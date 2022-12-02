using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Diagnostics;

namespace TrippingApp.Runtime
{
    public class GetApi
    {
        public static async void GetData(string url)
        {
            try
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    HttpResponseMessage message = await httpClient.GetAsync($"{url}");
                    message.EnsureSuccessStatusCode();

                    object data = message.Content.ReadAsStringAsync().Result;
                    string ketqua = data.ToString();
                    var somthing = JsonSerializer.Deserialize<dynamic>(ketqua);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "IS SERVER RUNNING AT THE PORT?");
                string a = "NO Data";
                object err = (object)a;
            }
            
        }
    }
}
