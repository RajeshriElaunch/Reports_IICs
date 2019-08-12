using System;
using System.Linq;
using Reports_IICs.DataModels;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Reports_IICs.DataAccess.Reports
{
    public class T_OperacionesRentaVariable_II : INotifyPropertyChanged
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

        private Nullable<System.DateTime> fecha;
        public Nullable<System.DateTime> Fecha

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
        
        private string tipoMovimiento;
        public string TipoMovimiento
        {
            get
            {
                return this.tipoMovimiento;
            }
            set
            {
                if (value != this.tipoMovimiento)
                {
                    this.tipoMovimiento = value;
                    this.OnPropertyChanged("TipoMovimiento");
                }
            }
        }

        private decimal cantidad;
        public decimal Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                if (value != this.cantidad)
                {
                    this.cantidad = value;
                    this.OnPropertyChanged("Cantidad");
                }
            }
        }

        private decimal precio;
        public decimal Precio
        {
            get
            {
                return this.precio;
            }
            set
            {
                if (value != this.precio)
                {
                    this.precio = value;
                    this.OnPropertyChanged("Precio");
                }
            }
        }

        private Nullable<decimal> efectivoEuros;
        public Nullable<decimal> EfectivoEuros
        {
            get
            {
                return this.efectivoEuros;
            }
            set
            {
                if (value != this.efectivoEuros)
                {
                    this.efectivoEuros = value;
                    this.OnPropertyChanged("EfectivoEuros");
                }
            }
        }

        private Nullable<decimal> precioEuros;
        public Nullable<decimal> PrecioEuros
        {
            get
            {
                return this.precioEuros;
            }
            set
            {
                if (value != this.precioEuros)
                {
                    this.precioEuros = value;
                    this.OnPropertyChanged("PrecioEuros");
                }
            }
        }

        private Nullable<decimal> costeMedio;
        public Nullable<decimal> CosteMedio
        {
            get
            {
                return this.costeMedio;
            }
            set
            {
                if (value != this.costeMedio)
                {
                    this.costeMedio = value;
                    this.OnPropertyChanged("CosteMedio");
                }
            }
        }

        private Nullable<decimal> ganPerVsCosMed;
        public Nullable<decimal> GanPerVsCosMed
        {
            get
            {
                return this.ganPerVsCosMed;
            }
            set
            {
                if (value != this.ganPerVsCosMed)
                {
                    this.ganPerVsCosMed = value;
                    this.OnPropertyChanged("GanPerVsCosMed");
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

    class ReportOperacionesRentaVariable_II_DA : INotifyPropertyChanged

    {
        public static ObservableCollection<T_OperacionesRentaVariable_II> GetTemp_OperacionesRentaVariable_II(string codigoIC, string tipoMov)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            ObservableCollection<T_OperacionesRentaVariable_II> operRentaVar = new ObservableCollection<T_OperacionesRentaVariable_II>();
            var proc = dbContext.Temp_OperacionesRentaVariable_II.Where(r => r.CodigoIC == codigoIC && r.TipoMovimiento == tipoMov).OrderBy(o=>o.Fecha);

            foreach (var item in proc)
            {
                T_OperacionesRentaVariable_II tmp_operRentaVar = new T_OperacionesRentaVariable_II();
                tmp_operRentaVar.Id = item.Id;
                tmp_operRentaVar.Fecha = item.Fecha;
                tmp_operRentaVar.CodigoIC = item.CodigoIC;
                tmp_operRentaVar.Isin = item.IsinPlantilla;
                tmp_operRentaVar.TipoMovimiento = item.TipoMovimiento;
                tmp_operRentaVar.Cantidad = item.Cantidad;
                tmp_operRentaVar.CosteMedio = item.CosteMedio;
                tmp_operRentaVar.EfectivoEuros = item.EfectivoEuros;
                tmp_operRentaVar.GanPerVsCosMed = item.GanPerVsCosMed;
                tmp_operRentaVar.Precio = item.Precio;
                tmp_operRentaVar.PrecioEuros = item.PrecioEuros;
                tmp_operRentaVar.DescripcionValor = item.DescripcionValor;

                operRentaVar.Add(tmp_operRentaVar);
            }
            return operRentaVar;
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
