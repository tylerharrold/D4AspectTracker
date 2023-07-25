using D4AspectTracker.MVVM.Models;
using System.Diagnostics;
using System.Globalization;

namespace D4AspectTracker.Utility.Converters;

class CategoryEnumToImgPathConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        
        AspectCategory categoryValue = (AspectCategory)value;

        switch (categoryValue)
        {
            case AspectCategory.Offensive:
                return "offensive_aspect.png";
            case AspectCategory.Defensive:
                return "defensive_aspect.png";
            case AspectCategory.Resource:
                return "resource_aspect.png";
            case AspectCategory.Utility:
                return "utility_aspect.png";
            case AspectCategory.Mobility:
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
