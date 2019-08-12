namespace Reports_IICs.Reports.DesgloseGastos
{
    using Helpers;
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for ReportVariacionPatrimonialB.
    /// </summary>
    public partial class ReportDesgloseGastos : Telerik.Reporting.Report
    {
        public ReportDesgloseGastos()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportDesgloseGastos(string codigoIC, int idSeccion, string isin, DateTime fechainforme)
        {
            
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
            
            this.ReportParameters["FechaInforme"].Value = fechainforme;
            this.ReportParameters["CodigoIC"].Value = codigoIC;
            this.ReportParameters["Isin"].Value = isin;
            this.ReportParameters["IdSeccion"].Value = idSeccion;

            var instanceReportSource1 = new Telerik.Reporting.InstanceReportSource();
            instanceReportSource1.ReportDocument = new ReportDesgloseGastos_SUB(codigoIC, idSeccion);
            this.subReport1.ReportSource = instanceReportSource1;

            this.sqlDataSource1.Parameters[0].Value = codigoIC;
            this.sqlDataSource1.Parameters[1].Value = isin;

            //loadTexts();

        }

        /// <summary>
        /// Hay dos filas que ocultamos en caso de ser 0: 
        /// Comisión Fija Pagada
        /// Comisión Variable
        /// En caso de que alguno de los dos sea 0, tenemos que colorear las líneas correctamente con este procedimiento
        /// </summary>
        private void colorear(bool comFijaPagada, bool comVariable)
        {
            //panelComFijaPagada y panelComFijaDevenNoPagada sólo se muestran si comFijaPagada != 0            
            //if (!comFijaPagada)
            //{
            //    //alternarColor(panelComFijaDevenNoPagada);
            //    if (comVariable)
            //        alternarColor(panelComVariable);
            //}
            //OR exclusivo
            //if(!comFijaPagada ^ !comVariable)
            
            //OR
            if (!comVariable)
            {
                foreach(var pnl in getListaPaneles())
                {
                    alternarColor(pnl);
                }
            }
        }

        /// <summary>
        /// Devuelve los paneles que siguen la regla común para el cambio de color si se oculta panelComFijaPagada o panelComVariable.
        /// Es decir, todos los que están por debajo de panelComVariable
        /// </summary>
        private List<Telerik.Reporting.Panel> getListaPaneles()
        {
            var lista = new List<Telerik.Reporting.Panel>();
/*
            lista.Add(panelServExterioresOtros);
            lista.Add(panelComDepositario);
            lista.Add(panelGastosTasaRegOficiales);
            lista.Add(panelGastosAdmisCotBolsa);
            lista.Add(panelGastosDifPeriodificaciones);
            lista.Add(panelGastosBancarios);
            lista.Add(panelGastosRegLibroAcc);
            lista.Add(panelAuditoriaCtas);
            lista.Add(panelOtros);
            lista.Add(panelImpuestoSS);
            */
            return lista;
        }

        private void alternarColor(Telerik.Reporting.Panel pnl)
        {
            /*
            var color1 = panel1.Style.BackgroundColor;
            var color2 = panel2.Style.BackgroundColor;

            var pnlColor = pnl.Style.BackgroundColor;
            
            if (pnlColor == color1)
                pnl.Style.BackgroundColor = color2;
            else
                pnl.Style.BackgroundColor = color1;
                */
        }

        private void detail_ItemDataBound(object sender, EventArgs e)
        {
            /*
            //var comFijaPagadaVisible = new System.Collections.Generic.Mscorlib_CollectionDebugView<Telerik.Reporting.Processing.ProcessingElement>(((Telerik.Reporting.Processing.ProcessingElement)sender).ChildElements).Items[3].Visible;
            Telerik.Reporting.Processing.DetailSection section = (sender as Telerik.Reporting.Processing.DetailSection);
            var comFijaPagVisible = ((Telerik.Reporting.Processing.Panel)Telerik.Reporting.Processing.ElementTreeHelper.GetChildByName(section, "panelComFijaPagada")).Visible;
            var comVariableVisible = ((Telerik.Reporting.Processing.Panel)Telerik.Reporting.Processing.ElementTreeHelper.GetChildByName(section, "panelComVariable")).Visible;

            colorear(comFijaPagVisible, comVariableVisible);
            */
        }

        private void ReportVariacionPatrimonialB_ItemDataBinding(object sender, EventArgs e)
        {
            string codigoIC = this.ReportParameters["CodigoIC"].Value.ToString();
            Utils.CenterPanel(codigoIC, this.Report, this.panel1);
            Utils.CenterPanel(codigoIC, this.Report, this.panel17);
            //Utils.CenterPanel(codigoIC, this.Report, this.panel3);
            
        }

        private void subReport1_ItemDataBinding(object sender, EventArgs e)
        {
            //Hacemos esto porque el subreport no está cogiendo automáticamente los parámetros
            //this.subReport1.Parameters.Parameters["CodigoIC"].Value = this.ReportParameters["CodigoIC"].Value;
            //this.subReport1.ReportSource.Parameters["IdSeccion"].Value = this.ReportParameters["IdSeccion"].Value;
        }



        //private void loadTexts()
        //{
        //    this.TituloReport.Value = Resources.Resource.TituloReportEvolucionPatriOperacionesRealizadasGuissona;
        //}
    }
}