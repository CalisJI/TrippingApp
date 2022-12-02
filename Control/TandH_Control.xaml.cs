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
    /// Interaction logic for TandH_Control.xaml
    /// </summary>
    public partial class TandH_Control : UserControl
    {
        public TandH_Control()
        {
            InitializeComponent();
        }



        public int ChieuDai
        {
            get { return (int)GetValue(ChieuDaiProperty); }
            set { SetValue(ChieuDaiProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChieuDai.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChieuDaiProperty =
            DependencyProperty.Register("ChieuDai", typeof(int), typeof(TandH_Control), new PropertyMetadata(0));



        public int ChieuRong
        {
            get { return (int)GetValue(ChieuRongProperty); }
            set { SetValue(ChieuRongProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ChieuRong.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChieuRongProperty =
            DependencyProperty.Register("ChieuRong", typeof(int), typeof(TandH_Control), new PropertyMetadata(0));



        public int NhietDo
        {
            get { return (int)GetValue(NhietDoProperty); }
            set { SetValue(NhietDoProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NhietDo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NhietDoProperty =
            DependencyProperty.Register("NhietDo", typeof(int), typeof(TandH_Control), new PropertyMetadata(0));



        public int DoAm
        {
            get { return (int)GetValue(DoAmProperty); }
            set { SetValue(DoAmProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DoAm.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DoAmProperty =
            DependencyProperty.Register("DoAm", typeof(int), typeof(TandH_Control), new PropertyMetadata(0));


    }
}
