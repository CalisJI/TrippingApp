using Cognex.InSight;
using Cognex.InSight.Controls.Display;
using Microsoft.Expression.Interactivity.Core;
using S7.Net.Types;
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
using TrippingApp.AppConfig;
using TrippingApp.Runtime;

namespace TrippingApp.ViewModel
{
    public class CameraApiViewModel:BaseViewModel.BaseViewModel
    {

        #region Event
        public event EventHandler QRCodeReceived;
        protected virtual void OnQRCodeReceived(QRCodeReceivedEventArgs e)
        {
            QRCodeReceived?.Invoke(this, e);
        }
        public delegate void QRCodeReceivedEventHandler(object sender, QRCodeReceivedEventArgs e);
        #endregion
        private BaseViewModel.BaseViewModel _selectecViewModel;

        public BaseViewModel.BaseViewModel SelectedViewModel
        {
            get { return _selectecViewModel; }
            set { SetProperty(ref _selectecViewModel, value, nameof(SelectedViewModel)); }
        }
        #region Command
        #region Static Command
        public static ICommand Connect_Camera_Command { get; set; }
        public static ICommand Online_Camera_Command { get; set; }
        public static ICommand Offline_Camera_Command { get; set; }
        #endregion

        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }


        public ICommand Fill_Check_Changed_Command { get; set; }
        public ICommand Fit_Check_Changed_Command { get; set; }
        public ICommand None_Check_Changed_Command { get; set; }

        public ICommand Online_check_Command { get; set; }
        public ICommand Live_check_Command { get; set; }
        public ICommand Graphics_check_Command { get; set; }
        public ICommand Grid_check_Command { get; set; }

        public ICommand Save_Config_Command { get; set; }
        #endregion


        #region Model
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

        private string _inforState;

        public string InforState
        {
            get { return _inforState; }
            set { SetProperty(ref _inforState, value, nameof(InforState)); }
        }
        private string _inforStatus;

        public string InforStatus
        {
            get { return _inforStatus; }
            set { SetProperty(ref _inforStatus, value, nameof(InforStatus)); }
        }


        private bool _showImage;

        public bool ShowImage_Check
        {
            get { return _showImage; }
            set { SetProperty(ref _showImage, value, nameof(ShowImage_Check)); }
        }

        private bool _showGrid;

        public bool ShowGrid_Check
        {
            get { return _showGrid; }
            set { SetProperty(ref _showGrid, value, nameof(ShowGrid_Check)); }
        }
        private bool _showGrapics;

        public bool ShowGraphics_Check
        {
            get { return _showGrapics; }
            set { SetProperty(ref _showGrapics, value, nameof(ShowGraphics_Check)); }
        }
        private bool _onlive;

        public bool Online_Check
        {
            get { return _onlive; }
            set { SetProperty(ref _onlive, value, nameof(Online_Check)); }
        }
        private bool _live;

        public bool Live_Check
        {
            get { return _live; }
            set { SetProperty(ref _live, value, nameof(Live_Check)); }
        }
        private bool _rationone;

        public bool RatioNone_Check
        {
            get { return _rationone; }
            set { SetProperty(ref _rationone, value, nameof(RatioNone_Check)); }
        }

        private bool _ratiofit;

        public bool RatioFit_Check
        {
            get { return _ratiofit; }
            set { SetProperty(ref _ratiofit, value, nameof(RatioFit_Check)); }
        }
        private bool _ratiofill;

        public bool RatioFill_Check
        {
            get { return _ratiofill; }
            set { SetProperty(ref _ratiofill, value, nameof(RatioFill_Check)); }
        }
        private bool _enable_connect_btn = true;

        public bool Enable_Connect_Btn
        {
            get { return _enable_connect_btn; }
            set { SetProperty(ref _enable_connect_btn, value, nameof(Enable_Connect_Btn)); }
        }
        private string _result;

        public string Cognex_Result
        {
            get { return _result; }
            set { SetProperty(ref _result, value, nameof(Cognex_Result)); }
        }


        private bool _connectCam;

        public bool Connected_Camera
        {
            get { return _connectCam; }
            set { SetProperty(ref _connectCam, value, nameof(Connected_Camera)); }
        }
        #endregion


