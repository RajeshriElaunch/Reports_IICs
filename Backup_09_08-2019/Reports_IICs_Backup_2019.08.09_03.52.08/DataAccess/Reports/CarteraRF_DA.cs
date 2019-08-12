using System;
using System.Linq;
using System.ComponentModel;
using Reports_IICs.DataModels;
using System.Collections.ObjectModel;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_Temp_CarteraRF : INotifyPropertyChanged
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

        private string valor;
        public string Valor
        {
            get
            {
                return this.valor;
            }
            set
            {
                if (value != this.valor)
                {
                    this.valor = value;
                    this.OnPropertyChanged("Valor");
                }
            }
        }


        private string divisa;
        public string Divisa
        {
            get
            {
                return this.divisa;
            }
            set
            {
                if (value != this.divisa)
                {
                    this.divisa = value;
                    this.OnPropertyChanged("Divisa");
                }
            }
        }

        private int? dias;
        public int? Dias
        {
            get
            {
                return this.dias;
            }
            set
            {
                if (value != this.dias)
                {
                    this.dias = value;
                    this.OnPropertyChanged("Dias");
                }
            }
        }

        private DateTime? vencimiento;
        public DateTime? Vencimiento

        {
            get
            {
                return this.vencimiento;
            }
            set
            {
                if (value != this.vencimiento)
                {
                    this.vencimiento = value;
                    this.OnPropertyChanged("Vencimiento");
                }
            }
        }

        private decimal nominal;
        public decimal Nominal
        {
            get
            {
                return this.nominal;
            }
            set
            {
                if (value != this.nominal)
                {
                    this.nominal = value;
                    this.OnPropertyChanged("Nominal");
                }
            }
        }


        private decimal efectivoCompra;
        public decimal EfectivoCompra
        {
            get
            {
                return this.efectivoCompra;
            }
            set
            {
                if (value != this.efectivoCompra)
                {
                    this.efectivoCompra = value;
                    this.OnPropertyChanged("EfectivoCompra");
                }
            }
        }

        private decimal tirCompra;
        public decimal TirCompra
        {
            get
            {
                return this.tirCompra;
            }
            set
            {
                if (value != this.tirCompra)
                {
                    this.tirCompra = value;
                    this.OnPropertyChanged("TirCompra");
                }
            }
        }

        private decimal tirMercado;
        public decimal TirMercado
        {
            get
            {
                return this.tirMercado;
            }
            set
            {
                if (value != this.tirMercado)
                {
                    this.tirMercado = value;
                    this.OnPropertyChanged("TirMercado");
                }
            }
        }


        private decimal intereses;
        public decimal Intereses
        {
            get
            {
                return this.intereses;
            }
            set
            {
                if (value != this.intereses)
                {
                    this.intereses = value;
                    this.OnPropertyChanged("Intereses");
                }
            }
        }


        private decimal? minusvalias;
        public decimal? Minusvalias
        {
            get
            {
                return this.minusvalias;
            }
            set
            {
                if (value != this.minusvalias)
                {
                    this.minusvalias = value;
                    this.OnPropertyChanged("Minusvalias");
                }
            }
        }

        private decimal? plusvalias;
        public decimal? Plusvalias
        {
            get
            {
                return this.plusvalias;
            }
            set
            {
                if (value != this.plusvalias)
                {
                    this.plusvalias = value;
                    this.OnPropertyChanged("Plusvalias");
                }
            }
        }


        private decimal efectivoActual;
        public decimal EfectivoActual
        {
            get
            {
                return this.efectivoActual;
            }
            set
            {
                if (value != this.efectivoActual)
                {
                    this.efectivoActual = value;
                    this.OnPropertyChanged("EfectivoActual");
                }
            }
        }

        private decimal? porcentajePat;
        public decimal? PorcentajePat
        {
            get
            {
                return this.porcentajePat;
            }
            set
            {
                if (value != this.porcentajePat)
                {
                    this.porcentajePat = value;
                    this.OnPropertyChanged("PorcentajePat");
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
    class CarteraRF_DA : INotifyPropertyChanged
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


        public static ObservableCollection<T_Temp_CarteraRF> GetTemp_CarteraRF(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();


            ObservableCollection<T_Temp_CarteraRF> rentemp_CarteraRF = new ObservableCollection<T_Temp_CarteraRF>();

            foreach (var item in dbContext.Temp_CarteraRF.Where(r => r.CodigoIC == codigoIC))
            {
                T_Temp_CarteraRF tmp_carteraRF = new T_Temp_CarteraRF();
                tmp_carteraRF.Id = item.Id;
                tmp_carteraRF.CodigoIC = item.CodigoIC;

                tmp_carteraRF.Dias = item.Dias;
                tmp_carteraRF.Divisa = item.Divisa;
                tmp_carteraRF.EfectivoActual = item.EfectivoActual;
                tmp_carteraRF.EfectivoCompra = item.EfectivoCompra;
                tmp_carteraRF.Intereses = item.Intereses;
                tmp_carteraRF.Nominal = item.Nominal;
                tmp_carteraRF.Plusvalias = (item.PlusvaliasMinusvalias>0)?item.PlusvaliasMinusvalias:0;
                tmp_carteraRF.Minusvalias = (item.PlusvaliasMinusvalias<0)?item.PlusvaliasMinusvalias*-1:0;
                tmp_carteraRF.PorcentajePat = item.PorcentajePat;
                tmp_carteraRF.TirCompra = item.TirCompra;
                tmp_carteraRF.TirMercado = item.TirMercado;
                tmp_carteraRF.Valor = item.Valor;
                tmp_carteraRF.Vencimiento = item.Vencimiento;
                
                rentemp_CarteraRF.Add(tmp_carteraRF);
            }
            return rentemp_CarteraRF;

        }

        public static ObservableCollection<T_Temp_CarteraRF> GetTemp_CarteraRFLPLAZO(string codigoIC, DateTime FechaReport)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();


            ObservableCollection<T_Temp_CarteraRF> rentemp_CarteraRF = new ObservableCollection<T_Temp_CarteraRF>();

            foreach (var item in dbContext.Temp_CarteraRF.Where(r => r.CodigoIC == codigoIC ))
            {
                if((item.Vencimiento != null && (item.Vencimiento.Value.Year - FechaReport.Year) > 1))
                {
                    T_Temp_CarteraRF tmp_carteraRF = new T_Temp_CarteraRF();
                    tmp_carteraRF.Id = item.Id;
                    tmp_carteraRF.CodigoIC = item.CodigoIC;

                    tmp_carteraRF.Dias = item.Dias;
                    tmp_carteraRF.Divisa = item.Divisa;
                    tmp_carteraRF.EfectivoActual = item.EfectivoActual;
                    tmp_carteraRF.EfectivoCompra = item.EfectivoCompra;
                    tmp_carteraRF.Intereses = item.Intereses;
                    tmp_carteraRF.Nominal = item.Nominal;
                    tmp_carteraRF.Plusvalias = (item.PlusvaliasMinusvalias > 0) ? item.PlusvaliasMinusvalias : 0;
                    tmp_carteraRF.Minusvalias = (item.PlusvaliasMinusvalias < 0) ? item.PlusvaliasMinusvalias * -1 : 0;
                    tmp_carteraRF.PorcentajePat = item.PorcentajePat;
                    tmp_carteraRF.TirCompra = item.TirCompra;
                    tmp_carteraRF.TirMercado = item.TirMercado;
                    tmp_carteraRF.Valor = item.Valor;
                    tmp_carteraRF.Vencimiento = item.Vencimiento;

                    rentemp_CarteraRF.Add(tmp_carteraRF);
                }
               
            }
            return rentemp_CarteraRF;

        }

        public static ObservableCollection<T_Temp_CarteraRF> GetTemp_CarteraRFCPLAZO(string codigoIC, DateTime FechaReport)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();


            ObservableCollection<T_Temp_CarteraRF> rentemp_CarteraRF = new ObservableCollection<T_Temp_CarteraRF>();

            foreach (var item in dbContext.Temp_CarteraRF.Where(r => r.CodigoIC == codigoIC))
            {
                if  (item.Vencimiento!=null && (item.Vencimiento.Value.Year == FechaReport.Year || (item.Vencimiento.Value.Year - FechaReport.Year ) == 1))
                {
                    T_Temp_CarteraRF tmp_carteraRF = new T_Temp_CarteraRF();
                    tmp_carteraRF.Id = item.Id;
                    tmp_carteraRF.CodigoIC = item.CodigoIC;

                    tmp_carteraRF.Dias = item.Dias;
                    tmp_carteraRF.Divisa = item.Divisa;
                    tmp_carteraRF.EfectivoActual = item.EfectivoActual;
                    tmp_carteraRF.EfectivoCompra = item.EfectivoCompra;
                    tmp_carteraRF.Intereses = item.Intereses;
                    tmp_carteraRF.Nominal = item.Nominal;
                    tmp_carteraRF.Plusvalias = (item.PlusvaliasMinusvalias > 0) ? item.PlusvaliasMinusvalias : 0;
                    tmp_carteraRF.Minusvalias = (item.PlusvaliasMinusvalias < 0) ? item.PlusvaliasMinusvalias * -1 : 0;
                    tmp_carteraRF.PorcentajePat = item.PorcentajePat;
                    tmp_carteraRF.TirCompra = item.TirCompra;
                    tmp_carteraRF.TirMercado = item.TirMercado;
                    tmp_carteraRF.Valor = item.Valor;
                    tmp_carteraRF.Vencimiento = item.Vencimiento;

                    rentemp_CarteraRF.Add(tmp_carteraRF);
                }
               
            }
            return rentemp_CarteraRF;

        }


        public static T_Temp_CarteraRF Get_Temp_CarteraRFById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            T_Temp_CarteraRF CarteraRF_temp = new T_Temp_CarteraRF();

            foreach (var item in dbContext.Temp_CarteraRF.Where(r => r.Id == id))
            {
                CarteraRF_temp.Id = item.Id;
                CarteraRF_temp.CodigoIC = item.CodigoIC;

                CarteraRF_temp.Dias = item.Dias;
                CarteraRF_temp.Divisa = item.Divisa;
                CarteraRF_temp.EfectivoActual = item.EfectivoActual;
                CarteraRF_temp.EfectivoCompra = item.EfectivoCompra;
                CarteraRF_temp.Intereses = item.Intereses;
                CarteraRF_temp.Nominal = item.Nominal;
                CarteraRF_temp.Plusvalias = (item.PlusvaliasMinusvalias > 0) ? item.PlusvaliasMinusvalias : 0;
                CarteraRF_temp.Minusvalias = (item.PlusvaliasMinusvalias < 0) ? item.PlusvaliasMinusvalias * -1 : 0;
                CarteraRF_temp.PorcentajePat = item.PorcentajePat;
                CarteraRF_temp.TirCompra = item.TirCompra;
                CarteraRF_temp.TirMercado = item.TirMercado;
                CarteraRF_temp.Valor = item.Valor;
                CarteraRF_temp.Vencimiento = item.Vencimiento;

            }

            return CarteraRF_temp;
        }

    }
}
