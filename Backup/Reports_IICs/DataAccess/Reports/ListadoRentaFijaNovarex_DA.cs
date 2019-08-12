using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Reports_IICs.DataModels;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_ListadoRentaFijaNovarex : INotifyPropertyChanged
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

        private string tituloDescripcion;
        public string TituloDescripcion
        {
            get
            {
                return this.tituloDescripcion;
            }
            set
            {
                if (value != this.tituloDescripcion)
                {
                    this.tituloDescripcion = value;
                    this.OnPropertyChanged("TituloDescripcion");
                }
            }
        }

        private DateTime? amortizacion;
        public DateTime? Amortizacion

        {
            get
            {
                return this.amortizacion;
            }
            set
            {
                if (value != this.amortizacion)
                {
                    this.amortizacion = value;
                    this.OnPropertyChanged("Amortizacion");
                }
            }
        }

        private decimal efectivoEuros;
        public decimal EfectivoEuros
        {
            get
            {
                return this.efectivoEuros;
            }
            set
            {
                if (value != this.efectivoEuros)
                {
                    this.efectivoEuros = value;
                    this.OnPropertyChanged("EfectivoEuros");
                }
            }
        }


        private decimal? tIR;
        public decimal? TIR
        {
            get
            {
                return this.tIR;
            }
            set
            {
                if (value != this.tIR)
                {
                    this.tIR = value;
                    this.OnPropertyChanged("TIR");
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
    class ListadoRentaFijaNovarex_DA : INotifyPropertyChanged
    {
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

        public static ObservableCollection<T_ListadoRentaFijaNovarex> GetTemp_ListadoRentaFijaNovarex(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            

                ObservableCollection<T_ListadoRentaFijaNovarex> rentListadoRFNovarex = new ObservableCollection<T_ListadoRentaFijaNovarex>();

                foreach (var item in dbContext.Temp_ListadoRentaFijaNovarex.Where(r => r.CodigoIC == codigoIC))
                {
                    T_ListadoRentaFijaNovarex tmp_rfnovarex = new T_ListadoRentaFijaNovarex();
                        tmp_rfnovarex.Id = item.Id;
                        tmp_rfnovarex.CodigoIC = item.CodigoIC;
                        
                        tmp_rfnovarex.Amortizacion = item.Amortizacion;
                        tmp_rfnovarex.EfectivoEuros = item.EfectivoEuros;
                        tmp_rfnovarex.TIR = item.TIR;
                        tmp_rfnovarex.TituloDescripcion = item.TituloDescripcion;


                rentListadoRFNovarex.Add(tmp_rfnovarex);
                }
                return rentListadoRFNovarex;
            
        }

        public static T_ListadoRentaFijaNovarex Get_Temp_ListadoRentaFijaNovarexById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            T_ListadoRentaFijaNovarex ListadoRFNovarex_temp = new T_ListadoRentaFijaNovarex();
            
            foreach (var item in dbContext.Temp_ListadoRentaFijaNovarex.Where(r => r.Id == id))
            {
                ListadoRFNovarex_temp.Id = item.Id;
                ListadoRFNovarex_temp.CodigoIC = item.CodigoIC;
                
                ListadoRFNovarex_temp.Amortizacion = item.Amortizacion;
                ListadoRFNovarex_temp.EfectivoEuros = item.EfectivoEuros;
                ListadoRFNovarex_temp.TIR = item.TIR;
                ListadoRFNovarex_temp.TituloDescripcion = item.TituloDescripcion;

            }

            return ListadoRFNovarex_temp;
        }

    }
}
