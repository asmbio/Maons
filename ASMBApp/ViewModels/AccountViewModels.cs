using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMBApp.ViewModels
{
    public partial class AccountViewModels:Magic.MAUI.ODbContext<Models.Account,DataPravider.AccountDatapravider>
    {
        //[ObservableProperty]
        //private string password;
        public async void GetAccount()
        {
            try
            {
                if (Model.Address == null) return;
                var add = SimpleBase.Base58.Bitcoin.Decode(Model.Address).ToArray();
                var aRpcClient = NASMB.Fullapi.FindSliceApiService(add);
                var ret = await aRpcClient.SendRequestAsync<NASMB.TYPES.StateAccount>("GetAccount", null, add);


                //  Model.Balance = ret.Balance;
                //  var ss = Model.Balance / 1;
                Model.copyfromStateact(ret);
               
            }
            catch (Exception e  )
            {

                Magic.MAUI.LogHelper.DefaultLogger.Error(e);    
            }
        

        }
    }


}
