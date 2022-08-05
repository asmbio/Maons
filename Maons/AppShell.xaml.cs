using ASMB.ViewModels;
using CommunityToolkit.Maui.Views;

namespace ASMB
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            //this.
            
        }

        internal async Task<bool> login()
        {
            ASMB.Views.Pwd pwd = new ASMB.Views.Pwd();
            //pwd.ac
            string paswd = (string)(await this.ShowPopupAsync(pwd));


            if (ASMB.ViewModels.MyWallet.GetWallet(paswd) == null)
            {
                await DisplayAlert("", "钱包密码错误", "确定");
                return false;
            }

            return true;
        }

            //async void OnOKButtonClicked(object? sender, EventArgs e)
            //{
            //    if (string.IsNullOrEmpty(epwd.Text))
            //    {
            //        return;
            //    }
            //    var w = ASMB.ViewModels.MyWallet.GetWallet(epwd.Text);
            //    if (w == null)
            //    {
            //        await DisplayAlert("", "钱包密码错误", "确定");
            //        return;
            //    }
            //    var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
            //    avm.GetList();
            //    avm.Model = avm.List.First(p => p.Address.SequenceEqual(w.Keys.Defaultkey.Address));

            //   // this.RemoveLogicalChild(login);
            //  //  login.IsVisible = false;
            //  //  flyout.IsVisible = true;

            //}
            //protected async override void OnAppearing()
            //{
            //    base.OnAppearing();


            //        //ASMB.Views.Pwd pwd = new ASMB.Views.Pwd(true);
            //        ////pwd.ac
            //        //string paswd = (string)(await this.ShowPopupAsync(pwd));


            //        //if (ASMB.ViewModels.MyWallet.GetWallet(paswd) == null)
            //        //{
            //        //    await DisplayAlert("", "钱包密码错误", "确定");
            //        //}



            //}

            private void flyout_HandlerChanged(object sender, EventArgs e)
        {

        }
    }
}