        public static Cognex.InSight.Controls.Display.CvsInSightDisplay CvsInSightDisplay2;
        public void Initialize()
        {
            try
            {
                CvsInSightDisplay2.LoadStandardTheme();
                CvsInSightDisplay2.ConnectedChanged += CvsInSightDisplay2_ConnectedChanged;
                CvsInSightDisplay2.StateChanged += CvsInSightDisplay2_StateChanged;
                CvsInSightDisplay2.ConnectCompleted += CvsInSightDisplay2_ConnectCompleted;
                CvsInSightDisplay2.StatusInformationChanged += CvsInSightDisplay2_StatusInformationChanged;
                CvsInSightDisplay2.ResultsChanged += CvsInSightDisplay2_ResultsChanged;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            Cognex.InSight.CvsInSightSoftwareDevelopmentKit.Initialize();
          
        }
        private  void CvsInSightDisplay2_ResultsChanged(object sender, EventArgs e)
        {
            try
            {
                if (CvsInSightDisplay2.Results.Cells.GetCell(31, 1) != null && CvsInSightDisplay2.Results.Cells.GetCell(31, 1).Text != string.Empty)
                {
                    var a = CvsInSightDisplay2.Results.Cells.GetCell(31, 1).Text;
                    if (a != Cognex_Result)
                    {
                        bool run = PLC_Query.ReadBit(AddressCrt.AUTO_STATE);
                        if (run)
                        {
                            Cognex_Result = a;
                            PLC_Query.DETECT_VALUE.SCANED_BARCODE = S7String.ToByteArray(a, 10);
                            PLC_Query.WriteData(PLC_Query.DETECT_VALUE, 20);
                            PLC_Query.WriteBit(AddressCrt.PC_Detected_Rack, true);
                        }
                       
                    }
                }
                if(CvsInSightDisplay2.Results.Cells.GetCell(31, 1)!= null) 
                {
                 Cognex_Result = CvsInSightDisplay2.Results.Cells.GetCell(31, 1).Text.ToString();
                }
            }
            catch (Exception ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);
            }
        }

        private void CvsInSightDisplay2_StatusInformationChanged(object sender, EventArgs e)
        {
            InforStatus = CvsInSightDisplay2.StatusInformation;
        }

