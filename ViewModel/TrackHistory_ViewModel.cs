using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TrippingApp.Runtime;

namespace TrippingApp.ViewModel
{
    public class TrackHistory_ViewModel:BaseViewModel.BaseViewModel
    {

        private DataTable _historyTable;

        public DataTable HistoryTable
        {
            get { return _historyTable; }
            set { SetProperty(ref _historyTable, value, nameof(HistoryTable)); }
        }


        private string _searchItembarcode;

        public string SearchBarcodeItem_Prop
        {
            get { return _searchItembarcode; }
            set { SetProperty(ref _searchItembarcode, value, nameof(SearchBarcodeItem_Prop)); }
        }


        private DateTime _selectDateItem_prop;

        public DateTime Search_Time_Prop
        {
            get { return _selectDateItem_prop; }
            set 
            {
                try
                {
                    SetProperty(ref _selectDateItem_prop, value, nameof(Search_Time_Prop));
                }
                catch (Exception)
                {
                    value = new DateTime();
                    SetProperty(ref _selectDateItem_prop, value, nameof(Search_Time_Prop));
                }
                 
            }
        }
        #region Command
        public ICommand Select_1000Row_Command { get; set; }
        public ICommand Search_Command { get; set; }
        #endregion

        public TrackHistory_ViewModel()
        {
            Select_1000Row_Command = new ActionCommand(() =>
            {
                HistoryTable = HistoryLogger.Upload_Rows();
            });
            Search_Command = new ActionCommand((p) =>
            {
                if (SearchBarcodeItem_Prop != "" && SearchBarcodeItem_Prop != null && Search_Time_Prop == new DateTime())
                {
                    HistoryTable = HistoryLogger.GetFilterTable(SearchBarcodeItem_Prop, Search_Time_Prop, "", ModeFilter.ByBarcode);
                }
                else if ((SearchBarcodeItem_Prop == "" || SearchBarcodeItem_Prop == null) && Search_Time_Prop != new DateTime())
                {
                    HistoryTable = HistoryLogger.GetFilterTable(SearchBarcodeItem_Prop, Search_Time_Prop, "", ModeFilter.ByDate);
                }
                else if(SearchBarcodeItem_Prop != "" && SearchBarcodeItem_Prop != null && Search_Time_Prop != new DateTime())
                {
                    HistoryTable = HistoryLogger.GetFilterTable(SearchBarcodeItem_Prop, Search_Time_Prop, "", ModeFilter.All);
                }
                else
                {
                    HistoryTable = HistoryLogger.Upload_Rows();
                }
            });
        }
    }
}
