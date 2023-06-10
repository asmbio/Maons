namespace ASMB
{
  
    public class UnFollowbyteToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((byte)value) != 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? (byte)1 : (byte)0;
        }
    }
    public class FollowbyteToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((byte)value) == 1;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return ((bool)value) ? (byte)1 : (byte)0;
        }
    }

    
    public class AddressstatezanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((byte)value)
            {    
                case 1:
                    return 24;
                default:
                    return 18;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
            //var ret = new NASMB.TYPES.AsmbAddress((string)value);
            //// ret.Address = ;
            //return ret;
        }
    }
    public class NegateboolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
            //var ret = new NASMB.TYPES.AsmbAddress((string)value);
            //// ret.Address = ;
            //return ret;
        }
    }
    public class AddressstatecaiConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((byte)value)
            {
   
                case 2:
                    return 24;
                default:
                    return 18;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
            //var ret = new NASMB.TYPES.AsmbAddress((string)value);
            //// ret.Address = ;
            //return ret;
        }
    }


    public class AddressstateopciyzanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((byte)value)
            {

                case 1:
                    return 1;
                default:
                    return 0.4;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
            //var ret = new NASMB.TYPES.AsmbAddress((string)value);
            //// ret.Address = ;
            //return ret;
        }
    }


    public class AddressstateopciycaiConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((byte)value)
            {

                case 2:
                    return 1;
                default:
                    return 0.4;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception();
            //var ret = new NASMB.TYPES.AsmbAddress((string)value);
            //// ret.Address = ;
            //return ret;
        }
    }
    public class AddressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
    
            return value;


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ret = new NASMB.TYPES.AsmbAddress((string)value);
           // ret.Address = ;
            return ret;
        }
    }

    public class MaonsConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value is System.Numerics.BigInteger)
                {
                    return NASMB.TYPES.Maons.FromNil((System.Numerics.BigInteger)value);

                }
                return "Error";
            }
            catch (Exception e)
            {

                return e.Message;
            }
        
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return new System.Numerics.BigInteger(0);
                }
                var nh = ((string)value).Trim() ;
                var strs = nh.Split(" ");
                if (strs.Length == 1)
                {
                    return NASMB.TYPES.Maons.ToNil((string)strs[0] + " Maons");
                }
                return NASMB.TYPES.Maons.ToNil(nh);
            }
            catch (Exception)
            {
                return "必须添加单位";
            }
}
    }
    public class MaonstoUintConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value == null)
                {
                    return (ulong)0;
                }
                var nh = ((string)value).Trim();
                var strs = nh.Split(" ");
                if (strs.Length == 1)
                {
                    return (ulong)NASMB.TYPES.Maons.ToNil((string)strs[0] + " Maons");
                }
                return (ulong)NASMB.TYPES.Maons.ToNil(nh);
            }
            catch (Exception)
            {
                return "必须添加单位";
            }
         

         //   return ((ulong)NASMB.TYPES.Maons.ToNil((string)value));
        }
    }

    public class EventTypeColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            switch ((string)value)
            {
                case "INFO":
                    return "CadetBlue";
                case "ERROR":
                    return "Red";
                case "WARN":
                    return "Orange";
                default:
                    return "Black";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
        class StatetoBgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.Black);
            try
            {
                //color.R =0xFF; color.G = 0; color.B = 0;
                /// IDLE，RUN，DOWN, FULL，FORCED
                switch (value)
                {
                    case "IDLE":
                        brush.Color = Colors.White;
                        break;
                    case "RUN":
                        brush.Color = Colors.GreenYellow;
                        break;
                    case "DOWN":
                        brush.Color = Colors.Red;
                        break;
                    case "FULL":
                        brush.Color = Colors.Green;
                        break;
                    case "FORCED":
                        brush.Color = Colors.Yellow;
                        break;
                    case "NONE":
                    default:
                        brush.Color = Colors.White;
                        break;
                }
                return brush;
            }
            catch (Exception e)
            {
                return brush;
                //888888888
                // \\ \\
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
    class StatetoStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {


            try
            {
                //color.R =0xFF; color.G = 0; color.B = 0;
                /// IDLE，RUN，DOWN, FULL，FORCED

                return "WhiteGreenStyle";
            }
            catch (Exception e)
            {
                return "Style";
                //888888888
                // \\ \\
            }



        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }




    class ErrorToBgConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = new SolidColorBrush(Colors.White);
            try
            {
                //color.R =0xFF; color.G = 0; color.B = 0;
                /// IDLE，RUN，DOWN, FULL，FORCED
                /// 
                if (value != null)
                {
                    brush.Color = Colors.Red;
                }
               
                return brush;
            }
            catch (Exception e)
            {
                return brush;
                //888888888
                // \\ \\
            }



        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


    class MixModeConverter1 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            
            try
            {
                switch ((int)value)
                {
                    case 1:
                        return true;
                    default:
                        break;
                }

                return false;
            }
            catch (Exception )
            {
                return false;
                //888888888
                // \\ \\
            }



        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                switch ((bool)value)
                {
                    case true:
                        return 1;
                    default:
                        break;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                //888888888
                // \\ \\
            }

        }
    }

    class MixModeConverter2 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            try
            {
                switch ((int)value)
                {
                    case 2:
                        return true;
                    default:
                        break;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                //888888888
                // \\ \\
            }



        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                switch ((bool)value)
                {
                    case true:
                        return 2;
                    default:
                        break;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                //888888888
                // \\ \\
            }

        }
    }
    class MixModeConverter3 : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            try
            {
                switch ((int)value)
                {
                    case 3:
                        return true;
                    default:
                        break;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                //888888888
                // \\ \\
            }



        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                switch ((bool)value)
                {
                    case true:
                        return 3;
                    default:
                        break;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
                //888888888
                // \\ \\
            }

        }
    }




}
