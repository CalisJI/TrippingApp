using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
using TrippingApp.Runtime;

namespace TrippingApp.ViewModel
{
    public class SimulationViewModel: BaseViewModel.BaseViewModel
    {
        private DispatcherTimer GetValueTimer = new DispatcherTimer();
        #region Command ViewModel
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        /// <summary>
        /// Set Value Bath1
        /// </summary>
        public ICommand B1_Set { get; set; }

        /// <summary>
        /// Set Value Bath2
        /// </summary>
        public ICommand B2_Set { get; set; }

        /// <summary>
        /// Set Value Bath3
        /// </summary>
        public ICommand B3_Set { get; set; }

        /// <summary>
        /// Set Value Bath4
        /// </summary>
        public ICommand B4_Set { get; set; }

        /// <summary>
        /// Set Value Bath5
        /// </summary>
        public ICommand B5_Set { get; set; }

        /// <summary>
        /// Set Value Bath6
        /// </summary>
        public ICommand B6_Set { get; set; }

        /// <summary>
        /// Set Value Bath7
        /// </summary>
        public ICommand B7_Set { get; set; }

        /// <summary>
        /// Set Value Bath8
        /// </summary>
        public ICommand B8_Set { get; set; }

        /// <summary>
        /// Set Value Bath9
        /// </summary>
        public ICommand B9_Set { get; set; }

        /// <summary>
        /// Set Value Bath10
        /// </summary>
        public ICommand B10_Set { get; set; }

        /// <summary>
        /// Set Value Bath11
        /// </summary>
        public ICommand B11_Set { get; set; }
        #endregion


        #region Properties
        private float _pv1;
        /// <summary>
        /// Bath1
        /// </summary>
        public float PV1
        {
            get { return _pv1; }
            set { SetProperty(ref _pv1, value, nameof(PV1)); }
        }


        private float _pv2;
        /// <summary>
        /// Bath2
        /// </summary>
        public float PV2
        {
            get { return _pv2; }
            set { SetProperty(ref _pv2, value, nameof(PV2)); }
        }

        private float _pv3;
        /// <summary>
        /// Bath3
        /// </summary>
        public float PV3
        {
            get { return _pv3; }
            set { SetProperty(ref _pv3, value, nameof(PV3)); }
        }

        private float _pv4;
        /// <summary>
        /// Bath4
        /// </summary>
        public float PV4
        {
            get { return _pv4; }
            set { SetProperty(ref _pv4, value, nameof(PV4)); }
        }

        private float _pv5;
        /// <summary>
        /// Bath5
        /// </summary>
        public float PV5
        {
            get { return _pv5; }
            set { SetProperty(ref _pv5, value, nameof(PV5)); }
        }

        private float _pv6;
        /// <summary>
        /// Bath6
        /// </summary>
        public float PV6
        {
            get { return _pv6; }
            set { SetProperty(ref _pv6, value, nameof(PV6)); }
        }


        private float _pv7;
        /// <summary>
        /// Bath7
        /// </summary>
        public float PV7
        {
            get { return _pv7; }
            set { SetProperty(ref _pv7, value, nameof(PV7)); }
        }

        private float _pv8;
        /// <summary>
        /// Bath8
        /// </summary>
        public float PV8
        {
            get { return _pv8; }
            set { SetProperty(ref _pv8, value, nameof(PV8)); }
        }

        private float _pv9;
        /// <summary>
        /// Bath9
        /// </summary>
        public float PV9
        {
            get { return _pv9; }
            set { SetProperty(ref _pv9, value, nameof(PV9)); }
        }

        private float _pv10;
        /// <summary>
        /// Bath10
        /// </summary>
        public float PV10
        {
            get { return _pv10; }
            set { SetProperty(ref _pv10, value, nameof(PV10)); }
        }

        private float _pv11;
        /// <summary>
        /// Bath11
        /// </summary>
        public float PV11
        {
            get { return _pv11; }
            set { SetProperty(ref _pv11, value, nameof(PV11)); }
        }


        private float _sv1;
        /// <summary>
        /// Set Value Bath 1
        /// </summary>
        public float SV1
        {
            get { return _sv1; }
            set { SetProperty(ref _sv1, value, nameof(SV1)); }
        }

        private float _sv2;
        /// <summary>
        /// Set Value Bath 2
        /// </summary>
        public float SV2
        {
            get { return _sv2; }
            set { SetProperty(ref _sv2, value, nameof(SV2)); }
        }

        private float _sv3;
        /// <summary>
        /// Set Value Bath 3
        /// </summary>
        public float SV3
        {
            get { return _sv3; }
            set { SetProperty(ref _sv3, value, nameof(SV3)); }
        }

