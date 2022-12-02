using System;
using System.Collections.Generic;
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
        public string PLC_IP_Address { get; set; }
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
        public double DipTimeTranfer { get; set; }
        public double DipP1 { get; set; }
        public double Dip1P2 { get; set; }
        public double Dip2P2 { get; set; }
        public double Dip1P3 { get; set; }
        public double Dip2P3 { get; set; }
        public double Dip1P4 { get; set; }
        public double Dip2P4 { get; set; }
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
    }
}
