using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using Corporate.Expenditures.CustomControls;

namespace Corporate.Expenditures.DataMatrix
{
    public class DataMatrixCellTemplateSelectorWrapper : DataTemplateSelector
    {
        private readonly DataTemplateSelector _actualSelector;
        private readonly string _columnName;
        private Dictionary<string, object> _originalRow;

        public DataMatrixCellTemplateSelectorWrapper(DataTemplateSelector actualSelecter, string columnName)
        {
            _actualSelector = actualSelecter;
            _columnName = columnName;
        }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is Dictionary<string, object>)
            {
                _originalRow = item as Dictionary<string, object>;
            }
            if (_originalRow == null)
                return null;

            var obj = _originalRow[_columnName];
            var template = _actualSelector.SelectTemplate(obj, container);

            var presenter = Utils.GetFirstParentForChild<ContentPresenter>(container);
            if (presenter != null)
            {
                presenter.Content = obj;
            }
            return template;
        }

        
}
}
