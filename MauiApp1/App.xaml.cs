using Maons.my;

namespace MauiApp1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var lan = new Languages();
            lan.InitLan();

            MainPage = new MainPage();
        }
    }
}