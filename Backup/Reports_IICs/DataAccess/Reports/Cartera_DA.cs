using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Linq;

namespace Reports_IICs.DataAccess.Reports
{
    public class Cartera_DA
    {
        public static IQueryable<Temp_PRO_11> GetTemp_PRO_11(string codigoIC, string tipo)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var temp = dbContext.Temp_PRO_11.Where(p => p.CodigoIC == codigoIC);
            if(!string.IsNullOrEmpty(tipo))
            {
                temp = temp.Where(w => w.Tipo == tipo);
            }
            return temp;
        }

        public static void Update_Temp_PRO_11_Item(Temp_PRO_11 pro11_temp_new)
        {
            Reports_IICSEntities dbcontext = new Reports_IICSEntities();
            Temp_PRO_11 pro11_temp_old = dbcontext.Temp_PRO_11.FirstOrDefault(p => p.Id == pro11_temp_new.Id);
            Utils.CopyPropertyValues(pro11_temp_new, pro11_temp_old);            

            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static void Update_Temp_PRO_12_Item(Temp_PRO_12 pro12_temp_new)
        {
            Reports_IICSEntities dbcontext = new Reports_IICSEntities();
            Temp_PRO_12 pro12_temp_old = dbcontext.Temp_PRO_12.FirstOrDefault(p => p.Id == pro12_temp_new.Id);
            Utils.CopyPropertyValues(pro12_temp_new, pro12_temp_old);

            try
            {
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //public static void Insert_Temp_PRO_11(Plantilla plantilla, DateTime? fecha)
        //{
        //    Reports_IICSEntities dbContext = new Reports_IICSEntities();

        //    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Si hubiera datos los borramos antes de insertar
        //            dbContext.Temp_PRO_11.RemoveRange(dbContext.Temp_PRO_11.Where(p => p.CodigoIC == plantilla.CodigoIc).ToList());

        //            List<Temp_PRO_11> listaPro11temp = new List<Temp_PRO_11>();

        //            //var isins = plantilla.Plantillas_Isins.Select(p => p.Isin);
        //            //var listaIsins = Utils.GetIsinsGeneradosSiEsFondo(plantilla.IdTipo, isins);
        //            //foreach (var isin in listaIsins)
        //            //{

        //                var pro11Result = Reports_DA.GetPRO11(plantilla.CodigoIc, fecha).ToList();
        //                var EfecActTotal = pro11Result.Sum(s => s.efeact);
        //                foreach (var pro11_item in pro11Result)
        //                {
        //                    Temp_PRO_11 pro11temp = new Temp_PRO_11();
        //                    //Copiamos el contenido de pro11_item en pro11temp
        //                    //Utils.CopyPropertyValues(pro11_item, pro11temp);
        //                    pro11temp.CodigoIC = plantilla.CodigoIc;
        //                    //pro11temp.Isin = isin;
        //                    pro11temp.Tipo = pro11_item.tipo;
        //                    pro11temp.DescripcionValor = pro11_item.descr;
        //                    pro11temp.Divisa = pro11_item.div;
        //                    pro11temp.Dias = pro11_item.diasvto;
        //                    pro11temp.Vencimiento = pro11_item.datvto;
        //                    pro11temp.Nominal = pro11_item.nomina;
        //                    pro11temp.Cantidad = pro11_item.cantid;
        //                    pro11temp.EfectivoCompra = pro11_item.efecos;
        //                    pro11temp.TIR_C_Fif = pro11_item.tircom;
        //                    pro11temp.CosteMedio = pro11_item.cosmed;
        //                    pro11temp.ValorActualDivisa = pro11_item.valact;
        //                    pro11temp.Cambio = pro11_item.cambio;
        //                    pro11temp.Intereses = pro11_item.interes;
        //                    if (pro11_item.plusva > 0)
        //                    {
        //                        pro11temp.Plusvalias = pro11_item.plusva;
        //                        pro11temp.Minusvalias = 0;
        //                    }
        //                    else
        //                    {
        //                        pro11temp.Plusvalias = 0;
        //                        pro11temp.Minusvalias = pro11_item.plusva*(-1);
        //                    }
        //                    pro11temp.EfectivoActual = pro11_item.efeact;

        //                    pro11temp.PorcentajeP = pro11_item.TPC2;
        //                    //Es el peso del EfectivoActual en el EfectivoActual Total
        //                    decimal porc = (pro11_item.efeact * 100) / EfecActTotal;
        //                    pro11temp.Porcentaje = decimal.Round(porc, 2);
        //                    decimal rounded = decimal.Round(Convert.ToDecimal(pro11temp.Porcentaje), 2);

        //                    listaPro11temp.Add(pro11temp);
        //                }
        //            //}
        //            dbContext.Temp_PRO_11.AddRange(listaPro11temp);
        //            dbContext.SaveChanges();
        //            dbContextTransaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            dbContextTransaction.Rollback();

        //            throw ex;
        //        }
        //    }
        //}

        //public static void Insert_Temp_PRO_12(Plantilla plantilla, DateTime? fecha)
        //{
        //    Reports_IICSEntities dbContext = new Reports_IICSEntities();
        //    using (var dbContextTransaction = dbContext.Database.BeginTransaction())
        //    {
        //        try
        //        {
        //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
        //            dbContext.Temp_PRO_12.RemoveRange(dbContext.Temp_PRO_12.Where(p => p.CodigoIC == plantilla.CodigoIc));

        //            List<Temp_PRO_12> listaPro12temp = new List<Temp_PRO_12>();

        //            var isins = plantilla.Plantillas_Generaciones_Plantilla.FirstOrDefault().Plantilla.Plantillas_Generaciones_Isins.Select(p => p.Isin);
        //            var listaIsins = Utils.GetIsinsGeneradosSiEsFondo(plantilla.IdTipo, isins);
        //            foreach (var isin in listaIsins)
        //            {
        //                DataTable dt = Reports_DA.GetPRO12(plantilla.CodigoIc, isin, Convert.ToDateTime(fecha));
        //                //var pro12Result = dbContext.PRO_12(plantilla.CodigoIc, isin.Isin, fecha).FirstOrDefault();
        //                //if (pro12Result != null)
        //                if (dt != null && dt.Rows.Count > 0)
        //                {
        //                    Temp_PRO_12 pro12temp = new Temp_PRO_12();
        //                    //Copiamos el contenido de pro12Result en pro12temp
        //                    //Utils.CopyPropertyValues(pro12Result, pro12temp);
        //                    pro12temp.CodigoIC = plantilla.CodigoIc;
        //                    pro12temp.Isin = isin;
        //                    pro12temp.Rentabilidad = Utils.CheckDecimal(dt.Rows[0]["rentabilidad"].ToString());
        //                    pro12temp.TotalPatrimonio = Utils.CheckDecimal(dt.Rows[0]["patrimonio"].ToString());
        //                    pro12temp.TotalParticipaciones = Utils.CheckDecimal(dt.Rows[0]["participaciones"].ToString());
        //                    pro12temp.ValorLiquidativo = Utils.CheckDecimal(dt.Rows[0]["valliq"].ToString());
        //                    pro12temp.TAE = Utils.CheckDecimal(dt.Rows[0]["tae"].ToString());
        //                    pro12temp.SaldoTesoreria = Utils.CheckDecimal(dt.Rows[0]["saldotesor"].ToString());
        //                    pro12temp.ActivoComputable = Utils.CheckDecimal(dt.Rows[0]["activo"].ToString());

        //                    listaPro12temp.Add(pro12temp);
        //                }
        //            }

        //            dbContext.Temp_PRO_12.AddRange(listaPro12temp);
        //            dbContext.SaveChanges();
        //            dbContextTransaction.Commit();
        //        }
        //        catch (Exception ex)
        //        {
        //            dbContextTransaction.Rollback();

        //            throw ex;
        //        }
        //    }
        //}

        public static IQueryable<Temp_PRO_12> GetTemp_PRO_12(string codigoIC, string isin)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            var output = dbContext.Temp_PRO_12.Where(p => p.CodigoIC == codigoIC && p.Isin == isin);
            return output;
        }

        

        public static IQueryable<Temp_GraficoIBenchmark> GetTemp_GraficoIBenchmark(string codigoIC, string isin, DateTime fecha)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            if (isin != null)
            {
                return dbContext.Temp_GraficoIBenchmark.Where(b => b.CodigoIc == codigoIC && b.Isin == isin);
            }
            else
            {
                return dbContext.Temp_GraficoIBenchmark.Where(b => b.CodigoIc == codigoIC);
            }
        }
        
        //public static ObjectResult<PRO_04_Result> GetPRO04(string codigoIC, string isin, DateTime fecha)
        //{
        //    dbContext = new Reports_IICSEntities();
        //    return dbContext.PRO_04(codigoIC, isin, Convert.ToDateTime(fecha));
        //}

        public static bool RatiosCarteraRVGenerada(string codigoIC)
        {
            Reports_IICSEntities dbcontext = new Reports_IICSEntities();

            bool generada = false;

            if (dbcontext.Temp_RatiosCarteraRV.Where(t => t.CodigoIC == codigoIC).Count() > 0)
            {
                generada = true;
            }

            return generada;
        }

        
    }
}
