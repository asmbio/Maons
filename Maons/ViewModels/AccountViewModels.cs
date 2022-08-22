
using ASMB.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASMB;
using NASMB.TYPES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
                if(Model.Address == null)
                {
                    await App.Current.MainPage.DisplayAlert("错误", "清先登录", "关闭");
                    return;
                }
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

        #region producer

        [ObservableProperty]
        private ObservableCollection<Models.Account> producers = new ObservableCollection<Account>();

        private RelayCommand getproducerCmd;
        public RelayCommand GetproducerCmd
        {
            get
            {
                return getproducerCmd ?? (getproducerCmd = new RelayCommand(getproducer));
            }
        }
        internal async void getproducer()
        {
            try
            {

                var pds = new string[] { "22xGFn6hd76h5nkA5uFt5pXKDfcb",
        "2tBFriXa3RAWXAVsFTfo7unCZ52H",
        "yxjZVqUcVKPvbciuXJ788tMLXnH",
        "3PSVKyHDrobMyWp4XHWktmrgKg7c",
        "4nx7yU2vft1MopCRxueDCdC1BoN",
        "3mndwomH4n4yKvQfTj9Zj3Tteb1S",
        "2g913NVWRbUuXNbfmXv2U7uY79vm",
        "3AN124up6U3mmJ4XGhXk46ATUNMf",
        "3W36cFF5b5EVdoXeWEovrtpdGapc",
        "4Z7AU6D4kzyMmz2Yeu1neq9Yusci",
        "4YWmbeTTNRZBdZ9xMPppGi8TDGun",
        "4XicFeJFnQNtUYSjPb7oB1asgHeH",
        "2pF896SVp5oSwahx7s4K3tqaBLZq",
        "c3N7u9DWfmmf4bBEHNvLaFVBo5A",
        "3taEVUPBmkKhFNer8dy8zTH1Ucms",
        "3GzDULzTMeFdphpFiYZdenc2Md3Q",
        "28sPwtCJq7Qc98y4sTJyS4Xwqto4",
        "4DpGRSJF1JzCtkeSQT7hSF16ZTD7",
        "2PZ22LzrgjnrCDrZpKCn4YNcVTcq",
        "4ZRE2Wx1MjbDJMkthuAeeDaQoS6P",
        "3Cs4HZtvxmvCGK45fzQXf5ffwo8W",
        "f2vTV2ebq93E33gSv9TzWbaQ5fP",
        "fmCPpf8gKrgJ1TuptwTX7LHZaAw",
        "43CmG9kcDSKcp6gd1N5LKNwWmwKg",
        "2BXMcLjchDXaiJYuwDWtQ9HsbBqj",
        "bAce2GC2AN1kVeCym1ibeXh9gLg",
        "3cW1Aqi4Be8ZVNEuQf737J3YC7bG",
        "24yd49En84qUKsMDHYQXZD1N9j5E",
        "24MFeTHn18hjoLoQ5jUQ1WV6HXR7",
        "2zm2DpSnX8pd9CgSQH22ALR2TUwz",
        "3FQQXCp1Uj3rKapwQUVaC6oUNtX4",
        "4Ahsij2dSpD1RRhjraxHhJCteeqE",
        "VdF1rB9ErqsM1kmJNDmUFX7ykSU",
        "askFhBQRvnmsgTtfxw1G1Qu7QN9",
        "4YFMLt1W6H2ATgSwRxqQkmfbGK5X",
        "3FmwJUQMtKD5HiwmDJBJmgKpxUBv",
        "3dramMd4TwwoKAsVPwXE1raYwg9W",
        "2m3LMHz2kxnBCVvKEAvccLowKMkm",
        "3q7b3ey7BxdSfbmPZgQqZsrHLobU",
        "nsG7iefD4PUQtowjW2QUmKQDoVL",
        "4X1FAggNdzCiCxpoRALVMAEYCF7F",
        "pVCAvHvRUzBwrD78D3cDo8ZAUpY",
        "2vokDjSkWgB4Czr1bbU2wnExS7x2",
        "4Xxe8qxEqh64GQ1kZT1KUNxtPBA4",
        "tAPd2QYjN8BrUuXxtzsVdFGauni",
        "31K921VDj4wEsbFqvv9jWYfuhS5v",
        "2pcpwNeKnoDQAKDLnJnPxYyhCVo9",
        "LatAkVZtBkf7yJ1cjx1MsFTa5th",
        "on5i1vH5eHgwJksAqapzEKwKyCH",
        "2mGdUbvMXLGg1i3nbgvadb8iQNmM",
        "3t4DkBMCGRBoqhYwzo2GkMW3LKUo",
        "42orvkXDqRXgXfLciDTEz7xoyYJ5",
        "4XEtP7mLSCYFPjreVRiSaRRfedaE",
        "2NsX9BrXdrNgwFXwU7UrGRPWJdBJ",
        "3LSRuRQzBx6pxuMzhMkNtX2ESyYr",
        "25cQofWuKyNmaSD6Kr8susFKSuei",
        "uj9Fevmfj54ebms4QBFGpyd3pVh",
        "3H9mQDYJkZ6USyyrQDQyvSiFwW2Y",
        "3uvddpjMFdeoRkBQk45Mu2ds2b6D",
        "231RCxSktK2thGTip66SgovqeUjs",
        "kPTriPUWuFDEt5WMmzgqVUKEYuP",
        "246z6gqQGaHx1Qhm2vFG9Rz688qc",
        "3a1GgmApdm1j3RbdPNfLBre8QCBP",
        "1Gwn3ppDoiBh9XsGkuCz4qn1CTf",
        "3QsrEd1EUgFAHhy9QuV5FgYG6WqU",
        "t7GxKhYRdcGQLUVWoHy1n1Je6Mc",
        "SpvVcs9RXywrmjmpCSGhBiV2qad",
        "23d4FX6qZfeQbXxBuFpSHv6KUeEq",
        "48XsimPGSjBUYYyZgwidpf39dELV",
        "2AvzJ9ZPXzDRJvsa8nEZzCQj6km3",
        "2uAi5n4rm7VmtfFHWpXk9mANArzG",
        "2fhYC44CBfRWGZnvV4F4DizBzvag",
        "knxxCjgi5eLNGGKTC4RBUB7hrMr",
        "S5aCJUNtuutHDK8iGPmqyvJ8Miy",
        "3RPtGkyAKXTddWat4Bx7gHpr8SPd",
        "5XnevkKqdmL9xyAKJxLtdVXyUMU",
        "3W7R7HzFeUJEq6YV8ND8sm2hHBNK",
        "42tdnfnebC5cumzPKZ3LnKK4EUah",
        "gvunr3uaL73QCj7stLpAjt1gc8C",
        "NRfAZcmPXrUXvDAZNKfZs9iSUPF",
        "2QX3Pe5EjHktUv9D5uxMwYtYSP3D",
        "QAneFX37L8nmEh9M1AtcgBpVqbF",
        "2aV3WeQdRx3HBQQTwcTjVJZC6s4F",
        "2esFoZFnTEsHtHUy52yNkFsbevvf",
        "2LorqD5V8UmfQnihmqp6neQsYNmU",
        "3zniQRzHpWGpfsKvc5fXYvMoTpH4",
        "3phXQ3Jw2S8B2YtZfHeWeeQCkUCd",
        "unkgxK2jFTZLP9ByFNLs9ZDja9C",
        "49FNJCzsqqo1dZZgcShaeKZSYoBX",
        "9buDa55VTK2YdQ9zeVd99RtjJrR",
        "3k3hdmg5F1W9PKaj91VzRk6xXE1n",
        "25CcLgYpNapVixuLvWXkFTryn4Rw",
        "83boq5UeKdSYburHFttNuXQ91bK",
        "2e13bh2nWytniHpsC8BotYvZFzaq",
        "3wjS7zhw9tWGBtL53sNHZAfaPtmf",
        "3y6qZk1Mn6bS1cDEo4STSmu1CS17",
        "3gpqHJv5831y2fh6eJxb5PKtbUd4",
        "2XRZESJnNMt7LBK9ShnQSjzsrBp6",
        "36ucZUsx5NM7GvBk5iAfZXPqavN4",
        "JhjoWWm8Y2N4848Q8tPBKNuXpAF"};

                for (int i = 0; i < pds.Length; i++)
                {
                    Producers.Add(new Account() {  Address = pds[i], Votest = new Models.VoteState() { Paiming = i, Votes = 0,OtherVotes=0 ,Marks="创世节点"} });
                }
                //foreach (var item in pds)
                //{
                    
                //}
                //var add = SimpleBase.Base58.Bitcoin.Decode(Model.Address).ToArray();
                //var aRpcClient = Fullapi.FindSliceApiService(add);
                //await aRpcClient.SendRequestAsync<object>("AskNil", null, add);
                //Producers = new ObservableCollection<Account>()
                //{
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},
                //    new Account(){ Address = ""},

                //};

                //return ;
            }
            catch (Exception e)
            {
                Magic.MAUI.LogHelper.DefaultLogger.Error(e);

                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
              //  return ;

            }
            IsRefreshing = false;

        }


        #endregion
    }


}
