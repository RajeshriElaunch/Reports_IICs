using System.Linq;
using Reports_IICs.DataModels;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_DistribucionPatrimonioNovarex_Tesoreria : INotifyPropertyChanged
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
        

        private decimal patrimonio;
        public decimal Patrimonio
        {
            get
            {
                return this.patrimonio;
            }
            set
            {
                if (value != this.patrimonio)
                {
                    this.patrimonio = value;
                    this.OnPropertyChanged("Patrimonio");
                }
            }
        }

        private decimal porcentajePatrimonio;
        public decimal PorcentajePatrimonio
        {
            get
            {
                return this.porcentajePatrimonio;
            }
            set
            {
                if (value != this.porcentajePatrimonio)
                {
                    this.porcentajePatrimonio = value;
                    this.OnPropertyChanged("PorcentajePatrimonio");
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

    public class T_DistribucionPatrimonioNovarex_Total : INotifyPropertyChanged
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


        private decimal patrimonio;
        public decimal Patrimonio
        {
            get
            {
                return this.patrimonio;
            }
            set
            {
                if (value != this.patrimonio)
                {
                    this.patrimonio = value;
                    this.OnPropertyChanged("Patrimonio");
                }
            }
        }

        private decimal porcentajePatrimonio;
        public decimal PorcentajePatrimonio
        {
            get
            {
                return this.porcentajePatrimonio;
            }
            set
            {
                if (value != this.porcentajePatrimonio)
                {
                    this.porcentajePatrimonio = value;
                    this.OnPropertyChanged("PorcentajePatrimonio");
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


    public class T_DistribucionPatrimonioNovarex_Cartera : INotifyPropertyChanged
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
        
        private decimal rentaVariable;
        public decimal RentaVariable
        {
            get
            {
                return this.rentaVariable;
            }
            set
            {
                if (value != this.rentaVariable)
                {
                    this.rentaVariable = value;
                    this.OnPropertyChanged("RentaVariable");
                }
            }
        }

        private decimal rentaVariablePorc;
        public decimal RentaVariablePorc
        {
            get
            {
                return this.rentaVariablePorc;
            }
            set
            {
                if (value != this.rentaVariablePorc)
                {
                    this.rentaVariablePorc = value;
                    this.OnPropertyChanged("RentaVariablePorc");
                }
            }
        }

        private decimal repoDeuda;
        public decimal RepoDeuda
        {
            get
            {
                return this.repoDeuda;
            }
            set
            {
                if (value != this.repoDeuda)
                {
                    this.repoDeuda = value;
                    this.OnPropertyChanged("RepoDeuda");
                }
            }
        }

        private decimal repoDeudaPorc;
        public decimal RepoDeudaPorc
        {
            get
            {
                return this.repoDeudaPorc;
            }
            set
            {
                if (value != this.repoDeudaPorc)
                {
                    this.repoDeudaPorc = value;
                    this.OnPropertyChanged("RepoDeudaPorc");
                }
            }
        }


        private decimal rentaFija;
        public decimal RentaFija
        {
            get
            {
                return this.rentaFija;
            }
            set
            {
                if (value != this.rentaFija)
                {
                    this.rentaFija = value;
                    this.OnPropertyChanged("RentaFija");
                }
            }
        }

        private decimal rentaFijaPorc;
        public decimal RentaFijaPorc
        {
            get
            {
                return this.rentaFijaPorc;
            }
            set
            {
                if (value != this.rentaFijaPorc)
                {
                    this.rentaFijaPorc = value;
                    this.OnPropertyChanged("RentaFijaPorc");
                }
            }
        }


        private decimal? retornoAbsoluto;
        public decimal? RetornoAbsoluto
        {
            get
            {
                return this.retornoAbsoluto;
            }
            set
            {
                if (value != this.retornoAbsoluto)
                {
                    this.retornoAbsoluto = value;
                    this.OnPropertyChanged("RetornoAbsoluto");
                }
            }
        }

        private decimal? retornoAbsolutoPorc;
        public decimal? RetornoAbsolutoPorc
        {
            get
            {
                return this.retornoAbsolutoPorc;
            }
            set
            {
                if (value != this.retornoAbsolutoPorc)
                {
                    this.retornoAbsolutoPorc = value;
                    this.OnPropertyChanged("RetornoAbsolutoPorc");
                }
            }
        }

        private decimal? garantizadosEstructurados;
        public decimal? GarantizadosEstructurados
        {
            get
            {
                return this.garantizadosEstructurados;
            }
            set
            {
                if (value != this.garantizadosEstructurados)
                {
                    this.garantizadosEstructurados = value;
                    this.OnPropertyChanged("GarantizadosEstructurados");
                }
            }
        }

        private decimal? garantizadosEstructuradosPorc;
        public decimal? GarantizadosEstructuradosPorc
        {
            get
            {
                return this.garantizadosEstructuradosPorc;
            }
            set
            {
                if (value != this.garantizadosEstructuradosPorc)
                {
                    this.garantizadosEstructuradosPorc = value;
                    this.OnPropertyChanged("GarantizadosEstructuradosPorc");
                }
            }
        }

        private decimal? divisas;
        public decimal? Divisas
        {
            get
            {
                return this.divisas;
            }
            set
            {
                if (value != this.divisas)
                {
                    this.divisas = value;
                    this.OnPropertyChanged("Divisas");
                }
            }
        }

        private decimal? divisasPorc;
        public decimal? DivisasPorc
        {
            get
            {
                return this.divisasPorc;
            }
            set
            {
                if (value != this.divisasPorc)
                {
                    this.divisasPorc = value;
                    this.OnPropertyChanged("DivisasPorc");
                }
            }
        }

        private decimal? commodities;
        public decimal? Commodities
        {
            get
            {
                return this.commodities;
            }
            set
            {
                if (value != this.commodities)
                {
                    this.commodities = value;
                    this.OnPropertyChanged("Commodities");
                }
            }
        }

        private decimal? commoditiesPorc;
        public decimal? CommoditiesPorc
        {
            get
            {
                return this.commoditiesPorc;
            }
            set
            {
                if (value != this.commoditiesPorc)
                {
                    this.commoditiesPorc = value;
                    this.OnPropertyChanged("CommoditiesPorc");
                }
            }
        }

        private decimal? otros;
        public decimal? Otros
        {
            get
            {
                return this.otros;
            }
            set
            {
                if (value != this.otros)
                {
                    this.otros = value;
                    this.OnPropertyChanged("Otros");
                }
            }
        }

        private decimal? otrosPorc;
        public decimal? OtrosPorc
        {
            get
            {
                return this.otrosPorc;
            }
            set
            {
                if (value != this.otrosPorc)
                {
                    this.otrosPorc = value;
                    this.OnPropertyChanged("OtrosPorc");
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


    public class T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED : INotifyPropertyChanged
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


        private decimal patrimonio;
        public decimal Patrimonio
        {
            get
            {
                return this.patrimonio;
            }
            set
            {
                if (value != this.patrimonio)
                {
                    this.patrimonio = value;
                    this.OnPropertyChanged("Patrimonio");
                }
            }
        }

        private decimal porcentajePatrimonio;
        public decimal PorcentajePatrimonio
        {
            get
            {
                return this.porcentajePatrimonio;
            }
            set
            {
                if (value != this.porcentajePatrimonio)
                {
                    this.porcentajePatrimonio = value;
                    this.OnPropertyChanged("PorcentajePatrimonio");
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



    class Report_DistribucionPatrimonioNovarex_DA : INotifyPropertyChanged
    {

        public static ObservableCollection<T_DistribucionPatrimonioNovarex_Tesoreria> GetTemp_DistribucionPatrimonioNovarex_Tesoreria(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            
                ObservableCollection<T_DistribucionPatrimonioNovarex_Tesoreria> DistribucionPatrimonioNovarex_Tesoreria = new ObservableCollection<T_DistribucionPatrimonioNovarex_Tesoreria>();

                foreach (var item in dbContext.Temp_DistribucionPatrimonioNovarex_Tesoreria.Where(r => r.CodigoIC == codigoIC))
                {
                    T_DistribucionPatrimonioNovarex_Tesoreria tmp_DistribucionPatrimonioNovarex_Tesoreria = new T_DistribucionPatrimonioNovarex_Tesoreria();
                    tmp_DistribucionPatrimonioNovarex_Tesoreria.Id = item.Id;
                    tmp_DistribucionPatrimonioNovarex_Tesoreria.CodigoIC = item.CodigoIC;
                    tmp_DistribucionPatrimonioNovarex_Tesoreria.Descripcion = item.Descripcion;
                    tmp_DistribucionPatrimonioNovarex_Tesoreria.Patrimonio = item.Patrimonio;
                    tmp_DistribucionPatrimonioNovarex_Tesoreria.PorcentajePatrimonio = item.PorcentajePatrimonio;
  

                     DistribucionPatrimonioNovarex_Tesoreria.Add(tmp_DistribucionPatrimonioNovarex_Tesoreria);
                }
                return DistribucionPatrimonioNovarex_Tesoreria;
            
        }

        public static ObservableCollection<T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED> GetTemp_DistribucionPatrimonioNovarex_Cartera(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            ObservableCollection<T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED> DistribucionPatrimonioNovarex_Cartera_Trans = new ObservableCollection<T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED>();
            ObservableCollection<T_DistribucionPatrimonioNovarex_Cartera> DistribucionPatrimonioNovarex_Cartera = new ObservableCollection<T_DistribucionPatrimonioNovarex_Cartera>();

            foreach (var item in dbContext.Temp_DistribucionPatrimonioNovarex_Cartera.Where(r => r.CodigoIC == codigoIC))
            {
                T_DistribucionPatrimonioNovarex_Cartera tmp_DistribucionPatrimonioNovarex_Cartera = new T_DistribucionPatrimonioNovarex_Cartera();
                tmp_DistribucionPatrimonioNovarex_Cartera.Id = item.Id;
                tmp_DistribucionPatrimonioNovarex_Cartera.CodigoIC = item.CodigoIC;
                tmp_DistribucionPatrimonioNovarex_Cartera.RentaFija = item.RentaFija;
                tmp_DistribucionPatrimonioNovarex_Cartera.RentaFijaPorc = item.RentaFijaPorc;
                tmp_DistribucionPatrimonioNovarex_Cartera.RentaVariable = item.RentaVariable;
                tmp_DistribucionPatrimonioNovarex_Cartera.RentaVariablePorc = item.RentaVariablePorc;
                tmp_DistribucionPatrimonioNovarex_Cartera.RepoDeuda = item.RepoDeuda;
                tmp_DistribucionPatrimonioNovarex_Cartera.RepoDeudaPorc = item.RepoDeudaPorc;
                tmp_DistribucionPatrimonioNovarex_Cartera.RetornoAbsoluto = item.RetornoAbsoluto;
                tmp_DistribucionPatrimonioNovarex_Cartera.RetornoAbsolutoPorc = item.RetornoAbsolutoPorc;
                tmp_DistribucionPatrimonioNovarex_Cartera.GarantizadosEstructurados = item.GarantizadosEstructurados;
                tmp_DistribucionPatrimonioNovarex_Cartera.GarantizadosEstructuradosPorc = item.GarantizadosEstructuradosPorc;
                //tmp_DistribucionPatrimonioNovarex_Cartera.Divisas = item.Divisas;
                //tmp_DistribucionPatrimonioNovarex_Cartera.DivisasPorc = item.DivisasPorc;
                //tmp_DistribucionPatrimonioNovarex_Cartera.Commodities = item.Commodities;
                //tmp_DistribucionPatrimonioNovarex_Cartera.CommoditiesPorc = item.CommoditiesPorc;
                tmp_DistribucionPatrimonioNovarex_Cartera.Otros = item.Otros;
                tmp_DistribucionPatrimonioNovarex_Cartera.OtrosPorc = item.OtrosPorc;


               DistribucionPatrimonioNovarex_Cartera.Add(tmp_DistribucionPatrimonioNovarex_Cartera);
            }


            foreach (var item in DistribucionPatrimonioNovarex_Cartera)
            {
                T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                tmp_DistribucionPatrimonioNovarex_Cartera_trans.CodigoIC = item.CodigoIC;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans.Id = item.Id;

                tmp_DistribucionPatrimonioNovarex_Cartera_trans.Descripcion = "Renta Variable + IICsRV";
                tmp_DistribucionPatrimonioNovarex_Cartera_trans.Patrimonio = item.RentaVariable;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans.PorcentajePatrimonio = item.RentaVariablePorc;
                DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans);

                T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_repo = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                tmp_DistribucionPatrimonioNovarex_Cartera_trans_repo.CodigoIC = item.CodigoIC;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_repo.Id = item.Id;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_repo.Descripcion = "REPO DEUDA";
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_repo.Patrimonio = item.RepoDeuda;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_repo.PorcentajePatrimonio = item.RepoDeudaPorc;
                DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_repo);

                T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_RF = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                tmp_DistribucionPatrimonioNovarex_Cartera_trans_RF.CodigoIC = item.CodigoIC;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_RF.Id = item.Id;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_RF.Descripcion = "Renta Fija + IICsRF";
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_RF.Patrimonio = item.RentaFija;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_RF.PorcentajePatrimonio = item.RentaFijaPorc;
                DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_RF);

                if (item.RetornoAbsoluto != null && item.RetornoAbsoluto.Value>0)
                { 
                    T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_RA = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_RA.CodigoIC = item.CodigoIC;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_RA.Id = item.Id;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_RA.Descripcion = "RETORNO ABSOLUTO";
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_RA.Patrimonio = item.RetornoAbsoluto.Value;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_RA.PorcentajePatrimonio = item.RetornoAbsolutoPorc.Value;
                    DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_RA);
                }

                if(item.GarantizadosEstructurados != null && item.GarantizadosEstructurados.Value>0)
                {
                    T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_GA = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_GA.CodigoIC = item.CodigoIC;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_GA.Id = item.Id;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_GA.Descripcion = "GARANTIZADOS/ESTRUCTURADOS";
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_GA.Patrimonio = item.GarantizadosEstructurados.Value;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_GA.PorcentajePatrimonio = item.GarantizadosEstructuradosPorc.Value;
                    DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_GA);
                }

                if (item.Divisas != null && item.Divisas.Value > 0)
                {
                    T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_DI = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_DI.CodigoIC = item.CodigoIC;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_DI.Id = item.Id;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_DI.Descripcion = "DIVISAS";
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_DI.Patrimonio = item.Divisas.Value;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_DI.PorcentajePatrimonio = item.DivisasPorc.Value;
                    DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_DI);
                }

                if (item.Commodities!=null && item.Commodities.Value > 0)
                {
                    T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_COM = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_COM.CodigoIC = item.CodigoIC;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_COM.Id = item.Id;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_COM.Descripcion = "COMMODITIES";
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_COM.Patrimonio = item.Commodities.Value;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_COM.PorcentajePatrimonio = item.CommoditiesPorc.Value;
                    DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_COM);
                }

                if (item.Otros != null && item.Otros.Value > 0)
                {
                    T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_OT = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_OT.CodigoIC = item.CodigoIC;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_OT.Id = item.Id;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_OT.Descripcion = "OTROS";
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_OT.Patrimonio = item.Otros.Value;
                    tmp_DistribucionPatrimonioNovarex_Cartera_trans_OT.PorcentajePatrimonio = item.OtrosPorc.Value;
                    DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_OT);
                }

                T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED tmp_DistribucionPatrimonioNovarex_Cartera_trans_TOTAL = new T_DistribucionPatrimonioNovarex_Cartera_TRANSFORMED();

                tmp_DistribucionPatrimonioNovarex_Cartera_trans_TOTAL.CodigoIC = item.CodigoIC;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_TOTAL.Id = item.Id;
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_TOTAL.Descripcion = "TOTAL CARTERA";
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_TOTAL.Patrimonio = item.RentaVariable + item.RentaFija + item.RepoDeuda + ((item.RetornoAbsoluto==null)?0:item.RetornoAbsoluto.Value) + ((item.GarantizadosEstructurados==null)?0:item.GarantizadosEstructurados.Value) + ((item.Divisas==null)?0:item.Divisas.Value) + ((item.Commodities==null)?0:item.Commodities.Value) + ((item.Otros==null)?0:item.Otros.Value);
                tmp_DistribucionPatrimonioNovarex_Cartera_trans_TOTAL.PorcentajePatrimonio = item.RentaVariablePorc + item.RentaFijaPorc + item.RepoDeudaPorc + ((item.RetornoAbsolutoPorc==null)?0:item.RetornoAbsolutoPorc.Value) + ((item.GarantizadosEstructuradosPorc==null)?0:item.GarantizadosEstructuradosPorc.Value) + ((item.DivisasPorc==null)?0:item.DivisasPorc.Value) + ((item.CommoditiesPorc==null)?0:item.CommoditiesPorc.Value) + ((item.OtrosPorc==null)?0:item.OtrosPorc.Value);
                DistribucionPatrimonioNovarex_Cartera_Trans.Add(tmp_DistribucionPatrimonioNovarex_Cartera_trans_TOTAL);


            }
            return DistribucionPatrimonioNovarex_Cartera_Trans;

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
