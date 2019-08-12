using System;
using System.ComponentModel;

namespace Reports_IICs.Pages.Plantillas.ControlesParametros
{
    class Param_RatiosCarteraRVValidation : IDataErrorInfo
    {
       
        public string BpaAñoInformeMaximo { get; set; }
        public string BpaAñoInformeMinimo { get; set; }
        public string BpaPrevisionMaximo { get; set; }
        public string BpaPrevisionMinimo { get; set; }
        public string DescuentoFundamentalMaximo { get; set; }
        public string DescuentoFundamentalMinimo { get; set; }
        public string DeudaNetaCapitalizacionMaximo { get; set; }
        public string DeudaNetaCapitalizacionMinimo { get; set; }
        public string DeudaNetaCapitalizacionPrevisionMaximo { get; set; }
        public string DeudaNetaCapitalizacionPrevisionMinimo { get; set; }
        public string PerAñoInformeMaximo { get; set; }
        public string PerAñoInformeMinimo { get; set; }
        public string PerPrevisionMaximo { get; set; }
        public string PerPrevisionMinimo { get; set; }
        public string PrecioVcMaximo { get; set; }
        public string PrecioVcMinimo { get; set; }
        public string RentabilidadesAñoInformeMaximo { get; set; }
        public string RentabilidadesAñoInformeMinimo { get; set; }
        public string RentabilidadesPrevisionMaximo { get; set; }
        public string RentabilidadesPrevisionMinimo { get; set; }
        //public string ValorFundamentalMaximo { get; set; }
        public string ValorFundamentalMinimo { get; set; }

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

                if (columnName == "BpaAñoInformeMaximo")
                {
                    if (string.IsNullOrEmpty(BpaAñoInformeMaximo))
                    {

                        result = Resources.Resource.IntroduzcaBPAAñoMax;

                    }

                }

                if (columnName == "BpaAñoInformeMinimo")
                {

                    if (string.IsNullOrEmpty(BpaAñoInformeMinimo))
                        result = Resources.Resource.IntroduzcaBPAAñoMin;

                }

                
                if (columnName == "BpaPrevisionMaximo")
                {

                    if (string.IsNullOrEmpty(BpaPrevisionMaximo))
                        result = Resources.Resource.IntroduzcaPrevisionMax;

                }

                if (columnName == "BpaPrevisionMinimo")
                {

                    if (string.IsNullOrEmpty(BpaPrevisionMinimo))
                        result = Resources.Resource.IntroduzcaPrevisionMin;

                }

                if (columnName == "DescuentoFundamentalMaximo")
                {

                    if (string.IsNullOrEmpty(DescuentoFundamentalMaximo))
                        result = Resources.Resource.IntroduzcaDtoFundamentalMax;

                }

                if (columnName == "DescuentoFundamentalMinimo")
                {

                    if (string.IsNullOrEmpty(DescuentoFundamentalMinimo))
                        result = Resources.Resource.IntroduzcaDtoFundamentalMin;

                }

                if (columnName == "DeudaNetaCapitalizacionMaximo")
                {

                    if (string.IsNullOrEmpty(DeudaNetaCapitalizacionMaximo))
                        result = Resources.Resource.IntroduzcaDeudaNetCapMax;

                }

                if (columnName == "DeudaNetaCapitalizacionMinimo")
                {

                    if (string.IsNullOrEmpty(DeudaNetaCapitalizacionMinimo))
                        result = Resources.Resource.IntroduzcaDeudaNetCapMin;

                }

                if (columnName == "DeudaNetaCapitalizacionPrevisionMaximo")
                {

                    if (string.IsNullOrEmpty(DeudaNetaCapitalizacionPrevisionMaximo))
                        result = Resources.Resource.IntroduzcaDeudaNetaCapPrevMax;

                }

                if (columnName == "DeudaNetaCapitalizacionPrevisionMinimo")
                {

                    if (string.IsNullOrEmpty(DeudaNetaCapitalizacionPrevisionMinimo))
                        result = Resources.Resource.IntroduzcaDeudaNetaCapPrevMin;

                }

                if (columnName == "PerAñoInformeMaximo")
                {

                    if (string.IsNullOrEmpty(PerAñoInformeMaximo))
                        result = Resources.Resource.IntroduzcaPERAñoMax;

                }

                if (columnName == "PerAñoInformeMinimo")
                {

                    if (string.IsNullOrEmpty(PerAñoInformeMinimo))
                        result = Resources.Resource.IntroduzcaPERAñoMin;

                }

                if (columnName == "PerPrevisionMaximo")
                {

                    if (string.IsNullOrEmpty(PerPrevisionMaximo))
                        result = Resources.Resource.IntroduzcaPERPrevisiónMax;

                }

                if (columnName == "PerPrevisionMinimo")
                {

                    if (string.IsNullOrEmpty(PerPrevisionMinimo))
                        result = Resources.Resource.IntroduzcaPERPrevisiónMin;

                }

                if (columnName == "PrecioVcMaximo")
                {

                    if (string.IsNullOrEmpty(PrecioVcMaximo))
                        result = Resources.Resource.IntroduzcaPrecioVCMax;

                }

                if (columnName == "PrecioVcMinimo")
                {

                    if (string.IsNullOrEmpty(PrecioVcMinimo))
                        result = Resources.Resource.IntroduzcaPrecioVCMin;

                }

                if (columnName == "RentabilidadesAñoInformeMaximo")
                {

                    if (string.IsNullOrEmpty(RentabilidadesAñoInformeMaximo))
                        result = Resources.Resource.IntroduzcaRentabilidadesAñoMax;

                }

                if (columnName == "RentabilidadesAñoInformeMinimo")
                {

                    if (string.IsNullOrEmpty(RentabilidadesAñoInformeMinimo))
                        result = Resources.Resource.IntroduzcaRentabilidadesAñoMin;

                }

                if (columnName == "RentabilidadesPrevisionMaximo")
                {

                    if (string.IsNullOrEmpty(RentabilidadesPrevisionMaximo))
                        result = Resources.Resource.IntroduzcaRentabilidadesPrevisionMax;

                }

                if (columnName == "RentabilidadesPrevisionMinimo")
                {

                    if (string.IsNullOrEmpty(RentabilidadesPrevisionMinimo))
                        result = Resources.Resource.IntroduzcaRentabilidadesPrevisionMin;

                }
                //if (columnName == "ValorFundamentalMaximo")
                //{

                //    if (string.IsNullOrEmpty(ValorFundamentalMaximo))
                //        result = Resources.Resource.IntroduzcaValorFundamentalMax;

                //}

                if (columnName == "ValorFundamentalMinimo")
                {

                    if (string.IsNullOrEmpty(ValorFundamentalMinimo))
                        result = Resources.Resource.IntroduzcaValorFundamentalMin;

                }

                
                return result;
            }
        }
        #endregion
    }
}
