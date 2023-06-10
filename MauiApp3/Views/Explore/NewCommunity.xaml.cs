using ASMB.ViewModels;
using Maons.Controls;
using Maons.Views.my;
using MauiApp3;

namespace Maons.Explore;

public partial class NewCommunity : ContentView
{
	public NewCommunity()
	{
		InitializeComponent();
    }
    private async void ImageButton_Clicked(object sender, EventArgs e)
    {

       var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        //if (avm.Model.Address == null || avm.Model.MetaEx == null)
        //{
        //    await App.Current.MainPage.DisplayAlert("刷新后重试", "", "关闭");
        //    return;
        //}
        this.Push(new Avatar(avm.Newcommunity));
    }
}