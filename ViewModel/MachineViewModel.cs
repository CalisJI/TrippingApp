using Microsoft.Expression.Interactivity.Core;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Threading;
using TrippingApp.APIController;
using TrippingApp.Runtime;
using DateTime = System.DateTime;

namespace TrippingApp.ViewModel
{
    public class MachineViewModel : BaseViewModel.BaseViewModel
    {

        private DispatcherTimer TimerA1 = new DispatcherTimer();
        private DispatcherTimer TimerA3 = new DispatcherTimer();
        private DispatcherTimer TimerRobot = new DispatcherTimer();
        private TimeSpan TimeA1_TP = new TimeSpan();
        private TimeSpan TimeA3_TP = new TimeSpan();
        private TimeSpan TimeRobot_TP = new TimeSpan();
        #region Command
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        public static ICommand Getbarcode_Command { get; set; }
        public static ICommand Get_Input_Time_Command { get; set; }
        public static ICommand Get_Trip_Time_Command { get; set; }
        public static ICommand Update_Temperature_Command { get; set; }

        public static ICommand Get_Dip_Time_A1_Command { get; set; }
        public static ICommand Get_Dip_Time_A3_Command { get; set; }
        public static ICommand Get_Dip_Time_Robot { get; set; }
        #endregion

        #region Model
        //bath 1
        private int _temper1;

        public int Temper1
        {
            get { return _temper1; }
            set { SetProperty(ref _temper1, value, nameof(Temper1)); }
        }


        private string _barcode1;

        public string Barcode1
        {
            get { return _barcode1; }
            set { SetProperty(ref _barcode1, value, nameof(Barcode1)); }
        }


        private string _diptime1;

        public string DipTime1
        {
            get { return _diptime1; }
            set { SetProperty(ref _diptime1, value, nameof(DipTime1)); }
        }


        private string _inputtime1;

        public string ImputTime1
        {
            get { return _inputtime1; }
            set { SetProperty(ref _inputtime1, value, nameof(ImputTime1)); }
        }


        //bath 2
        private int _temper2;

        public int Temper2
        {
            get { return _temper2; }
            set { SetProperty(ref _temper2, value, nameof(Temper2)); }
        }


        private string _barcode2;

        public string Barcode2
        {
            get { return _barcode2; }
            set { SetProperty(ref _barcode2, value, nameof(Barcode2)); }
        }


        private string _diptime2;

        public string DipTime2
        {
            get { return _diptime2; }
            set { SetProperty(ref _diptime2, value, nameof(DipTime2)); }
        }


        private string _inputtime2;

        public string ImputTime2
        {
            get { return _inputtime2; }
            set { SetProperty(ref _inputtime2, value, nameof(ImputTime2)); }
        }


        //bath 3
        private int _temper3;

        public int Temper3
        {
            get { return _temper3; }
            set { SetProperty(ref _temper3, value, nameof(Temper3)); }
        }


        private string _barcode3;

        public string Barcode3
        {
            get { return _barcode3; }
            set { SetProperty(ref _barcode3, value, nameof(Barcode3)); }
        }


        private string _diptime3;

        public string DipTime3
        {
            get { return _diptime3; }
            set { SetProperty(ref _diptime3, value, nameof(DipTime3)); }
        }


        private string _inputtime3;

        public string ImputTime3
        {
            get { return _inputtime3; }
            set { SetProperty(ref _inputtime3, value, nameof(ImputTime3)); }
        }

        //bath 4
        private int _temper4;

        public int Temper4
        {
            get { return _temper4; }
            set { SetProperty(ref _temper4, value, nameof(Temper4)); }
        }


        private string _barcode4;

        public string Barcode4
        {
            get { return _barcode4; }
            set { SetProperty(ref _barcode4, value, nameof(Barcode4)); }
        }


        private string _diptime4;

        public string DipTime4
        {
            get { return _diptime4; }
            set { SetProperty(ref _diptime4, value, nameof(DipTime4)); }
        }


        private string _inputtime4;

