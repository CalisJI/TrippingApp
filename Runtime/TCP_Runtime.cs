using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using TrippingApp.Logger;
using TrippingApp.Model;
using TrippingApp.View;
using TrippingApp.ViewModel;

namespace TrippingApp.Runtime
{
    public  static class TCP_Runtime
    {
        const int PORT_NO = 2000;
        const string SERVER_IP = "192.168.1.15";
        public static TcpListener TcpListener;
        private static Socket socket;
        public static bool Connect_TCP = false;
        //private static NetworkStream networkStream;
        
        public static void CreateNetWork()
        {
            try
            {
                bool abv = PLC_Query.CheckConnect(SERVER_IP);
                var ipaddr = IPAddress.Parse(SERVER_IP);
                TcpListener = new TcpListener(IPAddress.Any, PORT_NO);
                TcpListener.Start();
                Thread thread = new Thread(() =>
                {
                    try
                    {
                        // set the TcpListener on port 13000
                        Console.WriteLine("Waiting for connection...");
                        _ = Logger.Logger.Async_write("Waiting for connection...");
                        socket = TcpListener.AcceptSocket();
                        NetworkStream networkStream = new NetworkStream(socket);
                        Console.WriteLine(socket.RemoteEndPoint);
                        TcpListener.Start();
                        int aa = 0;
                        DateTime dateTime = DateTime.Now;
                        string store_vl = string.Empty;
                        while (!TcpListener.Pending())
                        {
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
                                    Console.WriteLine("TCP-IP: " + add);
                                    //FuntionSelection(add);
                                    //networkStream.Close();
                                }
                                catch (Exception)
                                {
                                    //MessageBox.Show("TCP/IP Disconnected");
                                    Console.WriteLine("TCP/IP Disconnected");

                                    goto DMM;
                                }

                            } while (networkStream.DataAvailable);
                            Console.WriteLine("Recycle");
                        }
                       
                        DMM:;
                        CreateNetWork();
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

        public static void CreateNetWork2() 
        {
            TcpListener = new TcpListener(IPAddress.Any, PORT_NO);
            TcpListener.Start();
            
            Thread thread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Console.WriteLine("Waiting for a client to connect...");
                        TcpClient client = TcpListener.AcceptTcpClient();
                        Console.WriteLine("Client connected: {0}", client.Client.RemoteEndPoint);
                        Connect_TCP = true;
                        // Get the network stream from the client
                        NetworkStream stream = client.GetStream();

                        // Read data from the client
                        byte[] buffer = new byte[1024];
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string data = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        string filter = Regex.Replace(data, @"(\s+|@|&|'|\(|\)|<|>|#|\?|\\|\0|\u0000|\u0001|\u0002|\u0003|\u0004|\u0005)", "");
                        string add = filter.Substring(0, filter.Length);
                        Console.WriteLine("TCP-IP: " + add);
                        FuntionSelection(add);
                        stream.Close();
                        client.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("TCP Function");
                        Console.WriteLine(ex.Message);
                    }
                   
                }
            });

            if (!thread.IsAlive) 
            {
                thread.Start();
            }
           
        }

        public static void FuntionSelection(string _char)
        {
            try
            {
                switch (_char)
                {
                    //Move Area 1 Done
                    case "1m":
                        //MonitorRackData.MoveRack123();
                        SyncProcessData.MovedRack123();
                        MachineViewModel.Get_Dip_Time_A1_Command.Execute(true);
                        PLC_Query.WriteBit(AddressCrt.MoveRack123, false);
                        MachineViewModel.Getbarcode_Command.Execute(null);

                        break;
                    //Move Area 2 Done
                    case "2m":
                        //MonitorRackData.MoveRack456();
                        SyncProcessData.MovedRack456();
                        MachineViewModel.Get_Dip_Time_Robot.Execute(true);
                        PLC_Query.WriteBit(AddressCrt.MoveRack456, false);
                        MachineViewModel.Getbarcode_Command.Execute(null);

                        break;
                    //Move Area 3 Done
                    case "3m":
                        //MonitorRackData.MoveRack789_10();
                        SyncProcessData.MovedRack789_10();
                        MachineViewModel.Get_Dip_Time_A3_Command.Execute(true);
                        MachineViewModel.Getbarcode_Command.Execute(null);
                        PLC_Query.WriteBit(AddressCrt.MoveRack789_10, false);
                        break;
                    // Trip A1 Done
                    case "1t":
                            SyncProcessData.TripDoneRack_123();
                        MachineViewModel.Get_Dip_Time_A1_Command.Execute(false);
                        PLC_Query.WriteBit(AddressCrt.TripDoneRack123, false);
                        break;
                    // Trip A2 Done
                    case "2t":
                        SyncProcessData.TripDoneRack_456();
                        MachineViewModel.Get_Dip_Time_Robot.Execute(false);
                        PLC_Query.WriteBit(AddressCrt.TripRackDone456, false);
                        break;
                    // Trip A3 Done
                    case "3t":
                        SyncProcessData.TripRackDone_798_10();
                        MachineViewModel.Get_Dip_Time_A3_Command.Execute(false);
                        PLC_Query.WriteBit(AddressCrt.TripDoneRack_789_10, false);
                        break;
                    //Begin Robot
                    case "gr":
                        MachineViewModel.Getbarcode_Command.Execute(null);
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
            }
            catch (Exception)
            {

                Console.WriteLine("ERROR WWITH PLC");
            }
        }
    }
}
