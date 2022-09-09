using ASMB.ViewModels;
using NASMB;
using NASMB.TYPES;
using Newtonsoft.Json;
using System.Timers;

namespace ASMB.Views.egg1;

public partial class egg1 : ContentPage
{
	public egg1()
	{
		InitializeComponent();
        //collectionView2.BindingContext = Account;
        //collectionView2.SetBinding(CollectionView.ItemsSourceProperty, "Messagebs" ,mode:BindingMode.OneWay);
        //isfresh.SetBinding(RefreshView.CommandProperty, "GetReciptsCmd");
        //isfresh.CommandParameter = Account;
        VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>().SetTimer();
    }





    //private  void SetTimer()
    //{
    //    if (aTimer==null)
    //    {
    //        // Create a timer with a two second interval.
    //        aTimer = new System.Timers.Timer(16000);
    //        // Hook up the Elapsed event for the timer. 
    //        aTimer.Elapsed += OnTimedEvent;
    //        aTimer.AutoReset = true;
    //        aTimer.Enabled = true;
    //        code2 = new byte[32];
    //        var t = NASMB.GO.Egg1.EnEgg1Code(code2, 32);
    //        var code22 = new byte[20];
    //        NASMB.GO.Egg1.DeEgg1Code(code2, 32, t, code22, 20);

    //        Account.Address = SimpleBase.Base58.Bitcoin.Encode(code22);
    //    }
    //}
    //private byte[] code2 { get; set; }

    //public Models.Account Account = new Models.Account() { Messagebs = new Messagebs[] { } };

    //ViewModels.AccountViewModels avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
    //private async void OnTimedEvent(Object source, ElapsedEventArgs e)
    //{
    //    if (isauto.IsChecked == false)
    //    {
    //        return;
    //    }
    //    try
    //    {
    //        choujiang.Dispatcher.Dispatch(() => {
    //            choujiang.Text = "挖矿中......";
    //        });

    //        var w = ViewModels.MyWallet.GetWallet();
    //        if (w == null|| string.IsNullOrEmpty( rcvaddr.Text))
    //        {
    //            choujiang.Dispatcher.Dispatch(() => {
    //                choujiang.Text = "清先登录选择默认地址";
    //            });
          
    //        }
            
    //        SignEgg1msg signEgg1Msg = new SignEgg1msg() { Egg1msg = new Egg1msg() };

    //        signEgg1Msg.Egg1msg.From.Address = rcvaddr.Text;

    //        signEgg1Msg.Egg1msg.Randomcode = new byte[32];
    //        signEgg1Msg.Egg1msg.Time = NASMB.GO.Egg1.EnEgg1Code(signEgg1Msg.Egg1msg.Randomcode, 32);
            

    //        var rlpb = signEgg1Msg.Egg1msg.RlpEncode();
    //        //var rlphex = Convert.ToHexString(rlpb);
    //        signEgg1Msg.Sign = w.Sign(signEgg1Msg.Egg1msg.From.GetAddressbyte(), rlpb);

    //        Messagebs messagebs = new Messagebs();
    //        messagebs.Body = signEgg1Msg;
    //        messagebs.Msgtype = signEgg1Msg.Egg1msg.Msgtype;

    //        var msg = Newtonsoft.Json.JsonConvert.SerializeObject(messagebs);
    //        var aRpcClient = Fullapi.FindSliceApiService(signEgg1Msg.Egg1msg.From.GetAddressbyte());
    //        var ret = await aRpcClient.SendRequestAsync<object>("Pubmsg", null, messagebs);
    //        Thread.Sleep(3000);
        
          
    //        choujiang.Dispatcher.Dispatch(() => {          
    //            choujiang.Text = "";
    //        });
         

    //    }
    //    catch (Exception ex)
    //    {
    //        choujiang.Text = $"网络错误：{ex.Message}";
    //    }
    //}
    private void collectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection[0] as NASMB.TYPES.Messagebs;
        //StringWriter textWriter = new StringWriter();
        //JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
        //{
        //    Formatting = Formatting.Indented,
        //    Indentation = 4,//缩进字符数
        //    IndentChar = ' '//缩进字符
        //};
        this.DisplayAlert("原始数据", Newtonsoft.Json.JsonConvert.SerializeObject(item.Body, Formatting.Indented), "关闭");
    }
}