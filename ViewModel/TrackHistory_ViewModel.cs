using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrippingApp.ViewModel
{
    public class TrackHistory_ViewModel:BaseViewModel.BaseViewModel
    {

        private int _variable;

        public int Variable
        {
            get { return _variable; }
            set { SetProperty(ref _variable, value, nameof(Variable)); }
        }
        public TrackHistory_ViewModel()
        {

        }
    }
}
