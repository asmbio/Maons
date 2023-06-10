using ASMB.ViewModels;
using Maons.Controls;
using MauiApp3;
namespace ASMB.Views.walletlist;

public partial class WalletlistPage : ContentView
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

            this.Pop();


        }
        catch (Exception ex)
		{

			await Application.Current.MainPage.DisplayAlert("正在连接主网", ex.Message, "关闭");
		}

    }

	private  void Button_Clicked_1(object sender, EventArgs e)
	{
        
         this.Push(new ASMB.Views.walletlist.NewAccount());
    }

	private  void daochu_Clicked(object sender, EventArgs e)
	{
        this.Push(new ASMB.Views.walletlist.export());
    }

	private  void daoru_Clicked(object sender, EventArgs e)
	{
        this.Push(new ASMB.Views.walletlist.import());
    }
}