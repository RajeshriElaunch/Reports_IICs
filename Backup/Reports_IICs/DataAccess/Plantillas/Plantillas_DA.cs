using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;

namespace Reports_IICs.DataAccess.Plantillas
{
    public class Plantillas_DA
    {
        private static Reports_IICSEntities dbContext;

        public static IQueryable<Plantilla> GetAll()
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Plantillas.AsNoTracking();
        }

        public static List<Plantilla> GetGeneraciones()
        {
            List<Plantilla> ListaGeneraciones = new List<Plantilla>();

            dbContext = new Reports_IICSEntities();
            var ListaCodigos = dbContext.Plantillas_Generaciones.AsNoTracking().Select(c=>c.CodigoIC).Distinct();
            if (ListaCodigos != null)
            {
                foreach (string item in ListaCodigos)
                {
                    var selectedPlantilla = dbContext.Plantillas.AsNoTracking().Where(c => c.CodigoIc == item).FirstOrDefault();
                    ListaGeneraciones.Add(selectedPlantilla);
                }
            }
            
            return ListaGeneraciones;
        }

        public static IQueryable<Indices_Referencia_Tipos> GetIndices_Referencia_Tipos()
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Indices_Referencia_Tipos.AsNoTracking();
        }

        public static IQueryable<Plantillas_Isins> GetPlantillasIsins()
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Plantillas_Isins.AsNoTracking();
        }

        public static IQueryable<Plantillas_Secciones> GetPlantillasSecciones()
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Plantillas_Secciones.AsNoTracking();
        }

        public static IQueryable<Plantillas_Participes> GetPlantillasParticipes()
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Plantillas_Participes.AsNoTracking();
        }
        
        public static Plantilla GetPlantilla(string codigoIc)
        {            
            try
            {
                dbContext = new Reports_IICSEntities();
                //return dbContext.Plantillas.FirstOrDefault(p => p.CodigoIc == codigoIc).;
                return dbContext.Plantillas.AsNoTracking().FirstOrDefault(p => p.CodigoIc == codigoIc);
            }
            catch (Exception ex)
            {
                //Siempre que se captura una excepción se debe realizar un rethrow de la excepción para no perder la 
                //trazabilidad del error y no se debe realizar un throw de la excepción capturada
                log.Error("Plantillas_DA/GetPlantilla", ex);
                // Compliance                                           
                throw;
            }
        }

        /// <summary>
        /// Comprueba si existe una Plantilla con el mismo CodigoIc
        /// </summary>
        /// <param name="codigoIc"></param>
        /// <returns></returns>
        public static bool CheckIfExistsCodigoIc(string codigoIc)
        {
            dbContext = new Reports_IICSEntities();
            if (dbContext.Plantillas.Any(p => p.CodigoIc == codigoIc))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static List<Plantillas_Isins> GetIsinsByIdPlantilla(string codigoIc)
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Plantillas_Isins.AsNoTracking().Where(p => p.CodigoIc == codigoIc).ToList();
        }

        public static void RemoveIsinsByCodigoIc(string codigoIc)
        {
            dbContext = new Reports_IICSEntities();
            dbContext.Plantillas_Isins.RemoveRange(dbContext.Plantillas_Isins.Where(p => p.CodigoIc == codigoIc));
        }

        public static void RemovePlantillasSeccionesByCodigoIc(string codigoIc)
        {
            dbContext = new Reports_IICSEntities();
            dbContext.Plantillas_Secciones.RemoveRange(dbContext.Plantillas_Secciones.Where(p => p.CodigoIc == codigoIc));
        }
      

        public static void DeleteParametros_DividendosCobrados(Parametros_DividendosCobrados itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramDividendosCobrados = dbContext.Parametros_DividendosCobrados.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramDividendosCobrados != null)
                {
                    dbContext.Parametros_DividendosCobrados.Remove(DEL_paramDividendosCobrados);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }


        }


        public static void DeleteParametros_RVComprasRealizadasEjercicio(Parametros_RVComprasRealizadasEjercicio itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramRVComprasRealizadasEjercicio = dbContext.Parametros_RVComprasRealizadasEjercicio.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramRVComprasRealizadasEjercicio != null)
                {
                    dbContext.Parametros_RVComprasRealizadasEjercicio.Remove(DEL_paramRVComprasRealizadasEjercicio);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }


        }

        public static void DeleteParametros_IIC_ComprasVentasEjercicio(Parametros_IIC_ComprasVentasEjercicio itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramIIC_ComprasVentasEjercicio = dbContext.Parametros_IIC_ComprasVentasEjercicio.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramIIC_ComprasVentasEjercicio != null)
                {
                    dbContext.Parametros_IIC_ComprasVentasEjercicio.Remove(DEL_paramIIC_ComprasVentasEjercicio);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }
        }

        public static void DeleteParametros_OperacionesRentaVariable_II(Parametros_OperacionesRentaVariable_II itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_param = dbContext.Parametros_OperacionesRentaVariable_II.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_param != null)
                {
                    dbContext.Parametros_OperacionesRentaVariable_II.Remove(DEL_param);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }
        }

        public static void DeleteParametros_RentabilidadCarteraII(Parametros_Rentabilidad_CarteraII itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramRentabilidadCarteraII = dbContext.Parametros_Rentabilidad_CarteraII.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramRentabilidadCarteraII != null)
                {
                    dbContext.Parametros_Rentabilidad_CarteraII.Remove(DEL_paramRentabilidadCarteraII);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }


        }


        public static void DeleteParametros_RFComprasVentasEjercicio(Parametros_RFComprasVentasEjercicio itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramEvolucionMercados = dbContext.Parametros_RFComprasVentasEjercicio.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramEvolucionMercados != null)
                {
                    dbContext.Parametros_RFComprasVentasEjercicio.Remove(DEL_paramEvolucionMercados);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }


        }


        public static void DeleteParametros_EvolucionMercados(Parametros_EvolucionMercados itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramEvolucionMercados = dbContext.Parametros_EvolucionMercados.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramEvolucionMercados != null)
                {
                    dbContext.Parametros_EvolucionMercados.Remove(DEL_paramEvolucionMercados);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }


        }

        public static void DeleteParametros_DistribucionPatrimonioNovarex(Parametros_DistribucionPatrimonioNovarex itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramDistribPatriNovarex = dbContext.Parametros_DistribucionPatrimonioNovarex.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramDistribPatriNovarex != null)
                {
                    dbContext.Parametros_DistribucionPatrimonioNovarex.Remove(DEL_paramDistribPatriNovarex);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }


        }
        
        public static void DeleteParametros_RatiosCarteraRV(Parametros_RatiosCarteraRV itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramRatiosCartera = dbContext.Parametros_RatiosCarteraRV.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramRatiosCartera != null)
                {
                    dbContext.Parametros_RatiosCarteraRV.Remove(DEL_paramRatiosCartera);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();
                    
                }

                catch (System.Exception)
                {
                    
                }
               
            }

            
        }

        public static void DeleteParametros_GraficoBenchmark(Parametros_GraficoBenchmark itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramGraficoBenchmark = dbContext.Parametros_GraficoBenchmark.Where(n => n.CodigoIc == itemtodelete.CodigoIc).FirstOrDefault();
                if (DEL_paramGraficoBenchmark != null)
                {
                    dbContext.Parametros_GraficoBenchmark.Remove(DEL_paramGraficoBenchmark);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }
               
            }
            
        }

        public static void DeleteParametros_VariacionPatrimonialB(Parametros_VariacionPatrimonialB itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramVariacionPatrimonialB = dbContext.Parametros_VariacionPatrimonialB.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramVariacionPatrimonialB != null)
                {
                    dbContext.Parametros_VariacionPatrimonialB.Remove(DEL_paramVariacionPatrimonialB);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }

        }

        public static void DeleteParametros_IndicePreconfiguradoNovarex(Parametros_IndicePreconfiguradoNovarex itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramIndicePreconfiguradoNovarex = dbContext.Parametros_IndicePreconfiguradoNovarex.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramIndicePreconfiguradoNovarex != null)
                {
                    dbContext.Parametros_IndicePreconfiguradoNovarex.Remove(DEL_paramIndicePreconfiguradoNovarex);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }

        }
        
        public static void DeleteParametros_EvolucionRentabGuissonaFondos(Parametros_EvolucionRentabilidadGuissona_Fondos itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramEvolucionRentabGuissonaFondos = dbContext.Parametros_EvolucionRentabilidadGuissona_Fondos.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramEvolucionRentabGuissonaFondos != null)
                {
                    dbContext.Parametros_EvolucionRentabilidadGuissona_Fondos.Remove(DEL_paramEvolucionRentabGuissonaFondos);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }

        }

        public static void DeleteParametros_EvolucionPatrimConjGuissonaFondos(Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramEvolucionPatrimConjGuissonaFondos = dbContext.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramEvolucionPatrimConjGuissonaFondos != null)
                {
                    dbContext.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Remove(DEL_paramEvolucionPatrimConjGuissonaFondos);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }

        }
        
        public static void DeleteParametros_EvolucionRentabGuissona(Parametros_EvolucionRentabilidadGuissona itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramEvolucionRentabGuissona = dbContext.Parametros_EvolucionRentabilidadGuissona.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramEvolucionRentabGuissona != null)
                {
                    dbContext.Parametros_EvolucionRentabilidadGuissona.Remove(DEL_paramEvolucionRentabGuissona);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }

        }

        public static void DeleteParametros_EvolucionPatrimConjGuissona(Parametros_EvolucionPatrimonioConjuntoGuissona itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramEvolucionPatrimConjGuissona = dbContext.Parametros_EvolucionPatrimonioConjuntoGuissona.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramEvolucionPatrimConjGuissona != null)
                {
                    dbContext.Parametros_EvolucionPatrimonioConjuntoGuissona.Remove(DEL_paramEvolucionPatrimConjGuissona);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }

        }
        
        public static void DeleteParametros_EvolucionPatrimGuissona(Parametros_EvolucionPatrimGuissona itemtodelete)
        {
            dbContext = new Reports_IICSEntities();
            if (itemtodelete != null)
            {
                var DEL_paramEvolucionPatrimGuissona = dbContext.Parametros_EvolucionPatrimGuissona.Where(n => n.CodigoIC == itemtodelete.CodigoIC).FirstOrDefault();
                if (DEL_paramEvolucionPatrimGuissona != null)
                {
                    dbContext.Parametros_EvolucionPatrimGuissona.Remove(DEL_paramEvolucionPatrimGuissona);
                }
                try
                {
                    //save changues to Db
                    dbContext.SaveChanges();

                }

                catch (System.Exception)
                {

                }

            }

        }
        
        public static void InsertPlantillasIsins(List<Plantillas_Isins> listaIsins)
        {
            dbContext = new Reports_IICSEntities();
            listaIsins.ForEach(f => f.FechaModificacion = DateTime.Now);
            dbContext.Plantillas_Isins.AddRange(listaIsins);
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        

        public static void SavePlantilla2(Plantilla plantilla)
        {
            dbContext = new Reports_IICSEntities();
            /*try
            {
                
                var obj = dbContext.Plantillas.Where(w => w.CodigoIc == plantilla.CodigoIc).Include("Plantillas_Indices_Referencia").AsNoTracking().FirstOrDefault();

                dbContext.Entry(plantilla).State = EntityState.Detached;
                dbContext.SaveChanges();

                obj = plantilla;
                dbContext.Entry(obj).State = EntityState.Modified;
                dbContext.SaveChanges();

                
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                log.Error("Error Generando Datos Temporales" + fullErrorMessage, ex);
                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (DbUpdateException ex)
            {
                //comprobamos en qué tabla/s se está produciendo el error
                var entidades = ex.Entries;
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }*/
            
            try
            {
                //No tiene ningún sentido pero algunas foreign entities de la plantilla se pierden cuando 
                //actualizamos los cambios. Esto no ocurre si accedemos a esas entidades de alguna forma
                //antes de actualizar. Es por esto que hacemos lo siguiente:
                checkParameters(plantilla);               
                
                var obj = dbContext.Plantillas.Where(w => w.CodigoIc == plantilla.CodigoIc).FirstOrDefault();
                if (obj != null)
                {
                    dbContext.Plantillas.Remove(obj);
                }
                
                dbContext.Plantillas.Add(plantilla);

                foreach (var entry in dbContext.ChangeTracker.Entries().Where(x => typeof(Seccione).IsAssignableFrom(x.Entity.GetType())))
                {
                    entry.State = EntityState.Detached;
                }

                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                log.Error("Error Generando Datos Temporales" + fullErrorMessage, ex);
                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
            catch (DbUpdateException ex)
            {
                //comprobamos en qué tabla/s se está produciendo el error
                var entidades = ex.Entries;
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// No tiene ningún sentido pero algunas foreign entities de la plantilla se pierden cuando actualizamos los cambios. Esto no ocurre si accedemos a esas entidades de alguna forma antes de actualizar. Es por esto que utilizamos este método antes de guardar la plantilla
        /// </summary>
        private static void checkParameters(Plantilla plantilla)
        {
            plantilla.Parametros_CarteraRF.Count();
            plantilla.Parametros_CompraVentaPrecAdq.Count();
            plantilla.Parametros_DistribucionPatrimonioNovarex.Count();
            plantilla.Parametros_DistribucionPatrimonioNovarex_Tipos.Count();
            //plantilla.Parametros_Diversificacion.Count();
            //plantilla.Parametros_Diversificacion_Instrumentos.Count();
            //plantilla.Parametros_Diversificacion_Instrumentos_Divisas.Count();
            plantilla.Parametros_DividendosCobrados.Count();
            plantilla.Parametros_EvolucionMercados.Count();
            plantilla.Parametros_EvolucionPatrimGuissona.Count();
            plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Count();
            plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Count();
            plantilla.Parametros_EvolucionRentabilidadGuissona.Count();
            plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.Count();
            plantilla.Parametros_GraficoBenchmark.Count();
            plantilla.Parametros_GraficoBenchmark_Indices.Count();
            plantilla.Parametros_GraficoCompPatrimonioTipoProducto.Count();
            plantilla.Parametros_IIC_ComprasVentasEjercicio.Count();
            plantilla.Parametros_IndicePreconfiguradoNovarex.Count();
            plantilla.Parametros_IndicePreconfiguradoNovarex_Otros.Count();
            plantilla.Parametros_OperacionesRentaVariable_II.Count();
            //plantilla.Parametros_Participes.Count();
            //plantilla.Parametros_ParticipesSalat_Participes.Count();
            plantilla.Parametros_PlusvaliasDividendos.Count();
            //plantilla.Parametros_PlusvaliasDividendos_ISINS.Count();
            plantilla.Parametros_RatiosCarteraRV.Count();
            plantilla.Parametros_Rentabilidad_CarteraII.Count();
            plantilla.Parametros_RFComprasVentasEjercicio.Count();
            plantilla.Parametros_RVComprasRealizadasEjercicio.Count();
            plantilla.Parametros_VariacionPatrimonialB.Count();
            //plantilla.ParamPredet_EvolucionMercados.Count()));
            plantilla.RentabilidadCarteraSolemegs.Count();
        }
        public static bool SavePlantilla(Plantilla plantilla,string CodigoIcBeforeUpdate,out Plantilla plantillaUpdated)
        {
            //Plantilla plantillaObject;
            bool result = false;
            try
            {
                using (dbContext = new Reports_IICSEntities())
                {
                   
                    var plantillaObject = dbContext.Plantillas.SingleOrDefault(c => c.CodigoIc == plantilla.CodigoIc);

                    var plantillaSpecialCases = plantillaObject;
                    List<Plantillas_Secciones> Plant_secciones_before_update = new List<Plantillas_Secciones>();

                    if(plantillaSpecialCases!=null)
                    {
                        foreach (var item in plantillaSpecialCases.Plantillas_Secciones)
                        {
                            Plant_secciones_before_update.Add(item);
                        }
                    }
                    

                    Plantilla PlantillaSC = plantilla;
                    if (plantilla.CodigoIc!= CodigoIcBeforeUpdate)
                    {
                        //Se ha cambiado la clave primaria
                        Plantilla plantillaToDelete = plantilla;
                        plantillaToDelete.CodigoIc = CodigoIcBeforeUpdate;
                        DeletePlantilla(plantillaToDelete);
                        plantillaObject = plantilla;
                        dbContext.Plantillas.Add(plantillaObject);
                    }
                    else
                    {
                        
                        #region Update
                        if (plantillaObject != null)
                        {
                            //plantillaObject = plantilla no funciona con el UPDATE. Así que hace aquí un clone manual
                            plantillaObject.CodigoIc = plantilla.CodigoIc;
                            plantillaObject.FechaCreacion = plantilla.FechaCreacion;
                            plantillaObject.Descripcion = plantilla.Descripcion;
                            plantillaObject.IdTipo = plantilla.IdTipo;
                            plantillaObject.ReferenciaTAE = plantilla.ReferenciaTAE;
                            //plantillaObject.Tipos = plantilla.Tipos;


                            #region Secciones
                            #region Remove
                            List<Plantillas_Secciones> SeccionToDelete = new List<Plantillas_Secciones>();

                            foreach (var item in plantillaObject.Plantillas_Secciones)
                            {
                                var originalItem = plantilla.Plantillas_Secciones.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    SeccionToDelete.Add(item);
                                }
                            }

                            foreach (var item in SeccionToDelete)
                            {
                                var itemtoDelete = plantillaObject.Plantillas_Secciones.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var seccionEntry = dbContext.Entry(itemtoDelete);
                                    seccionEntry.State = EntityState.Deleted;
                                    plantilla.Plantillas_Secciones.Remove(itemtoDelete);

                                }

                            }

                            #endregion
                            #region Add/Edit
                            List<Plantillas_Secciones> Plantillas_before_update = new List<Plantillas_Secciones>();
                            int order = 1;
                            foreach (var item in plantillaObject.Plantillas_Secciones)
                            {
                                item.Orden = order;
                                Plantillas_before_update.Add(item);
                                order++;
                            }

                            order = 1;

                            foreach (var item in plantilla.Plantillas_Secciones)
                            {
                                var originalItem = Plantillas_before_update.SingleOrDefault(i => i.Id == item.Id);

                                if (originalItem != null)
                                {
                                    var seccionEntry = dbContext.Entry(originalItem);
                                    //item.Orden = order;
                                    seccionEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Plantillas_Secciones newitem = new Plantillas_Secciones();
                                    newitem = item;

                                    if (newitem.Orden == null) newitem.Orden = order;
                                    plantillaObject.Plantillas_Secciones.Add(newitem);
                                }
                                order++;
                            }
                            #endregion
                            #endregion

                            #region Indices
                            #region Remove
                            List<Plantillas_Indices_Referencia> indicesToDelete = new List<Plantillas_Indices_Referencia>();

                            foreach (var item in plantillaObject.Plantillas_Indices_Referencia)
                            {
                                var originalItem = plantilla.Plantillas_Indices_Referencia.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    indicesToDelete.Add(item);
                                }
                            }

                            foreach (var item in indicesToDelete)
                            {
                                var itemtoDelete = plantillaObject.Plantillas_Indices_Referencia.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var indiceEntry = dbContext.Entry(itemtoDelete);
                                    indiceEntry.State = EntityState.Deleted;
                                    plantilla.Plantillas_Indices_Referencia.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit
                            List<Plantillas_Indices_Referencia> PlantillasIndices_Referencia_before_update = new List<Plantillas_Indices_Referencia>();
                            foreach (var item in plantillaObject.Plantillas_Indices_Referencia)
                            {
                                PlantillasIndices_Referencia_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Plantillas_Indices_Referencia)
                            {
                                var originalItem = PlantillasIndices_Referencia_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var indiceEntry = dbContext.Entry(originalItem);
                                    indiceEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Plantillas_Indices_Referencia newPlantIndRefitem = new Plantillas_Indices_Referencia();
                                    newPlantIndRefitem = item;
                                    plantillaObject.Plantillas_Indices_Referencia.Add(newPlantIndRefitem);
                                }

                            }
                            #endregion
                            #endregion

                            #region Isins
                            #region Remove
                            List<Plantillas_Isins> IsinToDelete = new List<Plantillas_Isins>();

                            foreach (var item in plantillaObject.Plantillas_Isins)
                            {
                                var originalItem = plantilla.Plantillas_Isins.SingleOrDefault(i => i.IdPlantillaIsin == item.IdPlantillaIsin);
                                if (originalItem == null)
                                {
                                    IsinToDelete.Add(item);
                                }
                            }

                            foreach (var item in IsinToDelete)
                            {
                                var itemtoDelete = plantillaObject.Plantillas_Isins.SingleOrDefault(i => i.IdPlantillaIsin == item.IdPlantillaIsin);
                                if (itemtoDelete != null)
                                {
                                    var isinEntry = dbContext.Entry(itemtoDelete);
                                    isinEntry.State = EntityState.Deleted;
                                    plantilla.Plantillas_Isins.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit
                            List<Plantillas_Isins> PlantillasIsins_before_update = new List<Plantillas_Isins>();
                            foreach (var item in plantillaObject.Plantillas_Isins)
                            {
                                PlantillasIsins_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Plantillas_Isins)
                            {
                                var originalItem = PlantillasIsins_before_update.SingleOrDefault(i => i.IdPlantillaIsin == item.IdPlantillaIsin);
                                if (originalItem != null)
                                {
                                    var isinEntry = dbContext.Entry(originalItem);
                                    isinEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Plantillas_Isins newitemPlIsin = new Plantillas_Isins();
                                    newitemPlIsin = item;
                                    plantillaObject.Plantillas_Isins.Add(newitemPlIsin);
                                }

                            }
                            #endregion
                            #endregion

                            #region Participes
                            #region Remove
                            List<Plantillas_Participes> ParticipeToDelete = new List<Plantillas_Participes>();

                            foreach (var item in plantillaObject.Plantillas_Participes)
                            {
                                var originalItem = plantilla.Plantillas_Participes.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    ParticipeToDelete.Add(item);
                                }
                            }

                            foreach (var item in ParticipeToDelete)
                            {
                                var itemtoDelete = plantillaObject.Plantillas_Participes.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var participeEntry = dbContext.Entry(itemtoDelete);
                                    participeEntry.State = EntityState.Deleted;
                                    plantilla.Plantillas_Participes.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit
                            List<Plantillas_Participes> PlantillasParticipes_before_update = new List<Plantillas_Participes>();
                            foreach (var item in plantillaObject.Plantillas_Participes)
                            {
                                PlantillasParticipes_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Plantillas_Participes)
                            {
                                var originalItem = PlantillasParticipes_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var participeEntry = dbContext.Entry(originalItem);
                                    participeEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Plantillas_Participes newitemPlParticipes = new Plantillas_Participes();
                                    newitemPlParticipes = item;
                                    plantillaObject.Plantillas_Participes.Add(newitemPlParticipes);
                                }

                            }
                            #endregion
                            #endregion

                            #region GraficoBenchmark
                            if (plantilla.Plantillas_Secciones.Any(a => a.IdSeccion == 25))
                            {
                                #region Remove
                                List<Parametros_GraficoBenchmark> GraficoBenchmarkToDelete = new List<Parametros_GraficoBenchmark>();

                                foreach (var item in plantillaObject.Parametros_GraficoBenchmark)
                                {
                                    var originalItem = plantilla.Parametros_GraficoBenchmark.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem == null)
                                    {
                                        GraficoBenchmarkToDelete.Add(item);
                                    }
                                }

                                foreach (var item in GraficoBenchmarkToDelete)
                                {
                                    var itemtoDelete = plantillaObject.Parametros_GraficoBenchmark.SingleOrDefault(i => i.Id == item.Id);
                                    if (itemtoDelete != null)
                                    {
                                        var GraficoBenchmarkEntry = dbContext.Entry(itemtoDelete);
                                        GraficoBenchmarkEntry.State = EntityState.Deleted;
                                        plantilla.Parametros_GraficoBenchmark.Remove(itemtoDelete);
                                    }
                                }

                                #endregion
                                #region Add/Edit
                                List<Parametros_GraficoBenchmark> PlantillasParam_GraficoBenchmark_before_update = new List<Parametros_GraficoBenchmark>();
                                foreach (var item in plantillaObject.Parametros_GraficoBenchmark)
                                {
                                    PlantillasParam_GraficoBenchmark_before_update.Add(item);
                                }

                                foreach (var item in plantilla.Parametros_GraficoBenchmark)
                                {
                                    var originalItem = PlantillasParam_GraficoBenchmark_before_update.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem != null)
                                    {
                                        var GraficoBenchmarkEntry = dbContext.Entry(originalItem);
                                        GraficoBenchmarkEntry.CurrentValues.SetValues(item);
                                    }
                                    else
                                    {
                                        Parametros_GraficoBenchmark newitemParamBenchmark = new Parametros_GraficoBenchmark();
                                        newitemParamBenchmark = item;
                                        plantillaObject.Parametros_GraficoBenchmark.Add(newitemParamBenchmark);
                                    }

                                }
                                #endregion

                                #endregion

                                #region Parametros_GraficoBenchmark_Indices 

                                #region Remove
                                List<Parametros_GraficoBenchmark_Indices> GraficoBenchmarkIndicesToDelete = new List<Parametros_GraficoBenchmark_Indices>();

                                foreach (var item in plantillaObject.Parametros_GraficoBenchmark_Indices)
                                {
                                    var originalItem = plantilla.Parametros_GraficoBenchmark_Indices.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem == null)
                                    {
                                        GraficoBenchmarkIndicesToDelete.Add(item);
                                    }
                                }

                                foreach (var item in GraficoBenchmarkToDelete)
                                {
                                    var itemtoDelete = plantillaObject.Parametros_GraficoBenchmark_Indices.SingleOrDefault(i => i.Id == item.Id);
                                    if (itemtoDelete != null)
                                    {
                                        var GraficoBenchmarkIndicesEntry = dbContext.Entry(itemtoDelete);
                                        GraficoBenchmarkIndicesEntry.State = EntityState.Deleted;
                                        plantilla.Parametros_GraficoBenchmark_Indices.Remove(itemtoDelete);
                                    }
                                }

                                #endregion

                                #region Add/Edit
                                List<Parametros_GraficoBenchmark_Indices> PlantillasParam_GraficoBenchmarkIndices_before_update = new List<Parametros_GraficoBenchmark_Indices>();
                                foreach (var item in plantillaObject.Parametros_GraficoBenchmark_Indices)
                                {
                                    PlantillasParam_GraficoBenchmarkIndices_before_update.Add(item);
                                }

                                foreach (var item in plantilla.Parametros_GraficoBenchmark_Indices)
                                {
                                    var originalItem = PlantillasParam_GraficoBenchmarkIndices_before_update.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem != null)
                                    {
                                        var GraficoBenchmarkIndicesEntry = dbContext.Entry(originalItem);
                                        GraficoBenchmarkIndicesEntry.CurrentValues.SetValues(item);
                                    }
                                    else
                                    {
                                        var newitemParamBenchmarkIndices = new Parametros_GraficoBenchmark_Indices();
                                        newitemParamBenchmarkIndices = item;
                                        plantillaObject.Parametros_GraficoBenchmark_Indices.Add(newitemParamBenchmarkIndices);
                                    }

                                }
                                #endregion
                            }
                            #endregion

                            #region EvolucionPatrimGuissona
                            if (plantilla.Plantillas_Secciones.Any(a => a.IdSeccion == 29))
                            {
                                #region Remove
                                List<Parametros_EvolucionPatrimGuissona> EvolucionPatrimGuissonaToDelete = new List<Parametros_EvolucionPatrimGuissona>();

                                foreach (var item in plantillaObject.Parametros_EvolucionPatrimGuissona)
                                {
                                    var originalItem = plantilla.Parametros_EvolucionPatrimGuissona.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem == null)
                                    {
                                        EvolucionPatrimGuissonaToDelete.Add(item);
                                    }
                                }

                                foreach (var item in EvolucionPatrimGuissonaToDelete)
                                {
                                    var itemtoDelete = plantillaObject.Parametros_EvolucionPatrimGuissona.SingleOrDefault(i => i.Id == item.Id);
                                    if (itemtoDelete != null)
                                    {
                                        var EvolucionPatrimGuissonaEntry = dbContext.Entry(itemtoDelete);
                                        EvolucionPatrimGuissonaEntry.State = EntityState.Deleted;
                                        plantilla.Parametros_EvolucionPatrimGuissona.Remove(itemtoDelete);
                                    }

                                }

                                #endregion
                                #region Add/Edit
                                List<Parametros_EvolucionPatrimGuissona> PlantillasParam_EvolucionPatrimGuissona_before_update = new List<Parametros_EvolucionPatrimGuissona>();
                                foreach (var item in plantillaObject.Parametros_EvolucionPatrimGuissona)
                                {
                                    PlantillasParam_EvolucionPatrimGuissona_before_update.Add(item);
                                }

                                foreach (var item in plantilla.Parametros_EvolucionPatrimGuissona)
                                {
                                    var originalItem = PlantillasParam_EvolucionPatrimGuissona_before_update.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem != null)
                                    {
                                        var EvolucionPatrimGuissonaEntry = dbContext.Entry(originalItem);
                                        EvolucionPatrimGuissonaEntry.CurrentValues.SetValues(item);
                                    }
                                    else
                                    {
                                        Parametros_EvolucionPatrimGuissona newitemParamEvolucionPatrimGuissona = new Parametros_EvolucionPatrimGuissona();
                                        newitemParamEvolucionPatrimGuissona = item;
                                        plantillaObject.Parametros_EvolucionPatrimGuissona.Add(newitemParamEvolucionPatrimGuissona);
                                    }

                                }
                                #endregion
                            }
                            #endregion

                            #region RatiosCarteraRV
                            if (plantilla.Plantillas_Secciones.Any(a => a.IdSeccion == 36))
                            {
                                #region Remove
                                List<Parametros_RatiosCarteraRV> RatiosCarteraRVToDelete = new List<Parametros_RatiosCarteraRV>();

                                foreach (var item in plantillaObject.Parametros_RatiosCarteraRV)
                                {
                                    var originalItem = plantilla.Parametros_RatiosCarteraRV.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem == null)
                                    {
                                        RatiosCarteraRVToDelete.Add(item);
                                    }
                                }

                                foreach (var item in RatiosCarteraRVToDelete)
                                {
                                    var itemtoDelete = plantillaObject.Parametros_RatiosCarteraRV.SingleOrDefault(i => i.Id == item.Id);
                                    if (itemtoDelete != null)
                                    {
                                        var RatiosCarteraRVEntry = dbContext.Entry(itemtoDelete);
                                        RatiosCarteraRVEntry.State = EntityState.Deleted;
                                        plantilla.Parametros_RatiosCarteraRV.Remove(itemtoDelete);
                                    }
                                }

                                #endregion
                                #region Add/Edit

                                List<Parametros_RatiosCarteraRV> PlantillasParam_RatiosCarteraRV_before_update = new List<Parametros_RatiosCarteraRV>();
                                foreach (var item in plantillaObject.Parametros_RatiosCarteraRV)
                                {
                                    PlantillasParam_RatiosCarteraRV_before_update.Add(item);
                                }
                                foreach (var item in plantilla.Parametros_RatiosCarteraRV)
                                {
                                    var originalItem = plantillaObject.Parametros_RatiosCarteraRV.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem != null)
                                    {
                                        var RatiosCarteraRVEntry = dbContext.Entry(originalItem);
                                        RatiosCarteraRVEntry.CurrentValues.SetValues(item);
                                    }
                                    else
                                    {
                                        Parametros_RatiosCarteraRV newitemParamCartera = new Parametros_RatiosCarteraRV();
                                        newitemParamCartera = item;
                                        plantillaObject.Parametros_RatiosCarteraRV.Add(newitemParamCartera);
                                    }

                                }
                                #endregion
                            }
                            #endregion

                            #region EvolucionMercados
                                #region Remove
                                List<Parametros_EvolucionMercados> EvolucionMercadosToDelete = new List<Parametros_EvolucionMercados>();

                                foreach (var item in plantillaObject.Parametros_EvolucionMercados)
                                {
                                    var originalItem = plantilla.Parametros_EvolucionMercados.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem == null)
                                    {
                                        EvolucionMercadosToDelete.Add(item);
                                    }
                                }

                                foreach (var item in EvolucionMercadosToDelete)
                                {
                                    var itemtoDelete = plantillaObject.Parametros_EvolucionMercados.SingleOrDefault(i => i.Id == item.Id);
                                    if (itemtoDelete != null)
                                    {
                                        var EvolucionMercadosEntry = dbContext.Entry(itemtoDelete);
                                        EvolucionMercadosEntry.State = EntityState.Deleted;
                                        plantilla.Parametros_EvolucionMercados.Remove(itemtoDelete);
                                    }
                                }

                                #endregion
                                #region Add/Edit

                                List<Parametros_EvolucionMercados> PlantillasParam_EvolucionMercados_before_update = new List<Parametros_EvolucionMercados>();
                                foreach (var item in plantillaObject.Parametros_EvolucionMercados)
                                {
                                    PlantillasParam_EvolucionMercados_before_update.Add(item);
                                }
                                foreach (var item in plantilla.Parametros_EvolucionMercados)
                                {
                                    var originalItem = PlantillasParam_EvolucionMercados_before_update.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem != null)
                                    {
                                        var EvolucionMercadosEntry = dbContext.Entry(originalItem);
                                        EvolucionMercadosEntry.CurrentValues.SetValues(item);
                                    }
                                    else
                                    {
                                        Parametros_EvolucionMercados newitemParamEvolucionMercados = new Parametros_EvolucionMercados();
                                        newitemParamEvolucionMercados = item;
                                        plantillaObject.Parametros_EvolucionMercados.Add(newitemParamEvolucionMercados);
                                    }

                                }
                            #endregion
                            #endregion

                            #region EvolucionRentabilidadGuissona

                            #region Remove
                            List<Parametros_EvolucionRentabilidadGuissona> EvolucionRentabilidadGuissonaToDelete = new List<Parametros_EvolucionRentabilidadGuissona>();

                            foreach (var item in plantillaObject.Parametros_EvolucionRentabilidadGuissona)
                            {
                                var originalItem = plantilla.Parametros_EvolucionRentabilidadGuissona.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    EvolucionRentabilidadGuissonaToDelete.Add(item);
                                }
                            }

                            foreach (var item in EvolucionRentabilidadGuissonaToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_EvolucionRentabilidadGuissona.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var EvolucionRentabilidadGuissonaEntry = dbContext.Entry(itemtoDelete);
                                    EvolucionRentabilidadGuissonaEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_EvolucionRentabilidadGuissona.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_EvolucionRentabilidadGuissona> PlantillasParam_EvolucionRentabilidadGuissona_before_update = new List<Parametros_EvolucionRentabilidadGuissona>();
                            foreach (var item in plantillaObject.Parametros_EvolucionRentabilidadGuissona)
                            {
                                PlantillasParam_EvolucionRentabilidadGuissona_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_EvolucionRentabilidadGuissona)
                            {
                                var originalItem = PlantillasParam_EvolucionRentabilidadGuissona_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var EvolucionRentabilidadGuissonaEntry = dbContext.Entry(originalItem);
                                    EvolucionRentabilidadGuissonaEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_EvolucionRentabilidadGuissona newitemParamEvolucionRentabilidadGuissona = new Parametros_EvolucionRentabilidadGuissona();
                                    newitemParamEvolucionRentabilidadGuissona = item;
                                    plantillaObject.Parametros_EvolucionRentabilidadGuissona.Add(newitemParamEvolucionRentabilidadGuissona);
                                }

                            }
                            #endregion
                            #endregion

                            #region EvolucionRentabilidadGuissonaFondos

                            #region Remove
                            List<Parametros_EvolucionRentabilidadGuissona_Fondos> EvolucionRentabGuissonaFondosToDelete = new List<Parametros_EvolucionRentabilidadGuissona_Fondos>();

                            foreach (var item in plantillaObject.Parametros_EvolucionRentabilidadGuissona_Fondos)
                            {
                                var originalItem = plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    EvolucionRentabGuissonaFondosToDelete.Add(item);
                                }
                            }

                            foreach (var item in EvolucionRentabGuissonaFondosToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_EvolucionRentabilidadGuissona_Fondos.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var EvolucionRentabGuissonaFondosEntry = dbContext.Entry(itemtoDelete);
                                    EvolucionRentabGuissonaFondosEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_EvolucionRentabilidadGuissona_Fondos> PlantillasParam_EvolucionRentabGuissonaFondos_before_update = new List<Parametros_EvolucionRentabilidadGuissona_Fondos>();
                            foreach (var item in plantillaObject.Parametros_EvolucionRentabilidadGuissona_Fondos)
                            {
                                PlantillasParam_EvolucionRentabGuissonaFondos_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos)
                            {
                                var originalItem = PlantillasParam_EvolucionRentabGuissonaFondos_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var EvolucionRentabGuissonaFondosEntry = dbContext.Entry(originalItem);
                                    EvolucionRentabGuissonaFondosEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_EvolucionRentabilidadGuissona_Fondos newitemParamEvolucionRentabGuissonaFondos = new Parametros_EvolucionRentabilidadGuissona_Fondos();
                                    newitemParamEvolucionRentabGuissonaFondos = item;
                                    plantillaObject.Parametros_EvolucionRentabilidadGuissona_Fondos.Add(newitemParamEvolucionRentabGuissonaFondos);
                                }

                            }
                            #endregion
                            #endregion
                            
                            #region Parametros_PlusvaliasDividendos_ISINS
                            #region Remove
                            List<Parametros_PlusvaliasDividendos_ISINS> Temp_PlusvaliasDividendos_ISINSToDelete = new List<Parametros_PlusvaliasDividendos_ISINS>();

                            foreach (var item in plantillaObject.Parametros_PlusvaliasDividendos)
                            {

                               
                                foreach (var PlDiViItem in item.Parametros_PlusvaliasDividendos_ISINS)
                                {


                                    var originalItem = plantilla.Parametros_PlusvaliasDividendos.Where(c => c.Id == PlDiViItem.Id_Parametros_PlusvaliasDividendos).SelectMany(p => p.Parametros_PlusvaliasDividendos_ISINS).Where(i => i.Id == PlDiViItem.Id).FirstOrDefault();   ///Where(p => p.Parametros_PlusvaliasDividendos_ISINS.FirstOrDefault().Id == PlDiViItem.Id_Parametros_PlusvaliasDividendos); 
                                    if (originalItem == null)
                                    {
                                        Temp_PlusvaliasDividendos_ISINSToDelete.Add(PlDiViItem);
                                    }

                                }
                                 
                            }

                            foreach (var item in Temp_PlusvaliasDividendos_ISINSToDelete)
                            {
                               

                                var itemtoDelete = plantillaObject.Parametros_PlusvaliasDividendos.Where(c => c.Id == item.Id_Parametros_PlusvaliasDividendos).SelectMany(p => p.Parametros_PlusvaliasDividendos_ISINS).Where(i => i.Id == item.Id).FirstOrDefault();  
                                if (itemtoDelete != null)
                                {

                                    var Temp_PlusvaliasDividendos_ISINSEntry = dbContext.Entry(itemtoDelete);
                                    Temp_PlusvaliasDividendos_ISINSEntry.State = EntityState.Deleted;


                                    plantilla.Parametros_PlusvaliasDividendos.Where(c => c.Id == item.Id_Parametros_PlusvaliasDividendos).SelectMany(p => p.Parametros_PlusvaliasDividendos_ISINS).ToList().Remove(itemtoDelete);  ///.Where(i => i.Id == item.Id). .Remove(itemtoDelete);

                                }
                            }

                            #endregion

                            #region Add/Edit

                            List<Parametros_PlusvaliasDividendos_ISINS> Temp_PlusvaliasDividendos_ISINS_before_update = new List<Parametros_PlusvaliasDividendos_ISINS>();
                            foreach (var itemPart in plantillaObject.Parametros_PlusvaliasDividendos.SelectMany(c => c.Parametros_PlusvaliasDividendos_ISINS))
                            {
                                Temp_PlusvaliasDividendos_ISINS_before_update.Add(itemPart);
                            }

                            foreach (var item in plantilla.Parametros_PlusvaliasDividendos.SelectMany(c => c.Parametros_PlusvaliasDividendos_ISINS))
                            {
                                var originalItem = Temp_PlusvaliasDividendos_ISINS_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var Temp_PlusvaliasDividendos_ISINSEntry = dbContext.Entry(originalItem);
                                    Temp_PlusvaliasDividendos_ISINSEntry.CurrentValues.SetValues(item);

                                }
                                else
                                {
                                    Parametros_PlusvaliasDividendos_ISINS newitemTemp_PlusvaliasDividendos_ISINS = new Parametros_PlusvaliasDividendos_ISINS();
                                    newitemTemp_PlusvaliasDividendos_ISINS = item;
                                    if(item.Id_Parametros_PlusvaliasDividendos>0)
                                    {
                                        plantillaObject.Parametros_PlusvaliasDividendos.Where(c => c.Id == item.Id_Parametros_PlusvaliasDividendos).Select(p => p.Parametros_PlusvaliasDividendos_ISINS).FirstOrDefault().Add(newitemTemp_PlusvaliasDividendos_ISINS);
                                    }
                                    else
                                    {
                                        plantillaObject.Parametros_PlusvaliasDividendos.FirstOrDefault().Parametros_PlusvaliasDividendos_ISINS.Add(newitemTemp_PlusvaliasDividendos_ISINS);
                                    }
                                   
                                }

                            }

                            #endregion
                            #endregion

                            #region Parametros_PlusvaliasDividendos

                            #region Remove
                            List<Parametros_PlusvaliasDividendos> PlusvaliasDividendosToDelete = new List<Parametros_PlusvaliasDividendos>();

                            foreach (var item in plantillaObject.Parametros_PlusvaliasDividendos)
                            {
                                var originalItem = plantilla.Parametros_PlusvaliasDividendos.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    PlusvaliasDividendosToDelete.Add(item);
                                }
                            }

                            foreach (var item in PlusvaliasDividendosToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_PlusvaliasDividendos.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var PlusvaliasDividendosEntry = dbContext.Entry(itemtoDelete);
                                    PlusvaliasDividendosEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_PlusvaliasDividendos.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_PlusvaliasDividendos> PlantillasParam_PlusvaliasDividendos_before_update = new List<Parametros_PlusvaliasDividendos>();
                            foreach (var item in plantillaObject.Parametros_PlusvaliasDividendos)
                            {
                                PlantillasParam_PlusvaliasDividendos_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_PlusvaliasDividendos)
                            {
                                var originalItem = PlantillasParam_PlusvaliasDividendos_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var PlusvaliasDividendosEntry = dbContext.Entry(originalItem);
                                    PlusvaliasDividendosEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_PlusvaliasDividendos newitemParamPlusvaliasDividendo = new Parametros_PlusvaliasDividendos();
                                    newitemParamPlusvaliasDividendo = item;
                                    plantillaObject.Parametros_PlusvaliasDividendos.Add(newitemParamPlusvaliasDividendo);
                                }

                            }
                            #endregion
                            #endregion

                            #region Parametros_RFComprasVentasEjercicio

                            #region Remove
                            List<Parametros_RFComprasVentasEjercicio> RFComprasVentasEjercicioToDelete = new List<Parametros_RFComprasVentasEjercicio>();

                            foreach (var item in plantillaObject.Parametros_RFComprasVentasEjercicio)
                            {
                                var originalItem = plantilla.Parametros_RFComprasVentasEjercicio.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    RFComprasVentasEjercicioToDelete.Add(item);
                                }
                            }

                            foreach (var item in RFComprasVentasEjercicioToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_RFComprasVentasEjercicio.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var PlusvaliasDividendosEntry = dbContext.Entry(itemtoDelete);
                                    PlusvaliasDividendosEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_RFComprasVentasEjercicio.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_RFComprasVentasEjercicio> PlantillasParam_RFComprasVentasEjercicio_before_update = new List<Parametros_RFComprasVentasEjercicio>();
                            foreach (var item in plantillaObject.Parametros_RFComprasVentasEjercicio)
                            {
                                PlantillasParam_RFComprasVentasEjercicio_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_RFComprasVentasEjercicio)
                            {
                                var originalItem = PlantillasParam_RFComprasVentasEjercicio_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var RFComprasVentasEjercicioEntry = dbContext.Entry(originalItem);
                                    RFComprasVentasEjercicioEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_RFComprasVentasEjercicio newitemParamRFComprasVentasEjercicio = new Parametros_RFComprasVentasEjercicio();
                                    newitemParamRFComprasVentasEjercicio = item;
                                    plantillaObject.Parametros_RFComprasVentasEjercicio.Add(newitemParamRFComprasVentasEjercicio);
                                }

                            }
                            #endregion
                            #endregion
                            
                            #region Parametros_DividendosCobrados

                            #region Remove
                            List<Parametros_DividendosCobrados> DividendosCobradosToDelete = new List<Parametros_DividendosCobrados>();

                            foreach (var item in plantillaObject.Parametros_DividendosCobrados)
                            {
                                var originalItem = plantilla.Parametros_DividendosCobrados.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    DividendosCobradosToDelete.Add(item);
                                }
                            }

                            foreach (var item in DividendosCobradosToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_DividendosCobrados.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var DividendosCobradosEntry = dbContext.Entry(itemtoDelete);
                                    DividendosCobradosEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_DividendosCobrados.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_DividendosCobrados> PlantillasParam_DividendosCobrados_before_update = new List<Parametros_DividendosCobrados>();
                            foreach (var item in plantillaObject.Parametros_DividendosCobrados)
                            {
                                PlantillasParam_DividendosCobrados_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_DividendosCobrados)
                            {
                                var originalItem = PlantillasParam_DividendosCobrados_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var DividendosCobradosEntry = dbContext.Entry(originalItem);
                                    DividendosCobradosEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_DividendosCobrados newitemParamDividendosCobrados = new Parametros_DividendosCobrados();
                                    newitemParamDividendosCobrados = item;
                                    plantillaObject.Parametros_DividendosCobrados.Add(newitemParamDividendosCobrados);
                                }

                            }
                            #endregion
                            #endregion

                            #region RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO

                            #region Remove
                            List<Parametros_RVComprasRealizadasEjercicio> RVComprasRealizadasEjercicioToDelete = new List<Parametros_RVComprasRealizadasEjercicio>();

                            foreach (var item in plantillaObject.Parametros_RVComprasRealizadasEjercicio)
                            {
                                var originalItem = plantilla.Parametros_RVComprasRealizadasEjercicio.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    RVComprasRealizadasEjercicioToDelete.Add(item);
                                }
                            }

                            foreach (var item in RVComprasRealizadasEjercicioToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_RVComprasRealizadasEjercicio.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var RVComprasRealizadasEjercicioEntry = dbContext.Entry(itemtoDelete);
                                    RVComprasRealizadasEjercicioEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_RVComprasRealizadasEjercicio.Remove(itemtoDelete);
                                }
                            }

                            #endregion

                            #region Add/Edit

                            List<Parametros_RVComprasRealizadasEjercicio> PlantillasParam_RVComprasRealizadasEjercicio_before_update = new List<Parametros_RVComprasRealizadasEjercicio>();
                            foreach (var item in plantillaObject.Parametros_RVComprasRealizadasEjercicio)
                            {
                                PlantillasParam_RVComprasRealizadasEjercicio_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_RVComprasRealizadasEjercicio)
                            {
                                var originalItem = PlantillasParam_RVComprasRealizadasEjercicio_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var RVComprasRealizadasEjercicioEntry = dbContext.Entry(originalItem);
                                    RVComprasRealizadasEjercicioEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_RVComprasRealizadasEjercicio newitemParamRVComprasRealizadasEjercicio = new Parametros_RVComprasRealizadasEjercicio();
                                    newitemParamRVComprasRealizadasEjercicio = item;
                                    plantillaObject.Parametros_RVComprasRealizadasEjercicio.Add(newitemParamRVComprasRealizadasEjercicio);
                                }

                            }
                            #endregion
                            #endregion

                            #region 19 - IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO

                            #region Remove
                            List<Parametros_IIC_ComprasVentasEjercicio> IIC_ComprasVentasEjercicioToDelete = new List<Parametros_IIC_ComprasVentasEjercicio>();

                            foreach (var item in plantillaObject.Parametros_IIC_ComprasVentasEjercicio)
                            {
                                var originalItem = plantilla.Parametros_IIC_ComprasVentasEjercicio.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    IIC_ComprasVentasEjercicioToDelete.Add(item);
                                }
                            }

                            foreach (var item in IIC_ComprasVentasEjercicioToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_IIC_ComprasVentasEjercicio.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var IIC_ComprasVentasEjercicioEntry = dbContext.Entry(itemtoDelete);
                                    IIC_ComprasVentasEjercicioEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_IIC_ComprasVentasEjercicio.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_IIC_ComprasVentasEjercicio> PlantillasParam_IIC_ComprasVentasEjercicio_before_update = new List<Parametros_IIC_ComprasVentasEjercicio>();
                            foreach (var item in plantillaObject.Parametros_IIC_ComprasVentasEjercicio)
                            {
                                PlantillasParam_IIC_ComprasVentasEjercicio_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_IIC_ComprasVentasEjercicio)
                            {
                                var originalItem = PlantillasParam_IIC_ComprasVentasEjercicio_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var IIC_ComprasVentasEjercicioEntry = dbContext.Entry(originalItem);
                                    IIC_ComprasVentasEjercicioEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_IIC_ComprasVentasEjercicio newitemParamIIC_ComprasVentasEjercicio = new Parametros_IIC_ComprasVentasEjercicio();
                                    newitemParamIIC_ComprasVentasEjercicio = item;
                                    plantillaObject.Parametros_IIC_ComprasVentasEjercicio.Add(newitemParamIIC_ComprasVentasEjercicio);
                                }

                            }
                            #endregion
                            #endregion

                            #region 35 - OPERACIONES RENTA VARIABLE (II)

                            #region Remove
                            var OperacionesRentaVariable_IIToDelete = new List<Parametros_OperacionesRentaVariable_II>();

                            foreach (var item in plantillaObject.Parametros_OperacionesRentaVariable_II)
                            {
                                var originalItem = plantilla.Parametros_OperacionesRentaVariable_II.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    OperacionesRentaVariable_IIToDelete.Add(item);
                                }
                            }

                            foreach (var item in OperacionesRentaVariable_IIToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_OperacionesRentaVariable_II.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var OperacionesRentaVariable_IIEntry = dbContext.Entry(itemtoDelete);
                                    OperacionesRentaVariable_IIEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_OperacionesRentaVariable_II.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            var PlantillasParam_OperacionesRentaVariable_II_before_update = new List<Parametros_OperacionesRentaVariable_II>();
                            foreach (var item in plantillaObject.Parametros_OperacionesRentaVariable_II)
                            {
                                PlantillasParam_OperacionesRentaVariable_II_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_OperacionesRentaVariable_II)
                            {
                                var originalItem = PlantillasParam_OperacionesRentaVariable_II_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var OperacionesRentaVariable_IIEntry = dbContext.Entry(originalItem);
                                    OperacionesRentaVariable_IIEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_OperacionesRentaVariable_II newitemParamOperacionesRentaVariable_II = new Parametros_OperacionesRentaVariable_II();
                                    newitemParamOperacionesRentaVariable_II = item;
                                    plantillaObject.Parametros_OperacionesRentaVariable_II.Add(newitemParamOperacionesRentaVariable_II);
                                }

                            }
                            #endregion
                            #endregion

                            #region Parametros_RentabilidadCarteraII

                            #region Remove
                            List<Parametros_Rentabilidad_CarteraII> RentabilidadCarteraIIToDelete = new List<Parametros_Rentabilidad_CarteraII>();

                            foreach (var item in plantillaObject.Parametros_Rentabilidad_CarteraII)
                            {
                                var originalItem = plantilla.Parametros_Rentabilidad_CarteraII.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    RentabilidadCarteraIIToDelete.Add(item);
                                }
                            }

                            foreach (var item in RentabilidadCarteraIIToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_Rentabilidad_CarteraII.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var RentabilidadCarteraIIEntry = dbContext.Entry(itemtoDelete);
                                    RentabilidadCarteraIIEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_Rentabilidad_CarteraII.Remove(itemtoDelete);
                                }
                            }

                            #endregion

                            #region Add/Edit

                            List<Parametros_Rentabilidad_CarteraII> PlantillasParam_RentabilidadCarteraII_before_update = new List<Parametros_Rentabilidad_CarteraII>();
                            foreach (var item in plantillaObject.Parametros_Rentabilidad_CarteraII)
                            {
                                PlantillasParam_RentabilidadCarteraII_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_Rentabilidad_CarteraII)
                            {
                                var originalItem = PlantillasParam_RentabilidadCarteraII_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var RentabilidadCarteraIIEntry = dbContext.Entry(originalItem);
                                    RentabilidadCarteraIIEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_Rentabilidad_CarteraII newitemParamRentabilidadCarteraII = new Parametros_Rentabilidad_CarteraII();
                                    newitemParamRentabilidadCarteraII = item;
                                    plantillaObject.Parametros_Rentabilidad_CarteraII.Add(newitemParamRentabilidadCarteraII);
                                }

                            }
                            #endregion
                            #endregion

                            #region DistribucionPatrimonioNovarex
                            #region Remove
                            List<Parametros_DistribucionPatrimonioNovarex> DistribPatriNovarexToDelete = new List<Parametros_DistribucionPatrimonioNovarex>();

                            foreach (var item in plantillaObject.Parametros_DistribucionPatrimonioNovarex)
                            {
                                var originalItem = plantilla.Parametros_DistribucionPatrimonioNovarex.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    DistribPatriNovarexToDelete.Add(item);
                                }
                            }

                            foreach (var item in DistribPatriNovarexToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_DistribucionPatrimonioNovarex.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var DistribPatriNovarexEntry = dbContext.Entry(itemtoDelete);
                                    DistribPatriNovarexEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_DistribucionPatrimonioNovarex.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_DistribucionPatrimonioNovarex> PlantillasParam_DistribucionPatrimonioNovarex_before_update = new List<Parametros_DistribucionPatrimonioNovarex>();
                            foreach (var item in plantillaObject.Parametros_DistribucionPatrimonioNovarex)
                            {
                                PlantillasParam_DistribucionPatrimonioNovarex_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_DistribucionPatrimonioNovarex)
                            {
                                var originalItem = PlantillasParam_DistribucionPatrimonioNovarex_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var DistribPatriNovarexEntry = dbContext.Entry(originalItem);
                                    DistribPatriNovarexEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_DistribucionPatrimonioNovarex newitemParamDistribPatriNovarex = new Parametros_DistribucionPatrimonioNovarex();
                                    newitemParamDistribPatriNovarex = item;
                                    plantillaObject.Parametros_DistribucionPatrimonioNovarex.Add(newitemParamDistribPatriNovarex);
                                }

                            }
                            #endregion
                            #endregion
                            
                            #region EvolucionPatrimonioConjuntoGuissona

                            #region Remove
                            List<Parametros_EvolucionPatrimonioConjuntoGuissona> EvolucionPatrimConjGuissonaToDelete = new List<Parametros_EvolucionPatrimonioConjuntoGuissona>();

                            foreach (var item in plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona)
                            {
                                var originalItem = plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    EvolucionPatrimConjGuissonaToDelete.Add(item);
                                }
                            }

                            foreach (var item in EvolucionPatrimConjGuissonaToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var EvolucionPatrimConjGuissonaEntry = dbContext.Entry(itemtoDelete);
                                    EvolucionPatrimConjGuissonaEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Remove(itemtoDelete);
                                  
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_EvolucionPatrimonioConjuntoGuissona> PlantillasParam_EvolucionPatrimConjGuissona_before_update = new List<Parametros_EvolucionPatrimonioConjuntoGuissona>();
                            foreach (var item in plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona)
                            {
                                PlantillasParam_EvolucionPatrimConjGuissona_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona)
                            {
                                var originalItem = PlantillasParam_EvolucionPatrimConjGuissona_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var EvolucionPatrimConjGuissonaEntry = dbContext.Entry(originalItem);
                                    EvolucionPatrimConjGuissonaEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_EvolucionPatrimonioConjuntoGuissona newitemParamEvolucionPatrimConjGuissona = new Parametros_EvolucionPatrimonioConjuntoGuissona();
                                    newitemParamEvolucionPatrimConjGuissona = item;
                                    plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona.Add(newitemParamEvolucionPatrimConjGuissona);
                                }

                            }
                            #endregion
                            #endregion

                            #region EvolucionPatrimonioConjuntoGuissonaFondos

                            #region Remove
                            List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> EvolucionPatrimConjGuissonaFondosToDelete = new List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos>();

                            foreach (var item in plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)
                            {
                                var originalItem = plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    EvolucionPatrimConjGuissonaFondosToDelete.Add(item);
                                }
                            }

                            foreach (var item in EvolucionPatrimConjGuissonaFondosToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var EvolucionPatrimConjGuissonaFondosEntry = dbContext.Entry(itemtoDelete);
                                    EvolucionPatrimConjGuissonaFondosEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Remove(itemtoDelete);
                                    
                                }
                            }

                            #endregion
                            #region Add/Edit

                            List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos> PlantillasParam_EvolucionPatrimConjGuissonaFondos_before_update = new List<Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos>();
                            foreach (var item in plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)
                            {
                                PlantillasParam_EvolucionPatrimConjGuissonaFondos_before_update.Add(item);
                            }
                            foreach (var item in plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)
                            {
                                var originalItem = PlantillasParam_EvolucionPatrimConjGuissonaFondos_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var EvolucionPatrimConjGuissonaFondosEntry = dbContext.Entry(originalItem);
                                    EvolucionPatrimConjGuissonaFondosEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos newitemParamEvolucionPatrimConjGuissonaFondos = new Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos();
                                    newitemParamEvolucionPatrimConjGuissonaFondos = item;
                                    plantillaObject.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Add(newitemParamEvolucionPatrimConjGuissonaFondos);
                                }

                            }
                            #endregion
                            #endregion

                            #region VARIACIÓN PATRIMONIAL B
                            #region Remove
                            List<Parametros_VariacionPatrimonialB> VariacionPatrimonialBToDelete = new List<Parametros_VariacionPatrimonialB>();

                            foreach (var item in plantillaObject.Parametros_VariacionPatrimonialB)
                            {
                                var originalItem = plantilla.Parametros_VariacionPatrimonialB.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    VariacionPatrimonialBToDelete.Add(item);
                                }
                            }

                            foreach (var item in VariacionPatrimonialBToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_VariacionPatrimonialB.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var VariacionPatrimonialBEntry = dbContext.Entry(itemtoDelete);
                                    VariacionPatrimonialBEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_VariacionPatrimonialB.Remove(itemtoDelete);
                                }
                            }

                            #endregion
                            #region Add/Edit
                            List<Parametros_VariacionPatrimonialB> PlantillasParam_VariacionPatrimonialB_before_update = new List<Parametros_VariacionPatrimonialB>();
                            foreach (var item in plantillaObject.Parametros_VariacionPatrimonialB)
                            {
                                PlantillasParam_VariacionPatrimonialB_before_update.Add(item);
                            }

                            foreach (var item in plantilla.Parametros_VariacionPatrimonialB)
                            {
                                var originalItem = PlantillasParam_VariacionPatrimonialB_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var VariacionPatrimonialBEntry = dbContext.Entry(originalItem);
                                    VariacionPatrimonialBEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_VariacionPatrimonialB newitemParamVariacionPatrimonialB = new Parametros_VariacionPatrimonialB();
                                    newitemParamVariacionPatrimonialB = item;
                                    plantillaObject.Parametros_VariacionPatrimonialB.Add(newitemParamVariacionPatrimonialB);
                                }

                            }
                            #endregion
                            #endregion

                            #region ÍNDICE PRECONFIGURADO (NOVAREX)
                            #region Remove
                            List<Parametros_IndicePreconfiguradoNovarex> IndicePreconfiguradoNovarexToDelete = new List<Parametros_IndicePreconfiguradoNovarex>();
                            /*
                            foreach (var item in plantillaObject.Parametros_IndicePreconfiguradoNovarex)
                            {
                                var originalItem = plantilla.Parametros_IndicePreconfiguradoNovarex.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    IndicePreconfiguradoNovarexToDelete.Add(item);
                                }
                            }

                            foreach (var item in IndicePreconfiguradoNovarexToDelete)
                            {
                                var itemtoDelete = plantillaObject.Parametros_IndicePreconfiguradoNovarex.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                    var IndicePreconfiguradoNovarexEntry = dbContext.Entry(itemtoDelete);
                                    IndicePreconfiguradoNovarexEntry.State = EntityState.Deleted;
                                    plantilla.Parametros_IndicePreconfiguradoNovarex.Remove(itemtoDelete);
                                }
                            }
                            */
                            #endregion
                            #region Add/Edit
                            List<Parametros_IndicePreconfiguradoNovarex> PlantillasParam_IndicePreconfiguradoNovarex_before_update = new List<Parametros_IndicePreconfiguradoNovarex>();
                            /*foreach (var item in plantillaObject.Parametros_IndicePreconfiguradoNovarex)
                            {
                                PlantillasParam_IndicePreconfiguradoNovarex_before_update.Add(item);
                            }

                            foreach (var item in plantilla.Parametros_IndicePreconfiguradoNovarex)
                            {
                                var originalItem = PlantillasParam_IndicePreconfiguradoNovarex_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var IndicePreconfiguradoNovarexEntry = dbContext.Entry(originalItem);
                                    IndicePreconfiguradoNovarexEntry.CurrentValues.SetValues(item);
                                }
                                else
                                {
                                    Parametros_IndicePreconfiguradoNovarex newitemParamIndicePreconfiguradoNovarex = new Parametros_IndicePreconfiguradoNovarex();
                                    newitemParamIndicePreconfiguradoNovarex = item;
                                    plantillaObject.Parametros_IndicePreconfiguradoNovarex.Add(newitemParamIndicePreconfiguradoNovarex);
                                }

                            }*/
                            #endregion
                            #endregion

                            /*
                            #region Temp_ParticipesSalat
                            #region Remove
                            List<Temp_ParticipesSalat> Temp_ParticipesSalatToDelete = new List<Temp_ParticipesSalat>();

                            foreach (var item in plantillaObject.Temp_ParticipesSalat)
                            {
                                var originalItem = plantilla.Temp_ParticipesSalat.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    Temp_ParticipesSalatToDelete.Add(item);
                                }
                            }

                            foreach (var item in Temp_ParticipesSalatToDelete)
                            {
                                var itemtoDelete = plantillaObject.Temp_ParticipesSalat.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {
                                   
                                    var Temp_ParticipesSalatEntry = dbContext.Entry(itemtoDelete);
                                    Temp_ParticipesSalatEntry.State = EntityState.Deleted;
                                    plantilla.Temp_ParticipesSalat.Remove(itemtoDelete);
                                }
                            }

                            #endregion

                            #region Add/Edit
                            List<Temp_ParticipesSalat> Temp_ParticipesSalat_before_update = new List<Temp_ParticipesSalat>();
                            foreach (var item in plantillaObject.Temp_ParticipesSalat)
                            {
                               
                                Temp_ParticipesSalat_before_update.Add(item);
                            }

                            foreach (var item in plantilla.Temp_ParticipesSalat)
                            {
                                var originalItem = Temp_ParticipesSalat_before_update.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem != null)
                                {
                                    var Temp_ParticipesSalatEntry = dbContext.Entry(originalItem);
                                    Temp_ParticipesSalatEntry.CurrentValues.SetValues(item);
                                    
                                    ///dbContext.Entry(originalItem.Temp_ParticipesSalat_Aportaciones).CurrentValues.SetValues(item.Temp_ParticipesSalat_Aportaciones);

                                }
                                else
                                {
                                    Temp_ParticipesSalat newitemTemp_ParticipesSalat = new Temp_ParticipesSalat();
                                    newitemTemp_ParticipesSalat = item;
                                    plantillaObject.Temp_ParticipesSalat.Add(newitemTemp_ParticipesSalat);
                                }

                            }
                            #endregion
                            #endregion
                            */

                            /*
                            #region Temp_ParticipesSalat_Aportaciones
                            #region Remove
                            List<ParticipesSalat_Aportaciones> Temp_ParticipesSalat_AportacionesToDelete = new List<ParticipesSalat_Aportaciones>();

                            foreach (var item in plantillaObject.Temp_ParticipesSalat.SelectMany(c => c.ParticipesSalat_Aportaciones))
                            {
                                var originalItem = plantilla.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Aportaciones.SingleOrDefault(i => i.Id == item.Id);
                                if (originalItem == null)
                                {
                                    Temp_ParticipesSalat_AportacionesToDelete.Add(item);
                                }
                            }

                            foreach (var item in Temp_ParticipesSalat_AportacionesToDelete)
                            {
                                var itemtoDelete = plantillaObject.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Aportaciones.SingleOrDefault(i => i.Id == item.Id);
                                if (itemtoDelete != null)
                                {

                                    var Temp_ParticipesSalatEntry = dbContext.Entry(itemtoDelete);
                                    Temp_ParticipesSalatEntry.State = EntityState.Deleted;

                                   
                                    plantilla.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Aportaciones.Remove(itemtoDelete);
                                }
                            }

                            #endregion

                            #region Add/Edit

                            List<ParticipesSalat_Aportaciones> Temp_ParticipesSalat_Aportaciones_before_update = new List<ParticipesSalat_Aportaciones>();
                                foreach (var itemPart in plantillaObject.Temp_ParticipesSalat.SelectMany(c=>c.ParticipesSalat_Aportaciones))
                                {
                                    Temp_ParticipesSalat_Aportaciones_before_update.Add(itemPart);

                                }

                                foreach (var item in plantilla.Temp_ParticipesSalat.SelectMany(c => c.ParticipesSalat_Aportaciones))
                                {
                                    var originalItem = Temp_ParticipesSalat_Aportaciones_before_update.SingleOrDefault(i => i.Id == item.Id);
                                    if (originalItem != null)
                                    {
                                        var Temp_ParticipesSalatEntry = dbContext.Entry(originalItem);
                                        Temp_ParticipesSalatEntry.CurrentValues.SetValues(item);

                                    }
                                    else
                                    {
                                       ParticipesSalat_Aportaciones newitemTemp_ParticipesSalat = new ParticipesSalat_Aportaciones();
                                        newitemTemp_ParticipesSalat = item;
                                       
                                        plantillaObject.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Aportaciones.Add(newitemTemp_ParticipesSalat); 
                                       
                                    }

                                }

                            #endregion
                            #endregion  
                                */


                            //#region Temp_ParticipesSalat_Periodos
                            //#region Remove
                            //List<ParticipesSalat_Periodos> Temp_ParticipesSalat_PeriodosToDelete = new List<ParticipesSalat_Periodos>();
                            //var ps = Reports_IICs.DataAccess.Secciones.ParticipesSalat_DA.Get_ParticipesSalat();

                            //foreach (var item in plantillaObject.ParticipesSalat.SelectMany(c => c.ParticipesSalat_Periodos))
                            //{
                            //    var originalItem = plantilla.ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.SingleOrDefault(i => i.Id == item.Id);
                            //    if (originalItem == null)
                            //    {
                            //        Temp_ParticipesSalat_PeriodosToDelete.Add(item);
                            //    }
                            //}

                            //foreach (var item in Temp_ParticipesSalat_PeriodosToDelete)
                            //{
                            //    var itemtoDelete = plantillaObject.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.SingleOrDefault(i => i.Id == item.Id);
                            //    if (itemtoDelete != null)
                            //    {
                            //        var Temp_ParticipesSalatEntry = dbContext.Entry(itemtoDelete);
                            //        Temp_ParticipesSalatEntry.State = EntityState.Deleted;
                            //        plantilla.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.Remove(itemtoDelete);
                            //    }
                            //}

                            //#endregion

                            //#region Add/Edit

                            //List<ParticipesSalat_Periodos> Temp_ParticipesSalat_Periodos_before_update = new List<ParticipesSalat_Periodos>();
                            //foreach (var itemPart in plantillaObject.Temp_ParticipesSalat.SelectMany(c => c.ParticipesSalat_Periodos))
                            //{
                            //    Temp_ParticipesSalat_Periodos_before_update.Add(itemPart);

                            //}

                            //foreach (var item in plantilla.Temp_ParticipesSalat.SelectMany(c => c.ParticipesSalat_Periodos))
                            //{
                            //    var originalItem = Temp_ParticipesSalat_Periodos_before_update.SingleOrDefault(i => i.Id == item.Id);
                            //    if (originalItem != null)
                            //    {
                            //        var Temp_ParticipesSalatEntry = dbContext.Entry(originalItem);
                            //        Temp_ParticipesSalatEntry.CurrentValues.SetValues(item);

                            //    }
                            //    else
                            //    {
                            //        ParticipesSalat_Periodos newitemTemp_ParticipesSalat = new ParticipesSalat_Periodos();
                            //        newitemTemp_ParticipesSalat = item;

                            //        plantillaObject.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.Add(newitemTemp_ParticipesSalat);

                            //    }

                            //}

                            //#endregion
                            //#endregion

                            //#region Temp_ParticipesSalat_Periodos_Lineas
                            //#region Remove
                            //List<ParticipesSalat_Periodos_Lineas> Temp_ParticipesSalat_Periodos_LineasToDelete = new List<ParticipesSalat_Periodos_Lineas>();

                            //foreach (var item in plantillaObject.Temp_ParticipesSalat.SelectMany(c => c.ParticipesSalat_Periodos.SelectMany(cl=>cl.ParticipesSalat_Periodos_Lineas)))
                            //{
                            //    var originalItem = plantilla.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.SelectMany(cl => cl.ParticipesSalat_Periodos_Lineas).SingleOrDefault(i => i.Id == item.Id);
                            //    if (originalItem == null)
                            //    {
                            //        Temp_ParticipesSalat_Periodos_LineasToDelete.Add(item);
                            //    }
                            //}

                            //foreach (var item in Temp_ParticipesSalat_Periodos_LineasToDelete)
                            //{
                            //    var itemtoDelete = plantillaObject.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.SelectMany(cl => cl.ParticipesSalat_Periodos_Lineas).SingleOrDefault(i => i.Id == item.Id);
                            //    if (itemtoDelete != null)
                            //    {
                            //        var Temp_ParticipesSalatEntry = dbContext.Entry(itemtoDelete);
                            //        Temp_ParticipesSalatEntry.State = EntityState.Deleted;
                            //        plantilla.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.SelectMany(cl => cl.ParticipesSalat_Periodos_Lineas).ToList().Remove(itemtoDelete);
                            //    }
                            //}

                            //#endregion

                            //#region Add/Edit

                            //List<ParticipesSalat_Periodos_Lineas> Temp_ParticipesSalat_Periodos_Lineas_before_update = new List<ParticipesSalat_Periodos_Lineas>();
                            //foreach (var itemPart in plantillaObject.Temp_ParticipesSalat.SelectMany(c => c.ParticipesSalat_Periodos).SelectMany(cl => cl.ParticipesSalat_Periodos_Lineas))
                            //{
                            //    Temp_ParticipesSalat_Periodos_Lineas_before_update.Add(itemPart);

                            //}

                            //foreach (var item in plantilla.Temp_ParticipesSalat.SelectMany(c => c.ParticipesSalat_Periodos).SelectMany(cl => cl.ParticipesSalat_Periodos_Lineas))
                            //{
                            //    var originalItem = Temp_ParticipesSalat_Periodos_Lineas_before_update.SingleOrDefault(i => i.Id == item.Id);
                            //    if (originalItem != null)
                            //    {
                            //        var Temp_ParticipesSalatEntry = dbContext.Entry(originalItem);
                            //        Temp_ParticipesSalatEntry.CurrentValues.SetValues(item);

                            //    }
                            //    else
                            //    {
                            //        ParticipesSalat_Periodos_Lineas newitemTemp_ParticipesSalat = new ParticipesSalat_Periodos_Lineas();
                            //        newitemTemp_ParticipesSalat = item;
                            //        try
                            //        {

                            //            plantillaObject.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Periodos.Where(c => c.Id == item.IdTempParticipesSalatPeriodo).FirstOrDefault().ParticipesSalat_Periodos_Lineas.Add(newitemTemp_ParticipesSalat);
                                        
                            //        }
                            //        catch (Exception ex)
                            //        {
                            //            log.Error("Error Saving Plantilla", ex);
                            //        }

                                   
                                    
                            //    }

                            //}

                            //#endregion

                            //#endregion

                            //#region Temp_ParticipesSalat_Participes
                            //if (plantilla.Plantillas_Secciones.Any(a => a.IdSeccion == 41))
                            //{
                            //    try
                            //    {
                            //        #region Remove
                            //        List<ParticipesSalat_Participes> Temp_ParticipesSalat_ParticipesToDelete = new List<ParticipesSalat_Participes>();

                            //        if (plantillaObject.Temp_ParticipesSalat.Count() > 0)
                            //        {
                            //            //foreach (var item in plantillaObject.Temp_ParticipesSalat_Participes)
                            //            foreach (var item in plantillaObject.Temp_ParticipesSalat.FirstOrDefault().ParticipesSalat_Participes)
                            //            {
                            //                //var originalItem = plantilla.Temp_ParticipesSalat_Participes.SingleOrDefault(i => i.Id == item.Id);
                            //                //var originalItem = item.SingleOrDefault(i => i.Id == item.Id);
                            //                //if (originalItem == null)
                            //                //{
                            //                Temp_ParticipesSalat_ParticipesToDelete.Add(item);
                            //                //}
                            //            }
                            //            /* borrar
                            //            foreach (var item in Temp_ParticipesSalat_ParticipesToDelete)
                            //            {
                            //                var itemtoDelete = plantillaObject.Temp_ParticipesSalat.FirstOrDefault().Temp_ParticipesSalat_Participes.SingleOrDefault(i => i.Id == item.Id);
                            //                if (itemtoDelete != null)
                            //                {
                            //                    var Temp_ParticipesSalat_ParticipesEntry = dbContext.Entry(itemtoDelete);
                            //                    Temp_ParticipesSalat_ParticipesEntry.State = EntityState.Deleted;
                            //                    //plantilla.Temp_ParticipesSalat_Participes.Remove(itemtoDelete);
                            //                    plantilla.Temp_ParticipesSalat.FirstOrDefault().Temp_ParticipesSalat_Participes.Remove(itemtoDelete);
                            //                }
                            //            }
                            //            */

                            //            #endregion
                            //            #region Add/Edit
                            //            /* borrar
                            //            List<Temp_ParticipesSalat_Participes> Temp_ParticipesSalat_Participes_before_update = new List<Temp_ParticipesSalat_Participes>();
                            //            //foreach (var item in plantillaObject.Temp_ParticipesSalat_Participes)
                            //            foreach (var item in plantillaObject.Temp_ParticipesSalat.FirstOrDefault().Temp_ParticipesSalat_Participes)
                            //            {
                            //                Temp_ParticipesSalat_Participes_before_update.Add(item);
                            //            }
                                        
                            //            //foreach (var item in plantilla.Temp_ParticipesSalat_Participes)
                            //            foreach (var item in plantilla.Temp_ParticipesSalat.FirstOrDefault().Temp_ParticipesSalat_Participes)
                            //            {
                            //                var originalItem = Temp_ParticipesSalat_Participes_before_update.SingleOrDefault(i => i.Id == item.Id);
                            //                if (originalItem != null)
                            //                {
                            //                    var Temp_ParticipesSalat_ParticipesEntry = dbContext.Entry(originalItem);
                            //                    Temp_ParticipesSalat_ParticipesEntry.CurrentValues.SetValues(item);
                            //                }
                            //                else
                            //                {
                            //                    Temp_ParticipesSalat_Participes newitemTemp_ParticipesSalat_Participes = new Temp_ParticipesSalat_Participes();
                            //                    newitemTemp_ParticipesSalat_Participes = item;
                            //                    plantillaObject.Temp_ParticipesSalat.FirstOrDefault().Temp_ParticipesSalat_Participes.Add(newitemTemp_ParticipesSalat_Participes);
                            //                }

                            //            }
                            //            */
                            //            #endregion
                            //        }
                            //    }
                            //    catch (DbEntityValidationException ex)
                            //    {
                            //        // Retrieve the error messages as a list of strings.
                            //        var errorMessages = ex.EntityValidationErrors
                            //                .SelectMany(x => x.ValidationErrors)
                            //                .Select(x => x.ErrorMessage);

                            //        // Join the list to a single string.
                            //        var fullErrorMessage = string.Join("; ", errorMessages);
                            //        //hasError = true;
                            //        log.Error("Error Generando Datos Temporales" + fullErrorMessage, ex);
                            //        // Combine the original exception message with the new one.
                            //        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                            //        // Throw a new DbEntityValidationException with the improved exception message.
                            //        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                            //    }
                            //    catch (DbUpdateException ex)
                            //    {
                            //        //comprobamos en qué tabla/s se está produciendo el error
                            //        var entidades = ex.Entries;
                            //        throw ex;
                            //    }
                            //    catch (Exception ex)
                            //    {
                            //        log.Error("Error Generando Datos Temporales", ex);
                            //        //hasError = true;
                            //        throw ex;
                            //    }
                            //}
                            //#endregion


                        }
                        #endregion
                        else
                        #region Insert
                        {
                           
                            plantillaObject = plantilla;
                            dbContext.Plantillas.Add(plantillaObject);
                        }
                        #endregion
                    }
                    
                    try
                    {
                        dbContext.SaveChanges();
                    }
                    catch (DbEntityValidationException ex)
                    {
                        // Retrieve the error messages as a list of strings.
                        var errorMessages = ex.EntityValidationErrors
                                .SelectMany(x => x.ValidationErrors)
                                .Select(x => x.ErrorMessage);

                        // Join the list to a single string.
                        var fullErrorMessage = string.Join("; ", errorMessages);
                        //hasError = true;
                        log.Error("Error Generando Datos Temporales" + fullErrorMessage, ex);
                        // Combine the original exception message with the new one.
                        var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                        // Throw a new DbEntityValidationException with the improved exception message.
                        throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                    }
                    catch (DbUpdateException ex)
                    {
                        //comprobamos en qué tabla/s se está produciendo el error
                        var entidades = ex.Entries;
                        throw ex;
                    }
                    catch (Exception ex)
                    {
                        log.Error("Error Generando Datos Temporales", ex);
                        //hasError = true;
                        throw ex;
                    }

                    #region Special Cases Remove Params info

                    List<Plantillas_Secciones> SeccionTobeDelete = new List<Plantillas_Secciones>();

                    foreach (var item in Plant_secciones_before_update)
                    {
                        var originalItem = PlantillaSC.Plantillas_Secciones.SingleOrDefault(i => i.Id == item.Id);
                        if (originalItem == null)
                        {
                            SeccionTobeDelete.Add(item);
                        }
                    }

                    foreach (var item in SeccionTobeDelete)
                    {
                        var itemtoDelete = Plant_secciones_before_update.SingleOrDefault(i => i.Id == item.Id);
                        if (itemtoDelete != null)
                        {
                            
                            #region Special Cases
                            switch (itemtoDelete.IdSeccion)
                            {
                                case 6://VARIACIÓN PATRIMONIAL B
                                    #region  VARIACIÓN PATRIMONIAL B
                                    var ParamVPitemtoDelete = plantillaSpecialCases.Parametros_VariacionPatrimonialB.SingleOrDefault(i => i.CodigoIC == plantilla.CodigoIc);
                                    if (ParamVPitemtoDelete != null)
                                    {
                                        DeleteParametros_VariacionPatrimonialB(ParamVPitemtoDelete);
                                    }
                                    //plantillaObject = dbContext.Plantillas.SingleOrDefault(c => c.CodigoIc == plantilla.CodigoIc);
                                    #endregion
                                    break;
                                case 8://RENTABILIDAD CARTERA (II)
                                    #region  RENTABILIDAD CARTERA (II)

                                    var ParamRentabilidad_CarteraIIitemtoDelete = plantillaSpecialCases.Parametros_Rentabilidad_CarteraII.Where(i => i.CodigoIC == plantilla.CodigoIc).ToList();
                                    if (ParamRentabilidad_CarteraIIitemtoDelete != null)
                                    {
                                        foreach (var itemIPre in ParamRentabilidad_CarteraIIitemtoDelete)
                                        {
                                            var paramtoDelete = plantilla.Parametros_Rentabilidad_CarteraII.Where(c => c.Id == itemIPre.Id).SingleOrDefault();
                                            if (paramtoDelete != null) plantilla.Parametros_Rentabilidad_CarteraII.Remove(paramtoDelete);
                                            DeleteParametros_RentabilidadCarteraII(itemIPre);
                                        }

                                    }
                                    

                                    #endregion
                                    break;
                                case 9://EVOLUCIÓN MERCADOS
                                    #region  EVOLUCIÓN MERCADOS
                                    foreach (var itemEmerca in plantillaSpecialCases.Parametros_EvolucionMercados.Where(i => i.CodigoIC == plantilla.CodigoIc))
                                    {
                                        DeleteParametros_EvolucionMercados(itemEmerca);
                                    }
                                    //var ParamEMercaitemtoDelete = plantillaSpecialCases.Parametros_EvolucionMercados.SingleOrDefault(i => i.CodigoIC == plantilla.CodigoIc);
                                    //if (ParamEMercaitemtoDelete != null)
                                    //{

                                    //    DeleteParametros_EvolucionMercados(ParamEMercaitemtoDelete);
                                    //}
                                    #endregion
                                    break;
                                case 10://ÍNDICE PRECONFIGURADO (NOVAREX)
                                    #region  ÍNDICE PRECONFIGURADO (NOVAREX)
                                    /*var ParamIPitemtoDelete = plantillaSpecialCases.Parametros_IndicePreconfiguradoNovarex.Where(i => i.CodigoIC == plantilla.CodigoIc).ToList();   
                                    if (ParamIPitemtoDelete != null)
                                    {
                                        foreach (var itemIPre in ParamIPitemtoDelete)
                                        {
                                            var paramtoDelete = plantilla.Parametros_IndicePreconfiguradoNovarex.Where(c => c.Id == itemIPre.Id).SingleOrDefault();
                                            if (paramtoDelete != null) plantilla.Parametros_IndicePreconfiguradoNovarex.Remove(paramtoDelete);
                                            DeleteParametros_IndicePreconfiguradoNovarex(itemIPre);
                                        }
                                       
                                    }*/
                                    //plantillaObject = dbContext.Plantillas.SingleOrDefault(c => c.CodigoIc == plantilla.CodigoIc);
                                    #endregion
                                    break;
                                case 12://DISTRIBUCIÓN PATRIMONIO NOVAREX
                                    #region  DISTRIBUCIÓN PATRIMONIO NOVAREX
                                    foreach (var itemEmerca in plantillaSpecialCases.Parametros_DistribucionPatrimonioNovarex.Where(i => i.CodigoIC == plantilla.CodigoIc))
                                    {
                                        DeleteParametros_DistribucionPatrimonioNovarex(itemEmerca);
                                    }
                                    //var ParamEMercaitemtoDelete = plantillaSpecialCases.Parametros_EvolucionMercados.SingleOrDefault(i => i.CodigoIC == plantilla.CodigoIc);
                                    //if (ParamEMercaitemtoDelete != null)
                                    //{

                                    //    DeleteParametros_EvolucionMercados(ParamEMercaitemtoDelete);
                                    //}
                                    #endregion
                                    break;
                                case 16://DIVIDENDOS COBRADOS
                                    #region  DIVIDENDOS COBRADOS
                                    foreach (var itemEmerca in plantillaSpecialCases.Parametros_DividendosCobrados.Where(i => i.CodigoIC == plantilla.CodigoIc))
                                    {
                                        DeleteParametros_DividendosCobrados(itemEmerca);
                                    }

                                    #endregion
                                    break;
                                case 18://RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                                    #region  RV: COMPRAS REALIZADAS DURANTE EL EJERCICIO
                                    var ParamRVComprasRealizadasEjercicioitemtoDelete = plantillaSpecialCases.Parametros_RVComprasRealizadasEjercicio.Where(i => i.CodigoIC == plantilla.CodigoIc).ToList();
                                    if (ParamRVComprasRealizadasEjercicioitemtoDelete != null)
                                    {
                                        foreach (var itemIPre in ParamRVComprasRealizadasEjercicioitemtoDelete)
                                        {
                                            var paramtoDelete = plantilla.Parametros_RVComprasRealizadasEjercicio.Where(c => c.Id == itemIPre.Id).SingleOrDefault();
                                            if (paramtoDelete != null) plantilla.Parametros_RVComprasRealizadasEjercicio.Remove(paramtoDelete);
                                            DeleteParametros_RVComprasRealizadasEjercicio(itemIPre);
                                        }
                                    }
                                    #endregion
                                    break;
                                case 19://IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO
                                    #region  IIC: COMPRAS Y VENTAS REALIZADAS DURANTE EL EJERCICIO

                                    var ParamIIC_ComprasVentasEjercicioitemtoDelete = plantillaSpecialCases.Parametros_IIC_ComprasVentasEjercicio.Where(i => i.CodigoIC == plantilla.CodigoIc).ToList();
                                    if (ParamIIC_ComprasVentasEjercicioitemtoDelete != null)
                                    {
                                        foreach (var itemIPre in ParamIIC_ComprasVentasEjercicioitemtoDelete)
                                        {
                                            var paramtoDelete = plantilla.Parametros_IIC_ComprasVentasEjercicio.Where(c => c.Id == itemIPre.Id).SingleOrDefault();
                                            if (paramtoDelete != null) plantilla.Parametros_IIC_ComprasVentasEjercicio.Remove(paramtoDelete);
                                            DeleteParametros_IIC_ComprasVentasEjercicio(itemIPre);
                                        }
                                    }
                                    
                                    #endregion
                                    break;
                                case 20://RF: COMPRAS Y VENTAS EJERCICIO
                                    #region  RF: COMPRAS Y VENTAS EJERCICIO
                                    foreach (var itemEmerca in plantillaSpecialCases.Parametros_RFComprasVentasEjercicio.Where(i => i.CodigoIC == plantilla.CodigoIc))
                                    {
                                        DeleteParametros_RFComprasVentasEjercicio(itemEmerca);
                                    }
                                   
                                    #endregion
                                    break;
                                case 25://GRÁFICO I (BENCHMARK)
                                    #region  GRÁFICO I (BENCHMARK)
                                    var ParamGFitemtoDelete = plantillaSpecialCases.Parametros_GraficoBenchmark.SingleOrDefault(i => i.CodigoIc == plantilla.CodigoIc);
                                    if (ParamGFitemtoDelete != null)
                                    {

                                        DeleteParametros_GraficoBenchmark(ParamGFitemtoDelete);
                                    }
                                    //plantillaObject = dbContext.Plantillas.SingleOrDefault(c => c.CodigoIc == plantilla.CodigoIc);
                                    #endregion
                                    break;
                                case 27: //EVOLUCIÓN RENTABILIDAD (GUISSONA)
                                    #region  EVOLUCIÓN RENTABILIDAD (GUISSONA)
                                    var ParamEvoRentabGuissonaFondositemtoDelete = plantillaSpecialCases.Parametros_EvolucionRentabilidadGuissona_Fondos.Where(i => i.CodigoIC == plantilla.CodigoIc);
                                    if (ParamEvoRentabGuissonaFondositemtoDelete != null)
                                    {
                                        foreach (var FondotoDelete in ParamEvoRentabGuissonaFondositemtoDelete.ToList())
                                        {
                                            foreach (var pEvoRentGui in plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos)
                                            {
                                                if (pEvoRentGui.Id == FondotoDelete.Id)
                                                {
                                                    plantilla.Parametros_EvolucionRentabilidadGuissona_Fondos.Remove(pEvoRentGui);
                                                    break;
                                                }
                                            }
                                           
                                            DeleteParametros_EvolucionRentabGuissonaFondos(FondotoDelete);
                                           
                                        }
                                       
                                    }

                                    var ParamEvoRentabGuissonaitemtoDelete = plantillaSpecialCases.Parametros_EvolucionRentabilidadGuissona.SingleOrDefault(i => i.CodigoIC == plantilla.CodigoIc);
                                    if (ParamEvoRentabGuissonaitemtoDelete != null)
                                    {
                                        DeleteParametros_EvolucionRentabGuissona(ParamEvoRentabGuissonaitemtoDelete);
                                        //if (plantilla.Parametros_EvolucionRentabilidadGuissona != null)
                                        //{
                                        //    plantilla.Parametros_EvolucionRentabilidadGuissona.Remove(ParamEvoRentabGuissonaitemtoDelete);
                                        //}
                                    }
                                    #endregion
                                    break;
                                case 28: //EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                    #region EVOLUCIÓN PATRIMONIO CONJUNTO GUISSONA
                                    var ParamEvoPatrimConjGuissonaFondositemtoDelete = plantillaSpecialCases.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Where(i => i.CodigoIC == plantilla.CodigoIc);
                                    if (ParamEvoPatrimConjGuissonaFondositemtoDelete != null)
                                    {

                                        foreach (var FondotoDelete in ParamEvoPatrimConjGuissonaFondositemtoDelete)
                                        {
                                           

                                            foreach (var pEvoPatriConj in plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos)
                                            {
                                                if (pEvoPatriConj.Id == FondotoDelete.Id)
                                                {
                                                    plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona_Fondos.Remove(pEvoPatriConj);
                                                    break;
                                                }
                                            }
                                           
                                            DeleteParametros_EvolucionPatrimConjGuissonaFondos(FondotoDelete);
                                            
                                        }
                                        
                                        
                                    }

                                    var ParamEvoPatrimConjGuissonaitemtoDelete = plantillaSpecialCases.Parametros_EvolucionPatrimonioConjuntoGuissona.SingleOrDefault(i => i.CodigoIC == plantilla.CodigoIc);
                                    if (ParamEvoPatrimConjGuissonaitemtoDelete != null)
                                    {
                                        DeleteParametros_EvolucionPatrimConjGuissona(ParamEvoPatrimConjGuissonaitemtoDelete);
                                        //if(plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona!=null)
                                        //{
                                        //    plantilla.Parametros_EvolucionPatrimonioConjuntoGuissona.Remove(ParamEvoPatrimConjGuissonaitemtoDelete);
                                        //}
                                        
                                    }
                                    #endregion
                                    break;
                                case 29: //EVOLUCIÓN PATRIMONIO GUISSONA
                                    #region EVOLUCIÓN PATRIMONIO GUISSONA
                                    var ParamEvoPatriGuissonaitemtoDelete = plantillaSpecialCases.Parametros_EvolucionPatrimGuissona.SingleOrDefault(i => i.CodigoIC == plantilla.CodigoIc);
                                    if (ParamEvoPatriGuissonaitemtoDelete != null)
                                    {

                                        DeleteParametros_EvolucionPatrimGuissona(ParamEvoPatriGuissonaitemtoDelete);
                                    }
                                    //plantillaObject = dbContext.Plantillas.SingleOrDefault(c => c.CodigoIc == plantilla.CodigoIc);
                                    #endregion
                                    break;
                                case 35://OPERACIONES RENTA VARIABLE (II)
                                    #region  OPERACIONES RENTA VARIABLE (II)

                                    var ParamOperacionesRentaVariable_II = plantillaSpecialCases.Parametros_OperacionesRentaVariable_II.Where(i => i.CodigoIC == plantilla.CodigoIc).ToList();
                                    if (ParamOperacionesRentaVariable_II != null)
                                    {
                                        foreach (var itemIPre in ParamOperacionesRentaVariable_II)
                                        {
                                            var paramtoDelete = plantilla.Parametros_OperacionesRentaVariable_II.Where(c => c.Id == itemIPre.Id).SingleOrDefault();
                                            if (paramtoDelete != null) plantilla.Parametros_OperacionesRentaVariable_II.Remove(paramtoDelete);
                                            DeleteParametros_OperacionesRentaVariable_II(itemIPre);
                                        }
                                    }

                                    #endregion
                                    break;
                                case 36: //RATIOS CARTERA RV (¿SECTORIALS?)
                                    #region RATIOS CARTERA RV (¿SECTORIALS?)
                                    var ParamRVitemtoDelete = plantillaSpecialCases.Parametros_RatiosCarteraRV.SingleOrDefault(i => i.CodigoIC == plantilla.CodigoIc);
                                    if (ParamRVitemtoDelete != null)
                                    {
                                        
                                        DeleteParametros_RatiosCarteraRV(ParamRVitemtoDelete);
                                    }
                                    #endregion
                                    break;
                               
                            }
                            #endregion
                        }

                    }
                    #endregion

                    plantillaUpdated = plantilla;
                    result = true;
                    return result;

                    //Si es una plantilla nueva tenemos que asignar el  IdPlantilla a los ISINS creados
                    //plantillaObject.Plantillas_Isins.(i => i.IdPlantilla = this.TextBoxCodigoIc.Text);
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                string error = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                         error = validationError.ErrorMessage + " " + validationError.PropertyName;
                    }
                }

                log.Info(error);
                
                throw dbEx;
            }
            catch (Exception ex)
            {
                plantillaUpdated = plantilla;
                log.Error("Error Saving Plantilla", ex);
                return result;
            }
        }


        public static void DeletePlantilla(Plantilla plantilla)
        {
            if (plantilla != null)
            {
                Reports_IICSEntities dbContext = new Reports_IICSEntities();
                var obj = dbContext.Plantillas.Where(w => w.CodigoIc == plantilla.CodigoIc).FirstOrDefault();
                if (obj != null)
                {
                    try
                    {
                        dbContext.Plantillas.Remove(obj);
                        dbContext.SaveChanges();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }
        }

        /// <summary>
        /// Delete Method
        /// </summary>
        /// <param name="NVtodelete">Object Instrumento</param>
        /// <returns> true(ok) or false(fail)</returns>
        //public static void DeletePlantilla(Plantilla plantilla)
        //{

        //    if (plantilla != null)
        //    {
        //        Reports_IICSEntities dbContext = new Reports_IICSEntities();

        //        if (plantilla.CodigoIc != null)
        //        {

        //            var delPlantilla = dbContext.Plantillas.AsNoTracking().Where(n => n.CodigoIc == plantilla.CodigoIc).FirstOrDefault();
        //            if (delPlantilla != null)
        //            {

        //                foreach (var item in plantilla.Plantillas_Indices_Referencia)
        //                {
        //                    var itemtoDelete = dbContext.Plantillas_Indices_Referencia.SingleOrDefault(c=>c.Id == item.Id);
        //                    if(itemtoDelete!=null) dbContext.Plantillas_Indices_Referencia.Remove(itemtoDelete);
        //                }
        //                foreach (var item in plantilla.Plantillas_Isins)
        //                {
        //                    var itemtoDelete = dbContext.Plantillas_Isins.AsNoTracking().SingleOrDefault(c => c.IdPlantillaIsin == item.IdPlantillaIsin);
        //                    if (itemtoDelete != null) dbContext.Plantillas_Isins.Remove(itemtoDelete);
        //                }
        //                foreach (var item in plantilla.Plantillas_Participes)
        //                {
        //                    var itemtoDelete = dbContext.Plantillas_Participes.AsNoTracking().SingleOrDefault(c => c.Id == item.Id);
        //                    if (itemtoDelete != null) dbContext.Plantillas_Participes.Remove(itemtoDelete);
        //                }
        //                foreach (var item in plantilla.Plantillas_Secciones)
        //                {
        //                    var itemtoDelete = dbContext.Plantillas_Secciones.AsNoTracking().SingleOrDefault(c => c.Id == item.Id);
        //                    if (itemtoDelete != null) dbContext.Plantillas_Secciones.Remove(itemtoDelete);
        //                }
        //                foreach (var item in plantilla.Parametros_GraficoBenchmark)
        //                {
        //                    var itemtoDelete = dbContext.Parametros_GraficoBenchmark.AsNoTracking().SingleOrDefault(c => c.Id == item.Id);
        //                    if (itemtoDelete != null) dbContext.Parametros_GraficoBenchmark.Remove(itemtoDelete);
        //                }
        //                foreach (var item in plantilla.Parametros_EvolucionPatrimGuissona)
        //                {
        //                    var itemtoDelete = dbContext.Parametros_EvolucionPatrimGuissona.AsNoTracking().SingleOrDefault(c => c.Id == item.Id);
        //                    if (itemtoDelete != null) dbContext.Parametros_EvolucionPatrimGuissona.Remove(itemtoDelete);
        //                }
        //                foreach (var item in plantilla.Parametros_RatiosCarteraRV)
        //                {
        //                    var itemtoDelete = dbContext.Parametros_RatiosCarteraRV.AsNoTracking().SingleOrDefault(c => c.Id == item.Id);
        //                    if (itemtoDelete != null) dbContext.Parametros_RatiosCarteraRV.Remove(itemtoDelete);
        //                }

        //                foreach (var item in plantilla.Plantillas_Generaciones_Secciones)
        //                {
        //                    var itemtoDelete = dbContext.Plantillas_Generaciones_Secciones.AsNoTracking().SingleOrDefault(c => c.IdPlantillas_Generaciones_Secciones == item.IdPlantillas_Generaciones_Secciones);
        //                    if (itemtoDelete != null) dbContext.Plantillas_Generaciones_Secciones.Remove(itemtoDelete);
        //                }

        //                dbContext.Plantillas.Remove(delPlantilla);
        //            }
        //            try
        //            {
        //                //save changues to Db
        //                dbContext.SaveChanges();

        //            }

        //            catch (System.Exception e)
        //            {

        //            }
        //        }
        //    }


        //}

        public static IQueryable<string> GetPlantillasCodigosIc()
        {
            dbContext = new Reports_IICSEntities();
            return dbContext.Plantillas.AsNoTracking().Select(p => p.CodigoIc);
        }

        public static List<Plantillas_Estrategias> GetEstrategias()
        {
            dbContext = new Reports_IICSEntities();
            //Las estrategias que utilizan nosotros las tenemos clasificadas con Instrumentos_Tipos
            //pero son sólo algunos de ellos. Los especificamos en la siguiente lista.
            List<string> listaInst = new List<string>(){ "PAT", "CCP", "PER", "OTR"};
            var instrumentos = dbContext.Instrumentos_Tipos.AsNoTracking().Where(w => listaInst.Contains(w.Codigo)).ToList();

            var listaEstrategias = new List<Plantillas_Estrategias>();
            foreach(var instrum in instrumentos)
            {
                var estrategia = new Plantillas_Estrategias();
                estrategia.IdTipoInstrumento = instrum.Id;
                //Añadimos la descripción manualmente porque las Estrategias no existen como tal, son Tipos de Instrumento
                estrategia.Descripcion = instrum.Descripcion;
                listaEstrategias.Add(estrategia);
            }

            return listaEstrategias;
        }

        public static void GuardarGeneracion(Plantilla plantilla, DateTime fechaInforme)
        {
            //Registramos la generación para poder visualizar el último generado
            var gen = dbContext.Plantillas_Generaciones.Where(w => w.CodigoIC == plantilla.CodigoIc).FirstOrDefault();

            if (gen == null)
            {
                gen = new Plantillas_Generaciones();
            }

            gen.FechaGeneracion = DateTime.Now;
            gen.CodigoIC = plantilla.CodigoIc;
            gen.FechaInforme = fechaInforme;

            dbContext.SaveChanges();
            //dbContextTransaction.Commit();
        }
    }
}
