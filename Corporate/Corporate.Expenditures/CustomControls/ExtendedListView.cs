using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using Corporate.Expenditures.DataMatrix;

namespace Corporate.Expenditures.CustomControls
{
    public class ExtendedListView : ListView
    {
        static ExtendedListView()
        {
            ViewProperty.OverrideMetadata(typeof(ExtendedListView), new PropertyMetadata(new PropertyChangedCallback(OnViewPropertyChanged)));
        }

        public static void OnViewPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            UpdateGridView(d as ExtendedListView, (IDataMatrix)d.GetValue(MatrixSourceProperty));
        }

        private static readonly DependencyProperty MatrixSourceProperty =
            DependencyProperty.Register("MatrixSource",
             typeof(IDataMatrix), typeof(ExtendedListView), new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnMatrixSourceChanged)));

        public IDataMatrix MatrixSource
        {
            get { return (IDataMatrix)GetValue(MatrixSourceProperty); }
            set { SetValue(MatrixSourceProperty, value); }
        }

        private static void OnMatrixSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listView = d as ExtendedListView;
            var dataMatrix = e.NewValue as IDataMatrix;

            UpdateGridView(listView, dataMatrix);
        }

        public static readonly DependencyProperty CellTemplateSelectorProperty =
            DependencyProperty.Register("CellTemplateSelector",
                                        typeof(DataTemplateSelector), typeof(ExtendedListView),
                                        new FrameworkPropertyMetadata(null, new PropertyChangedCallback(OnCellTemplateSelectorChanged)));

        public DataTemplateSelector CellTemplateSelector
        {
            get { return (DataTemplateSelector)GetValue(CellTemplateSelectorProperty); }
            set { SetValue(CellTemplateSelectorProperty, value); }
        }

        private static void OnCellTemplateSelectorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var listView = d as ExtendedListView;
            if (listView != null)
            {
                UpdateGridView(listView, listView.MatrixSource);
            }
        }

        private static void UpdateGridView(ExtendedListView listView, IDataMatrix dataMatrix)
        {
            if (listView == null || listView.View == null || !(listView.View is GridView) || dataMatrix == null) return;
            listView.ItemsSource = dataMatrix;
            var gridView = listView.View as GridView;
            gridView.Columns.Clear();
            foreach (var column in dataMatrix.Columns.Select(col => new GridViewColumn
                {
                    Header = col.Name,
                    HeaderTemplate = gridView.ColumnHeaderTemplate,
                    DisplayMemberBinding = new Binding(string.Format("[{0}]", col.Name))
                }))
            {
                gridView.Columns.Add(column);
            }
        }
    }
}
