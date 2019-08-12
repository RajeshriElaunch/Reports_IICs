using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Reports_IICs.DataModels;



namespace Reports_IICs.DataAccess.Reports
{

    public class T_EvolucionPatrimonioConjuntoGuissona : INotifyPropertyChanged
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

        private decimal? patrimonio;
        public decimal?  Patrimonio
        {
            get
            {
                return this.patrimonio;
            }
            set
            {
                if (value != this.patrimonio)
                {
                    this.patrimonio = value;
                    this.OnPropertyChanged("Patrimonio");
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

    class EvolucionPatrimonioConjuntoGuissona : INotifyPropertyChanged
    {
        public static ObservableCollection<T_EvolucionPatrimonioConjuntoGuissona> GetTemp_EvolucionPatrimonioConjuntoGuissona(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<T_EvolucionPatrimonioConjuntoGuissona> rentcartera = new ObservableCollection<T_EvolucionPatrimonioConjuntoGuissona>();

                foreach (var item in dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.Where(r => r.CodigoIC == codigoIC && r.IsinFondo == isin))
                {
                    T_EvolucionPatrimonioConjuntoGuissona tmp_evopatri = new T_EvolucionPatrimonioConjuntoGuissona();
                    tmp_evopatri.Id = item.Id;
                    tmp_evopatri.Fecha = item.Fecha;
                    tmp_evopatri.CodigoIC = item.CodigoIC;
                    tmp_evopatri.IsinFondo = item.IsinFondo;
                    tmp_evopatri.Patrimonio = Convert.ToDecimal(item.Patrimonio);


                    rentcartera.Add(tmp_evopatri);
                }
                return rentcartera;
            }
            else
            {

                ObservableCollection<T_EvolucionPatrimonioConjuntoGuissona> rentcartera = new ObservableCollection<T_EvolucionPatrimonioConjuntoGuissona>();

                foreach (var item in dbContext.Temp_EvolucionPatrimonioConjuntoGuissona.Where(r => r.CodigoIC == codigoIC))
                {
                    T_EvolucionPatrimonioConjuntoGuissona tmp_rentcartera = new T_EvolucionPatrimonioConjuntoGuissona();
                    tmp_rentcartera.Id = item.Id;
                    tmp_rentcartera.Fecha = item.Fecha;
                    tmp_rentcartera.CodigoIC = item.CodigoIC;
                    tmp_rentcartera.IsinFondo = item.IsinFondo;
                    tmp_rentcartera.Patrimonio = Convert.ToDecimal(item.Patrimonio);


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
