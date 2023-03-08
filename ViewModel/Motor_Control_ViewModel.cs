using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrippingApp.Runtime;

namespace TrippingApp.ViewModel
{
    public class Motor_Control_ViewModel : BaseViewModel.BaseViewModel
    {
        #region Command of TF1
        public ICommand Set_Fre_Trigger_TF1_Command { get; set; }
        public ICommand Set_Dec_Acc_TF1_Command { get; set; }
        public ICommand Jog_CW_P_TF1_Command { get; set; }
        public ICommand Jog_CW_N_TF1_Command { get; set; }
        public ICommand Jog_CCW_P_TF1_Command { get; set; }
        public ICommand Jog_CCW_N_TF1_Command { get; set; }

        public ICommand Run_CW_P_TF1_Command { get; set; }
        public ICommand Run_CW_N_TF1_Command { get; set; }
        public ICommand Run_CCW_P_TF1_Command { get; set; }
        public ICommand Run_CCW_N_TF1_Command { get; set; }

        public ICommand CVIN_IN_P_Command { get; set; }
        public ICommand CVIN_IN_N_Command { get; set; }

        public ICommand CVIN_Out_P_Command { get; set; }
        public ICommand CVIN_Out_N_Command { get; set; }

        public ICommand CVIN_Initial_Command { get; set; }

        public ICommand CVOut_IN_P_Command { get; set; }
        public ICommand CVOut_IN_N_Command { get; set; }

        public ICommand CVOut_Out_P_Command { get; set; }
        public ICommand CVOut_Out_N_Command { get; set; }

        public ICommand CVOut_Initial_Command { get; set; }
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        #endregion
        #region Model TF 1
        private int _frequency1;

        public int Frequency1
        {
            get { return _frequency1; }
            set { SetProperty(ref _frequency1, value, nameof(Frequency1)); }
        }

        private float _dec_time1;

        public float Dec_Time1
        {
            get { return _dec_time1; }
            set { SetProperty(ref _dec_time1, value, nameof(Dec_Time1)); }
        }

        private float _acc_time1;

        public float Acc_Time1
        {
            get { return _acc_time1; }
            set { SetProperty(ref _acc_time1, value, nameof(Acc_Time1)); }
        }

        #endregion

        #region Command of TF2
        public ICommand Set_Fre_Trigger_TF2_Command { get; set; }
        public ICommand Set_Dec_Acc_TF2_Command { get; set; }
        public ICommand Jog_CW_P_TF2_Command { get; set; }
        public ICommand Jog_CW_N_TF2_Command { get; set; }
        public ICommand Jog_CCW_P_TF2_Command { get; set; }
        public ICommand Jog_CCW_N_TF2_Command { get; set; }

        public ICommand Run_CW_P_TF2_Command { get; set; }
        public ICommand Run_CW_N_TF2_Command { get; set; }
        public ICommand Run_CCW_P_TF2_Command { get; set; }
        public ICommand Run_CCW_N_TF2_Command { get; set; }

        #endregion
        #region Model TF 2
        private int _frequency2;

        public int Frequency2
        {
            get { return _frequency2; }
            set { SetProperty(ref _frequency2, value, nameof(Frequency2)); }
        }

        private float _dec_time2;

        public float Dec_Time2
        {
            get { return _dec_time2; }
            set { SetProperty(ref _dec_time2, value, nameof(Dec_Time2)); }
        }

        private float _acc_time2;

        public float Acc_Time2
        {
            get { return _acc_time2; }
            set { SetProperty(ref _acc_time2, value, nameof(Acc_Time2)); }
        }

        #endregion

        #region Command of ML1
        public ICommand Set_Fre_Trigger_ML1_Command { get; set; }
        public ICommand Set_Dec_Acc_ML1_Command { get; set; }
        public ICommand Jog_CW_P_ML1_Command { get; set; }
        public ICommand Jog_CW_N_ML1_Command { get; set; }
        public ICommand Jog_CCW_P_ML1_Command { get; set; }
        public ICommand Jog_CCW_N_ML1_Command { get; set; }

