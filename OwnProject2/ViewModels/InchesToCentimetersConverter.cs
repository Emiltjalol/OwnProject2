using System.Globalization;

namespace OwnProject2.ViewModels
{
    public class InchesToCentimetersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double inches)
            {
                return inches * 2.54;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
