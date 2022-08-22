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

                await this.DisplayAlert("����", "����ɹ�", "�ر�");
			}
			else
			{
                await this.DisplayAlert("����", "����ʧ��", "�ر�");
            }
            var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
            avm.GetList();
            avm.Model = avm.List.First(p => p.Address == w.Keys.Defaultkey.Address.Address);
            await Navigation.PopAsync();
            //await this.po

        }
		catch (Exception ex)
		{
            await this.DisplayAlert("����", ex.Message, "�ر�");
        }


    }
}