        public ICommand Run_CW_P_ML1_Command { get; set; }
        public ICommand Run_CW_N_ML1_Command { get; set; }
        public ICommand Run_CCW_P_ML1_Command { get; set; }
        public ICommand Run_CCW_N_ML1_Command { get; set; }
        #endregion
        #region Model ML 1
        private int _frequency3;

        public int Frequency3
        {
            get { return _frequency3; }
            set { SetProperty(ref _frequency3, value, nameof(Frequency3)); }
        }

        private float _dec_time3;

        public float Dec_Time3
        {
            get { return _dec_time3; }
            set { SetProperty(ref _dec_time3, value, nameof(Dec_Time3)); }
        }

        private float _acc_time3;

        public float Acc_Time3
        {
            get { return _acc_time3; }
            set { SetProperty(ref _acc_time3, value, nameof(Acc_Time3)); }
        }
        #endregion

        #region Command of ML2
        public ICommand Set_Fre_Trigger_ML2_Command { get; set; }
        public ICommand Set_Dec_Acc_ML2_Command { get; set; }
        public ICommand Jog_CW_P_ML2_Command { get; set; }
        public ICommand Jog_CW_N_ML2_Command { get; set; }
        public ICommand Jog_CCW_P_ML2_Command { get; set; }
        public ICommand Jog_CCW_N_ML2_Command { get; set; }

        public ICommand Run_CW_P_ML2_Command { get; set; }
        public ICommand Run_CW_N_ML2_Command { get; set; }
        public ICommand Run_CCW_P_ML2_Command { get; set; }
        public ICommand Run_CCW_N_ML2_Command { get; set; }

        #endregion
        #region Model ML 2
        private int _frequency4;

        public int Frequency4
        {
            get { return _frequency4; }
            set { SetProperty(ref _frequency4, value, nameof(Frequency4)); }
        }

        private float _dec_time4;

        public float Dec_Time4
        {
            get { return _dec_time4; }
            set { SetProperty(ref _dec_time4, value, nameof(Dec_Time4)); }
        }

        private float _acc_time4;

        public float Acc_Time4
        {
            get { return _acc_time4; }
            set { SetProperty(ref _acc_time4, value, nameof(Acc_Time4)); }
        }

        #endregion

        #region Command of ML3
        public ICommand Set_Fre_Trigger_ML3_Command { get; set; }
        public ICommand Set_Dec_Acc_ML3_Command { get; set; }
        public ICommand Jog_CW_P_ML3_Command { get; set; }
        public ICommand Jog_CW_N_ML3_Command { get; set; }
        public ICommand Jog_CCW_P_ML3_Command { get; set; }
        public ICommand Jog_CCW_N_ML3_Command { get; set; }

        public ICommand Run_CW_P_ML3_Command { get; set; }
        public ICommand Run_CW_N_ML3_Command { get; set; }
        public ICommand Run_CCW_P_ML3_Command { get; set; }
        public ICommand Run_CCW_N_ML3_Command { get; set; }
        #endregion
        #region Model ML 3
        private int _frequency5;

        public int Frequency5
        {
            get { return _frequency5; }
            set { SetProperty(ref _frequency5, value, nameof(Frequency5)); }
        }

        private float _dec_time5;

        public float Dec_Time5
        {
            get { return _dec_time5; }
            set { SetProperty(ref _dec_time5, value, nameof(Dec_Time5)); }
        }

        private float _acc_time5;

