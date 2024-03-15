using System.Globalization;

namespace OwnProject2.ViewModels
{
    public class TraitLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int traitLevel)
            {
                switch (traitLevel)
                {
                    case 1:
                        return "★☆☆☆☆";
                    case 2:
                        return "★★☆☆☆";
                    case 3:
                        return "★★★☆☆";
                    case 4:
                        return "★★★★☆";
                    case 5:
                        return "★★★★★";
                }
            }
            return "No data available at this moment.";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
