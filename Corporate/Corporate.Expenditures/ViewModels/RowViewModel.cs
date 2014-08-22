using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corporate.Expenditures.ViewModels
{
    public class RowViewModel
    {
        public string Office { get; set; }
        public ObservableCollection<ColumnViewModel> Columns { get; set; }

        public RowViewModel()
        {
            Columns=new ObservableCollection<ColumnViewModel>();
        }

        public RowViewModel(IEnumerable<ColumnViewModel> models)
        {
            Columns=new ObservableCollection<ColumnViewModel>(models);
        }
    }
}
