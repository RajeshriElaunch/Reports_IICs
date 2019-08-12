using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    class AddEditEvolucionRentabGuissona_FondosValidation : IDataErrorInfo
    {
        public string CodigoIC { get; set; }

        public string CodigoICFondo { get; set; }
        public string IsinFondo { get; set; }

        public string Descripcion { get; set; }

        public DateTime FechaConstitucion { get; set; }

        public decimal? ReferenciaTAE { get; set; }
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
                    if (string.IsNullOrEmpty(CodigoICFondo))
                    {

                        result = Resources.Resource.IntroduzcaCodigoIsin_Message;

                    }
                    else
                    {

                        if (ListaCodigo.Exists(c => c == CodigoICFondo))
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

                if (columnName == "CodigoICFondo")
                {

                    if (string.IsNullOrEmpty(CodigoICFondo))
                        result = Resources.Resource.CodigoICFondo_Message;

                }

                
                if (columnName == "IsinFondo")
                {

                    if (string.IsNullOrEmpty(IsinFondo))
                        result = Resources.Resource.IsinFondo_Message;

                }
                if (columnName == "ReferenciaTAE")
                {

                    if (ReferenciaTAE==null)
                        result = Resources.Resource.ReferenciaTAE_Message;

                }
                
                if (columnName == "FechaConstitucion")
                {

                    if (string.IsNullOrEmpty(FechaConstitucion.ToString()))
                        result = Resources.Resource.IntroduzcaDescripcion_Message;

                }
                

                return result;
            }
        }
        #endregion

    }
}
