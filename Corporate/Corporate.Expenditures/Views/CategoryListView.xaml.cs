using System;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Interactivity.InteractionRequest;

namespace Corporate.Expenditures.Views
{
    /// <summary>
    /// Interaction logic for CategoryListView.xaml
    /// </summary>
    public partial class CategoryListView : UserControl
    {
        public CategoryListView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FinishInteraction != null)
                FinishInteraction();
        }

        public Action FinishInteraction { get; set; }
        public INotification Notification { get; set; }
    }
}
