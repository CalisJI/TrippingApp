using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Media3D;
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

        public ICommand Home_Page_Command { get; set; }
        public ICommand Test { get; set; }
        public ICommand Simulation_Page_Command { get; set; }
        public ICommand Setting_Page_Command { get; set; }
        public ICommand DashBoard_Page_Command { get; set; }
        public ICommand Robot_And_Manual_Configuration_Page_Command { get; set; }
        public ICommand Data_Machine_Page_Command { get; set; }
        public ICommand Process_Param_Page { get; set; }

        #region ViewModel
        private SimulationViewModel SimulationViewModel;
        private SettingViewModel SettingViewModel;
        #endregion
        public MainViewModel()
        {
            this.SelectedViewModel = this;
            Test = new ActionCommand((p) => 
            {
                string a = (string)p;
                Console.WriteLine(a);
            });
            #region D- Letter Command
            DashBoard_Page_Command = new ActionCommand(() =>
            {
            
            });
            Data_Machine_Page_Command = new ActionCommand(() =>
            {
            
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
                if (SimulationViewModel == null)
                {
                    SimulationViewModel = new SimulationViewModel();
                }
                ChildPage = true;
                this.SelectedViewModel = SimulationViewModel;
            });
            #endregion

            #region R-Letter Command
            Robot_And_Manual_Configuration_Page_Command = new ActionCommand(() =>
            {
                ChildPage = true;
                GetApi.GetData("http://127.0.0.1:8000/");
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
    }
}
