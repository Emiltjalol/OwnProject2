using System.Globalization;

namespace OwnProject2.ViewModels
{

    internal class TrainabilityLevelConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int goodWithStrangers)
            {
                switch (goodWithStrangers)
                {
                    case 1:
                        return "Can be challenging to train and may require experienced handling.";
                    case 2:
                        return "Moderate,will require consistent training and patience.";
                    case 3:
                        return "Average,responds well to training with regular reinforcement.";
                    case 4:
                        return "Good,quick to learn and obedient with proper training.";
                    case 5:
                        return "Exceptional,highly trainable and eager to please, quick to learn new commands.";
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

