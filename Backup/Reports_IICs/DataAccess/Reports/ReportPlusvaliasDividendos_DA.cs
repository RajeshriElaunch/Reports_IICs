using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{

    public class T_PlusvaliasDividendos : INotifyPropertyChanged
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

       

        private string nombreValor;
        public string NombreValor
        {
            get
            {
                return this.nombreValor;
            }
            set
            {
                if (value != this.nombreValor)
                {
                    this.nombreValor = value;
                    this.OnPropertyChanged("NombreValor");
                }
            }
        }


        private Nullable<decimal> plusvaliasMinusvalias;
        public Nullable<decimal> PlusvaliasMinusvalias
        {
            get
            {
                return this.plusvaliasMinusvalias;
            }
            set
            {
                if (value != this.plusvaliasMinusvalias)
                {
                    this.plusvaliasMinusvalias = value;
                    this.OnPropertyChanged("PlusvaliasMinusvalias");
                }
            }
        }


        
        private Nullable<decimal> dividendosNetos;
        public Nullable<decimal> DividendosNetos
        {
            get
            {
                return this.dividendosNetos;
            }
            set
            {
                if (value != this.dividendosNetos)
                {
                    this.dividendosNetos = value;
                    this.OnPropertyChanged("DividendosNetos");
                }
            }
        }



        private Nullable<decimal> total;
        public Nullable<decimal> Total
        {
            get
            {
                return this.total;
            }
            set
            {
                if (value != this.total)
                {
                    this.total = value;
                    this.OnPropertyChanged("Total");
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
    class ReportPlusvaliasDividendos_DA
    {
        public static ObservableCollection<T_PlusvaliasDividendos> GetTemp_PlusvaliasDividendos(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            if (!string.IsNullOrEmpty(isin))
            {

                ObservableCollection<T_PlusvaliasDividendos> plusvaliasDividendo = new ObservableCollection<T_PlusvaliasDividendos>();

                //foreach (var item in dbContext.Temp_PlusvaliasDividendos.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                foreach (var item in dbContext.Temp_PlusvaliasDividendos.Where(r => r.CodigoIC == codigoIC))
                {
                    T_PlusvaliasDividendos tmp_plusvaliasDividendo = new T_PlusvaliasDividendos();
                    tmp_plusvaliasDividendo.Id = item.Id;

                    tmp_plusvaliasDividendo.CodigoIC = item.CodigoIC;
                    tmp_plusvaliasDividendo.DividendosNetos = item.DividendosNetos;
                    tmp_plusvaliasDividendo.NombreValor = item.NombreValor;
                    tmp_plusvaliasDividendo.PlusvaliasMinusvalias = item.PlusvaliasMinusvalias;
                    tmp_plusvaliasDividendo.Total = item.DividendosNetos+ item.PlusvaliasMinusvalias;

                    plusvaliasDividendo.Add(tmp_plusvaliasDividendo);
                }
                return plusvaliasDividendo;
            }
            else
            {

                ObservableCollection<T_PlusvaliasDividendos> plusvaliasDividendo = new ObservableCollection<T_PlusvaliasDividendos>();

                foreach (var item in dbContext.Temp_PlusvaliasDividendos.Where(r => r.CodigoIC == codigoIC))
                {
                    T_PlusvaliasDividendos tmp_plusvaliasDividendo = new T_PlusvaliasDividendos();
                    tmp_plusvaliasDividendo.Id = item.Id;
                    tmp_plusvaliasDividendo.CodigoIC = item.CodigoIC;
                    tmp_plusvaliasDividendo.DividendosNetos = item.DividendosNetos;
                    tmp_plusvaliasDividendo.NombreValor = item.NombreValor;
                    tmp_plusvaliasDividendo.PlusvaliasMinusvalias = item.PlusvaliasMinusvalias;
                    tmp_plusvaliasDividendo.Total = ((item.DividendosNetos==null)?0:item.DividendosNetos) + ((item.PlusvaliasMinusvalias==null)?0: item.PlusvaliasMinusvalias);


                    plusvaliasDividendo.Add(tmp_plusvaliasDividendo);
                }
                return plusvaliasDividendo;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="tipoMov"></param>
        public static void UpdateWithSecc13(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            var obj = dbContext.Temp_RentaVariable.Where(r => r.CodigoIC == codigoIC 
                                                        && r.Isin.ToUpper() == isin.ToUpper());

            if(obj != null)
            {

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
