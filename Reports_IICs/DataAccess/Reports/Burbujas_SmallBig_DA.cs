using Reports_IICs.DataModels;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_Burbujas_SmallBig : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string codigoIC;
        private string isin;
        private string descripcionInstrumento;

        private decimal? capitalizacionBursatilEuros;
        private decimal? porcentajeCartera;
        private decimal? descuentoFundamental;
        private System.DateTime fechaCotizacion;
        private decimal? puntuacionSmallBig;
        private decimal? puntuacionValueGrowth;
        private decimal? puntuacionUta;
        private string tickerBloomberg;
        private bool? visible;

        public int Id
        {
            get { return this.id; }
            set
            {
                if (value != this.id)
                {
                    this.id = value;
                    this.OnPropertyChanged("Id");
                }
            }
        }

        public string CodigoIC
        {
            get { return this.codigoIC; }
            set
            {
                if (value != this.codigoIC)
                {
                    this.codigoIC = value;
                    this.OnPropertyChanged("CodigoIC");
                }
            }
        }
        public string Isin
        {
            get { return this.isin; }
            set
            {
                if (value != this.isin)
                {
                    this.isin = value;
                    this.OnPropertyChanged("Isin");
                }
            }
        }

        public string DescripcionInstrumento
        {
            get { return this.descripcionInstrumento; }
            set
            {
                if (value != this.descripcionInstrumento)
                {
                    this.descripcionInstrumento = value;
                    this.OnPropertyChanged("DescripcionInstrumento");
                }
            }
        }
        public decimal? CapitalizacionBursatilEuros
        {
            get { return this.capitalizacionBursatilEuros; }
            set
            {
                if (value != this.capitalizacionBursatilEuros)
                {
                    this.capitalizacionBursatilEuros = value;
                    this.OnPropertyChanged("CapitalizacionBursatilEuros");
                }
            }
        }


        public decimal? PorcentajeCartera
        {
            get { return this.porcentajeCartera; }
            set
            {
                if (value != this.porcentajeCartera)
                {
                    this.porcentajeCartera = value;
                    this.OnPropertyChanged("PorcentajeCartera");
                }
            }
        }
        public decimal? DescuentoFundamental
        {
            get { return this.descuentoFundamental; }
            set
            {
                if (value != this.descuentoFundamental)
                {
                    this.descuentoFundamental = value;
                    this.OnPropertyChanged("DescuentoFundamental");
                }
            }
        }
        public System.DateTime FechaCotizacion
        {
            get { return this.fechaCotizacion; }
            set
            {
                if (value != this.fechaCotizacion)
                {
                    this.fechaCotizacion = value;
                    this.OnPropertyChanged("FechaCotizacion");
                }
            }
        }


        public decimal? PuntuacionSmallBig
        {
            get { return this.puntuacionSmallBig; }
            set
            {
                if (value != this.puntuacionSmallBig)
                {
                    this.puntuacionSmallBig = value;
                    this.OnPropertyChanged("PuntuacionSmallBig");
                }
            }
        }

        public decimal? PuntuacionValueGrowth
        {
            get { return this.puntuacionValueGrowth; }
            set
            {
                if (value != this.puntuacionValueGrowth)
                {
                    this.puntuacionValueGrowth = value;
                    this.OnPropertyChanged("PuntuacionValueGrowth");
                }
            }
        }

        public decimal? PuntuacionUta
        {
            get { return this.puntuacionUta; }
            set
            {
                if (value != this.puntuacionUta)
                {
                    this.puntuacionUta = value;
                    this.OnPropertyChanged("PuntuacionUta");
                }
            }
        }

     

        public string TickerBloomberg
        {
            get { return this.tickerBloomberg; }
            set
            {
                if (value != this.tickerBloomberg)
                {
                    this.tickerBloomberg = value;
                    this.OnPropertyChanged("tickerBloomberg");
                }
            }
        }
        public bool? Visible
        {
            get { return this.visible; }
            set
            {
                if (value != this.visible)
                {
                    this.visible = value;
                    this.OnPropertyChanged("Visible");
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
    public class Burbujas_SmallBig_DA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<T_Burbujas_SmallBig> GetTemp_Burbujas_SmallBig(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<T_Burbujas_SmallBig> rentBurbujas = new ObservableCollection<T_Burbujas_SmallBig>();

                foreach (var item in dbContext.Temp_Burbujas.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                {
                    T_Burbujas_SmallBig tmp_rentBurbujas = new T_Burbujas_SmallBig();
                    tmp_rentBurbujas.Id = item.Id;
                    tmp_rentBurbujas.Isin = item.Isin;
                    tmp_rentBurbujas.CodigoIC = item.CodigoIC;
                    tmp_rentBurbujas.DescripcionInstrumento = item.DescripcionInstrumento;
                    tmp_rentBurbujas.CapitalizacionBursatilEuros = item.CapitalizacionBursatilEuros;
                    tmp_rentBurbujas.PorcentajeCartera = item.PorcentajeCartera;
                    tmp_rentBurbujas.DescuentoFundamental = item.DescuentoFundamental;
                    tmp_rentBurbujas.FechaCotizacion = item.FechaCotizacion;
                    tmp_rentBurbujas.TickerBloomberg = item.TickerBloomberg;
                    tmp_rentBurbujas.PuntuacionSmallBig = item.PuntuacionSmallBig;
                    tmp_rentBurbujas.PuntuacionValueGrowth = item.PuntuacionValueGrowth;
                    tmp_rentBurbujas.PuntuacionUta = item.PuntuacionUta;
                    tmp_rentBurbujas.Visible = item.Visible;

                    rentBurbujas.Add(tmp_rentBurbujas);
                }
                return rentBurbujas;
            }
            else
            {

                ObservableCollection<T_Burbujas_SmallBig> rentBurbujas = new ObservableCollection<T_Burbujas_SmallBig>();

                foreach (var item in dbContext.Temp_Burbujas.Where(r => r.CodigoIC == codigoIC))
                {
                    T_Burbujas_SmallBig tmp_rentBurbujas = new T_Burbujas_SmallBig();
                    tmp_rentBurbujas.Id = item.Id;
                    tmp_rentBurbujas.Isin = item.Isin;
                    tmp_rentBurbujas.CodigoIC = item.CodigoIC;
                    tmp_rentBurbujas.DescripcionInstrumento = item.DescripcionInstrumento;
                    tmp_rentBurbujas.CapitalizacionBursatilEuros = item.CapitalizacionBursatilEuros;
                    tmp_rentBurbujas.PorcentajeCartera = item.PorcentajeCartera;
                    tmp_rentBurbujas.DescuentoFundamental = item.DescuentoFundamental;
                    tmp_rentBurbujas.FechaCotizacion = item.FechaCotizacion;
                    tmp_rentBurbujas.TickerBloomberg = item.TickerBloomberg;
                    tmp_rentBurbujas.PuntuacionSmallBig = item.PuntuacionSmallBig;
                    tmp_rentBurbujas.PuntuacionValueGrowth = item.PuntuacionValueGrowth;
                    tmp_rentBurbujas.PuntuacionUta = item.PuntuacionUta;
                    tmp_rentBurbujas.Visible = item.Visible;

                    rentBurbujas.Add(tmp_rentBurbujas);
                }
                return rentBurbujas;
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


        public static void Update_GetTemp_Burbujas_SmallBig_Item(Temp_Burbujas burbSmallbig_temp_new)
        {
            Reports_IICSEntities dbcontext = new Reports_IICSEntities();
            Temp_Burbujas burbSmallbig_temp_old = dbcontext.Temp_Burbujas.FirstOrDefault(p => p.Id == burbSmallbig_temp_new.Id);
            Helpers.Utils.CopyPropertyValues(burbSmallbig_temp_new, burbSmallbig_temp_old);

            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

   

}
