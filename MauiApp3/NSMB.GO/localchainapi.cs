using DynaJson;
using Google.Protobuf;
using NASMB;
using NASMB.TYPES;
using Nethereum.JsonRpc.Client;
using Nethereum.RLP;
using Newtonsoft.Json.Linq;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace NASMB.GO
{
    public class Localchainapi
    {
        static string authkey = string.Empty;
        static TYPES.AsmbAddress addr;
        static TYPES.AsmbAddress lslice;
        public Localchainapi()
        {

        }


        //
        public async static Task Auth(string pwd)
        {
            //
        
            //  
            //  var url = new System.Url("http://127.0.0.1:8106");
            ARpcClient aRpcClient = new ARpcClient("http://127.0.0.1:8106", "maons", null);
            var token = await aRpcClient.SendRequestAsync<JToken>("GetAuth", null, pwd, "admin") as JToken;
            authkey = token["data"].ToString();
            AuthenticationHeaderValue DefaultauthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", authkey);
            ARpcClient aRpcClient1 = new ARpcClient("http://127.0.0.1:8106", "maons", DefaultauthenticationHeaderValue);

            var userjson = await aRpcClient1.SendRequestAsync<object>("GetUser", null);

              var user = JsonObject.Parse(userjson.ToString());
            //userjson.dat
             addr = new TYPES.AsmbAddress( user.data.id);
        }
        private static ARpcClient asmbClient = null;
        public  static ARpcClient AsmbClient
        {
            get
            {
               // byte[] slice = new byte[20];

               var rett =  NASMB.GO.Localchainapi.LocalApi.SendRequestAsync<TYPES.AsmbAddress>("Findslice", null, addr);
                var slice = rett.Result;


                //var len =   NASMB.GO.ASMB.Findslice(addr, slice, 20);
                //if (len==0)
                //{
                //    throw new Exception("正在连接主网");
                //}
                //var cslice = new byte[len];
                //Array.Copy(slice, cslice, len);
                if (asmbClient == null || !lslice.Address.Equals(slice.Address))
                {
                    //
                    lslice = slice;


                   

                    AuthenticationHeaderValue DefaultauthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", authkey);
                    asmbClient = new ARpcClient("http://127.0.0.1:8106", "asmb_" + lslice.Address, DefaultauthenticationHeaderValue);

                }
                return asmbClient;
            }
        }
        private static ARpcClient wallet = null;
        public static ARpcClient Wallet
        {
            get
            {
                if (wallet == null)
                {
                    if (string.IsNullOrEmpty( authkey))
                    {
                        throw new Exception("正在连接主网");
                    }
                    //
                    AuthenticationHeaderValue DefaultauthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", authkey);
                    wallet = new ARpcClient("http://127.0.0.1:8106", "wallet", DefaultauthenticationHeaderValue);

                }
                return wallet;
            }
        }

        private static ARpcClient localapi = null;
        public static ARpcClient LocalApi
        {
            get
            {
                if (localapi == null)
                {
                    if (string.IsNullOrEmpty(authkey))
                    {
                        throw new Exception("正在连接主网");
                    }
                    //
                    AuthenticationHeaderValue DefaultauthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", authkey);
                    localapi = new ARpcClient("http://127.0.0.1:8106", "local", DefaultauthenticationHeaderValue);

                }
                return localapi;
            }
        }

        private static ARpcClient maonapi = null;
        public static ARpcClient MaonsApi
        {
            get
            {
                if (maonapi == null)
                {
                    if (string.IsNullOrEmpty(authkey))
                    {
                        throw new Exception("正在连接主网");
                    }
                    //
                    AuthenticationHeaderValue DefaultauthenticationHeaderValue = new AuthenticationHeaderValue("Bearer", authkey);
                    maonapi = new ARpcClient("http://127.0.0.1:8106", "maons", DefaultauthenticationHeaderValue);

                }
                return maonapi;
            }
        }

    }
}
