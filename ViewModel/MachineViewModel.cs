using Microsoft.Expression.Interactivity.Core;
using S7.Net.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using TrippingApp.Runtime;
using DateTime = System.DateTime;

namespace TrippingApp.ViewModel
{
    public class MachineViewModel : BaseViewModel.BaseViewModel
    {
        #region Command
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        public static ICommand Getbarcode_Command { get; set; }
        public static ICommand Get_Input_Time_Command { get; set; }
        public static ICommand Get_Trip_Time_Command { get; set; }
        #endregion

        #region Model
        //bath 1
        private float _temper1;

        public float Temper1
        {
            get { return _temper1; }
            set { SetProperty(ref _temper1, value, nameof(Temper1)); }
        }


        private string _barcode1;

        public string Barcode1
        {
            get { return _barcode1; }
            set { SetProperty(ref _barcode1, value, nameof(Barcode1)); }
        }


        private string _diptime1;

        public string DipTime1
        {
            get { return _diptime1; }
            set { SetProperty(ref _diptime1, value, nameof(DipTime1)); }
        }


        private string _inputtime1;

        public string ImputTime1
        {
            get { return _inputtime1; }
            set { SetProperty(ref _inputtime1, value, nameof(ImputTime1)); }
        }


        //bath 2
        private float _temper2;

        public float Temper2
        {
            get { return _temper2; }
            set { SetProperty(ref _temper2, value, nameof(Temper2)); }
        }


        private string _barcode2;

        public string Barcode2
        {
            get { return _barcode2; }
            set { SetProperty(ref _barcode2, value, nameof(Barcode2)); }
        }


        private string _diptime2;

        public string DipTime2
        {
            get { return _diptime2; }
            set { SetProperty(ref _diptime2, value, nameof(DipTime2)); }
        }


        private string _inputtime2;

        public string ImputTime2
        {
            get { return _inputtime2; }
            set { SetProperty(ref _inputtime2, value, nameof(ImputTime2)); }
        }


        //bath 3
        private float _temper3;

        public float Temper3
        {
            get { return _temper3; }
            set { SetProperty(ref _temper3, value, nameof(Temper3)); }
        }


        private string _barcode3;

        public string Barcode3
        {
            get { return _barcode3; }
            set { SetProperty(ref _barcode3, value, nameof(Barcode3)); }
        }


        private string _diptime3;

        public string DipTime3
        {
            get { return _diptime3; }
            set { SetProperty(ref _diptime3, value, nameof(DipTime3)); }
        }


        private string _inputtime3;

        public string ImputTime3
        {
            get { return _inputtime3; }
            set { SetProperty(ref _inputtime3, value, nameof(ImputTime3)); }
        }

        //bath 4
        private float _temper4;

        public float Temper4
        {
            get { return _temper4; }
            set { SetProperty(ref _temper4, value, nameof(Temper4)); }
        }


        private string _barcode4;

        public string Barcode4
        {
            get { return _barcode4; }
            set { SetProperty(ref _barcode4, value, nameof(Barcode4)); }
        }


        private string _diptime4;

        public string DipTime4
        {
            get { return _diptime4; }
            set { SetProperty(ref _diptime4, value, nameof(DipTime4)); }
        }


        private string _inputtime4;

        public string ImputTime4
        {
            get { return _inputtime4; }
            set { SetProperty(ref _inputtime4, value, nameof(ImputTime4)); }
        }

        //bath 5
        private float _temper5;

        public float Temper5
        {
            get { return _temper5; }
            set { SetProperty(ref _temper5, value, nameof(Temper5)); }
        }


        private string _barcode5;

        public string Barcode5
        {
            get { return _barcode5; }
            set { SetProperty(ref _barcode5, value, nameof(Barcode5)); }
        }


        private string _diptime5;

        public string DipTime5
        {
            get { return _diptime5; }
            set { SetProperty(ref _diptime5, value, nameof(DipTime5)); }
        }


        private string _inputtime5;

        public string ImputTime5
        {
            get { return _inputtime5; }
            set { SetProperty(ref _inputtime5, value, nameof(ImputTime5)); }
        }

        //bath 6
        private float _temper6;

        public float Temper6
        {
            get { return _temper6; }
            set { SetProperty(ref _temper6, value, nameof(Temper6)); }
        }


        private string _barcode6;

        public string Barcode6
        {
            get { return _barcode6; }
            set { SetProperty(ref _barcode6, value, nameof(Barcode6)); }
        }


        private string _diptime6;

        public string DipTime6
        {
            get { return _diptime6; }
            set { SetProperty(ref _diptime6, value, nameof(DipTime6)); }
        }


        private string _inputtime6;

