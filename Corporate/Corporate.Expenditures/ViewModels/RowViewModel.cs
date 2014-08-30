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
        public List<ColumnViewModel> Columns { get; set; }

        public RowViewModel()
        {
            Columns = new List<ColumnViewModel>();
        }

        public RowViewModel(IEnumerable<ColumnViewModel> models)
        {
            Columns = new List<ColumnViewModel>(models);
        }

        public override string ToString()
        {
            return "RowViewModel: " + Office;
        }
    }
}
