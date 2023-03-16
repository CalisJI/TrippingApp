using System;
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
using System.Globalization;
using TrippingApp.APIController;
using Newtonsoft.Json;
using JsonIgnoreAttribute = Newtonsoft.Json.JsonIgnoreAttribute;

namespace TrippingApp.Model
{
    //public class RackData
    //{
    //    /// <summary>
    //    /// Barcode of rack
    //    /// </summary>
    //    public string Barcode { get; set; }
    //    /// <summary>
    //    /// Infor of sample get by link to database of Hoya
    //    /// </summary>
    //    public object RackDetails { get; set; }
    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public int ProcessKind { get; set; }
    //    /// <summary>
    //    /// Temperature of Baths when Rack Enter
    //    /// </summary>
    //    public float[] Rack_Temp { get; set; } = new float[11];
    //    /// <summary>
    //    /// Time Rack enter Bath
    //    /// </summary>
    //    public DateTime[] Time { get; set; } = new DateTime[11];

    //    public TempVsHumid_Data[] TempervsHumidity { get; set; } = new TempVsHumid_Data[11];
    //    public string Status { get; set; }
    //}

    //public static class MonitorRackData
    //{
    //    public static List<RackData> ListRackData { get; set; } = new List<RackData>();

    //    /// <summary>
    //    /// 
    //    /// </summary>
    //    public static string fileDatename 
    //    {
    //        get { return "Data-" + DateTime.Now.ToString("dd-MM-yyyy") + ".json"; }

    //    }
    //    //readonly static string fileDatename = DateTime.Now.ToString("dd-MM-yyyy");
    //    //readonly static string DataMonitorStore = ApplicationConfig.HistoryLogger + @"\" + fileDatename;
    //    public static string DataMonitorStore
    //    {
    //        get => ApplicationConfig.HistoryLogger + @"\" + fileDatename;
    //    }
    //    public static void TrackerData() 
    //    {

    //    }
    //    public static void CheckFileExist() 
    //    {
    //        try
    //        {
    //            if (!File.Exists(DataMonitorStore))
    //            {
    //                File.Create(DataMonitorStore).Close();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Windows.Forms.MessageBox.Show(ex.Message);
    //        }

    //    }
    //    public static void SaveHitory()
    //    {
    //        CheckFileExist();
    //        string jObject = System.Text.Json.JsonSerializer.Serialize(ListRackData, typeof(List<RackData>));
    //        using (FileStream fs = new FileStream(DataMonitorStore, FileMode.Open,FileAccess.ReadWrite))
    //        {
    //            System.Text.Json.JsonSerializer.Serialize(fs, jObject);
    //            fs.Close();
    //        }
    //        try
    //        {
    //            ListRackData.Remove(ListRackData.FirstOrDefault(x => x.Status == "Completed"));
    //        }
    //        catch (Exception)
    //        {

    //        }
    //    }
    //    public static void MoveRack123()
    //    {
    //        //Add new Rack into List
    //        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1) != "")
    //        {
    //            RackData rackData = new RackData()
    //            {
    //                Barcode = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1),
    //                ProcessKind = Convert.ToInt16(S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P2)),
    //                RackDetails = new object(), // Data Assinged From Database Before Trip
    //                Rack_Temp = new float[11],
    //                TempervsHumidity = new TempVsHumid_Data[11],
    //                Time = new DateTime[11],
    //                Status = "Aborted"

    //            };
    //            for (int i = 0; i < 11; i++)
    //            {
    //                rackData.TempervsHumidity[i] = new TempVsHumid_Data();
    //            }
    //            rackData.Rack_Temp[0] = Modbus_Communicate.VX4_1.PV;
    //            try
    //            {
    //                rackData.TempervsHumidity[0].Temperature = Modbus_Communicate.TH1.Temperature;
    //                rackData.TempervsHumidity[0].Humidity = Modbus_Communicate.TH1.Humidity;

