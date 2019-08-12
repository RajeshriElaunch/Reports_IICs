namespace Reports_IICs.Reports.Evolución.Evolución_índices_de_referencia
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;
    using Telerik.Reporting;
    using Telerik.Reporting.Drawing;

    /// <summary>
    /// Summary description for ReportEvolucionIndicesBenchMarkPRO_03.
    /// </summary>
    public partial class ReportEvolucionIndicesBenchMarkPRO_03 : Telerik.Reporting.Report
    {
        public ReportEvolucionIndicesBenchMarkPRO_03()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void table1_ItemDataBound(object sender, EventArgs e)
        {
            //Si no tiene filas ocultamos el Report
            //1 fila es la cabecera
            //a partir de la segunda fila vienen los datos
            if(((Telerik.Reporting.Processing.Table)sender).Rows.Count < 2)
            {
                Telerik.Reporting.Processing.ReportItemBase item = (Telerik.Reporting.Processing.ReportItemBase)sender;
                item.Visible = false;
            }

            

        }
    }
}