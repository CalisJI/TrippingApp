using BusyIndicator;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace TrippingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        int count_hold = 0;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                timer.Interval = new TimeSpan(100);
                timer.Tick += Timer_Tick;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }
            
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            count_hold++;
            if(count_hold >= 30)
            {
                Environment.Exit(0);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var workbenchName = "MySQLWorkbench";

            var process = Process.GetProcessesByName(workbenchName);
            if (process.Length > 0)
            {
                process[0].Kill();
                Console.WriteLine("MySQL Workbench has been shut down.");
            }
            else
            {
                Console.WriteLine("MySQL Workbench is not running.");
            }
        }

        private void Button_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                timer.Start();
            }
            catch (Exception)
            {

            }
        }

        private void Button_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            try
            {
                timer.Stop();
                count_hold = 0;
            }
            catch (Exception)
            {

            }
        }

        private void Button_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            try
            {
                timer.Start();
            }
            catch (Exception)
            {

            }
        }

        private void Button_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            try
            {
                timer.Stop();
                count_hold = 0;
            }
            catch (Exception)
            {

            }
        }
    }
}
