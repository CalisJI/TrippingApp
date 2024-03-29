﻿using System;
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
    /// Interaction logic for Robot_Manual_ConfigurationView.xaml
    /// </summary>
    public partial class Robot_Manual_ConfigurationView : UserControl
    {
        private static Robot_Manual_ConfigurationView instance;
        public Robot_Manual_ConfigurationView()
        {
            InitializeComponent();
        }
        public static Robot_Manual_ConfigurationView Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Robot_Manual_ConfigurationView();
                }
                return instance;
            }
        }
    }
}
