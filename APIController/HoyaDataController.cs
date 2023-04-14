using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Windows.Interop;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Math.Field;
using Owin;
using S7.Net.Types;
using TrippingApp.AppConfig;
using TrippingApp.Model;
using TrippingApp.Runtime;
using TrippingApp.ViewModel;

namespace TrippingApp.APIController
{
    public static class GlobalDataHoya
    {

        public static List<HoyaData> hoyaDatas = new List<HoyaData>();
        public static Nhietdo Nhietdo = new Nhietdo();
        public static Dictionary<string, HoyaData> HoyadataDict = new Dictionary<string, HoyaData>();
        public static InforQueueRack InforQueueRack = new InforQueueRack();
        public static DataTable Robot_Type_Table = new DataTable();
    }

    public class HoyaDataController : ApiController
    {
        // GET api/hoyaDatas
        [HttpGet]
        public IHttpActionResult Get()
        {
            //var data = HistoryLogger.Upload_Rows();
            return Json(GlobalDataHoya.hoyaDatas); // Return the list of users as JSON
        }

        // GET api/hoyaDatas/5
        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var user = GlobalDataHoya.hoyaDatas.FirstOrDefault(u => u.Barcode == id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user); // Return the user object as JSON
        }

        // PUT api/hoyaDatas/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] HoyaData hoyaData)
        {
            //var existingUser = GlobalDataHoya.hoyaDatas.FirstOrDefault(u => u.Id == id);
            //if (existingUser == null)
            //{
            //    return NotFound();
            //}
            //existingUser.Name = hoyaData.Name;
            //existingUser.Age = hoyaData.Age;
            return Json(new { message = "OK" }); // Return the updated user object as JSON
        }
        [HttpPost]
        public IHttpActionResult AddItem([FromBody] HoyaData item)
        {
            string keyCode = "HY-000";

            if (AppConfig.ApplicationConfig.SystemConfig.DataMethod)
            {
                if (!GlobalDataHoya.HoyadataDict.ContainsKey(keyCode))
                {
                    GlobalDataHoya.HoyadataDict.Add(keyCode, item);
                }
                else
                {
                    GlobalDataHoya.HoyadataDict[keyCode] = item;
                }

                return Json(new { message = "Item added successfully" });
            }
            else
            {
                return Json(new { message = "Error add item" });
            }
        }
    }
    [Route("QRCode")]
    public class QRCodeController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Json(GlobalDataHoya.HoyadataDict);
        }
        [Route("ReLoad_Rack")]
        [HttpGet]
        public IHttpActionResult ReLoad_Rack()
        {
            if (!PLC_Query.Connected)
            {
                return Json(new { message = "PLC Is Not Connec" });
            }
            PLC_Query.Get_ListCodeChar();
            MachineViewModel.Getbarcode_Command.Execute(null);

            return Json(new { message = "OK" });
        }

        [Route("Get_RackPLC")]
        [HttpGet]
        public IHttpActionResult Get_RackPLC()
        {
            try
            {
                if (!PLC_Query.Connected)
                {
                    return BadRequest("PLC is not connect");
                }
                PLC_Query.Get_ListCodeChar();
                GlobalDataHoya.InforQueueRack.Bath1_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode1_P1);
                GlobalDataHoya.InforQueueRack.Bath1_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode1_P2);

                GlobalDataHoya.InforQueueRack.Bath2_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode2_P1);
                GlobalDataHoya.InforQueueRack.Bath2_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode2_P2);

                GlobalDataHoya.InforQueueRack.Bath3_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode3_P1);
                GlobalDataHoya.InforQueueRack.Bath3_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode3_P2);

                GlobalDataHoya.InforQueueRack.Bath4_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode4_P1);
                GlobalDataHoya.InforQueueRack.Bath4_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode4_P2);

                GlobalDataHoya.InforQueueRack.Bath5_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode5_P1);
                GlobalDataHoya.InforQueueRack.Bath5_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode5_P2);

                GlobalDataHoya.InforQueueRack.Bath6_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode6_P1);
                GlobalDataHoya.InforQueueRack.Bath6_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode6_P2);

                GlobalDataHoya.InforQueueRack.Bath7_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode7_P1);
                GlobalDataHoya.InforQueueRack.Bath7_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode7_P2);

                GlobalDataHoya.InforQueueRack.Bath8_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode8_P1);
                GlobalDataHoya.InforQueueRack.Bath8_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode8_P2);

                GlobalDataHoya.InforQueueRack.Bath9_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode9_P1);
                GlobalDataHoya.InforQueueRack.Bath9_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode9_P2);

                GlobalDataHoya.InforQueueRack.Bath10_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode10_P1);
                GlobalDataHoya.InforQueueRack.Bath10_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Barcode10_P2);

                GlobalDataHoya.InforQueueRack.CBath1_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1);
                GlobalDataHoya.InforQueueRack.CBath1_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P2);

                GlobalDataHoya.InforQueueRack.CBath2_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1);
                GlobalDataHoya.InforQueueRack.CBath2_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P2);

                GlobalDataHoya.InforQueueRack.CBath3_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1);
                GlobalDataHoya.InforQueueRack.CBath3_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P2);

                GlobalDataHoya.InforQueueRack.CBath4_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1);
                GlobalDataHoya.InforQueueRack.CBath4_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P2);

                GlobalDataHoya.InforQueueRack.CBath5_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1);
                GlobalDataHoya.InforQueueRack.CBath5_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P2);

                GlobalDataHoya.InforQueueRack.CBath6_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1);
                GlobalDataHoya.InforQueueRack.CBath6_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P2);

                GlobalDataHoya.InforQueueRack.CBath7_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1);
                GlobalDataHoya.InforQueueRack.CBath7_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P2);

                GlobalDataHoya.InforQueueRack.CBath8_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1);
                GlobalDataHoya.InforQueueRack.CBath8_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P2);

                GlobalDataHoya.InforQueueRack.CBath9_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1);
                GlobalDataHoya.InforQueueRack.CBath9_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P2);

                GlobalDataHoya.InforQueueRack.CBath10_QR = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1);
                GlobalDataHoya.InforQueueRack.CBath10_T = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P2);
                //GlobalDataHoya.InforQueueRack.Bath1_QR = "HY-001";
                //GlobalDataHoya.InforQueueRack.Bath1_T = "1";

                //GlobalDataHoya.InforQueueRack.Bath2_QR = "HY-002";
                //GlobalDataHoya.InforQueueRack.Bath2_T = "2";

                //GlobalDataHoya.InforQueueRack.Bath3_QR = "HY-003";
                //GlobalDataHoya.InforQueueRack.Bath3_T = "3";

                //GlobalDataHoya.InforQueueRack.Bath4_QR = "HY-004";
                //GlobalDataHoya.InforQueueRack.Bath4_T = "4";

                //GlobalDataHoya.InforQueueRack.Bath5_QR = "HY-005";
                //GlobalDataHoya.InforQueueRack.Bath5_T = "1";

                //GlobalDataHoya.InforQueueRack.Bath6_QR = "HY-006";
                //GlobalDataHoya.InforQueueRack.Bath6_T = "2";

                //GlobalDataHoya.InforQueueRack.Bath7_QR = "HY-007";
                //GlobalDataHoya.InforQueueRack.Bath7_T = "3";

                //GlobalDataHoya.InforQueueRack.Bath8_QR = "HY-008";
                //GlobalDataHoya.InforQueueRack.Bath8_T = "4";

                //GlobalDataHoya.InforQueueRack.Bath9_QR = "HY-009";
                //GlobalDataHoya.InforQueueRack.Bath9_T = "1";

                //GlobalDataHoya.InforQueueRack.Bath10_QR = "HY-009";
                //GlobalDataHoya.InforQueueRack.Bath10_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath1_QR = "HY-001";
                //GlobalDataHoya.InforQueueRack.CBath1_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath2_QR = "HY-002";
                //GlobalDataHoya.InforQueueRack.CBath2_T = "2";

                //GlobalDataHoya.InforQueueRack.CBath3_QR = "HY-003";
                //GlobalDataHoya.InforQueueRack.CBath3_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath4_QR = "HY-004";
                //GlobalDataHoya.InforQueueRack.CBath4_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath5_QR = "HY-005";
                //GlobalDataHoya.InforQueueRack.CBath5_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath6_QR = "HY-006";
                //GlobalDataHoya.InforQueueRack.CBath6_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath7_QR = "HY-007";
                //GlobalDataHoya.InforQueueRack.CBath7_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath8_QR = "HY-008";
                //GlobalDataHoya.InforQueueRack.CBath8_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath9_QR = "HY-009";
                //GlobalDataHoya.InforQueueRack.CBath9_T = "1";

                //GlobalDataHoya.InforQueueRack.CBath10_QR = "HY-010";
                //GlobalDataHoya.InforQueueRack.CBath10_T = "1";
                MachineViewModel.Getbarcode_Command.Execute(null);
                return Json(GlobalDataHoya.InforQueueRack);
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return NotFound();
            }


        }
        //[Route("[action]")]
        [Route("LoadBarcode")]
        [HttpPost]
        public IHttpActionResult LoadBarcode()
        {
            string barcode = null;

            if (Request.Content != null)
            {
                barcode = Request.Content.ReadAsStringAsync().Result;
            }

            if (!string.IsNullOrEmpty(barcode))
            {
                if (!GlobalDataHoya.HoyadataDict.ContainsKey(barcode))
                {
                    GlobalDataHoya.HoyadataDict.Add(barcode, null);
                }
            }
            return Json(new { message = "Update Barcode Rack" });
        }

        [Route("EditBarcode")]
        [HttpPost]
        public IHttpActionResult EditBarcode([FromBody] JObject data)
        {
            if (data != null)
            {
                string barcode = data.GetValue("Barcode").ToString();
                string kind = data.GetValue("NG_Type").ToString();
                HoyaData hoyaData = new HoyaData() { Barcode = barcode, Ng_Type = kind };

                if (!GlobalDataHoya.HoyadataDict.ContainsKey(barcode))
                {
                    try
                    {
                        GlobalDataHoya.HoyadataDict.Add(barcode, hoyaData);
                        Data_Barcode_PLC data_Barcode_ = new Data_Barcode_PLC()
                        {
                            BarCode = barcode,
                            Kind = hoyaData.Ng_Type
                        };
                        bool status = false;
                        if (PLC_Query.PLC_Controller == null || PLC_Query.PLC_Controller.IsConnected == false)
                        {
                            return BadRequest("PLC Is Not Connect");
                        }
                        PLC_Query.AddRack2Queue(data_Barcode_, ref status);
                        if (status == false)
                        {
                            return BadRequest("Full Queue In PLC");
                        }
                    }
                    catch (Exception ex)
                    {

                        return NotFound();
                    }

                }
                else
                {
                    try
                    {
                        GlobalDataHoya.HoyadataDict[barcode] = hoyaData;
                        Data_Barcode_PLC data_Barcode_ = new Data_Barcode_PLC()
                        {
                            BarCode = barcode,
                            Kind = hoyaData.Ng_Type
                        };
                        bool status = false;
                        if (PLC_Query.PLC_Controller == null || PLC_Query.PLC_Controller.IsConnected == false)
                        {
                            return BadRequest("PLC Is Not Connect");
                        }
                        PLC_Query.AddRack2Queue(data_Barcode_, ref status);
                        if (status == false)
                        {
                            return BadRequest("Full Queue In PLC");
                        }
                    }
                    catch (Exception)
                    {
                        return BadRequest("Full Queue In PLC");
                    }

                }
                return Ok(new { message = "Updated QRCode Rack" });
            }
            else
            {
                return BadRequest("Invalid request data");
            }
        }
    }
    public class MonitorController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            //var data = HistoryLogger.Upload_Rows();
            return Json(GlobalDataHoya.Nhietdo); // Return the list of users as JSON
        }
        [Route("PutNhietDo")]
        [HttpPut]
        public IHttpActionResult PutNhietDo([FromBody] Nhietdo nhietdo)
        {

            if (nhietdo == null)
            {
                return NotFound();
            }
            GlobalDataHoya.Nhietdo = nhietdo;
            if (MachineViewModel.Update_Temperature_Command != null)
            {
                MachineViewModel.Update_Temperature_Command.Execute(null);
            }
            return Json("OK"); // Return the updated user object as JSON
        }
        [Route("PutQRCode")]
        [HttpPut]
        public IHttpActionResult PutQRCode([FromBody] QR QR_)
        {

            switch (QR_.Code)
            {
                //Move Area 1 Done
                case "1m":
                    //MonitorRackData.MoveRack123();
                    SyncProcessData.MovedRack123();
                    if (MachineViewModel.Get_Dip_Time_A1_Command != null)
                    {
                        MachineViewModel.Get_Dip_Time_A1_Command.Execute(true);

                    }
                    PLC_Query.WriteBit(AddressCrt.MoveRack123, false);
                    if (MachineViewModel.Getbarcode_Command != null)
                    {
                        MachineViewModel.Getbarcode_Command.Execute(null);
                    }

                    break;
                //Move Area 2 Done
                case "2m":
                    //MonitorRackData.MoveRack456();
                    SyncProcessData.MovedRack456();
                    MachineViewModel.Get_Dip_Time_Robot.Execute(true);
                    PLC_Query.WriteBit(AddressCrt.MoveRack456, false);
                    MachineViewModel.Getbarcode_Command.Execute(null);

                    break;

                case "2m4":
                    //MonitorRackData.MoveRack456();
                    SyncProcessData.MovedRack456(4);
                    if (MachineViewModel.Get_Dip_Time_Robot != null)
                    {
                        MachineViewModel.Get_Dip_Time_Robot.Execute(true);

                    }
                    PLC_Query.WriteBit(AddressCrt.MoveRack456, false);
                    if (MachineViewModel.Getbarcode_Command != null)
                    {
                        MachineViewModel.Getbarcode_Command.Execute(null);

                    }

                    break;
                case "2m5":
                    //MonitorRackData.MoveRack456();
                    SyncProcessData.MovedRack456(5);
                    if (MachineViewModel.Get_Dip_Time_Robot != null)
                    {
                        MachineViewModel.Get_Dip_Time_Robot.Execute(true);

                    }
                    PLC_Query.WriteBit(AddressCrt.MoveRack456, false);
                    if (MachineViewModel.Getbarcode_Command != null)
                    {
                        MachineViewModel.Getbarcode_Command.Execute(null);

                    }

                    break;
                case "2m6":
                    //MonitorRackData.MoveRack456();
                    SyncProcessData.MovedRack456(6);
                    if (MachineViewModel.Get_Dip_Time_Robot != null)
                    {
                        MachineViewModel.Get_Dip_Time_Robot.Execute(true);

                    }
                    PLC_Query.WriteBit(AddressCrt.MoveRack456, false);
                    if (MachineViewModel.Getbarcode_Command != null)
                    {
                        MachineViewModel.Getbarcode_Command.Execute(null);

                    }

                    break;
                //Move Area 3 Done
                case "3m":
                    //MonitorRackData.MoveRack789_10();
                    SyncProcessData.MovedRack789_10();
                    if (MachineViewModel.Get_Dip_Time_A3_Command != null)
                    {
                        MachineViewModel.Get_Dip_Time_A3_Command.Execute(true);

                    }
                    if (MachineViewModel.Getbarcode_Command != null)
                    {
                        MachineViewModel.Getbarcode_Command.Execute(null);
                    }
                    PLC_Query.WriteBit(AddressCrt.MoveRack789_10, false);
                    break;
                // Trip A1 Done
                case "1t":
                    SyncProcessData.TripDoneRack_123();
                    if (MachineViewModel.Get_Dip_Time_A1_Command != null)
                    {
                        MachineViewModel.Get_Dip_Time_A1_Command.Execute(false);

                    }
                    PLC_Query.WriteBit(AddressCrt.TripDoneRack123, false);
                    break;
                // Trip A2 Done
                case "2t":
                    if (MachineViewModel.Get_Dip_Time_Robot != null)
                    {
                        MachineViewModel.Get_Dip_Time_Robot.Execute(false);

                    }
                    PLC_Query.WriteBit(AddressCrt.TripRackDone456, false);
                    break;
                case "2t4":
                    SyncProcessData.TripDoneRack_456(4);
                    PLC_Query.WriteBit(AddressCrt.TripRackDone456, false);
                    break;
                case "2t5":
                    SyncProcessData.TripDoneRack_456(5);
                    PLC_Query.WriteBit(AddressCrt.TripRackDone456, false);
                    break;
                case "2t6":
                    SyncProcessData.TripDoneRack_456(6);
                    PLC_Query.WriteBit(AddressCrt.TripRackDone456, false);
                    break;
                // Trip A3 Done
                case "3t":
                    SyncProcessData.TripRackDone_798_10();
                    if (MachineViewModel.Get_Dip_Time_A3_Command != null)
                    {
                        MachineViewModel.Get_Dip_Time_A3_Command.Execute(false);
                    }
                    PLC_Query.WriteBit(AddressCrt.TripDoneRack_789_10, false);
                    break;
                //Begin Robot
                case "gr":
                    PLC_Query.Get_ListCodeChar();
                    if (MachineViewModel.Getbarcode_Command != null)
                    {
                        MachineViewModel.Getbarcode_Command.Execute(null);

                    }
                    PLC_Query.WriteBit(AddressCrt.Trigger_GetRack_Infor, false);
                    break;
                //out of qrcode
                case "e":
                    PLC_Query.WriteBit(AddressCrt.SEND_OutofQR, false);
                    break;
                //
                case "d":
                    PLC_Query.WriteBit(AddressCrt.SEND_Done_rack, false);
                    break;
                // Read Barcode Position
                case "l":
                    //PLC_Query.Get_ListCodeChar();
                    break;
                // Read Time Trip 3
                case "m":
                    break;
                //Trip Area 3 Done Trigger
                case "m1":
                    break;
                // Read Time Trip 1
                case "n":
                    break;
                //Trip Area 1 Done Trigger
                case "n1":
                    break;
                // Read Time Trip Robot
                case "o":
                    break;
                // Trip Robot Done trigger
                case "o1":
                    break;
                default:
                    break;

            }
            return Json("OK"); // Return the updated user object as JSON
        }

        [Route("GetRobotTable")]
        [HttpGet]
        public IHttpActionResult GetRobotTable()
        {
            return Json(ApplicationConfig.SystemConfig.Robot_Table_Type);
        }
        [Route("Get_Alarm")]
        [HttpGet]
        public IHttpActionResult Get_Alarm()
        {
            //MainViewModel.Alarm_Page_Command.Execute(null);
            return Json("OK");
        }

    }
    public class QR 
    {
        public string Code { get; set; }
    }
    public class HoyaData
    {
        public string Barcode { get; set; }
        public string Ng_Type { get; set; }
    }
    public class Nhietdo
    {
        public int Temp1 { get; set; }
        public int Temp2 { get; set; }
        public int Temp3 { get; set; }
        public int Temp4 { get; set; }
        public int Temp5 { get; set; }
        public int Temp6 { get; set; }
        public int Temp7 { get; set; }
        public int Temp8 { get; set; }
        public int Temp9 { get; set; }
        public int Temp10 { get; set; }
        public int Temp11 { get; set; }
        public float H1 { get; set; }
        public float T1 { get; set; }
        public float H2 { get; set; }
        public float T2 { get; set; }
    }
    public class InforQueueRack
    {
        public string Bath1_QR { get; set; }
        public string Bath1_T { get; set; }
        public string Bath2_QR { get; set; }
        public string Bath2_T { get; set; }
        public string Bath3_QR { get; set; }
        public string Bath3_T { get; set; }
        public string Bath4_QR { get; set; }
        public string Bath4_T { get; set; }
        public string Bath5_QR { get; set; }
        public string Bath5_T { get; set; }
        public string Bath6_QR { get; set; }
        public string Bath6_T { get; set; }
        public string Bath7_QR { get; set; }
        public string Bath7_T { get; set; }
        public string Bath8_QR { get; set; }
        public string Bath8_T { get; set; }
        public string Bath9_QR { get; set; }
        public string Bath9_T { get; set; }
        public string Bath10_QR { get; set; }
        public string Bath10_T { get; set; }

        public string CBath1_QR { get; set; }
        public string CBath1_T { get; set; }
        public string CBath2_QR { get; set; }
        public string CBath2_T { get; set; }
        public string CBath3_QR { get; set; }
        public string CBath3_T { get; set; }
        public string CBath4_QR { get; set; }
        public string CBath4_T { get; set; }
        public string CBath5_QR { get; set; }
        public string CBath5_T { get; set; }
        public string CBath6_QR { get; set; }
        public string CBath6_T { get; set; }
        public string CBath7_QR { get; set; }
        public string CBath7_T { get; set; }
        public string CBath8_QR { get; set; }
        public string CBath8_T { get; set; }
        public string CBath9_QR { get; set; }
        public string CBath9_T { get; set; }
        public string CBath10_QR { get; set; }
        public string CBath10_T { get; set; }
    }
}
