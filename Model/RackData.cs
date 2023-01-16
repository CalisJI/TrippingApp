﻿using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrippingApp.AppConfig;
using System.Text.Json;
using TrippingApp.Runtime;
using S7.Net.Types;
using DateTime = System.DateTime;

namespace TrippingApp.Model
{
    public class RackData
    {
        /// <summary>
        /// Barcode of rack
        /// </summary>
        public string Barcode { get; set; }
        /// <summary>
        /// Infor of sample get by link to database of Hoya
        /// </summary>
        public object RackDetails { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int ProcessKind { get; set; }
        /// <summary>
        /// Temperature of Baths when Rack Enter
        /// </summary>
        public float[] Rack_Temp { get; set; } = new float[11];
        /// <summary>
        /// Time Rack enter Bath
        /// </summary>
        public DateTime[] Time { get; set; } = new DateTime[11];

        public TempVsHumid_Data[] TempervsHumidity { get; set; } = new TempVsHumid_Data[11];
        public string Status { get; set; }
    }
    public static class MonitorRackData
    {
        public static List<RackData> ListRackData { get; set; } = new List<RackData>();

        /// <summary>
        /// 
        /// </summary>
        public static string fileDatename 
        {
            get { return "Data-" + DateTime.Now.ToString("dd-MM-yyyy") + ".json"; }
           
        }
        //readonly static string fileDatename = DateTime.Now.ToString("dd-MM-yyyy");
        //readonly static string DataMonitorStore = ApplicationConfig.HistoryLogger + @"\" + fileDatename;
        public static string DataMonitorStore
        {
            get => ApplicationConfig.HistoryLogger + @"\" + fileDatename;
        }
        public static void CheckFileExist() 
        {
            try
            {
                if (!File.Exists(ApplicationConfig.HistoryLogger + @"\" + fileDatename))
                {
                    File.Create(ApplicationConfig.HistoryLogger + @"\" + fileDatename).Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
           
        }
        public static void SaveHitory()
        {
            CheckFileExist();
            string jObject = System.Text.Json.JsonSerializer.Serialize(ListRackData, typeof(RackData[]));
            using (FileStream fs = new FileStream(DataMonitorStore, FileMode.Open,FileAccess.ReadWrite))
            {
                System.Text.Json.JsonSerializer.Serialize(fs, jObject);
                fs.Close();
            }
            try
            {
                ListRackData.Remove(ListRackData.FirstOrDefault(x => x.Status == "Completed"));
            }
            catch (Exception)
            {

            }
        }
        public static void MoveRack123()
        {
            //Add new Rack into List
            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1) != "")
            {
                RackData rackData = new RackData()
                {
                    Barcode = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1),
                    ProcessKind = Convert.ToInt16(S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P2)),
                    RackDetails = new object(), // Data Assinged From Database Before Trip
                    Rack_Temp = new float[11],
                    TempervsHumidity = new TempVsHumid_Data[11],
                    Time = new DateTime[11],
                    Status = "Aborted"

                };
                rackData.Rack_Temp[0] = Modbus_Communicate.VX4_1.PV;
                rackData.TempervsHumidity[0].Temperature = Modbus_Communicate.TH1.Temperature;
                rackData.TempervsHumidity[0].Humidity = Modbus_Communicate.TH1.Humidity;
                rackData.Time[0] = DateTime.Now;
                ListRackData.Add(rackData);
            }
            var R2 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1) && x.Status == "Aborted").FirstOrDefault();
            if(R2 != null)
            {
                R2.Time[1] = DateTime.Now;
                R2.Rack_Temp[1] = Modbus_Communicate.VX4_2.PV;
                R2.TempervsHumidity[1].Temperature = Modbus_Communicate.TH1.Temperature;
                R2.TempervsHumidity[1].Temperature = Modbus_Communicate.TH1.Humidity;
            }
            var R3 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1) && x.Status == "Aborted").FirstOrDefault();
            if (R3 != null)
            {
                R3.Time[2] = DateTime.Now;
                R3.Rack_Temp[2] = Modbus_Communicate.VX4_3.PV;
                R3.TempervsHumidity[2].Temperature = Modbus_Communicate.TH1.Temperature;
                R3.TempervsHumidity[2].Temperature = Modbus_Communicate.TH1.Humidity;
            }
            SaveHitory();
        }

        public static void MoveRack456()
        {
            //Add new Rack into List
            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1) != "") 
            {
                var R4 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R4 != null)
                {
                    R4.Time[3] = DateTime.Now;
                    R4.Rack_Temp[3] = Modbus_Communicate.VX4_4.PV;
                    R4.TempervsHumidity[3].Temperature = Modbus_Communicate.TH1.Temperature;
                    R4.TempervsHumidity[3].Temperature = Modbus_Communicate.TH1.Humidity;
                }
            }
            else if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1) != "")
            {
                var R5 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R5 != null)
                {
                    R5.Time[4] = DateTime.Now;
                    R5.Rack_Temp[4] = Modbus_Communicate.VX4_5.PV;
                    R5.TempervsHumidity[4].Temperature = Modbus_Communicate.TH1.Temperature;
                    R5.TempervsHumidity[4].Temperature = Modbus_Communicate.TH1.Humidity;
                }
            }
            else if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1) != "")
            {
                var R6 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R6 != null)
                {
                    R6.Time[5] = DateTime.Now;
                    R6.Rack_Temp[5] = Modbus_Communicate.VX4_6.PV;
                    R6.TempervsHumidity[5].Temperature = Modbus_Communicate.TH1.Temperature;
                    R6.TempervsHumidity[5].Temperature = Modbus_Communicate.TH1.Humidity;
                }
            }
            else 
            {
                return;
            }
            SaveHitory();
        }
        public static void MoveRack789_10()
        {
            //Add new Rack into List
            if(S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1) != "")
            {
                var R7 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R7 != null)
                {
                    R7.Time[6] = DateTime.Now;
                    R7.Rack_Temp[6] = Modbus_Communicate.VX4_7.PV;
                    R7.TempervsHumidity[6].Temperature = Modbus_Communicate.TH1.Temperature;
                    R7.TempervsHumidity[6].Temperature = Modbus_Communicate.TH1.Humidity;
                }
            }

            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1) != "")
            {
                var R8 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R8 != null)
                {
                    R8.Time[7] = DateTime.Now;
                    R8.Rack_Temp[7] = Modbus_Communicate.VX4_8.PV;
                    R8.TempervsHumidity[7].Temperature = Modbus_Communicate.TH1.Temperature;
                    R8.TempervsHumidity[7].Temperature = Modbus_Communicate.TH1.Humidity;
                }
            }
            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1) != "")
            {
                var R9 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R9 != null)
                {
                    R9.Time[8] = DateTime.Now;
                    R9.Rack_Temp[8] = Modbus_Communicate.VX4_9.PV;
                    R9.TempervsHumidity[8].Temperature = Modbus_Communicate.TH1.Temperature;
                    R9.TempervsHumidity[8].Temperature = Modbus_Communicate.TH1.Humidity;
                }
            }
            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1) != "")
            {
                var R10 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R10 != null)
                {
                    R10.Time[9] = DateTime.Now;
                    R10.Rack_Temp[9] = Modbus_Communicate.VX4_10.PV;
                    R10.TempervsHumidity[9].Temperature = Modbus_Communicate.TH1.Temperature;
                    R10.TempervsHumidity[9].Temperature = Modbus_Communicate.TH1.Humidity;
                }
            }
            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath11_P1) != "")
            {
                var R11 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath11_P1) && x.Status == "Aborted").FirstOrDefault();
                if (R11 != null)
                {
                    R11.Time[10] = DateTime.Now;
                    R11.Rack_Temp[10] = 0;
                    R11.TempervsHumidity[10].Temperature = Modbus_Communicate.TH1.Temperature;
                    R11.TempervsHumidity[10].Temperature = Modbus_Communicate.TH1.Humidity;
                    R11.Status = "Completed";
                }
            }
            SaveHitory();
        }
    }
}