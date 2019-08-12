using System;
using System.Linq;
using Reports_IICs.DataModels;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_RentabilidadCarteraSolemeg : INotifyPropertyChanged
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

        private string isin;
        public string Isin
        {
            get
            {
                return this.isin;
            }
            set
            {
                if (value != this.isin)
                {
                    this.isin = value;
                    this.OnPropertyChanged("Isin");
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




        private decimal numeroTitulos;
        public decimal NumeroTitulos
        {
            get
            {
                return this.numeroTitulos;
            }
            set
            {
                if (value != this.numeroTitulos)
                {
                    this.numeroTitulos = value;
                    this.OnPropertyChanged("NumeroTitulos");
                }
            }
        }

        private Nullable<decimal> precioCompraOriginal;
        public Nullable<decimal> PrecioCompraOriginal
        {
            get
            {
                return this.precioCompraOriginal;
            }
            set
            {
                if (value != this.precioCompraOriginal)
                {
                    this.precioCompraOriginal = value;
                    this.OnPropertyChanged("PrecioCompraOriginal");
                }
            }
        }


        private decimal? precioCompraSolemeg;
        public decimal? PrecioCompraSolemeg
        {
            get
            {
                return this.precioCompraSolemeg;
            }
            set
            {
                if (value != this.precioCompraSolemeg)
                {
                    this.precioCompraSolemeg = value;
                    this.OnPropertyChanged("PrecioCompraSolemeg");
                }
            }
        }


        private decimal precioActual;
        public decimal PrecioActual
        {
            get
            {
                return this.precioActual;
            }
            set
            {
                if (value != this.precioActual)
                {
                    this.precioActual = value;
                    this.OnPropertyChanged("PrecioActual");
                }
            }
        }

        private Nullable<bool> vendido;

        public Nullable<bool> Vendido
        {
            get
            {
                return this.vendido;
            }
            set
            {
                if (value != this.vendido)
                {
                    this.vendido = value;
                    this.OnPropertyChanged("Vendido");
                }
            }
        }


        private int grupo;
        public int Grupo
        {
            get
            {
                return this.grupo;
            }
            set
            {
                if (value != this.grupo)
                {
                    this.grupo = value;
                    this.OnPropertyChanged("Grupo");
                }
            }
        }

        private string mercado;
        public string Mercado
        {
            get
            {
                return this.mercado;
            }
            set
            {
                if (value != this.mercado)
                {
                    this.mercado = value;
                    this.OnPropertyChanged("Mercado");
                }
            }
        }

        private Nullable<decimal> rentabilidadOrigen;
        public Nullable<decimal> RentabilidadOrigen
        {
            get
            {
                return this.rentabilidadOrigen;
            }
            set
            {
                if (value != this.rentabilidadOrigen)
                {
                    this.rentabilidadOrigen = value;
                    this.OnPropertyChanged("RentabilidadOrigen");
                }
            }
        }

        private Nullable<decimal> rentabilidadSolemeg;
        public Nullable<decimal> RentabilidadSolemeg
        {
            get
            {
                return this.rentabilidadSolemeg;
            }
            set
            {
                if (value != this.rentabilidadSolemeg)
                {
                    this.rentabilidadSolemeg = value;
                    this.OnPropertyChanged("RentabilidadSolemeg");
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
    class Report_RentabilidadCarteraSolemeg_DA : INotifyPropertyChanged
    {
        public static ObservableCollection<T_RentabilidadCarteraSolemeg> GetTemp_RentabilidadCarteraSolemeg(string codigoIC, string isin, int grupo)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            if (!string.IsNullOrEmpty(isin))
            {

                ObservableCollection<T_RentabilidadCarteraSolemeg> operRentaVar = new ObservableCollection<T_RentabilidadCarteraSolemeg>();

                foreach (var item in dbContext.Temp_RentabilidadCarteraSolemeg.Where(r => r.CodigoIC == codigoIC && r.ISIN == isin && r.Grupo == grupo ))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.ISIN;
                    tmp_operRentaVar.Descripcion = (item.Vendido==true)?item.Descripcion + "(VENDIDO)": item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ? ((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) : 0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg)  : 0;

                    operRentaVar.Add(tmp_operRentaVar);
                }
                return operRentaVar;
            }
            else
            {

                ObservableCollection<T_RentabilidadCarteraSolemeg> operRentaVar = new ObservableCollection<T_RentabilidadCarteraSolemeg>();

                foreach (var item in dbContext.Temp_RentabilidadCarteraSolemeg.Where(r => r.CodigoIC == codigoIC && r.Grupo == grupo))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.ISIN;
                    tmp_operRentaVar.Descripcion = (item.Vendido == true) ? item.Descripcion + "(VENDIDO)" : item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ?((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) :0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg) :0;

                    operRentaVar.Add(tmp_operRentaVar);
                }
                return operRentaVar;
            }
        }

        public static ObservableCollection<T_RentabilidadCarteraSolemeg> GetTemp_RentabilidadCarteraSolemegGroup3(string codigoIC, string isin, int grupo)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            if (!string.IsNullOrEmpty(isin))
            {

                ObservableCollection<T_RentabilidadCarteraSolemeg> operRentaVar = new ObservableCollection<T_RentabilidadCarteraSolemeg>();

                var CustomQuery =
                   from TRC in dbContext.Temp_RentabilidadCarteraSolemeg
                   select new { Id = TRC.Id, CodigoIC = TRC.CodigoIC, Isin = TRC.ISIN, Descripcion = TRC.Descripcion, NumeroTitulos = TRC.NumeroTitulos, PrecioCompraOriginal = TRC.PrecioCompraOriginal, PrecioCompraSolemeg = TRC.PrecioCompraSolemeg, PrecioActual = TRC.PrecioActual, Vendido = TRC.Vendido, Grupo = TRC.Grupo, Mercado = TRC.Mercado, CodInstrumento = TRC.CodInstrumento, Pais = TRC.Pais };
                    

                #region SPAIN&RV


                foreach (var item in CustomQuery.Where(r => r.CodigoIC == codigoIC && r.Isin == isin && r.Grupo == grupo && r.CodInstrumento=="RV" && r.Pais== "ESPAÑA").OrderBy(c=>c.Descripcion))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.Isin;
                    tmp_operRentaVar.Descripcion = (item.Vendido == true) ? item.Descripcion + "(VENDIDO)" : item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ? ((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) : 0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg) : 0;

                    operRentaVar.Add(tmp_operRentaVar);

                }

                #endregion

                #region NOTSPAIN&RV
                foreach (var item in CustomQuery.Where(r => r.CodigoIC == codigoIC && r.Isin == isin && r.Grupo == grupo && r.CodInstrumento == "RV" && r.Pais != "ESPAÑA").OrderBy(c => c.Descripcion))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.Isin;
                    tmp_operRentaVar.Descripcion = (item.Vendido == true) ? item.Descripcion + "(VENDIDO)" : item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ? ((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) : 0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg) : 0;

                    operRentaVar.Add(tmp_operRentaVar);

                }
                #endregion

                #region NOTRV
                foreach (var item in CustomQuery.Where(r => r.CodigoIC == codigoIC && r.Isin == isin && r.Grupo == grupo && (r.CodInstrumento != "RV" || r.CodInstrumento == null)).OrderBy(c => c.Descripcion))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.Isin;
                    tmp_operRentaVar.Descripcion = (item.Vendido == true) ? item.Descripcion + "(VENDIDO)" : item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ? ((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) : 0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg) : 0;

                    operRentaVar.Add(tmp_operRentaVar);

                }
                #endregion


                return operRentaVar;
            }
            else
            {

                ObservableCollection<T_RentabilidadCarteraSolemeg> operRentaVar = new ObservableCollection<T_RentabilidadCarteraSolemeg>();

                var CustomQuery =
                   from TRC in dbContext.Temp_RentabilidadCarteraSolemeg
                   join M in dbContext.Mercados on TRC.Mercado equals M.CodMercado
                   select new { Id = TRC.Id, CodigoIC = TRC.CodigoIC, Isin = TRC.ISIN, Descripcion = TRC.Descripcion, NumeroTitulos = TRC.NumeroTitulos, PrecioCompraOriginal = TRC.PrecioCompraOriginal, PrecioCompraSolemeg = TRC.PrecioCompraSolemeg, PrecioActual = TRC.PrecioActual, Vendido = TRC.Vendido, Grupo = TRC.Grupo, Mercado = TRC.Mercado, CodInstrumento = TRC.CodInstrumento, Pais = M.Pais };

                #region SPAIN&RV


                foreach (var item in CustomQuery.Where(r => r.CodigoIC == codigoIC  && r.Grupo == grupo && r.CodInstrumento == "RV" && r.Pais == "ESPAÑA").OrderBy(c => c.Descripcion))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.Isin;
                    tmp_operRentaVar.Descripcion = (item.Vendido == true) ? item.Descripcion + "(VENDIDO)" : item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ? ((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) : 0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg) : 0;

                    operRentaVar.Add(tmp_operRentaVar);

                }

                #endregion

                #region NOTSPAIN&RV
                foreach (var item in CustomQuery.Where(r => r.CodigoIC == codigoIC  && r.Grupo == grupo && r.CodInstrumento == "RV" && r.Pais != "ESPAÑA").OrderBy(c => c.Descripcion))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.Isin;
                    tmp_operRentaVar.Descripcion = (item.Vendido == true) ? item.Descripcion + "(VENDIDO)" : item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ? ((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) : 0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg) : 0;

                    operRentaVar.Add(tmp_operRentaVar);

                }
                #endregion

                #region NOTRV
                foreach (var item in CustomQuery.Where(r => r.CodigoIC == codigoIC  && r.Grupo == grupo && (r.CodInstrumento != "RV" || r.CodInstrumento == null)).OrderBy(c => c.Descripcion))
                {
                    T_RentabilidadCarteraSolemeg tmp_operRentaVar = new T_RentabilidadCarteraSolemeg();
                    tmp_operRentaVar.Id = item.Id;
                    tmp_operRentaVar.CodigoIC = item.CodigoIC;
                    tmp_operRentaVar.Isin = item.Isin;
                    tmp_operRentaVar.Descripcion = (item.Vendido == true) ? item.Descripcion + "(VENDIDO)" : item.Descripcion;
                    tmp_operRentaVar.NumeroTitulos = item.NumeroTitulos;
                    tmp_operRentaVar.PrecioCompraOriginal = item.PrecioCompraOriginal;
                    tmp_operRentaVar.PrecioCompraSolemeg = item.PrecioCompraSolemeg;
                    tmp_operRentaVar.PrecioActual = item.PrecioActual;
                    tmp_operRentaVar.Vendido = item.Vendido;
                    tmp_operRentaVar.RentabilidadOrigen = (item.PrecioCompraOriginal > 0) ? ((item.PrecioActual - item.PrecioCompraOriginal) / item.PrecioCompraOriginal) : 0;
                    tmp_operRentaVar.RentabilidadSolemeg = (item.PrecioCompraSolemeg > 0) ? ((item.PrecioActual - item.PrecioCompraSolemeg) / item.PrecioCompraSolemeg) : 0;

                    operRentaVar.Add(tmp_operRentaVar);

                }
                #endregion
                return operRentaVar;
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
