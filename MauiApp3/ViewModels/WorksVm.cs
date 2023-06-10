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
using MauiApp3;

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

                byte[] keys = null;

                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, add, null, keys, 10);
                if (ret.Length == 0)
                {
                    IsRefreshing = false;
                    return;
                }
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
                if (account.Messagebs.Count < 10)
                {
                    ApendWorkss();
                }

                //    var msglist = new List<Messagebs>() { };
                // ret=  ;





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
            finally
            {
                IsRefreshing = false;
            }
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
                var n1 = account.Messagebs.Count;
                byte[] keys = null;
                if (n1>0)
                {
                    keys = account.Messagebs.Last()._Shakey;
                }
            
                do
                {
                    var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, add, null, keys, 10);
                    //    var msglist = new List<Messagebs>() { };
                    if (ret.Length == 0)
                    {
                        iszhuyeend = true;
                        return;
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
                    keys = ret.Last()._Shakey;
                } while (account.Messagebs.Count-n1 < 10);

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
