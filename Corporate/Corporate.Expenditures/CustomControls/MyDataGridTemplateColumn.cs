using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Corporate.Expenditures.CustomControls
{
    public class MyDataGridTemplateColumn:DataGridTemplateColumn
    {
        public string ColumnName { get; set; }

        protected override System.Windows.FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            var contentPresenter = (ContentPresenter) base.GenerateElement(cell, dataItem);
            BindingOperations.SetBinding(contentPresenter, ContentPresenter.ContentProperty, new Binding(this.ColumnName));
            return contentPresenter;
        }
    }
}
