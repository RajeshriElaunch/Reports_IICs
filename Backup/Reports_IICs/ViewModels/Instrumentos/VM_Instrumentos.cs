using System.Collections.ObjectModel;
using System.ComponentModel;
using Reports_IICs.DataModels;
using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Secciones;
using System.Windows.Input;
using Reports_IICs.DataAccess.Bloomberg;

namespace Reports_IICs.ViewModels.Instrumentos
{
    public class Action : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int id;
        private string name;


        public int ID
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

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value != this.name)
                {
                    this.name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public Action()
        {

        }

        public Action(int id, string name)
        {
            this.id = id;
            this.name = name;

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

        public static ObservableCollection<Action> GetActions()
        {
            ObservableCollection<Action> actions = new ObservableCollection<Action>();
            Action action;


            action = new Action(1, "Editar");
            actions.Add(action);
            action = new Action(2, "Eliminar");
            actions.Add(action);
            return actions;
        }


    }
    public class VM_Instrumentos : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        #region Rentabilidad Cartera

        
        private string valliquidescrip;

       

        public  string ValLiquiDescrip
        {
            get
            {
                return this.valliquidescrip="VALOR LIQUIDATIVO DÍA";
            }
            set
            {
               
                if (value != this.valliquidescrip)
                {
                    this.valliquidescrip = value;
                    this.OnPropertyChanged("ValLiquiDescrip");
                }
            }
        }

        #endregion

        #region Actions

        private ObservableCollection<Action> _actions;


        public ObservableCollection<Action> Actions
        {
            get
            {
                if (this._actions == null)
                {
                    this._actions = Action.GetActions();
                }

                return this._actions;
            }
        }

        #endregion

        #region Empresas
        public static ObservableCollection<Instrumentos_Empresas> GetEmpresas()
        {

            ObservableCollection<Instrumentos_Empresas> empresas = new ObservableCollection<Instrumentos_Empresas>();

            foreach (var item in InstrumentosEmpresas_DA.GetAll())
            {
                Instrumentos_Empresas tmp_empresa = new Instrumentos_Empresas();
                tmp_empresa.Id = item.Id;
                tmp_empresa.Codigo = item.Codigo;
                tmp_empresa.Descripcion = item.Descripcion;


                empresas.Add(tmp_empresa);
            }

            return empresas;
        }

        private ObservableCollection<Instrumentos_Empresas> instrumentosempresas;

        public ObservableCollection<Instrumentos_Empresas> instrumentosEmpresas
        {
            get
            {
                if (this.instrumentosempresas == null)
                {
                    this.instrumentosempresas = GetEmpresas();
                }

                return this.instrumentosempresas;
            }
        }
        #endregion

        #region Categorias
        public static ObservableCollection<Instrumentos_Categorias> GetCategorias()
        {

            ObservableCollection<Instrumentos_Categorias> categorias = new ObservableCollection<Instrumentos_Categorias>();

            foreach (var item in InstrumentosCategorias_DA.GetAll())
            {
                Instrumentos_Categorias tmp_categorias = new Instrumentos_Categorias();
                tmp_categorias.Id = item.Id;
                tmp_categorias.Codigo = item.Codigo;
                tmp_categorias.Descripcion = item.Descripcion;


                categorias.Add(tmp_categorias);
            }

            return categorias;
        }

        private ObservableCollection<Instrumentos_Categorias> instrumentoscategorias;

        public ObservableCollection<Instrumentos_Categorias> instrumentosCategorias
        {
            get
            {
                if (this.instrumentoscategorias == null)
                {
                    this.instrumentoscategorias = GetCategorias();
                }

                return this.instrumentoscategorias;
            }
        }

        #endregion

        #region Paises
        public static ObservableCollection<Instrumentos_Paises> GetPaises()
        {

            ObservableCollection<Instrumentos_Paises> paises = new ObservableCollection<Instrumentos_Paises>();

            foreach (var item in InstrumentosPaises_DA.GetAll())
            {
                Instrumentos_Paises tmp_paises = new Instrumentos_Paises();
                tmp_paises.Id = item.Id;
                tmp_paises.Codigo = item.Codigo;
                tmp_paises.Descripcion = item.Descripcion;


                paises.Add(tmp_paises);
            }

            return paises;
        }

        private ObservableCollection<Instrumentos_Paises> instrumentospaises;

        public ObservableCollection<Instrumentos_Paises> instrumentosPaises
        {
            get
            {
                if (this.instrumentospaises == null)
                {
                    this.instrumentospaises = GetPaises();
                }

                return this.instrumentospaises;
            }
        }

        #endregion

        #region Tipos
        public static ObservableCollection<Instrumentos_Tipos> GetTipos()
        {

            ObservableCollection<Instrumentos_Tipos> paises = new ObservableCollection<Instrumentos_Tipos>();

            foreach (var item in InstrumentosTipos_DA.GetAll())
            {
                Instrumentos_Tipos tmp_tipos = new Instrumentos_Tipos();
                tmp_tipos.Id = item.Id;
                tmp_tipos.Codigo = item.Codigo;
                tmp_tipos.Descripcion = item.Descripcion;


                paises.Add(tmp_tipos);
            }

            return paises;
        }

        private ObservableCollection<Instrumentos_Tipos> instrumentostipos;

        public ObservableCollection<Instrumentos_Tipos> instrumentosTipos
        {
            get
            {
                if (this.instrumentostipos == null)
                {
                    this.instrumentostipos = GetTipos();
                }

                return this.instrumentostipos;
            }
        }

        #endregion

        #region Tipo Formula
        public static ObservableCollection<Formulas_Tipos> GetTipoFormula()
        {

            ObservableCollection<Formulas_Tipos> tipos = new ObservableCollection<Formulas_Tipos>();

            foreach (var item in Formulas_Tipos_DA.GetAll())
            {
                Formulas_Tipos tmp_tipos = new Formulas_Tipos();
                tmp_tipos.Id = item.Id;
                /*tmp_tipos.IndicesPreconfiguradosNovarexes = item.IndicesPreconfiguradosNovarexes;
                tmp_tipos.Parametros_IndicePreconfiguradoNovarex = item.Parametros_IndicePreconfiguradoNovarex;*/
                tmp_tipos.Descripcion = item.Descripcion;


                tipos.Add(tmp_tipos);
            }

            return tipos;
        }

        private ObservableCollection<Formulas_Tipos> formulastipos;

        public ObservableCollection<Formulas_Tipos> formulasTipos
        {
            get
            {
                if (this.formulastipos == null)
                {
                    this.formulastipos = GetTipoFormula();
                }

                return this.formulastipos;
            }
        }

        #endregion
        
        #region Zonas
        public static ObservableCollection<Instrumentos_Zonas> GetZonas()
        {

            ObservableCollection<Instrumentos_Zonas> zonas = new ObservableCollection<Instrumentos_Zonas>();

            foreach (var item in InstrumentosZonas_DA.GetAll())
            {
                Instrumentos_Zonas tmp_zonas = new Instrumentos_Zonas();
                tmp_zonas.Id = item.Id;
                tmp_zonas.Codigo = item.Codigo;
                tmp_zonas.Descripcion = item.Descripcion;


                zonas.Add(tmp_zonas);
            }

            return zonas;
        }

        private ObservableCollection<Instrumentos_Zonas> instrumentoszonas;

        public ObservableCollection<Instrumentos_Zonas> instrumentosZonas
        {
            get
            {
                if (this.instrumentoszonas == null)
                {
                    this.instrumentoszonas = GetZonas();
                }

                return this.instrumentoszonas;
            }
        }

        #endregion
        
        #region Instrumentos Divisas
        public static ObservableCollection<Instrumentos_Divisas> GetDivisas()
        {

            ObservableCollection<Instrumentos_Divisas> divisas = new ObservableCollection<Instrumentos_Divisas>();

            foreach (var item in Instrumentos_divisas_DA.GetAll())
            {
                Instrumentos_Divisas tmp_divisas = new Instrumentos_Divisas();
                
                tmp_divisas.Codigo = item.Codigo;
                tmp_divisas.Descripcion = item.Descripcion;


                divisas.Add(tmp_divisas);
            }

            return divisas;
        }

        private ObservableCollection<Instrumentos_Divisas> instrumentosdivisas;

        public ObservableCollection<Instrumentos_Divisas> instrumentosDivisas
        {
            get
            {
                if (this.instrumentosdivisas == null)
                {
                    this.instrumentosdivisas = GetDivisas();
                }

                return this.instrumentosdivisas;
            }
        }

        #endregion

        #region Secciones

        public static ObservableCollection<Seccione> GetSecciones()
        {

            ObservableCollection<Seccione> secciones = new ObservableCollection<Seccione>();

            foreach (var item in Secciones_DA.GetAll())
            {
                Seccione tmp_secciones = new Seccione();
                tmp_secciones.Id = item.Id;
                tmp_secciones.Descripcion = item.Descripcion;
                
                secciones.Add(tmp_secciones);
            }

            return secciones;
        }

        private ObservableCollection<Seccione> secciones;

        public ObservableCollection<Seccione> Secciones
        {
            get
            {
                if (this.secciones == null)
                {
                    this.secciones = GetSecciones();
                }

                return this.secciones;
            }
        }

        #endregion

        #region Instrumentos

        public static ObservableCollection<Instrumento> GetInstrumentos()
        {

            ObservableCollection<Instrumento> instrumentos = new ObservableCollection<Instrumento>();

            foreach (var item in Instrumentos_DA.GetAll())
            {
                Instrumento tmp_instrumentos = new Instrumento();
                tmp_instrumentos.Id = item.Id;
                tmp_instrumentos.Codigo = item.Codigo;
                tmp_instrumentos.Descripcion = item.Descripcion;


                instrumentos.Add(tmp_instrumentos);
            }

            return instrumentos;
        }

        private ObservableCollection<Instrumento> instrumentos;

        public ObservableCollection<Instrumento> Instrumentos
        {
            get
            {
                if (this.instrumentos == null)
                {
                    this.instrumentos = GetInstrumentos();
                }

                return this.instrumentos;
            }
        }

        #endregion

        #region Instrumentos Importados

        #region with joins
            public static ObservableCollection<Query_Instrumentos_Importados> GetInstrumentosImportados()
            {

                ObservableCollection<Query_Instrumentos_Importados> instrumentos = new ObservableCollection<Query_Instrumentos_Importados>();

                foreach (var item in  InstrumentosImportados_DA.GetQuery())
                {
                    Query_Instrumentos_Importados tmp_instrumentos = new Query_Instrumentos_Importados();
                    tmp_instrumentos.ISIN = item.ISIN;
                   // tmp_instrumentos.IdTipoInstrumento=item.IdTipoInstrumento;
                    tmp_instrumentos.TipoInstrumento =item.TipoInstrumento;
                    tmp_instrumentos.Sector =item.Sector;
                    tmp_instrumentos.Emergente =item.Emergente;
                   // tmp_instrumentos.IdCategoria =item.IdCategoria;
                    tmp_instrumentos.descripcionCategoria =item.descripcionCategoria;
                   // tmp_instrumentos.IdEmpresa =item.IdEmpresa;
                    tmp_instrumentos.descripcionEmpresa =item.descripcionEmpresa;
                   // tmp_instrumentos.IdInstrumento =item.IdInstrumento;
                    tmp_instrumentos.descripcionInstrumento =item.descripcionInstrumento;
                   // tmp_instrumentos.IdZona =item.IdZona;
                    tmp_instrumentos.descripcionZona =item.descripcionZona;
                   // tmp_instrumentos.IdPais =item.IdPais;
                    tmp_instrumentos.descripcionPais =item.descripcionPais;
                    instrumentos.Add(tmp_instrumentos);

                }


                return instrumentos;
            }

            private ObservableCollection<Query_Instrumentos_Importados> instrumentosimportados;

            public ObservableCollection<Query_Instrumentos_Importados> InstrumentosImportados
            {
                get
                {
                    if (this.instrumentosimportados == null)
                    {
                        this.instrumentosimportados = GetInstrumentosImportados();
                    }

                    return this.instrumentosimportados;
                }
            }
        #endregion

        #region without joins
        public static ObservableCollection<Query_Instrumentos_Importados> GetInstrumentosImportadosNoJoin()
        {

            ObservableCollection<Query_Instrumentos_Importados> instrumentos = new ObservableCollection<Query_Instrumentos_Importados>();

            foreach (var item in InstrumentosImportados_DA.GetAll())
            {
                Query_Instrumentos_Importados tmp_instrumentos = new Query_Instrumentos_Importados();
                tmp_instrumentos.ISIN = item.ISIN;
                // tmp_instrumentos.IdTipoInstrumento=item.IdTipoInstrumento;
                tmp_instrumentos.TipoInstrumento = item.Instrumentos_Tipos!=null? item.Instrumentos_Tipos.Descripcion:string.Empty;
                tmp_instrumentos.TipoInstrumento2 = item.Instrumentos_Tipos1 != null ? item.Instrumentos_Tipos1.Descripcion : string.Empty;
                tmp_instrumentos.TipoInstrumento3 = item.Instrumentos_Tipos2 != null ? item.Instrumentos_Tipos2.Descripcion : string.Empty;
                tmp_instrumentos.Sector = item.Instrumentos_Sectores != null ? item.Instrumentos_Sectores.Descripcion : string.Empty;
                tmp_instrumentos.Emergente = item.Emergente;
                // tmp_instrumentos.IdCategoria =item.IdCategoria;
                tmp_instrumentos.descripcionCategoria = item.Instrumentos_Categorias!=null ? item.Instrumentos_Categorias.Descripcion:string.Empty;
                // tmp_instrumentos.IdEmpresa =item.IdEmpresa;
                tmp_instrumentos.descripcionEmpresa = item.Instrumentos_Empresas!=null ? item.Instrumentos_Empresas.Descripcion:string.Empty;
                // tmp_instrumentos.IdInstrumento =item.IdInstrumento;
                tmp_instrumentos.descripcionInstrumento = item.Instrumento!=null ? item.Instrumento.Descripcion:string.Empty;
                // tmp_instrumentos.IdZona =item.IdZona;
                tmp_instrumentos.descripcionZona = item.Instrumentos_Zonas!=null ? item.Instrumentos_Zonas.Descripcion:string.Empty;
                // tmp_instrumentos.IdPais =item.IdPais;
                tmp_instrumentos.descripcionPais = item.Instrumentos_Paises!=null ? item.Instrumentos_Paises.Descripcion:string.Empty;
                instrumentos.Add(tmp_instrumentos);

            }


            return instrumentos;
        }

        private ObservableCollection<Query_Instrumentos_Importados> instrumentosimportadosNoJoin;

        public ObservableCollection<Query_Instrumentos_Importados> InstrumentosImportadosNoJoin
        {
            get
            {
                if (this.instrumentosimportadosNoJoin == null)
                {
                    this.instrumentosimportadosNoJoin = GetInstrumentosImportadosNoJoin();
                }

                return this.instrumentosimportadosNoJoin;
            }
        }
        #endregion


        #endregion

        #region Bloomberg

        public static ObservableCollection<Reports_IICs.DataModels.Bloomberg> GetBloombergs()
        {

            ObservableCollection<Reports_IICs.DataModels.Bloomberg> bloomberg = new ObservableCollection<Reports_IICs.DataModels.Bloomberg>();

            foreach (var item in ImportarBloomberg_DA.GetAll())
            {
                Reports_IICs.DataModels.Bloomberg tmp_bloomberg = new Reports_IICs.DataModels.Bloomberg();

                tmp_bloomberg.ISIN = item.ISIN;
                tmp_bloomberg.Año = item.Año;
                tmp_bloomberg.ColumnaEstimacion = item.ColumnaEstimacion;
                tmp_bloomberg.Capitalizacion = item.Capitalizacion;
                tmp_bloomberg.Bpa0 = item.Bpa0;
                tmp_bloomberg.BpaPrevision1 = item.BpaPrevision1;
                tmp_bloomberg.BpaPrevision2 = item.BpaPrevision2;
                tmp_bloomberg.BpaPrevision3 = item.BpaPrevision3;
                tmp_bloomberg.RentabilidadDividendo1 = item.RentabilidadDividendo1;
                tmp_bloomberg.RentabilidadDividendo2 = item.RentabilidadDividendo2;
                tmp_bloomberg.RentabilidadDividendo3 = item.RentabilidadDividendo3;
                tmp_bloomberg.Per1 = item.Per1;
                tmp_bloomberg.Per2 = item.Per2;
                tmp_bloomberg.Per3 = item.Per3;
                tmp_bloomberg.DeudaNetaCapitalizacion = item.DeudaNetaCapitalizacion;
                tmp_bloomberg.PrecioVc = item.PrecioVc;
                tmp_bloomberg.ValorFundamental = item.ValorFundamental;
                tmp_bloomberg.GvcBloomberg = item.GvcBloomberg;
                tmp_bloomberg.DescuentoFundamental = item.DescuentoFundamental;
                
                bloomberg.Add(tmp_bloomberg);

            }


            return bloomberg;
        }

        private ObservableCollection<Reports_IICs.DataModels.Bloomberg> bloombergs;

        public ObservableCollection<Reports_IICs.DataModels.Bloomberg> Bloombergs
        {
            get
            {
                if (this.bloombergs == null)
                {
                    this.bloombergs = GetBloombergs();
                }

                return this.bloombergs;
            }
        }

        #endregion
        
        #region ComboBox


        public ICommand MyCommandEdit
        {
            get;
            set;
        }

        #endregion

        #region Sectores

        public static ObservableCollection<Instrumentos_Sectores> GetSectores()
        {

            ObservableCollection<Instrumentos_Sectores> sectores = new ObservableCollection<Instrumentos_Sectores>();

            foreach (var item in InstrumentosSectores_DA.GetAll())
            {
                Instrumentos_Sectores tmp_secciones = new Instrumentos_Sectores();
                tmp_secciones.Id = item.Id;
                tmp_secciones.Descripcion = item.Descripcion;
                tmp_secciones.IdCategoria = item.IdCategoria;
                sectores.Add(tmp_secciones);
            }

            return sectores;
        }

        private ObservableCollection<Instrumentos_Sectores> instrumentossectores;

        public ObservableCollection<Instrumentos_Sectores> instrumentosSectores
        {
            get
            {
                if (this.instrumentossectores == null)
                {
                    this.instrumentossectores = GetSectores();
                }

                return this.instrumentossectores;
            }
        }

       
        #endregion

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
