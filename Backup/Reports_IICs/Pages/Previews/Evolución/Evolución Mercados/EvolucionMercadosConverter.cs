using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados
{
    internal class EvolucionMercadosConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var tmp = value as Temp_EvolucionMercados;
            if (tmp == null)
            {
                throw new ArgumentException("Valor incorrecto", "value");
            }

            //var VarCotizacionDiv = 5;
            var VarCotizacionDiv = decimal.Round(Utils.PorcentajeVariacion(tmp.CotizaDivDesde, tmp.CotizaDivHasta), 2);
            return VarCotizacionDiv;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
