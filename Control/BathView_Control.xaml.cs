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

namespace TrippingApp.Control
{
    /// <summary>
    /// Interaction logic for BathView_Control.xaml
    /// </summary>
    public partial class BathView_Control : UserControl
    {


        public string BathName
        {
            get { return (string)GetValue(BathNameProperty); }
            set { SetValue(BathNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BathName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BathNameProperty =
            DependencyProperty.Register("BathName", typeof(string), typeof(BathView_Control), new FrameworkPropertyMetadata("Bath 1",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public string DipTime
        {
            get { return (string)GetValue(DipTimeProperty); }
            set { SetValue(DipTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DipTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DipTimeProperty =
            DependencyProperty.Register("DipTime", typeof(string), typeof(BathView_Control), new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public string Barcode
        {
            get { return (string)GetValue(BarcodeProperty); }
            set { SetValue(BarcodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Barcode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BarcodeProperty =
            DependencyProperty.Register("Barcode", typeof(string), typeof(BathView_Control), new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public string InputTime
        {
            get { return (string)GetValue(InputTimeProperty); }
            set { SetValue(InputTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InputTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InputTimeProperty =
            DependencyProperty.Register("InputTime", typeof(string), typeof(BathView_Control), new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public float Temperature
        {
            get { return (float)GetValue(TemperatureProperty); }
            set { SetValue(TemperatureProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Temperature.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TemperatureProperty =
            DependencyProperty.Register("Temperature", typeof(float), typeof(BathView_Control), new FrameworkPropertyMetadata(0.0f,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public BathView_Control()
        {
            InitializeComponent();
        }
    }
}
