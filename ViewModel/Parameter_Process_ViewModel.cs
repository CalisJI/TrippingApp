using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using TrippingApp.APIController;
using TrippingApp.AppConfig;
using TrippingApp.Runtime;

namespace TrippingApp.ViewModel
{
    public class Parameter_Process_ViewModel:BaseViewModel.BaseViewModel
    {
        #region Model


        private TimeSpan _batha1Time;

        public TimeSpan BathA1Time
        {
            get { return _batha1Time; }
            set { SetProperty(ref _batha1Time, value, nameof(BathA1Time)); }
        }

        private TimeSpan _batha3Time;

        public TimeSpan BathA3Time
        {
            get { return _batha3Time; }
            set { SetProperty(ref _batha3Time, value, nameof(BathA3Time)); }
        }


        private TimeSpan _bath6P1;

        public TimeSpan Bath6P1Time
        {
            get { return _bath6P1; }
            set { SetProperty(ref _bath6P1, value, nameof(Bath6P1Time)); }
        }


        private TimeSpan _bath6P2;

        public TimeSpan Bath6P2Time
        {
            get { return _bath6P2; }
            set { SetProperty(ref _bath6P2, value, nameof(Bath6P2Time)); }
        }

        private TimeSpan _bath6P3;

        public TimeSpan Bath6P3Time
        {
            get { return _bath6P3; }
            set { SetProperty(ref _bath6P3, value, nameof(Bath6P3Time)); }
        }


        private TimeSpan _bath6P4;

        public TimeSpan Bath6P4Time
        {
            get { return _bath6P4; }
            set { SetProperty(ref _bath6P4, value, nameof(Bath6P4Time)); }
        }


        private TimeSpan _bath4P2;

        public TimeSpan Bath4P2Time
        {
            get { return _bath4P2; }
            set { SetProperty(ref _bath4P2, value, nameof(Bath4P2Time)); }
        }

        private TimeSpan _bath4P3;

        public TimeSpan Bath4P3Time
        {
            get { return _bath4P3; }
            set { SetProperty(ref _bath4P3, value, nameof(Bath4P3Time)); }
        }

        private TimeSpan _bath5p4;

        public TimeSpan Bath5P4Time
        {
            get { return _bath5p4; }
            set { SetProperty(ref _bath5p4, value, nameof(Bath5P4Time)); }
        }



        private DataTable _robot_type;

        public DataTable Robot_Type
        {
            get { return _robot_type; }
            set { SetProperty(ref _robot_type, value, nameof(Robot_Type)); }
        }
        #endregion


