namespace ASMBUI;

public partial class wallet : ContentPage
{
	public string Testtext = "fanhai";
	public wallet()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		//var page = new Views.walletlist.MainPage();
		
        await Navigation.PushAsync(new  Views.walletlist.WalletlistPage());
    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.shoukuan());
    }

	private async void Button_Clicked_2(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.zhuanzhang());
    }

	private async void shoukuan_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.shoukuan());
    }

	private async void zhuanzhang_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.zhuanzhang());
    }
}