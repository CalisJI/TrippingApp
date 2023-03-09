using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using BaseViewModel;
using Cognex.InSight.Controls.Display;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Owin.Hosting;
using S7.Net.Types;
using TrippingApp.APIController;
using TrippingApp.AppConfig;
using TrippingApp.Model;
using TrippingApp.Runtime;
using DateTime = System.DateTime;

namespace TrippingApp.ViewModel
{
    public class MainViewModel : BaseViewModel.BaseViewModel
    {
        private BaseViewModel.BaseViewModel _selectedViewmodel;

        public BaseViewModel.BaseViewModel SelectedViewModel
        {
            get => _selectedViewmodel;
            set => SetProperty(ref _selectedViewmodel, value,nameof(SelectedViewModel));
        }
        private bool _childPage = true;

        public bool ChildPage
        {
            get { return _childPage; }
            set { SetProperty(ref _childPage, value, nameof(ChildPage)); }
        }

        private bool _workbench;

        public bool Workbench_Running
        {
            get { return _workbench; }
            set { SetProperty(ref _workbench, value, nameof(Workbench_Running)); }
        }


        private bool _camOn;

        public bool CameraOn
        {
            get { return _camOn; }
            set { SetProperty(ref _camOn, value, nameof(CameraOn)); }
        }
        public static DispatcherTimer ShowTimer = new DispatcherTimer();

        public ICommand Home_Page_Command { get; set; }
        public ICommand Test { get; set; }
        public ICommand Test1 { get; set; }
        public ICommand Test2 { get; set; }
        public ICommand Test3 { get; set; }
        public ICommand Machine_Page_Command { get; set; }
        public ICommand Setting_Page_Command { get; set; }
        public ICommand DashBoard_Page_Command { get; set; }
        public ICommand Robot_And_Manual_Configuration_Page_Command { get; set; }
        public ICommand Data_Machine_Page_Command { get; set; }
        public ICommand Process_Param_Page { get; set; }
        public ICommand CameraAPI_Page_Command { get; set; }
        public ICommand Camera_Connect_Command { get; set; }
        public ICommand PLC_Connect_Command { get; set; }
        public ICommand Tracking_Page_Command { get; set; }
        public ICommand IO_Page_Command { get; set; }
        public ICommand OpenKeyBoard_Command { get; set; }
        #region Model
        private string _time;

        public string Timer_Full
        {
            get { return _time; }
            set { SetProperty(ref _time, value, nameof(Timer_Full)); }
        }
        private static bool _isbusy;

        public bool IsBusy
        {
            get { return _isbusy; }
            set { SetProperty(ref _isbusy, value, nameof(IsBusy)); }
        }
        private static bool _isact = true;

        public bool IsActive
        {
            get { return _isact; }
            set { SetProperty(ref _isact, value, nameof(IsActive)); }
        }
        #endregion

        #region ViewModel
        private Lazy<SimulationViewModel> SimulationViewModel = new Lazy<SimulationViewModel>(() => { return new ViewModel.SimulationViewModel(); });
        //private SimulationViewModel SimulationViewModel;
        private SettingViewModel SettingViewModel;
        private OverViewMachineViewModel OverViewMachineViewModel;
        private Lazy<Robot_Manual_ConfigurationViewModel> Robot_Manual_ConfigurationViewModel = new Lazy<Robot_Manual_ConfigurationViewModel>(() => { return new ViewModel.Robot_Manual_ConfigurationViewModel(); });
        //private Robot_Manual_ConfigurationViewModel Robot_Manual_ConfigurationViewModel;
        private MachineViewModel MachineViewModel = new MachineViewModel();
        private CameraApiViewModel CameraApiViewModel = new CameraApiViewModel();
        private TrackHistory_ViewModel TrackHistory_ViewModel = new TrackHistory_ViewModel();
        private IOViewModel IOViewModel = new IOViewModel();
        private Process _touchKeyboardProcess;
        #endregion
        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);


