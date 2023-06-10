
using System.Text;

namespace ASMB;

using ASMB.ViewModels;
using CommunityToolkit.Maui.Views;
using Maons.Controls;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

public partial class wallet : ContentView
{
    public async void init()
    {
        try
        {
            var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();

            //if (avm.list.Count == 0)
            //{
            //  avm.GetList();
            //}
         
            //avm.GetAccount(avm.Model);

        }
        catch (Exception e)
        {
            await Application.Current.MainPage.DisplayAlert("错误", e.Message,"关闭");
        }
    }
    
    public wallet()
    {
        InitializeComponent();
        init();
        
        //if (MyWallet.GetWallet() == null)
        //{
        //    Task.Run(() =>
        //    {
        //        Thread.Sleep(2000);

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
        // var result =  DisplayPromptAsync("钱包密码", "输入钱包密码",  in keyboard: Keyboard.Numeric);

        // login();


        //result.Wait();
        // var pwd = result.Result;

        // ASMB.ViewModels.MyWallet.GetWallet(pwd);

        //OnChildRemoved

        // Create a secp256k1 context (ensure disposal to prevent unmanaged memory leaks).
        //using (var secp256k1 = new Secp256k1())
        //{

        //    // Generate a private key.
        //    var privateKey = new byte[32];
        //    var rnd = System.Security.Cryptography.RandomNumberGenerator.Create();
        //    do { rnd.GetBytes(privateKey); }
        //    while (!secp256k1.SecretKeyVerify(privateKey));


        //    // Create public key from private key.
        //    var publicKey = new byte[64];
        //    var ret = secp256k1.PublicKeyCreate(publicKey, privateKey);
        //    //

        //    // Sign a message hash.
        //    var messageBytes = Encoding.UTF8.GetBytes("Hello world.");
        //    var messageHash = System.Security.Cryptography.SHA256.Create().ComputeHash(messageBytes);
        //    var signature = new byte[64];
        //     ret = (secp256k1.Sign(signature, messageHash, privateKey));


        //    // Verify message hash.
        //    ret = (secp256k1.Verify(signature, messageHash, publicKey));

        //}
    }
    
    //override 
    //protected override void OnAppearing()
    //{
    //    base.OnAppearing();
    //  //  login();
    //}
    //internal async  Task<bool> login()
    //{
    //    ASMB.Views.Pwd pwd = new ASMB.Views.Pwd();
    //    //pwd.ac
    //    string paswd=  ( string)( await this.ShowPopupAsync(pwd));
        

    //    if (ASMB.ViewModels.MyWallet.GetWallet(paswd) == null)
    //    {
    //        await DisplayAlert("", "钱包密码错误", "确定");
    //        return false;
    //    }
    //    var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
    //    avm.GetList();
    //    return true;

    //}
    private void Button_Clicked(object sender, EventArgs e)
    {
        //var page = new Views.walletlist.MainPage();

        //if (MyWallet.GetWallet() == null)
        //{
        //    var ret = await login();
        //    if (!ret)
        //    {
        //        return;
        //    }
        //}
        // var service = VMlc.Services.BuildServiceProvider();


        //ASMB. MauiProgram.Services
        //ASMB.MauiProgram.Services.ge
       //  this.Push(new Views.walletlist.WalletlistPage());
    }

	private  void Button_Clicked_1(object sender, EventArgs e)
	{
         this.Push(new Views.shoukuan());
    }

	private  void Button_Clicked_2(object sender, EventArgs e)
	{
        this.Push(new Views.zhuanzhang());
    }

	private  void shoukuan_Clicked(object sender, EventArgs e)
	{
        this.Push(new Views.shoukuan());
    }

	private  void zhuanzhang_Clicked(object sender, EventArgs e)
	{
        this.Push(new Views.zhuanzhang());
    }

    private  void collectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var item = e.CurrentSelection[0] as NASMB.TYPES.Messagebs;

        //this.DisplayAlert("原始数据", Newtonsoft.Json.JsonConvert.SerializeObject(item.Body,Formatting.Indented), "关闭");


        //  dt.BindingContext = 
        switch (item.Msgtype)
        {
            case NASMB.TYPES.Msgtype.Unknown:
                break;
            case NASMB.TYPES.Msgtype.PubBlock:
                break;
            case NASMB.TYPES.Msgtype.JionPD:
                break;
            case NASMB.TYPES.Msgtype.SysCoinbase:
                break;
            case NASMB.TYPES.Msgtype.SignTrans:
                
            case NASMB.TYPES.Msgtype.CfmTrans:
                var dt = new Views.zzDetils(item);
                this.Push(dt);
                return;
            case NASMB.TYPES.Msgtype.SignVote:
                break;
            case NASMB.TYPES.Msgtype.CfmVote:
                break;

            case NASMB.TYPES.Msgtype.SignCancelvote:
                break;
            case NASMB.TYPES.Msgtype.CfmCancelvote:
                break;

            case NASMB.TYPES.Msgtype.Addcharges:
                break;
            case NASMB.TYPES.Msgtype.SignEgg1:
                break;
            case NASMB.TYPES.Msgtype.CfmEgg1:
                break;
            default:
                break;
        }
   

    }
}