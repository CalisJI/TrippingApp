using Microsoft.Web.WebView2.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrippingApp.Control
{
    public static class IntanceWeb
    {

        private static WebView2 _instance;

        public static WebView2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new WebView2();
                    // Add any initialization code for the WebView2 control here
                }
                return _instance;
            }
        }
    }
}
