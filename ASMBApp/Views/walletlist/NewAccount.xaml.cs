namespace ASMBApp.Views.walletlist;

public partial class NewAccount : ContentPage
{
	public NewAccount()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		await Navigation.PopAsync();

    }
}