    //            }
    //            catch (Exception ex)
    //            {
    //                rackData.TempervsHumidity[0].Temperature = 0;
    //                rackData.TempervsHumidity[0].Humidity = 0;
    //                Console.WriteLine("Has No Data Temperature");
    //            }
    //            rackData.Time[0] = DateTime.Now;
    //            ListRackData.Add(rackData);
    //        }
    //        var R2 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1) && x.Status == "Aborted").FirstOrDefault();
    //        if(R2 != null)
    //        {
    //            R2.Time[1] = DateTime.Now;
    //            R2.Rack_Temp[1] = Modbus_Communicate.VX4_2.PV;
    //            try
    //            {
    //                R2.TempervsHumidity[1].Temperature = Modbus_Communicate.TH1.Temperature;
    //                R2.TempervsHumidity[1].Humidity = Modbus_Communicate.TH1.Humidity;
    //            }
    //            catch (Exception)
    //            {
    //                R2.TempervsHumidity[1].Temperature = 0;
    //                R2.TempervsHumidity[1].Humidity = 0;
    //            }

    //        }
    //        var R3 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1) && x.Status == "Aborted").FirstOrDefault();
    //        if (R3 != null)
    //        {
    //            R3.Time[2] = DateTime.Now;
    //            R3.Rack_Temp[2] = Modbus_Communicate.VX4_3.PV;
    //            try
    //            {
    //                R3.TempervsHumidity[2].Temperature = Modbus_Communicate.TH1.Temperature;
    //                R3.TempervsHumidity[2].Humidity = Modbus_Communicate.TH1.Humidity;
    //            }
    //            catch (Exception)
    //            {
    //                R3.TempervsHumidity[2].Temperature = 0;
    //                R3.TempervsHumidity[2].Humidity = 0;
    //            }

    //        }
    //        SaveHitory();
    //    }

    //    public static void MoveRack456()
    //    {
    //        //Add new Rack into List
    //        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1) != "") 
    //        {
    //            var R4 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R4 != null)
    //            {
    //                R4.Time[3] = DateTime.Now;
    //                R4.Rack_Temp[3] = Modbus_Communicate.VX4_4.PV;
    //                try
    //                {
    //                    R4.TempervsHumidity[3].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R4.TempervsHumidity[3].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception)
    //                {

    //                    R4.TempervsHumidity[3].Temperature = 0;
    //                    R4.TempervsHumidity[3].Humidity = 0;
    //                }
    //            }
    //        }
    //        else if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1) != "")
    //        {
    //            var R5 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R5 != null)
    //            {
    //                R5.Time[4] = DateTime.Now;
    //                R5.Rack_Temp[4] = Modbus_Communicate.VX4_5.PV;
    //                try
    //                {
    //                    R5.TempervsHumidity[4].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R5.TempervsHumidity[4].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception)
    //                {
    //                    R5.TempervsHumidity[4].Temperature = 0;
    //                    R5.TempervsHumidity[4].Humidity = 0;
    //                }
    //            }
    //        }
    //        else if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1) != "")
    //        {
    //            var R6 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R6 != null)
    //            {
    //                R6.Time[5] = DateTime.Now;
    //                R6.Rack_Temp[5] = Modbus_Communicate.VX4_6.PV;
    //                try
    //                {
    //                    R6.TempervsHumidity[5].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R6.TempervsHumidity[5].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception ex)
    //                {

    //                    R6.TempervsHumidity[5].Temperature = 0;
    //                    R6.TempervsHumidity[5].Humidity = 0;
    //                }
    //            }
    //        }
    //        else 
    //        {
    //            return;
    //        }
    //        SaveHitory();
    //    }
    //    public static void MoveRack789_10()
    //    {
    //        //Add new Rack into List
    //        if(S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1) != "")
    //        {
    //            var R7 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R7 != null)
    //            {
    //                R7.Time[6] = DateTime.Now;
    //                R7.Rack_Temp[6] = Modbus_Communicate.VX4_7.PV;
    //                try
    //                {
    //                    R7.TempervsHumidity[6].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R7.TempervsHumidity[6].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception)
    //                {

    //                    R7.TempervsHumidity[6].Temperature = 0;
    //                    R7.TempervsHumidity[6].Humidity = 0;
    //                }
    //            }
    //        }

