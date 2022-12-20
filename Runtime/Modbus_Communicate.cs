using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using EasyModbus;

namespace TrippingApp.Runtime
{
    public static class Modbus_Communicate
    {
        public static DispatcherTimer Timer = new DispatcherTimer();
        public static bool Check_Error = false;
        public static BackgroundWorker Worker = new BackgroundWorker();
        public static Temperature_Data VX4_1 = new Temperature_Data();
        public static Temperature_Data VX4_2 = new Temperature_Data();
        public static Temperature_Data VX4_3 = new Temperature_Data();
        public static Temperature_Data VX4_4 = new Temperature_Data();
        public static Temperature_Data VX4_5 = new Temperature_Data();
        public static Temperature_Data VX4_6 = new Temperature_Data();
        public static Temperature_Data VX4_7 = new Temperature_Data();
        public static Temperature_Data VX4_8 = new Temperature_Data();
        public static Temperature_Data VX4_9 = new Temperature_Data();
        public static Temperature_Data VX4_10 = new Temperature_Data();
        public static Temperature_Data VX4_11 = new Temperature_Data();

        public static ModbusClient ModbusClient = new ModbusClient("192.168.1.35",20000);
        public static void Initial()
        {
            try
            {
                var a = PLC_Query.CheckConnect("192.168.1.35");
                if (a)
                {
                    Timer.Interval = new TimeSpan(0, 0, 10);
                    Timer.Tick += Timer_Tick;
                    Timer.Start();
                    Worker.DoWork += Worker_DoWork;
                    Worker.RunWorkerCompleted += Worker_RunWorkerCompleted;
                    Worker.WorkerReportsProgress = true;
                    Worker.WorkerSupportsCancellation = true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("RTU Connection is not valid");
                }
             
            }
            catch (Exception ex)
            {

                _ = Logger.Logger.Async_write(ex.Message);
            }
        }

        private static void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                if (!Check_Error)
                {
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank1 = VX4_1.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank2 = VX4_2.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank3 = VX4_3.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank4 = VX4_4.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank5 = VX4_5.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank6 = VX4_6.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank7 = VX4_7.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank8 = VX4_8.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank9 = VX4_9.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank10 = VX4_10.PV;
                    PLC_Query.DATA_TEMPERATURE.Nhiet_Do_Tank11 = VX4_11.PV;

                    PLC_Query.WriteData(PLC_Query.DATA_TEMPERATURE, 24);
                }
            }
            catch (Exception ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);
            }
         



        }

        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Read_Temp();
                Check_Error = false;
            }
            catch (Exception ex)
            {
                Check_Error = true;
                _ = Logger.Logger.Async_write(ex.Message);
            }
        }

        public static void ShutDown()
        {
            if (Timer.IsEnabled)
            {
                Timer.Stop();
            }
        }
        private static void Timer_Tick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public static void Read_Temp()
        {
            try
            {
                if (!ModbusClient.Connected)
                {
                    ModbusClient.Connect();
                }
                ModbusClient.UnitIdentifier = 1;
                int[] T0 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_1.PV = T0[0] / (float)Math.Pow(10, T0[3]);
                VX4_1.SV = T0[1] / (float)Math.Pow(10, T0[3]);
                VX4_1.TSV = T0[2] / (float)Math.Pow(10, T0[3]);
                ModbusClient.UnitIdentifier = 2;
                int[] T1 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_2.PV = T1[0] / (float)Math.Pow(10, T1[3]);
                VX4_2.SV = T1[1] / (float)Math.Pow(10, T1[3]);
                VX4_2.TSV = T1[2] / (float)Math.Pow(10, T1[3]);

                ModbusClient.UnitIdentifier = 3;
                int[] T2 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_3.PV = T2[0] / (float)Math.Pow(10, T2[3]);
                VX4_3.SV = T2[1] / (float)Math.Pow(10, T2[3]);
                VX4_3.TSV = T2[2] / (float)Math.Pow(10, T2[3]);

                ModbusClient.UnitIdentifier = 4;
                int[] T3 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_4.PV = T3[0] / (float)Math.Pow(10, T3[3]);
                VX4_4.SV = T3[1] / (float)Math.Pow(10, T3[3]);
                VX4_4.TSV = T3[2] / (float)Math.Pow(10, T3[3]);

                ModbusClient.UnitIdentifier = 5;
                int[] T4 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_5.PV = T4[0] / (float)Math.Pow(10, T4[3]);
                VX4_5.SV = T4[1] / (float)Math.Pow(10, T4[3]);
                VX4_5.TSV = T4[2] / (float)Math.Pow(10, T4[3]);

                ModbusClient.UnitIdentifier = 6;
                int[] T5 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_6.PV = T5[0] / (float)Math.Pow(10, T5[3]);
                VX4_6.SV = T5[1] / (float)Math.Pow(10, T5[3]);
                VX4_6.TSV = T5[2] / (float)Math.Pow(10, T5[3]);

                ModbusClient.UnitIdentifier = 7;
                int[] T6 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_7.PV = T6[0] / (float)Math.Pow(10, T6[3]);
                VX4_7.SV = T6[1] / (float)Math.Pow(10, T6[3]);
                VX4_7.TSV = T6[2] / (float)Math.Pow(10, T6[3]);

                ModbusClient.UnitIdentifier = 8;
                int[] T7 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_8.PV = T7[0] / (float)Math.Pow(10, T7[3]);
                VX4_8.SV = T7[1] / (float)Math.Pow(10, T7[3]);
                VX4_8.TSV = T7[2] / (float)Math.Pow(10, T7[3]);

                ModbusClient.UnitIdentifier = 9;
                int[] T8 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_9.PV = T8[0] / (float)Math.Pow(10, T8[3]);
                VX4_9.SV = T8[1] / (float)Math.Pow(10, T8[3]);
                VX4_9.TSV = T8[2] / (float)Math.Pow(10, T8[3]);
                ModbusClient.UnitIdentifier = 10;
                int[] T9 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_10.PV = T9[0] / (float)Math.Pow(10, T9[3]);
                VX4_10.SV = T9[1] / (float)Math.Pow(10, T9[3]);
                VX4_10.TSV = T9[2] / (float)Math.Pow(10, T9[3]);

                ModbusClient.UnitIdentifier = 11;
                int[] T10 = ModbusClient.ReadHoldingRegisters(0, 4);

                VX4_11.PV = T10[0] / (float)Math.Pow(10, T10[3]);
                VX4_11.SV = T10[1] / (float)Math.Pow(10, T10[3]);
                VX4_11.TSV = T10[2] / (float)Math.Pow(10, T10[3]);
                ModbusClient.Disconnect();
            }
            catch (Exception)
            {

            }
            
        }
    }

    public class Temperature_Data
    {
        public float PV { get; set; }
        public float SV { get; set; }
        public float TSV { get; set; }
        public int DP_P { get; set; }
    }
}
