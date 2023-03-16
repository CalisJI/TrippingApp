using Microsoft.Expression.Interactivity.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TrippingApp.ViewModel
{
    public class Manual_ViewModel:BaseViewModel.BaseViewModel
    {
        public ICommand Loaded { get; set; }
        public ICommand Unloaded { get; set; }

        public Manual_ViewModel()
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
