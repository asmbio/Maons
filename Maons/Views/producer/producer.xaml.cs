using ASMB.ViewModels;

namespace MauiApp1;

public partial class producer : ContentPage
{
	public producer()
	{
		InitializeComponent();

        var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();

		avm.getproducer();
    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
        await this.DisplayAlert("ͶƱ", "��ʱδ���Žڵ�ͶƱ�������ĵȴ�", "�ر�");
    }
}