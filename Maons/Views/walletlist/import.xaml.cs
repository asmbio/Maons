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

                await this.DisplayAlert("����", "����ɹ�", "�ر�");
			}
			else
			{
                await this.DisplayAlert("����", "����ʧ��", "�ر�");
            }

		
        }
		catch (Exception ex)
		{
            await this.DisplayAlert("����", ex.Message, "�ر�");
        }


    }
}