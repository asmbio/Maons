namespace ASMBApp.Views;

public partial class Pwd:CommunityToolkit.Maui.Views.Popup
{
	private bool isfirst = false;
	public Pwd(bool fist = false)
	{
		isfirst = fist;
		InitializeComponent();
        epwd.Text = "";
        CanBeDismissedByTappingOutsideOfPopup = false;



    }

    void OnOKButtonClicked(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(epwd.Text))
        {
            return;
        }
        Close(epwd.Text);
    }
}