    //        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1) != "")
    //        {
    //            var R8 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R8 != null)
    //            {
    //                R8.Time[7] = DateTime.Now;
    //                R8.Rack_Temp[7] = Modbus_Communicate.VX4_8.PV;
    //                try
    //                {
    //                    R8.TempervsHumidity[7].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R8.TempervsHumidity[7].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception)
    //                {
    //                    R8.TempervsHumidity[7].Temperature = 0;
    //                    R8.TempervsHumidity[7].Humidity = 0;
    //                }
    //            }
    //        }
    //        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1) != "")
    //        {
    //            var R9 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R9 != null)
    //            {
    //                R9.Time[8] = DateTime.Now;
    //                R9.Rack_Temp[8] = Modbus_Communicate.VX4_9.PV;
    //                try
    //                {
    //                    R9.TempervsHumidity[8].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R9.TempervsHumidity[8].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception)
    //                {
    //                    R9.TempervsHumidity[8].Temperature = 0;
    //                    R9.TempervsHumidity[8].Humidity = 0;
    //                }
    //            }
    //        }
    //        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1) != "")
    //        {
    //            var R10 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R10 != null)
    //            {
    //                R10.Time[9] = DateTime.Now;
    //                R10.Rack_Temp[9] = Modbus_Communicate.VX4_10.PV;
    //                try
    //                {
    //                    R10.TempervsHumidity[9].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R10.TempervsHumidity[9].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception)
    //                {
    //                    R10.TempervsHumidity[9].Temperature = 0;
    //                    R10.TempervsHumidity[9].Humidity = 0;
    //                }
    //            }
    //        }
    //        if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath11_P1) != "")
    //        {
    //            var R11 = ListRackData.Where(x => x.Barcode == S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath11_P1) && x.Status == "Aborted").FirstOrDefault();
    //            if (R11 != null)
    //            {
    //                R11.Time[10] = DateTime.Now;
    //                R11.Rack_Temp[10] = 0;
    //                try
    //                {
    //                    R11.TempervsHumidity[10].Temperature = Modbus_Communicate.TH1.Temperature;
    //                    R11.TempervsHumidity[10].Humidity = Modbus_Communicate.TH1.Humidity;
    //                }
    //                catch (Exception)
    //                {
    //                    R11.TempervsHumidity[10].Temperature = 0;
    //                    R11.TempervsHumidity[10].Humidity = 0;
    //                }
    //                R11.Status = "Completed";
    //            }
    //        }
    //        SaveHitory();
    //    }
    //}


    //public static class TrackingProces 
    //{
    //    public static List<RackObject> ListRackData { get; set; } = new List<RackObject>();

    //    public static string fileDatename
    //    {
    //        get { return "DataHoya-" + DateTime.Now.ToString("dd-MM-yyyy") + ".json"; }

    //    }
    //    //readonly static string fileDatename = DateTime.Now.ToString("dd-MM-yyyy");
    //    //readonly static string DataMonitorStore = ApplicationConfig.HistoryLogger + @"\" + fileDatename;
    //    public static string DataMonitorStore
    //    {
    //        get => ApplicationConfig.HistoryLogger + @"\" + fileDatename;
    //    }
    //    public static void TrackerData()
    //    {

    //    }
    //    public static void CheckFileExist()
    //    {
    //        try
    //        {
    //            if (!File.Exists(DataMonitorStore))
    //            {
    //                File.Create(DataMonitorStore).Close();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            System.Windows.Forms.MessageBox.Show(ex.Message);
    //        }

    //    }
    //    public static void SaveHitory()
    //    {
    //        CheckFileExist();
    //        try
    //        {
    //            string jObject = System.Text.Json.JsonSerializer.Serialize(ListRackData, typeof(List<RackObject>));
    //            using (FileStream fs = new FileStream(DataMonitorStore, FileMode.Open, FileAccess.ReadWrite))
    //            {
    //                System.Text.Json.JsonSerializer.Serialize(fs, jObject);
    //                fs.Close();
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine(ex.Message);
    //            _ = Logger.Logger.Async_write(ex.Message);
    //        }
    //    }

