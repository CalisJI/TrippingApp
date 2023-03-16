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

namespace TrippingApp.APIController
{
    public static class GlobalDataHoya
    {
        
        public static List<HoyaData> hoyaDatas = new List<HoyaData>
        {
            new HoyaData { Id = 1, Name = "John", Age = 30 },
            new HoyaData { Id = 2, Name = "Jane", Age = 25 },
            new HoyaData { Id = 3, Name = "Bob", Age = 40 }
        };
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
        public IHttpActionResult Get(int id)
        {
            var user = GlobalDataHoya.hoyaDatas.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return Json(user); // Return the user object as JSON
        }

        // PUT api/user/5
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] HoyaData hoyaData)
        {
            var existingUser = GlobalDataHoya.hoyaDatas.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return NotFound();
            }
            existingUser.Name = hoyaData.Name;
            existingUser.Age = hoyaData.Age;
            return Json(existingUser); // Return the updated user object as JSON
        }
        [HttpPost]
        public IHttpActionResult AddItem([FromBody] HoyaData item)
        {
            string keyCode = "HY-000";
            
            if (GlobalDataHoya.hoyaDatas.Any(i => i.Id == item.Id))
            {
                int newId = GlobalDataHoya.hoyaDatas.Count > 0 ? GlobalDataHoya.hoyaDatas.Max(i => i.Id) + 1 : 1;
                item.Id = newId;
            }
            GlobalDataHoya.hoyaDatas.Add(new HoyaData
            {
                Id = item.Id,
                 Age = item.Age,
                 Name = item.Name
            });

            if (!GlobalDataHoya.HoyadataDict.ContainsKey(keyCode))
            {
                GlobalDataHoya.HoyadataDict.Add(keyCode, item);   
            }
            else 
            {
                GlobalDataHoya.HoyadataDict[keyCode] = item;
            }
            RackObject rackObject = new RackObject()
            {
                RackBarcode = keyCode,
                NGType = "1",
                Data = item,
                RackStatus = Status.Inprocess,
                Bath1_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath2_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath3_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath4_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath5_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath6_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath7_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath8_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath9_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                },
                Bath10_Infor = new BathInformation()
                {
                    BathTemper = 0,
                    TimeIn = DateTime.Now,
                    TimeOut = new DateTime()
                }
                
            };
            HistoryLogger.AddRackObject(rackObject);
            return Json(new { message = "Item added successfully" });
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
                JObject hoyadt = data.GetValue("HoyaData") as JObject;
                HoyaData hoyaData = hoyadt.ToObject<HoyaData>();
                if (!GlobalDataHoya.HoyadataDict.ContainsKey(barcode))
                {
                    GlobalDataHoya.HoyadataDict.Add(barcode, hoyaData);
                }
                else 
                {
                    GlobalDataHoya.HoyadataDict[barcode] = hoyaData;
                }
                return Ok(new { message = "Update Barcode Rack" });
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
            return Json("OK"); // Return the updated user object as JSON
        }
       
    }
    public class HoyaData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
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