        public float Acc_Time5
        {
            get { return _acc_time5; }
            set { SetProperty(ref _acc_time5, value, nameof(Acc_Time5)); }
        }
        #endregion
        public Motor_Control_ViewModel()
        {
            CVIN_Initial_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Init_Input_Conveyor, true);
            });
            CVOut_Initial_Command = new ActionCommand(() => 
            {
                PLC_Query.WriteBit(AddressCrt.Init_Output_Conveyor, true);
            });

            CVIN_IN_P_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_FW_Input_Conveyor, true);
            });

            CVIN_IN_N_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_FW_Input_Conveyor, false);
            });

            CVIN_Out_P_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_BW_Input_Convetor, true);
            });
            CVIN_Out_N_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_BW_Input_Convetor, false);
            });


            CVOut_IN_P_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_FW_Output_Conveyor, true);
            });
            CVOut_IN_N_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_FW_Output_Conveyor, false);
            });

            CVOut_Out_P_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_BW_Output_Conveyor, true);
            });
            CVOut_Out_N_Command = new ActionCommand(() =>
            {
                PLC_Query.WriteBit(AddressCrt.Run_BW_Output_Conveyor, false);
            });
            Loaded = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.ReadData(PLC_Query.SYSTEM_DATA_RETAIN, 10);
                    Frequency1 = (int)PLC_Query.SYSTEM_DATA_RETAIN.Tranfer_Frequency;
                    Acc_Time1 = PLC_Query.SYSTEM_DATA_RETAIN.Accel_Tranfer * 100;
                    Dec_Time1 = PLC_Query.SYSTEM_DATA_RETAIN.Decel_Tranfer * 100;

                    Frequency2 = (int)PLC_Query.SYSTEM_DATA_RETAIN.Tranfer_Frequency;
                    Acc_Time2 = PLC_Query.SYSTEM_DATA_RETAIN.Accel_Tranfer * 100;
                    Dec_Time2 = PLC_Query.SYSTEM_DATA_RETAIN.Decel_Tranfer * 100;


                    Frequency3 = (int)PLC_Query.SYSTEM_DATA_RETAIN.Dip_Frequency;
                    Acc_Time3 = PLC_Query.SYSTEM_DATA_RETAIN.Accel_Dip * 100;
                    Dec_Time3 = PLC_Query.SYSTEM_DATA_RETAIN.Decel_Dip * 100;

                    Frequency4 = (int)PLC_Query.SYSTEM_DATA_RETAIN.Dip_Frequency;
                    Acc_Time4 = PLC_Query.SYSTEM_DATA_RETAIN.Accel_Dip * 100;
                    Dec_Time4 = PLC_Query.SYSTEM_DATA_RETAIN.Decel_Dip * 100;

                    Frequency5 = (int)PLC_Query.SYSTEM_DATA_RETAIN.Dip_Frequency;
                    Acc_Time5 = PLC_Query.SYSTEM_DATA_RETAIN.Accel_Dip * 100;
                    Dec_Time5 = PLC_Query.SYSTEM_DATA_RETAIN.Decel_Dip * 100;
                }
            });

            Unloaded = new ActionCommand(() =>
            {

            });



            // Tranfer 1
            #region Run Command
            Run_CW_P_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_TF1, true);
                }
            });
            Run_CW_N_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_TF1, false);
                }
            });
            Run_CCW_P_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_TF1, true);
                }
            });
            Run_CCW_N_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_TF1, false);
                }
            });
            #endregion



            #region Set Param
            Set_Dec_Acc_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Accel_Tranfer = Acc_Time1 / 100f;
                    PLC_Query.SYSTEM_DATA_RETAIN.Decel_Tranfer = Dec_Time1 / 100f;
                    PLC_Query.WriteBit(AddressCrt.Set_AccDec_Tranfer, true);
                }
            });
            Set_Fre_Trigger_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Tranfer_Frequency = Frequency1;
                    PLC_Query.WriteBit(AddressCrt.Set_Frequency_Tranfer, true);
                }
            });
            #endregion

            #region Jog Command
            Jog_CW_P_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_TF1, true);
                }
            });
            Jog_CW_N_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_TF1, false);
                }
            });
            Jog_CCW_P_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_TF1, true);
                }
            });
            Jog_CCW_N_TF1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_TF1, false);
                }
            });
            #endregion


            // Tranfer 2
            #region Run Command
            Run_CW_P_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_TF2, true);
                }
            });
            Run_CW_N_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_TF2, false);
                }
            });
            Run_CCW_P_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_TF2, true);
                }
            });
            Run_CCW_N_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_TF2, false);
                }
            });
            #endregion



            #region Set Param
            Set_Dec_Acc_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Accel_Tranfer = Acc_Time1 / 100f;
                    PLC_Query.SYSTEM_DATA_RETAIN.Decel_Tranfer = Dec_Time1 / 100f;
                    PLC_Query.WriteBit(AddressCrt.Set_AccDec_Tranfer, true);
                }
            });
            Set_Fre_Trigger_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Tranfer_Frequency = Frequency1;
                    PLC_Query.WriteBit(AddressCrt.Set_Frequency_Tranfer, true);
                }
            });
            #endregion

            #region Jog Command
            Jog_CW_P_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_TF2, true);
                }
            });
            Jog_CW_N_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_TF2, false);
                }
            });
            Jog_CCW_P_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_TF2, true);
                }
            });
            Jog_CCW_N_TF2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_TF2, false);
                }
            });
            #endregion


            // ML 1
            #region Run Command
            Run_CW_P_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_Lift1, true);
                }
            });
            Run_CW_N_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_Lift1, false);
                }
            });
            Run_CCW_P_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_Lift1, true);
                }
            });
            Run_CCW_N_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_Lift1, false);
                }
            });
            #endregion


            #region Set Param
            Set_Dec_Acc_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Accel_Dip = Acc_Time3 / 100f;
                    PLC_Query.SYSTEM_DATA_RETAIN.Decel_Dip = Dec_Time3 / 100f;
                    PLC_Query.WriteBit(AddressCrt.Set_AccDec_Motor_lift, true);
                }
            });
            Set_Fre_Trigger_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Dip_Frequency = Frequency3;
                    PLC_Query.WriteBit(AddressCrt.Set_Frequency_Motor_lift, true);
                }
            });
            #endregion

            #region Jog Command
            Jog_CW_P_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_Lift1, true);
                }
            });
            Jog_CW_N_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_Lift1, false);
                }
            });
            Jog_CCW_P_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_Lift1, true);
                }
            });
            Jog_CCW_N_ML1_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_Lift1, false);
                }
            });
            #endregion


            // ML 2
            #region Run Command
            Run_CW_P_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_Lift2, true);
                }
            });
            Run_CW_N_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_Lift2, false);
                }
            });
            Run_CCW_P_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_Lift2, true);
                }
            });
            Run_CCW_N_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_Lift2, false);
                }
            });
            #endregion


            #region Set Param
            Set_Dec_Acc_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Accel_Dip = Acc_Time3 / 100f;
                    PLC_Query.SYSTEM_DATA_RETAIN.Decel_Dip = Dec_Time3 / 100f;
                    PLC_Query.WriteBit(AddressCrt.Set_AccDec_Motor_lift, true);
                }
            });
            Set_Fre_Trigger_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Dip_Frequency = Frequency3;
                    PLC_Query.WriteBit(AddressCrt.Set_Frequency_Motor_lift, true);
                }
            });
            #endregion

            #region Jog Command
            Jog_CW_P_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_Lift2, true);
                }
            });
            Jog_CW_N_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_Lift2, false);
                }
            });
            Jog_CCW_P_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_Lift2, true);
                }
            });
            Jog_CCW_N_ML2_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_Lift2, false);
                }
            });
            #endregion


            // ML 3
            #region Run Command
            Run_CW_P_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_Lift3, true);
                }
            });
            Run_CW_N_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_FW_Lift3, false);
                }
            });
            Run_CCW_P_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_Lift3, true);
                }

            });
            Run_CCW_N_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Run_BW_Lift3, false);
                }
            });
            #endregion


            #region Set Param
            Set_Dec_Acc_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Accel_Dip = Acc_Time3 / 100f;
                    PLC_Query.SYSTEM_DATA_RETAIN.Decel_Dip = Dec_Time3 / 100f;
                    PLC_Query.WriteBit(AddressCrt.Set_AccDec_Motor_lift, true);
                }
            });
            Set_Fre_Trigger_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.SYSTEM_DATA_RETAIN.Dip_Frequency = Frequency3;
                    PLC_Query.WriteBit(AddressCrt.Set_Frequency_Motor_lift, true);
                }
            });
            #endregion

            #region Jog Command
            Jog_CW_P_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_Lift3, true);
                }
            });
            Jog_CW_N_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_FW_Lift3, false);
                }
            });
            Jog_CCW_P_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_Lift3, true);
                }
            });
            Jog_CCW_N_ML3_Command = new ActionCommand(() =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.WriteBit(AddressCrt.Jog_BW_Lift3, false);
                }
            });
            #endregion
        }
    }
}
