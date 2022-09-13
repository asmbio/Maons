using ASMB.ViewModels;

namespace ASMB;

public partial class Tianjia : CommunityToolkit.Maui.Views.Popup
{
    string channel = "";
	public Tianjia(string _channel)
	{
		InitializeComponent();
        channel = _channel;
        var cp = App.Current.MainPage as AppShell;
        //  Size =new Size(DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density-10, DeviceDisplay.Current.MainDisplayInfo.Height/ (DeviceDisplay.Current.MainDisplayInfo.Density*2));
        Size = new Size(cp.CurrentPage.Width, DeviceDisplay.Current.MainDisplayInfo.Height / DeviceDisplay.Current.MainDisplayInfo.Density);

        //  Size = new Size(DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density, DeviceDisplay.Current.MainDisplayInfo.Height / DeviceDisplay.Current.MainDisplayInfo.Density);
    }

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
		//App.Current.m
    }

    private void ImageButton_Clicked_1(object sender, EventArgs e)
    {
        Close();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        //var page = new Views.walletlist.MainPage();

        if (MyWallet.GetWallet() == null)
        {
            var cp = App.Current.MainPage as AppShell;
            var ret = await cp.login();
            if (!ret)
            {
                return;
            }
        }
        // var service = VMlc.Services.BuildServiceProvider();


        //ASMB. MauiProgram.Services
        //ASMB.MauiProgram.Services.ge
      //  await cp.Navigation.PushAsync(new Views.walletlist.WalletlistPage());
    }

    private async void ImageButton_Clicked_2(object sender, EventArgs e)
    {
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        if (string.IsNullOrEmpty( txtcontent.Text))
        {
          //  await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
            return;
        }
        if (await avm.Fasongcontent("", txtcontent.Text, channel))
        {
            await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
            Close();
           // await App.Current.MainPage.Navigation.PopAsync();
       }
    }
}