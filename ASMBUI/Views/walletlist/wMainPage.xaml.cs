namespace ASMBUI.Views.walletlist;

public partial class wMainPage : ContentPage
{
	public wMainPage()
	{
		InitializeComponent();

       // flyoutPage.collectionView.SelectionChanged += OnSelectionChanged;
    }

    //void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    //{
    //    var item = e.CurrentSelection.FirstOrDefault() as FlyoutPageItem;
    //    if (item != null)
    //    {
    //        //Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
    //        //IsPresented = false;

    //        //Detail =(Page)Activator.CreateInstance(item.TargetType);
    //        //IsPresented = false;
    //    }
    //}

    //private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{

    //}

    //private void collectionView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
    //{

    //}

    private void collectionView2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
    {

    }
}