        private void CvsInSightDisplay2_ConnectCompleted(object sender, Cognex.InSight.CvsConnectCompletedEventArgs e)
        {
            ShowImage_Check = CvsInSightDisplay2.ShowImage;
            if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.None)
                RatioNone_Check = true;
            else if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.Fit)
                RatioFit_Check = true;
            else if (CvsInSightDisplay2.ImageZoomMode == Cognex.InSight.Controls.Display.CvsDisplayZoom.Fill)
                RatioFill_Check = true;
            Enable_Connect_Btn = true;
        }

        private void CvsInSightDisplay2_StateChanged(object sender, Cognex.InSight.Controls.Display.CvsDisplayStateChangedEventArgs e)
        {
            UpdateStateMsg();
        }

        private void CvsInSightDisplay2_ConnectedChanged(object sender, EventArgs e)
        {
            if (CvsInSightDisplay2.Connected)
            {
                Connected = true;
                Connected_Camera = true;
                CvsInSightDisplay2.SoftOnline = true;
            }
            else
            {
                Connected_Camera = false;
            }
        }

        private void UpdateStateMsg()
        {
            switch (CvsInSightDisplay2.State)
            {
                case Cognex.InSight.Controls.Display.CvsDisplayState.Connecting:
                    InforState = "Connecting...";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Dialog:
                    InforState = "Dialog";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.DialogEditingReferenceRanges:
                    InforState = "Dialog Reference";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingCellExpression:
                    InforState = "Editing Expression";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingCellValue:
                    InforState = "Editing Value";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingGraphics:
                    InforState = "Editing Graphics";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.EditingReferenceRanges:
                    InforState = "Editing Reference";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Normal:
                    InforState = "Normal";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Waiting:
                    InforState = "Waiting...";
                    break;
                case Cognex.InSight.Controls.Display.CvsDisplayState.Wizard:
                    InforState = "Wizard";
                    break;
                default:
                    InforState = "Unknown";
                    break;
            }
        }
        
        public CameraApiViewModel()
        {
            Username = ApplicationConfig.SystemConfig.UserName;
            CameraAddress = ApplicationConfig.SystemConfig.CameraIP;
            Password = ApplicationConfig.SystemConfig.Password;
            Loaded = new ActionCommand(() =>
            {
                Username = ApplicationConfig.SystemConfig.UserName;
                CameraAddress = ApplicationConfig.SystemConfig.CameraIP;
                Password = ApplicationConfig.SystemConfig.Password;
            });
            Unloaded = new ActionCommand(() => 
            {
            
            });
            try
            {
                if (CvsInSightDisplay2 == null)
                {
                    CvsInSightDisplay2 = new CvsInSightDisplay();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
           
            CognexControl = new System.Windows.Forms.Integration.WindowsFormsHost();
            Initialize();

            CognexControl.Child = CvsInSightDisplay2;

            //CvsInSightDisplay2.Edit.SoftOnline.Bind()
            //CvsInSightDisplay2.Edit.LiveAcquire.Bind(Live_check_Command);  // live mode
            //CvsInSightDisplay2.Edit.ShowGraphics.Bind(Graphics_check_Command);
            //CvsInSightDisplay2.Edit.ShowGrid.Bind(Grid_check_Command);
            #region C-Letter Command

            Connect_Camera_Command = new ActionCommand((p) => 
            {
                try
                {
                    if (p != null && (int)p == 1)
                    {
                        if (!(CvsInSightDisplay2.Connected))
                        {

                            CvsInSightDisplay2.Connect(ApplicationConfig.SystemConfig.CameraIP, ApplicationConfig.SystemConfig.UserName, ApplicationConfig.SystemConfig.PWD, false);
                            Enable_Connect_Btn = false;
                            Connected = true;

                        }
                        else
                        {
                            CvsInSightDisplay2.Disconnect();
                            Connected = false;
                        }
                    }
                    else
                    {
                        if (!(CvsInSightDisplay2.Connected))
                        {

                            CvsInSightDisplay2.Connect(CameraAddress, Username, Password, false);
                            Enable_Connect_Btn = false;
                            Connected = true;

                        }
                        else
                        {
                            CvsInSightDisplay2.Disconnect();
                            Connected = false;
                        }
                    }
                    
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
               
                
            });
            #endregion

            Fill_Check_Changed_Command = new ActionCommand(() =>
            {
                if (RatioFill_Check)
                {
                    CvsInSightDisplay2.ImageZoomMode = CvsDisplayZoom.Fill;
                }
            });
            Fit_Check_Changed_Command = new ActionCommand(() =>
            {
                if (RatioFit_Check)
                {
                    CvsInSightDisplay2.ImageZoomMode = CvsDisplayZoom.Fit;
                }
            });
            None_Check_Changed_Command = new ActionCommand(() =>
            {
                if (RatioNone_Check)
                {
                    CvsInSightDisplay2.ImageZoomMode = CvsDisplayZoom.None;
                }
            });

            
            Grid_check_Command = new ActionCommand(() =>
            {
                if (ShowGrid_Check)
                {
                    CvsInSightDisplay2.ShowGrid = true;
                }
                else
                {
                    CvsInSightDisplay2.ShowGrid = false;
                }
                
            });
            Graphics_check_Command = new ActionCommand(() =>
            {
                if (ShowGrid_Check)
                {
                    CvsInSightDisplay2.ShowGraphics = true;
                }
                else
                {
                    CvsInSightDisplay2.ShowGraphics = false;
                }
            });

            Online_Camera_Command = new ActionCommand(() =>
            {
                CvsInSightDisplay2.SoftOnline = true;
            });

            Offline_Camera_Command = new ActionCommand(() =>
            {
                CvsInSightDisplay2.SoftOnline = true;
            });
            Live_check_Command = new ActionCommand((p) =>
            {
                if (Live_Check)
                {
                    CvsInSightDisplay2.Edit.LiveAcquire.Execute();
                }
                else 
                {
                    CvsInSightDisplay2.Edit.LiveAcquire.Activated = false;
                }
            });
            Online_check_Command = new ActionCommand((p) =>
            {
                //CvsInSightDisplay2.Edit.SoftOnline.Execute();
                if (Online_Check)
                {
                    CvsInSightDisplay2.SoftOnline = true;
                }
                else
                {
                    CvsInSightDisplay2.SoftOnline = false;
                }
            });

            Save_Config_Command = new ActionCommand(() =>
            {
                try
                {
                    ApplicationConfig.SystemConfig.CameraIP = CameraAddress;
                    ApplicationConfig.SystemConfig.PWD = Password;
                    ApplicationConfig.SystemConfig.UserName = Username;
                    ApplicationConfig.UpdateData(ApplicationConfig.SystemConfig);
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                }
                
            });
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
    public class QRCodeReceivedEventArgs : EventArgs
    {
        public int QRCode { get; set; }
        
    }
}
