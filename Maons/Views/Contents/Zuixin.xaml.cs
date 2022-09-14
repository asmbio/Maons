using ASMB.ViewModels;

namespace ASMB;

[QueryProperty(nameof(Vm), "Vm")]
public partial class Zuixin : ContentPage
{
    WorksVm vm = new WorksVm("htaM6rQvi4ci3bQ5uReAm5XXytv");
    public WorksVm Vm
    {
        get => vm;
        set
        {
            if (value !=null)
            {
                vm = value;
                vm.GetWorkss();
                OnPropertyChanged();
            }
           
        }
    }
   // AccountViewModels avm = VMlc.ServiceProvider.GetService<ASMB.ViewModels.AccountViewModels>();
    public Zuixin()
	{
		InitializeComponent();
        BindingContext = this;
		try
		{          
            vm.GetWorkss();
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
		if(e.LastVisibleItemIndex >= vm.Account.Messagebs.Count-2)
		{          
			lock (syncobj)
			{
                vm.ApendWorkss();
            }
        }
     
    }

	private void CollectionView_RemainingItemsThresholdReached(object sender, EventArgs e)
	{

    }
}