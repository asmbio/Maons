using System.Runtime.Serialization.DataContracts;

namespace Maons.Controls;


public sealed partial  class MaonsViewItemLeftRight : MaonsViewItem
{
    public static readonly BindableProperty LogViewProperty = BindableProperty.Create("LogView", typeof(ContentView), typeof(MaonsViewItemLeftRight), new ContentView() { MinimumWidthRequest = 400, MaximumWidthRequest = 600 });

    public static readonly BindableProperty RightViewProperty = BindableProperty.Create("RightView", typeof(ContentView), typeof(MaonsViewItemLeftRight), new ContentView() { MinimumWidthRequest = 0, MaximumWidthRequest = 0 });

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

    public MaonsViewItemLeftRight(ContentView left ,ContentView right)
	{
     
		InitializeComponent();
        BindingContext = this;
        //LeftView = left;
        RightView = right;
        this.MinimumWidthRequest = left.MinimumWidthRequest;
        this.MaximumWidthRequest = right.MaximumWidthRequest+left.MaximumWidthRequest;
        SizeChanged += MaonsViewItemLeftRight_SizeChanged;
        
    }

    private void MaonsViewItemLeftRight_SizeChanged(object sender, EventArgs e)
    {
        //var Content1 = sender as HorizontalStackLayout;
        //var v1 = Content1.Children[0] as CollectionView;
        //var v2 = (Content1.Children[2] as ContentPresenter).Content as MaonsViewItem;
        //if (v2 == null)
        //{
        //    return;
        //}

        double w1 = v1.Content.MaximumWidthRequest, w12 = v1.Content.MinimumWidthRequest, w2 = v2.Content.MaximumWidthRequest, w22 = v2.Content.MinimumWidthRequest;

        double a1 = w1 + w2;
        double a2 = w1 + w22;
        double a3 = w1 ;
        double a4 = w12 ;

        if (this.Width >= a1)
        {
            v1.WidthRequest = w1;
            v2.WidthRequest = w2;
            v2.IsVisible = true;
        }
        else if (this.Width >= a2)
        {
            v1.WidthRequest = w1;
            v2.WidthRequest = this.Width - w1;
            v2.IsVisible = true;
        }
        else if (this.Width >= a3)
        {
            this.WidthRequest = w1;
            v1.WidthRequest =w1;
            v2.WidthRequest = 0;
            v2.IsVisible = false;
        }
        else if (this.Width >= a4)
        {
            v1.WidthRequest = this.Width;
            v2.WidthRequest = 0;
            v2.IsVisible = false;
        }
        else
        {
            v1.WidthRequest = w12;
            v2.WidthRequest = 0;
            v2.IsVisible = false;
        }
    }
}