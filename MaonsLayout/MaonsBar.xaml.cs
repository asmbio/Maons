namespace Maons.Controls;

public partial class MaonsBar : ContentView
{
   
    public MaonsBar()
	{
		InitializeComponent();
	}

   
    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        this.Pop();
    }

    private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
    {
        this.Pop();
    }
}