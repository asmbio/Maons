using ASMB.ViewModels;
using Maons.Controls;
using MauiApp3;
using Newtonsoft.Json;

namespace Maons.Views.my;

public partial class Avatar : ContentView
{
    private ASMB.Models.Account account;
    public Avatar(ASMB.Models.Account _account)
	{
		InitializeComponent();
        avatar.Loaded += Avatar_Loaded;
        account = _account;
 //      changeimg(imgurl);

    }

    private void Avatar_Loaded(object sender, EventArgs e)
    {        
        //Thread.Sleep(1000);
        //changeimg(imgurl);
    }

    public async void changeimg(string img)
	{
        try
        {
          //  var ss = await avatar.EvaluateJavaScriptAsync($"window.avatar.changeImg(\"{img}\")");
        }
        catch (Exception)
        {

            //throw;
        }
      
        
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        try
        {
            var ss = await avatar.EvaluateJavaScriptAsync($"window.avatar.down(\"{"base64"}\")");
            var ss1 = await avatar.EvaluateJavaScriptAsync($"window.avatar.down(\"{"base64"}\")");

            //var ss2=JsonConvert.SerializeObject( ss1 );
            //  var ss2 = JsonConvert.DeserializeObject<string>( ss1 );
            var ss2 = ss1.Substring(2, ss1.Length - 3);
            var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
            account.MetaEx.Avatar = ss2;

            avm.SaveAvatar(account);
            this.Pop();
        }
        catch (Exception ex)
        {
            await App.Current.MainPage.DisplayAlert("正在连接主网", ex.Message, "关闭");
        }
 

    }
}