using System.Globalization;


namespace Maons.Converter
{
    public class WidthToVisableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (double)value<250 ? false:true;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("");
        }
    }
    public class BoolToFontAttributesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? FontAttributes.Bold:FontAttributes.None;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("");
        }
    }

    public class BoolToFontColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? Color.Parse("#512BD4") : Colors.Black;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("");
        }
    }

    //public class BoolToimgConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        return (bool)value ? Color.Parse("#512BD4") : Colors.Black;
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new Exception("");
    //    }
    //}

    public class IcoimgMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values.Length!=2)
            {
                return "";
            }
            string icon = values[1] as string;
            if (values[0] !=null&&(bool)values[0])
            {
                if (!icon.EndsWith("_selected.png"))
                {
                    var ioname = icon.Substring(0, icon.Length - 4);
                    icon = ioname + "_selected.png";
                }
            }
            else
            {
                if (icon?.EndsWith("_selected.png")==true)
                {
                    var ioname = icon.Substring(0, icon.Length - 13);
                    icon = ioname + ".png";
                }
            }
            return icon;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new Exception("");
        }
    }
}
