using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{

    public class T_SuscripcionesReembolsos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    this.OnPropertyChanged("ID");
                }
            }
        }

        private string codigoIC;
        public string CodigoIC
        {
            get
            {
                return this.codigoIC;
            }
            set
            {
                if (value != this.codigoIC)
                {
                    this.codigoIC = value;
                    this.OnPropertyChanged("CodigoIC");
                }
            }
        }

        private string isin;
        public string Isin
        {
            get
            {
                return this.isin;
            }
            set
            {
                if (value != this.isin)
                {
                    this.isin = value;
                    this.OnPropertyChanged("Isin");
                }
            }
        }

        private Nullable<System.DateTime> fecha;
        public Nullable<System.DateTime> Fecha

        {
            get
            {
                return this.fecha;
            }
            set
            {
                if (value != this.fecha)
                {
                    this.fecha = value;
                    this.OnPropertyChanged("Fecha");
                }
            }
        }


        

        private string tipoMovimiento;
        public string TipoMovimiento
        {
            get
            {
                return this.tipoMovimiento;
            }
            set
            {
                if (value != this.tipoMovimiento)
                {
                    this.tipoMovimiento = value;
                    this.OnPropertyChanged("TipoMovimiento");
                }
            }
        }

        private Nullable<decimal> importe;
        public Nullable<decimal> Importe
        {
            get
            {
                return this.importe;
            }
            set
            {
                if (value != this.importe)
                {
                    this.importe = value;
                    this.OnPropertyChanged("ImporteNeto");
                }
            }
        }

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

    //Temp_SuscripcionesReembolsos
    class Report_SuscripcionesReembolsos_DA : INotifyPropertyChanged
    {
        public static ObservableCollection<T_SuscripcionesReembolsos> GetTemp_SuscripcionesReembolsos(string codigoIC, string isin, string tipoMov)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            if (!string.IsNullOrEmpty(isin))
            {

                ObservableCollection<T_SuscripcionesReembolsos> suscriReembolso = new ObservableCollection<T_SuscripcionesReembolsos>();

                foreach (var item in dbContext.Temp_SuscripcionesReembolsos.Where(r => r.CodigoIC == codigoIC && r.Isin == isin && r.TipoMovimiento== tipoMov))
                {
                    T_SuscripcionesReembolsos tmp_suscriReembolso = new T_SuscripcionesReembolsos();
                    tmp_suscriReembolso.Id = item.Id;
                    tmp_suscriReembolso.Fecha = item.Fecha;
                    tmp_suscriReembolso.CodigoIC = item.CodigoIC;
                    tmp_suscriReembolso.Isin = item.Isin;
                    tmp_suscriReembolso.TipoMovimiento = item.TipoMovimiento;
                    tmp_suscriReembolso.Importe = item.Importe;

                    suscriReembolso.Add(tmp_suscriReembolso);
                }
                return suscriReembolso;
            }
            else
            {

                ObservableCollection<T_SuscripcionesReembolsos> suscriReembolso = new ObservableCollection<T_SuscripcionesReembolsos>();

                foreach (var item in dbContext.Temp_SuscripcionesReembolsos.Where(r => r.CodigoIC == codigoIC && r.TipoMovimiento == tipoMov))
                {
                    T_SuscripcionesReembolsos tmp_suscriReembolso = new T_SuscripcionesReembolsos();
                    tmp_suscriReembolso.Id = item.Id;
                    tmp_suscriReembolso.Fecha = item.Fecha;
                    tmp_suscriReembolso.CodigoIC = item.CodigoIC;
                    tmp_suscriReembolso.Isin = item.Isin;
                    tmp_suscriReembolso.TipoMovimiento = item.TipoMovimiento;
                    tmp_suscriReembolso.Importe = item.Importe;

                    suscriReembolso.Add(tmp_suscriReembolso);
                }
                return suscriReembolso;
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
