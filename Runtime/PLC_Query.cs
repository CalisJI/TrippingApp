using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using S7.Net;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using S7.Net.Types;
using Cognex.InSight.Controls.Display.EZBuilder;

namespace TrippingApp.Runtime
{
    public class PLC_Query
    {
        public static Plc PLC_Controller = null;
        /// <summary>
        /// Trang thái kết nối
        /// </summary>
        public static bool Connected { get; set; } = false;

        public static List<DataItem> DataItemPLC;
        /// <summary>
        /// Kiểm tra kết nối với các thiệt bị trong network
        /// </summary>
        /// <param name="IP">Địa chỉ cần kiểm tra</param>
        /// <returns>True = Kết Nối Khả Thi , False:Không tồn tại địa chỉ hoặc kết nối bị gián đoạn</returns>
        public static bool CheckConnect(string IP)
        {
            try
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(IP, 1000);
                return pingReply.Status == IPStatus.Success;
            }
            catch (Exception)
            {
                return false;
            }

        }


        /// <summary>
        /// Khởi Tạo kết nối PLC
        /// </summary>
        /// <param name="Ip">Đia chỉ PLC</param>
        public static void Initial(string Ip)
        {
            try
            {
                if (PLC_Controller == null)
                {
                    PLC_Controller = new Plc(CpuType.S71500, Ip, 0, 1);
                }

                if (Connected == false || PLC_Controller.IsConnected == false)
                {
                    PLC_Controller.Open();
                    Connected = true;
                }
                if (DataItemPLC == null)
                {
                    DataItemPLC = new List<DataItem>();
                }
                //Initial_Barcode_Address(DataItemPLC);
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        /// <summary>
        /// Hàm Đọc trạng thái của Bit
        /// </summary>
        /// <param name="BitAddress">Địa Chỉ Của Bit</param>
        /// <returns></returns>
        public static bool ReadBit(string BitAddress)
        {
            if (PLC_Controller == null)
            {
                return false;
            }
            else
            {
                try
                {
                    if (Connected && PLC_Controller.IsConnected)
                    {
                        return (bool)PLC_Controller.Read(BitAddress);
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return false;
                }

            }

        }
        /// <summary>
        /// Hàm Set bit
        /// </summary>
        /// <param name="BitAddress">Địa chỉ</param>
        /// <param name="value">Giá trị</param>
        public static void WriteBit(string BitAddress,bool value)
        {
            if (PLC_Controller == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (Connected && PLC_Controller.IsConnected)
                    {
                        PLC_Controller.Write(BitAddress, value);
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
        }
        /// <summary>
        /// Read Single Data
        /// </summary>
        /// <param name="DataAdress"></param>
        /// <returns></returns>
        public static object ReadData(string DataAdress)
        {
            if (PLC_Controller.IsConnected)
            {
                try
                {
                    return PLC_Controller.Read(DataAdress);
                }
                catch (Exception ex)
                {
                   
                }
                return new object();
            }
            else
            {
                return new object();
            }
        }

        /// <summary>
        /// Read Single Feild IN DataBlock
        /// </summary>
        /// <param name="item">Infor of Feild</param>
        /// <returns></returns>
        public static object ReadData(DataOffSetPLC item)
        {
            if (PLC_Controller.IsConnected)
            {
                try
                {
                    return PLC_Controller.Read(item.DataType,item.DB,item.StartByteAddress,item.VarType,item.VarCount);
                }
                catch (Exception ex)
                {

                }
                return new object();
            }
            else
            {
                return new object();
            }
        }
        /// <summary>
        /// Read Data through Struct Of Datablock
        /// </summary>
        /// <typeparam name="T">Type Of Struct</typeparam>
        /// <returns></returns>
        public static object ReadData<T>(int DB_Index,int Start_Addr=0)
        {
            if (PLC_Controller.IsConnected)
            {
                try
                {
                    return PLC_Controller.ReadStruct(typeof(T), DB_Index, Start_Addr);
                }
                catch (Exception ex)
                {

                }
                return new object();
            }
            else
            {
                return new object();
            }
        }
        /// <summary>
        /// ReadData Full DataBlock to Class Object
        /// </summary>
        /// <param name="sourceClass"></param>
        /// <param name="DB_index"></param>
        /// <param name="Start_Addr"></param>
        public static void ReadData(object  sourceClass,int DB_index,int Start_Addr=0)
        {
            if (PLC_Controller.IsConnected)
            {
                try
                {
                    PLC_Controller.ReadClass(sourceClass, DB_index, Start_Addr);
                }
                catch (PlcException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
          
        }
        /// <summary>
        /// Write Single Data
        /// </summary>
        /// <param name="DataAdress"></param>
        /// <param name="value"></param>
        public static void WriteData(string DataAdress, object value)
        {
            if (PLC_Controller.IsConnected) 
            {
                try
                {
                    PLC_Controller.Write(DataAdress, value);
                }
                catch (Exception ex)
                {

                    
                }

            }
        }
        /// <summary>
        /// Write Full Data from Class to DataBlock
        /// </summary>
        /// <param name="souceClass"></param>
        /// <param name="DB_Index"></param>
        /// <param name="Start_Addr"></param>
        public static void WriteData(object souceClass,int DB_Index,int Start_Addr=0)
        {
            if (PLC_Controller.IsConnected)
            {
                try
                {
                    PLC_Controller.WriteClass(souceClass, DB_Index, Start_Addr);
                }
                catch (PlcException ex)
                {


                }

            }
        }
        public static void WriteArrayData()
        {
            if (PLC_Controller == null)
            {
                return;
            }
            else
            {
                try
                {
                    if (Connected && PLC_Controller.IsConnected)
                    {
                        PLC_Controller.Write(DataItemPLC.ToArray());
                    }

                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
        }
        /// <summary>
        /// Hàm gán giá trị các thanh ghi chưa dữ liệu barcode backup
        /// </summary>
        private static void Initial_Barcode_Address(List<Data_Barcode_PLC> Plcs_Barcode)
        {
            try
            {
                DataItem Barcode1_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 0,
                    Value = new object()

                };
                DataItem Barcode1_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 12,
                    Value = new object()

                };
                DataItem Barcode2_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 16,
                    Value = new object()

                };
                DataItem Barcode2_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 28,
                    Value = new object()

                };
                DataItem Barcode3_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 32,
                    Value = new object()

                };
                DataItem Barcode3_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 44,
                    Value = new object()

                };
                DataItem Barcode4_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 48,
                    Value = new object()

                };
                DataItem Barcode4_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 60,
                    Value = new object()

                };
                DataItem Barcode5_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 64,
                    Value = new object()

                };
                DataItem Barcode5_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 76,
                    Value = new object()

                };
                DataItem Barcode6_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 80,
                    Value = new object()

                };
                DataItem Barcode6_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 92,
                    Value = new object()

                };
                DataItem Barcode7_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 96,
                    Value = new object()

                };
                DataItem Barcode7_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 108,
                    Value = new object()

                };
                DataItem Barcode8_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 112,
                    Value = new object()

                };
                DataItem Barcode8_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 124,
                    Value = new object()

                };
                DataItem Barcode9_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 128,
                    Value = new object()

                };
                DataItem Barcode9_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 140,
                    Value = new object()

                };
                DataItem Barcode10_P1 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 10,
                    StartByteAdr = 144,
                    Value = new object()

                };
                DataItem Barcode10_P2 = new DataItem()
                {
                    DataType = DataType.DataBlock,
                    VarType = VarType.String,
                    DB = 3,
                    BitAdr = 0,
                    Count = 1,
                    StartByteAdr = 156,
                    Value = new object()
                };


                Barcode1_P1.Value = Plcs_Barcode[0].BarCode;
                Barcode1_P2.Value = Plcs_Barcode[0].Kind;
                Barcode2_P1.Value = Plcs_Barcode[1].BarCode;
                Barcode2_P2.Value = Plcs_Barcode[1].Kind;
                Barcode3_P1.Value = Plcs_Barcode[2].BarCode;
                Barcode3_P2.Value = Plcs_Barcode[2].Kind;
                Barcode4_P1.Value = Plcs_Barcode[3].BarCode;
                Barcode4_P2.Value = Plcs_Barcode[3].Kind;
                Barcode5_P1.Value = Plcs_Barcode[4].BarCode;
                Barcode5_P2.Value = Plcs_Barcode[4].Kind;
                Barcode6_P1.Value = Plcs_Barcode[5].BarCode;
                Barcode6_P2.Value = Plcs_Barcode[5].Kind;
                Barcode7_P1.Value = Plcs_Barcode[6].BarCode;
                Barcode7_P2.Value = Plcs_Barcode[6].Kind;
                Barcode8_P1.Value = Plcs_Barcode[7].BarCode;
                Barcode8_P2.Value = Plcs_Barcode[7].Kind;
                Barcode9_P1.Value = Plcs_Barcode[8].BarCode;
                Barcode9_P2.Value = Plcs_Barcode[8].Kind;
                Barcode10_P1.Value = Plcs_Barcode[9].BarCode;
                Barcode10_P2.Value = Plcs_Barcode[9].Kind;
                if (DataItemPLC.Count != 0)
                {
                    DataItemPLC.Clear();
                }

                DataItemPLC.Add(Barcode1_P1);
                DataItemPLC.Add(Barcode1_P2);
                DataItemPLC.Add(Barcode2_P1);
                DataItemPLC.Add(Barcode2_P2);
                DataItemPLC.Add(Barcode3_P1);
                DataItemPLC.Add(Barcode3_P2);
                DataItemPLC.Add(Barcode4_P1);
                DataItemPLC.Add(Barcode4_P2);
                DataItemPLC.Add(Barcode5_P1);
                DataItemPLC.Add(Barcode5_P2);
                DataItemPLC.Add(Barcode6_P1);
                DataItemPLC.Add(Barcode6_P2);
                DataItemPLC.Add(Barcode7_P1);
                DataItemPLC.Add(Barcode7_P2);
                DataItemPLC.Add(Barcode8_P1);
                DataItemPLC.Add(Barcode8_P2);
                DataItemPLC.Add(Barcode9_P1);
                DataItemPLC.Add(Barcode9_P2);
                DataItemPLC.Add(Barcode10_P1);
                DataItemPLC.Add(Barcode10_P2);
                PLC_Controller.Write(DataItemPLC.ToArray());
            }
            catch (Exception)
            {


            }
        }
    }

    public class Data_Barcode_PLC
    {
        /// <summary>
        /// Barcode của Rack
        /// </summary>
        public string BarCode { get; set; }
        /// <summary>
        /// Loại lỗi để lựa chọn chu trình
        /// </summary>
        public string Kind { get; set; }
        public Data_Barcode_PLC()
        {

        }
        public Data_Barcode_PLC(string barCode, string kind)
        {
            BarCode = barCode;
            Kind = kind;
        }
    }
    public static class AddressCrt
    {
        /// <summary>
        /// Bật/Tắt Chế Độ Manual
        /// </summary>
        public readonly static string Manual_Mode = "M3.1";
        /// <summary>
        /// Enable Robot Servo
        /// </summary>
        public readonly static string OnRobot = "M61.5";
        /// <summary>
        /// Disable Robot Servo
        /// </summary>
        public readonly static string OffRobot = "M61.7";
        /// <summary>
        /// Begin Homing Robot Manual
        /// </summary>
        public readonly static string Manual_Home_Robot = "M63.3";
        /// <summary>
        /// Enable Lift Servo
        /// </summary>
        public readonly static string OnLift = "M62.1";
        /// <summary>
        /// Disable Lift Servo
        /// </summary>
        public readonly static string OffLift = "M62.3";
        /// <summary>
        /// Begin Home Lift Manual
        /// </summary>
        public readonly static string Manual_Home_Lift = "M61.5";

        public readonly static string Manual_Jog_FW_Robot = "M49.1";
        public readonly static string Manual_Jog_BW_Robot = "M49.2";
        public readonly static string Manual_Jog_FW_Lift = "M49.3";
        public readonly static string Manual_Jog_BW_Lift = "M49.4";

        public readonly static string Write_Data_Point_Robot = "M9.0";
        public readonly static string Write_Data_Point_Lift = "M9.3";

        public readonly static string SettingData_Point2Set = "DB2.DBW0";

        public readonly static string Jog_FW_TF1 = "M50.5";
        public readonly static string Jog_BW_TF1 = "M51.0";
        public readonly static string Jog_FW_TF2 = "M51.3";
        public readonly static string Jog_BW_TF2 = "M51.4";

        public readonly static string Run_FW_TF1 = "M57.3";
        public readonly static string Run_BW_TF1 = "M57.4";
        public readonly static string Run_FW_TF2 = "M54.7";
        public readonly static string Run_BW_TF2 = "M55.0";

        public readonly static string Set_Frequency_Tranfer = "M17.0";
        public readonly static string Set_AccDec_Tranfer = "M17.1";

        public readonly static string Set_Frequency_Robot = "M17.4";
        public readonly static string Set_AccDec_Robot = "M17.6";

        public readonly static string Jog_FW_Lift1 = "M52.1";
        public readonly static string Jog_BW_Lift1 = "M52.2";
        public readonly static string Jog_FW_Lift2 = "M52.7";
        public readonly static string Jog_BW_Lift2 = "M53.0";
        public readonly static string Jog_FW_Lift3 = "M53.5";
        public readonly static string Jog_BW_Lift3 = "M53.6";

        public readonly static string Run_FW_Lift1 = "M55.1";
        public readonly static string Run_BW_Lift1 = "M55.2";
        public readonly static string Run_FW_Lift2 = "M55.7";
        public readonly static string Run_BW_Lift2 = "M56.0";
        public readonly static string Run_FW_Lift3 = "M56.5";
        public readonly static string Run_BW_Lift3 = "M56.6";

        public readonly static string Run_FW_Input_Conveyor = "M98.1";
        public readonly static string Run_BW_Input_Convetor = "M98.2";
        public readonly static string Run_Output_Conveyor = "M98.3";

        public readonly static DataOffSetPLC Test = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 1,
            StartByteAddress = 4,
            VarType = VarType.Real,
            VarCount = 1
        };
        public readonly static DataOffSetPLC Test_time = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 1,
            StartByteAddress = 8,
            VarType = VarType.DInt,
            VarCount = 1
        };
        public readonly static TestClass TestClass;

    }
    public struct DataOffSetPLC 
    {
        public DataType DataType;
        public int DB;
        public int StartByteAddress;
        public VarType VarType;
        public int VarCount;
     
    }
    public class TestClass 
    {
        public bool var1;
        public int var2;
        public float var3;
        public int var4;
        public object var5;
        public Array var6;
        public Array var7;
        public int vw1;
        public float vw2;
        public object vw3;
        public int vw4;


    }
    public class TestST 
    {
        public bool var1 { get; set; }
        public short var2 { get; set; }
        public float var3 { get; set; }
        public Int32 var4 { get; set; }
        public byte[] var5 { get; set; } = new byte[11];
        public bool[] var6 { get; set; } = new bool[16];
        public short[] var7 { get; set; } = new short[9];
        public short vw1 { get; set; }
        public float vw2 { get; set; }
        public byte[] vw3 { get; set; } = new byte[11];
        public Int32 vw4 { get; set; }
       
    }
    /// <summary>
    /// Note type Convert 
    /// PLC : C#
    /// Int <=> short
    /// Real = Float
    /// String[length] = byte[length +1]
    /// Time = Int32 => to TimeSpan.FromMiliseconds
    /// </summary>
    public class ROBOT_PARAM
    {
        public short JOG_X_SPEED { get; set; }
        public short JOG_LIFT_SPEED { get; set; }
        public short AxisRobot_Position_1 { get; set; }
        public short AxisRobot_Position_2 { get; set; }
        public short AxisRobot_Position_3 { get; set; }
        public short AxisRobot_Position_Start { get; set; }
        public short AxisRobot_P1_Index { get; set; }
        public short AxisRobot_P2_Index { get; set; }
        public short AxisRobot_P3_Index { get; set; }
        public short AxisRobot_PStart_Index { get; set; }
        public short AxisLift_Position_1 { get; set; }
        public short AxisLift_Position_2 { get; set; }
        public short AxisLift_Position_Start { get; set; }
        public short AxisLift_P1_Index { get; set; }
        public short AxisLift_P2_Index { get; set; }
        public short AxisLift_PStart_Index { get; set; }
        public short AxisRobot_Target_Point { get; set; }
        public short AxisLift_Target_Point { get; set; }
    }
    public class SETTING_DATA
    {
        public short Point_to_Set { get; set; }
        public short Point_Data { get; set; }
        public short Point_Speed { get; set; }
        public short Point_Accel { get; set; }
        public short Point_Decel { get; set; }
        public short Axis_Number { get; set; }
    }
    public class SYSTEM_DATA_RETAIN
    {
        public float Balance_temperature { get; set; }
        public Int32 Time_Wait_Down_XL_Lift_1 { get; set; }
        public Int32 Time_Wait_Down_XL_Lift_2 { get; set; }
        public Int32 Time_Wait_Down_XL_Lift_3 { get; set; }
        public Int32 Time_Wait_Down_XL_Lift_4 { get; set; }
        public Int32 Time_Wait_Down_XL_Lift_5 { get; set; }
        public Int32 TIme_Wait_Back_TF { get; set; }
        public Int32 Time_Wati_Move_RackB4 { get; set; }
        public float Tranfer_Frequency { get; set; }
        public float Dip_Frequency { get; set; }
        public float Accel_Tranfer { get; set; }
        public float Decel_Tranfer { get; set; }
        public float Accel_Dip { get; set; }
        public float Decel_Dip { get; set; }
        public UInt32 BaudRate { get; set; }
        public UInt32 Parity { get; set; }

    }

    public class PROCESS_DATA_PARAMETER
    {
        public Int32 Timer_Region1vs3 { get; set; }
        public Int32 Timer_Bath6_P1 { get; set; }
        public Int32 Timer_Bath6_P2 { get; set; }
        public Int32 Timer_Bath6_P3 { get; set; }
        public Int32 Timer_Bath6_P4 { get; set; }
        public Int32 Timer_Bath4_P2 { get; set; }
        public Int32 Timer_Bath4_P3 { get; set; }
        public Int32 Timer_Bath5_P4 { get; set; }
        public Int32 Tranfer_timer { get; set; }
        public Int32 Timer_temp_Robot_Area { get; set; }
        public Int32 Current_TValue_Bath4 { get; set; }
        public Int32 Current_TValue_Bath5 { get; set; }
        public Int32 Current_TValue_Bath6 { get; set; }
        public Int32 Current_TValue_Area_1 { get; set; }
        public Int32 Current_TValue_Area_3 { get; set; }
        public short CurrentBathNumber { get; set; }
        public short MODE { get; set; }
        public short Time_Int_Check_Sensor_TF { get; set; }
        public Int32 Time_Check_Sensor_TF { get; set; }
        public Int32 Time_To_Active_Robot { get; set; }
        public Int32 Timer_Run_Conveyor_Inpur { get; set; }


    }
    public struct Barcode
    {
        public byte[] Barcode_P1;
        public byte[] Barcode_P2;
    }
    public class Barcode_1
    {
        public byte[] Barcode_P1 { get; set; } = new byte[11];
        public byte[] Barcode_P2 { get; set; } = new byte[3];
        public byte[] Barcode_P3 { get; set; } = new byte[11];
        public byte[] Barcode_P4 { get; set; } = new byte[3];
        public byte[] Barcode_P5 { get; set; } = new byte[11];
        public byte[] Barcode_P6 { get; set; } = new byte[3];
    }
}
