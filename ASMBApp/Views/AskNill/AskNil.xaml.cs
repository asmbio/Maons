using ASMBApp.ViewModels;

namespace ASMBApp.Views.AskNill;

public partial class AskNil : ContentPage
{
	public AskNil()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var avm = VMlc.ServiceProvider.GetService<ASMBApp.ViewModels.AccountViewModels>();
		if (await avm.asknil())
		{
			await this.DisplayAlert("请求代币", "请求确认中，请等待30s左右刷新查看", "关闭");
			await Navigation.PopAsync();
		}
	}
}