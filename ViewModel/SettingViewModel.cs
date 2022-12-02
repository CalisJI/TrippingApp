using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrippingApp.AppConfig;
using System.Windows.Forms;

namespace TrippingApp.ViewModel
{
    public class SettingViewModel:BaseViewModel.BaseViewModel
    {
        #region PLC Configuration
        private string _PC_Ip;

        public string PC_IP_Address
        {
            get => _PC_Ip;
            set => SetProperty(ref _PC_Ip, value, nameof(PC_IP_Address));
        }

        private string _PLC_Ip;

        public string PLC_IP_Address
        {
            get => _PLC_Ip;
            set => SetProperty(ref _PLC_Ip, value, nameof(PLC_IP_Address));
        }
        private int _PC_Port;

        public int PC_IP_Port
        {
            get => _PC_Port;
            set => SetProperty(ref _PC_Port, value, nameof(PC_IP_Port));
        }
        private short _rack = 1;

        public short Rack
        {
            get => _rack;
            set => SetProperty(ref _rack, value, nameof(Rack));
        }

        private short _slot = 0;

        public short Slot
        {
            get => _slot;
            set => SetProperty(ref _slot, value, nameof(Slot));
        }


        private string _comport;

        public string COM_Port
        {
            get => _comport;
            set => SetProperty(ref _comport, value, nameof(COM_Port));
        }

        private int _baud;

        public int Baudrate
        {
            get => _baud;
            set => SetProperty(ref _baud, value, nameof(Baudrate));
        }

        private Parity _parity;

        public Parity Paritys
        {
            get => _parity;
            set => SetProperty(ref _parity, value, nameof(Paritys));
        }

        private int _Pc_server_port;

        public int PC_Server_Port
        {
            get => _Pc_server_port;
            set => SetProperty(ref _Pc_server_port, value, nameof(PC_Server_Port));
        }
        private string _pc_server_ip;

        public string PC_Server_IP_Address
        {
            get => _pc_server_ip;
            set => SetProperty(ref _pc_server_ip, value, nameof(PC_Server_IP_Address));
        }


        private string[] _com;

        public string[] ListCom
        {
            get => _com;
            set => SetProperty(ref _com, value, nameof(ListCom));
        }

        private int[] _listBaud = { 9600, 19200, 38400, 57600, 115200 };

        public int[] ListBaudrate
        {
            get => _listBaud;
            set => SetProperty(ref _listBaud, value, nameof(ListBaudrate));
        }

        private Parity[] parities = { Parity.None, Parity.Odd, Parity.Even };

        public Parity[] Parities
        {
            get => parities;
            set => SetProperty(ref parities, value, nameof(Parities));
        }


        private bool _canedit;

        public bool CanEdit
        {
            get => _canedit;
            set => SetProperty(ref _canedit, value, nameof(CanEdit));
        }

        #endregion
        #region File Configuration
        private string _data_Folder;

        public string Data_Folder
        {
            get => _data_Folder;
            set => SetProperty(ref _data_Folder, value, nameof(Data_Folder));
        }

        #endregion
        #region Icommand
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        public ICommand Save { get; set; }
        public ICommand Edit { get; set; }
        public ICommand OpenPath { get; set; }
        public ICommand Cancel { get; set; }


        #endregion
        public SettingViewModel()
        {
            Loaded = new ActionCommand(() =>
            {
                Get_Com();
                Data_Folder = ApplicationConfig.SystemConfig.FileLocation;
                PLC_IP_Address = ApplicationConfig.SystemConfig.PLC_IP_Address;
                PC_IP_Port = ApplicationConfig.SystemConfig.Port;
                Rack = ApplicationConfig.SystemConfig.Rack;
                Slot = ApplicationConfig.SystemConfig.Slot;
                COM_Port = ApplicationConfig.SystemConfig.Comport;
                Baudrate = ApplicationConfig.SystemConfig.Baudrate;
                Paritys = ApplicationConfig.SystemConfig.Parity_MB;
                PC_IP_Address = GetLocalIPAddress();
                PC_Server_IP_Address = ApplicationConfig.SystemConfig.PC_Server_IP;
                PC_Server_Port = ApplicationConfig.SystemConfig.PC_Port;
            });
            Save = new ActionCommand(() =>
            {
                try
                {
                    _ = Logger.Logger.Async_write("Press Save Setting Config");
                    ApplicationConfig.SystemConfig.Baudrate = Baudrate;
                    ApplicationConfig.SystemConfig.Comport = COM_Port;
                    ApplicationConfig.SystemConfig.FileLocation = Data_Folder;
                    ApplicationConfig.SystemConfig.Parity_MB = Paritys;

                    ApplicationConfig.SystemConfig.PC_IP_Address = PC_IP_Address;
                    ApplicationConfig.SystemConfig.PC_Port = PC_Server_Port;
                    ApplicationConfig.SystemConfig.PLC_IP_Address = PLC_IP_Address;
                    ApplicationConfig.SystemConfig.PC_Server_IP = PC_Server_IP_Address;
                    ApplicationConfig.SystemConfig.Port = PC_IP_Port;
                    ApplicationConfig.SystemConfig.Rack = Rack;
                    ApplicationConfig.SystemConfig.Slot = Slot;

                    ApplicationConfig.UpdateData(ApplicationConfig.SystemConfig);
                    CanEdit = false;
                }
                catch (Exception ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    CanEdit = false;
                }
            });

            Edit = new ActionCommand(() =>
            {
                CanEdit = true;
                _ = Logger.Logger.Async_write("Press Edit Setting Config");
            });
            OpenPath = new ActionCommand(() =>
            {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    Data_Folder = folderBrowserDialog.SelectedPath;
                }
            });
            Cancel = new ActionCommand(() =>
            {
                _ = Logger.Logger.Async_write("Press Cancel Setting Config");
                CanEdit = false;
                Data_Folder = ApplicationConfig.SystemConfig.FileLocation;
                PLC_IP_Address = ApplicationConfig.SystemConfig.PLC_IP_Address;
                PC_IP_Port = ApplicationConfig.SystemConfig.Port;
                Rack = ApplicationConfig.SystemConfig.Rack;
                Slot = ApplicationConfig.SystemConfig.Slot;
                COM_Port = ApplicationConfig.SystemConfig.Comport;
                Baudrate = ApplicationConfig.SystemConfig.Baudrate;
                Paritys = ApplicationConfig.SystemConfig.Parity_MB;
                PC_IP_Address = GetLocalIPAddress();
                PC_Server_IP_Address = ApplicationConfig.SystemConfig.PC_Server_IP;
                PC_Server_Port = ApplicationConfig.SystemConfig.PC_Port;
            });
        }


        #region Method
        public static string GetLocalIPAddress()
        {
            try
            {
                var host = Dns.GetHostEntry(Dns.GetHostName());

                foreach (var ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork && ip.ToString().Contains("192.168.0"))
                    {
                        return ip.ToString();
                    }
                }
                throw new Exception("No network adapters with an IPv4 address in the system!");
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
        public void Get_Com()
        {
            ListCom = SerialPort.GetPortNames();

        }
        #endregion
    }
}
