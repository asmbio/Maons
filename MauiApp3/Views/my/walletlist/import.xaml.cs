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
                await Application.Current.MainPage.DisplayAlert("导入", "导入成功", "关闭");
            }
            catch (Exception )
			{
                await Application.Current.MainPage.DisplayAlert("导入", "导入失败", "关闭");
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
            await Application.Current.MainPage.DisplayAlert("错误", ex.Message, "关闭");
        }


    }
}