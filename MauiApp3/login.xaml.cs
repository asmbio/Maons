
using ASMB.ViewModels;
using Maons;
using Maons.Controls;
using System.Runtime.Intrinsics.X86;

namespace ASMB;

public partial class login : ContentPage
{
	public login()
	{
		InitializeComponent();
	}

     void  OnOKButtonClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(epwd.Text))
        {
            return;
        }

        MauiApp3.App.Startgomaons(epwd.Text);

        var MainPage1 = new NavigationPage(  new ContentPage(  ) {  Content = new Maons.Maons() });
        //NavigationPage.HasNavigationBar = false;
        NavigationPage.SetHasNavigationBar(MainPage1.RootPage, false);

        Application.Current.MainPage = MainPage1;

    }
}