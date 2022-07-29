using Newtonsoft.Json;

namespace ASMBApp.Views.Blocks;

public partial class BlockDetils : ContentPage
{
	public BlockDetils()
	{
		InitializeComponent();
	}

	private void collectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        var item = e.CurrentSelection[0] as NASMB.TYPES.Messagebs;
        this.DisplayAlert("原始数据", Newtonsoft.Json.JsonConvert.SerializeObject(item.Body, Formatting.Indented), "关闭");
    }

	private void ImageButton_Clicked(object sender, EventArgs e)
	{
        this.DisplayAlert("原始数据", Newtonsoft.Json.JsonConvert.SerializeObject((this.BindingContext as NASMB.TYPES.SignBlockHeader).Bh, Formatting.Indented), "关闭");
    }
}