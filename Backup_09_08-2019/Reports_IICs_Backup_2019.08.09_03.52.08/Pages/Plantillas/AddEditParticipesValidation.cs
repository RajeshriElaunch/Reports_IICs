using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas
{
    class AddEditParticipesValidation : IDataErrorInfo
    {

        public string Codigo { get; set; }

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

                if (columnName == "Codigo")
                {
                    if (string.IsNullOrEmpty(Codigo))
                    {

                        result = Resources.Resource.IntroduzcaDNI_Message;

                    }
                    else
                    {

                        if (ListaCodigo.Exists(c => c == Codigo))
                        {
                            result = Resources.Resource.DNIExiste_Message;
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
