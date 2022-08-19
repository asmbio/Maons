namespace MauiApp1;

public partial class producer : ContentPage
{
	public producer()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
        await this.DisplayAlert("投票", "暂时未开放节点投票，请耐心等待", "关闭");
    }
}