        public string ImputTime6
        {
            get { return _inputtime6; }
            set { SetProperty(ref _inputtime6, value, nameof(ImputTime6)); }
        }

        //bath 7
        private float _temper7;

        public float Temper7
        {
            get { return _temper7; }
            set { SetProperty(ref _temper7, value, nameof(Temper7)); }
        }


        private string _barcode7;

        public string Barcode7
        {
            get { return _barcode7; }
            set { SetProperty(ref _barcode7, value, nameof(Barcode7)); }
        }


        private string _diptime7;

        public string DipTime7
        {
            get { return _diptime7; }
            set { SetProperty(ref _diptime7, value, nameof(DipTime7)); }
        }


        private string _inputtime7;

        public string ImputTime7
        {
            get { return _inputtime7; }
            set { SetProperty(ref _inputtime7, value, nameof(ImputTime7)); }
        }

        //bath 8
        private float _temper8;

        public float Temper8
        {
            get { return _temper8; }
            set { SetProperty(ref _temper8, value, nameof(Temper8)); }
        }


        private string _barcode8;

        public string Barcode8
        {
            get { return _barcode8; }
            set { SetProperty(ref _barcode8, value, nameof(Barcode8)); }
        }


        private string _diptime8;

        public string DipTime8
        {
            get { return _diptime8; }
            set { SetProperty(ref _diptime8, value, nameof(DipTime8)); }
        }


        private string _inputtime8;

        public string ImputTime8
        {
            get { return _inputtime8; }
            set { SetProperty(ref _inputtime8, value, nameof(ImputTime8)); }
        }

        //bath 9
        private float _temper9;

        public float Temper9
        {
            get { return _temper9; }
            set { SetProperty(ref _temper9, value, nameof(Temper9)); }
        }


        private string _barcode9;

        public string Barcode9
        {
            get { return _barcode9; }
            set { SetProperty(ref _barcode9, value, nameof(Barcode9)); }
        }


        private string _diptime9;

        public string DipTime9
        {
            get { return _diptime9; }
            set { SetProperty(ref _diptime9, value, nameof(DipTime9)); }
        }


        private string _inputtime9;

        public string ImputTime9
        {
            get { return _inputtime9; }
            set { SetProperty(ref _inputtime9, value, nameof(ImputTime9)); }
        }

        //bath 10
        private float _temper10;

        public float Temper10
        {
            get { return _temper10; }
            set { SetProperty(ref _temper10, value, nameof(Temper10)); }
        }


        private string _barcode10;

        public string Barcode10
        {
            get { return _barcode10; }
            set { SetProperty(ref _barcode10, value, nameof(Barcode10)); }
        }


        private string _diptime10;

        public string DipTime10
        {
            get { return _diptime10; }
            set { SetProperty(ref _diptime10, value, nameof(DipTime10)); }
        }


        private string _inputtime10;

        public string ImputTime10
        {
            get { return _inputtime10; }
            set { SetProperty(ref _inputtime10, value, nameof(ImputTime10)); }
        }
        #endregion


        public MachineViewModel()
        {
            Loaded = new ActionCommand(() => 
            {
            
            });

            Unloaded = new ActionCommand(() =>
            {
            
            });

            Getbarcode_Command = new ActionCommand(() => 
            {
                Barcode1 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath1_P1);
                Barcode2 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath2_P1);
                Barcode3 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath3_P1);
                Barcode4 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath4_P1);
                Barcode5 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath5_P1);
                Barcode6 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath6_P1);
                Barcode7 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath7_P1);
                Barcode8 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath8_P1);
                Barcode9 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath9_P1);
                Barcode10 = S7String.FromByteArray(PLC_Query.LIST_CODE_CHAR.Contain_In_Bath10_P1);
            });
            Get_Input_Time_Command = new ActionCommand((p) => 
            {
                if((int)p == 1)
                {
                    DateTime dateTime = DateTime.Now;
                    ImputTime1 = dateTime.ToShortTimeString(); 
                    ImputTime2 = dateTime.ToShortTimeString();
                    ImputTime3 = dateTime.ToShortTimeString(); 
                }
                else if((int)p == 2) 
                {
                    DateTime dateTime = DateTime.Now;
                    ImputTime4 = dateTime.ToShortTimeString();
                    ImputTime5 = dateTime.ToShortTimeString();
                    ImputTime6 = dateTime.ToShortTimeString();

                }
                else if ((int)p == 3) 
                {
                    DateTime dateTime = DateTime.Now;
                    ImputTime7 = dateTime.ToShortTimeString();
                    ImputTime8 = dateTime.ToShortTimeString();
                    ImputTime9 = dateTime.ToShortTimeString();
                    ImputTime10 = dateTime.ToShortTimeString();
                }
            });
        }
    }
}
