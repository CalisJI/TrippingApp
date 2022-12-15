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
    /// Interaction logic for ServoLit_Control.xaml
    /// </summary>
    public partial class ServoLit_Control : UserControl
    {


        public int Jog_Speed
        {
            get { return (int)GetValue(Jog_SpeedProperty); }
            set { SetValue(Jog_SpeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_Speed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_SpeedProperty =
            DependencyProperty.Register("Jog_Speed", typeof(int), typeof(ServoLit_Control), new PropertyMetadata(0));



        public int Position_Above
        {
            get { return (int)GetValue(Position_AboveProperty); }
            set { SetValue(Position_AboveProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Position_Above.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Position_AboveProperty =
            DependencyProperty.Register("Position_Above", typeof(int), typeof(ServoLit_Control), new PropertyMetadata(0));



        public int Position_Below
        {
            get { return (int)GetValue(Position_BelowProperty); }
            set { SetValue(Position_BelowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Position_Below.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Position_BelowProperty =
            DependencyProperty.Register("Position_Below", typeof(int), typeof(ServoLit_Control), new PropertyMetadata(0));



        public int Position_Start
        {
            get { return (int)GetValue(Position_StartProperty); }
            set { SetValue(Position_StartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Position_Start.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Position_StartProperty =
            DependencyProperty.Register("Position_Start", typeof(int), typeof(ServoLit_Control), new PropertyMetadata(0));




        public int CurrentPos
        {
            get { return (int)GetValue(CurrentPosProperty); }
            set { SetValue(CurrentPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPosProperty =
            DependencyProperty.Register("CurrentPos", typeof(int), typeof(ServoLit_Control), new PropertyMetadata(0));



        public ICommand Jog_Up_P_Command
        {
            get { return (ICommand)GetValue(Jog_Up_P_CommandProperty); }
            set { SetValue(Jog_Up_P_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_Up_P_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_Up_P_CommandProperty =
            DependencyProperty.Register("Jog_Up_P_Command", typeof(ICommand), typeof(ServoLit_Control));


        public ICommand Jog_Up_N_Command
        {
            get { return (ICommand)GetValue(Jog_Up_N_CommandProperty); }
            set { SetValue(Jog_Up_N_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_Up_N_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_Up_N_CommandProperty =
            DependencyProperty.Register("Jog_Up_N_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Jog_Down_P_Command
        {
            get { return (ICommand)GetValue(Jog_Down_P_CommandProperty); }
            set { SetValue(Jog_Down_P_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_Down_P_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_Down_P_CommandProperty =
            DependencyProperty.Register("Jog_Down_P_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Jog_Down_N_Command
        {
            get { return (ICommand)GetValue(Jog_Down_N_CommandProperty); }
            set { SetValue(Jog_Down_N_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_Down_N_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_Down_N_CommandProperty =
            DependencyProperty.Register("Jog_Down_N_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Enable_Command
        {
            get { return (ICommand)GetValue(Enable_CommandProperty); }
            set { SetValue(Enable_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Enable_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Enable_CommandProperty =
            DependencyProperty.Register("Enable_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Origin_Command
        {
            get { return (ICommand)GetValue(Origin_CommandProperty); }
            set { SetValue(Origin_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Origin_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Origin_CommandProperty =
            DependencyProperty.Register("Origin_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Disable_Command
        {
            get { return (ICommand)GetValue(Disable_CommandProperty); }
            set { SetValue(Disable_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Disable_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Disable_CommandProperty =
            DependencyProperty.Register("Disable_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Set_Jog_Speed_Command
        {
            get { return (ICommand)GetValue(Set_Jog_Speed_CommandProperty); }
            set { SetValue(Set_Jog_Speed_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_Jog_Speed_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_Jog_Speed_CommandProperty =
            DependencyProperty.Register("Set_Jog_Speed_Command", typeof(ICommand), typeof(ServoLit_Control));




        public ICommand Set_Position_Above_Command
        {
            get { return (ICommand)GetValue(Set_Position_Above_CommandProperty); }
            set { SetValue(Set_Position_Above_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_Position_Above_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_Position_Above_CommandProperty =
            DependencyProperty.Register("Set_Position_Above_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Set_Position_Below_Command
        {
            get { return (ICommand)GetValue(Set_Position_Below_CommandProperty); }
            set { SetValue(Set_Position_Below_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_Position_Below_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_Position_Below_CommandProperty =
            DependencyProperty.Register("Set_Position_Below_Command", typeof(ICommand), typeof(ServoLit_Control));



        public ICommand Set_Position_Start_Command
        {
            get { return (ICommand)GetValue(Set_Position_Start_CommandProperty); }
            set { SetValue(Set_Position_Start_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_Position_Start_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_Position_Start_CommandProperty =
            DependencyProperty.Register("Set_Position_Start_Command", typeof(ICommand), typeof(ServoLit_Control));


        public ServoLit_Control()
        {
            InitializeComponent();
        }
    }
}
