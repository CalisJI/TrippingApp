using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace TrippingApp.Control
{
    /// <summary>
    /// Interaction logic for Cylender_Control.xaml
    /// </summary>
    public partial class Cylender_Control : UserControl
    {


        public bool SS1_Up
        {
            get { return (bool)GetValue(SS1_UpProperty); }
            set { SetValue(SS1_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS1_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS1_UpProperty =
            DependencyProperty.Register("SS1_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false));




        public bool SS1_Down
        {
            get { return (bool)GetValue(SS1_DownProperty); }
            set { SetValue(SS1_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS1_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS1_DownProperty =
            DependencyProperty.Register("SS1_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false));


        public bool SS2_Up
        {
            get { return (bool)GetValue(SS2_UpProperty); }
            set { SetValue(SS2_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS2_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS2_UpProperty =
            DependencyProperty.Register("SS2_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false));




        public bool SS2_Down
        {
            get { return (bool)GetValue(SS2_DownProperty); }
            set { SetValue(SS2_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS2_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS2_DownProperty =
            DependencyProperty.Register("SS2_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));


        public bool SS3_Up
        {
            get { return (bool)GetValue(SS3_UpProperty); }
            set { SetValue(SS3_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS3_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS3_UpProperty =
            DependencyProperty.Register("SS3_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS3_Down
        {
            get { return (bool)GetValue(SS3_DownProperty); }
            set { SetValue(SS3_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS3_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS3_DownProperty =
            DependencyProperty.Register("SS3_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS4_Up
        {
            get { return (bool)GetValue(SS4_UpProperty); }
            set { SetValue(SS4_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS4_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS4_UpProperty =
            DependencyProperty.Register("SS4_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS4_Down
        {
            get { return (bool)GetValue(SS4_DownProperty); }
            set { SetValue(SS4_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS4_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS4_DownProperty =
            DependencyProperty.Register("SS4_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS5_Up
        {
            get { return (bool)GetValue(SS5_UpProperty); }
            set { SetValue(SS5_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS5_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS5_UpProperty =
            DependencyProperty.Register("SS5_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS5_Down
        {
            get { return (bool)GetValue(SS5_DownProperty); }
            set { SetValue(SS5_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS5_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS5_DownProperty =
            DependencyProperty.Register("SS5_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS6_Up
        {
            get { return (bool)GetValue(SS6_UpProperty); }
            set { SetValue(SS6_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS6_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS6_UpProperty =
            DependencyProperty.Register("SS6_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS6_Down
        {
            get { return (bool)GetValue(SS6_DownProperty); }
            set { SetValue(SS6_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS6_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS6_DownProperty =
            DependencyProperty.Register("SS6_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS7_Up
        {
            get { return (bool)GetValue(SS7_UpProperty); }
            set { SetValue(SS7_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS7_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS7_UpProperty =
            DependencyProperty.Register("SS7_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS7_Down
        {
            get { return (bool)GetValue(SS7_DownProperty); }
            set { SetValue(SS7_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS7_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS7_DownProperty =
            DependencyProperty.Register("SS7_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS8_Up
        {
            get { return (bool)GetValue(SS8_UpProperty); }
            set { SetValue(SS8_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS8_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS8_UpProperty =
            DependencyProperty.Register("SS8_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS8_Down
        {
            get { return (bool)GetValue(SS8_DownProperty); }
            set { SetValue(SS8_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS8_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS8_DownProperty =
            DependencyProperty.Register("SS8_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS9_Up
        {
            get { return (bool)GetValue(SS9_UpProperty); }
            set { SetValue(SS9_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS9_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS9_UpProperty =
            DependencyProperty.Register("SS9_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS9_Down
        {
            get { return (bool)GetValue(SS9_DownProperty); }
            set { SetValue(SS9_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS9_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS9_DownProperty =
            DependencyProperty.Register("SS9_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS10_Up
        {
            get { return (bool)GetValue(SS10_UpProperty); }
            set { SetValue(SS10_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS10_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS10_UpProperty =
            DependencyProperty.Register("SS10_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS10_Down
        {
            get { return (bool)GetValue(SS10_DownProperty); }
            set { SetValue(SS10_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS10_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS10_DownProperty =
            DependencyProperty.Register("SS10_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS11_Up
        {
            get { return (bool)GetValue(SS11_UpProperty); }
            set { SetValue(SS11_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS11_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS11_UpProperty =
            DependencyProperty.Register("SS11_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS11_Down
        {
            get { return (bool)GetValue(SS11_DownProperty); }
            set { SetValue(SS11_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS11_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS11_DownProperty =
            DependencyProperty.Register("SS11_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS12_Up
        {
            get { return (bool)GetValue(SS12_UpProperty); }
            set { SetValue(SS12_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS12_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS12_UpProperty =
            DependencyProperty.Register("SS12_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS12_Down
        {
            get { return (bool)GetValue(SS12_DownProperty); }
            set { SetValue(SS12_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS12_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS12_DownProperty =
            DependencyProperty.Register("SS12_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS13_Up
        {
            get { return (bool)GetValue(SS13_UpProperty); }
            set { SetValue(SS13_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS13_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS13_UpProperty =
            DependencyProperty.Register("SS13_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS13_Down
        {
            get { return (bool)GetValue(SS13_DownProperty); }
            set { SetValue(SS13_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS13_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS13_DownProperty =
            DependencyProperty.Register("SS13_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool SS14_Up
        {
            get { return (bool)GetValue(SS14_UpProperty); }
            set { SetValue(SS14_UpProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS14_Up.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS14_UpProperty =
            DependencyProperty.Register("SS14_Up", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));




        public bool SS14_Down
        {
            get { return (bool)GetValue(SS14_DownProperty); }
            set { SetValue(SS14_DownProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SS14_Down.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SS14_DownProperty =
            DependencyProperty.Register("SS14_Down", typeof(bool), typeof(Cylender_Control), new FrameworkPropertyMetadata(false,FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));



        public ICommand XL1_Up_Command
        {
            get { return (ICommand)GetValue(XL1_Up_CommandProperty); }
            set { SetValue(XL1_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL1_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL1_Up_CommandProperty =
            DependencyProperty.Register("XL1_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL1_Down_Command
        {
            get { return (ICommand)GetValue(XL1_Down_CommandProperty); }
            set { SetValue(XL1_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL1_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL1_Down_CommandProperty =
            DependencyProperty.Register("XL1_Down_Command", typeof(ICommand), typeof(Cylender_Control));

        public ICommand XL2_Up_Command
        {
            get { return (ICommand)GetValue(XL2_Up_CommandProperty); }
            set { SetValue(XL2_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL2_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL2_Up_CommandProperty =
            DependencyProperty.Register("XL2_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL2_Down_Command
        {
            get { return (ICommand)GetValue(XL2_Down_CommandProperty); }
            set { SetValue(XL2_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL2_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL2_Down_CommandProperty =
            DependencyProperty.Register("XL2_Down_Command", typeof(ICommand), typeof(Cylender_Control));

        public ICommand XL3_Up_Command
        {
            get { return (ICommand)GetValue(XL3_Up_CommandProperty); }
            set { SetValue(XL3_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL3_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL3_Up_CommandProperty =
            DependencyProperty.Register("XL3_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL3_Down_Command
        {
            get { return (ICommand)GetValue(XL3_Down_CommandProperty); }
            set { SetValue(XL3_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL3_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL3_Down_CommandProperty =
            DependencyProperty.Register("XL3_Down_Command", typeof(ICommand), typeof(Cylender_Control));


        public ICommand XL4_Up_Command
        {
            get { return (ICommand)GetValue(XL4_Up_CommandProperty); }
            set { SetValue(XL4_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL4_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL4_Up_CommandProperty =
            DependencyProperty.Register("XL4_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL4_Down_Command
        {
            get { return (ICommand)GetValue(XL4_Down_CommandProperty); }
            set { SetValue(XL4_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL4_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL4_Down_CommandProperty =
            DependencyProperty.Register("XL4_Down_Command", typeof(ICommand), typeof(Cylender_Control));

        public ICommand XL5_Up_Command
        {
            get { return (ICommand)GetValue(XL5_Up_CommandProperty); }
            set { SetValue(XL5_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL5_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL5_Up_CommandProperty =
            DependencyProperty.Register("XL5_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL5_Down_Command
        {
            get { return (ICommand)GetValue(XL5_Down_CommandProperty); }
            set { SetValue(XL5_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL5_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL5_Down_CommandProperty =
            DependencyProperty.Register("XL5_Down_Command", typeof(ICommand), typeof(Cylender_Control));


        public ICommand XL6_Up_Command
        {
            get { return (ICommand)GetValue(XL6_Up_CommandProperty); }
            set { SetValue(XL6_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL6_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL6_Up_CommandProperty =
            DependencyProperty.Register("XL6_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL6_Down_Command
        {
            get { return (ICommand)GetValue(XL6_Down_CommandProperty); }
            set { SetValue(XL6_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL6_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL6_Down_CommandProperty =
            DependencyProperty.Register("XL6_Down_Command", typeof(ICommand), typeof(Cylender_Control));

        public ICommand XL7_Up_Command
        {
            get { return (ICommand)GetValue(XL7_Up_CommandProperty); }
            set { SetValue(XL7_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL7_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL7_Up_CommandProperty =
            DependencyProperty.Register("XL7_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL7_Down_Command
        {
            get { return (ICommand)GetValue(XL7_Down_CommandProperty); }
            set { SetValue(XL7_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL7_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL7_Down_CommandProperty =
            DependencyProperty.Register("XL7_Down_Command", typeof(ICommand), typeof(Cylender_Control));


        public ICommand XL8_Up_Command
        {
            get { return (ICommand)GetValue(XL8_Up_CommandProperty); }
            set { SetValue(XL8_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL8_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL8_Up_CommandProperty =
            DependencyProperty.Register("XL8_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL8_Down_Command
        {
            get { return (ICommand)GetValue(XL8_Down_CommandProperty); }
            set { SetValue(XL8_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL8_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL8_Down_CommandProperty =
            DependencyProperty.Register("XL8_Down_Command", typeof(ICommand), typeof(Cylender_Control));


        public ICommand XL9_Up_Command
        {
            get { return (ICommand)GetValue(XL9_Up_CommandProperty); }
            set { SetValue(XL9_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL9_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL9_Up_CommandProperty =
            DependencyProperty.Register("XL9_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL9_Down_Command
        {
            get { return (ICommand)GetValue(XL9_Down_CommandProperty); }
            set { SetValue(XL9_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL9_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL9_Down_CommandProperty =
            DependencyProperty.Register("XL9_Down_Command", typeof(ICommand), typeof(Cylender_Control));


        public ICommand XL10_Up_Command
        {
            get { return (ICommand)GetValue(XL10_Up_CommandProperty); }
            set { SetValue(XL10_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL10_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL10_Up_CommandProperty =
            DependencyProperty.Register("XL10_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL10_Down_Command
        {
            get { return (ICommand)GetValue(XL10_Down_CommandProperty); }
            set { SetValue(XL10_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL10_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL10_Down_CommandProperty =
            DependencyProperty.Register("XL10_Down_Command", typeof(ICommand), typeof(Cylender_Control));


        public ICommand XL11_Up_Command
        {
            get { return (ICommand)GetValue(XL11_Up_CommandProperty); }
            set { SetValue(XL11_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL11_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL11_Up_CommandProperty =
            DependencyProperty.Register("XL11_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL11_Down_Command
        {
            get { return (ICommand)GetValue(XL11_Down_CommandProperty); }
            set { SetValue(XL11_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL11_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL11_Down_CommandProperty =
            DependencyProperty.Register("XL11_Down_Command", typeof(ICommand), typeof(Cylender_Control));


        public ICommand XL12_Up_Command
        {
            get { return (ICommand)GetValue(XL12_Up_CommandProperty); }
            set { SetValue(XL12_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL12_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL12_Up_CommandProperty =
            DependencyProperty.Register("XL12_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL12_Down_Command
        {
            get { return (ICommand)GetValue(XL12_Down_CommandProperty); }
            set { SetValue(XL12_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL12_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL12_Down_CommandProperty =
            DependencyProperty.Register("XL12_Down_Command", typeof(ICommand), typeof(Cylender_Control));

        public ICommand XL13_Up_Command
        {
            get { return (ICommand)GetValue(XL13_Up_CommandProperty); }
            set { SetValue(XL13_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL13_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL13_Up_CommandProperty =
            DependencyProperty.Register("XL13_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL13_Down_Command
        {
            get { return (ICommand)GetValue(XL13_Down_CommandProperty); }
            set { SetValue(XL13_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL13_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL13_Down_CommandProperty =
            DependencyProperty.Register("XL13_Down_Command", typeof(ICommand), typeof(Cylender_Control));

        public ICommand XL14_Up_Command
        {
            get { return (ICommand)GetValue(XL14_Up_CommandProperty); }
            set { SetValue(XL14_Up_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL14_Up_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL14_Up_CommandProperty =
            DependencyProperty.Register("XL14_Up_Command", typeof(ICommand), typeof(Cylender_Control));



        public ICommand XL14_Down_Command
        {
            get { return (ICommand)GetValue(XL14_Down_CommandProperty); }
            set { SetValue(XL14_Down_CommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for XL14_Down_Command.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty XL14_Down_CommandProperty =
            DependencyProperty.Register("XL14_Down_Command", typeof(ICommand), typeof(Cylender_Control));



        public Cylender_Control()
        {
            InitializeComponent();
        }
    }
    public class CvtSensorSignal : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value)
            {
                return Colors.Red;
            }
            else
            {
                return Colors.DarkGray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
