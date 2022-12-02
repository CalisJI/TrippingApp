using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrippingApp.ViewModel
{
    public class OverViewMachineViewModel:BaseViewModel.BaseViewModel
    {
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }
        public OverViewMachineViewModel()
        {
            Loaded = new ActionCommand(() =>
            {
            
            });
            Unloaded = new ActionCommand(() =>
            {
            
            });

        }
    }
}
