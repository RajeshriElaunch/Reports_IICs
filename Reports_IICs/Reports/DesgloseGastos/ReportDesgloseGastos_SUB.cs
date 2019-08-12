namespace Reports_IICs.Reports.DesgloseGastos
{
    using DataAccess.Reports;
    using DataModels;
    using System;
    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Media;

    /// <summary>
    /// Summary description for ReportVariacionPatrimonialB_SUB.
    /// </summary>
    public partial class ReportDesgloseGastos_SUB : Telerik.Reporting.Report
    {
        private int _idSeccion;
        private Get_Temp_DesgloseGastos_Result _data = new Get_Temp_DesgloseGastos_Result();
        public ReportDesgloseGastos_SUB(string codigoIC, int idSeccion)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();
            _idSeccion = idSeccion;
            this.ReportParameters["CodigoIC"].Value = codigoIC;
            this.ReportParameters["IdSeccion"].Value = idSeccion;

            _data = DesgloseGastos_DA.Get_Temp_DesgloseGastos(codigoIC, string.Empty);
            this.DataSource = _data;
            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void ReportVariacionPatrimonialB_SUB_ItemDataBinding(object sender, EventArgs e)
        {
            var report1 = (sender as Telerik.Reporting.Processing.Report);
            var idSecc = Convert.ToInt32(report1.Parameters["IdSeccion"].Value);
            if (idSecc == 5)
            {
                //this.panel1.Visible = false;
                this.panel3.Visible = false;
                this.panel4.Visible = false;
                this.panel5.Visible = false;
                this.panel6.Visible = false;
                this.panel9.Visible = false;
                this.panel10.Visible = false;
                this.panel11.Visible = false;
                this.panel12.Visible = false;
                this.panel13.Visible = false;
                this.panel14.Visible = false;
                this.panel15.Visible = false;

                //Recolocamos los paneles visibles. Los ponemos en la posición de algún panel que acabamos de ocultar
                CopyYPosition(panel7, panel3);
                CopyYPosition(panel8, panel4);
                CopyYPosition(panel16, panel5);                

                //var aaa = detail..GetChildOfType<Telerik.Reporting.Panel>();
                //Modificamos el tamaño de detail     
                //this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(1.86);                
            }
            else
            {
                if(_data.ComFijaPagada + _data.ComFijaDevengada == 0)
                {
                    this.panel3.Visible = false;
                    this.panel4.Visible = false;
                    this.panel5.Visible = false;
                }

                if (_data.MostrarFijaPagada != null && !(bool)_data.MostrarFijaPagada)
                {
                    this.panel4.Visible = false;
                    this.panel5.Visible = false;
                }

                ShowHidePanel(_data.ComVariable, panel6);
                ShowHidePanel(_data.ComDepositario, panel8);
                ShowHidePanel(_data.GastosTasaRegistrosOficiales, panel9);
                ShowHidePanel(_data.GastosAdmisionCotizacionBolsa, panel10);
                ShowHidePanel(_data.GastosDiferenciaPeriodificaciones, panel11);
                ShowHidePanel(_data.GastosBancarios, panel12);
                ShowHidePanel(_data.GastosRegistroLibroAccionistas, panel13);
                ShowHidePanel(_data.AuditoriaCuentas, panel14);
                ShowHidePanel(_data.Otros, panel15);
            }
            //else if (idSecc == 46)
            //{
            //    //Modificamos el tamaño de detail     
            //    this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(4.5);
            //}

            //Ajustamos el alto de "detail"
            int contPnls = 0;
            foreach (var item in detail.Items)
            {
                if (item.GetType() == typeof(Telerik.Reporting.Panel)
                    && ((Telerik.Reporting.Panel)item).Visible)
                {
                    
                    contPnls++;
                }
            }
            this.detail.Height = Telerik.Reporting.Drawing.Unit.Cm(0.4 * Convert.ToDouble(contPnls));
        }

        private void ShowHidePanel(decimal valor, Telerik.Reporting.Panel pnl)
        {
            if (valor == 0)
                pnl.Visible = false;
            else
                pnl.Visible = true;
        }

        private void CopyYPosition(Telerik.Reporting.Panel pnlToChange, Telerik.Reporting.Panel pnlY)
        {
            pnlToChange.Location = new Telerik.Reporting.Drawing.PointU(
                Telerik.Reporting.Drawing.Unit.Cm(pnlToChange.Location.X.Value),
                Telerik.Reporting.Drawing.Unit.Cm(pnlY.Location.Y.Value));
        }
        
    }
}