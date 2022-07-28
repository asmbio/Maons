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
 
        //this.DisplayAlert("ԭʼ����", Newtonsoft.Json.JsonConvert.SerializeObject(item.Bh), "�ر�");
    }
}