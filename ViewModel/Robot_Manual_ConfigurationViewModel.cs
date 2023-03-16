using Microsoft.Expression.Interactivity.Core;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using TrippingApp.Runtime;
using DateTime = System.DateTime;

namespace TrippingApp.ViewModel
{
    public class Robot_Manual_ConfigurationViewModel:BaseViewModel.BaseViewModel
    {
        DispatcherTimer timer = new DispatcherTimer();
        private BaseViewModel.BaseViewModel _cylinder_view;

        public BaseViewModel.BaseViewModel Cylinder_View
        {
            get { return _cylinder_view; }
            set { SetProperty(ref _cylinder_view, value, nameof(Cylinder_View)); }
        }
        private BaseViewModel.BaseViewModel _motor_Control;

        public BaseViewModel.BaseViewModel Motor_Control_View
        {
            get { return _motor_Control; }
            set { SetProperty(ref _motor_Control, value, nameof(Motor_Control_View)); }
        }


        private BaseViewModel.BaseViewModel _process_param_view;

        public BaseViewModel.BaseViewModel Process_Param_View
        {
            get { return _process_param_view; }
            set { SetProperty(ref _process_param_view, value, nameof(Process_Param_View)); }
        }

        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        public ICommand Camera_Connect { get; set; }

        public ICommand Changed_Page_Command { get; set; }
        /// <summary>
        /// Command To Set Up Parameter Of Servo
        /// </summary>
        #region Command To Set Up Parameter Of Servo
        public ICommand SetRobotJogSpeed_Command { get; set; }
        public ICommand SetLiftJogSpeed_Command { get; set; }
        public ICommand SetDataPointBath4Robot_Command { get; set; }
        public ICommand SetDataPointBath5Robot_Command { get; set; }
        public ICommand SetDataPointBath6Robot_Command { get; set; }

        public ICommand SetDataPointAbove_Lift_Command { get; set; }
        public ICommand SetDataPointBelow_Lift_Command { get; set; }
        public ICommand SetDataPointStart_Lift_Command { get; set; }


        #endregion
        /// <summary>
        /// Command Of Conveyor
        /// </summary>
        #region Command Of Conveyor
        public ICommand RunFW_Input_Conveyor_Command { get; set; }
        public ICommand RunBW_Input_Conveyor_Command { get; set; }
        public ICommand RunFW_Output_Conveyor_Command { get; set; }
        public ICommand RunBW_Output_Conveyor_Command { get; set; }
        #endregion

        /// <summary>
        /// Robot Commandation
        /// </summary>
        #region Command Of Robot
        public ICommand SetPointSpeedCommand { get; set; }
        public ICommand SetAccPointCommand { get; set; }
        public ICommand SetDeccelPointCommand { get; set; }
        public ICommand Origin_Robot_Command { get; set; }
        public ICommand Enable_Robot_Command { get; set; }
        public ICommand Disable_Robot_Command { get; set; }
        #endregion

        #region Model Of Robot
        private int _jog_robot_speed;

        public int Jog_Robot_Speed
        {
            get { return _jog_robot_speed; }
            set { SetProperty(ref _jog_robot_speed, value, nameof(Jog_Robot_Speed)); }
        }

        private int _posBath4;

        public int PosBath4
        {
            get { return _posBath4; }
            set { SetProperty(ref _posBath4, value, nameof(PosBath4)); }
        }
        private int _posBath5;

        public int PosBath5
        {
            get { return _posBath5; }
            set { SetProperty(ref _posBath5,value,nameof(PosBath5)); }
        }
        private int _posBath6;

        public int PosBath6
        {
            get { return _posBath6; }
            set { SetProperty(ref _posBath6,value,nameof(PosBath6)); }
        }
        private int _currentPos;

        public int CurrentPos
        {
            get { return _currentPos; }
            set { SetProperty(ref _currentPos, value, nameof(CurrentPos)); }
        }

        private int _pointSpeed;

        public int PointSpeed
        {
            get { return _pointSpeed; }
            set { SetProperty(ref _pointSpeed, value, nameof(PointSpeed)); }
        }

        private int _accpoint;

        public int Accel_Point
        {
            get { return _accpoint; }
            set { SetProperty(ref _accpoint, value, nameof(Accel_Point)); }
        }

