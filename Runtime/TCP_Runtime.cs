using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using TrippingApp.Logger;
using TrippingApp.Model;

namespace TrippingApp.Runtime
{
    public class TCP_Runtime
    {
        const int PORT_NO = 2000;
        const string SERVER_IP = "192.168.1.5";
        private static TcpListener TcpListener;
        private static Socket socket;
        private static NetworkStream networkStream;

        public static void CreateNetWork()
        {
            try
            {
                bool abv = PLC_Query.CheckConnect(SERVER_IP);
                var ipaddr = IPAddress.Parse(SERVER_IP);
                TcpListener = new TcpListener(ipaddr, PORT_NO);
                TcpListener.Start();
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        // set the TcpListener on port 13000
                        Console.WriteLine("Waiting for connection...");
                        _ = Logger.Logger.Async_write("Waiting for connection...");
                        socket = TcpListener.AcceptSocket();
                        networkStream = new NetworkStream(socket);
                        TcpListener.Start();
                        int aa = 0;
                        DateTime dateTime = DateTime.Now;
                        string store_vl = string.Empty;
                        while (!TcpListener.Pending())
                        {
                            //Console.WriteLine("Connected");
                            //if (networkStream.DataAvailable)
                            //{
                            //    try
                            //    {
                            //        byte[] data = new byte[256];

                            //        var read = networkStream.Read(data, 0, data.Length);

                            //        string str = Encoding.ASCII.GetString(data, 0, read);
                            //        string filter = Regex.Replace(str, @"(\s+|@|&|'|\(|\)|<|>|#|\?|\\|\0|\u0000|\u0001|\u0002|\u0003|\u0004|\u0005)", "");
                            //        string add = filter.Substring(0, filter.Length);
                            //        Console.WriteLine(add);
                            //    }
                            //    catch (Exception)
                            //    {

                            //        //MessageBox.Show("TCP/IP Disconnected");
                            //        CreateNetWork();
                            //        goto DMM;
                            //    }
                            //}
                            do
                            {
                                DateTime dateTime1 = DateTime.Now;
                                try
                                {
                                    byte[] data = new byte[256];

                                    var read = networkStream.Read(data, 0, data.Length);

                                    string str = Encoding.ASCII.GetString(data, 0, read);
                                    string filter = Regex.Replace(str, @"(\s+|@|&|'|\(|\)|<|>|#|\?|\\|\0|\u0000|\u0001|\u0002|\u0003|\u0004|\u0005)", "");
                                    string add = filter.Substring(0, filter.Length);
                                    //Console.WriteLine("Counter: {0}", aa);
                                    //Console.WriteLine("Recaived: {1} {0}", add, DateTime.Now.ToString("HH:mm:ss:ff"));
                                    //UpdateStatus(add);
                                    FuntionSelection(add);
                                }
                                catch (Exception)
                                {
                                    //MessageBox.Show("TCP/IP Disconnected");
                                    CreateNetWork();
                                    goto DMM;
                                }

                            } while (networkStream.DataAvailable);
                            //Console.WriteLine("Recycle");
                        }

                        DMM:;
                    }
                    catch (SocketException e)
                    {
                        Console.WriteLine("SocketException: {0}", e);
                        _ = Logger.Logger.Async_write(string.Format("SocketException: {0}", e));
                    }

                });
                if (!thread.IsAlive)
                {
                    thread.Start();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
          
        }

        public static void FuntionSelection(string _char)
        {

            switch (_char)
            {
                //Move Area 1 Done
                case "a":
                    MonitorRackData.MoveRack123();
                    break;
                //Move Area 2 Done
                case "b":
                    MonitorRackData.MoveRack456();
                    break;
                //Move Area 3 Done
                case "c":
                    MonitorRackData.MoveRack789_10();
                    break;
                // Run Out of Barcode 
                case "d":
                    break;
                // Optional
                case "e":
                    break;
                //Begin Tranfer 1
                case "f":
                    break;
                //Begin Robot
                case "g":
                    break;
                //Begin Tranfer3
                case "h":
                    break;
                //Has Rack Done
                case "k":
                    break;
                // Read Barcode A1
                case "l":
                    PLC_Query.Get_ListCodeChar();
                    break;
                // Read Barcode A2
                case "m":
                    break;
                // Read Barcode A3
                case "n":
                    break;
                default:
                    break;
            }
        }
    }
}
