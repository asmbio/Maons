
using ASMB.ViewModels;
using Maons.Controls;

namespace Maons.Messages;

public partial class Messages : MaonsViewItem
{
	public Messages()
	{
		InitializeComponent();
        //    Content = GlobalView.LemonView;

       // var bview = new BlazorWebView();
        lemonui.Loaded += Lemonui_Loaded;

    }
    
    private void Lemonui_Loaded(object sender, EventArgs e)
    {


        Task.Run( async () =>
        {
            string pwd = MauiApp3.App.Pwd;
            //MauiApp3.App.Pwd = "";
            byte[] bufer = new byte[500];
            while (true)
            {
                Thread.Sleep(1000);
#if Local
                Buffer.BlockCopy(System.Text.Encoding.UTF8.GetBytes("run"), 0, bufer, 0, 3);
#else

                NASMB.GO.ASMB.GetlastErr(bufer, 500);

#endif
                if (System.Text.Encoding.UTF8.GetString(bufer).StartsWith("run"))
                {
                    await NASMB.GO.Localchainapi.Auth(pwd);
                    var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
                    avm.GetList();

                    Thread.Sleep(6000);
              
                    this.Dispatcher.Dispatch(async () =>
                    {
                   
                        var ss = await lemonui.EvaluateJavaScriptAsync($"window.IMUI.authnew(\"{pwd}\")");
                        Console.WriteLine(ss);
                    });
                
                   // lemonui.EvaluateJavaScriptAsync($"window.IMUI.Authnew(\"{pwd}\")");
                    break;
                }

            }
        });

    }

    //public async override void Changemenu(string menu)
    //{
    //    //if (GlobalView.LemonView.Parent as ContentView != null){
    //    //    (GlobalView.LemonView.Parent as ContentView).Content = null;
    //    //}
    //    //Content = GlobalView.LemonView;

    //    //messages
    //    //contacts
    //   // string result1 = await lemonui.EvaluateJavaScriptAsync($"window.factorial(5)"); 
    //  //  string result = await lemonui.EvaluateJavaScriptAsync($"window.IMUI.changeMenu(\"{menu}\")");
    ////    string result2 = await lemonui.EvaluateJavaScriptAsync($"window.changeMenu(\"{menu}\")");
    //  //  this.Selected = true;
    //    //resultLabel.Text = $"Factorial of {number} is {result}.";
    //}
}