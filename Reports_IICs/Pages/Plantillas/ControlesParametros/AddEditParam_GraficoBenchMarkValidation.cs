using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    class AddEditParam_GraficoBenchMarkValidation : IDataErrorInfo
    {
        public string Indice { get; set; }

        public string Descripcion { get; set; }

        public List<string> ListaCodigo { get; set; }

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

                        result = Resources.Resource.IntroduzcaCodigoIsin_Message;

                    }
                    else
                    {

                        if (ListaCodigo.Exists(c => c == Indice))
                        {
                            result = Resources.Resource.IndiceExiste_Message;
                        }


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