        #region Command

        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        public ICommand Apply_DataProcess_Command { get; set; }
        public ICommand Edit_Command { get; set; }
        public ICommand Cancel_Command { get; set; }
        #endregion
        public Parameter_Process_ViewModel()
        {
            CreateTable();

            Loaded = new ActionCommand(() => 
            {
                if (PLC_Query.Connected) 
                {
                    PLC_Query.ReadData(PLC_Query.PROCESS_DATA_PARAMETER, 5);
                    PLC_Query.GetMulty_Type_Robot();
                    //BathA1Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3);
                    //BathA3Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3);
                    //Bath4P2Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P2);
                    //Bath4P3Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P3);
                    //Bath5P4Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath5_P4);
                    //Bath6P1Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P1);
                    //Bath6P2Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P2);
                    //Bath6P3Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P3);
                    //Bath6P4Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P4);
                    ReloadTable();
                }
            });
            Apply_DataProcess_Command = new ActionCommand(async () =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P1 =  Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[0]["Bath 6"].ToString())).TotalMilliseconds);
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P2 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[1]["Bath 6"].ToString())).TotalMilliseconds);
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[2]["Bath 6"].ToString())).TotalMilliseconds);
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P4 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[3]["Bath 6"].ToString())).TotalMilliseconds);

                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P2 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[1]["Bath 4"].ToString())).TotalMilliseconds);
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[2]["Bath 4"].ToString())).TotalMilliseconds);
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath5_P4 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[3]["Bath 5"].ToString())).TotalMilliseconds);

                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[3]["Bath 1"].ToString())).TotalMilliseconds);

                    if (Robot_Type.Rows.Count > 4) 
                    {
                        for (int i = 4; i < Robot_Type.Rows.Count; i++)
                        {
                            int ii = (int)Robot_Type.Rows[i]["Id"];
                            switch (ii)
                            {
                                case 5:

                                    PLC_Query.Multy_Robot_Type.Type5_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type5_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type5_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type5_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);

                                    break;
                                case 6:

                                    PLC_Query.Multy_Robot_Type.Type6_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type6_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type6_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type6_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 7:

                                    PLC_Query.Multy_Robot_Type.Type7_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type7_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type7_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type7_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 8:
                                    PLC_Query.Multy_Robot_Type.Type8_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type8_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type8_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type8_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 9:
                                    PLC_Query.Multy_Robot_Type.Type9_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type9_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type9_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type9_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 10:
                                    PLC_Query.Multy_Robot_Type.Type10_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type10_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type10_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type10_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 11:
                                    PLC_Query.Multy_Robot_Type.Type11_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type11_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type11_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type11_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 12:
                                    PLC_Query.Multy_Robot_Type.Type12_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type12_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type12_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type12_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 13:
                                    PLC_Query.Multy_Robot_Type.Type13_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type13_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type13_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type13_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 14:
                                    PLC_Query.Multy_Robot_Type.Type14_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type14_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type14_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type14_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 15:
                                    PLC_Query.Multy_Robot_Type.Type15_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type15_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type15_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type15_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 16:
                                    PLC_Query.Multy_Robot_Type.Type16_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type16_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type16_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type16_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 17:
                                    PLC_Query.Multy_Robot_Type.Type17_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type17_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type17_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type17_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 18:
                                    PLC_Query.Multy_Robot_Type.Type18_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type18_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type18_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type18_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 19:
                                    PLC_Query.Multy_Robot_Type.Type19_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type19_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type19_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type19_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 20:
                                    PLC_Query.Multy_Robot_Type.Type20_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type20_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type20_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type20_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 21:
                                    PLC_Query.Multy_Robot_Type.Type21_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type21_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type21_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type21_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 22:
                                    PLC_Query.Multy_Robot_Type.Type22_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type22_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type22_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type22_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 23:
                                    PLC_Query.Multy_Robot_Type.Type23_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type23_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type23_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type23_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 24:
                                    PLC_Query.Multy_Robot_Type.Type24_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type24_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type24_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type24_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                case 25:
                                    PLC_Query.Multy_Robot_Type.Type25_Bath1_3 = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 1"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type25_Bath4_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 4"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type25_Bath5_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 5"].ToString())).TotalMilliseconds);
                                    PLC_Query.Multy_Robot_Type.Type25_Bath6_Px = Convert.ToInt32(TimeSpan.FromMinutes(Convert.ToDouble(Robot_Type.Rows[i]["Bath 6"].ToString())).TotalMilliseconds);
                                    break;
                                default:
                                    break;
                            }
                        }
                    }




                    PLC_Query.WriteData(PLC_Query.PROCESS_DATA_PARAMETER, 5);
                }
                else
                {

                }


                //using (var client = new HttpClient()) 
                //{
                //    var response = await client.GetAsync("http://localhost:8000/data");

                //    if (response.IsSuccessStatusCode)
                //    {
                //        var content = await response.Content.ReadAsStringAsync();
                //        Console.WriteLine(content);
                //    }
                //    else
                //    {
                //        Console.WriteLine($"API request failed with status code {response.StatusCode}");
                //    }
                //}

            });

            Edit_Command = new ActionCommand(() =>
            {
            
            });

            Cancel_Command = new ActionCommand(() => 
            {
                
            });
            Unloaded = new ActionCommand(() =>
            {
            
            });
        }
        public void CreateTable() 
        {
            Robot_Type = new DataTable();
            Robot_Type.Columns.Add("Id").DataType = typeof(int);
            Robot_Type.Columns.Add("Liquid");
            Robot_Type.Columns.Add("FS Time");
            Robot_Type.Columns.Add("Bath 1");
            Robot_Type.Columns.Add("Bath 2");
            Robot_Type.Columns.Add("Bath 3");
            Robot_Type.Columns.Add("Bath 4");
            Robot_Type.Columns.Add("Bath 5");
            Robot_Type.Columns.Add("Bath 6");
            Robot_Type.Columns.Add("Bath 7");
            Robot_Type.Columns.Add("Bath 8");
            Robot_Type.Columns.Add("Bath 9");
            Robot_Type.Columns.Add("Bath 10");
            Robot_Type.Columns.Add("Condition");


            Robot_Type.Rows.Add(1,"Any", "1", "6", "6", "6", "0", "0", "6", "6", "6", "6", "6", "1");
            Robot_Type.Rows.Add(2,"Any", "1", "6", "6", "6", "0.5", "0", "5", "6", "6", "6", "6", "2");
            Robot_Type.Rows.Add(3,"Any", "1", "6", "6", "6", "2", "0", "3.5", "6", "6", "6", "6", "3");
            Robot_Type.Rows.Add(4,"Tool Strip", "1", "6", "6", "6", "0", "5", "0.5", "6", "6", "6", "6", "4");
            //Robot_Type.Rows.Add(5, "HCE5F", "1-2-3", "3", "3", "3", "0", "0", "3", "3", "3", "3", "3", "5");
        }
        public void ReloadTable() 
        {
            Robot_Type.Rows[0]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[0]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[0]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[0]["Bath 4"] = "0";
            Robot_Type.Rows[0]["Bath 5"] = "0";
            Robot_Type.Rows[0]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P1).TotalMinutes.ToString();
            Robot_Type.Rows[0]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[0]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[0]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[0]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();

            Robot_Type.Rows[1]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P2).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 5"] = "0";
            Robot_Type.Rows[1]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P2).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[1]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();

            Robot_Type.Rows[2]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 5"] = "0";
            Robot_Type.Rows[2]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[2]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();

            Robot_Type.Rows[3]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 4"] = "0";
            Robot_Type.Rows[3]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath5_P4).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P4).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();
            Robot_Type.Rows[3]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3).TotalMinutes.ToString();

            if (Robot_Type.Rows.Count > 4) 
            {
                for (int i = 4; i < Robot_Type.Rows.Count; i++)
                {
                    int ii = (int)Robot_Type.Rows[i]["Id"];
                    switch (ii)
                    {
                        case 5:

                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type5_Bath1_3).TotalMinutes.ToString();

                            break;
                        case 6:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type6_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 7:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type7_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 8:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type8_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 9:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type9_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 10:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type10_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 11:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type11_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 12:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type12_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 13:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type13_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 14:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type14_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 15:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type15_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 16:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type16_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 17:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type17_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 18:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type18_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 19:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type19_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 20:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type20_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 21:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type21_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 22:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type22_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 23:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type23_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 24:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type24_Bath1_3).TotalMinutes.ToString();
                            break;
                        case 25:
                            Robot_Type.Rows[i]["Bath 1"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 2"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 3"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 4"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath4_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 5"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath5_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 6"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath6_Px).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 7"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 8"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 9"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath1_3).TotalMinutes.ToString();
                            Robot_Type.Rows[i]["Bath 10"] = TimeSpan.FromMilliseconds(PLC_Query.Multy_Robot_Type.Type25_Bath1_3).TotalMinutes.ToString();
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
    public class StringToTimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            //string timeString = value.ToString();
            //TimeSpan timeSpan = TimeSpan.ParseExact(timeString, "mm\\:ss", null);
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string timeString = value.ToString();
            TimeSpan timeSpan = TimeSpan.ParseExact(timeString, @"m\:s", null);
            return timeSpan;
        }
    }
}
