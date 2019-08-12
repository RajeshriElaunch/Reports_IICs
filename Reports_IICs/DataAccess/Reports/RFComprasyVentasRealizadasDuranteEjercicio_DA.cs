using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{


    class T_RFComprasyVentasRealizadasEjercicio : INotifyPropertyChanged
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

        private bool esCompra;
        public bool EsCompra
        {
            get
            {
                return this.esCompra;
            }
            set
            {
                if (value != this.esCompra)
                {
                    this.esCompra = value;
                    this.OnPropertyChanged("EsCompra");
                }
            }
        }

        private bool visto;
        public bool Visto
        {
            get
            {
                return this.visto;
            }
            set
            {
                if (value != this.visto)
                {
                    this.visto = value;
                    this.OnPropertyChanged("Visto");
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

    class RFComprasyVentasRealizadasDuranteEjercicio_DA : INotifyPropertyChanged
    {
        public static ObservableCollection<T_RFComprasyVentasRealizadasEjercicio> GetTemp_RFComprasyVentasRealizadasEjercicio(string codigoIC, string isin,bool Escompra)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            
            ObservableCollection<T_RFComprasyVentasRealizadasEjercicio> rfcompra = new ObservableCollection<T_RFComprasyVentasRealizadasEjercicio>();

            foreach (var item in dbContext.Temp_RFComprasVentasEjercicio.Where(r => r.CodigoIC == codigoIC && r.EsCompra==Escompra))
            {
                T_RFComprasyVentasRealizadasEjercicio tmp_rfcompra = new T_RFComprasyVentasRealizadasEjercicio();
                tmp_rfcompra.Id = item.Id;
                tmp_rfcompra.Fecha = item.Fecha;
                tmp_rfcompra.CodigoIC = item.CodigoIC;
                tmp_rfcompra.Cantidad = item.Cantidad;
                
                tmp_rfcompra.DescripcionValor = item.DescripcionValor;
               
                tmp_rfcompra.Precio = item.Precio;
                tmp_rfcompra.TipoMovimiento = item.TipoMovimiento;
                tmp_rfcompra.EsCompra = item.EsCompra;
                tmp_rfcompra.Visto = item.Visto;

                rfcompra.Add(tmp_rfcompra);
            }
            return rfcompra;
           
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
