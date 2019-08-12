using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Reports_IICs.DataModels;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_Participes : INotifyPropertyChanged
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

        private string nombreApellidos;
        public string NombreApellidos

        {
            get
            {
                return this.nombreApellidos;
            }
            set
            {
                if (value != this.nombreApellidos)
                {
                    this.nombreApellidos = value;
                    this.OnPropertyChanged("NombreApellidos");
                }
            }
        }

        private decimal numeroParticipaciones;
        public decimal NumeroParticipaciones
        {
            get
            {
                return this.numeroParticipaciones;
            }
            set
            {
                if (value != this.numeroParticipaciones)
                {
                    this.numeroParticipaciones = value;
                    this.OnPropertyChanged("NumeroParticipaciones");
                }
            }
        }
        private decimal? porcentajeParticipacion;
        public decimal? PorcentajeParticipacion
        {
            get
            {
                return this.porcentajeParticipacion;
            }
            set
            {
                if (value != this.porcentajeParticipacion)
                {
                    this.porcentajeParticipacion = value;
                    this.OnPropertyChanged("PorcentajeParticipacion");
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

    public class T_Temp_ParticipesSalat : INotifyPropertyChanged
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

        private string tituloInforme;
        public string TituloInforme
        {
            get
            {
                return this.tituloInforme;
            }
            set
            {
                if (value != this.tituloInforme)
                {
                    this.tituloInforme = value;
                    this.OnPropertyChanged("TituloInforme");
                }
            }
        }

        private string evolucionCarteras_Text;
        public string EvolucionCarteras_Text

        {
            get
            {
                return this.evolucionCarteras_Text;
            }
            set
            {
                if (value != this.evolucionCarteras_Text)
                {
                    this.evolucionCarteras_Text = value;
                    this.OnPropertyChanged("EvolucionCarteras_Text");
                }
            }
        }

        private string aportaciones_EvolCart_Text;
        public string Aportaciones_EvolCart_Text
        {
            get
            {
                return this.aportaciones_EvolCart_Text;
            }
            set
            {
                if (value != this.aportaciones_EvolCart_Text)
                {
                    this.aportaciones_EvolCart_Text = value;
                    this.OnPropertyChanged("Aportaciones_EvolCart_Text");
                }
            }
        }

        private string valor_EvolCart_Text;
        public string Valor_EvolCart_Text
        {
            get
            {
                return this.valor_EvolCart_Text;
            }
            set
            {
                if (value != this.valor_EvolCart_Text)
                {
                    this.valor_EvolCart_Text = value;
                    this.OnPropertyChanged("Valor_EvolCart_Text");
                }
            }
        }

        private decimal? valor_EvolCartera;
        public decimal? Valor_EvolCartera
        {
            get
            {
                return this.valor_EvolCartera;
            }
            set
            {
                if (value != this.valor_EvolCartera)
                {
                    this.valor_EvolCartera = value;
                    this.OnPropertyChanged("Valor_EvolCartera");
                }
            }
        }

        private decimal? totalPeriodos;
        public decimal? TotalPeriodos
        {
            get
            {
                return this.totalPeriodos;
            }
            set
            {
                if (value != this.totalPeriodos)
                {
                    this.totalPeriodos = value;
                    this.OnPropertyChanged("TotalPeriodos");
                }
            }
        }

        private string totalPeriodos_Text;
        public string TotalPeriodos_Text

        {
            get
            {
                return this.totalPeriodos_Text;
            }
            set
            {
                if (value != this.TotalPeriodos_Text)
                {
                    this.totalPeriodos_Text = value;
                    this.OnPropertyChanged("TotalPeriodos_Text");
                }
            }
        }

        public  List<ParticipesSalat_Participes> ParticipesSalat_Participes { get; set; }
        public List<ParticipesSalat_Aportaciones> ParticipesSalat_Aportaciones { get; set; }
        public List<ParticipesSalat_Periodos> ParticipesSalat_Periodos { get; set; }

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

    class ParticipesReport_DA : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public static ObservableCollection<T_Participes> GetTemp_Participes(string codigoIC, string isin)
        {
            var temp = new List<Temp_Participes>();
            using (var dbContext = new Reports_IICSEntities())
            {
                temp = dbContext.Temp_Participes.Where(r => r.CodigoIC == codigoIC).ToList();
            }
            
            ObservableCollection<T_Participes> rentparticipes = new ObservableCollection<T_Participes>();

            foreach (var item in temp)
            {
                T_Participes tmp_participes = new T_Participes();
                tmp_participes.Id = item.Id;
                tmp_participes.CodigoIC = item.CodigoIC;
                tmp_participes.Isin = item.Isin;
                tmp_participes.NombreApellidos = item.NombreApellidos;
                tmp_participes.NumeroParticipaciones = item.NumeroParticipaciones;
                tmp_participes.PorcentajeParticipacion = item.PorcentajeParticipacion;

                rentparticipes.Add(tmp_participes);
            }
            return rentparticipes;

        }

        //Temp_ParticipesSalat_Aportaciones
        public static ObservableCollection<T_Temp_ParticipesSalat> GetTemp_ParticipesSalat(string codigoIC, string isin)
        {


            ObservableCollection<T_Temp_ParticipesSalat> rentparticipesSalat = new ObservableCollection<T_Temp_ParticipesSalat>();
            var tempParticipes = new List<ParticipesSalat>();
            using (var dbContext = new Reports_IICSEntities())
            {
                tempParticipes = dbContext.ParticipesSalats.ToList();
            }
            foreach (var item in tempParticipes)
            {
                T_Temp_ParticipesSalat tmp_participesSalat = new T_Temp_ParticipesSalat();
                tmp_participesSalat.Id = item.Id;
                //tmp_participesSalat.CodigoIC = item.CodigoIC;

                tmp_participesSalat.Aportaciones_EvolCart_Text = item.Aportaciones_EvolCart_Text;
                tmp_participesSalat.EvolucionCarteras_Text = item.EvolucionCarteras_Text;
                tmp_participesSalat.TituloInforme = item.TituloInforme;
                tmp_participesSalat.TotalPeriodos = item.TotalPeriodos;
                tmp_participesSalat.TotalPeriodos_Text = item.TotalPeriodos_Text;
                tmp_participesSalat.Valor_EvolCart_Text = item.Valor_EvolCart_Text;
                tmp_participesSalat.Valor_EvolCartera = item.Valor_EvolCartera;

                #region   Temp_ParticipesSalat_Aportaciones

                var tempAportaciones = new List<ParticipesSalat_Aportaciones>();
                using (var dbContext = new Reports_IICSEntities())
                {
                    tempAportaciones = dbContext.ParticipesSalat_Aportaciones.Where(r => r.IdParticipeSalat == item.Id).ToList();
                }

                foreach (var item_Aportaciones in tempAportaciones)
                {
                    ParticipesSalat_Aportaciones tmp_ParticipesSalat_Aportaciones = new ParticipesSalat_Aportaciones();
                    tmp_ParticipesSalat_Aportaciones.Id = item_Aportaciones.Id;

                    tmp_ParticipesSalat_Aportaciones.Aportacion = item_Aportaciones.Aportacion;
                    tmp_ParticipesSalat_Aportaciones.Fecha = item_Aportaciones.Fecha;
                    tmp_ParticipesSalat_Aportaciones.IdParticipeSalat = item_Aportaciones.IdParticipeSalat;
                    tmp_ParticipesSalat_Aportaciones.Titular = item_Aportaciones.Titular;
                    tmp_ParticipesSalat_Aportaciones.IdTitular = item_Aportaciones.IdTitular;
                    if (tmp_participesSalat.ParticipesSalat_Aportaciones == null) tmp_participesSalat.ParticipesSalat_Aportaciones = new List<ParticipesSalat_Aportaciones>();
                    tmp_participesSalat.ParticipesSalat_Aportaciones.Add(tmp_ParticipesSalat_Aportaciones);
                }
                #endregion
                //foreach (var item_Participes in dbContext.Temp_ParticipesSalat_Participes.Where(r => r.CodigoIC == codigoIC))
                //{
                //    Temp_ParticipesSalat_Participes tmp_ParticipesSalat_Participes = new Temp_ParticipesSalat_Participes();
                //    tmp_ParticipesSalat_Participes.Id = item_Participes.Id;
                //    tmp_ParticipesSalat_Participes.CodigoIC  = item_Participes.CodigoIC;
                //    tmp_ParticipesSalat_Participes.DNI = item_Participes.DNI;
                //    tmp_ParticipesSalat_Participes.Isin = item_Participes.Isin;
                //    tmp_ParticipesSalat_Participes.NombreApellidos = item_Participes.NombreApellidos;
                //    tmp_ParticipesSalat_Participes.NumeroParticipaciones = item_Participes.NumeroParticipaciones;
                //    tmp_ParticipesSalat_Participes.PorcentajeParticipacion = item_Participes.PorcentajeParticipacion;


                //    tmp_participesSalat.Temp_ParticipesSalat_Participes.Add(tmp_ParticipesSalat_Participes);


                //}

                var tempPeriodos = new List<ParticipesSalat_Periodos>();
                using (var dbContext = new Reports_IICSEntities())
                {
                    tempPeriodos = dbContext.ParticipesSalat_Periodos.Where(r => r.IdTempParticipeSalat == item.Id).ToList();
                }

                foreach (var item_Periodos in tempPeriodos)
                {
                    ParticipesSalat_Periodos tmp_ParticipesSalat_Periodos = new ParticipesSalat_Periodos();
                    tmp_ParticipesSalat_Periodos.Id = item_Periodos.Id;
                    tmp_ParticipesSalat_Periodos.Descripcion = item_Periodos.Descripcion;
                    tmp_ParticipesSalat_Periodos.FechaSaldo = item_Periodos.FechaSaldo;
                    tmp_ParticipesSalat_Periodos.IdTempParticipeSalat = item_Periodos.IdTempParticipeSalat;

                    var tempLineas = new List<ParticipesSalat_Periodos_Lineas>();
                    using (var dbContext = new Reports_IICSEntities())
                    {
                        tempLineas = dbContext.ParticipesSalat_Periodos_Lineas.Where(r => r.IdParticipesSalatPeriodo == tmp_ParticipesSalat_Periodos.Id).ToList();
                    }
                    foreach (var item_Periodos_linea in tempLineas)
                    {
                        ParticipesSalat_Periodos_Lineas tmp_ParticipesSalat_Periodos_Lineas = new ParticipesSalat_Periodos_Lineas();
                        tmp_ParticipesSalat_Periodos_Lineas.Id = item_Periodos_linea.Id;
                        tmp_ParticipesSalat_Periodos_Lineas.IdParticipesSalatPeriodo = item_Periodos_linea.IdParticipesSalatPeriodo;
                        tmp_ParticipesSalat_Periodos_Lineas.IdParametroParticipeSalat = item_Periodos_linea.IdParametroParticipeSalat;
                        tmp_ParticipesSalat_Periodos_Lineas.ImporteInvertido = item_Periodos_linea.ImporteInvertido;
                        tmp_ParticipesSalat_Periodos_Lineas.Resultado = item_Periodos_linea.Resultado;
                        tmp_ParticipesSalat_Periodos_Lineas.Saldo = item_Periodos_linea.Saldo;
                        tmp_ParticipesSalat_Periodos_Lineas.Titular = item_Periodos_linea.Titular;
                        tmp_ParticipesSalat_Periodos_Lineas.IdTitular = item_Periodos_linea.IdTitular;
                        tmp_ParticipesSalat_Periodos_Lineas.Valor = item_Periodos_linea.Valor;
                        tmp_ParticipesSalat_Periodos_Lineas.ValorMasEfectPeriodoAnt = item_Periodos_linea.ValorMasEfectPeriodoAnt;

                        tmp_ParticipesSalat_Periodos.ParticipesSalat_Periodos_Lineas.Add(tmp_ParticipesSalat_Periodos_Lineas);
                    }
                    if (tmp_participesSalat.ParticipesSalat_Periodos == null) tmp_participesSalat.ParticipesSalat_Periodos = new List<ParticipesSalat_Periodos>();
                    tmp_participesSalat.ParticipesSalat_Periodos.Add(tmp_ParticipesSalat_Periodos);

                }


                rentparticipesSalat.Add(tmp_participesSalat);
            }
            return rentparticipesSalat;

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