using System;
using System.Collections.Generic;
using System.Data;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrippingApp.AppConfig
{
    public class SystemConfig
    {
        public SystemConfig()
        {
            DataFolder = "HYD";
        }
        #region File Configuration
        public string DataFolder { get; set; }
        public string FileLocation { get; set; }
        public string Config2 { get; set; }
        #endregion
        #region PLC Configuration
        public string PC_IP_Address { get; set; }
        public string PLC_IP_Address { get; set; } = "192.168.1.25";
        public int Port { get; set; }
        public short Rack { get; set; }
        public short Slot { get; set; }
        #endregion

        #region Server_DataBase
        public string Server { get; set; }
        public string PWD { get; set; }
        public string Uid { get; set; }
        public string Database { get; set; }
        #endregion

        #region Press Parameter
        public DataTable Robot_Table_Type { get; set; } = new DataTable("Robot_Type");
        #endregion


        #region Serial Communication
        public int Baudrate { get; set; }
        //public int Databit { get; set; }
        public Parity Parity_MB { get; set; }
        //public StopBits StopBit_MB { get; set; }
        public string Comport { get; set; }
        #endregion


        #region Network Database
        public string PC_Server_IP { get; set; }
        public int PC_Port { get; set; }
        #endregion

        #region Camera Information
        /// <summary>
        /// connecting IP of Camera Sensor Cognex
        /// </summary>
        public string CameraIP { get; set; } = "192.168.1.64";
        /// <summary>
        /// UserName of Account Camera
        /// </summary>
        public string UserName { get; set; } = "admin";
        /// <summary>
        /// Password of Account Camera
        /// </summary>
        public string Password { get; set; }
        #endregion


        public bool DataMethod { get; set; } // use to enable orr disable send data to hoya


    }
}