        private int _deccelpoint;

        public int DeccelPoint
        {
            get { return _deccelpoint; }
            set { SetProperty(ref _deccelpoint, value, nameof(DeccelPoint)); }
        }

        #endregion

        #region Model Of Lift

        private int _lift_point_speed;

        public int Lift_Point_Speed
        {
            get { return _lift_point_speed; }
            set { SetProperty(ref _lift_point_speed, value, nameof(Lift_Point_Speed)); }
        }

        private int _acclift_point;

        public int AccLifftPoint
        {
            get { return _acclift_point; }
            set { SetProperty(ref _acclift_point, value, nameof(AccLifftPoint)); }
        }

        private int _decel_Lift_point;

        public int DecLiftPoint
        {
            get { return _decel_Lift_point; }
            set { SetProperty(ref _decel_Lift_point, value, nameof(DecLiftPoint)); }
        }

        private int _current_pos;

        public int CurrentPos_Lift
        {
            get { return _current_pos; }
            set { SetProperty(ref _current_pos, value, nameof(CurrentPos_Lift)); }
        }

        private int _position_above;

        public int Position_Above
        {
            get { return _position_above; }
            set { SetProperty(ref _position_above, value, nameof(Position_Above)); }
        }

        private int _position_below;

        public int Position_Below
        {
            get { return _position_below; }
            set { SetProperty(ref _position_below, value, nameof(Position_Below)); }
        }

        private int _position_start;

        public int Position_Start
        {
            get { return _position_start; }
            set { SetProperty(ref _position_start, value, nameof(Position_Start)); }
        }
        private int _jog_lift_speed;

        public int Jog_Lift_Speed
        {
            get { return _jog_lift_speed; }
            set { SetProperty(ref _jog_lift_speed, value, nameof(Jog_Lift_Speed)); }
        }

        #endregion
        /// <summary>
        /// Lift Commandation
        /// </summary>
        #region Command Of Lift
        //public ICommand Jog_BW_Lift_P_Command { get; set; }
        //public ICommand Jog_BW_Lift_N_Command { get; set; }

        //public ICommand Jog_FW_Lift_P_Command { get; set; }
        //public ICommand Jog_FW_Lift_N_Command { get; set; }
        public ICommand SetPointSpeed_Lift_Command { get; set; }
        public ICommand SetAccLift_Point_Command { get; set; }
        public ICommand SetDecLift_Point_Command { get; set; }

        public ICommand Origin_Lift_Command { get; set; }

        public ICommand Enable_Lift_Command { get; set; }

        public ICommand Disable_Lift_Command { get; set; }
        #endregion


        /// <summary>
        /// All Commandation of Xy Lanh
        /// </summary>
        #region Command Control Manual Xy Lanh
        public ICommand Up_XL_Lift_Input_Command { get; set; }
        public ICommand Down_XL_Lift_Input_Command { get; set; }

        public ICommand Up_XL_Lift_1_Command { get; set; }
        public ICommand Down_XL_Lift_1_Command { get; set; }

        public ICommand Up_XL_Lift_2_Command { get; set; }
        public ICommand Down_XL_Lift_2_Command { get; set; }

        public ICommand Up_XL_Lift_3_Command { get; set; }
        public ICommand Down_XL_Lift_3_Command { get; set; }

        public ICommand Up_XL_Lift_4_Command { get; set; }
        public ICommand Down_XL_Lift_4_Command { get; set; }

        public ICommand Up_XL_Lift_5_Command { get; set; }
        public ICommand Down_XL_Lift_5_Command { get; set; }

        public ICommand Up_XL_Lift_Output_Command { get; set; }
        public ICommand Down_XL_Lift_Output_Command { get; set; }


        public ICommand Up_XL_Robot_Command { get; set; }
        public ICommand Down_XL_Robot_Command { get; set; }

        public ICommand Close_XL_Robot_Command { get; set; }
        public ICommand Open_XL_Robot_Command { get; set; }



        #endregion

