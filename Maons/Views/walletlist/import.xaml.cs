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
			if (ASMB.ViewModels.MyWallet.GetWallet().Import(exportedit.Text, pwd.Text))
			{

                await this.DisplayAlert("导入", "导入成功", "关闭");
			}
			else
			{
                await this.DisplayAlert("导入", "导入失败", "关闭");
            }

		
        }
		catch (Exception ex)
		{
            await this.DisplayAlert("错误", ex.Message, "关闭");
        }


    }
}