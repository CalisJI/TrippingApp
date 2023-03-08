using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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
        public static TempVsHumid_Data TH1 = new TempVsHumid_Data();
        public static TempVsHumid_Data TH2 = new TempVsHumid_Data();
        public static EnergyAnalyzer EnergyAnalyzer = new EnergyAnalyzer();
        public static ModbusClient ModbusClient = new ModbusClient("192.168.1.35",20002);

        public static void Initial()
        {
            try
            {
                var a = PLC_Query.CheckConnect("192.168.1.35");
                if (a)
                {
                    Timer.Interval = new TimeSpan(0,0,0,0,1500);
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
                    //Console.WriteLine("Bath1: " + VX4_1.PV);
                    //Console.WriteLine("Bath2: " + VX4_2.PV);
                    //Console.WriteLine("Bath3: " + VX4_3.PV);
                    //Console.WriteLine("Bath4: " + VX4_4.PV);
                    //Console.WriteLine("Bath5: " + VX4_5.PV);
                    //Console.WriteLine("Bath6: " + VX4_6.PV);
                    //Console.WriteLine("Bath7: " + VX4_7.PV);
                    //Console.WriteLine("Bath8: " + VX4_8.PV);
                    //Console.WriteLine("Bath9: " + VX4_9.PV);
                    //Console.WriteLine("Bath10: " + VX4_10.PV);
                    //Console.WriteLine("Bath11: " + VX4_10.PV);

                    //Console.WriteLine("Temperature 1: " + TH1.Temperature);
                    //Console.WriteLine("Temperature 2: " + TH2.Temperature);

                    //Console.WriteLine("Humidity 1: " + TH1.Humidity);
                    //Console.WriteLine("Humidity 2: " + TH2.Humidity);

                    //Console.WriteLine(string.Format("{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}-{11}-{12}-{13}-{14}" +
                    //    "-{15}-{16}-{17}" +
                    //    "-{18}--{19}--{20}--{21}--{22}--{23}--{24}--{25}--{26}--{27}--{28}--{29}--{30}",
                    //    EnergyAnalyzer.L1_Voltage,
                    //    EnergyAnalyzer.L2_Voltage,
                    //    EnergyAnalyzer.L3_Voltage,
                    //    EnergyAnalyzer.L12_Voltage,
                    //    EnergyAnalyzer.L23_Voltage,
                    //    EnergyAnalyzer.L31_Voltage,
                    //    EnergyAnalyzer.L1_Current,
                    //    EnergyAnalyzer.L2_Current,
                    //    EnergyAnalyzer.L3_Current,
                    //    EnergyAnalyzer.L1_Frequency,
                    //    EnergyAnalyzer.L2_Frequency,
                    //    EnergyAnalyzer.L3_Frequency,
                    //    EnergyAnalyzer.L1_ActivePower,
                    //    EnergyAnalyzer.L2_ActivePower,
                    //    EnergyAnalyzer.L3_ActivePower,
                    //    EnergyAnalyzer.Total_Active_Power,
                    //    VX4_1.PV,
                    //    VX4_2.PV,
                    //    VX4_3.PV,
                    //    VX4_4.PV,
                    //    VX4_5.PV,
                    //    VX4_6.PV,
                    //    VX4_7.PV,
                    //    VX4_8.PV,
                    //    VX4_9.PV,
                    //    VX4_10.PV,
                    //    VX4_11.PV,
                    //    TH1.Temperature,
                    //    TH2.Temperature,
                    //    TH1.Humidity,
                    //    TH2.Humidity));
                    //Console.WriteLine(nameof(EnergyAnalyzer.L1_Voltage) + " :" + EnergyAnalyzer.L1_Voltage);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L2_Voltage) + " :" + EnergyAnalyzer.L2_Voltage);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L3_Voltage) + " :" + EnergyAnalyzer.L3_Voltage);

                    //Console.WriteLine(nameof(EnergyAnalyzer.L12_Voltage) + " :" + EnergyAnalyzer.L12_Voltage);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L23_Voltage) + " :" + EnergyAnalyzer.L23_Voltage);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L31_Voltage) + " :" + EnergyAnalyzer.L31_Voltage);

                    //Console.WriteLine(nameof(EnergyAnalyzer.L1_Current) + " :" + EnergyAnalyzer.L1_Current);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L2_Current) + " :" + EnergyAnalyzer.L2_Current);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L3_Current) + " :" + EnergyAnalyzer.L3_Current);

                    //Console.WriteLine(nameof(EnergyAnalyzer.L1_Frequency) + " :" + EnergyAnalyzer.L1_Frequency);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L2_Frequency) + " :" + EnergyAnalyzer.L2_Frequency);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L3_Frequency) + " :" + EnergyAnalyzer.L3_Frequency);

                    //Console.WriteLine(nameof(EnergyAnalyzer.L1_ActivePower) + " :" + EnergyAnalyzer.L1_ActivePower);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L2_ActivePower) + " :" + EnergyAnalyzer.L2_ActivePower);
                    //Console.WriteLine(nameof(EnergyAnalyzer.L3_ActivePower) + " :" + EnergyAnalyzer.L3_ActivePower);

                    //Console.WriteLine(nameof(EnergyAnalyzer.Total_Active_Power) + " :" + EnergyAnalyzer.Total_Active_Power);
                }
            }
            catch (Exception ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);
            }
        }
        private static int Count = 0;
        private static void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Count++;
                Read_Energy();
                if (Count == 8)
                {
                    Read_Temp();
                    Read_TemvsHum();
                    Count = 0;
                }
               
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
            if (!Worker.IsBusy) 
            {
                Worker.RunWorkerAsync();
            }
        }
        public static void Write_Data(int ID,float value) 
        {
        
        }
        public static void Read_Temp()
        {
            try
            {
                ModbusClient.Connect();
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
        public static void Read_TemvsHum()
        {
            try
            {
                ModbusClient.Connect();
                ModbusClient.UnitIdentifier = 13;
                int[] TvsH1 = ModbusClient.ReadHoldingRegisters(0, 2);
                TH1.Temperature = TvsH1[1] / 10f;
                TH1.Humidity = TvsH1[0] / 10f;
                ModbusClient.UnitIdentifier = 14;
                int[] TvsH2 = ModbusClient.ReadHoldingRegisters(0, 2);
                TH2.Temperature = TvsH2[1] / 10f;
                TH2.Humidity = TvsH2[0] / 10f;
                ModbusClient.Disconnect();
            }
            catch (Exception ex)
            {
                _ = Logger.Logger.Async_write("Read temperature vs humydity" + ex.Message);
            }
        }

        public static void Read_Energy()
        {
            try
            {
                ModbusClient.Connect();
                ModbusClient.UnitIdentifier = 22;
                int[] energy = ModbusClient.ReadHoldingRegisters(4002, 18);
                EnergyAnalyzer.L1_Voltage = energy[0] / 10f;
                EnergyAnalyzer.L2_Voltage = energy[1] / 10f;
                EnergyAnalyzer.L3_Voltage = energy[2] / 10f;

                EnergyAnalyzer.L12_Voltage = energy[3] / 10f;
                EnergyAnalyzer.L23_Voltage = energy[4] / 10f;
                EnergyAnalyzer.L31_Voltage = energy[5] / 10f;

                EnergyAnalyzer.L1_Current = energy[6] / 10f;
                EnergyAnalyzer.L2_Current = energy[7] / 10f;
                EnergyAnalyzer.L3_Current = energy[8] / 10f;

                EnergyAnalyzer.L1_Frequency = energy[10] / 100f;
                EnergyAnalyzer.L2_Frequency = energy[11] / 100f;
                EnergyAnalyzer.L3_Frequency = energy[12] / 100f;

                EnergyAnalyzer.L1_ActivePower = energy[13] / 10f;
                EnergyAnalyzer.L2_ActivePower = energy[14] / 10f;
                EnergyAnalyzer.L3_ActivePower = energy[15] / 10f;
                EnergyAnalyzer.Total_Active_Power = energy[16] / 10f;

            }
            catch (Exception ex)
            {
                _ = Logger.Logger.Async_write("Read Energy" + ex.Message);
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
    public class TempVsHumid_Data
    {
        public float Temperature { get; set; }
        public float Humidity { get; set; }
    }
    public class EnergyAnalyzer
    {
        public float L1_Voltage { get; set; }
        public float L2_Voltage { get; set; }
        public float L3_Voltage { get; set; }
        public float L12_Voltage { get; set; }
        public float L23_Voltage { get; set; }
        public float L31_Voltage { get; set; }
        public float L1_Current { get; set; }
        public float L2_Current { get; set; }
        public float L3_Current { get; set; }
        public float L1_Frequency { get; set; }
        public float L2_Frequency { get; set; }
        public float L3_Frequency { get; set; }
        public float L1_ActivePower { get; set; }
        public float L2_ActivePower { get; set; }
        public float L3_ActivePower { get; set; }
        public float Total_Active_Power { get; set; }
    }
}
