using ASMB.ViewModels;
using NASMB.TYPES;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;

namespace ASMB;

public partial class Pinglun : ContentPage
{


    //public BindableProperty Heightp = new BindableProperty();
    public Pinglun(NASMB.TYPES.Messagebs _msg)
	{
		InitializeComponent();

        //if (DeviceDisplay.Current.MainDisplayInfo.Width/ DeviceDisplay.Current.MainDisplayInfo.Density > txtcontent.MaximumWidthRequest)
        //{
        //    txtcontent.WidthRequest = txtcontent.MaximumWidthRequest - 50;
        //}
        //else
        //{
        //    txtcontent.WidthRequest = DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density - 50;
        //}
        //var cp = App.Current.MainPage as AppShell;
     //   view2.HeightRequest = cp.CurrentPage.Height-100;

        var vm = new PinlunVm(_msg);
        
        //vm.GetWorksReceipts();
        BindingContext = vm;
        ///    var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        //this.Dispatcher.Dispatch(async () =>
        //{
          
        //    //  ((NASMB.TYPES.SignWorksmsgEx)_msg.Body).WorksmsgEx.AddrState = t;

        //});


    }


    private void txtcontent_SizeChanged(object sender, EventArgs e)
    {
       // grow2.Height = ((Editor)sender).Height;
     ////   grid1.Height = grid0.Height- 50- grow2.Height.Value;
     //   grid1.Height = GridLength.Auto;
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtcontent.Text))
        {
            //  await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
            return;
        }
        if (MyWallet.GetWallet() == null)
        {
            await App.Current.MainPage.DisplayAlert("错误", "请先登录", "关闭"); return;
        }
        var Msg = (this.BindingContext as PinlunVm).Msg;
        var body = Msg.Body as IWorksEx;
        //if (DateTime.Now.AddSeconds(-30) < body.GetWorksmsgEx().Laststatetime)
        //{
        //    await App.Current.MainPage.DisplayAlert("警告", $"操作过于频繁，等待{30 - (DateTime.Now - body.WorksmsgEx.Laststatetime).Seconds} s再试", "关闭");
        //    return;
        //}
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        //if (string.IsNullOrEmpty(txtcontent.Text))
        //{
        //    //  await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
        //    return;
        //}
        var nmsgbs = await avm.FasongcontentComment(body.WAddr().Address, Msg._Shakey, 4, txtcontent.Text);

        if (nmsgbs  != null)
        {
            body.GetWorksmsgEx().PinglunTimes++;
            txtcontent.Text = "";
            body.GetWorksmsgEx().Receipts.Insert(0,new Messagebs()
            {
                Msgtype = NASMB.TYPES.Msgtype.SWorkscomment,
                Body = new SignWorkscommentmsgEx()
                {
                    SignWorkscommentmsg = nmsgbs.Body as SignWorkscommentmsg,
                    WorksmsgEx = new WorksmsgEx()

                }
            });
            // await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
            //await App.Current.MainPage.Navigation.PopAsync();
        }

        // body.WorksmsgEx.Laststatetime = DateTime.Now;
        //  Msg = msg;
     //   BindingContext = this.BindingContext;
    }

    private void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        var vm = (this.BindingContext as PinlunVm);
        if (e.LastVisibleItemIndex >= (vm.Msg.Body as IWorksEx).GetWorksmsgEx().Receipts.Count - 1)
        {
            vm.ApendWorksReceipts();            
        }
    }

    private void CollectionView_SizeChanged(object sender, EventArgs e)
    {
        //var cp = App.Current.MainPage as AppShell;
        
        //view2.HeightRequest = cp.CurrentPage.Height -view1.Height - 80;
        
    }
}