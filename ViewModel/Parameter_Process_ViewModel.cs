using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
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
        #endregion


        #region Command

        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        public ICommand Apply_DataProcess_Command { get; set; }
        #endregion
        public Parameter_Process_ViewModel()
        {
            Loaded = new ActionCommand(() => 
            {
                if (PLC_Query.Connected) 
                {
                    PLC_Query.ReadData(PLC_Query.PROCESS_DATA_PARAMETER, 5);
                    BathA1Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3);
                    BathA3Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3);
                    Bath4P2Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P2);
                    Bath4P3Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P3);
                    Bath5P4Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath5_P4);
                    Bath6P1Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P1);
                    Bath6P2Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P2);
                    Bath6P3Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P3);
                    Bath6P4Time = TimeSpan.FromMilliseconds(PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P4);

                }

            });
            Apply_DataProcess_Command = new ActionCommand(async () =>
            {
                if (PLC_Query.Connected)
                {
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P1 = (Int32)Bath6P1Time.TotalMilliseconds;
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P2 = (Int32)Bath6P2Time.TotalMilliseconds;
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P3 = (Int32)Bath6P3Time.TotalMilliseconds;
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath6_P4 = (Int32)Bath6P4Time.TotalMilliseconds;

                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P2 = (Int32)Bath4P2Time.TotalMilliseconds;
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath4_P3 = (Int32)Bath4P3Time.TotalMilliseconds;
                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Bath5_P4 = (Int32)Bath5P4Time.TotalMilliseconds;

                    PLC_Query.PROCESS_DATA_PARAMETER.Timer_Region1vs3 = (Int32)BathA1Time.TotalMilliseconds;

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
            Unloaded = new ActionCommand(() =>
            {
            
            });
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
