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
		try
        {
            var avm = VMlc.ServiceProvider.GetService<ASMBApp.ViewModels.AccountViewModels>();
            avm.GetAccount();

            await Navigation.PopAsync();


        }
        catch (Exception ex)
		{

			await this.DisplayAlert("ÍøÂç´íÎó", ex.Message, "¹Ø±Õ");
		}

    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ASMBApp.Views.walletlist.NewAccount());
    }
}