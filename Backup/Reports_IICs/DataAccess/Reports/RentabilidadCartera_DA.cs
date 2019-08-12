using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public  class T_RentabilidadCarteraV1 : INotifyPropertyChanged
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

        private System.DateTime fecha;
        public System.DateTime Fecha

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

        private decimal valorLiquidativo;
        public decimal ValorLiquidativo
        {
            get
            {
                return this.valorLiquidativo;
            }
            set
            {
                if (value != this.valorLiquidativo)
                {
                    this.valorLiquidativo = value;
                    this.OnPropertyChanged("ValorLiquidativo");
                }
            }
        }
        private Nullable<decimal> rentabilidadPeriodo;
        public Nullable<decimal> RentabilidadPeriodo
        {
            get
            {
                return this.rentabilidadPeriodo;
            }
            set
            {
                if (value != this.rentabilidadPeriodo)
                {
                    this.rentabilidadPeriodo = value;
                    this.OnPropertyChanged("RentabilidadPeriodo");
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

    public class T_RentabilidadCarteraV2 : INotifyPropertyChanged
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

        private string descripcionIndice;
        public string DescripcionIndice
        {
            get
            {
                return this.descripcionIndice;
            }
            set
            {
                if (value != this.descripcionIndice)
                {
                    this.descripcionIndice = value;
                    this.OnPropertyChanged("DescripcionIndice");
                }
            }
        }

        private System.DateTime fecha;
        public System.DateTime Fecha

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

        private decimal valorLiquidativo;
        public decimal ValorLiquidativo
        {
            get
            {
                return this.valorLiquidativo;
            }
            set
            {
                if (value != this.valorLiquidativo)
                {
                    this.valorLiquidativo = value;
                    this.OnPropertyChanged("ValorLiquidativo");
                }
            }
        }
        private Nullable<decimal> rentabilidadPeriodo;
        public Nullable<decimal> RentabilidadPeriodo
        {
            get
            {
                return this.rentabilidadPeriodo;
            }
            set
            {
                if (value != this.rentabilidadPeriodo)
                {
                    this.rentabilidadPeriodo = value;
                    this.OnPropertyChanged("RentabilidadPeriodo");
                }
            }
        }

        private Nullable<Boolean> esIndice;
        public Nullable<Boolean> EsIndice
        {
            get
            {
                return this.esIndice;
            }
            set
            {
                if (value != this.esIndice)
                {
                    this.esIndice = value;
                    this.OnPropertyChanged("EsIndice");
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
    public class RentabilidadCartera_DA : INotifyPropertyChanged
    {
       
        public static ObservableCollection<T_RentabilidadCarteraV1> GetTemp_RentabilidadCarteraV1(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<T_RentabilidadCarteraV1> rentcartera = new ObservableCollection<T_RentabilidadCarteraV1>();

                foreach (var item in dbContext.Temp_RentabilidadCarteraV1.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                {
                    T_RentabilidadCarteraV1 tmp_rentcartera = new T_RentabilidadCarteraV1();
                    tmp_rentcartera.Id = item.Id;
                    tmp_rentcartera.Fecha = item.Fecha;
                    tmp_rentcartera.CodigoIC = item.CodigoIC;
                    tmp_rentcartera.Isin = item.Isin;
                    tmp_rentcartera.ValorLiquidativo = item.ValorLiquidativo;
                    tmp_rentcartera.RentabilidadPeriodo = item.RentabilidadPeriodo;



                    rentcartera.Add(tmp_rentcartera);
                }
                return rentcartera;
            }
            else
            {
               
                ObservableCollection<T_RentabilidadCarteraV1> rentcartera = new ObservableCollection<T_RentabilidadCarteraV1>();

                foreach (var item in dbContext.Temp_RentabilidadCarteraV1.Where(r => r.CodigoIC == codigoIC))
                {
                    T_RentabilidadCarteraV1 tmp_rentcartera = new T_RentabilidadCarteraV1();
                    tmp_rentcartera.Id = item.Id;
                    tmp_rentcartera.Fecha = item.Fecha;
                    tmp_rentcartera.CodigoIC = item.CodigoIC;
                    tmp_rentcartera.Isin = item.Isin;
                    tmp_rentcartera.ValorLiquidativo = item.ValorLiquidativo;
                    tmp_rentcartera.RentabilidadPeriodo = item.RentabilidadPeriodo;



                    rentcartera.Add(tmp_rentcartera);
                }
                return rentcartera;
            }
        }

        public static ObservableCollection<T_RentabilidadCarteraV2> GetTemp_RentabilidadCarteraV2(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<T_RentabilidadCarteraV2> rentcartera = new ObservableCollection<T_RentabilidadCarteraV2>();

                foreach (var item in dbContext.Temp_RentabilidadCarteraV2.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                {
                    T_RentabilidadCarteraV2 tmp_rentcartera = new T_RentabilidadCarteraV2();
                    tmp_rentcartera.Id = item.Id;
                    tmp_rentcartera.Fecha = item.Fecha;
                    tmp_rentcartera.CodigoIC = item.CodigoIC;
                    tmp_rentcartera.Isin = item.Isin;
                    tmp_rentcartera.ValorLiquidativo = item.ValorLiquidativo;
                    tmp_rentcartera.RentabilidadPeriodo = item.RentabilidadPeriodo;
                    tmp_rentcartera.DescripcionIndice = item.DescripcionIndice;
                    tmp_rentcartera.EsIndice = item.EsIndice;

                    rentcartera.Add(tmp_rentcartera);
                }
                return rentcartera;
            }
            else
            {

                ObservableCollection<T_RentabilidadCarteraV2> rentcartera = new ObservableCollection<T_RentabilidadCarteraV2>();

                foreach (var item in dbContext.Temp_RentabilidadCarteraV2.Where(r => r.CodigoIC == codigoIC))
                {
                    T_RentabilidadCarteraV2 tmp_rentcartera = new T_RentabilidadCarteraV2();
                    tmp_rentcartera.Id = item.Id;
                    tmp_rentcartera.Fecha = item.Fecha;
                    tmp_rentcartera.CodigoIC = item.CodigoIC;
                    tmp_rentcartera.Isin = item.Isin;
                    tmp_rentcartera.ValorLiquidativo = item.ValorLiquidativo;
                    tmp_rentcartera.RentabilidadPeriodo = item.RentabilidadPeriodo;
                    tmp_rentcartera.DescripcionIndice = item.DescripcionIndice;
                    tmp_rentcartera.EsIndice = item.EsIndice;


                    rentcartera.Add(tmp_rentcartera);
                }
                return rentcartera;
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
