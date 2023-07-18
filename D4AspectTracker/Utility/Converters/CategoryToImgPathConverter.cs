
using System.Globalization;
using System.Xml;

namespace D4AspectTracker.Utility.Converters
{
    internal class CategoryToImgPathConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int categoryValue = (int)value;

            switch(categoryValue)
            {
                case 0:
                    return "offensive_aspect.png";
                case 1:
                    return "defensive_aspect.png";
                case 2:
                    return "resource_aspect.png";
                case 3:
                    return "utility_aspect.png";
                case 4:
                    return "mobility_aspect.png";
                default:
                    return "offensive_aspect.png";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
