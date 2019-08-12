using System;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    class Param_EvolucionPatrimGuissonaValidation : IDataErrorInfo
    {
        
        public decimal? TasaGestionAnual { get; set; }

        public decimal? ComisionDepositaria { get; set; }

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

                if (columnName == "TasaGestionAnual")
                {
                    if (TasaGestionAnual == null)
                    {

                        result = Resources.Resource.IntroduzcaTasaGestionAnual_Message;

                    }

                }

                if (columnName == "ComisionDepositaria")
                {

                    if (ComisionDepositaria==null)
                        result = Resources.Resource.IntroduzcaComisionDepositaria_Message;

                }

                return result;
            }
        }
        #endregion
    }
}
