using System.Windows;
using System.Windows.Data;

namespace Corporate.Expenditures.CustomControls
{
    public class DataContextProxy : FrameworkElement
    {
        public DataContextProxy()
        {
            Loaded += new RoutedEventHandler(DataContextProxyLoaded);
        }

        void DataContextProxyLoaded(object sender, RoutedEventArgs e)
        {
            var binding = new Binding {Source = DataContext, Mode = BindingMode};
            if (!string.IsNullOrEmpty(BindingPropertyName))
            {
                binding.Path = new PropertyPath(BindingPropertyName);
            }
            
            SetBinding(DataContextProxy.DataSourceProperty, binding);
        }

        public object DataSource
        {
            get { return (object) GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof (object), typeof (DataContextProxy), null);

        public string BindingPropertyName { get; set; }
        public BindingMode BindingMode { get; set; }
    }
}
