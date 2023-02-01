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
    /// Interaction logic for Motor_Control.xaml
    /// </summary>
    public partial class Motor_Control : UserControl
    {


        public ICommand Set_Fre_Trigger_Command
        {
            get { return (ICommand)GetValue(Set_Fre_Trigger_CommandProperty); }
            set { SetValue(Set_Fre_Trigger_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_Fre_Trigger_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_Fre_Trigger_CommandProperty =
            DependencyProperty.Register("Set_Fre_Trigger_Command", typeof(ICommand), typeof(Motor_Control));





        public ICommand Set_Dec_Command
        {
            get { return (ICommand)GetValue(Set_Dec_CommandProperty); }
            set { SetValue(Set_Dec_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_Dec_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_Dec_CommandProperty =
            DependencyProperty.Register("Set_Dec_Command", typeof(ICommand), typeof(Motor_Control));



        public ICommand Set_Acc_Command
        {
            get { return (ICommand)GetValue(Set_Acc_CommandProperty); }
            set { SetValue(Set_Acc_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Set_Acc_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Set_Acc_CommandProperty =
            DependencyProperty.Register("Set_Acc_Command", typeof(ICommand), typeof(Motor_Control));




        public ICommand Jog_CW_P_Command
        {
            get { return (ICommand)GetValue(Jog_CW_P_CommandProperty); }
            set { SetValue(Jog_CW_P_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_CW_P_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_CW_P_CommandProperty =
            DependencyProperty.Register("Jog_CW_P_Command", typeof(ICommand), typeof(Motor_Control));



        public ICommand Jog_CW_N_Command
        {
            get { return (ICommand)GetValue(Jog_CW_N_CommandProperty); }
            set { SetValue(Jog_CW_N_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_CW_N_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_CW_N_CommandProperty =
            DependencyProperty.Register("Jog_CW_N_Command", typeof(ICommand), typeof(Motor_Control));




        public ICommand Jog_CCW_P_Command
        {
            get { return (ICommand)GetValue(Jog_CCW_P_CommandProperty); }
            set { SetValue(Jog_CCW_P_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_CCW_P_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_CCW_P_CommandProperty =
            DependencyProperty.Register("Jog_CCW_P_Command", typeof(ICommand), typeof(Motor_Control));



        public ICommand Jog_CCW_N_Commnand
        {
            get { return (ICommand)GetValue(Jog_CCW_N_CommnandProperty); }
            set { SetValue(Jog_CCW_N_CommnandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Jog_CCW_N_Commnand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Jog_CCW_N_CommnandProperty =
            DependencyProperty.Register("Jog_CCW_N_Commnand", typeof(ICommand), typeof(Motor_Control));




        public ICommand Run_CW_P_Command
        {
            get { return (ICommand)GetValue(Run_CW_P_CommandProperty); }
            set { SetValue(Run_CW_P_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Run_CW_P_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Run_CW_P_CommandProperty =
            DependencyProperty.Register("Run_CW_P_Command", typeof(ICommand), typeof(Motor_Control));



        public ICommand Run_CW_N_Command
        {
            get { return (ICommand)GetValue(Run_CW_N_CommandProperty); }
            set { SetValue(Run_CW_N_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Run_CW_N_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Run_CW_N_CommandProperty =
            DependencyProperty.Register("Run_CW_N_Command", typeof(ICommand), typeof(Motor_Control));




        public ICommand Run_CCW_P_Command
        {
            get { return (ICommand)GetValue(Run_CCW_P_CommandProperty); }
            set { SetValue(Run_CCW_P_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Run_CCW_P_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Run_CCW_P_CommandProperty =
            DependencyProperty.Register("Run_CCW_P_Command", typeof(ICommand), typeof(Motor_Control));



        public ICommand Run_CCW_N_Commnand
        {
            get { return (ICommand)GetValue(Run_CCW_N_CommnandProperty); }
            set { SetValue(Run_CCW_N_CommnandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Run_CCW_N_Commnand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Run_CCW_N_CommnandProperty =
            DependencyProperty.Register("Run_CCW_N_Commnand", typeof(ICommand), typeof(Motor_Control));



        public ICommand Apply_Fre_Command
        {
            get { return (ICommand)GetValue(Apply_Fre_CommandProperty); }
            set { SetValue(Apply_Fre_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Apply_Fre_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Apply_Fre_CommandProperty =
            DependencyProperty.Register("Apply_Fre_Command", typeof(ICommand), typeof(Motor_Control));



        public ICommand Apply_Acc_Dec_Command
        {
            get { return (ICommand)GetValue(Apply_Acc_Dec_CommandProperty); }
            set { SetValue(Apply_Acc_Dec_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Apply_Acc_Dec_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Apply_Acc_Dec_CommandProperty =
            DependencyProperty.Register("Apply_Acc_Dec_Command", typeof(ICommand), typeof(Motor_Control));


        #region Model Binding



        public int Frequency
        {
            get { return (int)GetValue(FrequencyProperty); }
            set { SetValue(FrequencyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Frequency.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrequencyProperty =
            DependencyProperty.Register("Frequency", typeof(int), typeof(Motor_Control), new FrameworkPropertyMetadata(0,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public float Acc_Time
        {
            get { return (float)GetValue(Acc_TimeProperty); }
            set { SetValue(Acc_TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Acc_Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Acc_TimeProperty =
            DependencyProperty.Register("Acc_Time", typeof(float), typeof(Motor_Control), new FrameworkPropertyMetadata(0.0f,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public float Decc_Time
        {
            get { return (float)GetValue(Decc_TimeProperty); }
            set { SetValue(Decc_TimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Decc_Time.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty Decc_TimeProperty =
            DependencyProperty.Register("Decc_Time", typeof(float), typeof(Motor_Control), new FrameworkPropertyMetadata(0.0f,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        #endregion

        public Motor_Control()
        {
            InitializeComponent();
        }
    }
}
