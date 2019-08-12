using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_RentabilidadCarteraGuissona : INotifyPropertyChanged
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

        private string isinFondo;
        public string IsinFondo
        {
            get
            {
                return this.isinFondo;
            }
            set
            {
                if (value != this.isinFondo)
                {
                    this.isinFondo = value;
                    this.OnPropertyChanged("IsinFondo");
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

        private decimal? porcentajeRentabilidad;
        public decimal? PorcentajeRentabilidad
        {
            get
            {
                return this.porcentajeRentabilidad;
            }
            set
            {
                if (value != this.porcentajeRentabilidad)
                {
                    this.porcentajeRentabilidad = value;
                    this.OnPropertyChanged("PorcentajeRentabilidad");
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
    class RentabilidadCarteraGuissona_DA : INotifyPropertyChanged
    {

        public static ObservableCollection<T_RentabilidadCarteraGuissona> GetTemp_RentabilidadCarteraGuissona(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<T_RentabilidadCarteraGuissona> rentcartera = new ObservableCollection<T_RentabilidadCarteraGuissona>();

                foreach (var item in dbContext.Temp_EvolucionRentabilidadGuissona.Where(r => r.CodigoIC == codigoIC && r.IsinFondo == isin))
                {
                    T_RentabilidadCarteraGuissona tmp_rentcartera = new T_RentabilidadCarteraGuissona();
                    tmp_rentcartera.Id = item.Id;
                    tmp_rentcartera.Fecha = item.Fecha;
                    tmp_rentcartera.CodigoIC = item.CodigoIC;
                    tmp_rentcartera.IsinFondo = item.IsinFondo;
                    tmp_rentcartera.PorcentajeRentabilidad = Convert.ToDecimal(item.PorcentajeRentabilidad);


                    rentcartera.Add(tmp_rentcartera);
                }
                return rentcartera;
            }
            else
            {

                ObservableCollection<T_RentabilidadCarteraGuissona> rentcartera = new ObservableCollection<T_RentabilidadCarteraGuissona>();

                foreach (var item in dbContext.Temp_EvolucionRentabilidadGuissona.Where(r => r.CodigoIC == codigoIC))
                {
                    T_RentabilidadCarteraGuissona tmp_rentcartera = new T_RentabilidadCarteraGuissona();
                    tmp_rentcartera.Id = item.Id;
                    tmp_rentcartera.Fecha = item.Fecha;
                    tmp_rentcartera.CodigoIC = item.CodigoIC;
                    tmp_rentcartera.IsinFondo = item.IsinFondo;
                    tmp_rentcartera.PorcentajeRentabilidad = Convert.ToDecimal(item.PorcentajeRentabilidad);
                    

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
