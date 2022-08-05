

namespace ASMB.Views;

public partial class shoukuan : ContentPage
{
	public shoukuan()
	{
		InitializeComponent();
	}

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        await Clipboard.Default.SetTextAsync(shoukuandiz.Text);

        //      await Clipboard.SetTextAsync("asmb test");
        //if (!Clipboard.Default.HasText)
        //{
        //	//await Clipboard.Default.SetTextAsync("ssss"); 
        //	//if (!Clipboard.HasText)
        //	//{

        //	//}

        //}
        //var txt = await Clipboard.GetTextAsync();
    //    BarcodeGeneratorView

    }
}