    //    public static void GetHistory(DateTime Time)
    //    {
    //        string directoryPath = ApplicationConfig.HistoryLogger;
    //        string dateFormat = ""+Time.Day.ToString("D2")+"-"+Time.Month.ToString("D2")+"-"+Time.Year.ToString();
    //        string searchPattern = "Data-*.json";

    //        var filteredFiles = Directory.GetFiles(directoryPath, searchPattern)
    //            .Where(file =>
    //            {
    //                string fileName = Path.GetFileNameWithoutExtension(file);
    //                string datePart = fileName.Replace("Data-", "");
    //                return DateTime.TryParseExact(datePart, dateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
    //            });

    //        foreach (var file in filteredFiles)
    //        {
    //            Console.WriteLine(file);
    //        }
    //    }
    //}


    public class RackObject
    {
        public string RackBarcode { get; set; }
        public string NGType { get; set; }

        [JsonIgnore]
        public HoyaData Data { get; set; }
        public string RackDetails
        {
            get
            {
                return JsonConvert.SerializeObject(Data);
            }
            set
            {
                Data = JsonConvert.DeserializeObject<HoyaData>(value);
            }
        }
        public BathInformation Bath1_Infor { get; set; } = new BathInformation();
        public BathInformation Bath2_Infor { get; set; } = new BathInformation();
        public BathInformation Bath3_Infor { get; set; } = new BathInformation();
        public BathInformation Bath4_Infor { get; set; } = new BathInformation();
        public BathInformation Bath5_Infor { get; set; } = new BathInformation();
        public BathInformation Bath6_Infor { get; set; } = new BathInformation();
        public BathInformation Bath7_Infor { get; set; } = new BathInformation();
        public BathInformation Bath8_Infor { get; set; } = new BathInformation();
        public BathInformation Bath9_Infor { get; set; } = new BathInformation();
        public BathInformation Bath10_Infor { get; set; } = new BathInformation();
        public Status RackStatus { get; set; }
    }
    public enum Status
    {
        Done,
        Inprocess
    }
    public class BathInformation
    {
        public float BathTemper { get; set; }
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }
    }

    public static class SyncProcessData
    {
        public static List<RackObject> RackObjects = new List<RackObject>();

        public static void MovedRack123()
        {
            PLC_Query.Get_ListCodeChar();
            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1) != "")
            {
                RackObject rackObject = new RackObject()
                {
                    RackBarcode = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1),
                    //Data = GlobalDataHoya.HoyadataDict[S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1)],
                    Data = new HoyaData(),
                    RackStatus = Status.Inprocess,
                    NGType = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P2),
                    Bath1_Infor = new BathInformation()
                    {
                        BathTemper = GlobalDataHoya.Nhietdo.Temp1,
                        TimeIn = DateTime.Now,
                        TimeOut = new DateTime()
                    },
                    Bath2_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath3_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath4_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath5_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath6_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath7_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath8_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath9_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                    Bath10_Infor = new BathInformation()
                    {
                        BathTemper = 0,
                        TimeIn = new DateTime(),
                        TimeOut = new DateTime()
                    },
                };
                RackObjects.Add(rackObject);
                HistoryLogger.AddRackObject(rackObject);
            }
            string code2 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1);
            string type2 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P2);
            var R2 = RackObjects.Where(x => x.RackBarcode == code2 && x.NGType == type2 && code2 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R2!=null)
            {
                R2.Bath2_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp2;
                R2.Bath2_Infor.TimeIn = DateTime.Now;
                HistoryLogger.EditRackObject(R2);
            }
            
            
            string code3 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1);
            string type3 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P2);
            var R3 = RackObjects.Where(x => x.RackBarcode == code3 && x.NGType == type3 && code3 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R3 != null) 
            {
                R3.Bath3_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp3;
                R3.Bath3_Infor.TimeIn = DateTime.Now;
                HistoryLogger.EditRackObject(R3);
            }
           


        }
        public static void MovedRack456()
        {
            PLC_Query.Get_ListCodeChar();

            if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1) != "")
            {
                string code4 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1);
                string type4 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P2);
                var R4 = RackObjects.Where(x => x.RackBarcode == code4 && x.NGType == type4 && code4 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
                if (R4!=null)
                {
                    R4.Bath4_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp4;
                    R4.Bath4_Infor.TimeIn = DateTime.Now;
                    HistoryLogger.EditRackObject(R4);
                }
            }
            else if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1) != "")
            {
                string code5 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1);
                string type5 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P2);
                var R5 = RackObjects.Where(x => x.RackBarcode == code5 && x.NGType == type5 && code5 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
                if (R5 != null)
                {
                    R5.Bath5_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp5;
                    R5.Bath5_Infor.TimeIn = DateTime.Now;
                    HistoryLogger.EditRackObject(R5);
                }
            
            }
            else if (S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1) != "")
            {
                string code6 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1);
                string type6 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P2);
                var R6 = RackObjects.Where(x => x.RackBarcode == code6 && x.NGType == type6 && code6 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
                if (R6 != null)
                {
                    R6.Bath6_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp6;
                    R6.Bath6_Infor.TimeIn = DateTime.Now;
                    HistoryLogger.EditRackObject(R6);
                }
            }
            else
            {
                return;
            }
        }

        public static void MovedRack789_10()
        {
            PLC_Query.Get_ListCodeChar();
            string code7 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1);
            string type7 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P2);
            var R7 = RackObjects.Where(x => x.RackBarcode == code7 && x.NGType == type7 && code7 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
            if (R7 != null) 
            {
                R7.Bath7_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp7;
                R7.Bath7_Infor.TimeIn = DateTime.Now;
                HistoryLogger.EditRackObject(R7);
            }
            string code8 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1);
            string type8 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P2);
            var R8 = RackObjects.Where(x => x.RackBarcode == code8 && x.NGType == type8 && code8 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
            if (R8 != null)
            {
                R8.Bath8_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp8;
                R8.Bath8_Infor.TimeIn = DateTime.Now;
                HistoryLogger.EditRackObject(R8);
            }
            string code9 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1);
            string type9 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P2);
            var R9 = RackObjects.Where(x => x.RackBarcode == code9 && x.NGType == type9 && code9 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
            if (R9 != null)
            {
                R9.Bath9_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp9;
                R9.Bath9_Infor.TimeIn = DateTime.Now;
                HistoryLogger.EditRackObject(R9);
            }

            string code10 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1);
            string type10 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P2);
            var R10 = RackObjects.Where(x => x.RackBarcode == code10 && x.NGType == type10 && code10 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
            if (R10 != null)
            {
                R10.Bath10_Infor.BathTemper = GlobalDataHoya.Nhietdo.Temp10;
                R10.Bath10_Infor.TimeIn = DateTime.Now;
                HistoryLogger.EditRackObject(R10);
            }

            string code11 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath11_P1);
            string type11 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath11_P2);
            var R11 = RackObjects.Where(x => x.RackBarcode == code11 && x.NGType == type11 && code11 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
            if (R11 != null)
            {
                R11.RackStatus = Status.Done;
                HistoryLogger.EditRackObject(R11);
                GlobalDataHoya.HoyadataDict[R11.RackBarcode] = null;

            }
        }

        public static void TripDoneRack_123()
        {
            string code1 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1);
            string type1 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P2);
            var R1 = RackObjects.Where(x => x.RackBarcode == code1 && x.NGType == type1 && code1 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R1 != null)
            {
                R1.Bath1_Infor.TimeOut = DateTime.Now;
                HistoryLogger.EditRackObject(R1);
            }


            string code2 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1);
            string type2 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P2);
            var R2 = RackObjects.Where(x => x.RackBarcode == code2 && x.NGType == type2 && code2 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R2 != null)
            {
                R2.Bath2_Infor.TimeOut = DateTime.Now;
                HistoryLogger.EditRackObject(R2);
            }

            string code3 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1);
            string type3 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P2);
            var R3 = RackObjects.Where(x => x.RackBarcode == code3 && x.NGType == type3 && code3 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R3 != null)
            {
                R3.Bath3_Infor.TimeOut = DateTime.Now;
                HistoryLogger.EditRackObject(R3);
            }
            DateTime dateTime = DateTime.Parse("2023-03-16 17:49:57");
            //var R4 = new RackObject()
            //{
            //    RackBarcode = "HY-004",
            //    Data = new HoyaData(),
            //    NGType = "2",
            //    Bath1_Infor = new BathInformation() { TimeIn = dateTime, BathTemper = 10, TimeOut = DateTime.Now },
            //    Bath2_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 49, TimeOut = DateTime.Now },
            //    Bath3_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 61, TimeOut = DateTime.Now },
            //    Bath4_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 54, TimeOut = DateTime.Now },
            //    Bath5_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 55, TimeOut = DateTime.Now },
            //    Bath6_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 49, TimeOut = DateTime.Now },
            //    Bath7_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 74, TimeOut = DateTime.Now },
            //    Bath8_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 49, TimeOut = DateTime.Now },
            //    Bath9_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 49, TimeOut = DateTime.Now },
            //    Bath10_Infor = new BathInformation() { TimeIn = DateTime.Now, BathTemper = 49, TimeOut = DateTime.Now },
            //    RackStatus = Status.Inprocess

                
            //};
            //HistoryLogger.EditRackObject(R4);

        }
        public static void TripDoneRack_456()
        {
            string code4 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1);
            if (code4 != "") 
            {
                string type4 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P2);
                var R4 = RackObjects.Where(x => x.RackBarcode == code4 && x.NGType == type4 && code4 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
                if (R4 != null)
                {
                    R4.Bath1_Infor.TimeOut = DateTime.Now;
                    HistoryLogger.EditRackObject(R4);
                }
            }

            string code5 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1);
            if (code5!="")
            {
                string type5 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P2);
                var R5 = RackObjects.Where(x => x.RackBarcode == code5 && x.NGType == type5 && code5 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

                if (R5 != null)
                {
                    R5.Bath2_Infor.TimeOut = DateTime.Now;
                    HistoryLogger.EditRackObject(R5);
                }
            }

            string code6 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1);
            if (code6 != "")
            {
                string type6 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P2);
                var R6 = RackObjects.Where(x => x.RackBarcode == code6 && x.NGType == type6 && code6 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();
                if (R6 != null)
                {
                    R6.Bath6_Infor.TimeOut = DateTime.Now;
                    HistoryLogger.EditRackObject(R6);
                }
            }
           
        }

        public static void TripRackDone_798_10()
        {
            string code7 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1);
            string type7 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P2);
            var R7 = RackObjects.Where(x => x.RackBarcode == code7 && x.NGType == type7 && code7 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R7 != null)
            {
                R7.Bath7_Infor.TimeOut = DateTime.Now;
                HistoryLogger.EditRackObject(R7);
            }

            string code8 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1);
            string type8 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P2);
            var R8 = RackObjects.Where(x => x.RackBarcode == code8 && x.NGType == type8 && code8 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R8 != null)
            {
                R8.Bath8_Infor.TimeOut = DateTime.Now;
                HistoryLogger.EditRackObject(R8);
            }

            string code9 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1);
            string type9 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P2);
            var R9 = RackObjects.Where(x => x.RackBarcode == code9 && x.NGType == type9 && code9 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R9 != null)
            {
                R9.Bath9_Infor.TimeOut = DateTime.Now;
                HistoryLogger.EditRackObject(R9);
            }

            string code10 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1);
            string type10 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P2);
            var R10 = RackObjects.Where(x => x.RackBarcode == code10 && x.NGType == type10 && code10 != "" && x.RackStatus == Status.Inprocess).FirstOrDefault();

            if (R10 != null)
            {
                R10.Bath10_Infor.TimeOut = DateTime.Now;
                HistoryLogger.EditRackObject(R10);
            }
        }
    }
}
