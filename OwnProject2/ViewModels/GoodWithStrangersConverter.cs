using System.Globalization;


namespace OwnProject2.ViewModels
{
    internal class GoodWithStrangersConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int goodWithStrangers)
            {
                switch (goodWithStrangers)
                {
                    case 1:
                        return "Uncomfortable with strangers, and may display signs of fear or aggression around unfamiliar people.";
                    case 2:
                        return "Tolerant of strangers, but may show wariness or hesitation around unfamiliar people.";
                    case 3:
                        return "Neutral towards strangers, typically interacts with unfamiliar people in a calm and indifferent manner.";
                    case 4:
                        return "Friendly towards strangers, generally warm and sociable towards unfamiliar people.";
                    case 5:
                        return "Very friendly towards strangers, exceptionally welcoming and well-socialized with unfamiliar people.";
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
