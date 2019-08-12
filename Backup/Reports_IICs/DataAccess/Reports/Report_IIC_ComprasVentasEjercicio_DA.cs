using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_IIC_ComprasVentasEjercicio : INotifyPropertyChanged
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

    
    class Report_IIC_ComprasVentasEjercicio_DA : INotifyPropertyChanged
    {
        public static ObservableCollection<T_IIC_ComprasVentasEjercicio> GetTemp_IIC_ComprasVentasEjercicio(string codigoIC, string isin, string tipoMov)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            if (!string.IsNullOrEmpty(isin))
            {

                ObservableCollection<T_IIC_ComprasVentasEjercicio> IIC_CompraVentaEjercicio = new ObservableCollection<T_IIC_ComprasVentasEjercicio>();

                foreach (var item in dbContext.Temp_IIC_ComprasVentasEjercicio.Where(r => r.CodigoIC == codigoIC && r.Isin == isin && r.TipoMovimiento == tipoMov))
                {
                    T_IIC_ComprasVentasEjercicio tmp_IIC_CompraVentaEjercicio = new T_IIC_ComprasVentasEjercicio();
                    tmp_IIC_CompraVentaEjercicio.Id = item.Id;
                    tmp_IIC_CompraVentaEjercicio.Fecha = item.Fecha;
                    tmp_IIC_CompraVentaEjercicio.CodigoIC = item.CodigoIC;
                    tmp_IIC_CompraVentaEjercicio.Isin = item.Isin;
                    tmp_IIC_CompraVentaEjercicio.TipoMovimiento = item.TipoMovimiento;
                    tmp_IIC_CompraVentaEjercicio.Cantidad = item.Cantidad;
                    tmp_IIC_CompraVentaEjercicio.Precio = item.Precio;
                    tmp_IIC_CompraVentaEjercicio.DescripcionValor = item.DescripcionValor;

                    IIC_CompraVentaEjercicio.Add(tmp_IIC_CompraVentaEjercicio);
                }
                return IIC_CompraVentaEjercicio;
            }
            else
            {

                ObservableCollection<T_IIC_ComprasVentasEjercicio> IIC_CompraVentaEjercicio = new ObservableCollection<T_IIC_ComprasVentasEjercicio>();

                foreach (var item in dbContext.Temp_IIC_ComprasVentasEjercicio.Where(r => r.CodigoIC == codigoIC && r.TipoMovimiento == tipoMov))
                {
                    T_IIC_ComprasVentasEjercicio tmp_IIC_CompraVentaEjercicio = new T_IIC_ComprasVentasEjercicio();
                    tmp_IIC_CompraVentaEjercicio.Id = item.Id;
                    tmp_IIC_CompraVentaEjercicio.Fecha = item.Fecha;
                    tmp_IIC_CompraVentaEjercicio.CodigoIC = item.CodigoIC;
                    tmp_IIC_CompraVentaEjercicio.Isin = item.Isin;
                    tmp_IIC_CompraVentaEjercicio.TipoMovimiento = item.TipoMovimiento;
                    tmp_IIC_CompraVentaEjercicio.Cantidad = item.Cantidad;
                    tmp_IIC_CompraVentaEjercicio.Precio = item.Precio;
                    tmp_IIC_CompraVentaEjercicio.DescripcionValor = item.DescripcionValor;

                    IIC_CompraVentaEjercicio.Add(tmp_IIC_CompraVentaEjercicio);
                }
                return IIC_CompraVentaEjercicio;
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
