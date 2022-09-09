using ASMB.ViewModels;

namespace ASMB;

public partial class login : ContentPage
{
	public login()
	{
		InitializeComponent();
	}

    async void  OnOKButtonClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(epwd.Text))
        {
            return;
        }
        var w = ASMB.ViewModels.MyWallet.GetWallet(epwd.Text);
        if (w == null)
        {
            await DisplayAlert("", "Ç®°üÃÜÂë´íÎó", "È·¶¨");
            return;
        }
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        avm.GetList();
        avm.Model = avm.List.First(p => p.Address == w.Keys.Defaultkey.Address.Address );

        await Shell.Current.GoToAsync("//zhuye");


    }
}