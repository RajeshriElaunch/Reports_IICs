using Reports_IICs.DataModels;
using System.Windows.Controls;
using System.Linq;
using System;
using Reports_IICs.DataAccess.Reports;

namespace Reports_IICs.Pages.Previews.Cartera
{
    /// <summary>
    /// Interaction logic for PRO_11_Preview.xaml
    /// </summary>
    public partial class PRO_11_UC : UserControl
    {
        private string _codigoIC;
        private string _tipo;
        public PRO_11_UC(string codigoIc, string tipo)
        {
            InitializeComponent();
            _codigoIC = codigoIc;
            _tipo = tipo;
            getData();
        }

        private void getData()
        {
            var pro11 = Cartera_DA.GetTemp_PRO_11(_codigoIC, _tipo).ToList();
            this.myGrid.ItemsSource = pro11;
        }

        private void myGrid_CellEditEnded(object sender, Telerik.Windows.Controls.GridViewCellEditEndedEventArgs e)
        {
            int id = ((Reports_IICs.DataModels.Temp_PRO_11)(((Telerik.Windows.Controls.DataControl)sender).SelectedItem)).Id;
            var pro11_Sel_object = (Temp_PRO_11)((Telerik.Windows.Controls.DataControl)sender).SelectedItem;
            Temp_PRO_11 pro11_temp = new Temp_PRO_11(); ;

            pro11_temp.Id = id;
            pro11_temp.Cambio = pro11_Sel_object.Cambio;
            pro11_temp.Cantidad = pro11_Sel_object.Cantidad;
            pro11_temp.CodigoIC = _codigoIC;
            pro11_temp.CosteMedio = pro11_Sel_object.CosteMedio;
            pro11_temp.DescripcionValor = pro11_Sel_object.DescripcionValor;
            pro11_temp.Dias = pro11_Sel_object.Dias;
            pro11_temp.Divisa = pro11_Sel_object.Divisa;
            pro11_temp.EfectivoActual = pro11_Sel_object.EfectivoActual;
            pro11_temp.EfectivoCompra = pro11_Sel_object.EfectivoCompra;
            pro11_temp.Intereses = pro11_Sel_object.Intereses;
            pro11_temp.Minusvalias = pro11_Sel_object.Minusvalias;
            pro11_temp.Nominal = pro11_Sel_object.Nominal;
            pro11_temp.Plusvalias = pro11_Sel_object.Plusvalias;
            pro11_temp.Porcentaje = pro11_Sel_object.Porcentaje;
            pro11_temp.PorcentajeP = pro11_Sel_object.PorcentajeP;
            pro11_temp.Tipo = pro11_Sel_object.Tipo;
            pro11_temp.TIR_C_Fif = pro11_Sel_object.TIR_C_Fif;
            pro11_temp.ValorActualDivisa = pro11_Sel_object.ValorActualDivisa;
            pro11_temp.Vencimiento = pro11_Sel_object.Vencimiento;

            try
            {
                Cartera_DA.Update_Temp_PRO_11_Item(pro11_temp);                
            }
            catch (Exception)
            {

            }

        }

    }
}
