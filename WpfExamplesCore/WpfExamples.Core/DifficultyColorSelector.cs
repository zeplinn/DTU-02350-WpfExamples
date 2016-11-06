using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using WpfExamples.ToolBox;

namespace WpfExamples.Core
{
    public class DifficultyColorSelector:IValueConverter
    {
        private static readonly Brush Beginner = new SolidColorBrush(new Color() {R = 184, G = 220, B = 163});
        private static readonly Brush Intermediate = new SolidColorBrush(new Color() { R = 238, G = 226, B = 145 });
        private static readonly Brush Advanced = new SolidColorBrush(new Color() { R = 239, G = 172, B = 143 });

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is EDifficulty))
                throw new ArgumentNullException(
                    $"value type is not of type {nameof(EDifficulty)}, but {value?.GetType()}");

            switch ((EDifficulty)value)
            {
                case EDifficulty.Beginner:
                    return Beginner;
                case EDifficulty.Intermediate:
                    return Intermediate;
                case EDifficulty.Advanced:
                    return Advanced;
                default:
                    throw new ArgumentOutOfRangeException(nameof(value), value, null);
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
