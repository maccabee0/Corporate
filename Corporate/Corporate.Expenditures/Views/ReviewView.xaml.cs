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
        public ReviewView(IUnityContainer container)
        {
            InitializeComponent();
            DataContext = container.Resolve<ReviewViewModel>();
            SetDataGridColumns(((ReviewViewModel)DataContext).Rows);
        }

        private void SetDataGridColumns(IEnumerable<RowViewModel> records)
        {
            var rowViewModels = records as RowViewModel[] ?? records.ToArray();
            if (!rowViewModels.Any()) return;
            var record = rowViewModels.First();
            var columns = record.Columns.Select((x, i) => new { Name = x.Name, Index = i }).ToList();
            var template = (DataTemplate)totalsDataGrid.FindResource("ButtonTemplate");
            
            foreach (var column in columns)
            {
                DataGridColumn col;
                if (column.Name == "Office"||column.Name =="Total")
                {
                    col=new DataGridTextColumn { Header = column.Name, Binding = new Binding(string.Format("Columns[{0}].Value", column.Index)) };
                }
                else{
                    var binding = new Binding(string.Format("Columns[{0}].Value", column.Index));
                    col = new CustomBoundColumn { 
                        Header = column.Name,
                        TemplateName = "ButtonTemplate", 
                        Binding = binding
                    };                    
                }                
                totalsDataGrid.Columns.Add(col);
            }
        }
    }
}
