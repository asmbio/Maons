namespace ASMBApp.Views.Blocks;

public partial class Blocks : ContentPage
{
	public Blocks()
	{
		InitializeComponent();
	}

	private async void collectionView23_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        var item = e.CurrentSelection[0] as NASMB.TYPES.SignBlockHeader;
		var bd = new Views.Blocks.BlockDetils();
		bd.BindingContext = item;
        await Navigation.PushAsync(bd);
 
        //this.DisplayAlert("原始数据", Newtonsoft.Json.JsonConvert.SerializeObject(item.Bh), "关闭");
    }
}