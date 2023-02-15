using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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

        #region Command
        public ICommand Select_1000Row_Command { get; set; }
        public ICommand Search_Command { get; set; }
        #endregion

        public TrackHistory_ViewModel()
        {
            Select_1000Row_Command = new ActionCommand(() =>
            {
                
            });
            Search_Command = new ActionCommand((p) =>
            {
            
            });
        }
    }
}
