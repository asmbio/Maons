namespace ASMB.Views.walletlist;

public partial class export : ContentPage
{
	public export()
	{
		InitializeComponent();
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		var hex = ASMB.ViewModels.MyWallet.GetWallet().Export();

		exportedit.Text = hex;

    }

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        await Clipboard.Default.SetTextAsync(exportedit.Text);
    }
}