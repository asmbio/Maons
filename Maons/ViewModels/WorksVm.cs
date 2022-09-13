using ASMB.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASMB;
using NASMB.TYPES;
using Nethereum.RLP;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMB.ViewModels
{
    public partial class WorksVm: CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public WorksVm(string pindao)
        {
            Account=  new Account() { Address = pindao };
        }

  

        [ObservableProperty]
        private bool isRefreshing = false;

        #region zhuye
        [ObservableProperty]
        private Account account;

        private RelayCommand getworkssCmd;
        public RelayCommand GetWorkssCmd
        {
            get
            {
                return getworkssCmd ?? (getworkssCmd = new RelayCommand(GetWorkss));
            }
        }
        public async void GetWorkss()
        {
            try
            {
                if (account.Address == null) return;
                // if (Model.Messagebs == null) return;
                if (account.Messagebs == null)
                {
                    account.Messagebs = new ObservableCollection<Messagebs>();
                }
                var add = SimpleBase.Base58.Bitcoin.Decode(account.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, add, null, null, 10);
                //    var msglist = new List<Messagebs>() { };
                // ret=  ;
                foreach (var item in ret.Reverse())
                {
                    if (item.Msgtype == Msgtype.SignWorks || item.Msgtype == Msgtype.ChanSignWorks)
                    {
                        if (account.Messagebs.FirstOrDefault(p => p.Time == item.Time) == null)
                        {
                            account.Messagebs.Insert(0, item);
                            // msglist.Add(item);
                        }
                        //account.Messagebs =  account.Messagebs.Append(item);                        
                    }
                    continue;
                }
                //   = msglist.Concat( account.Messagebs).ToArray() ;
                //  Moaccount.Messagebs del.Balance = ret.Balance;
                //  var ss = Model.Balance / 1;
                // account.Messagebs = msglist.ToArray();
            }
            catch (Exception e)
            {
                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                if (App.Current.MainPage.IsLoaded)
                {
                    await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");

                }
            }
            IsRefreshing = false;

        }

        private RelayCommand apendWorkssCmd;
        public RelayCommand ApendWorkssCmd
        {
            get
            {
                return apendWorkssCmd ?? (apendWorkssCmd = new RelayCommand(ApendWorkss));
            }
        }
        private bool iszhuyeend = false;


        public async void ApendWorkss()
        {
            try
            {
                if (iszhuyeend)
                {
                    return;
                }

                if (account.Address == null)
                {
                    return;
                }
                // if (Model.Messagebs == null) return;
                if (account.Messagebs == null)
                {
                    account.Messagebs = new ObservableCollection<Messagebs>();
                }
                // var last = account.Messagebs[]
                var add = SimpleBase.Base58.Bitcoin.Decode(account.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, add, null, account.Messagebs.Last()._Shakey, 10);
                //    var msglist = new List<Messagebs>() { };
                // ret=  ;
                if (ret.Length == 0)
                {
                    iszhuyeend = true;
                }
                foreach (var item in ret)
                {
                    if (item.Msgtype == Msgtype.SignWorks || item.Msgtype == Msgtype.ChanSignWorks)
                    {
                        if (account.Messagebs.FirstOrDefault(p => p.Time == item.Time) == null)
                        {
                            account.Messagebs.Add(item);
                            // msglist.Add(item);
                        }
                        //account.Messagebs =  account.Messagebs.Append(item);                        
                    }
                    continue;
                }
                //   = msglist.Concat( account.Messagebs).ToArray() ;
                //  Moaccount.Messagebs del.Balance = ret.Balance;
                //  var ss = Model.Balance / 1;
                // account.Messagebs = msglist.ToArray();

            }
            catch (Exception e)
            {
                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                if (App.Current.MainPage.IsLoaded)
                {
                    await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");

                }
            }
        }

        #endregion
    }
}