        public string ImputTime4
        {
            get { return _inputtime4; }
            set { SetProperty(ref _inputtime4, value, nameof(ImputTime4)); }
        }

        //bath 5
        private int _temper5;

        public int Temper5
        {
            get { return _temper5; }
            set { SetProperty(ref _temper5, value, nameof(Temper5)); }
        }


        private string _barcode5;

        public string Barcode5
        {
            get { return _barcode5; }
            set { SetProperty(ref _barcode5, value, nameof(Barcode5)); }
        }


        private string _diptime5;

        public string DipTime5
        {
            get { return _diptime5; }
            set { SetProperty(ref _diptime5, value, nameof(DipTime5)); }
        }


        private string _inputtime5;

        public string ImputTime5
        {
            get { return _inputtime5; }
            set { SetProperty(ref _inputtime5, value, nameof(ImputTime5)); }
        }

        //bath 6
        private int _temper6;

        public int Temper6
        {
            get { return _temper6; }
            set { SetProperty(ref _temper6, value, nameof(Temper6)); }
        }


        private string _barcode6;

        public string Barcode6
        {
            get { return _barcode6; }
            set { SetProperty(ref _barcode6, value, nameof(Barcode6)); }
        }


        private string _diptime6;

        public string DipTime6
        {
            get { return _diptime6; }
            set { SetProperty(ref _diptime6, value, nameof(DipTime6)); }
        }


        private string _inputtime6;

        public string ImputTime6
        {
            get { return _inputtime6; }
            set { SetProperty(ref _inputtime6, value, nameof(ImputTime6)); }
        }

        //bath 7
        private int _temper7;

        public int Temper7
        {
            get { return _temper7; }
            set { SetProperty(ref _temper7, value, nameof(Temper7)); }
        }


        private string _barcode7;

        public string Barcode7
        {
            get { return _barcode7; }
            set { SetProperty(ref _barcode7, value, nameof(Barcode7)); }
        }


        private string _diptime7;

        public string DipTime7
        {
            get { return _diptime7; }
            set { SetProperty(ref _diptime7, value, nameof(DipTime7)); }
        }


        private string _inputtime7;

        public string ImputTime7
        {
            get { return _inputtime7; }
            set { SetProperty(ref _inputtime7, value, nameof(ImputTime7)); }
        }

        //bath 8
        private int _temper8;

        public int Temper8
        {
            get { return _temper8; }
            set { SetProperty(ref _temper8, value, nameof(Temper8)); }
        }


        private string _barcode8;

        public string Barcode8
        {
            get { return _barcode8; }
            set { SetProperty(ref _barcode8, value, nameof(Barcode8)); }
        }


        private string _diptime8;

        public string DipTime8
        {
            get { return _diptime8; }
            set { SetProperty(ref _diptime8, value, nameof(DipTime8)); }
        }


        private string _inputtime8;

        public string ImputTime8
        {
            get { return _inputtime8; }
            set { SetProperty(ref _inputtime8, value, nameof(ImputTime8)); }
        }

        //bath 9
        private int _temper9;

        public int Temper9
        {
            get { return _temper9; }
            set { SetProperty(ref _temper9, value, nameof(Temper9)); }
        }


        private string _barcode9;

        public string Barcode9
        {
            get { return _barcode9; }
            set { SetProperty(ref _barcode9, value, nameof(Barcode9)); }
        }


        private string _diptime9;

        public string DipTime9
        {
            get { return _diptime9; }
            set { SetProperty(ref _diptime9, value, nameof(DipTime9)); }
        }


        private string _inputtime9;

        public string ImputTime9
        {
            get { return _inputtime9; }
            set { SetProperty(ref _inputtime9, value, nameof(ImputTime9)); }
        }

        //bath 10
        private int _temper10;

        public int Temper10
        {
            get { return _temper10; }
            set { SetProperty(ref _temper10, value, nameof(Temper10)); }
        }


        private string _barcode10;

        public string Barcode10
        {
            get { return _barcode10; }
            set { SetProperty(ref _barcode10, value, nameof(Barcode10)); }
        }


