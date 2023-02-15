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

namespace TrippingApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

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
    }
}
