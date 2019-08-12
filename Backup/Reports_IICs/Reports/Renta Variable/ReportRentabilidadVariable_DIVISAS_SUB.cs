namespace Reports_IICs.Reports.Renta_Variable
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Summary description for ReportRentabilidadVariable_GARANTIZADOSESTRUCTURADOS_SUB.
    /// </summary>
    public partial class ReportRentabilidadVariable_DIVISAS_SUB : Telerik.Reporting.Report
    {
        //Esta variable la utilizaremos para ocultar la cabecera en caso de que ningún subreports sea visible
        private List<bool> subreportsVisibles = new List<bool>();
        public ReportRentabilidadVariable_DIVISAS_SUB()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void subReportIICS_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void subReportOTROS_ItemDataBound(object sender, EventArgs e)
        {
            subreportsVisibles.Add(ReportsUtils.HideSubReportIfNoRecords(sender));
        }

        private void ReportRentabilidadVariable_GARANTIZADOSESTRUCTURADOS_SUB_ItemDataBound(object sender, EventArgs e)
        {
            //si no existe ningún subreport con Visible = true
            //No mostramos nada
            if(!subreportsVisibles.Exists(ex => ex))
            {
                this.Visible = false;
            }
        }
    }
}