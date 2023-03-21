using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Math.Field;
using Owin;
using TrippingApp.Model;
using TrippingApp.Runtime;
using TrippingApp.ViewModel;

namespace TrippingApp.APIController
{
    public static class GlobalDataHoya
    {

        public static List<HoyaData> hoyaDatas = new List<HoyaData> ();
        public static Nhietdo Nhietdo = new Nhietdo();
        public static Dictionary<string, HoyaData> HoyadataDict = new Dictionary<string, HoyaData>();
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
            var user = GlobalDataHoya.hoyaDatas.FirstOrDefault(u=>u.Barcode==id);
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
            return Json(new {message = "OK"}); // Return the updated user object as JSON
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
                        if(status == false) 
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
        [HttpPut]
        public IHttpActionResult Put([FromBody] Nhietdo nhietdo)
        {
            
            if (nhietdo == null)
            {
                return NotFound();
            }
            GlobalDataHoya.Nhietdo = nhietdo;
            MachineViewModel.Update_Temperature_Command.Execute(null);
            return Json("OK"); // Return the updated user object as JSON
        }
       
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
    }
    
}
