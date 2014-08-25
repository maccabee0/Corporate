using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using Corporate.Expenditures.CorporateEventArgs;
using Corporate.Expenditures.CustomControls;
using Corporate.Expenditures.ViewModels;

using Microsoft.Practices.Unity;

namespace Corporate.Expenditures.Views
{
    /// <summary>
    /// Interaction logic for ReviewView.xaml
    /// </summary>
    public partial class ReviewView : UserControl
    {
        public event EventHandler<ItemSelectedEventArgs> ItemSelected;
        public ReviewView(IUnityContainer container)
        {
            InitializeComponent();
            DataContext = container.Resolve<ReviewViewModel>();
            ItemSelected += ((ReviewViewModel)DataContext).OnMouseItemSelected;
            SetDataGridColumns(((ReviewViewModel)DataContext).Rows);
        }

        private void DataGridCellMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((StackPanel)sender).DataContext as TotalsCellViewModel;
            if (item != null && item.ExpenseId != 0)
            {
                OnDoubleClick(new ItemSelectedEventArgs(item));
            }
        }

        private void OnDoubleClick(ItemSelectedEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref ItemSelected, null, null);
            if (temp != null)
            {
                temp(this, e);
            }
        }

        private void SetDataGridColumns(IEnumerable<RowViewModel> records)
        {
            var rowViewModels = records as RowViewModel[] ?? records.ToArray();
            if (!rowViewModels.Any()) return;
            var record = rowViewModels.First();
            var columns = record.Columns.Select((x, i) => new { Name = x.Name, Index = i }).ToList();
            //var template = (DataTemplate)totalsDataGrid.FindResource("TotalsDataTemplate");
            foreach (var column in columns)
            {
                var binding = new Binding(string.Format("Columns[{0}].Value", column.Index));
                //var col = new DataGridTemplateColumn { Header = column.Name, CellTemplate = template, DisplayIndex = column.Index, ClipboardContentBinding = binding };
                totalsDataGrid.Columns.Add(new DataGridTextColumn { Header = column.Name, Binding = binding });
            }
        }

        private void TotalsDataGrid_OnAutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if (e.PropertyType == typeof(TotalsCellViewModel))
            {
                var col = new MyDataGridTemplateColumn();
                col.ColumnName = e.PropertyName;
                col.CellTemplate = Resources["TotalsDataTemplate"] as DataTemplate;
                e.Column = col;
                e.Column.Header = e.PropertyName;
            }
        }
    }
}
