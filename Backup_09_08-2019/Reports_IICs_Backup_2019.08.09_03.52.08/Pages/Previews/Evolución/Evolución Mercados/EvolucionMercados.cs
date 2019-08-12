using System.Collections.ObjectModel;
using System.ComponentModel;
using Reports_IICs.DataAccess.Secciones;

namespace Reports_IICs.Pages.Previews.Evolución.Evolución_Mercados
{
    public class EvolucionMercados : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string codigoIC;
        private string isin;

        private string descripcion;
        private decimal cotizaDivDesde;
        private decimal cotizaDivHasta;
        private decimal varCotizaDivisa;
        private decimal? varCotizaEuros;
        private System.DateTime fechaCotizacionDesde;
        private System.DateTime fechaCotizacionHasta;

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

        public string Descripcion
        {
            get { return this.descripcion; }
            set
            {
                if (value != this.descripcion)
                {
                    this.descripcion = value;
                    this.OnPropertyChanged("Descripcion");
                }
            }
        }

        public decimal CotizaDivDesde
        {
            get { return this.cotizaDivDesde; }
            set
            {
                if (value != this.cotizaDivDesde)
                {
                    this.cotizaDivDesde = value;
                    this.OnPropertyChanged("CotizaDivDesde");
                }
            }
        }

        public decimal CotizaDivHasta
        {
            get { return this.cotizaDivHasta; }
            set
            {
                if (value != this.cotizaDivHasta)
                {
                    this.cotizaDivHasta = value;
                    this.OnPropertyChanged("CotizaDivHasta");
                }
            }
        }

        public decimal VarCotizaDivisa
        {
            get { return this.varCotizaDivisa; }
            set
            {
                if (value != this.varCotizaDivisa)
                {
                    this.varCotizaDivisa = value;
                    this.OnPropertyChanged("VarCotizaDivisa");
                }
            }
        }

      
        public decimal? VarCotizaEuros
        {
            get { return this.varCotizaEuros; }
            set
            {
                if (value != this.varCotizaEuros)
                {
                    this.varCotizaEuros = value;
                    this.OnPropertyChanged("VarCotizaEuros");
                }
            }
        }
        public System.DateTime FechaCotizacionDesde
        {
            get { return this.fechaCotizacionDesde; }
            set
            {
                if (value != this.fechaCotizacionDesde)
                {
                    this.fechaCotizacionDesde = value;
                    this.OnPropertyChanged("FechaCotizacionDesde");
                }
            }
        }
        public System.DateTime FechaCotizacionHasta
        {
            get { return this.fechaCotizacionHasta; }
            set
            {
                if (value != this.fechaCotizacionHasta)
                {
                    this.fechaCotizacionHasta = value;
                    this.OnPropertyChanged("FechaCotizacionHasta");
                }
            }
        }

        public EvolucionMercados()
        {
        }

        public EvolucionMercados(string descripcion, decimal cotizaDivDesde, decimal cotizaDivHasta, decimal varCotizaDivisa)
        {
            this.descripcion = descripcion;
            this.cotizaDivDesde = cotizaDivDesde;
            this.cotizaDivHasta = cotizaDivHasta;
            this.varCotizaDivisa = varCotizaDivisa;
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
    
        public static ObservableCollection<EvolucionMercados> Get_Temp_EvolucionMercados(string codigoIC)
       
        {
            ObservableCollection<EvolucionMercados> tmp = new ObservableCollection<EvolucionMercados>();

            foreach (var item in EvolucionMercados_DA.GetTemp_EvolucionMercados(codigoIC, null))
            {
                EvolucionMercados tmp_evomerca = new EvolucionMercados();
                tmp_evomerca.Id = item.Id;
                tmp_evomerca.CodigoIC = item.CodigoIC;
                tmp_evomerca.CotizaDivDesde = item.CotizaDivDesde;
                tmp_evomerca.CotizaDivHasta = item.CotizaDivHasta;
                tmp_evomerca.Descripcion = item.Descripcion;
                tmp_evomerca.FechaCotizacionDesde = item.FechaCotizacionDesde;
                tmp_evomerca.FechaCotizacionHasta = item.FechaCotizacionHasta;
                tmp_evomerca.Isin = item.Isin;
                tmp_evomerca.VarCotizaDivisa = item.VarCotizaDivisa;
                tmp_evomerca.VarCotizaEuros = item.VarCotizaEuros;
                tmp.Add(tmp_evomerca);
            }
            return tmp;
            
        }
    }
}
