using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_DividendosCobrados : INotifyPropertyChanged
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
        

       

        
        private Nullable<decimal> importeBruto;
        public Nullable<decimal> ImporteBruto
        {
            get
            {
                return this.importeBruto;
            }
            set
            {
                if (value != this.importeBruto)
                {
                    this.importeBruto = value;
                    this.OnPropertyChanged("ImporteBruto");
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

    class DividendosCobrados_DA : INotifyPropertyChanged
    {
        public static void UpdateFechaUltimaReunion(string codigoIC, DateTime fecha)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            dbContext = new Reports_IICSEntities();
            var obj = dbContext.Parametros_DividendosCobrados.Where(w => w.CodigoIC == codigoIC).FirstOrDefault();

            //UPDATE
            if(obj == null)
            {
                obj = new Parametros_DividendosCobrados();
            }

            obj.CodigoIC = codigoIC;
            obj.FechaUltimaReunion = fecha;

            dbContext.SaveChanges();
        }

        public static ObservableCollection<T_DividendosCobrados> GetTemp_DividendosCobrados(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            if (!string.IsNullOrEmpty(isin))
            {
                
                ObservableCollection<T_DividendosCobrados> diviCobrado = new ObservableCollection<T_DividendosCobrados>();

                foreach (var item in dbContext.Temp_DividendosCobrados.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                {
                    T_DividendosCobrados tmp_diviCobrado = new T_DividendosCobrados();
                    tmp_diviCobrado.Id = item.Id;
                    tmp_diviCobrado.Fecha = item.Fecha;
                    tmp_diviCobrado.CodigoIC = item.CodigoIC;
                    tmp_diviCobrado.ImporteBruto = item.ImporteBruto;
                    tmp_diviCobrado.DescripcionValor = item.NombreValor;

                    diviCobrado.Add(tmp_diviCobrado);
                }
                return diviCobrado;
            }
            else
            {

            ObservableCollection<T_DividendosCobrados> diviCobrado = new ObservableCollection<T_DividendosCobrados>();

            foreach (var item in dbContext.Temp_DividendosCobrados.Where(r => r.CodigoIC == codigoIC))
            {
                T_DividendosCobrados tmp_diviCobrado = new T_DividendosCobrados();
                tmp_diviCobrado.Id = item.Id;
                tmp_diviCobrado.Fecha = item.Fecha;
                tmp_diviCobrado.CodigoIC = item.CodigoIC;
                tmp_diviCobrado.ImporteBruto = item.ImporteBruto;
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

        public static decimal GetTotalDividendosBrutos(string codigoIC)
        {
            decimal output = 0;

            var dbContext = new Reports_IICSEntities();
            var total = dbContext.Temp_DividendosCobrados.Where(w => w.CodigoIC == codigoIC).Sum(s => s.ImporteBruto);

            if (total != null)
                output = (decimal)total;

            return output;
        }
    }
}
