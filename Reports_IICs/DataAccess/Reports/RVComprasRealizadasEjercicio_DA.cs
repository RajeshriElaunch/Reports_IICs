using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{

    public class T_RVComprasRealizadasEjercicio : INotifyPropertyChanged
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


        private string descripcionValor;
        public string DescripcionValor
        {
            get
            {
                return this.descripcionValor;
            }
            set
            {
                if (value != this.descripcionValor)
                {
                    this.descripcionValor = value;
                    this.OnPropertyChanged("DescripcionValor");
                }
            }
        }


        private decimal? cantidad;
        public decimal? Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                if (value != this.cantidad)
                {
                    this.cantidad = value;
                    this.OnPropertyChanged("Cantidad");
                }
            }
        }

        private decimal? precio;
        public decimal? Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value != this.precio)
                {
                    this.precio = value;
                    this.OnPropertyChanged("Precio");
                }
            }
        }

        private Nullable<decimal> dividendosCobrados;
        public Nullable<decimal> DividendosCobrados
        {
            get
            {
                return this.dividendosCobrados;
            }
            set
            {
                if (value != this.dividendosCobrados)
                {
                    this.dividendosCobrados = value;
                    this.OnPropertyChanged("DividendosCobrados");
                }
            }
        }

        private string cotizacionFechaFin;
        public string CotizacionFechaFin
        {
            get
            {
                return this.cotizacionFechaFin;
            }
            set
            {
                if (value != this.cotizacionFechaFin)
                {
                    this.cotizacionFechaFin = value;
                    this.OnPropertyChanged("CotizacionFechaFin");
                }
            }
        }

        private string variacion;
        public string Variacion
        {
            get
            {
                return this.variacion;
            }
            set
            {
                if (value != this.variacion)
                {
                    this.variacion = value;
                    this.OnPropertyChanged("Variacion");
                }
            }
        }


        private bool vendido;
        public bool Vendido
        {
            get
            {
                return this.vendido;
            }
            set
            {
                if (value != this.vendido)
                {
                    this.vendido = value;
                    this.OnPropertyChanged("Vendido");
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


    class RVComprasRealizadasEjercicio_DA : INotifyPropertyChanged
    {
        public static ObservableCollection<T_RVComprasRealizadasEjercicio> GetTemp_RVComprasRealizadasEjercicio(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            //if (!string.IsNullOrEmpty(isin))
            //{
            //    ObservableCollection<T_RVComprasRealizadasEjercicio> rvcompra = new ObservableCollection<T_RVComprasRealizadasEjercicio>();

            //    foreach (var item in dbContext.Temp_RVComprasRealizadasEjercicio.Where(r => r.CodigoIC == codigoIC && r.i))
            //    {
            //        T_RVComprasRealizadasEjercicio tmp_rvcompra = new T_RVComprasRealizadasEjercicio();
            //        tmp_rvcompra.Id = item.Id;
            //        tmp_rvcompra.Fecha = item.Fecha;
            //        tmp_rvcompra.CodigoIC = item.CodigoIC;
            //        tmp_rvcompra.Cantidad  = item.Cantidad;
            //        tmp_rvcompra.CotizacionFechaFin = item.CotizacionFechaFin;
            //        tmp_rvcompra.DescripcionValor = item.DescripcionValor;
            //        tmp_rvcompra.DividendosCobrados = item.DividendosCobrados;
            //        tmp_rvcompra.Precio = item.Precio;
            //        tmp_rvcompra.TipoMovimiento = item.TipoMovimiento;
            //        tmp_rvcompra.Vendido = item.Vendido;
                    
            //        rvcompra.Add(tmp_rvcompra);
            //    }
            //    return rvcompra;
            //}
            //else
            //{

                ObservableCollection<T_RVComprasRealizadasEjercicio> rvcompra = new ObservableCollection<T_RVComprasRealizadasEjercicio>();

                foreach (var item in dbContext.Temp_RVComprasRealizadasEjercicio.Where(r => r.CodigoIC == codigoIC))
                {
                    T_RVComprasRealizadasEjercicio tmp_rvcompra = new T_RVComprasRealizadasEjercicio();
                    tmp_rvcompra.Id = item.Id;
                    tmp_rvcompra.Fecha = item.Fecha;
                    tmp_rvcompra.CodigoIC = item.CodigoIC;
                    tmp_rvcompra.Cantidad = item.Cantidad;
                    tmp_rvcompra.CotizacionFechaFin = String.Format("{0:N2}", item.CotizacionFechaFin);
                    tmp_rvcompra.DescripcionValor = item.DescripcionValor;
                    tmp_rvcompra.DividendosCobrados = item.DividendosCobrados;
                    tmp_rvcompra.Precio = item.Precio;
                    tmp_rvcompra.TipoMovimiento = item.TipoMovimiento;
                    //tmp_rvcompra.Vendido = item.Vendido;

                    rvcompra.Add(tmp_rvcompra);
                }
                return rvcompra;
            //}
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
