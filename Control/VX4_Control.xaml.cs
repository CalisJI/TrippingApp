using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Interaction logic for VX4_Control.xaml
    /// </summary>
    public partial class VX4_Control : UserControl
    {
        #region Dependency Object
        public float NhietDo
        {
            get { return (float)GetValue(NhietDoProperty); }
            set { SetValue(NhietDoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NhietDo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NhietDoProperty =
            DependencyProperty.Register("NhietDo", typeof(float), typeof(VX4_Control), new PropertyMetadata(00.0f, new PropertyChangedCallback(Convert_Number)));



        public float SetTemp
        {
            get { return (float)GetValue(SetTempProperty); }
            set { SetValue(SetTempProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetTemp.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetTempProperty =
            DependencyProperty.Register("SetTemp", typeof(float), typeof(VX4_Control), new PropertyMetadata(0.0f));



        public int Length_X
        {
            get { return (int)GetValue(Length_XProperty); }
            set { SetValue(Length_XProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Length_X.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Length_XProperty =
            DependencyProperty.Register("Length_X", typeof(int), typeof(VX4_Control), new PropertyMetadata(120));


        public int Length_Y
        {
            get { return (int)GetValue(Length_YProperty); }
            set { SetValue(Length_YProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Length_Y.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Length_YProperty =
            DependencyProperty.Register("Length_Y", typeof(int), typeof(VX4_Control), new PropertyMetadata(100));



        public bool RUN
        {
            get { return (bool)GetValue(RUNProperty); }
            set { SetValue(RUNProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Run.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RUNProperty =
            DependencyProperty.Register("RUN", typeof(bool), typeof(VX4_Control), new PropertyMetadata(false));



        public bool COM
        {
            get { return (bool)GetValue(COMProperty); }
            set { SetValue(COMProperty, value); }
        }

        // Using a DependencyProperty as the backing store for COM.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty COMProperty =
            DependencyProperty.Register("COM", typeof(bool), typeof(VX4_Control), new PropertyMetadata(true));



        public bool SUB1
        {
            get { return (bool)GetValue(SUB1Property); }
            set { SetValue(SUB1Property, value); }
        }

        // Using a DependencyProperty as the backing store for SUB1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SUB1Property =
            DependencyProperty.Register("SUB1", typeof(bool), typeof(VX4_Control), new PropertyMetadata(false));



        public bool OUT1
        {
            get { return (bool)GetValue(OUT1Property); }
            set { SetValue(OUT1Property, value); }
        }

        // Using a DependencyProperty as the backing store for OUT1.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OUT1Property =
            DependencyProperty.Register("OUT1", typeof(bool), typeof(VX4_Control), new PropertyMetadata(false));



        public bool IsBeingSet
        {
            get { return (bool)GetValue(IsBeingSetProperty); }
            set { SetValue(IsBeingSetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsBeingSet.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsBeingSetProperty =
            DependencyProperty.Register("IsBeingSet", typeof(bool), typeof(VX4_Control), new PropertyMetadata(false));





        public int Posit
        {
            get { return (int)GetValue(PositProperty); }
            set { SetValue(PositProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Posit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PositProperty =
            DependencyProperty.Register("Posit", typeof(int), typeof(VX4_Control), new PropertyMetadata(0));




        public ICommand WriteCommand
        {
            get { return (ICommand)GetValue(WriteCommandProperty); }
            set { SetValue(WriteCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WriteCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WriteCommandProperty =
            DependencyProperty.Register("WriteCommand", typeof(ICommand), typeof(VX4_Control), new PropertyMetadata());



        #endregion



        #region Property Normal
        private bool _isSet = false;

        public bool IsSet
        {
            get { return _isSet; }
            set { _isSet = value; }
        }


        #endregion

        private static void Convert_Number(DependencyObject dp, DependencyPropertyChangedEventArgs args)
        {
            
        }
        

        public VX4_Control()
        {
            InitializeComponent();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
            if (!IsSet)
            {
                return;
            }
            SetValue(SetTempProperty, (float)Math.Round((float)(SetTemp += 0.1f), 1));
        }

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (!IsSet)
            {
                return;
            }
            SetValue(SetTempProperty, (float)Math.Round((float)(SetTemp -= 0.1f), 1));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SetValue(IsBeingSetProperty, true);
            IsSet = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            SetValue(IsBeingSetProperty, false);
            IsSet = false;
        }

        private void RepeatButton_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!IsSet)
            {
                return ;
            }
            SetValue(IsBeingSetProperty, false);
        }

        private void RepeatButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!IsSet)
            {
                return;
            }
            SetValue(IsBeingSetProperty, true);
        }

        private void RepeatButton_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (!IsSet)
            {
                return;
            }
            SetValue(IsBeingSetProperty, false);
        }

        private void RepeatButton_PreviewMouseUp_1(object sender, MouseButtonEventArgs e)
        {
            if (!IsSet)
            {
                return;
            }
            SetValue(IsBeingSetProperty, true);
        }
    }
    public class Ditgit1 : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            else
            {
                
                var a = Math.Round((float)value, 1);
                uint a_int = (uint)a;
                var tram = a_int / 100;
                return tram;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
           return null;
        }
    }
    public class Ditgit1_show : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value == null) return Visibility.Hidden;
            else
            {

                var a = Math.Round((float)value, 1);
                uint a_int = (uint)a;
                var tram = a_int / 100;
                if(tram == 0)
                {
                    return Visibility.Hidden;
                }
                else
                {
                    return Visibility.Visible;
                }
                
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class Ditgit2 : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            else
            {

                var a = Math.Round((float)value, 1);
                uint a_int = (uint)a;
                var chuc = (a_int % 100) / 10;
                return chuc;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class Ditgit2_show : IValueConverter
    {
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            else
            {

                var a = Math.Round((float)value, 1);
                uint a_int = (uint)a;

                var tram = a_int / 100;
                if (tram == 0)
                {
                    var chuc = (a_int % 100) / 10;
                    if(chuc == 0)
                    {
                        return Visibility.Hidden;
                    }
                    else
                    {
                        return Visibility.Visible;
                    }
                }
                else
                {
                    return Visibility.Visible;
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class Digit3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            else
            {

                var a = Math.Round((float)value, 1);
                uint a_int = (uint)a;
                var donvi = (a_int % 100) % 10;
                return donvi;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
    public class Digit4 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return 0;
            else
            {

                float a = (float)Math.Round((float)value, 1);
                uint a_int = (uint)a;
                var b = a - a_int;

                b *= 10;
                return (int)b;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
