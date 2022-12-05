using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using TrippingApp.Runtime;

namespace TrippingApp.ViewModel
{
    public class CameraApiViewModel:BaseViewModel.BaseViewModel
    {
        private BaseViewModel.BaseViewModel _selectecViewModel;

        public BaseViewModel.BaseViewModel SelectedViewModel
        {
            get { return _selectecViewModel; }
            set { SetProperty(ref _selectecViewModel, value, nameof(SelectedViewModel)); }
        }

        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        public ICommand Connect_Camera_Command { get; set; }
        private string _cameraAddress;

        public string CameraAddress
        {
            get { return _cameraAddress; }
            set { SetProperty(ref _cameraAddress, value, nameof(CameraAddress)); }
        }
        private string _username;

        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value, nameof(Username)); }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value, nameof(Password)); }
        }
        private bool _connected = false;

        public bool Connected
        {
            get { return _connected; }
            set { SetProperty(ref _connected, value, nameof(Connected)); }
        }
        private System.Windows.Forms.Integration.WindowsFormsHost _cognexControl;

        public System.Windows.Forms.Integration.WindowsFormsHost CognexControl
        {
            get { return _cognexControl; }
            set { SetProperty(ref _cognexControl, value, nameof(CognexControl)); }
        }


        public Cognex.InSight.Controls.Display.CvsInSightDisplay CvsInSightDisplay2;
        public void Initialize()
        {
            Cognex.InSight.CvsInSightSoftwareDevelopmentKit.Initialize();
            CvsInSightDisplay2.LoadStandardTheme();
            CvsInSightDisplay2.ConnectedChanged += CvsInSightDisplay2_ConnectedChanged;
            CvsInSightDisplay2.StateChanged += CvsInSightDisplay2_StateChanged;
            CvsInSightDisplay2.ConnectCompleted += CvsInSightDisplay2_ConnectCompleted;
            CvsInSightDisplay2.StatusInformationChanged += CvsInSightDisplay2_StatusInformationChanged;
            CvsInSightDisplay2.ResultsChanged += CvsInSightDisplay2_ResultsChanged;
        }
        private  void CvsInSightDisplay2_ResultsChanged(object sender, EventArgs e)
        {
            try
            {
                if (CvsInSightDisplay2.Results.Cells.GetCell(31, 1) != null)
                {
                    var a = CvsInSightDisplay2.Results.Cells.GetCell(31, 1).Text;
                    Console.WriteLine(a);
                }
            }
            catch (Exception)
            {


            }
        }

        private void CvsInSightDisplay2_StatusInformationChanged(object sender, EventArgs e)
        {

        }

        private void CvsInSightDisplay2_ConnectCompleted(object sender, Cognex.InSight.CvsConnectCompletedEventArgs e)
        {

        }

        private void CvsInSightDisplay2_StateChanged(object sender, Cognex.InSight.Controls.Display.CvsDisplayStateChangedEventArgs e)
        {
        }

        private void CvsInSightDisplay2_ConnectedChanged(object sender, EventArgs e)
        {

        }
        public CameraApiViewModel()
        {
            if(CvsInSightDisplay2 == null)
            {
                CvsInSightDisplay2 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
            }
            CognexControl = new System.Windows.Forms.Integration.WindowsFormsHost();
            Initialize();

            CognexControl.Child = CvsInSightDisplay2;
            #region C-Letter Command

            Connect_Camera_Command = new ActionCommand(() => 
            {
                Connected = !Connected;
            });
            #endregion
        }
    }

    public class ChangedState : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(bool)value)
            {
                DrawingImage key = (DrawingImage)Application.Current.Resources["connectedDrawingImage"];
                return key;
            }
            else
            {
                DrawingImage key = (DrawingImage)Application.Current.Resources["disconnectedDrawingImage"];
                return key;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
