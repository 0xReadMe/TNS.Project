using System.Globalization;
using System.Windows.Data;

namespace TNS.Front_end;
public class StringToFirstCharConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is string str && str.Length > 0)
            return str.Substring(0, 1);
        return string.Empty;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value;
    }
}
