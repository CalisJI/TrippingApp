using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Threading;
using BaseViewModel;
using Microsoft.Expression.Interactivity.Core;
using TrippingApp.Runtime;

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

        public static DispatcherTimer ShowTimer = new DispatcherTimer();

        public ICommand Home_Page_Command { get; set; }
        public ICommand Test { get; set; }
        public ICommand Simulation_Page_Command { get; set; }
        public ICommand Setting_Page_Command { get; set; }
        public ICommand DashBoard_Page_Command { get; set; }
        public ICommand Robot_And_Manual_Configuration_Page_Command { get; set; }
        public ICommand Data_Machine_Page_Command { get; set; }
        public ICommand Process_Param_Page { get; set; }
        public ICommand CameraAPI_Page_Command { get; set; }

        #region Model
        private string _time;

        public string Timer_Full
        {
            get { return _time; }
            set { SetProperty(ref _time, value, nameof(Timer_Full)); }
        }

        #endregion

        #region ViewModel
        private Lazy<SimulationViewModel> SimulationViewModel = new Lazy<SimulationViewModel>(() => { return new ViewModel.SimulationViewModel(); });
        //private SimulationViewModel SimulationViewModel;
        private SettingViewModel SettingViewModel;
        private OverViewMachineViewModel OverViewMachineViewModel;
        private Lazy<Robot_Manual_ConfigurationViewModel> Robot_Manual_ConfigurationViewModel = new Lazy<Robot_Manual_ConfigurationViewModel>(() => { return new ViewModel.Robot_Manual_ConfigurationViewModel(); });
        //private Robot_Manual_ConfigurationViewModel Robot_Manual_ConfigurationViewModel;
        private CameraApiViewModel CameraApiViewModel;
        #endregion
        public MainViewModel()
        {
            ShowTimer.Interval = new TimeSpan(0,0,1);
            ShowTimer.Tick += ShowTimer_Tick;
            ShowTimer.Start();

            this.SelectedViewModel = this;
            Test = new ActionCommand((p) => 
            {
                string a = (string)p;
                Console.WriteLine(a);
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
            #endregion

            #region D- Letter Command
            DashBoard_Page_Command = new ActionCommand(() =>
            {
            
            });
            Data_Machine_Page_Command = new ActionCommand(() =>
            {
                if (OverViewMachineViewModel == null)
                {
                    OverViewMachineViewModel = new OverViewMachineViewModel();
                }
                ChildPage = true;
                this.SelectedViewModel = OverViewMachineViewModel;
            });
            #endregion

            #region H- Letter Command
            Home_Page_Command = new ActionCommand(() =>
            {
                ChildPage = false;
                this.SelectedViewModel = this;
            });
            #endregion

            #region P-Letter Command
            Process_Param_Page = new ActionCommand(() =>
            {
                this.SelectedViewModel = SimulationViewModel.Value;
                ChildPage = true;
            });
            #endregion

            #region R-Letter Command
            Robot_And_Manual_Configuration_Page_Command = new ActionCommand(() =>
            {
                ChildPage = true;
                //if (Robot_Manual_ConfigurationViewModel == null)
                //{
                //    Robot_Manual_ConfigurationViewModel = new Robot_Manual_ConfigurationViewModel();
                //}
                this.SelectedViewModel = Robot_Manual_ConfigurationViewModel.Value;
                //GetApi.GetData("http://127.0.0.1:8D2/");
            });
            #endregion

            #region S - Letter Command

            Simulation_Page_Command = new ActionCommand(() =>
            {
               
            });
            Setting_Page_Command = new ActionCommand(() =>
            {
                if (SettingViewModel == null)
                {
                    SettingViewModel = new SettingViewModel();
                }
                ChildPage = true;
                this.SelectedViewModel = SettingViewModel;
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
        }
    }
}
