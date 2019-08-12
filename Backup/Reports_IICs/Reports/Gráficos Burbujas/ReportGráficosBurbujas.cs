namespace Reports_IICs.Reports.Gráficos_Burbujas
{
    using Telerik.Reporting;

    /// <summary>
    /// Summary description for ReportGráficosBurbujas.
    /// </summary>
    public partial class ReportGráficosBurbujas : Telerik.Reporting.Report
    {
        public ReportGráficosBurbujas()
        {
            //
            // Required for telerik Reporting designer support
            //
            InitializeComponent();


            // TODO: Add any constructor code after InitializeComponent call
            //
            NumericalScale escalaY = new NumericalScale();

            escalaY.Minimum = -2;
            NumericalScaleCrossAxisPosition EscalaYStartValue = new NumericalScaleCrossAxisPosition();
            EscalaYStartValue.Position = GraphScaleCrossAxisPosition.Specific;
            EscalaYStartValue.Value = -2;
            escalaY.CrossAxisPositions.Add(EscalaYStartValue);
            //Eje y
            var k = graphAxis8.Scale.SpacingSlotCount;
            graphAxis8.Scale = escalaY;
           
            //Eje X

            NumericalScale escalaX = new NumericalScale();

            escalaX.Minimum = -50;
            NumericalScaleCrossAxisPosition EscalaXStartValue = new NumericalScaleCrossAxisPosition();
            EscalaXStartValue.Position = GraphScaleCrossAxisPosition.Specific;
            EscalaXStartValue.Value = -50;
            escalaX.CrossAxisPositions.Add(EscalaXStartValue);

            var j = graphAxis7.Scale.SpacingSlotCount;
            

            graphAxis7.Scale = escalaX;
        }

        public ReportGráficosBurbujas(string isin, string isinDesc, string codigoic, double? minEjeX, double? minEjeY, double? maxEjeY, double? stepX, double? stepY)
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
                //EscalaYStartValue.Value = 0; //Force Zero
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