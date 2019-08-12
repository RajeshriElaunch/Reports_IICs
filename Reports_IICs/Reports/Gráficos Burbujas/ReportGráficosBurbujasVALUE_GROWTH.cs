namespace Reports_IICs.Reports.Gráficos_Burbujas
{
    using Telerik.Reporting;

    /// <summary>
    /// Summary description for ReportGráficosBurbujasVALUE_GROWTH.
    /// </summary>
    public partial class ReportGráficosBurbujasVALUE_GROWTH : Telerik.Reporting.Report
    {
        public ReportGráficosBurbujasVALUE_GROWTH()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        public ReportGráficosBurbujasVALUE_GROWTH(string isin, string isinDesc, string codigoic, double? minEjeX, double? minEjeY, double? maxEjeY, double? stepX, double? stepY)
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();

            //if(minEjeX!=0)
            //{
            #region Correct SCALE Eje X



            //Eje X

            NumericalScale escalaX = new NumericalScale();

            escalaX.Minimum = minEjeX.Value;
            NumericalScaleCrossAxisPosition EscalaXStartValue = new NumericalScaleCrossAxisPosition();
            EscalaXStartValue.Position = GraphScaleCrossAxisPosition.Specific;
            EscalaXStartValue.Value = minEjeX.Value;
            escalaX.MajorStep = stepX.Value;
            escalaX.MinorStep = stepX.Value;
            escalaX.CrossAxisPositions.Add(EscalaXStartValue);

            graphAxis7.Scale = escalaX;
            #endregion

            //}
            //if (minEjeY != 0)
            //{
            #region Correct SCALE EjeY
            NumericalScale escalaY = new NumericalScale();

            escalaY.Minimum = minEjeY.Value;
            escalaY.MajorStep = stepY.Value;
            escalaY.MinorStep = stepY.Value;
            escalaY.Maximum = maxEjeY.Value;
            NumericalScaleCrossAxisPosition EscalaYStartValue = new NumericalScaleCrossAxisPosition();
            EscalaYStartValue.Position = GraphScaleCrossAxisPosition.Specific;
            EscalaYStartValue.Value = minEjeY.Value;

            escalaY.CrossAxisPositions.Add(EscalaYStartValue);
            //Eje y
            graphAxis8.Scale = escalaY;

            #endregion
            //}


            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }
    }
}