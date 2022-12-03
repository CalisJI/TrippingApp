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
        public ICommand SetRobotJogSpeed_Command { get; set; }
        public ICommand SetLiftJogSpeed_Command { get; set; }
        public ICommand SetDataPointRobot_Command { get; set; }
        public ICommand SetDataPointLift_Command { get; set; }

        public ICommand RunFW_Input_Conveyor_Command { get; set; }
        public ICommand RunBW_Input_Conveyor_Command { get; set; }
        public ICommand RunFW_Output_Conveyor_Command { get; set; }
        public ICommand RunBW_Output_Conveyor_Command { get; set; }

        public ICommand Jog_FW_Robot_P_Command { get; set; }
        public ICommand Jog_FW_Robot_N_Command { get; set; }

        public ICommand Jog_BW_Robot_P_Command { get; set; }
        public ICommand Jog_BW_Robot_N_Command { get; set; }

        public ICommand Jog_BW_Lift_P_Command { get; set; }
        public ICommand Jog_BW_Lift_N_Command { get; set; }

        public ICommand Jog_FW_Lift_P_Command { get; set; }
        public ICommand Jog_FW_Lift_N_Command { get; set; }


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
