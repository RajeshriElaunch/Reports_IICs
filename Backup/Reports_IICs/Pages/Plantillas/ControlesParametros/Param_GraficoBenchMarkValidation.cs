using System;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    class Param_GraficoBenchMarkValidation : IDataErrorInfo
    {
        public string Indice { get; set; }

        public string Descripcion { get; set; }

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

                if (columnName == "Indice")
                {
                    if (string.IsNullOrEmpty(Indice))
                    {

                        result = Resources.Resource.IntroduzcaIndice_Message;

                    }
                    
                }

                if (columnName == "Descripcion")
                {

                    if (string.IsNullOrEmpty(Descripcion))
                        result = Resources.Resource.IntroduzcaDescripcion_Message;

                }

                return result;
            }
        }
        #endregion
    }
}
