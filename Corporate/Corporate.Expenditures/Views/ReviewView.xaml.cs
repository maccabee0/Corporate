using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

using Corporate.Expenditures.ViewModels;

using Microsoft.Practices.Unity;

namespace Corporate.Expenditures.Views
{
    /// <summary>
    /// Interaction logic for ReviewView.xaml
    /// </summary>
    public partial class ReviewView : UserControl
    {
        public event EventHandler<MouseButtonEventArgs> DoubleClick;
        public ReviewView(IUnityContainer container)
        {
            InitializeComponent();
            DataContext = container.Resolve<ReviewViewModel>();
            DoubleClick += ((ReviewViewModel)DataContext).OnMouseDoubleClick;
            SetDataGridColumns(((ReviewViewModel)DataContext).Rows);
        }

        private void ExtendedListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var row = ((ListView)sender).SelectedValue;
            //OnDoubleClick(e);
        }

        private void OnDoubleClick(MouseButtonEventArgs e)
        {
            var temp = Interlocked.CompareExchange(ref DoubleClick, null, null);
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
            var columns = record.Columns.Select((x, i) => new {Name = x.Name, Index = i}).ToList();
            foreach (var column in columns)
            {
                var binding = new Binding(string.Format("Columns[{0}].Value", column.Index));
                totalsDataGrid.Columns.Add(new DataGridTextColumn {Header = column.Name, Binding = binding});
            }
        }
    }
}