        public MainViewModel()
        {

            try
            {
                var workbenchPath = @"C:\Program Files\MySQL\MySQL Workbench 8.0\MySQLWorkbench.exe";

                var process = new Process();
                process.StartInfo.FileName = workbenchPath;
                process.Start();
                ShowWindow(process.MainWindowHandle, 6);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            

            
            ShowTimer.Interval = new TimeSpan(0,0,1);
            ShowTimer.Tick += ShowTimer_Tick;
            ShowTimer.Start();

            this.SelectedViewModel = this;
            Test = new ActionCommand((p) => 
            {
                try
                {
                    //SYSTEM_DATA_RETAIN data10 = new SYSTEM_DATA_RETAIN();
                    //PLC_Query.ReadData(data10, 10);
                    //ROBOT_PARAM data1 = new ROBOT_PARAM();
                    //PLC_Query.ReadData(data1, 14);
                    //PLC_Query.ReadData(PLC_Query.LIST_CODE_CHAR, 3);
                    //Random ab = new Random();
                    //int rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode1_P1 = S7String.ToByteArray("HY-001", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode1_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1, 4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode2_P1 = S7String.ToByteArray("HY-002", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode2_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode3_P1 = S7String.ToByteArray("HY-003", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode3_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode4_P1 = S7String.ToByteArray("HY-004", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode4_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode5_P1 = S7String.ToByteArray("HY-005", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode5_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode6_P1 = S7String.ToByteArray("HY-006", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode6_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode7_P1 = S7String.ToByteArray("HY-007", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode7_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode8_P1 = S7String.ToByteArray("HY-008", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode8_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode9_P1 = S7String.ToByteArray("HY-009", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode9_P2 = S7String.ToByteArray(rd.ToString(), 1);
                    //rd = (int)ab.Next(1,4);
                    //PLC_Query.LIST_CODE_CHAR.Barcode10_P1 = S7String.ToByteArray("HY-010", 10);
                    //PLC_Query.LIST_CODE_CHAR.Barcode10_P2 = S7String.ToByteArray(rd.ToString(), 1);

                    //PLC_Query.WriteData(PLC_Query.LIST_CODE_CHAR, 3);

                    //Modbus_Communicate.Initial();

                    //this.SelectedViewModel = TrackHistory_ViewModel;

                    //TrackingProces.GetHistory(new DateTime(2023, 1, 29));


                    //HistoryLogger.CreateTable_History();

                    //PLC_Query.WriteData(AddressCrt.Barcode_1_P1, S7String.ToByteArray("HY-007",10));
                    //PLC_Query.WriteData(AddressCrt.Barcode_1_P2, S7String.ToByteArray("2", 1));

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            });

            Test1 = new ActionCommand(() => 
            {
                RackObject rackObject = new RackObject();
                rackObject.RackBarcode = "HY-001";
                rackObject.RackStatus = Status.Inprocess;
                rackObject.RackDetails = "aaa";
                rackObject.Bath1_Infor.TimeIn = DateTime.Now;

                HistoryLogger.AddRackObject(rackObject);
            });
            Test2 = new ActionCommand(() =>
            {
            
            });

            Test3 = new ActionCommand(() =>
            {
            
            });


            #region C-Letter Command
            CameraAPI_Page_Command = new ActionCommand(() =>
            {
                
                if (CameraApiViewModel == null) 
                {
                    CameraApiViewModel = new CameraApiViewModel();
                }
                this.SelectedViewModel = CameraApiViewModel;
                ChildPage = true;
             
            });
            Camera_Connect_Command = new ActionCommand(() =>
            {
                //CameraApiViewModel.Initialize();
                try
                {
                    if (PLC_Query.PLC_Controller == null)
                    {
                        throw new Exception("Please Connect PLC First");
                       
                    }
                    CameraApiViewModel.Connect_Camera_Command.Execute(null);
                    CameraApiViewModel.Online_Camera_Command.Execute(null);
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                
             
                
            });
            #endregion

            #region D- Letter Command
            DashBoard_Page_Command = new ActionCommand(() =>
            {
            
            });
            Data_Machine_Page_Command = new ActionCommand(() =>
            {
                IsBusy = true;
                IsActive = true;
                if (OverViewMachineViewModel == null)
                {
                    OverViewMachineViewModel = new OverViewMachineViewModel();
                }
                ChildPage = true;
                this.SelectedViewModel = OverViewMachineViewModel;
                IsBusy = false;
                IsActive = false;
            });
            #endregion

            #region H- Letter Command
            Home_Page_Command = new ActionCommand(() =>
            {
                ChildPage = false;
                this.SelectedViewModel = this;
            });
            #endregion


            #region I - Letter Command
            IO_Page_Command = new ActionCommand(() =>
            {
                this.SelectedViewModel = IOViewModel;
            });
            #endregion
            #region P-Letter Command
            Process_Param_Page = new ActionCommand(() =>
            {
                //IsActive = true;
                this.SelectedViewModel = SimulationViewModel.Value;
                ChildPage = true;
                //IsActive = false;
            });
            PLC_Connect_Command = new ActionCommand(() =>
            {
                try
                {
                    if (!PLC_Query.Connected) 
                    {
                        PLC_Query.Initial(ApplicationConfig.SystemConfig.PLC_IP_Address);
                    }
                    //if(TCP_Runtime.TcpListener == null)
                    //{
                    //    TCP_Runtime.CreateNetWork();
                    //}
                   
                    
                    //Modbus_Communicate.Initial();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                  
                }
               
            });
            #endregion


            #region O-Letter Command
            OpenKeyBoard_Command = new ActionCommand(() =>
            {
                try
                {
                    if (Process.GetProcessesByName("TabTip").Length == 0)
                    {
                        string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";
                        _touchKeyboardProcess = Process.Start(touchKeyboardPath);

                    }
                    else
                    {
                        foreach (var item in Process.GetProcessesByName("TabTip"))
                        {
                            item.Kill();
                            _touchKeyboardProcess.Dispose();
                            _touchKeyboardProcess = null;
                        }
                        string touchKeyboardPath = @"C:\Program Files\Common Files\Microsoft Shared\Ink\TabTip.exe";
                        _touchKeyboardProcess = Process.Start(touchKeyboardPath);
                    }
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
               
            });
            #endregion
            #region R-Letter Command
            Robot_And_Manual_Configuration_Page_Command = new ActionCommand(() =>
            {

                this.SelectedViewModel = Robot_Manual_ConfigurationViewModel.Value;

            });
            #endregion

            #region S - Letter Command

            Machine_Page_Command = new ActionCommand(() =>
            {
                if (MachineViewModel == null) 
                {
                    MachineViewModel = new MachineViewModel();
                }
                this.SelectedViewModel = MachineViewModel;
            });
            Setting_Page_Command = new ActionCommand(() =>
            {
                //IsBusy = true;
                //IsActive = true;
                if (SettingViewModel == null)
                {
                    SettingViewModel = new SettingViewModel();
                }
                ChildPage = true;
                this.SelectedViewModel = SettingViewModel;
              
            });

            #endregion


            #region T - Letter Command
            Tracking_Page_Command = new ActionCommand(() =>
            {
                if (TrackHistory_ViewModel == null) 
                {
                    TrackHistory_ViewModel = new TrackHistory_ViewModel();
                }
                ChildPage = true;
                this.SelectedViewModel = TrackHistory_ViewModel;
            });
            #endregion

        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            Timer_Full = string.Format("{0}:{1}:{2} {3} {4}-{5}-{6}",
                dateTime.Hour.ToString("D2"),
                dateTime.Minute.ToString("D2"),
                dateTime.Second.ToString("D2"),
                dateTime.DayOfWeek,
                dateTime.Day.ToString("D2"),
                dateTime.Month.ToString("D2"),
                dateTime.Year);

            var workbenchPath = @"MySQLWorkbench";
            var process = Process.GetProcessesByName(workbenchPath);
            if (process.Length > 0)
            {
                Workbench_Running = true;
            }
            else
            {
                Workbench_Running = false;
            }
            
            CameraOn = CameraApiViewModel.CvsInSightDisplay2.Connected;
        }
        
    }
}
