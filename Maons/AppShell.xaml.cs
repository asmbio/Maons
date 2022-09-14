using ASMB.ViewModels;
using CommunityToolkit.Maui.Views;

namespace ASMB
{
    public partial class AppShell : Shell
    {
        Dictionary<string, string> _data = new Dictionary<string, string>()
        {
            {"想法","htaM6rQvi4ci3bQ5uReAm5XXytv" },
            {"提案","3E4ZuLQW2NAtB8aCvH4CTm2iBVMa" },
            {"悬赏","4ZFmgxH4KPVzUtPS16CdoKAEw76Z" },
        };

        string curguangchang = "想法";
        public   AppShell()
        {
            InitializeComponent();
          
            //if (MyWallet.GetWallet() == null)
            //{
            //    Task.Run(() =>
            //    {
            //        Thread.Sleep(1000);

            //        this.Dispatcher.Dispatch(async () =>
            //        {
            //            var ret = await login();
            //            if (!ret)
            //            {
            //                return;
            //            }
            //            await Navigation.PushAsync(new Views.walletlist.WalletlistPage());
            //        });
            //    });
            //}

        }

        //protected async override void OnNavigated(ShellNavigatedEventArgs args)
        //{
        //    base.OnNavigated(args);
        //    //await login();
        //}

        //protected override  SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        //{
        
        //  var ee=   base.OnMeasure(widthConstraint, heightConstraint);
        //     login();
        //    return ee;
        //}
        //protected override async void OnAppearing()
        //{

        //    base.OnAppearing();


        //}
        //protected async override void OnSizeAllocated(double width, double height)
        //{
        //    base.OnSizeAllocated(width, height);
        //    await login();
        //}
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
            var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
            avm.GetList();

      
         //   await Navigation.PushAsync(new Views.walletlist.WalletlistPage());
         
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


        private async void ImageButton_Clicked(object sender, EventArgs e)
        {

            if (MyWallet.GetWallet() == null)
            {
                var ret = await login();
                if (!ret)
                {
                    return;
                }
                await Navigation.PushAsync(new Views.walletlist.WalletlistPage());        
        
            }
            else
            {
                if (curguangchang == "悬赏" && VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>().Model.Address != _data[curguangchang])
                {
                    await DisplayAlert("提示", "非管理员不能发布悬赏", "确定");
                    return;
                }
                ASMB.Tianjia pwd = new ASMB.Tianjia(_data[curguangchang]);
                //pwd.ac
                await this.ShowPopupAsync(pwd);
            }        
        }

        private async void ImageButton_Clicked_1(object sender, EventArgs e)
        {
            await GoToAsync("//zhuye");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            curguangchang = (sender as Button).Text;

            if (_data.ContainsKey(curguangchang))
            {
                await GoToAsync("//zhuye", new Dictionary<string, object>()
                {
                    {  "Vm",new WorksVm(_data[curguangchang]) }
                });
            }
            else
            {
                await DisplayAlert("提示", "功能完善中", "确定");
            }
            


            //(sender as Button).
     
        }

        private async void ImageButton_Clicked_2(object sender, EventArgs e)
        {
            await GoToAsync("//fenqu");
        }
    }
}