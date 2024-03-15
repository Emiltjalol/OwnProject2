using System.Globalization;

namespace OwnProject2.ViewModels
{
    public class GoodWithOtherDogsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int goodWithOtherDogs)
            {
                switch (goodWithOtherDogs)
                {
                    case 1:
                        return "This one tends to struggle around other dogs. It's best they have space, as they might react with aggression or fear.";
                    case 2:
                        return "They're somewhat patient with other dogs, though it's clear they have their limits. Watch for signs of discomfort.";
                    case 3:
                        return "They have a reserved attitude towards other dogs. They coexist peacefully but without much enthusiasm.";
                    case 4:
                        return "Friendly and sociable. They're generally well-behaved around other dogs and often engage in positive interactions.";
                    case 5:
                        return "A social butterfly among dogs, always ready to play and interact. They exhibit exemplary behavior and seem to enjoy the company of their peers.";
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
