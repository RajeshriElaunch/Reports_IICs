using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;

namespace Reports_IICs.DataAccess.Bloomberg
{
    public static class ImportarBloomberg_DA
    {
        //private static Reports_IICSEntities dbContext = new Reports_IICSEntities();

        public static List<Reports_IICs.DataModels.Bloomberg> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            List<Reports_IICs.DataModels.Bloomberg> listaBloomberg = new List<Reports_IICs.DataModels.Bloomberg>();
            try
            {
                foreach (Reports_IICs.DataModels.Bloomberg item in dbContext.Bloombergs)
                {
                    listaBloomberg.Add(item);
                }
                return listaBloomberg;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string error = validationError.ErrorMessage + " " + validationError.PropertyName;
                    }
                }

                throw dbEx;
            }
            catch (Exception ex)
            {
                //dbContextTransaction.Rollback();

                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                log.Error("Error ImportarBloomberg/GetAll", ex);
                // Compliance                                           
                throw;
            }
            
        }

        //public static DataModels.Bloomberg GetByIsin(string isin)
        //{
        //    Reports_IICSEntities dbContext = new Reports_IICSEntities();
            
        //    try
        //    {
        //     var output = dbContext.Bloombergs.Where(b => b.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();
        //        return output;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Procedimiento para guardar la información Bloomberg importada a través de Excel
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static void GuardarBloomberg(DataTable dt, int año, int columnaEstimacion)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    //En cada importación se eliminarán los datos importados en la tabla.
                    dbContext.Bloombergs.RemoveRange(dbContext.Bloombergs);

                    //Aquí almacenaremos todos los instrumentos importados a guardar para hacerlo en una sola llamada a bd
                    List<Reports_IICs.DataModels.Bloomberg> listaBloomberg = new List<Reports_IICs.DataModels.Bloomberg>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Reports_IICs.DataModels.Bloomberg bloombergObject = new Reports_IICs.DataModels.Bloomberg();
                        bloombergObject.ISIN = dr["Isin"].ToString().ToUpper();
                        
                        bloombergObject.Año = año;
                        bloombergObject.ColumnaEstimacion = columnaEstimacion;
                        
                        bloombergObject.Capitalizacion = Utils.CheckDecimal(dr["Capitalización (millones)"].ToString());
                        bloombergObject.Bpa0 = Utils.CheckDecimal(dr["Bpa 0"].ToString());
                        bloombergObject.BpaPrevision1 = Utils.CheckDecimal(dr["Bpa previsión 1"].ToString());
                        bloombergObject.BpaPrevision2 = Utils.CheckDecimal(dr["Bpa previsión 2"].ToString());
                        bloombergObject.BpaPrevision3 = Utils.CheckDecimal(dr["Bpa previsión 3"].ToString());

                        var rd1 = Utils.CheckDecimal(dr["Rentabilidad dividendo 1"].ToString());
                        if (rd1 != null)
                        {
                            var rentabilidadDiv1 = rd1 * 100;
                            bloombergObject.RentabilidadDividendo1 = (rentabilidadDiv1 == null) ? (decimal?)null : decimal.Round(Convert.ToDecimal(rentabilidadDiv1), 1);
                        }

                        var rd2 = Utils.CheckDecimal(dr["Rentabilidad dividendo 2"].ToString());
                        if (rd2 != null)
                        {
                            var rentabilidadDiv2 = rd2 * 100;
                            bloombergObject.RentabilidadDividendo2 = (rentabilidadDiv2 == null) ? (decimal?)null : decimal.Round(Convert.ToDecimal(rentabilidadDiv2), 1);
                        }

                        var rd3 = Utils.CheckDecimal(dr["Rentabilidad dividendo 3"].ToString());
                        if (rd3 != null)
                        {
                            var rentabilidadDiv3 = rd3 * 100;
                            bloombergObject.RentabilidadDividendo3 = (rentabilidadDiv3 == null) ? (decimal?)null : decimal.Round(Convert.ToDecimal(rentabilidadDiv3), 1);
                        }

                        bloombergObject.Per1 = Utils.CheckDecimal(dr["Per 1"].ToString());
                        bloombergObject.Per2 = Utils.CheckDecimal(dr["Per 2"].ToString());
                        bloombergObject.Per3 = Utils.CheckDecimal(dr["Per 3"].ToString());
                        bloombergObject.DeudaNetaCapitalizacion = Utils.CheckDecimal(dr["Deuda neta / capitalización"].ToString());
                        bloombergObject.PrecioVc = Utils.CheckDecimal(dr["Precio / VC"].ToString());
                        bloombergObject.ValorFundamental = Utils.CheckDecimal(dr["Valor fundamental"].ToString());
                        bloombergObject.GvcBloomberg = !string.IsNullOrEmpty(dr["GVC o Bloomberg"].ToString()) ? dr["GVC o Bloomberg"].ToString() : string.Empty;

                        var df = Utils.CheckDecimal(dr["Descuento fundamental"].ToString());
                        if (df != null)
                        {
                            var dtoFundamental = df * 100;
                            bloombergObject.DescuentoFundamental = decimal.Round(Convert.ToDecimal(dtoFundamental), 1);
                        }

                        listaBloomberg.Add(bloombergObject);
                    }

                    dbContext.Bloombergs.AddRange(listaBloomberg);
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();                    
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            string error = validationError.ErrorMessage + " " + validationError.PropertyName;
                        }
                    }

                    throw dbEx;
                }
                catch (Exception ex)
                {
                    log.Error("Error Importing Data Bloomberg ", ex);

                    dbContextTransaction.Rollback();

                    //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                    //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                    log.Error("Error ImportarBloomberg/GuardarBloomberg", ex);
                    // Compliance                                           
                    throw;
                }
            }
        }

        public static bool GuardarBloombergs(List<Reports_IICs.DataModels.Bloomberg> listaBloomberg)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            //Primero borramos los existentes
            dbContext.Bloombergs.RemoveRange(dbContext.Bloombergs);
            dbContext.Bloombergs.AddRange(listaBloomberg);

            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        string error = validationError.ErrorMessage + " " + validationError.PropertyName;
                    }
                }

                throw dbEx;
            }
            catch (Exception ex)
            {
                log.Error("Error Importing Data Bloomberg ", ex);
                return false;
            }
        }
    }
}
