using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Corporate.Expenditures.CustomControls
{
    public class CellDataSelector:DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, System.Windows.DependencyObject container)
        {
            var control = Utils.GetFirstParentForChild<DataGrid>(container);

            var resource = "CellTemplate";

            return (DataTemplate) control.FindResource(resource);
        }
    }
}
