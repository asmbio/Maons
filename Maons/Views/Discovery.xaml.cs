namespace ASMB;

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
		await this.DisplayAlert("ͶƱ","�����У������ڴ�������","�ر�");	
	}

	private async void btnegg1_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new Views.egg1.egg1());
    }

	private async void producerbtn_Clicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new  MauiApp1.producer());
    }
}