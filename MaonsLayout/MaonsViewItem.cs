namespace Maons.Controls;

public class MaonsViewItem : ContentView
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(MaonsViewItem), null);

    public static readonly BindableProperty IconSourceProperty = BindableProperty.Create("IconSource", typeof(string), typeof(MaonsViewItem), null);

  //  public static readonly BindableProperty FontAttributesProperty = BindableProperty.Create("FontAttributes", typeof(FontAttributes), typeof(MaonsViewItem), FontAttributes.None);

    public static readonly BindableProperty SelectedProperty = BindableProperty.Create("Selected", typeof(bool), typeof(MaonsViewItem), false);


    public static readonly BindableProperty LogViewProperty = BindableProperty.Create("LogView", typeof(ContentView), typeof(MaonsViewItemLeftRight), new ContentView() { MinimumWidthRequest = 400, MaximumWidthRequest = 600 });

    public static readonly BindableProperty RightViewProperty = BindableProperty.Create("RightView", typeof(ContentView), typeof(MaonsViewItemLeftRight), new ContentView() { MinimumWidthRequest = 0, MaximumWidthRequest = 0 });

    // 忘记干啥用的了
    public ContentView LogView
    {
        get => (ContentView)GetValue(LogViewProperty);
        set => SetValue(LogViewProperty, value);
    }
    public ContentView RightView
    {
        get => (ContentView)GetValue(RightViewProperty);
        set => SetValue(RightViewProperty, value);
    }
    public static readonly BindableProperty TopViewProperty = BindableProperty.Create("TopView", typeof(ContentView), typeof(MaonsViewItemLeftRight), new ContentView() { MinimumWidthRequest = 400, MaximumWidthRequest = 600 });


    public ContentView TopView
    {
        get => (ContentView)GetValue(TopViewProperty);
        set => SetValue(TopViewProperty, value);
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

}
