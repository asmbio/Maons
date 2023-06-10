using ASMB.ViewModels;
using Maons.Controls;

namespace ASMB.Views.walletlist;

public partial class import : ContentView
{
	public import()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{ 
		try
		{
			try
			{
                await NASMB.GO.Localchainapi.Wallet.SendRequestAsync("Import", "", exportedit.Text, pwd.Text);
                await Application.Current.MainPage.DisplayAlert("����", "����ɹ�", "�ر�");
            }
            catch (Exception )
			{
                await Application.Current.MainPage.DisplayAlert("����", "����ʧ��", "�ر�");
            }
         
            var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
            avm.GetList();

            var daddr= await NASMB.GO.Localchainapi.Wallet.SendRequestAsync<byte[]>("Default", "");
            avm.Model = avm.List.First(p => p.Address == (new NASMB.TYPES.AsmbAddress(daddr)).ToString() );
            this.Pop();
            //await this.po

        }
		catch (Exception ex)
		{
            await Application.Current.MainPage.DisplayAlert("����", ex.Message, "�ر�");
        }


    }
}