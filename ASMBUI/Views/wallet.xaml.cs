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
}