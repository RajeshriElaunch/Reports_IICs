using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataModels;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_ParticipesSalat : INotifyPropertyChanged
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

        //private string codigoIC;
        //public string CodigoIC
        //{
        //    get
        //    {
        //        return this.codigoIC;
        //    }
        //    set
        //    {
        //        if (value != this.codigoIC)
        //        {
        //            this.codigoIC = value;
        //            this.OnPropertyChanged("CodigoIC");
        //        }
        //    }
        //}

        //private string isin;
        //public string Isin
        //{
        //    get
        //    {
        //        return this.isin;
        //    }
        //    set
        //    {
        //        if (value != this.isin)
        //        {
        //            this.isin = value;
        //            this.OnPropertyChanged("Isin");
        //        }
        //    }
        //}

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
        private decimal porcentajeParticipacion;
        public decimal PorcentajeParticipacion
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

    class ParticipesSalatReport_DA : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public static ObservableCollection<T_ParticipesSalat> GetTemp_Participes(string codigoIC, string isin)
        public static ObservableCollection<T_ParticipesSalat> GetTemp_Participes()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            //var temp = dbContext.Temp_ParticipesSalat.AsNoTracking().Where(r => r.CodigoIC == codigoIC).FirstOrDefault();
            var temp = new ParticipesSalat_MNG().Get();

            //if (!string.IsNullOrEmpty(isin))
            //{
                ObservableCollection<T_ParticipesSalat> rentparticipes = new ObservableCollection<T_ParticipesSalat>();

                
                //foreach (var item in dbContext.Temp_ParticipesSalat_Participes.Where(r => r.CodigoIC == codigoIC && r.Isin == isin))
                if (temp != null)
                {
                    foreach (var item in temp.ParticipesSalat_Participes)
                    {
                        T_ParticipesSalat tmp_participes = new T_ParticipesSalat();
                        tmp_participes.Id = item.Id;
                        //tmp_participes.CodigoIC = item.CodigoIC;
                        //tmp_participes.Isin = item.IsinPlantilla;
                        tmp_participes.NombreApellidos = item.NombreApellidos;
                        tmp_participes.NumeroParticipaciones = item.NumeroParticipaciones;
                        tmp_participes.PorcentajeParticipacion = item.PorcentajeParticipacion;

                        rentparticipes.Add(tmp_participes);
                    }
                }
                return rentparticipes;
            //}
            //else
            //{

            //    ObservableCollection<T_ParticipesSalat> rentparticipes = new ObservableCollection<T_ParticipesSalat>();

            //    //foreach (var item in dbContext.Temp_ParticipesSalat_Participes.Where(r => r.CodigoIC == codigoIC))
            //    if (temp != null)
                
            //        {
            //        foreach (var item in temp.ParticipesSalat_Participes)
            //        {
            //            T_ParticipesSalat tmp_participes = new T_ParticipesSalat();
            //            tmp_participes.Id = item.Id;
            //            //tmp_participes.CodigoIC = item.CodigoIC;
            //            tmp_participes.Isin = item.IsinPlantilla;
            //            tmp_participes.NombreApellidos = item.NombreApellidos;
            //            tmp_participes.NumeroParticipaciones = item.NumeroParticipaciones;
            //            tmp_participes.PorcentajeParticipacion = item.PorcentajeParticipacion;


            //            rentparticipes.Add(tmp_participes);
            //        }
            //    }
            //    return rentparticipes;
            //}
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
