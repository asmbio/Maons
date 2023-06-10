using Newtonsoft.Json.Linq;

namespace ASMB.Views.walletlist;

public partial class export : ContentView
{
	public export()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
        var hex     = await NASMB.GO.Localchainapi.Wallet.SendRequestAsync<JToken>("Export", "");
		

		exportedit.Text =(string) hex;

    }

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        await Clipboard.Default.SetTextAsync(exportedit.Text);
    }
}