using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using System;
using System.Windows.Controls;
using Telerik.Windows.Data;

namespace Reports_IICs.Pages.Previews.Changes.UserControls
{
    /// <summary>
    /// Interaction logic for RentaVariable_CHN.xaml
    /// </summary>
    public partial class RentaVariable_CHN : UserControl
    {
        public RentaVariable_CHN(string codigoIC, DateTime fechaInforme)
        {
            InitializeComponent();

            try
            {
                //var source = RentaVariable_DA.GetPreviewChanges(codigoIC, fechaInforme).ToList();

                var source = RentaVariable_DA.GetPreviewChanges(codigoIC, fechaInforme);
                    //from prev in RentaVariable_DA.GetPreviewChanges(codigoIC, fechaInforme).OrderBy(o=>o.Descripcion).ThenBy(t=>t.GrupoNuevo)
                    //         select new
                    //         {
                    //             Id = prev.Id,
                    //             Isin = prev.Isin,
                    //             Descripcion = prev.Descripcion,
                    //             FechaCompra = prev.FechaCompra,
                    //             FechaVenta = prev.FechaVenta,
                    //             prev.NumeroTitulos,
                    //             prev.PrecioIni,
                    //             prev.PrecioFin,
                    //             prev.PrecioFinEuros,
                    //             prev.PrecioAjustado,
                    //             prev.TipoCambioIni,
                    //             prev.TipoCambioFin,
                    //             prev.NumO,
                    //             prev.TipoO,
                    //             prev.NumC,
                    //             prev.TipoC,
                    //             prev.GrupoNuevo,
                    //             Grupo = prev.Grupo != null ? Utils.GetGrupoInt(prev.Grupo) : (int?)null,
                    //             prev.Estado,
                    //             prev.Ejercicio,
                    //             prev.FechaInforme,
                    //             prev.IsVisible,
                    //             prev.Added,
                    //             Modificacion = getModificaciónText(prev)
                    //         }
                    //         ;

                //IEnumerable<object> source = new Preview_RentaFija_MNG().GetByCodigoIC(codigoIC, true).ToList();
                this.RadGridView1.ItemsSource = source;

                var descriptor = new GroupDescriptor();
                descriptor.Member = "Modificacion";
                RadGridView1.GroupDescriptors.Add(descriptor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string getModificaciónText(RentaVariable_PrecioAjustado prev)
        {
            string output = string.Empty;

            if(!prev.IsVisible)
            {
                output = "ELIMINADO";
            }
            else if(prev.IsVisible && !prev.Added)
            {
                output = "MODIFICADO";
            }
            else if(prev.IsVisible && prev.Added)
            {
                output = "AÑADIDO";
            }

            return output;
        }
    }
}
