namespace ASMBApp;

public partial class Discovery : ContentPage
{
	public Discovery()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.AskNill.AskNil());
    }

	private async void ImageButton_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.Blocks.Blocks());
    }

	private async void ImageButton_Clicked_1(object sender, EventArgs e)
	{
		await this.DisplayAlert("彩蛋","开发中，敬请期待！！！","关闭");	
	}
}