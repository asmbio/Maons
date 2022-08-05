using CommunityToolkit.Mvvm.ComponentModel;

namespace ASMB.ViewModels
{
    internal partial class MyWallet
    {

        public static readonly MyWallet Instance = new MyWallet();
        private static NASMB.Wallet.Wallet wallet;
        public static NASMB.Wallet.Wallet GetWallet(string pwd)
        {
            if (wallet == null)
            {
                try
                {
                    wallet = new NASMB.Wallet.Wallet(FileSystem.AppDataDirectory+"/ASMB", pwd);
                }
                catch (Exception)
                {

                    return null;
                }            
               
            }
            else
            {
                if ( !wallet.Vdpwd(pwd))
                {
                    return null;
                }
            }
            wallet.Pwd = pwd;
            return wallet;
        }


        public static NASMB.Wallet.Wallet GetWallet()
        {

            return wallet;
        }


        //public string Password
        //{
        //    get { return _pwd; }
        //    set
        //    {
        //        _pwd = value;
        //        RaisePropertyChanged("Password");
        //    }
        //}

    }
}
