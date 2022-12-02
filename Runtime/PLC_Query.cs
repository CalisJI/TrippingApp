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
                    PLC_Controller = new Plc(CpuType.S71200, Ip, 1, 0);
                }

                if (Connected == false || PLC_Controller.IsConnected == false)
                {
                    PLC_Controller.Open();
                    Connected = true;
                }
                if(DataItemPLC == null)
                {
                    DataItemPLC = new List<DataItem>();
                }
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
            if(PLC_Controller == null)
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
        /// Hàm ghi giá trị cho các bit
        /// </summary>
        /// <param name="BitAddress"> Địa chỉ Bit cần ghi</param>
        public static void WriteBit(string BitAddress) 
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
                        PLC_Controller.Write(BitAddress, true);
                    }
                   
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }

            }
        }
        public static void ReadData()
        {

        }
        public static void WriteData(string DataAdress , object value)
        {
            
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
}
