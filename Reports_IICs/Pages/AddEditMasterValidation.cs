using Reports_IICs.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reports_IICs.Pages
{
    public class AddEditMasterValidation : INotifyPropertyChanged, IDataErrorInfo
    {
        private string codigo;
        public string Codigo
        {
            get { return this.codigo; }

            set
            {
                if (value != this.codigo)
                {
                    this.codigo = value;
                    NotifyPropertyChanged("Codigo");
                }
            }

         }

        private string descripcion;
        public string Descripcion
        {
            get { return this.descripcion; }

            set
            {
                if (value != this.descripcion)
                {
                    this.descripcion = value;
                    NotifyPropertyChanged("Descripcion");
                }
            }
        }

        private string editmode;
        public string Editmode
        {
            get { return this.editmode; }

            set
            {
                if (value != this.editmode)
                {
                    this.editmode = value;
                    NotifyPropertyChanged("Editmode");
                }
            }

        }

        public List<string> ListaCodigo = new List<string>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


        #region IDataErrorInfo Members

        public string Error
        {
            get { throw new NotImplementedException(); }
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;
                
                    if (columnName == "Codigo")
                    {
                        if (string.IsNullOrEmpty(Codigo))
                        {

                            result = Resource.IntroduceCodigo_Message;
                        
                        }
                        else
                        {

                            if (ListaCodigo.Exists(c => c == Codigo))
                            {
                                result = Resource.CodigoYaExiste_Message;
                            }


                        }
                    }  
                
                if (columnName == "Descripcion")
                {

                    if (string.IsNullOrEmpty(Descripcion))
                        result = Resource.IntroduzcaDescripcion_Message;
                     
                }
                
                return result;
            }
        }
        #endregion
    }
}
