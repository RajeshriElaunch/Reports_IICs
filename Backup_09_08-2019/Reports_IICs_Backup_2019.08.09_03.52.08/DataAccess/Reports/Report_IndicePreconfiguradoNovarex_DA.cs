using System;
using System.Linq;
using System.ComponentModel;
using Reports_IICs.DataModels;
using System.Collections.ObjectModel;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_Temp_IndicePreconfiguradoNovarex : INotifyPropertyChanged
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

        private string descripcion;
        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                if (value != this.descripcion)
                {
                    this.descripcion = value;
                    this.OnPropertyChanged("Descripcion");
                }
            }
        }

        
        private decimal euros;
        public decimal Euros
        {
            get
            {
                return this.euros;
            }
            set
            {
                if (value != this.euros)
                {
                    this.euros = value;
                    this.OnPropertyChanged("Euros");
                }
            }
        }

       

        private decimal porcentaje;
        public decimal Porcentaje
        {
            get
            {
                return this.porcentaje;
            }
            set
            {
                if (value != this.porcentaje)
                {
                    this.porcentaje = value;
                    this.OnPropertyChanged("Porcentaje");
                }
            }
        }

     

        private decimal? indexNovarex;
        public decimal? IndexNovarex
        {
            get
            {
                return this.indexNovarex;
            }
            set
            {
                if (value != this.indexNovarex)
                {
                    this.indexNovarex = value;
                    this.OnPropertyChanged("IndexNovarex");
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

    class Report_IndicePreconfiguradoNovarex_DA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<T_Temp_IndicePreconfiguradoNovarex> GetTemp_IndicePreconfiguradoNovarex(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
           

                ObservableCollection<T_Temp_IndicePreconfiguradoNovarex> rentindicepre = new ObservableCollection<T_Temp_IndicePreconfiguradoNovarex>();

                foreach (var item in dbContext.Temp_IndicePreconfiguradoNovarex.Where(r => r.CodigoIC == codigoIC))
                {
                    T_Temp_IndicePreconfiguradoNovarex tmp_indice = new T_Temp_IndicePreconfiguradoNovarex();
                    tmp_indice.Id = item.Id;
                    tmp_indice.CodigoIC = item.CodigoIC;
                    tmp_indice.Descripcion = item.Descripcion;
                    tmp_indice.Euros = item.Euros;
                    tmp_indice.IndexNovarex = item.IndexNovarex;
                    tmp_indice.Porcentaje = Convert.ToDecimal(item.Porcentaje);

                    rentindicepre.Add(tmp_indice);
                }
                return rentindicepre;
            
        }

        public static T_Temp_IndicePreconfiguradoNovarex Get_Temp_IndicePreconfiguradoNovarexById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            T_Temp_IndicePreconfiguradoNovarex IndicePreconfiguradoNovarex_temp = new T_Temp_IndicePreconfiguradoNovarex();


            foreach (var item in dbContext.Temp_IndicePreconfiguradoNovarex.Where(r => r.Id == id))
            {
                IndicePreconfiguradoNovarex_temp.Id = item.Id;
                IndicePreconfiguradoNovarex_temp.CodigoIC = item.CodigoIC;
                IndicePreconfiguradoNovarex_temp.Descripcion  = item.Descripcion;
                IndicePreconfiguradoNovarex_temp.Euros = item.Euros;
                IndicePreconfiguradoNovarex_temp.IndexNovarex = item.IndexNovarex;
                IndicePreconfiguradoNovarex_temp.Porcentaje = Convert.ToDecimal(item.Porcentaje);

            }

            return IndicePreconfiguradoNovarex_temp;
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
}
