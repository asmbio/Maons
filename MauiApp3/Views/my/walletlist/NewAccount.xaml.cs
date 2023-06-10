using Maons.Controls;

namespace ASMB.Views.walletlist;

public partial class NewAccount : ContentView
{
	public NewAccount()
	{
		InitializeComponent();
	}

	private  void Button_Clicked(object sender, EventArgs e)
	{
		this.Pop();
    }
}