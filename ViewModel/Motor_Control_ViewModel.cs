using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrippingApp.ViewModel
{
    public class Motor_Control_ViewModel:BaseViewModel.BaseViewModel
    {
        #region Command of TF1
        public ICommand Set_Fre_Trigger_TF1_Command { get; set; }
        public ICommand Set_Dec_TF1_Command { get; set; }
        public ICommand Set_Acc_TF1_Command { get; set; }
        public ICommand Jog_CW_P_TF1_Command { get; set; }
        public ICommand Jog_CW_N_TF1_Command { get; set; }
        public ICommand Jog_CCW_P_TF1_Command { get; set; }
        public ICommand Jog_CCW_N_TF1_Command { get; set; }

        public ICommand Run_CW_P_TF1_Command { get; set; }
        public ICommand Run_CW_N_TF1_Command { get; set; }
        public ICommand Run_CCW_P_TF1_Command { get; set; }
        public ICommand Run_CCW_N_TF1_Command { get; set; }

        public ICommand Apply_Fre_TF1_Command { get; set; }
        public ICommand Apply_Acc_Dec_TF1_Command { get; set; }
        #endregion

        #region Command of TF2
        public ICommand Set_Fre_Trigger_TF2_Command { get; set; }
        public ICommand Set_Dec_TF2_Command { get; set; }
        public ICommand Set_Acc_TF2_Command { get; set; }
        public ICommand Jog_CW_P_TF2_Command { get; set; }
        public ICommand Jog_CW_N_TF2_Command { get; set; }
        public ICommand Jog_CCW_P_TF2_Command { get; set; }
        public ICommand Jog_CCW_N_TF2_Command { get; set; }

        public ICommand Run_CW_P_TF2_Command { get; set; }
        public ICommand Run_CW_N_TF2_Command { get; set; }
        public ICommand Run_CCW_P_TF2_Command { get; set; }
        public ICommand Run_CCW_N_TF2_Command { get; set; }

        public ICommand Apply_Fre_TF2_Command { get; set; }
        public ICommand Apply_Acc_Dec_TF2_Command { get; set; }
        #endregion

        #region Command of ML1
        public ICommand Set_Fre_Trigger_ML1_Command { get; set; }
        public ICommand Set_Dec_ML1_Command { get; set; }
        public ICommand Set_Acc_ML1_Command { get; set; }
        public ICommand Jog_CW_P_ML1_Command { get; set; }
        public ICommand Jog_CW_N_ML1_Command { get; set; }
        public ICommand Jog_CCW_P_ML1_Command { get; set; }
        public ICommand Jog_CCW_N_ML1_Command { get; set; }

        public ICommand Run_CW_P_ML1_Command { get; set; }
        public ICommand Run_CW_N_ML1_Command { get; set; }
        public ICommand Run_CCW_P_ML1_Command { get; set; }
        public ICommand Run_CCW_N_ML1_Command { get; set; }

        public ICommand Apply_Fre_ML1_Command { get; set; }
        public ICommand Apply_Acc_Dec_ML1_Command { get; set; }
        #endregion

        #region Command of ML2
        public ICommand Set_Fre_Trigger_ML2_Command { get; set; }
        public ICommand Set_Dec_ML2_Command { get; set; }
        public ICommand Set_Acc_ML2_Command { get; set; }
        public ICommand Jog_CW_P_ML2_Command { get; set; }
        public ICommand Jog_CW_N_ML2_Command { get; set; }
        public ICommand Jog_CCW_P_ML2_Command { get; set; }
        public ICommand Jog_CCW_N_ML2_Command { get; set; }

        public ICommand Run_CW_P_ML2_Command { get; set; }
        public ICommand Run_CW_N_ML2_Command { get; set; }
        public ICommand Run_CCW_P_ML2_Command { get; set; }
        public ICommand Run_CCW_N_ML2_Command { get; set; }

        public ICommand Apply_Fre_ML2_Command { get; set; }
        public ICommand Apply_Acc_Dec_ML2_Command { get; set; }
        #endregion
        #region Command of ML3
        public ICommand Set_Fre_Trigger_ML3_Command { get; set; }
        public ICommand Set_Dec_ML3_Command { get; set; }
        public ICommand Set_Acc_ML3_Command { get; set; }
        public ICommand Jog_CW_P_ML3_Command { get; set; }
        public ICommand Jog_CW_N_ML3_Command { get; set; }
        public ICommand Jog_CCW_P_ML3_Command { get; set; }
        public ICommand Jog_CCW_N_ML3_Command { get; set; }

        public ICommand Run_CW_P_ML3_Command { get; set; }
        public ICommand Run_CW_N_ML3_Command { get; set; }
        public ICommand Run_CCW_P_ML3_Command { get; set; }
        public ICommand Run_CCW_N_ML3_Command { get; set; }

        public ICommand Apply_Fre_ML3_Command { get; set; }
        public ICommand Apply_Acc_Dec_ML3_Command { get; set; }
        #endregion
        public Motor_Control_ViewModel()
        {

        }
    }
}
