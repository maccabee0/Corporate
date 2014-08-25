using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corporate.Expenditures.ViewModels;

namespace Corporate.Expenditures.CorporateEventArgs
{
    public class ItemSelectedEventArgs:EventArgs
    {
        public TotalsCellViewModel Item { get; set; }
        public ItemSelectedEventArgs(TotalsCellViewModel item)
        {
            Item = item;
        }
    }
}
