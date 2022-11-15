using Maons;


namespace MauiApp3
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //var lan = new Languages();
            //lan.InitLan();
            var   MainPage1 = new NavigationPage( new Maons.Maons()) { };
            //NavigationPage.HasNavigationBar = false;
           NavigationPage.SetHasNavigationBar(MainPage1.RootPage, false);
            
            MainPage = MainPage1;

        
        }
    }
}