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
    /// Interaction logic for Conveyor_Control.xaml
    /// </summary>
    public partial class Conveyor_Control : UserControl
    {
        public Conveyor_Control()
        {
            InitializeComponent();
        }



        public string NameConveyor
        {
            get { return (string)GetValue(NameConveyorProperty); }
            set { SetValue(NameConveyorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameConveyor.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameConveyorProperty =
            DependencyProperty.Register("NameConveyor", typeof(string), typeof(Conveyor_Control), new FrameworkPropertyMetadata("",FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public ICommand Click_Initial
        {
            get { return (ICommand)GetValue(Click_InitialProperty); }
            set { SetValue(Click_InitialProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Click_Initial.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Click_InitialProperty =
            DependencyProperty.Register("Click_Initial", typeof(ICommand), typeof(Conveyor_Control));



        public ICommand InClick_Down_Command
        {
            get { return (ICommand)GetValue(InClick_Down_CommandProperty); }
            set { SetValue(InClick_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InClick_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InClick_Down_CommandProperty =
            DependencyProperty.Register("InClick_Down_Command", typeof(ICommand), typeof(Conveyor_Control));
        public ICommand InClick_Up_Command
        {
            get { return (ICommand)GetValue(InClick_Up_CommandProperty); }
            set { SetValue(InClick_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for InClick_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InClick_Up_CommandProperty =
            DependencyProperty.Register("InClick_Up_Command", typeof(ICommand), typeof(Conveyor_Control));

        public ICommand OutClick_Down_Command
        {
            get { return (ICommand)GetValue(OutClick_Down_CommandProperty); }
            set { SetValue(OutClick_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OutClick_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OutClick_Down_CommandProperty =
            DependencyProperty.Register("OutClick_Down_Command", typeof(ICommand), typeof(Conveyor_Control));
        public ICommand OutClick_Up_Command
        {
            get { return (ICommand)GetValue(OutClick_Up_CommandProperty); }
            set { SetValue(OutClick_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OutClick_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OutClick_Up_CommandProperty =
            DependencyProperty.Register("OutClick_Up_Command", typeof(ICommand), typeof(Conveyor_Control));


    }
}
