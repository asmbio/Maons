using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using NASMB.TYPES;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMB.ViewModels
{
    internal partial class PinlunVm: CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public PinlunVm(NASMB.TYPES.Messagebs _msg)
        {
            Msg = _msg;
        }

        [ObservableProperty]
        private NASMB.TYPES.Messagebs msg;
     

        [ObservableProperty]
        private bool isRefreshing = false;

        private RelayCommand getWorksReceiptsCmd;
        public RelayCommand GetWorksReceiptsCmd
        {
            get
            {
                return getWorksReceiptsCmd ?? (getWorksReceiptsCmd = new RelayCommand(GetWorksReceipts));
            }
        }
        public async void GetWorksReceipts()
        {
            var swex = msg.Body as IWorksEx;
            byte[] workaddr = swex.WAddr().GetAddressbyte();

            byte[] key = msg._Shakey;
            try
            {
                //if (swex.GetWorksmsgEx().MyReceipts == null)
                //{
                //    swex.GetWorksmsgEx().MyReceipts = new ObservableCollection<Messagebs>();
                //}
                if (swex.GetWorksmsgEx().Receipts == null)
                {
                    swex.GetWorksmsgEx().Receipts = new ObservableCollection<Messagebs>();
                }
                //if (account.Address == null) return;
                //// if (Model.Messagebs == null) return;

                // var add = SimpleBase.Base58.Bitcoin.Decode(account.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindApiService(workaddr);
                var wex = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs>("GetWorksWithEx", null, workaddr, key);


                //swex.SetWorksmsgEx((wex.Body as IWorksEx).GetWorksmsgEx());
                swex.GetWorksmsgEx().Pinglun = (wex.Body as IWorksEx).GetWorksmsgEx().Pinglun;
                //swex.GetWorksmsgEx().Up = (wex.Body as IWorksEx).GetWorksmsgEx().Up;
                //swex.GetWorksmsgEx().Down = (wex.Body as IWorksEx).GetWorksmsgEx().Down;


                byte[] hash = swex.Rcphash();

                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, null, hash, null, 10);

                var msglist = new List<Messagebs>() { };
                foreach (var item in ret)
                {
                    if (item.Msgtype == Msgtype.SWorkscomment || item.Msgtype == Msgtype.CfmSWorkscomment)
                    {
                        if (swex.GetWorksmsgEx().Receipts.FirstOrDefault(p => p.Time == item.Time) == null)
                        {
                            msglist.Add(item);
                        }

                        //account.Messagebs =  account.Messagebs.Append(item);                        
                    }
                }

                //for (int i = swex.GetWorksmsgEx().MyReceipts.Count() - 1; i >= 0; i--)
                //{
                //    if (msglist.FirstOrDefault(p => p.Time == swex.GetWorksmsgEx().MyReceipts[i].Time) != null)
                //    {
                //        swex.GetWorksmsgEx().MyReceipts.Remove(swex.GetWorksmsgEx().MyReceipts[i]);
                //    }
                //}

                foreach (var item in msglist.ToArray().Reverse())
                {
                    swex.GetWorksmsgEx().Receipts.Insert(0,item);
                }
                // swex.GetWorksmsgEx().Receipts =  swex.GetWorksmsgEx().Receipts.Concat(msglist);
            }
            catch (Exception e)
            {

                Magic.MAUI.LogHelper.DefaultLogger.Error(e);
                await App.Current.MainPage.DisplayAlert("网络错误", e.Message, "关闭");
            }
            IsRefreshing = false;

        }


        private RelayCommand apendWorksReceiptsCmd;
        public RelayCommand ApendWorksReceiptsCmd
        {
            get
            {
                return apendWorksReceiptsCmd ?? (apendWorksReceiptsCmd = new RelayCommand(ApendWorksReceipts));
            }
        }
        private bool isend = false;


        public async void ApendWorksReceipts()
        {
            try
            {
                if (isend)
                {
                    return;
                }
                var swex = msg.Body as IWorksEx;
                byte[] workaddr = swex.WAddr().GetAddressbyte();

                byte[] key = msg._Shakey;

                // var last = account.Messagebs[]
                var aRpcClient = NASMB.Fullapi.FindApiService(workaddr);
              

                byte[] hash = swex.Rcphash();

                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.Messagebs[]>("GetReceipts", null, null, hash, swex.GetWorksmsgEx().Receipts.Last()._Shakey, 10);

                // ret=  ;
                if (ret.Length < 10)
                {
                    isend = true;
                }
                foreach (var item in ret)
                {
                    if (item.Msgtype == Msgtype.SWorkscomment || item.Msgtype == Msgtype.CfmSWorkscomment)
                    {
                        if (swex.GetWorksmsgEx().Receipts. FirstOrDefault(p => p.Time == item.Time) == null)
                        {
                            swex.GetWorksmsgEx().Receipts.Add(item);
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
    }
}
