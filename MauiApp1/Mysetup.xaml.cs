

using Maons;
using MauiApp1;

namespace Maons.my;

public partial class Mysetup : Maons.Controls.MaonsViewItem
{
    public Languages Languages = new Languages();
	public Mysetup()
	{

        InitializeComponent();
        this.BindingContext = Languages;

        //var monkeyList = new List<string>();
        //monkeyList.Add("Baboon");
        //monkeyList.Add("Capuchin Monkey");
        //monkeyList.Add("Blue Monkey");
        //monkeyList.Add("Squirrel Monkey");
        //monkeyList.Add("Golden Lion Tamarin");
        //monkeyList.Add("Howler Monkey");
        //monkeyList.Add("Japanese Macaque");
        pcklan.ItemsSource =(System.Collections.IList) Languages.Lans.ToList();
        

    }

    private void Picker_SelectedIndexChanged(object sender, EventArgs e)
    {
        Languages.SwitchLan(((sender as Picker).SelectedItem as KeyValuePair<string, string>?).Value.Key);
    }
}