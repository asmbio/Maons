namespace ASMBApp
{

    public class AddressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
    
            return value;


        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var ret = new NASMB.TYPES.AsmbAddress();
            ret.Address = (string)value;
            return ret;
        }
    }

    public class NihilConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value is System.Numerics.BigInteger)
                {
                    return NASMB.TYPES.Nihil.FromNil((System.Numerics.BigInteger)value);

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

                return NASMB.TYPES.Nihil.ToNil((string)value);
            }
            catch (Exception)
            {
                return new System.Numerics.BigInteger(0);
            }     
        }
    }
    //public class NihiltoUintConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        throw new Exception("The method or operation is not implemented.");
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        if (value == null)
    //        {
    //            return (ulong)0;
    //        }

    //        return ((ulong)NASMB.TYPES.Nihil.ToNil((string)value));
    //    }
    //}

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
