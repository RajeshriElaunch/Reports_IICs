using System.ComponentModel;
using System.Linq;
using Reports_IICs.DataModels;
using System.Collections.ObjectModel;

namespace Reports_IICs.DataAccess.Reports
{
    class ReportDesgloseGastosDA : INotifyPropertyChanged
    {
        public static ObservableCollection<Temp_DesgloseGastos> GetTemp_VariacionPatrimonialB(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<Temp_DesgloseGastos> variapatrimonial = new ObservableCollection<Temp_DesgloseGastos>();

                foreach (var item in dbContext.Temp_DesgloseGastos.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                {
                    Temp_DesgloseGastos tmp_variapatrimonial = new Temp_DesgloseGastos();
                    tmp_variapatrimonial.Id = item.Id;
                    tmp_variapatrimonial.AuditoriaCuentas = item.AuditoriaCuentas;
                    tmp_variapatrimonial.CodigoIC = item.CodigoIC;
                    tmp_variapatrimonial.Isin = item.Isin;
                    tmp_variapatrimonial.ComDepositario = item.ComDepositario;
                    tmp_variapatrimonial.ComFijaDevengada = item.ComFijaDevengada;
                    tmp_variapatrimonial.ComFijaPagada = item.ComFijaPagada;
                    tmp_variapatrimonial.ComVariable = item.ComVariable;
                    tmp_variapatrimonial.GastosAdmisionCotizacionBolsa = item.GastosAdmisionCotizacionBolsa;
                    tmp_variapatrimonial.GastosBancarios = item.GastosBancarios;
                    tmp_variapatrimonial.GastosDiferenciaPeriodificaciones = item.GastosDiferenciaPeriodificaciones;
                    tmp_variapatrimonial.GastosRegistroLibroAccionistas = item.GastosRegistroLibroAccionistas;
                    tmp_variapatrimonial.GastosTasaRegistrosOficiales = item.GastosTasaRegistrosOficiales;
                    tmp_variapatrimonial.ImpuestoSobreSociedades = item.ImpuestoSobreSociedades;
                    tmp_variapatrimonial.Otros = item.Otros;
                    tmp_variapatrimonial.PatrimonioFechaInforme = item.PatrimonioFechaInforme;
                    variapatrimonial.Add(tmp_variapatrimonial);
                }
                return variapatrimonial;
            }
            else
            {

                ObservableCollection<Temp_DesgloseGastos> variapatrimonial = new ObservableCollection<Temp_DesgloseGastos>();

                foreach (var item in dbContext.Temp_DesgloseGastos.Where(r => r.CodigoIC == codigoIC))
                {
                    var tmp = new Temp_DesgloseGastos
                    {
                        Id = item.Id,
                        AuditoriaCuentas = item.AuditoriaCuentas,
                        CodigoIC = item.CodigoIC,
                        Isin = item.Isin,
                        ComDepositario = item.ComDepositario,
                        ComFijaDevengada = item.ComFijaDevengada,
                        ComFijaPagada = item.ComFijaPagada,
                        ComVariable = item.ComVariable,
                        GastosAdmisionCotizacionBolsa = item.GastosAdmisionCotizacionBolsa,
                        GastosBancarios = item.GastosBancarios,
                        GastosDiferenciaPeriodificaciones = item.GastosDiferenciaPeriodificaciones,
                        GastosRegistroLibroAccionistas = item.GastosRegistroLibroAccionistas,
                        GastosTasaRegistrosOficiales = item.GastosTasaRegistrosOficiales,
                        ImpuestoSobreSociedades = item.ImpuestoSobreSociedades,
                        Otros = item.Otros,
                        PatrimonioFechaInforme = item.PatrimonioFechaInforme
                    };
                    variapatrimonial.Add(tmp);

                   
                }
                return variapatrimonial;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
    }
}
