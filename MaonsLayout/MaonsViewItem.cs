

namespace Maons.Controls;

public class MaonsViewItem : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(MaonsViewItem), null);


    public static readonly BindableProperty TitleDetailsProperty = BindableProperty.Create("TitleDetails", typeof(string), typeof(MaonsViewItem), null);

    public static readonly BindableProperty IconSourceProperty = BindableProperty.Create("IconSource", typeof(string), typeof(MaonsViewItem), null);

  //  public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(MaonsViewItem), FontAttributes.None);

    public static readonly BindableProperty SelectedProperty = BindableProperty.Create("Selected", typeof(bool), typeof(MaonsViewItem), false);


    public string TitleDetails
    {
        get => (string)GetValue(TitleDetailsProperty);
        set => SetValue(TitleDetailsProperty, value);
    }


    public string Title
    {
        get => (string)GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
    public string IconSource
    {
        get => (string)GetValue(IconSourceProperty);
        set => SetValue(IconSourceProperty, value);
    }
    public bool Selected
    {
        get => (bool)GetValue(SelectedProperty);
        set => SetValue(SelectedProperty, value);
    }


    //public ContentView ContentView
    //{
    //    get => (ContentView)GetValue(ContentViewProperty);
    //    set => SetValue(ContentViewProperty, value);
    //}
    public MaonsViewItem()
    {
        MinimumWidthRequest = 400;
        MaximumWidthRequest = 600;
        
    }

    public virtual Size MyMeasure(double widthConstraint, double heightConstraint)
    {

        return new Size(widthConstraint, heightConstraint);
    }
    public virtual void Changemenu(string menu)
    {

        Selected= true;
    }



}
