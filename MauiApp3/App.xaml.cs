using ASMB.ViewModels;
using CommunityToolkit.Maui.Views;
using Magic.MAUI;
using Maons;
using NASMB;

namespace MauiApp3
{
    public partial class App : Application
    {
        public  App()
        {
            InitializeComponent();
            
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            var lan = new Languages();
            lan.InitLan();
             //NASMB.GO.Localchainapi.Auth("123456");
            MainPage = new ASMB.login();
            LogHelper.DefaultLogger.Info("login");

        }
       static Task maonsgo;

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.DefaultLogger.Error(e.ExceptionObject);
        }
        public static string Pwd;
        public static void Startgomaons( string pwd)
        {
                string mainDir = FileSystem.Current.AppDataDirectory;
                maonsgo = Task.Run(() => {
#if Local

#else

                    NASMB.GO.ASMB.NewLightNode(pwd, mainDir + "/asmb");
                    //Thread.Sleep(1000);
#endif

                });
                
                Pwd= pwd;

        }

        internal static async Task<bool> login()
        {
            ASMB.Views.Pwd pwd = new ASMB.Views.Pwd();
            //pwd.ac
            string paswd = (string)(await (App.Current.MainPage).ShowPopupAsync(pwd));






            //   await Navigation.PushAsync(new Views.walletlist.WalletlistPage());

            return true;
        }
    }
}