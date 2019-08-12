using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    
    
 public class T_CompraVentaPrecAdq : INotifyPropertyChanged
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

        private System.DateTime? fecha;
        public System.DateTime? Fecha

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

        private System.DateTime? fechaNew;
        public System.DateTime? FechaNew

        {
            get
            {
                return this.fechaNew;
            }
            set
            {
                if (value != this.fechaNew)
                {
                    this.fechaNew = value;
                    this.OnPropertyChanged("FechaNew");
                }
            }
        }

        private string tipo;
        public string Tipo
        {
            get
            {
                return this.tipo;
            }
            set
            {
                if (value != this.tipo)
                {
                    this.tipo = value;
                    this.OnPropertyChanged("Tipo");
                }
            }
        }

        private string tipoNew;
        public string TipoNew
        {
            get
            {
                return this.tipoNew;
            }
            set
            {
                if (value != this.tipoNew)
                {
                    this.tipoNew = value;
                    this.OnPropertyChanged("TipoNew");
                }
            }
        }

        private decimal? titulos;
        public decimal? Titulos
        {
            get
            {
                return this.titulos;
            }
            set
            {
                if (value != this.titulos)
                {
                    this.titulos = value;
                    this.OnPropertyChanged("Titulos");
                }
            }
        }

        private decimal? titulosNew;
        public decimal? TitulosNew
        {
            get
            {
                return this.titulosNew;
            }
            set
            {
                if (value != this.titulosNew)
                {
                    this.titulosNew = value;
                    this.OnPropertyChanged("TitulosNew");
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

        private string descripcionValorNew;
        public string DescripcionValorNew
        {
            get
            {
                return this.descripcionValorNew;
            }
            set
            {
                if (value != this.descripcionValorNew)
                {
                    this.descripcionValorNew = value;
                    this.OnPropertyChanged("DescripcionValorNew");
                }
            }
        }

        private decimal? adquisicion;
        public decimal? Adquisicion
        {
            get
            {
                return this.adquisicion;
            }
            set
            {
                if (value != this.adquisicion)
                {
                    this.adquisicion = value;
                    this.OnPropertyChanged("Adquisicion");
                }
            }
        }

        private decimal? adquisicionNew;
        public decimal? AdquisicionNew
        {
            get
            {
                return this.adquisicionNew;
            }
            set
            {
                if (value != this.adquisicionNew)
                {
                    this.adquisicionNew = value;
                    this.OnPropertyChanged("AdquisicionNew");
                }
            }
        }


        private decimal? efectivo;
        public decimal? Efectivo
        {
            get
            {
                return this.efectivo;
            }
            set
            {
                if (value != this.efectivo)
                {
                    this.efectivo = value;
                    this.OnPropertyChanged("Efectivo");
                }
            }
        }

        private decimal? efectivoNew;
        public decimal? EfectivoNew
        {
            get
            {
                return this.efectivoNew;
            }
            set
            {
                if (value != this.efectivoNew)
                {
                    this.efectivoNew = value;
                    this.OnPropertyChanged("EfectivoNew");
                }
            }
        }

        private decimal? beneficio;
        public decimal? Beneficio
        {
            get
            {
                return this.beneficio;
            }
            set
            {
                if (value != this.beneficio)
                {
                    this.beneficio = value;
                    this.OnPropertyChanged("Beneficio");
                }
            }
        }


        private decimal? perdida;
        public decimal? Perdida
        {
            get
            {
                return this.perdida;
            }
            set
            {
                if (value != this.perdida)
                {
                    this.perdida = value;
                    this.OnPropertyChanged("Perdida");
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


 public class CompraVentaRespectoPrecioAdquisicion_DA : INotifyPropertyChanged
        {
        //public static ObjectResult<Get_Temp_CompraVentaPrecAdq_Result> GetTemp_Ordenado(string codigoIC)        
        public static List<Temp_CompraVentaPrecAdq> GetTemp_Ordenado(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var obj = dbContext.Get_Temp_CompraVentaPrecAdq(codigoIC).ToList();

            var output = new List<Temp_CompraVentaPrecAdq>();
            foreach(var item in obj)
            {
                var temp = new Temp_CompraVentaPrecAdq();
                Utils.CopyPropertyValues(item, temp);
                output.Add(temp);
            }

            return output;
        }

        public static List<Get_PreviewChanges_CompraVentaPrecAdq_Result> GetPreviewChanges(string codigoIC, DateTime fechaInforme)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var output = dbContext.Get_PreviewChanges_CompraVentaPrecAdq(codigoIC, fechaInforme).ToList();            

            return output;
        }
        public static ObservableCollection<T_CompraVentaPrecAdq> GetTemp_CompraVentaRespectoPrecioAdquisicion(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (!string.IsNullOrEmpty(isin))
            {
                ObservableCollection<T_CompraVentaPrecAdq> rentcompraventa = new ObservableCollection<T_CompraVentaPrecAdq>();

                foreach (var item in dbContext.Temp_CompraVentaPrecAdq.Where(r => r.CodigoIC == codigoIC && r.Isin == isin).OrderBy(c => c.Fecha))
                {
                    T_CompraVentaPrecAdq tmp_rentcompraventa = new T_CompraVentaPrecAdq();
                    tmp_rentcompraventa.Id = item.Id;
                    tmp_rentcompraventa.Fecha = item.Fecha;
                    tmp_rentcompraventa.CodigoIC = item.CodigoIC;
                    //tmp_rentcompraventa.IsinPlantilla = item.IsinPlantilla;
                    tmp_rentcompraventa.Isin = item.Isin;
                    tmp_rentcompraventa.Tipo = item.Tipo;
                    tmp_rentcompraventa.Titulos = item.Titulos;
                    tmp_rentcompraventa.DescripcionValor = item.DescripcionValor;
                    tmp_rentcompraventa.Adquisicion = item.Adquisicion;
                    tmp_rentcompraventa.Efectivo = item.Efectivo;
                    //tmp_rentcompraventa.Beneficio = (item.Efectivo > 0 ? item.Efectivo : 0);
                    //tmp_rentcompraventa.Perdida = (item.Efectivo < 0 ? item.Efectivo : 0);

                    //Buscamos si hay algún valor almacenado en la preview que tuviera los mismos valores 
                    //originales que el item actual
                    var obj = dbContext.Preview_CompraVentaPrecAdq.Where(w =>
                                    w.Fecha == item.Fecha
                                    && w.CodigoIC == item.CodigoIC
                                    //&& w.IsinPlantilla == item.IsinPlantilla
                                    && w.Isin == item.Isin
                                    && w.Tipo == item.Tipo
                                    && w.Titulos == item.Titulos
                                    && w.DescripcionValor == item.DescripcionValor
                                    && w.Adquisicion == item.Adquisicion
                                    //&& w.Efectivo == item.Efectivo
                                    ).FirstOrDefault();

                    if (obj != null)
                    {
                        tmp_rentcompraventa.FechaNew = obj.FechaNew;
                        tmp_rentcompraventa.TipoNew = obj.TipoNew;
                        tmp_rentcompraventa.TitulosNew = obj.TitulosNew;
                        tmp_rentcompraventa.DescripcionValorNew = obj.DescripcionValorNew;
                        tmp_rentcompraventa.AdquisicionNew = obj.AdquisicionNew;
                        tmp_rentcompraventa.EfectivoNew = obj.TitulosNew* obj.AdquisicionNew;
                    }
                    //Ponemos los valores originales en caso de que no existan modificados
                    //Porque los campos "...New" son los que mostraremos en la Preview
                    else
                    {
                        tmp_rentcompraventa.FechaNew = item.Fecha;
                        tmp_rentcompraventa.TipoNew = item.Tipo;
                        tmp_rentcompraventa.TitulosNew = item.Titulos;
                        tmp_rentcompraventa.DescripcionValorNew = item.DescripcionValor;
                        tmp_rentcompraventa.AdquisicionNew = item.Adquisicion;
                        tmp_rentcompraventa.EfectivoNew = item.Titulos*item.Adquisicion;
                    }

                    tmp_rentcompraventa.Beneficio = (tmp_rentcompraventa.EfectivoNew > 0 ? tmp_rentcompraventa.EfectivoNew : 0);
                    tmp_rentcompraventa.Perdida = (tmp_rentcompraventa.EfectivoNew < 0 ? tmp_rentcompraventa.EfectivoNew : 0);


                    rentcompraventa.Add(tmp_rentcompraventa);
                }
                return rentcompraventa;
            }
            else
            {

                ObservableCollection<T_CompraVentaPrecAdq> rentcompraventa = new ObservableCollection<T_CompraVentaPrecAdq>();

                foreach (var item in dbContext.Temp_CompraVentaPrecAdq.Where(r => r.CodigoIC == codigoIC))
                {
                    T_CompraVentaPrecAdq tmp_rentcompraventa = new T_CompraVentaPrecAdq();
                    tmp_rentcompraventa.Id = item.Id;
                    tmp_rentcompraventa.Fecha = item.Fecha;
                    tmp_rentcompraventa.CodigoIC = item.CodigoIC;
                    //tmp_rentcompraventa.IsinPlantilla = item.IsinPlantilla;
                    tmp_rentcompraventa.Isin = item.Isin;
                    tmp_rentcompraventa.Tipo = item.Tipo;
                    tmp_rentcompraventa.Titulos = item.Titulos;
                    tmp_rentcompraventa.DescripcionValor = item.DescripcionValor;
                    tmp_rentcompraventa.Adquisicion = item.Adquisicion;
                    tmp_rentcompraventa.Efectivo = item.Titulos*item.Adquisicion;
                    tmp_rentcompraventa.Beneficio = (item.Efectivo > 0 ? item.Efectivo : 0);
                    tmp_rentcompraventa.Perdida = (item.Efectivo < 0 ? item.Efectivo : 0);


                    rentcompraventa.Add(tmp_rentcompraventa);
                }
                return rentcompraventa;
            }
        }

        /// <summary>
        /// Devuelven los datos que antes de ser modificados en la Preview tenían Tipo = "VENTA" y Fecha != null
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="isin"></param>
        /// <returns></returns>
        public static IQueryable<Preview_CompraVentaPrecAdq> GetVentasPreview(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            //Filtramos teniendo en cuenta los datos originales, no los que datos después de haber sido modificados
            var obj = dbContext.Preview_CompraVentaPrecAdq.Where(w => w.CodigoIC == codigoIC && w.Tipo == "VENTA" && w.Fecha != null);

            return obj;
            
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
