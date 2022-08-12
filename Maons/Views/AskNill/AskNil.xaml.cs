using ASMB.ViewModels;

namespace ASMB.Views.AskNill;

public partial class AskNil : ContentPage
{
	public AskNil()
	{
		InitializeComponent();
	}

	private async void Button_Clicked(object sender, EventArgs e)
	{
		var avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
		if (await avm.asknil())
		{
			await this.DisplayAlert("�������", "����ȷ���У���ȴ�30s����ˢ�²鿴", "�ر�");
			await Navigation.PopAsync();
		}
	}
}