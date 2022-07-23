using ASMBApp.ViewModels;

namespace ASMBApp.Views.walletlist;

public partial class WalletlistPage : ContentPage
{
	public WalletlistPage()
	{
		InitializeComponent();
		
	}

	private async void collectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{

        var avm = VMlc.ServiceProvider.GetService<ASMBApp.ViewModels.AccountViewModels>();
		avm.GetAccount();

        await Navigation.PopAsync();

    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ASMBApp.Views.walletlist.NewAccount());
    }
}