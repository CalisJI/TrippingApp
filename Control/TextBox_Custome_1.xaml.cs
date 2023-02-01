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
    /// Interaction logic for TextBox_Custome_1.xaml
    /// </summary>
    public partial class TextBox_Custome_1 : UserControl
    {
        public TextBox_Custome_1()
        {
            InitializeComponent();
        }



        public int ChieuRong
        {
            get { return (int)GetValue(ChieuRongProperty); }
            set { SetValue(ChieuRongProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChieuRong.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChieuRongProperty =
            DependencyProperty.Register("ChieuRong", typeof(int), typeof(TextBox_Custome_1), new PropertyMetadata(150));



        public int ChieuCao
        {
            get { return (int)GetValue(ChieuCaoProperty); }
            set { SetValue(ChieuCaoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChieuCao.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChieuCaoProperty =
            DependencyProperty.Register("ChieuCao", typeof(int), typeof(TextBox_Custome_1), new PropertyMetadata(80));



        public int NumberValue
        {
            get { return (int)GetValue(NumberValueProperty); }
            set { SetValue(NumberValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NumberValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberValueProperty =
            DependencyProperty.Register("NumberValue", typeof(int), typeof(TextBox_Custome_1), new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public float NumberValueF
        {
            get { return (float)GetValue(NumberValueFProperty); }
            set { SetValue(NumberValueFProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NumberValueF.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberValueFProperty =
            DependencyProperty.Register("NumberValueF", typeof(float), typeof(TextBox_Custome_1), new FrameworkPropertyMetadata(0.0f,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public bool NumberMode
        {
            get { return (bool)GetValue(NumberModeProperty); }
            set { SetValue(NumberModeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NumberMode.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NumberModeProperty =
            DependencyProperty.Register("NumberMode", typeof(bool), typeof(TextBox_Custome_1), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool UnLimited
        {
            get { return (bool)GetValue(UnLimitedProperty); }
            set { SetValue(UnLimitedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UnLimited.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UnLimitedProperty =
            DependencyProperty.Register("UnLimited", typeof(bool), typeof(TextBox_Custome_1), new PropertyMetadata(false));



        public ICommand BTN_Up_Command
        {
            get { return (ICommand)GetValue(BTN_Up_CommandProperty); }
            set { SetValue(BTN_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BTN_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BTN_Up_CommandProperty =
            DependencyProperty.Register("BTN_Up_Command", typeof(ICommand), typeof(TextBox_Custome_1));




        void Inscrease() 
        {
            if (!NumberMode)
            {
                if (NumberValue < 2500 && !UnLimited)
                {
                    SetValue(NumberValueProperty, NumberValue += 1);
                }
                else 
                {
                    SetValue(NumberValueProperty, NumberValue += 1);
                }
            }
            else 
            {
                if (NumberValueF < 100.0f)
                {
                    SetValue(NumberValueFProperty, NumberValueF += 0.1f);
                }
              
            }
        }
        void Descrease() 
        {
            if (!NumberMode)
            {
                if (NumberValue > 0)
                {
                    SetValue(NumberValueProperty, NumberValue -= 1);
                }
            }
            else 
            {
                if (NumberValueF > 0)
                {
                    SetValue(NumberValueFProperty, NumberValueF -= 0.1f);
                }
            }
        }
        private void RepeatButton_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            Inscrease();
        }

        private void RepeatButton_Click(object sender, RoutedEventArgs e)
        {
           Inscrease();
        }

        private void RepeatButton_PreviewTouchDown_1(object sender, TouchEventArgs e)
        {
            Descrease();
        }

        private void RepeatButton_Click_1(object sender, RoutedEventArgs e)
        {
            Descrease();
        }
    }
    
}
