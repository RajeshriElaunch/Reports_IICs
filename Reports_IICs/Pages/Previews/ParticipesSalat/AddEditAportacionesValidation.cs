using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reports_IICs.Pages.Previews.ParticipesSalat
{
    class AddEditAportacionesValidation : IDataErrorInfo
    {
       

        //public string Titular { get; set; }
        public int? IdParametroParticipeSalat { get; set; }

        public decimal? Aportacion { get; set; }

        public System.DateTime Fecha { get; set; }


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
               
                if (columnName == "Aportacion")
                {
                    if (Aportacion==null)
                        result = Resources.Resource.IntroduzcaAportacion_Message;
                }

                if (columnName == "Titular")
                {
                    if (IdParametroParticipeSalat == null)
                        result = Resources.Resource.IntroduzcaTitular_Message;
                }
                return result;
            }
        }
        #endregion
    }
}
