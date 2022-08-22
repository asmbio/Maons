using ASMB.ViewModels;

namespace ASMB.Views.walletlist;

public partial class import : ContentPage
{
	public import()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{ 
		try
		{
			var w = ASMB.ViewModels.MyWallet.GetWallet();

            if (w.Import(exportedit.Text, pwd.Text))
			{

                await this.DisplayAlert("导入", "导入成功", "关闭");
			}
			else
			{
                await this.DisplayAlert("导入", "导入失败", "关闭");
            }
            var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
            avm.GetList();
            avm.Model = avm.List.First(p => p.Address == w.Keys.Defaultkey.Address.Address);
            await Navigation.PopAsync();
            //await this.po

        }
		catch (Exception ex)
		{
            await this.DisplayAlert("错误", ex.Message, "关闭");
        }


    }
}