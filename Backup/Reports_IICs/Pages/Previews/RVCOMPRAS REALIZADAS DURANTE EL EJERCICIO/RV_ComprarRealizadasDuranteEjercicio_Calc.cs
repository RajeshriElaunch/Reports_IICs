using Reports_IICs.DataAccess.Reports;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Reports_IICs.Pages.Previews.RVCOMPRAS_REALIZADAS_DURANTE_EL_EJERCICIO
{
    internal class RV_ComprarRealizadasDuranteEjercicio_Calc : IValueConverter
    {
        #region IValueConverter Members 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var compra = value  as T_RVComprasRealizadasEjercicio;
            
            //var ratios = RvComprasRealizadasEjercicio_DA.GetTemp_RVComprasRealizadasEjercicioById(compra.Id);

            decimal variacion = 0;
            if (compra == null)
            {
               // throw new ArgumentException("valor erróneo", "value");
            }
            else
            {
                if(compra.CotizacionFechaFin!=null && compra.Precio != null)
                {
                  if(!compra.Vendido) variacion = (System.Convert.ToDecimal(compra.Precio) - decimal.Parse(compra.CotizacionFechaFin)) / System.Convert.ToDecimal(compra.Precio);

                }

            }

            return variacion;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

    internal class RV_ComprarRealizadasDuranteEjercicio_Cotizacion : IValueConverter
    {
        #region IValueConverter Members 

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var compra = value as T_RVComprasRealizadasEjercicio;

            //var ratios = RvComprasRealizadasEjercicio_DA.GetTemp_RVComprasRealizadasEjercicioById(compra.Id);

            decimal variacion = 0;
            if (compra == null)
            {
                // throw new ArgumentException("valor erróneo", "value");
            }
            else
            {
               if(compra.Vendido)
                {
                    variacion = 0;
                }

            }

            return variacion;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion

    }

}
