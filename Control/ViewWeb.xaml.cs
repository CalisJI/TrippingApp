using Microsoft.Web.WebView2.Core;
using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms.Integration;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace TrippingApp.Control
{
    /// <summary>
    /// Interaction logic for ViewWeb.xaml
    /// </summary>
    public partial class ViewWeb : UserControl
    {
        private static Grid grid = new Grid();
        private static Viewbox Viewbox = new Viewbox();
        private static int Page = -1;


        public int PageIndex
        {
            get { return (int)GetValue(PageIndexProperty); }
            set { SetValue(PageIndexProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PageIndex.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PageIndexProperty =
            DependencyProperty.Register("PageIndex", typeof(int), typeof(ViewWeb), new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public string Source
        {
            get { return (string)GetValue(SourceProperty); }
            set { SetValue(SourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Source.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source", typeof(string), typeof(ViewWeb), new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        private static WebView2 web;
        public static WebView2 View2 
        {
            get 
            {
                if (web == null) 
                {
                    web = new WebView2();
                    web.CreationProperties = new CoreWebView2CreationProperties();
                    web.NavigationCompleted += Web_NavigationCompleted;
                    web.NavigationStarting += Web_NavigationStarting;
                    web.SourceChanged += Web_SourceChanged;
                    return web;
                }
                else 
                {
                    return web;
                }
            }
            set 
            {
                web = value;
            }
        }

        private static void Web_SourceChanged(object sender, CoreWebView2SourceChangedEventArgs e)
        {
            ////throw new NotImplementedException();
            //if (!grid.Children.Contains(View2))
            //{
            //    grid.Children.Add(View2);
            //}

        }

        private static void Web_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            //View2.Visibility = Visibility.Hidden;
        }

        private static void Web_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            //View2.Visibility = Visibility.Visible;           
        }

        private static ViewWeb instance;
        public ViewWeb()
        {
            InitializeComponent();
            grid.Width = 1920;
            grid.Height = 990;
            Viewbox.Child = grid;
            this.AddChild(Viewbox);
        }
        public static ViewWeb Instance 
        {
            get
            {
                if (instance == null) 
                {
                    instance = new ViewWeb();
                    return instance;
                }
                else 
                {
                    return instance;
                }

            }

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if(PageIndex != Page) 
            {
                View2.Source = new Uri(Source);
                PageIndex = Page;
            }
            
            if (!grid.Children.Contains(View2))
            {
                grid.Children.Add(View2);
            }

        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            //grid.Children.Clear();
            //if (View2 != null) 
            //{
            //    View2.Dispose();
            //    View2 = null;
            //}
        }
    }
}
