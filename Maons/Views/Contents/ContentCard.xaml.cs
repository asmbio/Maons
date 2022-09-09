namespace ASMB;

public partial class ContentCard : ContentView
{
	public ContentCard()
	{
		InitializeComponent();
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//contentdetails");
       // await Navigation.PushAsync(new ContentDetails());
    }
}