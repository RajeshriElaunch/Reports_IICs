using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls.GridView;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Telerik.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Distribucion_Patrimonio_Novarex
{
    /// <summary>
    /// Lógica de interacción para DistribucionPatrimonioNovarex_UC.xaml
    /// </summary>
    public partial class DistribucionPatrimonioNovarex_UC : UserControl
    {
        private Plantilla _plantilla;
        protected DateTime _fecha;

        private decimal TotalPatrimonio;
        private decimal TotalPatrimonioPorC;
        private string CodigoIC;
        private List<T_DistribucionPatrimonioNovarex_Total> gridTotal = new List<T_DistribucionPatrimonioNovarex_Total>();
        public DistribucionPatrimonioNovarex_UC()
        {
            InitializeComponent();
        }

        public DistribucionPatrimonioNovarex_UC(Plantilla plantilla, string isin, DateTime fecha)
        {
            InitializeComponent();
            _plantilla = plantilla;
            _fecha = fecha;
            CodigoIC = plantilla.CodigoIc;
            var DistribucionPatrimonioNovarexCartera = DataAccess.Reports.Report_DistribucionPatrimonioNovarex_DA.GetTemp_DistribucionPatrimonioNovarex_Cartera(plantilla.CodigoIc);
            var DistribucionPatrimonioNovarexPatrimonio = DataAccess.Reports.Report_DistribucionPatrimonioNovarex_DA.GetTemp_DistribucionPatrimonioNovarex_Tesoreria(plantilla.CodigoIc);
            this.myGridCartera.ItemsSource = DistribucionPatrimonioNovarexCartera;
            this.myGridPatrimonio.ItemsSource = DistribucionPatrimonioNovarexPatrimonio;

            #region Calculate  Total & %
            var SumValuesPatri = from r in DistribucionPatrimonioNovarexPatrimonio
             group r by new { CodigoIC = r.CodigoIC } into g
             select new
             {
                 CodigoIC = g.Key.CodigoIC,
                 totalPatri = g.Sum(x => x.Patrimonio),
                 totalPatriPorC = g.Sum(x => x.PorcentajePatrimonio)
             };

            var SumValuesCartera = from r in DistribucionPatrimonioNovarexCartera
                                   where r.Descripcion!= "TOTAL CARTERA"
                                   group r by new { CodigoIC = r.CodigoIC } into g
                                   select new
                                   {
                                       CodigoIC = g.Key.CodigoIC,
                                       totalPatri = g.Sum(x => x.Patrimonio),
                                       totalPatriPorC = g.Sum(x => x.PorcentajePatrimonio)
                                   };

            decimal sumPat = 0;
            if (SumValuesPatri.FirstOrDefault() != null)
                sumPat = SumValuesPatri.FirstOrDefault().totalPatri;
            decimal sumCart = 0;
            if (SumValuesCartera.FirstOrDefault() != null)
                sumCart = SumValuesCartera.FirstOrDefault().totalPatri;
            TotalPatrimonio = sumPat + sumCart;

            decimal sumPatPct = 0;
            if (SumValuesPatri.FirstOrDefault() != null)
                sumPatPct = SumValuesPatri.FirstOrDefault().totalPatriPorC;
            decimal sumCartPct = 0;
            if (SumValuesCartera.FirstOrDefault() != null)
                sumCartPct = SumValuesCartera.FirstOrDefault().totalPatriPorC;
            TotalPatrimonioPorC = sumPatPct + sumCartPct;

           
            T_DistribucionPatrimonioNovarex_Total gridTotalTemp = new T_DistribucionPatrimonioNovarex_Total();

            gridTotalTemp.Descripcion = "TOTAL";
            gridTotalTemp.Patrimonio = TotalPatrimonio;
            gridTotalTemp.PorcentajePatrimonio = TotalPatrimonioPorC;
            gridTotal.Add(gridTotalTemp);

            this.myGridTotal.ItemsSource = gridTotal;
            #endregion
        }

        private static Reports_IICSEntities dbcontext = new Reports_IICSEntities();

        private void myGridCartera_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempDistribucionPatrimonioNovarex_Cartera_Sel_object = (T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var DistribucionPatrimonioNovarex_Cartera_temp = dbcontext.Temp_DistribucionPatrimonioNovarex_Cartera.FirstOrDefault(p => p.Id == id);

                if (DistribucionPatrimonioNovarex_Cartera_temp != null)
                {
                    
                    switch (tempDistribucionPatrimonioNovarex_Cartera_Sel_object.Descripcion)
                        {
                        case "Renta Variable + IICsRV":
                            DistribucionPatrimonioNovarex_Cartera_temp.RentaVariable = tempDistribucionPatrimonioNovarex_Cartera_Sel_object.Patrimonio;
                            DistribucionPatrimonioNovarex_Cartera_temp.RentaVariablePorc = tempDistribucionPatrimonioNovarex_Cartera_Sel_object.PorcentajePatrimonio;

                            break;
                        case "REPO DEUDA":
                            
                            DistribucionPatrimonioNovarex_Cartera_temp.RepoDeuda = tempDistribucionPatrimonioNovarex_Cartera_Sel_object.Patrimonio;
                            DistribucionPatrimonioNovarex_Cartera_temp.RepoDeudaPorc = tempDistribucionPatrimonioNovarex_Cartera_Sel_object.PorcentajePatrimonio;

                            break;
                        case "Renta Fija + IICsRF":
                           
                            DistribucionPatrimonioNovarex_Cartera_temp.RentaFija = tempDistribucionPatrimonioNovarex_Cartera_Sel_object.Patrimonio;
                            DistribucionPatrimonioNovarex_Cartera_temp.RentaFijaPorc = tempDistribucionPatrimonioNovarex_Cartera_Sel_object.PorcentajePatrimonio;

                            break;
                       
                    }
                    
                }
                try
                {
                    dbcontext.SaveChanges();

                    #region Calculate %
                        var DistribucionPatrimonioNovarexCartera = DataAccess.Reports.Report_DistribucionPatrimonioNovarex_DA.GetTemp_DistribucionPatrimonioNovarex_Cartera(CodigoIC);
                        var DistribucionPatrimonioNovarexPatrimonio = DataAccess.Reports.Report_DistribucionPatrimonioNovarex_DA.GetTemp_DistribucionPatrimonioNovarex_Tesoreria(CodigoIC);

                    #region Calculate  Total & %

                        #region Get Values
                        var SumValuesPatri = from r in DistribucionPatrimonioNovarexPatrimonio
                                                 group r by new { CodigoIC = r.CodigoIC } into g
                                                 select new
                                                 {
                                                     CodigoIC = g.Key.CodigoIC,
                                                     totalPatri = g.Sum(x => x.Patrimonio),
                                                     totalPatriPorC = g.Sum(x => x.PorcentajePatrimonio)
                                                 };

                            var SumValuesCartera = from r in DistribucionPatrimonioNovarexCartera
                                                   where r.Descripcion != "TOTAL CARTERA"
                                                   group r by new { CodigoIC = r.CodigoIC } into g
                                                   select new
                                                   {
                                                       CodigoIC = g.Key.CodigoIC,
                                                       totalPatri = g.Sum(x => x.Patrimonio),
                                                       totalPatriPorC = g.Sum(x => x.PorcentajePatrimonio)
                                                   };

                            TotalPatrimonio = SumValuesPatri.FirstOrDefault().totalPatri + SumValuesCartera.FirstOrDefault().totalPatri;
                            TotalPatrimonioPorC = SumValuesPatri.FirstOrDefault().totalPatriPorC + SumValuesCartera.FirstOrDefault().totalPatriPorC;

                            T_DistribucionPatrimonioNovarex_Total gridTotalTemp = gridTotal.SingleOrDefault();
                            if(gridTotalTemp!=null)
                            {
                                gridTotalTemp.Patrimonio = TotalPatrimonio;
                                gridTotalTemp.PorcentajePatrimonio = TotalPatrimonioPorC;

                            }
                        #endregion

                    decimal TotalPatri_temp =0;
                        decimal TotalPatriPerct_temp=0;
                        decimal TotalPatri_tempParcial = 0;
                        decimal TotalPatriPerct_tempParcial = 0;

                        #region GridTesoreria Get Values To Sum
                            foreach (T_DistribucionPatrimonioNovarex_Tesoreria item in this.myGridPatrimonio.Items)
                            {
                                TotalPatri_temp = TotalPatri_temp + item.Patrimonio;
                                TotalPatriPerct_temp = TotalPatriPerct_temp + item.PorcentajePatrimonio;
                            }
                        #endregion

                        #region GridCartera
                        foreach (T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED item in this.myGridCartera.Items)
                        {
                            #region Object
                            if(item.Descripcion != "TOTAL CARTERA")
                            {
                                item.PorcentajePatrimonio = (item.Patrimonio / TotalPatrimonio) * 100;
                                TotalPatri_temp = TotalPatri_temp + item.Patrimonio;
                                TotalPatriPerct_temp = TotalPatriPerct_temp + item.PorcentajePatrimonio;
                                TotalPatri_tempParcial = TotalPatri_tempParcial + item.Patrimonio;
                                TotalPatriPerct_tempParcial = TotalPatriPerct_tempParcial + item.PorcentajePatrimonio;
                        }
                            else
                            {
                                item.Patrimonio = TotalPatri_tempParcial;
                                item.PorcentajePatrimonio = TotalPatriPerct_tempParcial;
                            }
                            #endregion
                            #region Save in DB
                                DistribucionPatrimonioNovarex_Cartera_temp = dbcontext.Temp_DistribucionPatrimonioNovarex_Cartera.FirstOrDefault(p => p.Id == item.Id);
                                if (DistribucionPatrimonioNovarex_Cartera_temp != null)
                                {
                                    switch (item.Descripcion)
                                    {
                                        case "Renta Variable + IICsRV":
                                            DistribucionPatrimonioNovarex_Cartera_temp.RentaVariable = item.Patrimonio;
                                            DistribucionPatrimonioNovarex_Cartera_temp.RentaVariablePorc = item.PorcentajePatrimonio;

                                            break;
                                        case "REPO DEUDA":

                                            DistribucionPatrimonioNovarex_Cartera_temp.RepoDeuda = item.Patrimonio;
                                            DistribucionPatrimonioNovarex_Cartera_temp.RepoDeudaPorc = item.PorcentajePatrimonio;

                                            break;
                                        case "Renta Fija + IICsRF":

                                            DistribucionPatrimonioNovarex_Cartera_temp.RentaFija = item.Patrimonio;
                                            DistribucionPatrimonioNovarex_Cartera_temp.RentaFijaPorc = item.PorcentajePatrimonio;

                                            break;

                                    }

                            }
                            try
                            {
                                dbcontext.SaveChanges();
                            }
                            catch (Exception)
                            {

                            }
                            #endregion
                        }
                    #endregion

                    #region Update Values in GridTesoreria 
                    foreach (T_DistribucionPatrimonioNovarex_Tesoreria item in this.myGridPatrimonio.Items)
                    {
                        item.PorcentajePatrimonio = (item.Patrimonio / TotalPatrimonio) * 100;
                        #region Save In DB
                            var DistribucionPatrimonioNovarex_Patrimonio_temp = dbcontext.Temp_DistribucionPatrimonioNovarex_Tesoreria.FirstOrDefault(p => p.Id == item.Id);
                            if (DistribucionPatrimonioNovarex_Patrimonio_temp != null)
                            {
                            
                            DistribucionPatrimonioNovarex_Patrimonio_temp.PorcentajePatrimonio = item.PorcentajePatrimonio;

                            }
                            try
                            {
                                dbcontext.SaveChanges();
                            }
                            catch (Exception)
                            {

                            }
                        #endregion
                    }
                    #endregion



                    #endregion


                    #endregion


                }
                catch (Exception)
                {

                }

            }


        }

        private void myGridPatrimonio_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {

            int id = ((T_DistribucionPatrimonioNovarex_Tesoreria)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var tempDistribucionPatrimonioNovarex_Tesoreria_Sel_object = (T_DistribucionPatrimonioNovarex_Tesoreria)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;


            using (dbcontext = new Reports_IICSEntities())
            {
                var distribucionPatrimonioNovarex_temp = dbcontext.Temp_DistribucionPatrimonioNovarex_Tesoreria.FirstOrDefault(p => p.Id == id);

                if (distribucionPatrimonioNovarex_temp != null)
                {
                    distribucionPatrimonioNovarex_temp.Patrimonio = tempDistribucionPatrimonioNovarex_Tesoreria_Sel_object.Patrimonio;
                    distribucionPatrimonioNovarex_temp.PorcentajePatrimonio = tempDistribucionPatrimonioNovarex_Tesoreria_Sel_object.PorcentajePatrimonio;
                }
                try
                {
                    dbcontext.SaveChanges();
                    #region Calculate %
                    var DistribucionPatrimonioNovarexCartera = DataAccess.Reports.Report_DistribucionPatrimonioNovarex_DA.GetTemp_DistribucionPatrimonioNovarex_Cartera(CodigoIC);
                    var DistribucionPatrimonioNovarexPatrimonio = DataAccess.Reports.Report_DistribucionPatrimonioNovarex_DA.GetTemp_DistribucionPatrimonioNovarex_Tesoreria(CodigoIC);

                    #region Calculate  Total & %

                    #region Get Values
                    var SumValuesPatri = from r in DistribucionPatrimonioNovarexPatrimonio
                                         group r by new { CodigoIC = r.CodigoIC } into g
                                         select new
                                         {
                                             CodigoIC = g.Key.CodigoIC,
                                             totalPatri = g.Sum(x => x.Patrimonio),
                                             totalPatriPorC = g.Sum(x => x.PorcentajePatrimonio)
                                         };

                    var SumValuesCartera = from r in DistribucionPatrimonioNovarexCartera
                                           where r.Descripcion != "TOTAL CARTERA"
                                           group r by new { CodigoIC = r.CodigoIC } into g
                                           select new
                                           {
                                               CodigoIC = g.Key.CodigoIC,
                                               totalPatri = g.Sum(x => x.Patrimonio),
                                               totalPatriPorC = g.Sum(x => x.PorcentajePatrimonio)
                                           };

                    TotalPatrimonio = SumValuesPatri.FirstOrDefault().totalPatri + SumValuesCartera.FirstOrDefault().totalPatri;
                    TotalPatrimonioPorC = SumValuesPatri.FirstOrDefault().totalPatriPorC + SumValuesCartera.FirstOrDefault().totalPatriPorC;

                    T_DistribucionPatrimonioNovarex_Total gridTotalTemp = gridTotal.SingleOrDefault();
                    if (gridTotalTemp != null)
                    {
                        gridTotalTemp.Patrimonio = TotalPatrimonio;
                        gridTotalTemp.PorcentajePatrimonio = TotalPatrimonioPorC;

                    }
                    #endregion

                    decimal TotalPatri_temp = 0;
                    decimal TotalPatriPerct_temp = 0;
                  

                    #region Update Values in GridPatrimonio
                    foreach (T_DistribucionPatrimonioNovarex_Tesoreria item in this.myGridPatrimonio.Items)
                    {
                        item.PorcentajePatrimonio = (item.Patrimonio / TotalPatrimonio) * 100;
                        #region Save In DB
                        var DistribucionPatrimonioNovarex_Patrimonio_temp = dbcontext.Temp_DistribucionPatrimonioNovarex_Tesoreria.FirstOrDefault(p => p.Id == item.Id);
                        if (DistribucionPatrimonioNovarex_Patrimonio_temp != null)
                        {

                            DistribucionPatrimonioNovarex_Patrimonio_temp.PorcentajePatrimonio = item.PorcentajePatrimonio;

                        }
                        try
                        {
                            dbcontext.SaveChanges();
                        }
                        catch (Exception)
                        {

                        }
                        #endregion
                    }
                    #endregion

                    #region Update Values in GridCartera

                    foreach (T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED item in this.myGridCartera.Items)
                    {
                        if (item.Descripcion != "TOTAL CARTERA")
                        {
                            item.PorcentajePatrimonio = (item.Patrimonio / TotalPatrimonio) * 100;
                            TotalPatri_temp = TotalPatri_temp + item.Patrimonio;
                            TotalPatriPerct_temp = TotalPatriPerct_temp + item.PorcentajePatrimonio;
                        }
                        else
                        {
                            item.PorcentajePatrimonio = TotalPatriPerct_temp;
                            item.Patrimonio = TotalPatri_temp;
                        }

                        #region Save In DB
                        var DistribucionPatrimonioNovarex_Cartera_temp = dbcontext.Temp_DistribucionPatrimonioNovarex_Cartera.FirstOrDefault(p => p.Id == item.Id);
                        if (DistribucionPatrimonioNovarex_Cartera_temp != null)
                        {
                            switch (item.Descripcion)
                            {
                                case "Renta Variable + IICsRV":
                                    DistribucionPatrimonioNovarex_Cartera_temp.RentaVariable = item.Patrimonio;
                                    DistribucionPatrimonioNovarex_Cartera_temp.RentaVariablePorc = item.PorcentajePatrimonio;

                                    break;
                                case "REPO DEUDA":

                                    DistribucionPatrimonioNovarex_Cartera_temp.RepoDeuda = item.Patrimonio;
                                    DistribucionPatrimonioNovarex_Cartera_temp.RepoDeudaPorc = item.PorcentajePatrimonio;

                                    break;
                                case "Renta Fija + IICsRF":

                                    DistribucionPatrimonioNovarex_Cartera_temp.RentaFija = item.Patrimonio;
                                    DistribucionPatrimonioNovarex_Cartera_temp.RentaFijaPorc = item.PorcentajePatrimonio;

                                    break;
                                    
                            }
                        }
                        try
                        {
                            dbcontext.SaveChanges();
                        }
                        catch (Exception)
                        {

                        }
                        #endregion

                    }

                   
                    #endregion

                    #endregion

                    #endregion


                }
                catch (Exception)
                {

                }

            }


        }

        private void myGrid_DataLoaded(object sender, EventArgs e)
        {
            ((RadGridView)sender).ExpandAllGroups();

        }

        private void myGrid_RowLoaded(object sender, Telerik.Windows.Controls.GridView.RowLoadedEventArgs e)
        {
            var row = e.Row as GridViewRow;


            if (row != null)

            {

            }
        }

        private void myGrid_BeginningEdit(object sender, GridViewBeginningEditRoutedEventArgs e)
        {


            //if (e.Cell.Column.Name == "Cotizacion")
            //{
            //    if (((Reports_IICs.DataAccess.Reports.T_RVComprasRealizadasEjercicio)e.Row.DataContext).Vendido)
            //    {
            //        e.Cancel = true;
            //    }
            //}


        }
    }
}
