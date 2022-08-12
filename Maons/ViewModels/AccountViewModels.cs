
using ASMB.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASMB;
using NASMB.TYPES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace ASMB.ViewModels
{
    public partial class AccountViewModels : Magic.MAUI.ODbContext<Models.Account, DataPravider.AccountDatapravider>
    {
        public AccountViewModels()
        {
            //transmsg = new NASMB.TYPES.Transmsg();
        }
        //[ObservableProperty]
        //private string password;

        [ObservableProperty]
        public bool isRefreshing = false;

        private RelayCommand<Account> getAccountCmd;
        public RelayCommand<Account> GetAccountCmd
        {
            get
            {
                return getAccountCmd ?? (getAccountCmd = new RelayCommand<Account>(GetAccount));
            }
        }
 


        public async void GetAccount(Account account)
        {
            try
            {
                if (account ==null)
                {
                    account = Model;
                }
                if (account.Address == null) {
                    var ret1 = await ((AppShell)App.Current.MainPage).login();
                    if (!ret1)
                    {
                        return;
                    }
                    //var w =ASMB.ViewModels.MyWallet.GetWallet();
                    GetList();   
                   await App.Current.MainPage. Navigation.PushAsync(new Views.walletlist.WalletlistPage());
                    return;
                }
                var add = SimpleBase.Base58.Bitcoin.Decode(account.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.StateAccount>("GetAccount", null, add);


                //  Model.Balance = ret.Balance;
                //  var ss = Model.Balance / 1;
                account.copyfromStateact(ret);

                GetRecipts(account);

            }
            catch (Exception e)
            {

                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
            }
            IsRefreshing = false;

        }
        private RelayCommand<Account> getReciptsCmd;
        public RelayCommand<Account> GetReciptsCmd
        {
            get
            {
                return getReciptsCmd ?? (getReciptsCmd = new RelayCommand<Account>(GetRecipts));
            }
        }
     

        public async void GetRecipts(Account account)
        {
  
            try
            {

                if (account.Address == null) return;
               // if (Model.Messagebs == null) return;
             
                var add = SimpleBase.Base58.Bitcoin.Decode(account.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, add, UInt64.MaxValue, 10);


                //  Model.Balance = ret.Balance;
                //  var ss = Model.Balance / 1;
                account.Messagebs = ret;

            }
            catch (Exception e)
            {

                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
            }
            IsRefreshing = false;

        }
        //[ObservableProperty]
        private ASMB.Models.Transmsg transmsg = new ASMB.Models.Transmsg();

        public ASMB.Models.Transmsg Transmsg
        {
            get { return transmsg; }
            set
            {
                if (transmsg.Equals(value))
                {
                    transmsg = value;
                    RaisePropertyChanged("Transmsg");
                }
            }
        }


        //private RelayCommand zhuanzhangCmd;
        //public RelayCommand ZhuanzhangCmd
        //{
        //    get
        //    {
        //        return zhuanzhangCmd ?? (zhuanzhangCmd = new RelayCommand(Zhuanzhang));
        //    }
        //}

        //private void Zhuanzhang(bool obj)
        //{
        //    throw new NotImplementedException();
        //}

        internal async Task<bool> Zhuanzhang()
        {
            try
            {
                if (transmsg.Balance <= 0 )
                {
                    await App.Current.MainPage.DisplayAlert("输入错误", "金额", "关闭");
                    return false;
                }
                if (transmsg.Balance >= Model.Balance)
                {
                    await App.Current.MainPage.DisplayAlert("输入错误", "金额超过余额", "关闭");
                    return false;
                }

                if (transmsg.Feesrate <= 0)
                {
                    await App.Current.MainPage.DisplayAlert("输入错误", "费率", "关闭");
                    return false;
                }

                var ret = await ((AppShell)App.Current.MainPage).login();
                if (!ret)
                {
                    return false;
                }
                NASMB.TYPES.SignTransmsg signTransmsg = new NASMB.TYPES.SignTransmsg();
                signTransmsg.Transmsg = new NASMB.TYPES.Transmsg();
                signTransmsg.Transmsg.From = new AsmbAddress(Model.Address);
                //signTransmsg.Transmsg.From =  SetAddress( Model.Address);
                signTransmsg.Transmsg.To = transmsg.To;
                signTransmsg.Transmsg.Feesrate = transmsg.Feesrate;
                signTransmsg.Transmsg.Balance = transmsg.Balance;
                signTransmsg.Transmsg.Marks = transmsg.Marks;
                //signTransmsg.Transmsg.Time = 637944439095943909;
                signTransmsg.Transmsg.Time = (UInt64)(System.DateTime.Now.ToUniversalTime().Ticks  - 621355968000000000)*100;


                var rlpb = signTransmsg.Transmsg.RlpEncode();


                var istreu= await App.Current.MainPage.DisplayAlert(title: "交易确认", message: $"交易金额:{NASMB.TYPES.Maons.FromNil(signTransmsg.Transmsg.Balance)};\t\n总费用：{Maons.FromNil(new System.Numerics.BigInteger(signTransmsg.Transmsg.Feesrate) * (rlpb.Length+ 69)*2)}","确定","取消");
                if (!istreu)
                {
                    return false;
                }

                // var rlphex = Convert.ToHexString(rlpb);
                var w = MyWallet.GetWallet();
                if (w == null)
                {
                    return false;
                }
                signTransmsg.Sign = w.Sign(signTransmsg.Transmsg.From.GetAddressbyte(), rlpb);

                Messagebs messagebs = new Messagebs();
                messagebs.Body = signTransmsg;
                messagebs.Msgtype = signTransmsg.Transmsg.Msgtype;

                var msg = Newtonsoft.Json.JsonConvert.SerializeObject(messagebs);


                var aRpcClient = Fullapi.FindSliceApiService(signTransmsg.Transmsg.From.GetAddressbyte());
                await aRpcClient.SendRequestAsync<object>("Pubmsg", null, messagebs);

                // 记录到本地缓存 跟踪消息状态
                return true;

            }
            catch (Exception e)
            {

                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
                return false;
            }
          
        }
        //private RelayCommand asknillCmd;
        //public RelayCommand AsknilCmd
        //{
        //    get
        //    {
        //        return asknillCmd ?? (asknillCmd = new RelayCommand(asknill));
        //    }
        //}
        internal async Task<bool> asknil()
        {
            try
            {
                var add = SimpleBase.Base58.Bitcoin.Decode(Model.Address).ToArray();
                var aRpcClient = Fullapi.FindSliceApiService(add);
                await aRpcClient.SendRequestAsync<object>("AskNil", null, add);
                return true;
            }
            catch (Exception e)
            {
                Magic.MAUI.LogHelper.DefaultLogger.Error(e);

               await App.Current.MainPage .DisplayAlert("网络错误", e.Message, "关闭");
                return false;

            }
        

        }


        #region egg1


        private System.Timers.Timer aTimer;

        //public static void Main()
        //{
        //    SetTimer();

        //    Console.WriteLine("\nPress the Enter key to exit the application...\n");
        //    Console.WriteLine("The application started at {0:HH:mm:ss.fff}", DateTime.Now);
        //    Console.ReadLine();
        //    aTimer.Stop();
        //    aTimer.Dispose();

        //    Console.WriteLine("Terminating the application...");
        //}

        public async void SetTimer()
        {
            try
            {
                if (aTimer == null)
                {
                    // Create a timer with a two second interval.
                    aTimer = new System.Timers.Timer(16000);
                    // Hook up the Elapsed event for the timer. 
                    aTimer.Elapsed += OnTimedEvent;
                    aTimer.AutoReset = true;
                    aTimer.Enabled = true;
                    var From = new AsmbAddress(Model.Address);
                    var aRpcClient = Fullapi.FindSliceApiService(From.GetAddressbyte());
                    // SignEgg1msg signEgg1Msg = new SignEgg1msg() { Egg1msg = new Egg1msg() { From = new AsmbAddress(Model.Address) } };
                    var sEgg1Msg = await aRpcClient.SendRequestAsync<Egg1msg>("EnEgg1Code", null);

                    var code22 = await aRpcClient.SendRequestAsync<byte[]>("DeEgg1Code", null,sEgg1Msg.Randomcode,sEgg1Msg.Time);



                    Account.Address = SimpleBase.Base58.Bitcoin.Encode(code22);
                }
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("错误", ex.Message, "关闭");

            }

        }
        // private byte[] code2 { get; set; }
        [ObservableProperty]
        private bool isauto =false; 

        [ObservableProperty]
        private string egg1str = "...";
        
        [ObservableProperty]
        private Models.Account account = new Models.Account() { Messagebs = new Messagebs[] { } };

      //  ViewModels.AccountViewModels avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (isauto == false)
            {
                return;
            }
            try
            {
                
                egg1str = "挖矿中......";
             

                var w = ViewModels.MyWallet.GetWallet();
                if (w == null || string.IsNullOrEmpty(Model.Address))
                {

                    await App.Current.MainPage.DisplayAlert("提醒", "清先登录选择默认地址", "关闭");
                    return;
                }
                var From = new AsmbAddress(Model.Address);
                var aRpcClient = Fullapi.FindSliceApiService(From.GetAddressbyte());
               // SignEgg1msg signEgg1Msg = new SignEgg1msg() { Egg1msg = new Egg1msg() { From = new AsmbAddress(Model.Address) } };
                var sEgg1Msg = await aRpcClient.SendRequestAsync<Egg1msg>("EnEgg1Code", null);

                sEgg1Msg.From = From;
                SignEgg1msg signEgg1Msg = new SignEgg1msg() { };
                signEgg1Msg.Egg1msg = sEgg1Msg;
                //    signEgg1Msg.Egg1msg.From.Address =;

            

                var rlpb = signEgg1Msg.Egg1msg.RlpEncode();
                //var rlphex = Convert.ToHexString(rlpb);
                signEgg1Msg.Sign = w.Sign(signEgg1Msg.Egg1msg.From.GetAddressbyte(), rlpb);

                Messagebs messagebs = new Messagebs();
                messagebs.Body = signEgg1Msg;
                messagebs.Msgtype = signEgg1Msg.Egg1msg.Msgtype;

                var msg = Newtonsoft.Json.JsonConvert.SerializeObject(messagebs);
              
                var ret = await aRpcClient.SendRequestAsync<object>("Pubmsg", null, messagebs);
                //Thread.Sleep(3000);


                //egg1str = "";


            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("网络错误", ex.Message, "关闭");
                //egg1str  = $"网络错误：{ex.Message}";
            }


        }
        #endregion


    }


}
