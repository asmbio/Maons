using ASMB;
using ASMB.ViewModels;

namespace ASMB.Views;

public partial class zhuanzhang : ContentPage
{
	public zhuanzhang()
	{
		InitializeComponent();
	}
	

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
   

//#if __ANDROID__
//            // Initialize the scanner first so it can track the current context
//         //  MobileBarcodeScanner.Initialize(Application.Current);
//#endif

//            var scanner = new ZXing.Mobile.MobileBarcodeScanner();

//            var result = await scanner.Scan();

//            if (result != null)
//                   addr.Text = result.Text;
        
    }

	private void Button_Clicked(object sender, EventArgs e)
	{
		feilv.Text = feilv.Placeholder;

    }

	private void btnall_Clicked(object sender, EventArgs e)
	{
		jine.Text = jine.Placeholder ;
	}

	private async void Button_Clicked_1(object sender, EventArgs e)
	{

        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
		if(await avm.Zhuanzhang())
        {
            await this.DisplayAlert("转账", "请求确认中，请等待30s左右刷新查看", "关闭");
            await Navigation.PopAsync();

        }
    }
}