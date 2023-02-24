using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;
using System.Windows;


namespace TrippingApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        
        public App()
        {
            var config = new HttpSelfHostConfiguration("http://0.0.0.0:5001");
            config.Routes.MapHttpRoute("API Default", "api/{controller}/{action}/{id}", new { id = RouteParameter.Optional,action = RouteParameter.Optional });
            var server = new HttpSelfHostServer(config);
            server.OpenAsync().Wait();
            try
            {
                new AppConfig.ApplicationConfig();
                SetStartup();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }
        private void SetStartup()
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            registryKey.SetValue("TrippingApp", Directory.GetCurrentDirectory());
        }
    }
}
