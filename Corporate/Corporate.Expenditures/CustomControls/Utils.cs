using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Corporate.Expenditures.CustomControls
{
    public static class Utils
    {
        public static T GetFirstParentForChild<T>(DependencyObject child) where T : class
        {
            if (child == null) return null;
            var cadidate = child as T;
            return cadidate ?? GetFirstParentForChild<T>(VisualTreeHelper.GetParent(child));
        }
    }
}
