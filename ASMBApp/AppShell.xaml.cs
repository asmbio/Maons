using ASMBApp.ViewModels;
using CommunityToolkit.Maui.Views;

namespace ASMBApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //this.
            
        }

        //async void OnOKButtonClicked(object? sender, EventArgs e)
        //{
        //    if (string.IsNullOrEmpty(epwd.Text))
        //    {
        //        return;
        //    }
        //    var w = ASMBApp.ViewModels.MyWallet.GetWallet(epwd.Text);
        //    if (w == null)
        //    {
        //        await DisplayAlert("", "钱包密码错误", "确定");
        //        return;
        //    }
        //    var avm = VMlc.ServiceProvider.GetService<ASMBApp.ViewModels.AccountViewModels>();
        //    avm.GetList();
        //    avm.Model = avm.List.First(p => p.Address.SequenceEqual(w.Keys.Defaultkey.Address));

        //   // this.RemoveLogicalChild(login);
        //  //  login.IsVisible = false;
        //  //  flyout.IsVisible = true;

        //}
        //protected async override void OnAppearing()
        //{
        //    base.OnAppearing();

        
        //        //ASMBApp.Views.Pwd pwd = new ASMBApp.Views.Pwd(true);
        //        ////pwd.ac
        //        //string paswd = (string)(await this.ShowPopupAsync(pwd));


        //        //if (ASMBApp.ViewModels.MyWallet.GetWallet(paswd) == null)
        //        //{
        //        //    await DisplayAlert("", "钱包密码错误", "确定");
        //        //}


            
        //}

        private void flyout_HandlerChanged(object sender, EventArgs e)
        {

        }
    }
}