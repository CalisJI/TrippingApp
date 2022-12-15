using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using EasyModbus;

namespace TrippingApp.Runtime
{
    public static class Modbus_Communicate
    {
        public static ModbusClient ModbusClient = new ModbusClient("192.168.0.8",20000);
        public static void Initial()
        {
            try
            {
                ModbusClient.Connect();
            }
            catch (Exception ex)
            {

                _ = Logger.Logger.Async_write(ex.Message);
            }
        }
        public static void Read_Temp()
        {
            ModbusClient.UnitIdentifier = 1;
            int T0 = ModbusClient.ReadHoldingRegisters(0, 1)[0];

        }
    }
}
