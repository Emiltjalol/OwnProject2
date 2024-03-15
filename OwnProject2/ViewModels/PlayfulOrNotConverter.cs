using System.Globalization;

namespace OwnProject2.ViewModels
{
    internal class PlayfulOrNotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int playfulLevel)
            {


                switch (playfulLevel)
                {
                    case 1:
                        return "Not very playful, tends to be reserved or disinterested in play, and may prefer solitude or rest.";
                    case 2:
                        return "Fairly playful, can engage in play but may show signs of hesitation or limited enthusiasm.";
                    case 3:
                        return "Average playfulness, typically engages in play in a neutral or balanced manner.";
                    case 4:
                        return "Playful, Generally enjoys playtime and shows enthusiasm and energy during play.";
                    case 5:
                        return "Very playful, exceptionally active, energetic, and enthusiastic during play, often seeking out play opportunities.";
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