        private Cylinder_Control_ViewModel Cylinder_Control_ViewModel = new Cylinder_Control_ViewModel();
        private Motor_Control_ViewModel Motor_Control_ViewModel = new Motor_Control_ViewModel();
        private Parameter_Process_ViewModel Parameter_Process_ViewModel = new Parameter_Process_ViewModel();
        private Manual_ViewModel Manual_ViewModel = new Manual_ViewModel();

        public Robot_Manual_ConfigurationViewModel()
        {
            //this.Motor_Control_View = Motor_Control_ViewModel;
            this.Process_Param_View = Parameter_Process_ViewModel;
            this.Cylinder_View = Manual_ViewModel;
            Loaded = new ActionCommand(() =>
            {
                if (PLC_Query.Connected) 
                {
                    PLC_Query.ReadData(PLC_Query.SETTING_DATA, 2);
                    PLC_Query.ReadData(PLC_Query.ROBOT_PARAM, 14);
                    Accel_Point = PLC_Query.SETTING_DATA.Robot_Point_Accel;
                    DeccelPoint = PLC_Query.SETTING_DATA.Robot_Point_Decel;
                    PointSpeed = PLC_Query.SETTING_DATA.Robot_Point_Speed;
                    Jog_Robot_Speed = PLC_Query.ROBOT_PARAM.JOG_X_SPEED;
                    Jog_Lift_Speed = PLC_Query.ROBOT_PARAM.JOG_LIFT_SPEED;

                    PosBath4 = PLC_Query.ROBOT_PARAM.AxisRobot_Position_1;
                    PosBath5 = PLC_Query.ROBOT_PARAM.AxisRobot_Position_2;
                    PosBath6 = PLC_Query.ROBOT_PARAM.AxisRobot_Position_3;


                    AccLifftPoint = PLC_Query.SETTING_DATA.Lift_Point_Accel;
                    DecLiftPoint = PLC_Query.SETTING_DATA.Lift_Point_Decel;
                    Lift_Point_Speed = PLC_Query.SETTING_DATA.Lift_Point_Speed;

                    Position_Start = PLC_Query.ROBOT_PARAM.AxisLift_Position_Start;
                    Position_Above = PLC_Query.ROBOT_PARAM.AxisLift_Position_1;
                    Position_Below = PLC_Query.ROBOT_PARAM.AxisLift_Position_2;

                    PLC_Query.WriteBit(AddressCrt.Sync_Position, true);
                    timer.Interval = new TimeSpan(500);
                    timer.Tick += Timer_Tick;
                    if (timer.IsEnabled == false)
                    {
                        timer.Start();
                    }
                }
                //timer.Interval = new TimeSpan(100);
                //timer.Tick += Timer_Tick;
                //if (timer.IsEnabled == false) 
                //{
                //    timer.Start();
                //}
                //try
                //{
                //    PLC_Query.Initial("192.168.0.101");
                //}
                //catch (Exception ex)
                //{

                //    Console.WriteLine(ex.Message);
                //}

                //TestST testST = new TestST();
                //Barcode_1 barcode_1 = new Barcode_1() 
                //{

                //};
                //try
                //{
                //    PLC_Query.ReadData(barcode_1, 8);

                //    var a = Regex.Replace(Encoding.ASCII.GetString(barcode_1.Barcode_P1, 0, barcode_1.Barcode_P1.Length), @"(@|/h|&|'|\(|\)|<|>|#|\?|\\|\0|\u0000|\u0001|\u0002|\u0003|\u0004|\u0005|\u0006|\n)", "");
                //    var b = Regex.Replace(Encoding.UTF8.GetString(barcode_1.Barcode_P2, 0, barcode_1.Barcode_P2.Length), @"(@|/h|&|'|\(|\)|<|>|#|\?|\\|\0|\u0000|\u0001|\u0002|\u0003|\u0004|\u0005|\u0006|\n)", "");

                //    //string ad = S7String.FromByteArray(barcode_1.Barcode_P5);
                //    Console.WriteLine(a);
                //    Console.WriteLine(b);

                //    barcode_1.Barcode_P3 = S7String.ToByteArray("HY-001", 10);
                //    barcode_1.Barcode_P4 = S7String.ToByteArray("2", 1);
                //    PLC_Query.WriteData(barcode_1, 8);
                //}
                //catch (Exception ex)
                //{

                //}
            });
           
            Unloaded = new ActionCommand(() =>
            {
                if (timer.IsEnabled) timer.Stop();
                timer.Tick -= Timer_Tick;
            });
            Changed_Page_Command = new ActionCommand((p) =>
            {
                //if ((int)p==1)
                //{
                //    this.Cylinder_View = Cylinder_Control_ViewModel.Value;
                //}
            });
           
            Origin_Robot_Command = new ActionCommand(() =>
            {
                try
                {
                    //PLC_Query.WriteData(AddressCrt.SELECT_AXIS_HOME, 1);
                    PLC_Query.WriteBit(AddressCrt.Manual_Home_Robot, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            });
            Enable_Robot_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.WriteBit(AddressCrt.OnRobot, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            });
            Disable_Robot_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.WriteBit(AddressCrt.OffRobot, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            });
            SetRobotJogSpeed_Command = new ActionCommand((p) =>
            {
                try
                {
                    PLC_Query.WriteData(AddressCrt.Jog_X_SPEED, (short)Jog_Robot_Speed);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
                
            });
            SetDataPointBath4Robot_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.SETTING_DATA.Point_to_Set = 2;
                    PLC_Query.SETTING_DATA.Point_Data = (short)PosBath4;
                    PLC_Query.SETTING_DATA.Robot_Point_Accel = (short)Accel_Point;
                    PLC_Query.SETTING_DATA.Robot_Point_Decel = (short)DeccelPoint;
                    PLC_Query.SETTING_DATA.Robot_Point_Speed = (short)PointSpeed;
                    PLC_Query.WriteData(AddressCrt.AxisRobot_Position_1,(short) PosBath4);
                    PLC_Query.Write_Setting_DataPoint();
                    PLC_Query.WriteBit(AddressCrt.WRITE_DATA_POINT_X, true);
                    
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            });
            SetDataPointBath5Robot_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.SETTING_DATA.Point_to_Set = 3;
                    PLC_Query.SETTING_DATA.Point_Data = (short)PosBath5;
                    PLC_Query.SETTING_DATA.Robot_Point_Accel = (short)Accel_Point;
                    PLC_Query.SETTING_DATA.Robot_Point_Decel = (short)DeccelPoint;
                    PLC_Query.SETTING_DATA.Robot_Point_Speed = (short)PointSpeed;
                    PLC_Query.WriteData(AddressCrt.AxisRobot_Position_2, (short)PosBath5);
                    PLC_Query.Write_Setting_DataPoint();
                    PLC_Query.WriteBit(AddressCrt.WRITE_DATA_POINT_X, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            });
            SetDataPointBath6Robot_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.SETTING_DATA.Point_to_Set = 4;
                    PLC_Query.SETTING_DATA.Point_Data = (short)PosBath6;
                    PLC_Query.SETTING_DATA.Robot_Point_Accel = (short)Accel_Point;
                    PLC_Query.SETTING_DATA.Robot_Point_Decel = (short)DeccelPoint;
                    PLC_Query.SETTING_DATA.Robot_Point_Speed = (short)PointSpeed;
                    PLC_Query.WriteData(AddressCrt.AxisRobot_Position_3, (short)PosBath6);
                    PLC_Query.Write_Setting_DataPoint();
                    PLC_Query.WriteBit(AddressCrt.WRITE_DATA_POINT_X, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            });
            
            Origin_Lift_Command = new ActionCommand(() =>
            {
                try
                {
                    //PLC_Query.WriteData(AddressCrt.SELECT_AXIS_HOME, 2);
                    PLC_Query.WriteBit(AddressCrt.Manual_Home_Lift, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            });
            Enable_Lift_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.WriteBit(AddressCrt.OnLift, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            });
            Disable_Lift_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.WriteBit(AddressCrt.OffLift, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            });

            SetLiftJogSpeed_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.WriteData(AddressCrt.Jog_Lift_SPEED, (short)Jog_Lift_Speed);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            });

            SetDataPointAbove_Lift_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.SETTING_DATA.Point_to_Set = 2;
                    PLC_Query.SETTING_DATA.Point_Data = (short)Position_Above;
                    PLC_Query.SETTING_DATA.Lift_Point_Accel = (short)AccLifftPoint;
                    PLC_Query.SETTING_DATA.Lift_Point_Decel = (short)DecLiftPoint;
                    PLC_Query.SETTING_DATA.Lift_Point_Speed = (short)Lift_Point_Speed;
                    PLC_Query.WriteData(AddressCrt.AxisLift_Position_1, (short)Position_Above);
                    PLC_Query.Write_Setting_DataPoint();
                    PLC_Query.WriteBit(AddressCrt.WRITE_DATA_POINT_LIFT, true);

                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            });

            SetDataPointBelow_Lift_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.SETTING_DATA.Point_to_Set = 3;
                    PLC_Query.SETTING_DATA.Point_Data = (short)Position_Below;
                    PLC_Query.SETTING_DATA.Lift_Point_Accel = (short)AccLifftPoint;
                    PLC_Query.SETTING_DATA.Lift_Point_Decel = (short)DecLiftPoint;
                    PLC_Query.SETTING_DATA.Lift_Point_Speed = (short)Lift_Point_Speed;
                    PLC_Query.WriteData(AddressCrt.AxisLift_Position_2, (short)Position_Below);
                    PLC_Query.Write_Setting_DataPoint();
                    PLC_Query.WriteBit(AddressCrt.WRITE_DATA_POINT_LIFT, true);

                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            });

            SetDataPointStart_Lift_Command = new ActionCommand(() =>
            {
                try
                {
                    PLC_Query.SETTING_DATA.Point_to_Set = 1;
                    PLC_Query.SETTING_DATA.Point_Data = (short)Position_Start;
                    PLC_Query.SETTING_DATA.Lift_Point_Accel = (short)AccLifftPoint;
                    PLC_Query.SETTING_DATA.Lift_Point_Decel = (short)DecLiftPoint;
                    PLC_Query.SETTING_DATA.Lift_Point_Speed = (short)Lift_Point_Speed;
                    PLC_Query.WriteData(AddressCrt.AxisLift_Position_Start,(short)Position_Start);
                    PLC_Query.Write_Setting_DataPoint();
                    PLC_Query.WriteBit(AddressCrt.WRITE_DATA_POINT_LIFT, true);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            });

            SetPointSpeed_Lift_Command = new ActionCommand(() =>
            {
            
            });
            SetAccLift_Point_Command = new ActionCommand(() =>
            {
            
            });

            SetDecLift_Point_Command = new ActionCommand(() => 
            {
            
            });
            //Jog_FW_Lift_P_Command = new ActionCommand(() => 
            //{
            //    try
            //    {
            //        PLC_Query.WriteBit(AddressCrt.Manual_Jog_FW_Lift, true);
            //    }
            //    catch (Exception ex)
            //    {
            //        _ = Logger.Logger.Async_write(ex.Message);
            //    }
            //});
            //Jog_FW_Lift_N_Command = new ActionCommand(() =>
            //{
            //    try
            //    {
            //        PLC_Query.WriteBit(AddressCrt.Manual_Jog_FW_Lift, false);
            //    }
            //    catch (Exception ex)
            //    {
            //        _ = Logger.Logger.Async_write(ex.Message);
            //    }
            //});
            //Jog_BW_Lift_P_Command = new ActionCommand(() =>
            //{
            //    try
            //    {
            //        PLC_Query.WriteBit(AddressCrt.Manual_Jog_BW_Lift, true);
            //    }
            //    catch (Exception ex)
            //    {
            //        _ = Logger.Logger.Async_write(ex.Message);
            //    }
            //});
            //Jog_BW_Lift_N_Command = new ActionCommand(() =>
            //{
            //    try
            //    {
            //        PLC_Query.WriteBit(AddressCrt.Manual_Jog_BW_Lift, false);
            //    }
            //    catch (Exception ex)
            //    {
            //        _ = Logger.Logger.Async_write(ex.Message);
            //    }
            //});
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            try
            {
                object a = PLC_Query.ReadData(AddressCrt.Current_Position_X);
                CurrentPos = Convert.ToInt16(a);
                object b = PLC_Query.ReadData(AddressCrt.Current_Position_Lift);
                CurrentPos_Lift = Convert.ToInt16(b);
            }
            catch (Exception ex)
            {
                
            }
        }
    }
}
