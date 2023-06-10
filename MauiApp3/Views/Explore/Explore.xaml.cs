using Maons.Controls;
using System.Collections.ObjectModel;

namespace Maons.Explore;

public partial class Explore : ContentView
{
	public Explore()
	{
		InitializeComponent();

        var Items2= new ObservableCollection<MaonsViewItem>();


        //var exploer_item2 = new MaonsViewItem()
        //{
        //    Content = GlobalView.LemonView,
        //    IconSource = "weibiaoti.png",
        //    MaximumWidthRequest = 620,
        //    TitleDetails = "",
        //};
        //exploer_item2.SetDynamicResource(MaonsViewItem.TitleProperty, "friends");
        //Items2.Add(exploer_item2);

        //var exploer_item3 = new MaonsViewItem()
        //{
        //    Content = GlobalView.LemonView,
        //    IconSource = "a_tuanduizuzhijiagoushequn_04.png",
        //    MaximumWidthRequest = 620,
        //};
        //exploer_item3.SetDynamicResource(MaonsViewItem.TitleProperty, "community");
        //Items2.Add(exploer_item3);

        var exploer_item1 = new MaonsViewItem()
        {
            Content = new peers(),
            IconSource = "jiedian.png",
            MaximumWidthRequest = 620,
            TitleDetails = "看看谁和我这么有缘和他们打个招呼吧",
        };
        exploer_item1.SetDynamicResource(MaonsViewItem.TitleProperty, "connectingusernode");
        Items2.Add(exploer_item1);


        var exploer_item4 = new MaonsViewItem()
        {
            Content = new Explorercommunity1(),
            IconSource = "shequ.png",
            MaximumWidthRequest = 620,
            TitleDetails = "找到属于自己的社区畅所欲言吧",
        };
        exploer_item4.SetDynamicResource(MaonsViewItem.TitleProperty, "explorercommunity1");
        Items2.Add(exploer_item4);

        var exploer_item5 = new MaonsViewItem()
        {
            Content = new ExploreContent(),
            IconSource = "youqu.png",
            MaximumWidthRequest = 620,
            TitleDetails = "看看别人都发了什么吧，内容，图片，视频？",
        };
        exploer_item5.SetDynamicResource(MaonsViewItem.TitleProperty, "explorecontent");
       Items2.Add(exploer_item5);

        var exploer_item6 = new MaonsViewItem()
        {
            Content = new NewCommunity(),
            IconSource = "chuangjianqunliao.png",
            MaximumWidthRequest = 620,
            TitleDetails = "邀请好友一起来嗨吧",
            Title = "创建社区",
        };
        //   exploer_item6.SetDynamicResource(MaonsViewItem.TitleProperty, "explorecontent");
        Items2.Add(exploer_item6);
        this.clview.ItemsSource = Items2;
        cview.Content    = Items2[0];

    }
    private void v1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //  var clview = new CollectionView();

        // 

        if (clview.SelectedItem != null)
        {
            // this.Content = clview.SelectedItem as ContentView;

            var view = clview.SelectedItem as MaonsViewItem;
            cview.Content = view;
            //if (view.IconSource== "weibiaoti.png")
            //{
            //    //  (GlobalView.MaonsPage.Content as ContentView).Push(view);
            //  //  view.MaximumWidthRequest = 1020;
            //  //  (view.Content  as Messages.Messages). Changemenu("contacts");

            //    //GlobalView.MaonsPage.Content  = view.Content;

            //}
            //else
            //{
            // //   GlobalView.MaonsPage.Content = this.Parent as MaonsViewItem;
               
            //}
            //this.Push(clview.SelectedItem as ContentView);

        }
        
    }
}