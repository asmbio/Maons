using Microsoft.Maui.Devices;

namespace ASMB.Views;

public partial class Pwd:CommunityToolkit.Maui.Views.Popup
{
	private bool isfirst = false;
	public Pwd()
	{
	//	isfirst = fist;
		InitializeComponent();
        epwd.Text = "";
        CanBeDismissedByTappingOutsideOfPopup = false;
        var cp = App.Current.MainPage as AppShell;
       //  Size =new Size(DeviceDisplay.Current.MainDisplayInfo.Width / DeviceDisplay.Current.MainDisplayInfo.Density-10, DeviceDisplay.Current.MainDisplayInfo.Height/ (DeviceDisplay.Current.MainDisplayInfo.Density*2));
       Size = new Size(cp.CurrentPage.Width, cp.CurrentPage.Height / 2);
        //Size.Width= 1080;
        //  this.Size =new Size(1080, 400);



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