        private string _diptime10;

        public string DipTime10
        {
            get { return _diptime10; }
            set { SetProperty(ref _diptime10, value, nameof(DipTime10)); }
        }


        private string _inputtime10;

        public string ImputTime10
        {
            get { return _inputtime10; }
            set { SetProperty(ref _inputtime10, value, nameof(ImputTime10)); }
        }
        #endregion



        private bool Init = false;


        public MachineViewModel()
        {
            
            TimerA1.Interval = new TimeSpan(0, 0, 1);
            TimerA1.Tick += TimerA1_Tick;
            TimerA3.Interval = new TimeSpan(0, 0, 1);
            TimerA3.Tick += TimerA3_Tick;
            TimerRobot.Interval = new TimeSpan(0, 0, 1);
            TimerRobot.Tick += TimerRobot_Tick;


            

            Loaded = new ActionCommand(() => 
            {
                try
                {
                    if (!Init && PLC_Query.Connected)
                    {
                        PLC_Query.Get_ListCodeChar();
                        PLC_Query.GetProcess_Data_Parameter();
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1) != "")
                        {
                            var time1 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Area_1);
                            TimeA1_TP = time1;
                            DipTime1 = string.Format("{0:00}:{1:00}", time1.Minutes, time1.Seconds);
                            ImputTime1 = (DateTime.Now - time1).ToString("HH:mm:ss");
                            if (TimerA1.IsEnabled == false) 
                            {
                                TimerA1.Start();
                                TimerA1.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime1 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1) != "")
                        {
                            var time2 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Area_1);
                            TimeA1_TP = time2;
                            DipTime2 = string.Format("{0:00}:{1:00}", time2.Minutes, time2.Seconds);
                            ImputTime2 = (DateTime.Now - time2).ToString("HH:mm:ss");
                            if (TimerA1.IsEnabled == false)
                            {
                                TimerA1.Start();
                                TimerA1.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime2 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1) != "")
                        {
                            var time3 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Area_1);
                            TimeA1_TP = time3;
                            DipTime3 = string.Format("{0:00}:{1:00}", time3.Minutes, time3.Seconds);
                            ImputTime3 = (DateTime.Now - time3).ToString("HH:mm:ss");
                            if (TimerA1.IsEnabled == false)
                            {
                                TimerA1.Start();
                                TimerA1.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime3 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1) != "")
                        {
                            var time4 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Bath4);
                            TimeRobot_TP = time4;
                            DipTime4 = string.Format("{0:00}:{1:00}", time4.Minutes, time4.Seconds);
                            ImputTime4 = (DateTime.Now - time4).ToString("HH:mm:ss");
                            if (TimerRobot.IsEnabled == false)
                            {
                                TimerRobot.Start();
                                TimerRobot.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime4 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1) != "")
                        {
                            var time5 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Bath5);
                            TimeRobot_TP = time5;
                            DipTime5 = string.Format("{0:00}:{1:00}", time5.Minutes, time5.Seconds);
                            ImputTime5 = (DateTime.Now - time5).ToString("HH:mm:ss");
                            if (TimerRobot.IsEnabled == false)
                            {
                                TimerRobot.Start();
                                TimerRobot.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime5 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1) != "")
                        {
                            var time6 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Bath6);
                            TimeRobot_TP = time6;
                            DipTime6 = string.Format("{0:00}:{1:00}", time6.Minutes, time6.Seconds);
                            ImputTime6 = (DateTime.Now - time6).ToString("HH:mm:ss");
                            if (TimerRobot.IsEnabled == false)
                            {
                                TimerRobot.Start();
                                TimerRobot.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime6 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1) != "")
                        {
                            var time7 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Area_3);
                            TimeA3_TP = time7;
                            DipTime7 = string.Format("{0:00}:{1:00}", time7.Minutes, time7.Seconds);
                            ImputTime7 = (DateTime.Now - time7).ToString("HH:mm:ss");
                            if (TimerA3.IsEnabled == false)
                            {
                                TimerA3.Start();
                                TimerA3.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime7 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1) != "")
                        {
                            var time8 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Area_3);
                            TimeA3_TP = time8;
                            DipTime8 = string.Format("{0:00}:{1:00}", time8.Minutes, time8.Seconds);
                            ImputTime8 = (DateTime.Now - time8).ToString("HH:mm:ss");
                            if (TimerA3.IsEnabled == false)
                            {
                                TimerA3.Start();
                                TimerA3.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime8 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1) != "")
                        {
                            var time9 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Area_3);
                            TimeA3_TP = time9;
                            DipTime9 = string.Format("{0:00}:{1:00}", time9.Minutes, time9.Seconds);
                            ImputTime9 = (DateTime.Now - time9).ToString("HH:mm:ss");
                            if (TimerA3.IsEnabled == false)
                            {
                                TimerA3.Start();
                                TimerA3.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime9 = "--:--";
                        }
                        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1) != "")
                        {
                            var time10 = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Current_TValue_Area_3);
                            TimeA3_TP = time10;
                            DipTime10 = string.Format("{0:00}:{1:00}", time10.Minutes, time10.Seconds);
                            ImputTime10 = (DateTime.Now - time10).ToString("HH:mm:ss");
                            if (TimerA3.IsEnabled == false)
                            {
                                TimerA3.Start();
                                TimerA3.IsEnabled = true;
                            }
                        }
                        else
                        {
                            DipTime10 = "--:--";
                        }
                        
                        Getbarcode_Command.Execute(null);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("exeption with convert value or error with plc comunication");
                }
                
            });

            Unloaded = new ActionCommand(() =>
            {
            
            });

            Getbarcode_Command = new ActionCommand(() => 
            {
                Barcode1 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1);
                Barcode2 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1);
                Barcode3 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1);
                Barcode4 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1);
                Barcode5 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1);
                Barcode6 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1);
                Barcode7 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1);
                Barcode8 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1);
                Barcode9 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1);
                Barcode10 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1);
            });
            Get_Input_Time_Command = new ActionCommand((p) => 
            {
                if((int)p == 1)
                {
                    DateTime dateTime = DateTime.Now;
                    ImputTime1 = dateTime.ToShortTimeString(); 
                    ImputTime2 = dateTime.ToShortTimeString();
                    ImputTime3 = dateTime.ToShortTimeString(); 
                }
                else if((int)p == 2) 
                {
                    DateTime dateTime = DateTime.Now;
                    ImputTime4 = dateTime.ToShortTimeString();
                    ImputTime5 = dateTime.ToShortTimeString();
                    ImputTime6 = dateTime.ToShortTimeString();

                }
                else if ((int)p == 3) 
                {
                    DateTime dateTime = DateTime.Now;
                    ImputTime7 = dateTime.ToShortTimeString();
                    ImputTime8 = dateTime.ToShortTimeString();
                    ImputTime9 = dateTime.ToShortTimeString();
                    ImputTime10 = dateTime.ToShortTimeString();
                }
            });

            Get_Dip_Time_A1_Command = new ActionCommand((p) => 
            {
                if((bool)p) 
                {
                    ImputTime1 = ImputTime2 = ImputTime3 = DateTime.Now.ToString("HH:mm:ss");
                    TimerA1.Start();
                    TimerA1.IsEnabled = true;
                    
                }
                else 
                {
                    ImputTime1 = ImputTime2 = ImputTime3 = "--:--";
                    TimerA1.Stop();
                    TimerA1.IsEnabled = false;
                    TimeA1_TP = TimeSpan.FromSeconds(0);
                }
            });
            Get_Dip_Time_A3_Command = new ActionCommand((p) => 
            {
                if ((bool)p)
                {
                    ImputTime7 = ImputTime8 = ImputTime9 = ImputTime10 = DateTime.Now.ToString("HH:mm:ss");
                    TimerA3.Start();
                    TimerA3.IsEnabled = true;
                }
                else
                {
                    ImputTime7 = ImputTime8 = ImputTime9 = ImputTime10 = "--:--";
                    TimerA3.Stop();
                    TimerA3.IsEnabled = false;
                    TimeA3_TP = TimeSpan.FromSeconds(0);
                }
            });
            Get_Dip_Time_Robot = new ActionCommand((p) => 
            {
                if ((bool)p)
                {
                    TimerRobot.Start();
                    TimerRobot.IsEnabled = true;
                    if (Barcode4 != string.Empty)
                    {
                        ImputTime5 = "--:--";
                        ImputTime6 = "--:--";
                        ImputTime4 = DateTime.Now.ToString("HH:mm:ss");
                    }
                    else if (Barcode5 != string.Empty)
                    {
                        ImputTime4 = "--:--";
                        ImputTime6 = "--:--";
                        ImputTime5 = DateTime.Now.ToString("HH:mm:ss");
                    }
                    else if (Barcode6 != string.Empty)
                    {
                        ImputTime4 = "--:--";
                        ImputTime5 = "--:--";
                        ImputTime6 = DateTime.Now.ToString("HH:mm:ss");
                    }
                }
                else
                {
                    TimerRobot.Stop();
                    TimerRobot.IsEnabled = false;
                    TimeRobot_TP = TimeSpan.FromSeconds(0);
                    ImputTime5 = "--:--";
                    ImputTime6 = "--:--";
                    ImputTime5 = "--:--";
                }
            });

            Update_Temperature_Command = new ActionCommand(() => 
            {
                Temper1 = GlobalDataHoya.Nhietdo.Temp1;
                Temper2 = GlobalDataHoya.Nhietdo.Temp2;
                Temper3 = GlobalDataHoya.Nhietdo.Temp3;
                Temper4 = GlobalDataHoya.Nhietdo.Temp4;
                Temper5 = GlobalDataHoya.Nhietdo.Temp5;
                Temper6 = GlobalDataHoya.Nhietdo.Temp6;
                Temper7 = GlobalDataHoya.Nhietdo.Temp7;
                Temper8 = GlobalDataHoya.Nhietdo.Temp8;
                Temper9 = GlobalDataHoya.Nhietdo.Temp9;
                Temper10 = GlobalDataHoya.Nhietdo.Temp10;
                 
            });
            
        }

        private void TimerRobot_Tick(object sender, EventArgs e)
        {
            if(Barcode4 != string.Empty) 
            {
                DipTime5 = "--:--";
                DipTime6 = "--:--";
                TimeRobot_TP += TimeSpan.FromSeconds(1);
                DipTime4 = string.Format("{0:00}:{1:00}", TimeRobot_TP.Minutes, TimeRobot_TP.Seconds);
            }
            else if(Barcode5 != string.Empty)
            {
                DipTime4 = "--:--";
                DipTime6 = "--:--";
                TimeRobot_TP += TimeSpan.FromSeconds(1);
                DipTime5 = string.Format("{0:00}:{1:00}", TimeRobot_TP.Minutes, TimeRobot_TP.Seconds);
            }
            else if (Barcode6 != string.Empty) 
            {
                DipTime5 = "--:--";
                DipTime4 = "--:--";
                TimeRobot_TP += TimeSpan.FromSeconds(1);
                DipTime6 = string.Format("{0:00}:{1:00}", TimeRobot_TP.Minutes, TimeRobot_TP.Seconds);
            }
        }

        private void TimerA3_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeA3_TP += TimeSpan.FromSeconds(1);
                DipTime7 = DipTime8 = DipTime9 = DipTime10 = string.Format("{0:00}:{1:00}", TimeA3_TP.Minutes, TimeA3_TP.Seconds);
            }
            catch (Exception)
            {

               
            }
           
        }

        private void TimerA1_Tick(object sender, EventArgs e)
        {
            try
            {
                TimeA1_TP += TimeSpan.FromSeconds(1);
                DipTime1 = DipTime2 = DipTime3 = string.Format("{0:00}:{1:00}", TimeA1_TP.Minutes,TimeA1_TP.Seconds);
            }
            catch (Exception)
            {

            }
        }
    }
}