        private float _sv4;
        /// <summary>
        /// Set Value Bath 4
        /// </summary>
        public float SV4
        {
            get { return _sv4; }
            set { SetProperty(ref _sv4, value, nameof(SV4)); }
        }

        private float _sv5;
        /// <summary>
        /// Set Value Bath 5
        /// </summary>
        public float SV5
        {
            get { return _sv5; }
            set { SetProperty(ref _sv5, value, nameof(SV5)); }
        }

        private float _sv6;
        /// <summary>
        /// Set Value Bath 6
        /// </summary>
        public float SV6
        {
            get { return _sv6; }
            set { SetProperty(ref _sv6, value, nameof(SV6)); }
        }

        private float _sv7;
        /// <summary>
        /// Set Value Bath 7
        /// </summary>
        public float SV7
        {
            get { return _sv7; }
            set { SetProperty(ref _sv7, value, nameof(SV7)); }
        }

        private float _sv8;
        /// <summary>
        /// Set Value Bath 8
        /// </summary>
        public float SV8
        {
            get { return _sv8; }
            set { SetProperty(ref _sv8, value, nameof(SV8)); }
        }

        private float _sv9;
        /// <summary>
        /// Set Value Bath 9
        /// </summary>
        public float SV9
        {
            get { return _sv9; }
            set { SetProperty(ref _sv9, value, nameof(SV9)); }
        }

        private float _sv10;
        /// <summary>
        /// Set Value Bath 10
        /// </summary>
        public float SV10
        {
            get { return _sv10; }
            set { SetProperty(ref _sv10, value, nameof(SV10)); }
        }

        private float _sv11;
        /// <summary>
        /// Set Value Bath 11
        /// </summary>
        public float SV11
        {
            get { return _sv11; }
            set { SetProperty(ref _sv11, value, nameof(SV11)); }
        }
        #endregion
        public SimulationViewModel()
        {
            GetValueTimer.Tick += GetValueTimer_Tick;
            GetValueTimer.Interval = new TimeSpan(2000);
            

            Loaded = new ActionCommand((p) =>
            {
                if (!GetValueTimer.IsEnabled) 
                {
                    GetValueTimer.Start();
                }
                SV1 = Modbus_Communicate.VX4_1.SV;
                SV2 = Modbus_Communicate.VX4_2.SV;
                SV3 = Modbus_Communicate.VX4_3.SV;
                SV4 = Modbus_Communicate.VX4_4.SV;
                SV5 = Modbus_Communicate.VX4_5.SV;
                SV6 = Modbus_Communicate.VX4_6.SV;
                SV7 = Modbus_Communicate.VX4_7.SV;
                SV8 = Modbus_Communicate.VX4_8.SV;
                SV9 = Modbus_Communicate.VX4_9.SV;
                SV10 = Modbus_Communicate.VX4_10.SV;
                SV11 = Modbus_Communicate.VX4_11.SV;
            });
            Unloaded = new ActionCommand((p) =>
            {
                if (GetValueTimer.IsEnabled)
                {
                    GetValueTimer.Stop();
                }
            });

            B1_Set = new ActionCommand((p) =>
            {

            });
            B2_Set = new ActionCommand((p) =>
            {

            });
            B3_Set = new ActionCommand((p) =>
            {

            });
            B4_Set = new ActionCommand((p) =>
            {

            });
            B5_Set = new ActionCommand((p) =>
            {

            });
            B6_Set = new ActionCommand((p) =>
            {

            });
            B7_Set = new ActionCommand((p) =>
            {

            });
            B8_Set = new ActionCommand((p) =>
            {

            });
            B9_Set = new ActionCommand((p) =>
            {

            });
            B10_Set = new ActionCommand((p) =>
            {

            });
            B11_Set = new ActionCommand((p) =>
            {

            });
        }

        private void GetValueTimer_Tick(object sender, EventArgs e)
        {
            PV1 = Modbus_Communicate.VX4_1.PV;
            PV2 = Modbus_Communicate.VX4_2.PV;
            PV3 = Modbus_Communicate.VX4_3.PV;
            PV4 = Modbus_Communicate.VX4_4.PV;
            PV5 = Modbus_Communicate.VX4_5.PV;
            PV6 = Modbus_Communicate.VX4_6.PV;
            PV7 = Modbus_Communicate.VX4_7.PV;
            PV8 = Modbus_Communicate.VX4_8.PV;
            PV9 = Modbus_Communicate.VX4_9.PV;
            PV10 = Modbus_Communicate.VX4_10.PV;
            PV11 = Modbus_Communicate.VX4_11.PV;

        }
    }
}
