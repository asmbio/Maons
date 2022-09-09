using ASMB.ViewModels;

namespace ASMB;

public partial class Zuixin : ContentPage
{
    AccountViewModels avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
    public Zuixin()
	{
		InitializeComponent();
		try
		{
          
            avm.GetWorkss(avm.ZhuyeAccount);
        }
		catch (Exception)
		{

		//	throw;
		}

    }



	private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
	{
        var item = e.CurrentSelection[0] as NASMB.TYPES.Messagebs;
		//Navigation.PushModalAsync

		var cv =new ContentDetails(item);
		// 设置 本账户是否点赞



		//cv.Msg = ;

		await Navigation.PushAsync(cv);
        //await Shell.Current.GoToAsync("//contentdetails",new Dictionary<string, object>() { {"Msg",item }});
        //   await Navigation.PushAsync(dt);
    }

	private void CollectionView_ScrollToRequested(object sender, ScrollToRequestEventArgs e)
	{
		Console.Write("");
    }
    private object syncobj = new object();
    private async void CollectionView_Scrolled(object sender, ItemsViewScrolledEventArgs e)
	{
		if(e.LastVisibleItemIndex >= avm.ZhuyeAccount.Messagebs.Count-1)
		{          
			lock (syncobj)
			{
                avm.ApendWorkss(avm.ZhuyeAccount);
            }
        }
     
    }

	private void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
	{

    }
}