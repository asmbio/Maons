
using System.Text;

namespace ASMBApp;

using ASMBApp.ViewModels;
using CommunityToolkit.Maui.Views;
using Microsoft.Extensions.DependencyInjection;

public partial class wallet : ContentPage
{

	public   wallet()
	{
		InitializeComponent();
        
        // var result =  DisplayPromptAsync("«Æ∞¸√‹¬Î", " ‰»Î«Æ∞¸√‹¬Î",  in keyboard: Keyboard.Numeric);

       // login();


        //result.Wait();
        // var pwd = result.Result;

        // ASMBApp.ViewModels.MyWallet.GetWallet(pwd);

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
    internal async  Task login()
    {
        ASMBApp.Views.Pwd pwd = new ASMBApp.Views.Pwd(true);
        //pwd.ac
        string paswd=  ( string)( await this.ShowPopupAsync(pwd));


        if (ASMBApp.ViewModels.MyWallet.GetWallet(paswd) == null)
        {
            await DisplayAlert("", "«Æ∞¸√‹¬Î¥ÌŒÛ", "»∑∂®");
        }


    }
	private async void Button_Clicked(object sender, EventArgs e)
	{
		//var page = new Views.walletlist.MainPage();
		
        if (MyWallet.GetWallet() == null)
        {
           await login();
        }
       // var service = VMlc.Services.BuildServiceProvider();

        var avm = VMlc.ServiceProvider.GetService<ASMBApp.ViewModels.AccountViewModels>();
        avm.GetList();
        //ASMBApp. MauiProgram.Services
        //ASMBApp.MauiProgram.Services.ge
        await Navigation.PushAsync(new  Views.walletlist.WalletlistPage());
    }

	private async void Button_Clicked_1(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.shoukuan());
    }

	private async void Button_Clicked_2(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.zhuanzhang());
    }

	private async void shoukuan_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.shoukuan());
    }

	private async void zhuanzhang_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.zhuanzhang());
    }

    private void Button_Clicked_3(object sender, EventArgs e)
    {
        login();
    }
}