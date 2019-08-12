using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    class AddEditParamEvolucionMercadosValidation : IDataErrorInfo
    {
        public string Isin { get; set; }

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

                if (columnName == "Isin")
                {
                    if (string.IsNullOrEmpty(Isin))
                    {

                        result = Resources.Resource.IntroduzcaCodigoIsin_Message;

                    }
                    else
                    {

                        if (ListaCodigo.Exists(c => c == Isin))
                        {
                            result = Resources.Resource.IsinExiste_Message;
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
