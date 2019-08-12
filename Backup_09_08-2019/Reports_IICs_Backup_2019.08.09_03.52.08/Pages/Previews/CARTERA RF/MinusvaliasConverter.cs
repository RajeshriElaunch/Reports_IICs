using System;
using System.Windows.Data;

namespace Reports_IICs.Pages.Previews.CARTERA_RF
{
   public class MinusvaliasConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           
            decimal decimalValue = 0;

            decimal.TryParse(value.ToString(), out decimalValue);

            if (decimalValue < 0)
            {
                value = decimalValue*-1;
            }
            else
            {
                value = 0;
            }
                

            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
