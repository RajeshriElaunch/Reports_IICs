using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{

    public class T_CuponesCobrados : INotifyPropertyChanged
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


        private Nullable<decimal> importeNeto;
        public Nullable<decimal> ImporteNeto
        {
            get
            {
                return this.importeNeto;
            }
            set
            {
                if (value != this.importeNeto)
                {
                    this.importeNeto = value;
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

    class ReportCuponesCobrados_DA : INotifyPropertyChanged
    {

        public static ObservableCollection<T_CuponesCobrados> GetTemp_CuponesCobrados(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            if (!string.IsNullOrEmpty(isin))
            {

                ObservableCollection<T_CuponesCobrados> diviCobrado = new ObservableCollection<T_CuponesCobrados>();

                foreach (var item in dbContext.Temp_CuponesCobrados.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                {
                    T_CuponesCobrados tmp_diviCobrado = new T_CuponesCobrados();
                    tmp_diviCobrado.Id = item.Id;
                    tmp_diviCobrado.Fecha = item.Fecha;
                    tmp_diviCobrado.CodigoIC = item.CodigoIC;
                    tmp_diviCobrado.ImporteNeto = item.ImporteNeto;
                    tmp_diviCobrado.DescripcionValor = item.NombreValor;

                    diviCobrado.Add(tmp_diviCobrado);
                }
                return diviCobrado;
            }
            else
            {

                ObservableCollection<T_CuponesCobrados> diviCobrado = new ObservableCollection<T_CuponesCobrados>();

                foreach (var item in dbContext.Temp_CuponesCobrados.Where(r => r.CodigoIC == codigoIC))
                {
                    T_CuponesCobrados tmp_diviCobrado = new T_CuponesCobrados();
                    tmp_diviCobrado.Id = item.Id;
                    tmp_diviCobrado.Fecha = item.Fecha;
                    tmp_diviCobrado.CodigoIC = item.CodigoIC;
                    tmp_diviCobrado.ImporteNeto = item.ImporteNeto;
                    tmp_diviCobrado.DescripcionValor = item.NombreValor;

                    diviCobrado.Add(tmp_diviCobrado);
                }
                return diviCobrado;
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
