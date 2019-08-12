using Microsoft.VisualStudio.TestTools.UnitTesting;
using Reports_IICs.Helpers;

namespace Reports_IICs_Tests
{
    [TestClass]
    public class Reports_IICs_UnitTest
    {
        //[TestMethod()]
        //public void ActualiarPrecioYCambioFin_precsAj()
        //{
        //    /*
        //    Reports_IICSEntities dbContext = new Reports_IICSEntities();
        //    //var lista = dbContext.RentaVariable_PrecioAjustado.Where(w => w.PrecioFin  == null || w.TipoCambioFin == null).ToList();
        //    var lista = dbContext.RentaVariable_PrecioAjustado.ToList();

        //    foreach (var item in lista)
        //    {
        //        var plantilla = Plantillas_DA.GetPlantilla(item.CodigoIC);
        //        var fechaIni = Utils.GetFechaInicio(plantilla, item.FechaInforme);
        //        var pro13 = Reports_DA.GetPRO13(plantilla, fechaIni, item.FechaInforme);

        //        var obj = pro13.Where(w => w.Isin.ToUpper() == item.Isin.ToUpper()).FirstOrDefault();

        //        if(item.Isin.ToUpper() == "ES0113211835")
        //        {
        //            bool flag = true;
        //        }

        //        if(obj != null)
        //        {
        //            if (obj.PrecioC != null && obj.PrecioF != obj.PrecioC)
        //            {
        //                bool flag = true;
        //            }
        //            else
        //            {
        //                item.PrecioFin = obj.PrecioC != null ? obj.PrecioC : obj.PrecioF;
        //            }
        //            item.TipoCambioFin = obj.CambioC != null ? obj.CambioC : obj.CambioF;
        //        }
        //    }

        //    dbContext.SaveChanges();
        //    */
        //}


        [TestMethod()]
        public void InsertTemp21()
        {
            VariablesGlobales.SetVariablesGlobales();
            Utils.PruebasExcel();                                
        }
    }
}
