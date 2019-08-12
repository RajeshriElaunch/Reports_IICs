using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public class T_RentaFija : INotifyPropertyChanged
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
       

        private decimal numTit;
        public decimal NumTit
        {
            get
            {
                return this.numTit;
            }
            set
            {
                if (value != this.numTit)
                {
                    this.numTit = value;
                    this.OnPropertyChanged("NumTit");
                }
            }
        }

        private Nullable<decimal> grupo;
        public Nullable<decimal> Grupo
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

        private Nullable<decimal> efectivoIni;
        public Nullable<decimal> EfectivoIni
        {
            get
            {
                return this.efectivoIni;
            }
            set
            {
                if (value != this.efectivoIni)
                {
                    this.efectivoIni = value;
                    this.OnPropertyChanged("EfectivoIni");
                }
            }
        }

        private Nullable<decimal> efectivoFin;
        public Nullable<decimal> EfectivoFin
        {
            get
            {
                return this.efectivoFin;
            }
            set
            {
                if (value != this.efectivoFin)
                {
                    this.efectivoFin = value;
                    this.OnPropertyChanged("EfectivoFin");
                }
            }
        }

        private Nullable<decimal> boPdivisa;
        public Nullable<decimal> BoPDivisa
        {
            get
            {
                return this.boPdivisa;
            }
            set
            {
                if (value != this.boPdivisa)
                {
                    this.boPdivisa = value;
                    this.OnPropertyChanged("BoPDivisa");
                }
            }
        }

        private Nullable<decimal> boPPrecio;
        public Nullable<decimal> BoPPrecio
        {
            get
            {
                return this.boPPrecio;
            }
            set
            {
                if (value != this.boPPrecio)
                {
                    this.boPPrecio = value;
                    this.OnPropertyChanged("BoPPrecio");
                }
            }
        }

        private Nullable<decimal> boPTotal;
        public Nullable<decimal> BoPTotal
        {
            get
            {
                return this.boPTotal;
            }
            set
            {
                if (value != this.boPTotal)
                {
                    this.boPTotal = value;
                    this.OnPropertyChanged("BoPTotal");
                }
            }
        }

        private Nullable<decimal> boPTotalPorcentaje;
        public Nullable<decimal> BoPTotalPorcentaje
        {
            get
            {
                return this.boPTotalPorcentaje;
            }
            set
            {
                if (value != this.boPTotalPorcentaje)
                {
                    this.boPTotalPorcentaje = value;
                    this.OnPropertyChanged("BoPTotalPorcentaje");
                }
            }
        }

        private Nullable<decimal> posicionCartera;
        public Nullable<decimal> PosicionCartera
        {
            get
            {
                return this.posicionCartera;
            }
            set
            {
                if (value != this.posicionCartera)
                {
                    this.posicionCartera = value;
                    this.OnPropertyChanged("PosicionCartera");
                    UpdateTotalPosiciones();
                }
            }
        }

        private Nullable<decimal> posicionesCerradas;
        public Nullable<decimal> PosicionesCerradas
        {
            get
            {
                return this.posicionesCerradas;
            }
            set
            {
                if (value != this.posicionesCerradas)
                {
                    this.posicionesCerradas = value;
                    this.OnPropertyChanged("PosicionesCerradas");
                    UpdateTotalPosiciones();
                }
            }
        }

        private Nullable<decimal> totalPosiciones;
        public Nullable<decimal> TotalPosiciones
        {
            get
            {
                return this.totalPosiciones;
            }
            set
            {
                if (value != this.totalPosiciones)
                {
                    this.totalPosiciones = value;
                    this.OnPropertyChanged("TotalPosiciones");
                    //UpdateTotalPosiciones();
                }
            }
        }

        private void UpdateTotalPosiciones()
        {
            decimal cart = this.PosicionCartera != null ? Convert.ToDecimal(this.PosicionCartera) : 0;
            decimal cerr = this.PosicionesCerradas != null ? Convert.ToDecimal(this.PosicionesCerradas) : 0;
            this.TotalPosiciones = cart + cerr;
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
    public static class RentaFija_DA
    {
        public static IQueryable<Temp_RentaFija> GetTemp(string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            return dbContext.Temp_RentaFija.Where(w=>w.CodigoIC == codigoIC);
        }

        public static List<Get_PreviewChanges_RentaFija_Result> GetPreviewChanges(string codigoIC, DateTime fechaInforme)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var output = dbContext.Get_PreviewChanges_RentaFija(codigoIC, fechaInforme).ToList();

            return output;
        }

        public static void UpdateTempById(T_RentaFija t)
        {
            var dbContext = new Reports_IICSEntities();
            var obj = dbContext.Temp_RentaFija.Where(w => w.Id == t.Id).FirstOrDefault();
            
            if(obj != null)
            {
                Utils.CopyPropertyValues(t, obj);
                dbContext.SaveChanges();

            }
        }
    }
}
