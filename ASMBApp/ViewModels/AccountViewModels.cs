using ASMBApp.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASMB;
using NASMB.TYPES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMBApp.ViewModels
{
    public partial class AccountViewModels : Magic.MAUI.ODbContext<Models.Account, DataPravider.AccountDatapravider>
    {
        public AccountViewModels()
        {
            //transmsg = new NASMB.TYPES.Transmsg();
        }
        //[ObservableProperty]
        //private string password;


        private RelayCommand getAccountCmd;
        public RelayCommand GetAccountCmd
        {
            get
            {
                return getAccountCmd ?? (getAccountCmd = new RelayCommand(GetAccount));
            }
        }
 

          public async void GetAccount()
        {
            try
            {
                if (Model.Address == null) return;
                var add = SimpleBase.Base58.Bitcoin.Decode(Model.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.StateAccount>("GetAccount", null, add);


                //  Model.Balance = ret.Balance;
                //  var ss = Model.Balance / 1;
                Model.copyfromStateact(ret);

                GetRecipts();

            }
            catch (Exception e)
            {

                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
            }


        }
        private RelayCommand getReciptsCmd;
        public RelayCommand GetReciptsCmd
        {
            get
            {
                return getReciptsCmd ?? (getReciptsCmd = new RelayCommand(GetRecipts));
            }
        }


        public async void GetRecipts()
        {
            try
            {
                if (Model.Address == null) return;
               // if (Model.Messagebs == null) return;
             
                var add = SimpleBase.Base58.Bitcoin.Decode(Model.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, add, UInt64.MaxValue, 10);


                //  Model.Balance = ret.Balance;
                //  var ss = Model.Balance / 1;
                Model.Messagebs = ret;

            }
            catch (Exception e)
            {

                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
            }


        }
        //[ObservableProperty]
        private ASMBApp.Models.Transmsg transmsg = new ASMBApp.Models.Transmsg();

        public ASMBApp.Models.Transmsg Transmsg
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
                var ret = await ((AppShell)App.Current.MainPage).login();
                if (!ret)
                {
                    return false;
                }
                NASMB.TYPES.SignTransmsg signTransmsg = new NASMB.TYPES.SignTransmsg();
                signTransmsg.Transmsg = new NASMB.TYPES.Transmsg();
                signTransmsg.Transmsg.From.Address = Model.Address;
                signTransmsg.Transmsg.To = transmsg.To;
                signTransmsg.Transmsg.Feesrate = transmsg.Feesrate;
                signTransmsg.Transmsg.Balance = transmsg.Balance;
                //signTransmsg.Transmsg.Time = 637944439095943909;
                signTransmsg.Transmsg.Time = (UInt64)System.DateTime.Now.Ticks *100 + 621355968000000000;

                var rlpb = signTransmsg.Transmsg.RlpEncode();
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

    }


}
