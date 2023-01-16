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
    /// Interaction logic for Robot_Control.xaml
    /// </summary>
    public partial class Robot_Control : UserControl
    {


        public ICommand SetSpeedCommand
        {
            get { return (ICommand)GetValue(SetSpeedCommandProperty); }
            set { SetValue(SetSpeedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetSpeedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetSpeedCommandProperty =
            DependencyProperty.Register("SetSpeedCommand", typeof(ICommand), typeof(Robot_Control));



        public ICommand Set_PosBath4_Command
        {
            get { return (ICommand)GetValue(Set_PosBath4_CommandProperty); }
            set { SetValue(Set_PosBath4_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_PosBath4_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_PosBath4_CommandProperty =
            DependencyProperty.Register("Set_PosBath4_Command", typeof(ICommand), typeof(Robot_Control));


        public ICommand Set_PosBath5_Command
        {
            get { return (ICommand)GetValue(Set_PosBath5_CommandProperty); }
            set { SetValue(Set_PosBath5_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_PosBath5_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_PosBath5_CommandProperty =
            DependencyProperty.Register("Set_PosBath5_Command", typeof(ICommand), typeof(Robot_Control));




        public ICommand Set_PosBath6_Command
        {
            get { return (ICommand)GetValue(Set_PosBath6_CommandProperty); }
            set { SetValue(Set_PosBath6_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_PosBath6_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_PosBath6_CommandProperty =
            DependencyProperty.Register("Set_PosBath6_Command", typeof(ICommand), typeof(Robot_Control));


        ///// <summary>
        ///// Trigger Jog BW Positive Edge
        ///// </summary>
        //public ICommand JogBW_P_Command
        //{
        //    get { return (ICommand)GetValue(JogBW_P_CommandProperty); }
        //    set { SetValue(JogBW_P_CommandProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for JogBW_P_Command.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty JogBW_P_CommandProperty =
        //    DependencyProperty.Register("JogBW_P_Command", typeof(ICommand), typeof(Robot_Control));


        //public ICommand JogBW_N_Command
        //{
        //    get { return (ICommand)GetValue(JogBW_N_CommandProperty); }
        //    set { SetValue(JogBW_N_CommandProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for JogBW_N_Command.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty JogBW_N_CommandProperty =
        //    DependencyProperty.Register("JogBW_N_Command", typeof(ICommand), typeof(Robot_Control));



        //public ICommand JogFW_P_Command
        //{
        //    get { return (ICommand)GetValue(JogFW_P_CommandProperty); }
        //    set { SetValue(JogFW_P_CommandProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for JogFW_P_Command.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty JogFW_P_CommandProperty =
        //    DependencyProperty.Register("JogFW_P_Command", typeof(ICommand), typeof(Robot_Control));



        //public ICommand JogFW_N_Command
        //{
        //    get { return (ICommand)GetValue(JogFW_N_CommandProperty); }
        //    set { SetValue(JogFW_N_CommandProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for JogFW_N_Command.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty JogFW_N_CommandProperty =
        //    DependencyProperty.Register("JogFW_N_Command", typeof(ICommand), typeof(Robot_Control));



        public ICommand Enable_Command
        {
            get { return (ICommand)GetValue(Enable_CommandProperty); }
            set { SetValue(Enable_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Enable_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Enable_CommandProperty =
            DependencyProperty.Register("Enable_Command", typeof(ICommand), typeof(Robot_Control));


        public ICommand Disable_Command
        {
            get { return (ICommand)GetValue(Disable_CommandProperty); }
            set { SetValue(Disable_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Disable_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Disable_CommandProperty =
            DependencyProperty.Register("Disable_Command", typeof(ICommand), typeof(Robot_Control));




        public ICommand Origin_Command
        {
            get { return (ICommand)GetValue(Origin_CommandProperty); }
            set { SetValue(Origin_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Origin_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Origin_CommandProperty =
            DependencyProperty.Register("Origin_Command", typeof(ICommand), typeof(Robot_Control));



        public ICommand SetAccPointCommand
        {
            get { return (ICommand)GetValue(SetAccPointCommandProperty); }
            set { SetValue(SetAccPointCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetAccPointCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetAccPointCommandProperty =
            DependencyProperty.Register("SetAccPointCommand", typeof(ICommand), typeof(Robot_Control));



        public ICommand SetDecelPointCommand
        {
            get { return (ICommand)GetValue(SetDecelPointCommandProperty); }
            set { SetValue(SetDecelPointCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetDecelPointCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetDecelPointCommandProperty =
            DependencyProperty.Register("SetDecelPointCommand", typeof(ICommand), typeof(Robot_Control));



        public ICommand SetPointSpeedCommand
        {
            get { return (ICommand)GetValue(SetPointSpeedCommandProperty); }
            set { SetValue(SetPointSpeedCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetPointSpeedCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetPointSpeedCommandProperty =
            DependencyProperty.Register("SetPointSpeedCommand", typeof(ICommand), typeof(Robot_Control));



        #region Model


        public int CurrentPos
        {
            get { return (int)GetValue(CurrentPosProperty); }
            set { SetValue(CurrentPosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentPos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentPosProperty =
            DependencyProperty.Register("CurrentPos", typeof(int), typeof(Robot_Control), new PropertyMetadata(0));



        public int JogSpeed
        {
            get { return (int)GetValue(JogSpeedProperty); }
            set { SetValue(JogSpeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for JogSpeed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty JogSpeedProperty =
            DependencyProperty.Register("JogSpeed", typeof(int), typeof(Robot_Control), new PropertyMetadata(0));



        public int PosBath4
        {
            get { return (int)GetValue(PosBath4Property); }
            set { SetValue(PosBath4Property, value); }
        }

        // Using a DependencyProperty as the backing store for PosBath4.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PosBath4Property =
            DependencyProperty.Register("PosBath4", typeof(int), typeof(Robot_Control), new PropertyMetadata(0));



        public int PosBath5
        {
            get { return (int)GetValue(PosBath5Property); }
            set { SetValue(PosBath5Property, value); }
        }

        // Using a DependencyProperty as the backing store for PosBath5.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PosBath5Property =
            DependencyProperty.Register("PosBath5", typeof(int), typeof(Robot_Control), new PropertyMetadata(0));



        public int PosBath6
        {
            get { return (int)GetValue(PosBath6Property); }
            set { SetValue(PosBath6Property, value); }
        }

        // Using a DependencyProperty as the backing store for PosBath6.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PosBath6Property =
            DependencyProperty.Register("PosBath6", typeof(int), typeof(Robot_Control), new PropertyMetadata(0));



        public int AccPoint
        {
            get { return (int)GetValue(AccPointProperty); }
            set { SetValue(AccPointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AccPoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AccPointProperty =
            DependencyProperty.Register("AccPoint", typeof(int), typeof(Robot_Control), new PropertyMetadata(100));



        public int DecelPoint
        {
            get { return (int)GetValue(DecelPointProperty); }
            set { SetValue(DecelPointProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DecelPoint.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DecelPointProperty =
            DependencyProperty.Register("DecelPoint", typeof(int), typeof(Robot_Control), new PropertyMetadata(100));



        public int PointSpeed
        {
            get { return (int)GetValue(PointSpeedProperty); }
            set { SetValue(PointSpeedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PointSpeed.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PointSpeedProperty =
            DependencyProperty.Register("PointSpeed", typeof(int), typeof(Robot_Control), new PropertyMetadata(0));



        #endregion


        public Robot_Control()
        {
            InitializeComponent();
        }
    }
}
