using Maons.Controls;

namespace Maons.Explore;

public partial class Friends : MaonsViewItem
{
	public Friends()
	{
		InitializeComponent();
       // Content = GlobalView.LemonView;
    }

    public async override void Changemenu(string menu)
    {
        //messages

        //contacts
        //if(GlobalView.LemonView.Parent as ContentView != null){
        //    (GlobalView.LemonView.Parent as ContentView).Content = null;
        //}
        //Content = GlobalView.LemonView;

       // string result = await lemonui.EvaluateJavaScriptAsync($"App.changeMenu({"contacts"})");
        this.Selected = true;
        //resultLabel.Text = $"Factorial of {number} is {result}.";
    }
}