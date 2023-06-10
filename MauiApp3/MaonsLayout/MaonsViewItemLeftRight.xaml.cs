

namespace Maons.Controls;


public sealed partial  class MaonsViewItemLeftRight : MaonsViewItem
{
    public static readonly BindableProperty LeftViewProperty = BindableProperty.Create("LeftView", typeof(ContentView), typeof(MaonsViewItemLeftRight), new ContentView() { MinimumWidthRequest = 400, MaximumWidthRequest = 600 });

    public static readonly BindableProperty RightViewProperty = BindableProperty.Create("RightView", typeof(ContentView), typeof(MaonsViewItemLeftRight), new ContentView() { MinimumWidthRequest = 0, MaximumWidthRequest = 0 });

    public ContentView LeftView
    {
        get => (ContentView)GetValue(LeftViewProperty);
        set => SetValue(LeftViewProperty, value);
    }
    public ContentView RightView
    {
        get => (ContentView)GetValue(RightViewProperty);
        set => SetValue(RightViewProperty, value);
    }


    public MaonsViewItemLeftRight(ContentView left ,ContentView right)
	{
     
		InitializeComponent();
        BindingContext = this;
        LeftView = left;
        RightView = right;
        this.MinimumWidthRequest = left.MinimumWidthRequest;
        this.MaximumWidthRequest = right.MaximumWidthRequest+left.MaximumWidthRequest;
        SizeChanged += MaonsViewItemLeftRight_SizeChanged;
        
    }
    
    public override Size MyMeasure(double widthConstraint, double heightConstraint)
    {
        double w1 = v1.Content.MaximumWidthRequest, w12 = v1.Content.MinimumWidthRequest, w2 = v2.Content.MaximumWidthRequest, w22 = v2.Content.MinimumWidthRequest;

        double a1 = w1 + w2;
        double a2 = w1 + w22;
        double a3 = w1;
        double a4 = w12;

        if (widthConstraint >= a1)
        {
            //v1.WidthRequest = w1;
            //v2.WidthRequest = w2;
            return new Size(a1, heightConstraint);
        }
        else if (widthConstraint >= a2)
        {
            //v1.WidthRequest = w1;
            //v2.WidthRequest = this.Width - w1;
            return new Size(widthConstraint, heightConstraint);
        }
        else if (widthConstraint >= a3)
        {
            //this.WidthRequest = w1;
            //v1.WidthRequest = w1;
            //v2.WidthRequest = 0;
            //v2.IsVisible = false;

            return new Size(w1, heightConstraint);
        }
        else if (widthConstraint >= a4)
        {
            return new Size(widthConstraint, heightConstraint);
        }
        else
        {
            return new Size(w12, heightConstraint);
        }
    }
    //public override SizeRequest Measure(double widthConstraint, double heightConstraint, MeasureFlags flags = MeasureFlags.None)
    //{
    //    double w1 = v1.Content.MaximumWidthRequest, w12 = v1.Content.MinimumWidthRequest, w2 = v2.Content.MaximumWidthRequest, w22 = v2.Content.MinimumWidthRequest;

    //    double a1 = w1 + w2;
    //    double a2 = w1 + w22;
    //    double a3 = w1;
    //    double a4 = w12;

    //    if (widthConstraint >= a1)
    //    {
    //        //v1.WidthRequest = w1;
    //        //v2.WidthRequest = w2;
    //        return new SizeRequest(new Size(a1,heightConstraint));
    //    }
    //    else if (widthConstraint >= a2)
    //    {
    //        //v1.WidthRequest = w1;
    //        //v2.WidthRequest = this.Width - w1;
    //        return new SizeRequest(new Size(widthConstraint, heightConstraint));
    //    }
    //    else if (widthConstraint >= a3)
    //    {
    //        //this.WidthRequest = w1;
    //        //v1.WidthRequest = w1;
    //        //v2.WidthRequest = 0;
    //        //v2.IsVisible = false;

    //        return new SizeRequest(new Size(w1, heightConstraint));
    //    }
    //    else if (widthConstraint >= a4)
    //    {
    //        return new SizeRequest(new Size(widthConstraint, heightConstraint));
    //    }
    //    else
    //    {
    //        return new SizeRequest(new Size(w12, heightConstraint));
    //    }

    //}

    public override void Changemenu(string menu)
    {
        base.Changemenu(menu);

        var cw = this.LeftView;
        while (!(cw is MaonsViewItem))
        {
            if (cw.Content is ContentView)
            {
                cw =  cw.Content as ContentView;
            }
            else
            {
                break;
            }           
        }
        if (cw is MaonsViewItem)
        {
            (cw as MaonsViewItem).Changemenu(menu);
        }
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
           // this.WidthRequest = w1;
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