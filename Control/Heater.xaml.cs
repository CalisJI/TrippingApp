using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Heater.xaml
    /// </summary>
    public partial class Heater : UserControl
    {

        public int Number
        {
            get { return (int)GetValue(NumberProperty); }
            set { 
                SetValue(NumberProperty, value); 
            }
        }

        // Using a DependencyProperty as the backing store for Number.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(int), typeof(Heater), new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public string NumberS
        {
            get { return (string)GetValue(NumberSProperty); }
            set { SetValue(NumberSProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NumberS.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberSProperty =
            DependencyProperty.Register("NumberS", typeof(string), typeof(Heater), new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool Fpoint
        {
            get { return (bool)GetValue(FpointProperty); }
            set { SetValue(FpointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Fpoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FpointProperty =
            DependencyProperty.Register("Fpoint", typeof(bool), typeof(Heater), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public int Length_X
        {
            get { return (int)GetValue(Length_XProperty); }
            set { SetValue(Length_XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Length_X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Length_XProperty =
            DependencyProperty.Register("Length_X", typeof(int), typeof(Heater), new FrameworkPropertyMetadata(100,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public int Length_Y
        {
            get { return (int)GetValue(Length_YProperty); }
            set { SetValue(Length_YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Length_Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Length_YProperty =
            DependencyProperty.Register("Length_Y", typeof(int), typeof(Heater), new FrameworkPropertyMetadata(100,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));







        public Brush MauChu
        {
            get { return (Brush)GetValue(MauChuProperty); }
            set { SetValue(MauChuProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MauChu.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MauChuProperty =
            DependencyProperty.Register("MauChu", typeof(Brush), typeof(Heater), new PropertyMetadata(Brushes.WhiteSmoke));


        public Heater()
        {
            InitializeComponent();
        }

    }
    public  class A_Con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }
            int a = int.Parse((string)value);
            switch (a)
            {
                case 0:
                    return Visibility.Visible;
                case 1:
                    return Visibility.Hidden;
                case 2:
                    return Visibility.Visible;
                case 3:
                    return Visibility.Visible;
                case 4:
                    return Visibility.Hidden;
                case 5:
                    return Visibility.Visible;
                case 6:
                    return Visibility.Visible;
                case 7:
                    return Visibility.Visible;
                case 8:
                    return Visibility.Visible;
                case 9:
                    return Visibility.Visible; ;
                default:
                    return Visibility.Hidden;
            }
            
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class B_Con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }
            int a = int.Parse((string)value);
            switch (a)
            {
                case 0:
                    return Visibility.Visible;
                case 1:
                    return Visibility.Visible;
                case 2:
                    return Visibility.Visible;
                case 3:
                    return Visibility.Visible;
                case 4:
                    return Visibility.Visible;
                case 5:
                    return Visibility.Hidden;
                case 6:
                    return Visibility.Hidden;
                case 7:
                    return Visibility.Visible;
                case 8:
                    return Visibility.Visible;
                case 9:
                    return Visibility.Visible;
                default:
                    return Visibility.Hidden;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class C_Con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }
            int a = int.Parse((string)value);
            switch (a)
            {
                case 0:
                    return Visibility.Visible;
                case 1:
                    return Visibility.Visible;
                case 2:
                    return Visibility.Hidden;
                case 3:
                    return Visibility.Visible;
                case 4:
                    return Visibility.Visible;
                case 5:
                    return Visibility.Visible;
                case 6:
                    return Visibility.Visible;
                case 7:
                    return Visibility.Visible;
                case 8:
                    return Visibility.Visible;
                case 9:
                    return Visibility.Visible;
                default:
                    return Visibility.Hidden;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class D_Con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }
            int a = int.Parse((string)value);
            switch (a)
            {
                case 0:
                    return Visibility.Visible;
                case 1:
                    return Visibility.Hidden;
                case 2:
                    return Visibility.Visible;
                case 3:
                    return Visibility.Visible;
                case 4:
                    return Visibility.Hidden;
                case 5:
                    return Visibility.Visible;
                case 6:
                    return Visibility.Visible;
                case 7:
                    return Visibility.Hidden;
                case 8:
                    return Visibility.Visible;
                case 9:
                    return Visibility.Visible;
                default:
                    return Visibility.Hidden;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class E_Con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }
            int a = int.Parse((string)value);
            switch (a)
            {
                case 0:
                    return Visibility.Visible;
                case 1:
                    return Visibility.Hidden;
                case 2:
                    return Visibility.Visible;
                case 3:
                    return Visibility.Hidden;
                case 4:
                    return Visibility.Hidden;
                case 5:
                    return Visibility.Hidden;
                case 6:
                    return Visibility.Visible;
                case 7:
                    return Visibility.Hidden;
                case 8:
                    return Visibility.Visible;
                case 9:
                    return Visibility.Hidden;
                default:
                    return Visibility.Hidden;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class F_Con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }
            int a = int.Parse((string)value);
            switch (a)
            {
                case 0:
                    return Visibility.Visible;
                case 1:
                    return Visibility.Hidden;
                case 2:
                    return Visibility.Hidden;
                case 3:
                    return Visibility.Hidden;
                case 4:
                    return Visibility.Visible;
                case 5:
                    return Visibility.Visible;
                case 6:
                    return Visibility.Visible;
                case 7:
                    return Visibility.Hidden;
                case 8:
                    return Visibility.Visible;
                case 9:
                    return Visibility.Visible;
                default:
                    return Visibility.Hidden;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class G_Con : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value))
            {
                return false;
            }
            int a = int.Parse((string)value);
            switch (a)
            {
                case 0:
                    return Visibility.Hidden;
                case 1:
                    return Visibility.Hidden;
                case 2:
                    return Visibility.Visible;
                case 3:
                    return Visibility.Visible;
                case 4:
                    return Visibility.Visible;
                case 5:
                    return Visibility.Visible;
                case 6:
                    return Visibility.Visible;
                case 7:
                    return Visibility.Hidden;
                case 8:
                    return Visibility.Visible;
                case 9:
                    return Visibility.Visible;
                default:
                    return Visibility.Hidden;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class DPoint : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Visibility.Visible;
            }
            else return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
