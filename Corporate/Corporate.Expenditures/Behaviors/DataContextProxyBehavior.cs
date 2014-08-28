using System.Windows;
using System.Windows.Data;
using System.Windows.Interactivity;

using Corporate.Expenditures.CustomControls;

namespace Corporate.Expenditures.Behaviors
{
    public class DataContextProxyBehavior : Behavior<FrameworkElement>
    {
        public object DataSource
        {
            get { return (object)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }

        public static readonly DependencyProperty DataSourceProperty =
            DependencyProperty.Register("DataSource", typeof(object), typeof(DataContextProxy), null);

        protected override void OnAttached()
        {
            base.OnAttached();
            var binding = new Binding
                {
                    Source = AssociatedObject,
                    Path = new PropertyPath("DataContext"),
                    Mode = BindingMode.OneWay
                };
            BindingOperations.SetBinding(this, DataSourceProperty, binding);

            AssociatedObject.Resources.Add("DataContextProxy", this);
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.Resources.Remove("DataContextProxy");
        }
    }
}
