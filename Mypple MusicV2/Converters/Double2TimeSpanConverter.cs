using System.Globalization;
using System.Windows.Data;

namespace Mypple_MusicV2.Converters
{
    public class Double2TimeSpanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null && double.TryParse(value.ToString(), out double result))
            {
                TimeSpan ts = TimeSpan.FromSeconds(result);
                string str = ts.ToString(@"mm\:ss");
                return str;
            }
            return "00:00";
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }    
    }
}
