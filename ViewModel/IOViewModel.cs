using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using System.Xml.Linq;
using TrippingApp.Runtime;

namespace TrippingApp.ViewModel
{
    public class IOViewModel:BaseViewModel.BaseViewModel
    {

        private ObservableCollection<InputTag> _itags;

        public ObservableCollection<InputTag> Itags
        {
            get { return _itags; }
            set { SetProperty(ref _itags, value, nameof(Itags)); }
        }

        private ObservableCollection<OutputTag> _oTag;

        public ObservableCollection<OutputTag> OTags
        {
            get { return _oTag; }
            set { SetProperty(ref _oTag, value, nameof(OTags)); }
        }
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        private DispatcherTimer DispatcherTimer = new DispatcherTimer();
        public IOViewModel()
        {
            LoadXml();
            DispatcherTimer.Interval = new TimeSpan(250);
            DispatcherTimer.Tick += DispatcherTimer_Tick;
            Loaded = new ActionCommand(() =>
            {
                //if(DispatcherTimer.IsEnabled == false) 
                //{
                //    DispatcherTimer.Start();
                //    DispatcherTimer.IsEnabled = true;
                //}
            });

            Unloaded = new ActionCommand(() =>
            {
                //if (DispatcherTimer.IsEnabled == true)
                //{
                //    DispatcherTimer.Stop();
                //    DispatcherTimer.IsEnabled = false;
                //}
                GC.Collect();
            });
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {
            RefreshIO();
        }

        public void LoadXml()
        {
            try
            {
                XDocument xdoc = XDocument.Load("./Init/IOTagsEdit.xml");
                IEnumerable<XElement> tags = xdoc.Descendants("Tag");
                if (Itags == null)
                {
                    Itags = new ObservableCollection<InputTag>();
                }

                if (OTags == null)
                {
                    OTags = new ObservableCollection<OutputTag>();
                }
                // Add rows to the DataTable from the Tags in the XDocument object
                foreach (XElement tag in tags)
                {
                    if (tag.Attribute("addr").Value.StartsWith("I"))
                    {
                        InputTag inputTag = new InputTag()
                        {
                            Address = tag.Attribute("addr").Value,
                            Name = tag.Value,
                            Value = false
                        };
                        Itags.Add(inputTag);
                    }
                    else if (tag.Attribute("addr").Value.StartsWith("Q"))
                    {
                        OutputTag OutputTag = new OutputTag()
                        {
                            Address = tag.Attribute("addr").Value,
                            Name = tag.Value,
                            Value = false
                        };
                        OTags.Add(OutputTag);
                    }


                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
           
           
            // Bind the DataTable to a DataGrid in WPF
        }
        public void RefreshIO() 
        {
            if (PLC_Query.Connected)
            {

                PLC_Query.ReadOutput();
                PLC_Query.ReadInput();
                PropertyInfo[] properties = typeof(PLCOutput).GetProperties();
                PropertyInfo[] properties1 = typeof(PLCInput).GetProperties();
                for (int i = 0; i < properties.Length; i++)
                {
                    try
                    {
                        string pname = properties[i].Name;
                        var item = OTags.Where(x => x.Address.Replace(".", "") == pname).FirstOrDefault();
                        if(item != null) 
                        {
                            item.Value = (bool)properties[i].GetValue(PLC_Query.PLCOutput);
                         
                        }
                    }
                    catch (Exception)
                    {

                       
                    }
                }
                for (int i = 0; i < properties1.Length; i++)
                {
                    try
                    {
                        string pname = properties1[i].Name;
                        var item = Itags.Where(x => x.Address.Replace(".", "") == pname).FirstOrDefault();
                        if (item != null)
                        {
                            item.Value = (bool)properties1[i].GetValue(PLC_Query.PLCInput);
                           
                        }
                    }
                    catch (Exception ex)
                    {


                    }
                }
                CollectionViewSource.GetDefaultView(Itags).Refresh();
                CollectionViewSource.GetDefaultView(OTags).Refresh();
                GC.Collect();
            }
           
        }
    }
    public class InputTag
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Value { get; set; }
    }
    public class OutputTag 
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public bool Value { get; set; }
    }
}
