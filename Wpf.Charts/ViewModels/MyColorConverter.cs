using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace Wpf.Charts.ViewModels
{
    public class MyColorConverter : IValueConverter
    {
        private static PropertyInfo[] s_AllColorInfo =
            typeof(Colors).GetProperties();
        private static Color[] s_allColors = s_AllColorInfo.
            Select(c => (Color)ColorConverter.ConvertFromString(c.Name)).ToArray();
        // vm -> view
        public object Convert(object value, Type type, object parameter, CultureInfo culture)
        {
            Color v = (Color)value;

            return s_AllColorInfo.Where(c => (Color)ColorConverter.ConvertFromString(c.Name) == v).FirstOrDefault();
        }

        // view -> vm
        public object ConvertBack(object value, Type type, object parameter, CultureInfo culture)
        {
            PropertyInfo s = (PropertyInfo)value;

            return ColorConverter.ConvertFromString(s.Name);
        }
    }
}
