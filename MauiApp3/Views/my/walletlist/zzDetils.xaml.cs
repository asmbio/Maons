namespace ASMB.Views;

public partial class zzDetils : ContentView
{
	public zzDetils(NASMB.TYPES.Messagebs messagebs)
	{
		InitializeComponent();
		this.BindingContext = messagebs;
	}
}