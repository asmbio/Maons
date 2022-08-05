namespace ASMB.Views;

public partial class zzDetils : ContentPage
{
	public zzDetils(NASMB.TYPES.Messagebs messagebs)
	{
		InitializeComponent();
		this.BindingContext = messagebs;
	}
}