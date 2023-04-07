using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace TrippingApp.View
{
    /// <summary>
    /// Interaction logic for Manual_View.xaml
    /// </summary>
    public partial class Manual_View : UserControl
    {
        private static Manual_View instance;
        public Manual_View()
        {
            InitializeComponent();
        }
        public static Manual_View Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Manual_View();
                }
                return instance;
            }
        }
    }
}
