using Maons.Controls;
using Maons.my;
using Maons.Messages;
using Maons;
using System.Collections.ObjectModel;

using Maons.Explore;

namespace Maons;

public class Maons : global::Maons.Controls.MaonsPage
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
        Items1.Add(new Messages.Messages() { IconSource = "xiaoxi.png",RightView=new NewContent2() });
        Items1.Add(new Explore.Explore() { IconSource = "faxian.png", RightView = new NewContent2() });
        Items1.Add(new Share.Share() { IconSource = "tianjia.png", RightView = new NewContent2() });
        Items1.Add(new Tool.useful() { IconSource = "gongneng.png", RightView = new NewContent2() });
        Items1.Add(new My() {  IconSource = "qianbao.png" , RightView = new NewContent2() });


        Items = Items1;

       // CurrentView = Items[0];
        Content = Items[0];

    }
}
