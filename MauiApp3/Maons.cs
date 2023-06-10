using Maons.Controls;
using Maons.my;
using Maons.Messages;
using Maons;
using System.Collections.ObjectModel;

using Maons.Explore;
using ASMB.ViewModels;
using CommunityToolkit.Maui.Views;

namespace Maons;

public class Maons : MaonsPage
{
    public Maons()
	{
        //    this.back
        //ResourceDictionary dict = new ResourceDictionary();

        //if (_currentLan == "ZH")
        //{
        //    dict.Source = new Uri(@"Resources\Language\EN.xaml", UriKind.Relative);

        //    _currentLan = "EN";
        //}
        //else
        //{
        //    dict.Source = new Uri(@"Resources\Language\ZH.xaml", UriKind.Relative);

        //    _currentLan = "ZH";
        //}
        //dict[]
        //Content = new NewContent1();
        var  Items1 = new ObservableCollection<MaonsViewItem>();

        var msgs = new Messages.Messages();
        
        Items1.Add(msgs);

        var maonsng =new MaonsNavigation() { MaximumWidthRequest = 620, MinimumWidthRequest=400};       
        var elitems = new Explore.Explore();
        maonsng.Content = elitems;
       var exploer = new MaonsViewItemLeftRight(maonsng, new NewContent2()) { IconSource = "faxian.png" };
        exploer.SetDynamicResource(MaonsViewItemLeftRight.TitleProperty, "explorer");
        Items1.Add(exploer );



        //Items1.Add(new Explore.Explore() { IconSource = "faxian.png", RightView = new NewContent2() });
        //Items1.Add(new Share.Share() { IconSource = "tianjia.png", RightView = new NewContent2() });
        //Items1.Add(new Tool.useful() { IconSource = "gongneng.png", RightView = new NewContent2() });
        //Items1.Add(new My() {  IconSource = "qianbao.png" , RightView = new NewContent2() });

        var share = new MaonsViewItemLeftRight(new Share.Share(), new NewContent2()) { IconSource = "tianjia.png" };
        share.SetDynamicResource(MaonsViewItemLeftRight.TitleProperty, "share");
        Items1.Add(share);

        var useful = new MaonsViewItemLeftRight(new Tool.useful(), new NewContent2()) { IconSource = "gongneng.png" };
        useful.SetDynamicResource(MaonsViewItemLeftRight.TitleProperty, "function");
        Items1.Add(useful);


        var mynavig = new MyMaonsNavigation();
        var My = new MaonsViewItemLeftRight(mynavig, new NewContent2());
        My.IconSource = mynavig.CurContent.IconSource;
        My.SetDynamicResource(MaonsViewItemLeftRight.TitleProperty, "my");
        Items1.Add(My);

        Items = Items1;

       // CurrentView = Items[0];
        Content = Items[0];
      //  Items[0].Selected= true;

    }


}
