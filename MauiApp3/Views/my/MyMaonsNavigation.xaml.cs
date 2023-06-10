using Maons.my;
using Microsoft.Maui.Controls.Xaml;
using System.Configuration.Internal;

namespace Maons.Controls;

public partial class MyMaonsNavigation : ContentView
{
	public MyMaonsNavigation()
    {
  
        //  cmain = my;
        InitializeComponent();
        BindingContext = this;
        MinimumWidthRequest = 400;
        MaximumWidthRequest = 600;
        //CurContent = my;
        navig.Content = CurContent;
        // cmain.Content = CurContent;
        //Topbar = new MaonsBar();

        //  IconSource = (it)cmain.Content
        //swich.SetBinding(Image.SourceProperty, new MultiBinding()
        //{
        //    Bindings =
        //    {

        //        new Binding(){Source=true},
        //        new Binding(){ Source = CurContent ,Path = "IconSource"}
        //    },
        //    Converter = new Converter.IcoimgMultiConverter()
        //});

    }

    private MaonsViewItem my = new My() { IconSource = "qianbao.png"};
    
    private MaonsViewItem profile = new Profile() { IconSource = "profile_light.png" };

    //public static readonly BindableProperty IconSourceProperty = BindableProperty.Create("IconSource", typeof(string), typeof(MyMaonsNavigation), "");


    //public string IconSource
    //{
    //    get => (string)GetValue(IconSourceProperty);
    //    set => SetValue(IconSourceProperty, value);
    //}

    public static readonly BindableProperty IsBackVisibleProperty = BindableProperty.Create("IsBackVisible", typeof(bool), typeof(MyMaonsNavigation), false);


    public bool IsBackVisible
    {
        get => (bool)GetValue(IsBackVisibleProperty);
        set => SetValue(IsBackVisibleProperty, value);
    }

    public static readonly BindableProperty TopbarProperty = BindableProperty.Create("Topbar", typeof(ContentView), typeof(MyMaonsNavigation), null);

    public ContentView Topbar
    {
        get { 
            
           var c= (ContentView)GetValue(TopbarProperty);

            if (c==null)
            {
                return new MaonsBar();
            }
            return c;
        }
        set => SetValue(TopbarProperty, value);
    }
    public static readonly BindableProperty CurContentProperty = BindableProperty.Create("CurContent", typeof(MaonsViewItem), typeof(MyMaonsNavigation), null);
    public MaonsViewItem CurContent
    {
        get
        {
            var c = (MaonsViewItem)GetValue(CurContentProperty);
            if (c == null)
            {
                return my;
            }
            return c;
        }
        set => SetValue(CurContentProperty, value);
    }

    protected Stack<ContentView> st = new Stack<ContentView>();

    protected View root;

    public void Push(ContentView view)
    {
        if (st.Count == 0)
        {
            root = this.Content;
        }
        st.Push(view);
        //   root = this.Content;
        this.Content = view;
        IsBackVisible = true;
    }
    public View Pop()
    {
        if (st.Count == 0)
        {
            return this.Content;
        }
        else
        {
            var v = st.Pop();
            ContentView view;
            if (st.TryPeek(out view))
            {
                this.Content = view;

            }
            else
            {
                this.Content = root;
                IsBackVisible = false;
            }
            return this.Content;
           
        }

        //var v = st.Pop();
        //ContentView view;
        //if (st.TryPeek(out view))
        //{
        //    this.Content = view;
        //}
        //else
        //{
        //    this.Content = root;
        //}
    }

    //private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    //{
    //    if (CurContent == my)
    //    {
    //        CurContent = profile;
    //    }
    //    else
    //    {
    //        CurContent = my;
    //    }
    //}

    private void Button_Clicked(object sender, EventArgs e)
    {
        if (CurContent == my)
        {
            CurContent = profile;
            profile.Changemenu("");
        }
        else
        {
            CurContent = my;
        }
        navig.Content = CurContent;
    }
}