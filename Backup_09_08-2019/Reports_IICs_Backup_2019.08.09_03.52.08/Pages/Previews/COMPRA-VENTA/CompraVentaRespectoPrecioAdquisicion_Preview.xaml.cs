using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using Telerik.Windows.Controls;
using Reports_IICs.DataModels;
using Reports_IICs.DataAccess.Reports;

namespace Reports_IICs.Pages.Previews.COMPRA_VENTA
{


    /// <summary>
    /// Lógica de interacción para CompraVentaRespectoPrecioAdquisicion_Preview.xaml
    /// </summary>
    public partial class CompraVentaRespectoPrecioAdquisicion_Preview : WizardPage
    {
        private Plantilla _plantilla;
        private string _isin;
        public CompraVentaRespectoPrecioAdquisicion_Preview(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            this.PreviewWizardPage.labelTitulo.Content = "RESULTADOS EN RENTA VARIABLE DESDE ADQUISICIÓN ";

            //var SelectIsin = plantilla.Plantillas_Isins.Where(c => c.Isin == isin);

            //var LSelectIsin = SelectIsin.ToList();
            //if (LSelectIsin != null)
            //{
            //    this.PreviewWizardPage.labelTitulo.Content = "RESULTADOS EN RENTA VARIABLE DESDE ADQUISICIÓN "; //+ LSelectIsin[0].Descripcion;

            //}

            //var data = Cartera_DA.GetTemp_PRO_11(plantilla.CodigoIc).ToList();


            _plantilla = plantilla;
            _isin = isin;
            populateData(plantilla, isin, fecha);

        }



        private void UpdateTotalTextBox(object sender, object EventArgs)
        {
            TextBlock TotalTxtBox = (TextBlock)this.PreviewWizardPage.MyStackPanelVertical.Children[this.PreviewWizardPage.MyStackPanelVertical.Children.Count - 1];
            if(TotalTxtBox != null)
            {
                var cventa = DataAccess.Reports.CompraVentaRespectoPrecioAdquisicion_DA.GetTemp_CompraVentaRespectoPrecioAdquisicion(_plantilla.CodigoIc, _isin);

                decimal Total = 0;
                foreach (var item in cventa)
                {
                    Total = Total + item.Efectivo != null ? Convert.ToDecimal(item.Efectivo) : Convert.ToDecimal(0);
                }
               
                var Temp_ListTexbox = TotalTxtBox.Inlines.ToList();
                var LastTextBox = Temp_ListTexbox[Temp_ListTexbox.Count-1];
                TotalTxtBox.Inlines.Remove(LastTextBox);
                TotalTxtBox.Inlines.Add(new Run() { Text = "TOTAL RENTA VARIABLE " + String.Format("{0:N2}", Total), FontWeight = FontWeights.Bold });
            }
        }

        private void populateData(Plantilla plantilla, string isin, DateTime fecha)
        {
            #region Calculate Total
            var cventa = DataAccess.Reports.CompraVentaRespectoPrecioAdquisicion_DA.GetTemp_CompraVentaRespectoPrecioAdquisicion(plantilla.CodigoIc, isin);

            //Nos fijamos en el orden que se hace en el procedimiento que tenemos en el report y lo ordenamos por el orden de los ids de ese poc
            var proc = CompraVentaRespectoPrecioAdquisicion_DA.GetTemp_Ordenado(plantilla.CodigoIc).Select(s => s.Id).ToList();
            var objOrdenado = cventa.OrderBy(d => proc.IndexOf(d.Id)).ToList();
            cventa = new System.Collections.ObjectModel.ObservableCollection<T_CompraVentaPrecAdq>(objOrdenado);

            decimal Total=0;
            foreach (var item in cventa)
            {
                Total = Total + ((item.Efectivo != null) ? item.Efectivo.Value : Convert.ToDecimal(0));
            }
            #endregion

            #region Generate values group by isin
            //var secondFilter = cventa.Where(c => c.Tipo == "VENTA" && c.Fecha != null).OrderBy(o => o.Fecha);
            var secondFilter = cventa.Where(c => c.Tipo == "VENTA" && c.Fecha != null);            

            var distinctIsin = secondFilter.Select(p => p.Isin).Distinct().ToList();
            distinctIsin.AddRange(CompraVentaRespectoPrecioAdquisicion_DA.GetVentasPreview(plantilla.CodigoIc).Select(s => s.Isin));
            distinctIsin = distinctIsin.Distinct().ToList();
            //Tenemos que añadir los ISINS que se hayan modificado en la Preview y cumplan estas condiciones

            

            for (int i = 0; i < distinctIsin.Count; i++)
            {
                var idsOrdenadosTemp = new List<int>();
                this.PreviewWizardPage.MyStackPanelVertical.Children.Add(new CompraVentaRespectoPrecioAdquisicion_UC(plantilla, distinctIsin[i], fecha, idsOrdenadosTemp));
                this.PreviewWizardPage.MyStackPanelVertical.Width = 571;


                CompraVentaRespectoPrecioAdquisicion_UC k = (CompraVentaRespectoPrecioAdquisicion_UC)this.PreviewWizardPage.MyStackPanelVertical.Children[this.PreviewWizardPage.MyStackPanelVertical.Children.Count-1];
                if(k!=null)k.CellEditEnded += new EventHandler(UpdateTotalTextBox);
            }
            #endregion

            #region Fill TotalTexbox

            TextBlock MyTextBlankBlock = new TextBlock();
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlankBlock);

            TextBlock MyTextBlock = new TextBlock();
            MyTextBlock.TextAlignment = TextAlignment.Right;

            MyTextBlock.Inlines.Add(new Run() { Text = "TOTAL RENTA VARIABLE " + String.Format("{0:N2}", Total), FontWeight = FontWeights.Bold });

           
            this.PreviewWizardPage.MyStackPanelVertical.Children.Add(MyTextBlock);
            #endregion

        }
    }
}
