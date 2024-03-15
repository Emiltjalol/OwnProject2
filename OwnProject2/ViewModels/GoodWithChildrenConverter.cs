using System.Globalization;

namespace OwnProject2.ViewModels
{
    public class GoodWithChildrenConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int goodWithChildren)
            {
                switch (goodWithChildren)
                {
                    case 1:
                        return "Not quite comfortable with children. This one may need space, as they could get nervous or show signs of distress around kids.";
                    case 2:
                        return "Somewhat patient with children, though it's clear they prefer their own space. They might not fully engage with kids.";
                    case 3:
                        return "Neutral around children. They don't seek out interaction, but they don't avoid it either. There's a balance of disinterest and tolerance.";
                    case 4:
                        return "Quite friendly with children. Expect them to be patient and to engage positively with kids.";
                    case 5:
                        return "Outstandingly gentle and affectionate with children. They're the type who form strong, positive bonds and are consistently well-mannered around kids.";
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
