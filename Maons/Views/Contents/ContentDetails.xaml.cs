using ASMB.ViewModels;
using CommunityToolkit.Maui.Views;


namespace ASMB;
[QueryProperty(nameof(Msg), "Msg")]
public partial class ContentDetails : ContentPage
{

    NASMB.TYPES.Messagebs msg;
    public NASMB.TYPES.Messagebs Msg
    {
        get => msg;
        set
        {
            msg = value;
            OnPropertyChanged();
        }
    }
    //byte addrstate;
    //public byte AddrState
    //{
    //    get { return addrstate; }
    //    set
    //    {
    //        addrstate = value;
    //        OnPropertyChanged();
    //    }
    //}
    //DateTime laststatetime;

    //public DateTime Laststatetime
    //{
    //    get { return laststatetime; }
    //    set
    //    {
    //        laststatetime = value;
    //        OnPropertyChanged();
    //    }
    //}
    public ContentDetails(NASMB.TYPES.Messagebs _Msg)
	{
		InitializeComponent();
		BindingContext = this;
    
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
         if (((NASMB.TYPES.SignWorksmsgEx)_Msg.Body).WorksmsgEx.AddrState == 0)
        {
            this.Dispatcher.Dispatch(async () =>
            {

                var t = await avm.GetaddrState(_Msg);

                ((NASMB.TYPES.SignWorksmsgEx)_Msg.Body).WorksmsgEx.AddrState = t;

                Msg = _Msg;
            });
        }
        else
        {
            Msg = _Msg;
        }
       
        
        // var t=   
        // t.Wait();
        //t.Wait(1000);
        // = t.Result;
        // 
        //this.BindingContext = Shell.Current.pam
    }

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        var cv = new Pinglun(Msg);
        await Navigation.PushAsync(cv);
    }


    private async void lbtnzan_Clicked(object sender, EventArgs e)
    {
        if(MyWallet.GetWallet() == null)
        {
            await App.Current.MainPage.DisplayAlert("错误", "请先登录", "关闭"); return;
        }
        var body = ((NASMB.TYPES.SignWorksmsgEx)Msg.Body);
        if (DateTime.Now.AddSeconds(-30) < body.WorksmsgEx.Laststatetime)
        {
            await App.Current.MainPage.DisplayAlert("警告", $"操作过于频繁，等待{30 - (DateTime.Now - body.WorksmsgEx.Laststatetime).Seconds} s再试", "关闭");
            return;
        }
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        //if (string.IsNullOrEmpty(txtcontent.Text))
        //{
        //    //  await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
        //    return;
        //}
    
        var tag = body.WorksmsgEx.AddrState;
        if (tag == 1)
        {
            tag = 5;
        }
        else
        {
            tag = 1;
        }


        if (await avm.FasongcontentComment(body.SignWorksmsg.Worksmsg.From.Address, Msg._Shakey, tag, "") !=null) 
        {
            //await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
            //await App.Current.MainPage.Navigation.PopAsync();
           
            switch (body.WorksmsgEx.AddrState)
            {
                case 1:
                    body.WorksmsgEx.Up = body.WorksmsgEx.Up -1;
                    break;
                case 2:
                    body.WorksmsgEx.Down = body.WorksmsgEx.Down-1;
                    break;
                case 5:
                default:
                    break;
            }
            body.WorksmsgEx.AddrState = tag;
            if (body.WorksmsgEx.AddrState == 1)
            {
                body.WorksmsgEx.Up = body.WorksmsgEx.Up + 1;
                //body.WorksmsgEx.Up--;
            }

        }
        else
        {
            return;
        }
     
        body.WorksmsgEx.Laststatetime = DateTime.Now;
        Msg = msg;
    }

    private async void lbtncai_Clicked(object sender, EventArgs e)
    {
        if (MyWallet.GetWallet() == null)
        {
            await App.Current.MainPage.DisplayAlert("错误", "请先登录", "关闭"); return;
        }
        var body = ((NASMB.TYPES.SignWorksmsgEx)Msg.Body);
        if (DateTime.Now.AddSeconds(-30) < body.WorksmsgEx.Laststatetime)
        {
            await App.Current.MainPage.DisplayAlert("警告", $"操作过于频繁，等待{30- (DateTime.Now - body.WorksmsgEx.Laststatetime).Seconds} s再试", "关闭");
            return;
        }
        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
        //if (string.IsNullOrEmpty(txtcontent.Text))
        //{
        //    //  await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
        //    return;
        //}
      
        var tag = body.WorksmsgEx.AddrState;
        if (tag == 2)
        {
            tag = 5;
        }
        else
        {
            tag = 2;
        }


        if (await avm.FasongcontentComment(body.SignWorksmsg.Worksmsg.From.Address, Msg._Shakey, tag, "") != null)
        {
            switch (body.WorksmsgEx.AddrState)
            {
                case 1:
                    body.WorksmsgEx.Up = body.WorksmsgEx.Up - 1;
                    break;
                case 2:
                    body.WorksmsgEx.Down = body.WorksmsgEx.Down - 1;
                    break;
                case 5:
                default:
                    break;
            }
            body.WorksmsgEx.AddrState = tag;
            if (body.WorksmsgEx.AddrState == 2)
            {
                body.WorksmsgEx.Down = body.WorksmsgEx.Down + 1;
            }

            // await App.Current.MainPage.DisplayAlert("内容", "区块确认中，请等待30s左右刷新查看", "关闭");
            //await App.Current.MainPage.Navigation.PopAsync();
        }
        else { return; }
    
        body.WorksmsgEx.Laststatetime = DateTime.Now;
        Msg = msg;
    }
}