namespace Maons.Controls;

public partial class MaonsNavigation : ContentView
{
	public MaonsNavigation()
	{
		InitializeComponent();
        //Topbar = new MaonsBar();
	}

    public static readonly BindableProperty IsBackVisibleProperty = BindableProperty.Create("IsBackVisible", typeof(bool), typeof(MaonsNavigation), false);


    public bool IsBackVisible
    {
        get => (bool)GetValue(IsBackVisibleProperty);
        set => SetValue(IsBackVisibleProperty, value);
    }

    public static readonly BindableProperty TopbarProperty = BindableProperty.Create("Topbar", typeof(ContentView), typeof(MaonsNavigation), null);

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

}