using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    class AddEditDistriPatrimNovarexValidation : IDataErrorInfo
    {
        public string Formula { get; set; }

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

                if (columnName == "Descripcion")
                {
                    if (string.IsNullOrEmpty(Descripcion))
                    {

                        result = Resources.Resource.IntroduzcaDescripcion_Message;

                    }
                    else
                    {

                        if (ListaCodigo.Exists(c => c == Descripcion))
                        {
                            result = Resources.Resource.DescripcionExiste_Message;
                        }


                    }
                }

                if (columnName == "Formula")
                {

                    if (string.IsNullOrEmpty(Formula))
                        result = Resources.Resource.IntroduzcaFormula_Message;

                }

                return result;
            }
        }
        #endregion

    }
}
