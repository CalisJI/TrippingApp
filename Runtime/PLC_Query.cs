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
using System.Security.AccessControl;

namespace TrippingApp.Runtime
{
    public class PLC_Query
    {
        public static SYSTEM_DATA_RETAIN SYSTEM_DATA_RETAIN = new SYSTEM_DATA_RETAIN();
        public static ROBOT_PARAM ROBOT_PARAM = new ROBOT_PARAM();
        public static DATA_TEMPERATURE DATA_TEMPERATURE = new DATA_TEMPERATURE();
        public static DETECT_VALUE DETECT_VALUE = new DETECT_VALUE();
        public static PROCESS_DATA_PARAMETER PROCESS_DATA_PARAMETER = new PROCESS_DATA_PARAMETER();
        public static SETTING_DATA SETTING_DATA = new SETTING_DATA();
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
                if (CheckConnect(Ip)) 
                {
                    if (PLC_Controller == null)
                    {
                        PLC_Controller = new Plc(CpuType.S71200, Ip, 0, 1);
                    }

                    if (Connected == false || PLC_Controller.IsConnected == false)
                    {
                        PLC_Controller.Open();
                        Connected = true;
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("IP Address Invalid or Lost Connect Ethernet Cable");
                }
              
                
            }
            catch (PlcException ex) { _ = Logger.Logger.Async_write(ex.Message); System.Windows.Forms.MessageBox.Show(ex.Message); }

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
                catch (PlcException ex) { _ = Logger.Logger.Async_write(ex.Message); return false; }
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
                catch (PlcException ex) { _ = Logger.Logger.Async_write(ex.Message); }

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
                catch (PlcException ex) { _ = Logger.Logger.Async_write(ex.Message); }
                return new object();
            }
            else
            {
                return new object();
            }
        }
        public static async Task<object> ReadDataAsync(DataOffSetPLC item)
        {
            if (!PLC_Controller.IsConnected) return new object();
            object data = null;
            void act()
            {
                data =  PLC_Controller.ReadAsync(item.DataType, item.DB, item.StartByteAddress, item.VarType, item.VarCount);
            };
            var a = new Task(act);
            a.Start();
            await a;
            return data;

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
                catch (PlcException ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
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
                catch (PlcException ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
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
                    _ = Logger.Logger.Async_write(ex.Message);
                }
            }
            else 
            {
            
            }

        }

        public static void WriteData(DataOffSetPLC arg1, object value)
        {

            if (PLC_Controller.IsConnected)
            {
                try
                {
                    PLC_Controller.Write(arg1.DataType, arg1.DB, arg1.StartByteAddress, value);
                }
                catch ( PlcException ex)
                {

                    _ = Logger.Logger.Async_write(ex.Message);
                }
            }
            else 
            {
                //System.Windows.Forms.MessageBox.Show("PLC is not connect");
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
                catch (PlcException ex)
                {
                    _ = Logger.Logger.Async_write(ex.Message);
                    
                }

            }
            else
            {

                //System.Windows.Forms.MessageBox.Show("Test");
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
                    PLC_Controller.WriteClassAsync(souceClass, DB_Index, Start_Addr);
                }
                catch (PlcException ex)
                {

                    _ = Logger.Logger.Async_write(ex.Message);
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
        public static void Initial_Barcode_Address(List<Data_Barcode_PLC> Plcs_Barcode , LIST_CODE_CHAR ListCode)
        {
            try
            {
                ListCode.Barcode1_P1 = S7String.ToByteArray(Plcs_Barcode[0].BarCode,10);
                ListCode.Barcode1_P2 = S7String.ToByteArray( Plcs_Barcode[0].Kind,1);
                ListCode.Barcode2_P1 = S7String.ToByteArray(Plcs_Barcode[1].BarCode, 10);
                ListCode.Barcode2_P2 = S7String.ToByteArray(Plcs_Barcode[1].Kind, 1);
                ListCode.Barcode3_P1 = S7String.ToByteArray(Plcs_Barcode[2].BarCode, 10);
                ListCode.Barcode3_P2 = S7String.ToByteArray(Plcs_Barcode[2].Kind, 1);
                ListCode.Barcode4_P1 = S7String.ToByteArray(Plcs_Barcode[3].BarCode, 10);
                ListCode.Barcode4_P2 = S7String.ToByteArray(Plcs_Barcode[3].Kind, 1);
                ListCode.Barcode5_P1 = S7String.ToByteArray(Plcs_Barcode[4].BarCode, 10);
                ListCode.Barcode5_P2 = S7String.ToByteArray(Plcs_Barcode[4].Kind, 1);
                ListCode.Barcode6_P1 = S7String.ToByteArray(Plcs_Barcode[5].BarCode, 10);
                ListCode.Barcode6_P2 = S7String.ToByteArray(Plcs_Barcode[5].Kind, 1);
                ListCode.Barcode7_P1 = S7String.ToByteArray(Plcs_Barcode[6].BarCode, 10);
                ListCode.Barcode7_P2 = S7String.ToByteArray(Plcs_Barcode[6].Kind, 1);
                ListCode.Barcode8_P1 = S7String.ToByteArray(Plcs_Barcode[7].BarCode, 10);
                ListCode.Barcode8_P2 = S7String.ToByteArray(Plcs_Barcode[7].Kind, 1);
                ListCode.Barcode9_P1 = S7String.ToByteArray(Plcs_Barcode[8].BarCode, 10);
                ListCode.Barcode9_P2 = S7String.ToByteArray(Plcs_Barcode[8].Kind, 1);
                ListCode.Barcode10_P1 = S7String.ToByteArray(Plcs_Barcode[10].BarCode, 10);
                ListCode.Barcode10_P2 = S7String.ToByteArray(Plcs_Barcode[10].Kind, 1);

                WriteData(ListCode, 3);
                _ = Logger.Logger.Async_write("Download List Barcode Successfully");
            }
            catch (Exception ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);

            }
        }

        public static void PostData_Temperature(float[] Temperatures)
        {
            try
            {
                DATA_TEMPERATURE temper = new DATA_TEMPERATURE
                {
                    Nhiet_Do_Tank1 = Temperatures[0],
                    Nhiet_Do_Tank2 = Temperatures[1],
                    Nhiet_Do_Tank3 = Temperatures[2],
                    Nhiet_Do_Tank4 = Temperatures[3],
                    Nhiet_Do_Tank5 = Temperatures[4],
                    Nhiet_Do_Tank6 = Temperatures[5],
                    Nhiet_Do_Tank7 = Temperatures[6],
                    Nhiet_Do_Tank8 = Temperatures[7],
                    Nhiet_Do_Tank9 = Temperatures[8],
                    Nhiet_Do_Tank10 = Temperatures[9],
                    Nhiet_Do_Tank11 = Temperatures[10]
                };
                WriteData(temper, 24);
                _ = Logger.Logger.Async_write("Write Temperature Successfully");
            }
            catch (Exception ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);
            }
        }
        public static void GetRobot_Setting()
        {
            try
            {
                ReadData(ROBOT_PARAM, 14);
            }
            catch (PlcException ex )
            {
                _ = Logger.Logger.Async_write(ex.Message);
                
            }
        }

        public static void GetProcess_Data_Parameter()
        {
            try
            {
                ReadData(PROCESS_DATA_PARAMETER, 14);
            }
            catch (PlcException ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);

            }
        }

        public static void GetSystem_Data_Retain()
        {
            try
            {
                ReadData(SYSTEM_DATA_RETAIN, 10);
            }
            catch (PlcException ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);

            }
        }

        public static void GetDetect_Value()
        {
            try
            {
                ReadData(DETECT_VALUE,20);
            }
            catch (PlcException ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);

            }
        }

        public static void Write_Setting_DataPoint()
        {
            try
            {
                WriteData(SETTING_DATA, 2);
            }
            catch (PlcException ex)
            {
                _ = Logger.Logger.Async_write(ex.Message);

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

        public readonly static string WRITE_DATA_POINT_X = "M9.0";
        public readonly static string WRITE_DATA_POINT_LIFT = "M9.3";

        public readonly static string Manual_Jog_FW_Robot = "M49.1";
        public readonly static string Manual_Jog_BW_Robot = "M49.2";
        public readonly static string Manual_Jog_FW_Lift = "M49.3";
        public readonly static string Manual_Jog_BW_Lift = "M49.4";

        public readonly static string Write_Data_Point_Robot = "M9.0";
        public readonly static string Write_Data_Point_Lift = "M9.3";

        public readonly static string HOME_MAN_TRIGGER_PC = "M3.3";
        public readonly static string SELECT_AXIS_HOME = "MW6";
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

        public readonly static string Current_Position_X = "MW128";
        public readonly static string Current_Position_Lift = "MW130";


        public readonly static string Man_Up_XL_Nang_Input = "M30.7";
        public readonly static string Man_Down_XL_Nang_Input = "M31.1";


        public readonly static string Man_Up_XL_Lift1 = "M29.0";
        public readonly static string Man_Down_XL_Lift1 = "M29.1";

        public readonly static string Man_Up_XL_Lift2 = "M29.2.";
        public readonly static string Man_Down_XL_Lift2 = "M29.3";

        public readonly static string Man_Up_XL_Lift3 = "M29.4";
        public readonly static string Man_Down_XL_Lift3 = "M29.5";

        public readonly static string Man_Up_XL_Lift4 = "M29.6";
        public readonly static string Man_Down_XL_Lift4 = "M29.7";

        public readonly static string Man_Up_XL_Lift5 = "M30.0";
        public readonly static string Man_Down_XL_Lift5 = "M30.1";

        public readonly static string Man_Up_XL_Chot_Input = "M30.4";
        public readonly static string Man_Down_XL_Chot_Input = "M30.5";

        public readonly static string Man_Up_XL_Nang_Output = "M103.0";
        public readonly static string Man_Down_XL_Nang_Output = "M31.4";

        public readonly static string Man_Open_XL_Robot = "M31.6";
        public readonly static string Man_Close_XL_Robot = "M32.0";

        public readonly static string Man_Up_XL_Robot = "M32.2";
        public readonly static string Man_Down_XL_Robot = "M32.4";

        public readonly static string Man_On_Van_DI = "M103.4";
        public readonly static string Man_Off_Van_DI = "M103.6";

        public readonly static string Man_On_Van_RO = "M104.0";
        public readonly static string Man_Off_Van_RO = "M104.2";
        public readonly static string Test = "MW4";

        public readonly static DataOffSetPLC Jog_X_SPEED  = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 0,
            VarType = VarType.Int,
            VarCount = 1
        };
        public readonly static DataOffSetPLC Jog_Lift_SPEED = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 2,
            VarType = VarType.Int,
            VarCount = 1
        };
        
        public readonly static DataOffSetPLC AxisRobot_Position_1 = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 4,
            VarType = VarType.Int,
            VarCount = 1
        };
        public readonly static DataOffSetPLC AxisRobot_Position_2 = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 6,
            VarType = VarType.Int,
            VarCount = 1
        };
        public readonly static DataOffSetPLC AxisRobot_Position_3 = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 8,
            VarType = VarType.Int,
            VarCount = 1
        };
        public readonly static DataOffSetPLC AxisRobot_Position_Start = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 10,
            VarType = VarType.Int,
            VarCount = 1
        };
        
        public readonly static DataOffSetPLC AxisLift_Position_1 = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 20,
            VarType = VarType.Int,
            VarCount = 1
        };
        public readonly static DataOffSetPLC AxisLift_Position_2 = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 22,
            VarType = VarType.Int,
            VarCount = 1
        };

        public readonly static DataOffSetPLC AxisLift_Position_Start = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 24,
            VarType = VarType.Int,
            VarCount = 1
        };

        public readonly static DataOffSetPLC AxisRobot_Target_Point = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 32,
            VarType = VarType.Int,
            VarCount = 1
        };

        public readonly static DataOffSetPLC AxisLift_Target_Point = new DataOffSetPLC()
        {
            DataType = DataType.DataBlock,
            DB = 14,
            StartByteAddress = 34,
            VarType = VarType.Int,
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
        public Int32 BaudRate { get; set; }
        public Int32 Parity { get; set; }
        public short Detect_Vector { get; set; }
        public short Detect_Vector_1 { get; set; }

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
    public class DETECT_VALUE
    {
        public byte[] SCANED_BARCODE { get; set; } = new byte[11];
        public byte[] INPUT_SCANED_BARCODE { get; set; } = new byte[11];
    }

    public class DATA_TEMPERATURE 
    {
        public float Nhiet_Do_Tank1 { get; set; }
        public float Nhiet_Do_Tank2 { get; set; }
        public float Nhiet_Do_Tank3 { get; set; }
        public float Nhiet_Do_Tank4 { get; set; }
        public float Nhiet_Do_Tank5 { get; set; }
        public float Nhiet_Do_Tank6 { get; set; }
        public float Nhiet_Do_Tank7 { get; set; }
        public float Nhiet_Do_Tank8 { get; set; }
        public float Nhiet_Do_Tank9 { get; set; }
        public float Nhiet_Do_Tank10 { get; set; }
        public float Nhiet_Do_Tank11 { get; set; }
    }


    public class LIST_CODE_CHAR 
    {
        public byte[] Barcode1_P1 { get; set; } = new byte[11];
        public byte[] Barcode1_P2 { get; set; } = new byte[3];
        public byte[] Barcode2_P1 { get; set; } = new byte[11];
        public byte[] Barcode2_P2 { get; set; } = new byte[3];
        public byte[] Barcode3_P1 { get; set; } = new byte[11];
        public byte[] Barcode3_P2 { get; set; } = new byte[3];
        public byte[] Barcode4_P1 { get; set; } = new byte[11];
        public byte[] Barcode4_P2 { get; set; } = new byte[3];
        public byte[] Barcode5_P1 { get; set; } = new byte[11];
        public byte[] Barcode5_P2 { get; set; } = new byte[3];
        public byte[] Barcode6_P1 { get; set; } = new byte[11];
        public byte[] Barcode6_P2 { get; set; } = new byte[3];
        public byte[] Barcode7_P1 { get; set; } = new byte[11];
        public byte[] Barcode7_P2 { get; set; } = new byte[3];
        public byte[] Barcode8_P1 { get; set; } = new byte[11];
        public byte[] Barcode8_P2 { get; set; } = new byte[3];
        public byte[] Barcode9_P1 { get; set; } = new byte[11];
        public byte[] Barcode9_P2 { get; set; } = new byte[3];
        public byte[] Barcode10_P1 { get; set; } = new byte[11];
        public byte[] Barcode10_P2 { get; set; } = new byte[3];

        public byte[] Contain_In_Bath1_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath1_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath2_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath2_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath3_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath3_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath4_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath4_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath5_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath5_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath6_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath6_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath7_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath7_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath8_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath8_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath9_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath9_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath10_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath10_P2 { get; set; } = new byte[3];
        public byte[] Contain_In_Bath11_P1 { get; set; } = new byte[11];
        public byte[] Contain_In_Bath11_P2 { get; set; } = new byte[3];

        public byte[] Barcode_Queue_Robot_P1 { get; set; } = new byte[11];
        public byte[] Barcode_Queue_Robot_P2 { get; set; } = new byte[3];

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
