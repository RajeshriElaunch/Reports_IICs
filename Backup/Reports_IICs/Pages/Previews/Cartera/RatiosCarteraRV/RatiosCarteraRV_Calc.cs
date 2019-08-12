using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Reports_IICs.Pages.Previews.Cartera.RatiosCarteraRV
{
    internal class RatiosCarteraRV_Calc : IValueConverter
    {
        #region IValueConverter Members 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var ratio = value as Temp_RatiosCarteraRV;

            var ratios = RatiosCarteraRV_DA.GetTemp_RatiosCarteraRV(ratio.CodigoIC);

            decimal numTitulosCartera = ratios.Select(r => r.NumeroTitulos).Sum();
            var porcentCartera = ratio.NumeroTitulos * 100 / numTitulosCartera;
            decimal rounded = decimal.Round(porcentCartera, 1);

            if (ratio == null)
            {
                throw new ArgumentException("valor erróneo", "value");
            }

            return rounded;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
