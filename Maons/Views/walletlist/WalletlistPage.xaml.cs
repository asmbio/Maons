using ASMB.ViewModels;

namespace ASMB.Views.walletlist;

public partial class WalletlistPage : ContentPage
{
	public WalletlistPage()
	{
		InitializeComponent();

        gridcontent.SetBinding(Grid.HeightRequestProperty,new Binding(source:App.Current,path: "MainPage.CurrentPage.Height"));


    }

	private async void collectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		try
        {
            var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
            avm.GetAccount(avm.Model);

            await Navigation.PopAsync();


        }
        catch (Exception ex)
		{

			await this.DisplayAlert("ÍøÂç´íÎó", ex.Message, "¹Ø±Õ");
		}

    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ASMB.Views.walletlist.NewAccount());
    }

	private async void daochu_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ASMB.Views.walletlist.export());
    }

	private async void daoru_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new ASMB.Views.walletlist.import());
    }
}