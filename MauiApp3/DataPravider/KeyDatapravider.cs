using ASMB.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASMB.DataPravider
{
    public class AccountDatapravider : Magic.MAUI.IDataProvider<Models.Account>
    {
        public Task<Account> Delete(Account oItem)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(IEnumerable<Account> list)
        {
            throw new NotImplementedException();
        }

        public async Task<(int total, IEnumerable<Account> list, IEnumerable<IGrouping<object, Account>> group)> GetList(Dictionary<string, object> query, int pageNo, int pageSize, DateTime? stime, DateTime? etime, string orderby, string orderKey, string groupkey)
        {
            var alist = new List<Account>();

            var klist =  await NASMB.GO.Localchainapi.Wallet.SendRequestAsync<JToken>("List", null) as JToken;
            foreach (byte[] item in klist)
            {
                alist.Add(new Account() { Address = new NASMB.TYPES.AsmbAddress(item).ToString() });
            }

            // NASMB.GO.Localchainapi.Wallet.SendRequestAsync()
            return ( alist.Count, alist, null );
        }

        public Task<(int total, IEnumerable<Account> list, IEnumerable<IGrouping<object, Account>> group)> GetListLike(Dictionary<string, object> query, int pageNo, int pageSize, DateTime? stime, DateTime? etime, string orderby, string orderKey, string groupkey)
        {
            throw new NotImplementedException();
        }

        public Task<Account> GetModel(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Account>> Input(IEnumerable<Account> list)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Insert(Account oItem)
        {

            var addr = NASMB.GO.Localchainapi.Wallet.SendRequestAsync<JToken>("New", null);


            //var addr= ASMB.ViewModels.MyWallet.GetWallet().New();
            oItem = new Account();
            oItem.Address = SimpleBase.Base58.Bitcoin.Encode((byte[])addr.Result );



            return Task.FromResult(oItem);
            //return ASMB.ViewModels.MyWallet.GetWallet().Keys.Defaultkey
        }

        public Task<IEnumerable<Account>> OverrideImporting(IEnumerable<Account> list)
        {
            throw new NotImplementedException();
        }

        public Task<Account> Update(Account oItem)
        {
            throw new NotImplementedException();
        }
    }
}
