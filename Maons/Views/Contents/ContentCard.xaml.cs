
namespace ASMB;

public partial class ContentCard : ContentView
{
	public ContentCard()
	{
		InitializeComponent();
	}

	private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        var cv = new ContentDetails(this.BindingContext as NASMB.TYPES.Messagebs);
        // 设置 本账户是否点赞



        //cv.Msg = ;

        await Navigation.PushAsync(cv);
        //await Shell.Current.GoToAsync("//contentdetails");
        // await Navigation.PushAsync(new ContentDetails());
    }
}