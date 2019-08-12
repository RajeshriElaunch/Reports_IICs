namespace Reports_IICs.Reports.VariacionPatrimonialA
{
    using System;

    /// <summary>
    /// Summary description for SubReportRendimientos.
    /// </summary>
    public partial class SubReportRendimientos : Telerik.Reporting.Report
    {
        public SubReportRendimientos()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        private void textBox_ItemDataBound(object sender, EventArgs e)
        {
            if(((Telerik.Reporting.Processing.TextBox)sender).Text == "0")
            {
                ((Telerik.Reporting.Processing.TextBox)sender).Value = string.Empty;
            }
        }
    }
}