﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UserControl = System.Windows.Controls.UserControl;

namespace TrippingApp.View
{
    /// <summary>
    /// Interaction logic for IOView.xaml
    /// </summary>
    public partial class IOView : UserControl
    {
        private static IOView instance; 
        public IOView()
        {
            InitializeComponent();
        }
        public static IOView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new IOView();
                }
                return instance;
            }
        }
    }
}
