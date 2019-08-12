using Reports_IICs.DataModels;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Reports_IICs.Pages.Previews.Variacion_Patrimonial_B
{
    /// <summary>
    /// Lógica de interacción para VariacionPatrimonialB_UC.xaml
    /// </summary>
    /// 

   

    public partial class VariacionPatrimonialB_UC : UserControl
    {
        private int Id_Selected;

        public VariacionPatrimonialB_UC()
        {
            InitializeComponent();
        }

        public VariacionPatrimonialB_UC(Plantilla plantilla, string isin,DateTime fecha)
        {
            InitializeComponent();

            var vpatrimonial = DataAccess.Reports.ReportDesgloseGastosDA.GetTemp_VariacionPatrimonialB(plantilla.CodigoIc, isin);
            if (vpatrimonial != null)
            {
                if(vpatrimonial.Count==1)
                {
                    var tmp_vpatrimonial = vpatrimonial.FirstOrDefault();

                    decimal TotalServiciosExteriores = tmp_vpatrimonial.ComDepositario + tmp_vpatrimonial.GastosTasaRegistrosOficiales + tmp_vpatrimonial.GastosAdmisionCotizacionBolsa + tmp_vpatrimonial.GastosDiferenciaPeriodificaciones + tmp_vpatrimonial.GastosBancarios + tmp_vpatrimonial.GastosRegistroLibroAccionistas + tmp_vpatrimonial.AuditoriaCuentas + tmp_vpatrimonial.Otros;
                    Id_Selected = tmp_vpatrimonial.Id;
                    decimal ComisionFija = tmp_vpatrimonial.ComFijaPagada + tmp_vpatrimonial.ComFijaDevengada;
                    decimal ComisionGestion = ComisionFija + tmp_vpatrimonial.ComVariable;
                    decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + tmp_vpatrimonial.ImpuestoSobreSociedades;

                    System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("es-ES");

                    //String.Format("{0:N2}", item.CotizacionFechaFin);

                    TxtTotalGastosGestionCorriente.Text = String.Format( "{0:N2}", TotalGastosGestionCorriente);
                    TxtTotalGastosGestionCorriente.IsReadOnly = true;

                    TxtComisionGestion.Text = String.Format(culture, "{0:N2}", ComisionGestion);
                    TxtComisionGestion.IsReadOnly = true;

                    TxtComisionFija.Text = String.Format(culture, "{0:N2}", ComisionFija);

                    TxtAuditoriadecuentas.Text = String.Format(culture, "{0:#,###0}", tmp_vpatrimonial.AuditoriaCuentas);

                   
                    TxtTotalServiciosExteriores.Text = String.Format(culture, "{0:N2}", TotalServiciosExteriores);
                    TxtTotalServiciosExteriores.IsReadOnly = true;

                    TxtComisionDepositario.Text = String.Format("{0:N2}", tmp_vpatrimonial.ComDepositario);
                    
                    TxtComisionFijaPagada.Text = String.Format("{0:N2}", tmp_vpatrimonial.ComFijaPagada);
                    TxtComisionFijaPagadaDevengada.Text = String.Format("{0:N2}", tmp_vpatrimonial.ComFijaDevengada);
                    TxtComisionVariable.Text = String.Format("{0:N2}", tmp_vpatrimonial.ComVariable);
                    TxtGastosAdmiCotizaBolsa.Text = String.Format("{0:N2}", tmp_vpatrimonial.GastosAdmisionCotizacionBolsa);
                    TxtGastosBancarios.Text = String.Format("{0:N2}", tmp_vpatrimonial.GastosBancarios);
                    TxtGastosdifperiodificaciones.Text = String.Format("{0:N2}", tmp_vpatrimonial.GastosDiferenciaPeriodificaciones);
                    TxtGastosRegistroLibroAccionistas.Text = String.Format("{0:N2}", tmp_vpatrimonial.GastosRegistroLibroAccionistas);
                    TxtGastostasaRegOfi.Text = String.Format("{0:N2}", tmp_vpatrimonial.GastosTasaRegistrosOficiales);
                   
                    TxtOtros.Text = String.Format("{0:N2}", tmp_vpatrimonial.Otros);
                    TxtPatrimonio.Text = String.Format("{0:N2}", tmp_vpatrimonial.PatrimonioFechaInforme);
                   
                    TxtImpuestSobreSociedades.Text = String.Format("{0:N2}", tmp_vpatrimonial.ImpuestoSobreSociedades);
                    this.lblPatrimonio.Content = this.lblPatrimonio.Content.ToString() + " " + fecha.ToShortDateString();

                }
            }
            Loaded += OnLoaded;

        }

        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            
            Loaded -= OnLoaded;
        }

        
        private void GuardarVariacionPatrimonialB()
        {

            using (var dbcontext = new Reports_IICSEntities())
            {

                var selectedVariPatrimonialB = dbcontext.Temp_DesgloseGastos.FirstOrDefault(c => c.Id == Id_Selected);
                if (selectedVariPatrimonialB != null)
                {
                    try
                    {
                        selectedVariPatrimonialB.AuditoriaCuentas = Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text);
                       
                        selectedVariPatrimonialB.ComDepositario = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text);
                        selectedVariPatrimonialB.ComFijaDevengada = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text); 
                        selectedVariPatrimonialB.ComFijaPagada = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text);
                        selectedVariPatrimonialB.ComVariable = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text);
                        selectedVariPatrimonialB.GastosAdmisionCotizacionBolsa = Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text);
                        selectedVariPatrimonialB.GastosBancarios = Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text);
                        selectedVariPatrimonialB.GastosDiferenciaPeriodificaciones = Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text);
                        selectedVariPatrimonialB.GastosRegistroLibroAccionistas = Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text);
                        selectedVariPatrimonialB.GastosTasaRegistrosOficiales = Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text);
                        selectedVariPatrimonialB.ImpuestoSobreSociedades = Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text);
                        selectedVariPatrimonialB.Otros = Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text);
                        selectedVariPatrimonialB.PatrimonioFechaInforme = Convert.ToDecimal(string.IsNullOrEmpty(TxtPatrimonio.Text) ? "0" : TxtPatrimonio.Text);
                        dbcontext.SaveChanges();
                    }
                    catch (Exception)
                    {

                    }
                }
            }
           

           

        }

        private void TxtComisionFijaPagada_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text)? "0":TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0":TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ?"0":TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ?"0":TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ?"0":TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ?"0":TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ?"0":TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ?"0":TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ?"0":TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ?"0":TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ?"0":TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ?"0":TxtImpuestSobreSociedades.Text.Replace(".", ""));

            TxtComisionFija.Text = String.Format("{0:N2}", ComisionFija);
            TxtComisionGestion.Text = String.Format("{0:N2}", ComisionGestion);
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            GuardarVariacionPatrimonialB();
        }

        private void TxtComisionFijaPagadaDevengada_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            TxtComisionFija.Text = String.Format("{0:N2}", ComisionFija);
            TxtComisionGestion.Text = String.Format("{0:N2}", ComisionGestion);
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            GuardarVariacionPatrimonialB();
        }

        private void TxtComisionVariable_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            TxtComisionFija.Text = String.Format("{0:N2}", ComisionFija);
            TxtComisionGestion.Text = String.Format("{0:N2}", ComisionGestion);
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            GuardarVariacionPatrimonialB();

        }

        private void TxtComisionDepositario_TextInput(object sender, TextCompositionEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);
            GuardarVariacionPatrimonialB();
        }

        private void TxtGastostasaRegOfi_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);
            GuardarVariacionPatrimonialB();

        }

        private void TxtGastosAdmiCotizaBolsa_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);
            GuardarVariacionPatrimonialB();

        }

        private void TxtGastosdifperiodificaciones_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text);

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);
            GuardarVariacionPatrimonialB();

        }

        private void TxtGastosBancarios_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text);

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);
            GuardarVariacionPatrimonialB();

        }

        private void TxtGastosRegistroLibroAccionistas_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text);

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);

            GuardarVariacionPatrimonialB();
        }

        private void TxtAuditoriadecuentas_TextInput(object sender, TextCompositionEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);

            GuardarVariacionPatrimonialB();
        }

        private void TxtOtros_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text.Replace(".","")) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);
            GuardarVariacionPatrimonialB();
        }

        private void TxtImpuestSobreSociedades_TextChanged(object sender, TextChangedEventArgs e)
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text.Replace(".", "")) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);
            GuardarVariacionPatrimonialB();
        }


        void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            e.Handled = new Regex("[^0-9.,-]+").IsMatch(e.Text);            
        }

        private void Calcular()
        {
            decimal TotalServiciosExteriores = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionDepositario.Text) ? "0" : TxtComisionDepositario.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastostasaRegOfi.Text) ? "0" : TxtGastostasaRegOfi.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosAdmiCotizaBolsa.Text) ? "0" : TxtGastosAdmiCotizaBolsa.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosdifperiodificaciones.Text) ? "0" : TxtGastosdifperiodificaciones.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosBancarios.Text) ? "0" : TxtGastosBancarios.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtGastosRegistroLibroAccionistas.Text) ? "0" : TxtGastosRegistroLibroAccionistas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtAuditoriadecuentas.Text.Replace(".", "")) ? "0" : TxtAuditoriadecuentas.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtOtros.Text) ? "0" : TxtOtros.Text.Replace(".", ""));

            decimal ComisionFija = Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagada.Text) ? "0" : TxtComisionFijaPagada.Text.Replace(".", "")) + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionFijaPagadaDevengada.Text) ? "0" : TxtComisionFijaPagadaDevengada.Text.Replace(".", ""));
            decimal ComisionGestion = ComisionFija + Convert.ToDecimal(string.IsNullOrEmpty(TxtComisionVariable.Text) ? "0" : TxtComisionVariable.Text.Replace(".", ""));
            decimal TotalGastosGestionCorriente = ComisionFija + TotalServiciosExteriores + Convert.ToDecimal(string.IsNullOrEmpty(TxtImpuestSobreSociedades.Text) ? "0" : TxtImpuestSobreSociedades.Text.Replace(".", ""));

            //TxtComisionFija.Text = ComisionFija.ToString();
            //TxtComisionGestion.Text = ComisionGestion.ToString();
            TxtTotalGastosGestionCorriente.Text = String.Format("{0:N2}", TotalGastosGestionCorriente);
            TxtTotalServiciosExteriores.Text = String.Format("{0:N2}", TotalServiciosExteriores);            
        }

        private void TxtAuditoriadecuentas_TextInput_1(object sender, TextCompositionEventArgs e)
        {

        }

        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            Calcular();
            GuardarVariacionPatrimonialB();
        }
    }
}
