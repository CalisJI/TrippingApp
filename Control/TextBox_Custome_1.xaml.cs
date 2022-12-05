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
            DependencyProperty.Register("NumberValue", typeof(int), typeof(TextBox_Custome_1), new PropertyMetadata(0));


        void Inscrease() 
        {
            if (NumberValue < 2500)
            {
                SetValue(NumberValueProperty, NumberValue += 1);
            }
        }
        void Descrease() 
        {
            if (NumberValue > 0)
            {
                SetValue(NumberValueProperty, NumberValue -= 1);
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
