using CommunityToolkit.Mvvm.DependencyInjection;
using Magic.MAUI;

namespace ASMB
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
          //  AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
                // MainPage = new login();
                ////Microsoft.Maui.Devices.DeviceInfo .Idiom
                MainPage = new MainPage();
            

        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            LogHelper.DefaultLogger.Error(e.ExceptionObject);
        }

        //private void CurrentDomain_ProcessExit(object sender, EventArgs e)
        //{
        
        //}

        public void ConfigureServices()
        {
            Ioc.Default.ConfigureServices(
                    new ServiceCollection()
                    .AddSingleton<ViewModels.MyWallet>() //Services
                    .AddSingleton<IDataProvider<Models.Account>,DataPravider.AccountDatapravider>()
                    .AddSingleton<ViewModels.AccountViewModels>()
                    //.AddSingleton<IFilesService, FilesService>()
                    //.AddSingleton<ISettingsService, SettingsService>()
                    //.AddSingleton(RestService.For<IRedditService>("https://www.reddit.com/"))
                    //.AddSingleton(RestService.For<IContactsService>("https://randomuser.me/"))
                    //.AddTransient<PostWidgetViewModel>() //ViewModels
                    //.AddTransient<SubredditWidgetViewModel>()
                    //.AddTransient<ContactsListWidgetViewModel>()
                    //.AddTransient<AsyncRelayCommandPageViewModel>()
                    //.AddTransient<IocPageViewModel>()
                    //.AddTransient<MessengerPageViewModel>()
                    //.AddTransient<ObservableObjectPageViewModel>()
                    //.AddTransient<ObservableValidatorPageViewModel>()
                    //.AddTransient<ValidationFormWidgetViewModel>()
                    //.AddTransient<RelayCommandPageViewModel>()
                    //.AddTransient<CollectionsPageViewModel>()
                    //.AddTransient<SamplePageViewModel>()
                    .BuildServiceProvider());

        }
        /// <inheritdoc/>

        //protected async override void OnStart()
        //{
        //    base.OnStart();
        //    ASMB.Views.Pwd pwd = new ASMB.Views.Pwd(true);
        //    //pwd.ac
        //    string paswd = (string)(await this.ShowPopupAsync(pwd));


        //    if (ASMB.ViewModels.MyWallet.GetWallet(paswd) == null)
        //    {
        //       // await DisplayAlert("", "钱包密码错误", "确定");
        //    }
        //}

    }
}