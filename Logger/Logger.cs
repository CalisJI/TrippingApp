using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrippingApp.AppConfig;

namespace TrippingApp.Logger
{
    public static class Logger
    {
        public static async Task Async_write(string jd)
        {
            void act()
            {
                try
                {
                    using (StreamWriter sw = File.AppendText(ApplicationConfig.File_Logger))
                    {
                        DateTime dateTime = DateTime.Now;
                        _ = dateTime.ToString("HH:mm:ss");
                        string aa = "[" + dateTime + "] " + jd;
                        sw.WriteLine(aa);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            };
            Task a = new Task(act);
            a.Start();
            await a;
        }
    }
}
