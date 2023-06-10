using System.Collections.ObjectModel;


namespace Maons.Controls;


public sealed partial  class MaonsViewItemMessages : MaonsViewItem
{

    public static readonly BindableProperty Items2Property = BindableProperty.Create("Items2", typeof(ObservableCollection<MaonsViewItem>), typeof(MaonsViewItemMessages), null);

    public IList<MaonsViewItem> Items2
    {
        get => (IList<MaonsViewItem>)GetValue(Items2Property);
        set => SetValue(Items2Property, value);
    }
 
    public static readonly BindableProperty RightViewProperty = BindableProperty.Create("RightView", typeof(ContentView), typeof(MaonsViewItemMessages), null);

  
    public ContentView RightView
    {
        get => (ContentView)GetValue(RightViewProperty);
        set => SetValue(RightViewProperty, value);
    }


    public MaonsViewItemMessages( ContentView right)
    {

        InitializeComponent();
        BindingContext = this;

        RightView = right;
        this.MinimumWidthRequest = v1.MinimumWidthRequest;
        this.MaximumWidthRequest = right.MaximumWidthRequest + v1.MaximumWidthRequest;
        SizeChanged += MaonsViewItemLeftRight_SizeChanged;

        if (!MaonsPage.IsPc)
        {
            // 
            v2.IsBackVisible = true;
        }
    }
    public override Size MyMeasure(double widthConstraint, double heightConstraint)
    {
        double w1 = 380, w12 = 250, w2 = v2.Content.MaximumWidthRequest, w22 = v2.Content.MinimumWidthRequest;

        double a1 = w1 + w2;
        double a2 = w12 + w2;
        double a3 = w2;
        double a4 = w22;

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

            return new Size(a3, heightConstraint);
        }
        else if (widthConstraint >= a4)
        {
            return new Size(widthConstraint, heightConstraint);
        }
        else
        {
            return new Size(a4, heightConstraint);
        }
    }
   

    private void MaonsViewItemLeftRight_SizeChanged(object sender, EventArgs e)
    {
        //var clview = new CollectionView();

        double w1 = 380, w12 = 250, w2 = v2.Content.MaximumWidthRequest, w22 = v2.Content.MinimumWidthRequest;

     
        double a1 = w1 + w2;
        double a2 = w12 + w2;
        double a3 = w2;
        double a4 = w22;

        if (this.Width >= a1)
        {
            v1.WidthRequest = w1;
            v2.WidthRequest = w2;
            v2.IsVisible = true;
            v1.IsVisible = true;
            //v2.IsBackVisible = false;

        }
        else if (this.Width >= a2)
        {
            v1.WidthRequest = this.Width - w2;
            v2.WidthRequest = w2;
            v2.IsVisible = true;
            v1.IsVisible= true;
            //v2.IsBackVisible = false;

        }
        else if (this.Width >= a3)
        {
            if (clview.SelectedItem!=null)
            {
                v1.WidthRequest = 0;
                v2.WidthRequest = w2;
                v1.IsVisible = false;
                v2.IsVisible = true;
              //  v2.IsBackVisible= true;
            //    (v2.Content as MaonsMessageItem).IsBackvisible = true;
            }
            else
            {
                
                v1.WidthRequest = w2;
                v2.WidthRequest = 0;
                v2.IsVisible = false;
                v1.IsVisible = true;
                
            }
         
        }
        else if (this.Width >= a4)
        {
            if (clview.SelectedItem != null)
            {
                v1.WidthRequest = 0;
                v2.WidthRequest = this.Width;
                v1.IsVisible = false;
                v2.IsVisible = true;
              //  v2.IsBackVisible = true;

            }
            else
            {

                v1.WidthRequest = this.Width;
                v2.WidthRequest = 0;
                v2.IsVisible = false;
                v1.IsVisible = true;
            }

        }
        else
        {
            if (clview.SelectedItem != null)
            {
                v1.WidthRequest = 0;
                v2.WidthRequest = w22;
                v1.IsVisible = false;
                v2.IsVisible = true;
                //v2.IsBackVisible = true;
            }
            else
            {

                v1.WidthRequest = w22;
                v2.WidthRequest = 0;
                v2.IsVisible = false;
                v1.IsVisible = true;
            }
        }
    }

    private void v1_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        //  var clview = new CollectionView();

        // 

        if (clview.SelectedItem !=null)
        {
            this.RightView = clview.SelectedItem as ContentView;
        }
        else
        {

        }     
        MaonsViewItemLeftRight_SizeChanged(this, null);
    }

    private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        if (v2.Pop() == v2.Content)
        {
            clview.SelectedItem = null;
            if (!MaonsPage.IsPc)
            {
                v2.IsBackVisible = true;
            }
            MaonsViewItemLeftRight_SizeChanged(this, null);
        }
    }
}