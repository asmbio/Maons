using Microsoft.Maui.ApplicationModel.Communication;
using System.Collections.ObjectModel;

namespace Maons.Controls
{
    public partial class MaonsPage : ContentView
    {
      

        public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(MaonsPage), default(string));
        public static readonly BindableProperty ItemsProperty = BindableProperty.Create("Items", typeof(ObservableCollection<MaonsViewItem>), typeof(MaonsPage), default(ObservableCollection<MaonsViewItem>));


        public static readonly BindableProperty CurrentViewProperty = BindableProperty.Create("CurrentView", typeof(MaonsViewItem), typeof(MaonsPage), null);


        public static bool IsPc =true;
       
        public string HeaderText
        {
            get => (string)GetValue(HeaderTextProperty);
            set => SetValue(HeaderTextProperty, value);
        }

        public MaonsViewItem CurrentView
        {
            get => (MaonsViewItem)GetValue(CurrentViewProperty);
            set => SetValue(CurrentViewProperty, value);
        }
        public IList<MaonsViewItem> Items
        {
            get => (IList<MaonsViewItem>)GetValue(ItemsProperty);
            set => SetValue(ItemsProperty, value);
        }

        public MaonsPage()
        {
            InitializeComponent();
#if IOS || ANDROID
            ControlTemplate = (ControlTemplate)Resources["AppTemplate"];
            IsPc= false;    
            
#else
            ControlTemplate = (ControlTemplate)Resources["PCTemplate"];
            //SizeChanged += MaonsPage_SizeChanged;
#endif



        }

        protected  void ImageButton_Clicked(object sender, EventArgs e)
        {
            
            foreach (MaonsViewItem item in Items)
            {
                item.Selected = false;
            }


            var view = Items[0];

            view.Selected = true;

            Content = view;

            
        }

        protected void MaonsPage_SizeChanged(object sender, EventArgs e)
        {                       
            var Content1 =  sender as HorizontalStackLayout;
            var v1 = Content1.Children[0] as CollectionView;
            // var v2 = ((Content1.Children[2] as ContentPresenter).Content as ContentPresenter).Content as MaonsViewItem;
            var v2 = ((Content1.Children[2] as ContentPresenter)).Content as MaonsViewItem;
            //var v3 = ((Content1.Children[4] as ContentView) as ContentView).Content as ContentView;

            //if ((v2 as MaonsViewItem ).HideLeft)
            //{
            //    var vt = v2;
            //    v2 = v3;
            //    v3= vt;
            //}

            if (v2 == null )
            {
                return;
            }


            double w1 = v1.MaximumWidthRequest, w12 = v1.MinimumWidthRequest;

            double w2 = v2.MaximumWidthRequest, w22 = v2.MinimumWidthRequest;

          //  double w3 = v3.MaximumWidthRequest,w32 =  v3.MinimumWidthRequest; 


            double a1 = w1 + w2 ;
            double a2 = w12 + w2  ;
            double a3 = w12 + w22 ;

            //double a4 = w12 + w2;

            //double a5 = w12 + w22;


           


            if (this.Width >= a1)
            {
                v1.WidthRequest = w1;
                v2.WidthRequest = w2;
             
            }
            else if (this.Width >= a2)
            {
                v1.WidthRequest = ((this.Width - w2)-w12)/10 + w12;
                v2.WidthRequest = w2;
               
            }
            else if (this.Width >= a3)
            {
                //  v1.WidthRequest = w12;
                var size = v2.MyMeasure(this.Width - w12, this.Height);

                v2.WidthRequest = size.Width;

                v1.WidthRequest = ((this.Width - size.Width) - w12) / 10 + w12;

            }   
            else
            {
                v1.WidthRequest = w12;
                v2.WidthRequest = w22;
             

            }

        }


        protected void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Content = sender as ;
            if (e.CurrentSelection.Count > 0)
            {
                var collview = sender as CollectionView;
                foreach (MaonsViewItem item in collview.ItemsSource)
                {
                    item.Selected = false;
                }


                var view = e.CurrentSelection[0] as MaonsViewItem;
                //contacts
                view.Changemenu("contacts");
                Content = null;

                Content = view;

            //    var Content1 = collview.Parent as HorizontalStackLayout;

          //      (Content1.Children[4] as ContentView).Content = view.RightView;



            }
        }
    }
}
