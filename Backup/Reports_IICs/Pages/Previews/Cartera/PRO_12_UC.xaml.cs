using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Windows.Controls;

namespace Reports_IICs.Pages.Previews.Cartera
{
    /// <summary>
    /// Interaction logic for PRO_12_UC.xaml
    /// </summary>
    public partial class PRO_12_UC : UserControl
    {
        private string _codigoIc;
        private string _isin;
        public PRO_12_UC(string codigoIc, string isin, DateTime fecha, Temp_PRO_12 tempPro12)
        {
            InitializeComponent();
            _codigoIc = codigoIc;
            _isin = isin;

            if (tempPro12 != null)
            {
                this.LabelIsin.Content = isin; 
                this.rentabilidadTextBox.Text = tempPro12.Rentabilidad.ToString();
                this.totalPatrimonioTextBox.Text = tempPro12.TotalPatrimonio.ToString();
                this.totalParticipacionesTextBox.Text = tempPro12.TotalParticipaciones.ToString();
                this.valorLiquidativoTextBox.Text = tempPro12.ValorLiquidativo.ToString();
                this.taeTextBox.Text = tempPro12.TAE.ToString();
                this.saldoTesoreriaTextBox.Text = tempPro12.SaldoTesoreria.ToString();
                this.activoComputable1TextBox.Text = tempPro12.ActivoComputable.ToString();                
            }
            
        }

        private void textBox_LostFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            var pro12_temp = Cartera_DA.GetTemp_PRO_12(_codigoIc,  _isin).FirstOrDefault();
            if (pro12_temp != null)
            {
                pro12_temp.Rentabilidad = Convert.ToDecimal(this.rentabilidadTextBox.Text);
                pro12_temp.TotalPatrimonio = Convert.ToDecimal(this.totalParticipacionesTextBox.Text);
                pro12_temp.TotalParticipaciones = Convert.ToDecimal(this.totalParticipacionesTextBox.Text);
                pro12_temp.ValorLiquidativo = Convert.ToDecimal(this.valorLiquidativoTextBox.Text);
                pro12_temp.TAE = Convert.ToDecimal(this.taeTextBox.Text);
                pro12_temp.SaldoTesoreria = Convert.ToDecimal(this.saldoTesoreriaTextBox.Text);
                pro12_temp.ActivoComputable = Convert.ToDecimal(this.activoComputable1TextBox.Text);
            }

            try
            {
                Cartera_DA.Update_Temp_PRO_12_Item(pro12_temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
