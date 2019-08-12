using System;
using System.ComponentModel;
using Reports_IICs.DataModels;

namespace Reports_IICs.Pages.Informes
{
    class ChooseReportValidation : IDataErrorInfo
    {
        public Plantilla SelectedPlantilla { get; set; }

        public string Descripcion { get; set; }

        public DateTime? ReportDate { get; set; }

        public bool ShowDate { get; set; }

        public ChooseReportValidation(bool showdate)
        {
            ShowDate = showdate;
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
                
                if (ShowDate!= false && columnName == "ReportDate")
                {
                    if (ReportDate == null)
                    {

                        result = Resources.Resource.IntroduzcaFecha_Message;

                    }
                    else
                    {

                       

                    }
                }

                if (columnName == "SelectedPlantilla")
                {

                    if (SelectedPlantilla==null)
                        result = Resources.Resource.SeleccionePlantilla_Message;

                }

                return result;
            }
        }
        #endregion
    }
}
