using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrippingApp.ViewModel
{
    public class Robot_Manual_ConfigurationViewModel:BaseViewModel.BaseViewModel
    {

        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        /// <summary>
        /// Command To Set Up Parameter Of Servo
        /// </summary>
        #region Command To Set Up Parameter Of Servo
        public ICommand SetRobotJogSpeed_Command { get; set; }
        public ICommand SetLiftJogSpeed_Command { get; set; }
        public ICommand SetDataPointBath4Robot_Command { get; set; }
        public ICommand SetDataPointBath5Robot_Command { get; set; }
        public ICommand SetDataPointBath6Robot_Command { get; set; }
        public ICommand SetDataPointLift_Command { get; set; }

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
        public ICommand Jog_FW_Robot_P_Command { get; set; }
        public ICommand Jog_FW_Robot_N_Command { get; set; }

        public ICommand Jog_BW_Robot_P_Command { get; set; }
        public ICommand Jog_BW_Robot_N_Command { get; set; }

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

        #endregion
        /// <summary>
        /// Lift Commandation
        /// </summary>
        #region Command Of Lift
        public ICommand Jog_BW_Lift_P_Command { get; set; }
        public ICommand Jog_BW_Lift_N_Command { get; set; }

        public ICommand Jog_FW_Lift_P_Command { get; set; }
        public ICommand Jog_FW_Lift_N_Command { get; set; }

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
        public Robot_Manual_ConfigurationViewModel()
        {
            Loaded = new ActionCommand(() =>
            {
            
            });

            Unloaded = new ActionCommand(() =>
            {
            
            });

            
        }
    }
}
