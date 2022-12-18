using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace TrippingApp.Runtime
{
    public class TCP_Runtime
    {
        private static TcpClient Tcp_Client = new TcpClient();
        public static void Initialize()
        {
            
			try
			{
                
			}
			catch (Exception ex)
			{
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
