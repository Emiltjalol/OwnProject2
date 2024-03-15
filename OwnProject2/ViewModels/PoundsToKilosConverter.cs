using System.Globalization;

namespace OwnProject2.ViewModels
{
    class PoundsToKilosConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double pounds)
            {
                return pounds * 0.453592;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
}
