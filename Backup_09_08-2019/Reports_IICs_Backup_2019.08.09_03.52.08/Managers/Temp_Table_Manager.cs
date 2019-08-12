using Reports_IICs.Base;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;

namespace Reports_IICs.Managers
{
    //public class Temp_Table_Manager<TEntity> : BaseManagers<TEntity> where TEntity : class
    public class Temp_Table_Manager : BaseManagers<TempTableBase>
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        //public static void GetTemp(string codigoIC, Type temp)
        //{
        //    var dbContext = new Reports_IICSEntities();

        //    try
        //    {
        //        DbSet dbSet = dbContext.Set(temp);
        //        var keyNames = dbSet.EntitySet.ElementType.KeyMembers.Select(k => k.Name);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        /// <summary>
        /// En algunas ocasiones puede ocurrir que alguna sección no tenga datos.
        /// En estos casos tenemos que borrar su tabla temporal para que al mostrar el informe no aparezcan los datos de una generación anterior para esa sección
        /// </summary>
        /// <param name="secciones"></param>
        private static void borrarTemp(Plantilla plantilla, bool actualizarCambiosPreviewRV, bool actualizarCambiosPreviewRF)
        {
            //foreach (var id in plantilla.Plantillas_Secciones.Select(s=>s.IdSeccion))
            foreach (var ps in plantilla.Plantillas_Secciones)
            {
                //En caso de que acabemos de actualizar la Preview de RV sólo borraremos los datos de las secciones dependientes de RV
                //que vamos a insertar ahora de nuevo
                if (
                    (actualizarCambiosPreviewRV && (ps.Seccione.DependienteRV || ps.IdSeccion == 13))
                    || (actualizarCambiosPreviewRF && (ps.Seccione.DependienteRF || ps.IdSeccion == 21))
                    || (!actualizarCambiosPreviewRV && !actualizarCambiosPreviewRF)
                    )
                {
                    switch (ps.IdSeccion)
                    {
                        //la sección 2 es especial porque se unificaron las secciones 2 y 3
                        case 2:
                            borrarTabla(ps.IdSeccion, plantilla.CodigoIc);
                            //borrarTabla(3, plantilla.CodigoIc);
                            break;
                        //En esta sección mostramos datos de las secciones 6, 11, 13, 21 y 46
                        case 5:
                        case 6:
                        case 46:
                            borrarTabla(5, plantilla.CodigoIc);
                            borrarTabla(6, plantilla.CodigoIc);
                            borrarTabla(11, plantilla.CodigoIc);
                            borrarTabla(13, plantilla.CodigoIc);
                            borrarTabla(21, plantilla.CodigoIc);
                            borrarTabla(46, plantilla.CodigoIc);
                            break;
                        case 17:
                            borrarTabla(13, plantilla.CodigoIc);
                            borrarTabla(16, plantilla.CodigoIc);
                            borrarTabla(17, plantilla.CodigoIc);
                            break;
                        //Tiene dos tablas temporales Temp_PRO_11 y Temp_PRO_12
                        case 26:
                            borrarTabla(26, plantilla.CodigoIc);
                            break;
                        case 45:
                            borrarTabla(2, plantilla.CodigoIc);
                            borrarTabla(3, plantilla.CodigoIc);
                            borrarTabla(25, plantilla.CodigoIc);
                            break;
                        default:
                            borrarTabla(ps.IdSeccion, plantilla.CodigoIc);
                            break;
                    }
                }
            }
        }

        private static void borrarTabla(int idSeccion, string codigoIC)
        {
            var dbContext = new Reports_IICSEntities();
            string predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";

            if (idSeccion == 2)
            {
                //Para la sección 2 tenemos que borrar varias tablas
                var tabla = typeof(Temp_EvolucionPatrValLiq).Name;
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
                tabla = typeof(Temp_EvolucionIndBench).Name;
                predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
            }
            else if (idSeccion == 5)
            {
                //Para la sección 2 tenemos que borrar varias tablas
                var tabla = typeof(Temp_VariacionPatrimonialA).Name;
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
                tabla = typeof(Temp_VariacionPatrimonialA_Totales).Name;
                predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
            }
            else if(idSeccion == 12)
            {
                var tabla = typeof(Temp_DistribucionPatrimonioNovarex_Cartera).Name;
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
                tabla = typeof(Temp_DistribucionPatrimonioNovarex_Tesoreria).Name;
                predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
            }
            else if(idSeccion == 26)
            {
                //Para la sección 26 tenemos que borrar 2 tablas
                var tabla = typeof(Temp_PRO_11).Name;
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
                tabla = typeof(Temp_PRO_12).Name;
                predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
            }
            else if (idSeccion == 27)
            {
                //Para la sección 26 tenemos que borrar 2 tablas
                var tabla = typeof(Temp_EvolucionRentabilidadGuissona).Name;
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
                //Esto no hay que borrarlo, son parámetros ahora
                //tabla = typeof(Temp_EvolucionRentabilidadGuissona_Fondos).Name;
                //predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                //predicate = string.Format(predicate, tabla, codigoIC);
                //dbContext.Database.ExecuteSqlCommand(predicate);
                tabla = typeof(Temp_EvolucionRentabilidadGuissona_TAE).Name;
                predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
            }
            else if (idSeccion == 29)
            {
                //Para esta sección tenemos que borrar varias tablas
                var tabla = typeof(Temp_EvolucionPatrGuissonaValLiq).Name;
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);

                tabla = typeof(Temp_EvolucionPatrGuissonaIndBench).Name;
                predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);

                tabla = typeof(Temp_EvolucionPatrGuissonaRentabilidad).Name;
                predicate = "DELETE FROM {0} WHERE CodigoIC = '{1}'";
                predicate = string.Format(predicate, tabla, codigoIC);
                dbContext.Database.ExecuteSqlCommand(predicate);
            }
            else
            {
                var temp = VariablesGlobales.TablasSecciones.Where(w => w.Item1 == idSeccion).FirstOrDefault();

                if (temp != null)
                {
                    predicate = string.Format(predicate, temp.Item2, codigoIC);

                    dbContext.Database.ExecuteSqlCommand(predicate);
                }
            }

            dbContext.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="plantilla"></param>
        /// <param name="temp"></param>
        /// <param name="fechaInforme"></param>
        /// <param name="actualizarCambiosPreview">Es True si se acaban de hacer cambios en la Preview de RV y hay que actualizar sólo las secciones dependientes sin  borrar los datos insertados para el resto de secciones</param>
        public static void InsertTemp(Plantilla plantilla, List<TempTableBase> temp, DateTime fechaInforme, bool actualizarCambiosPreviewRV, bool actualizarCambiosPreviewRF)
        {
            var dbContext = new Reports_IICSEntities();
            //Primero borramos las tablas temporales de las secciones que vamos a generar para ese codigoIC
            borrarTemp(plantilla, actualizarCambiosPreviewRV, actualizarCambiosPreviewRF);

            try
            {
                var entidades = temp.GroupBy(p => p.GetType());
                //DbSet<TEntity> dbSet = dbContext.Set<TEntity>();

                foreach (var entidad in entidades)
                {
                    try
                    {
                        //if(entidad.First().GetType() == new Temp_Participes().GetType())
                        //{
                        //    bool flag = true;
                        //}
                        DbSet dbSet = dbContext.Set(entidad.First().GetType());

                        //Si hubiera datos para este CodigoIC los borramos antes de insertar    
                        string tabla = entidad.First().GetType().Name;

                        //Para Temp_ParticipesSalat borramos de una forma especial
                        
                        if (tabla.Equals("Temp_ParticipesSalat"))
                        {
                            #region  Temp_ParticipesSalat
                            //Primero borramos que se insertarán en cada generación para sólo quedarnos con
                            //los introducidos a mano en la preview                            
                            //Borrar Participes 
                            dbContext.ParticipesSalat_Participes.RemoveRange(dbContext.ParticipesSalat_Participes);
                            //Borrar periodos (y sus lineas) a partir de la fecha que hay datos
                            //esto es los periodos posteriores a 27/4/2016
                            var fechaInicioPart = new DateTime(2016, 4, 27);
                            
                            dbContext.ParticipesSalat_Periodos.RemoveRange(dbContext.ParticipesSalat_Periodos.Where(w => w.FechaSaldo > fechaInicioPart));
                            dbContext.SaveChanges();


                            //var obj = ParticipesSalat_DA.Get_ParticipesSalat();
                            ////Si ya se ha generado alguna vez
                            //if (obj != null)
                            //{
                            //    int idTempPartSal = obj.Id;
                            //    var objNew = (ParticipesSalat)entidad.First();
                            //    //Añadimos los datos nuevos que se han generado
                            //    //obj.Temp_ParticipesSalat_Participes.ToList().AddRange(objNew.Temp_ParticipesSalat_Participes.ToList());
                            //    foreach(var part in objNew.ParticipesSalat_Participes)
                            //    {
                            //        obj.ParticipesSalat_Participes.Add(part);
                            //    }
                            //    foreach (var perio in objNew.ParticipesSalat_Periodos)
                            //    {
                            //        obj.ParticipesSalat_Periodos.Add(perio);
                            //    }

                            //}
                            ////si es la primera vez que se genera
                            //else
                            //{ 
                            //    obj = ((ParticipesSalat)entidad.First());
                            //    dbContext.ParticipesSalat.Add(obj);
                            //}

                            //la entidad nos vale igual para la parte histórica (si tuviera)
                            //esto es los periodos posteriores a 27/4/2016, que los actualizaremos a continuación
                            //por tanto los eliminamos de este objeto para que se inserten actualizados
                            //var fechaInicioPart = new DateTime(2016, 4, 27);
                            //dbContext.Temp_ParticipesSalat_Periodos.ToList().RemoveAll(w => w.FechaSaldo > fechaInicioPart);
                            #endregion
                        }
                        //else if (tabla.Equals("Temp_RentabilidadCarteraSolemeg"))
                        //{
                        //}
                        else
                        {
                            //var predicate = string.Format("DELETE FROM {0} WHERE CodigoIC = '{1}'", tabla, plantilla.CodigoIc);
                            //dbContext.Database.ExecuteSqlCommand(predicate);
                            //Insert

                            dbSet.AddRange(entidad);
                        }

                        
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }

                //Registramos la generación para poder visualizar el último generado
                //var gen = dbContext.Plantillas_Generaciones.Where(w => w.CodigoIC == plantilla.CodigoIc).FirstOrDefault();

                //if(gen == null)
                //{
                //    gen = new Plantillas_Generaciones();
                //}

                //gen.FechaGeneracion = DateTime.Now;
                //gen.CodigoIC = plantilla.CodigoIc;
                //gen.FechaInforme = fechaInforme;

                dbContext.SaveChanges();
                //dbContextTransaction.Commit();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
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
                throw new System.Data.Entity.Validation.DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
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

        public static void DeleteTemp(string codigoIC,System.Type entidad)
        {
            #region Eliminar Temp
            var dbContext = new Reports_IICSEntities();

            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    
                    DbSet dbSet = dbContext.Set(entidad);

                    var predicate = string.Format("DELETE FROM {0} WHERE CodigoIC = '{1}'", entidad.Name, codigoIC);

                    predicate = predicate.Replace("Reports_IICs.DataModels.", "");
                    dbContext.Database.ExecuteSqlCommand(predicate);


                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();
                }
                catch (Exception ex)
                {
                    dbContextTransaction.Rollback();
                    throw ex;
                }
            }
            #endregion
        }
    }
    //public class Temp_Table_Manager2<TEntity> : BaseManagers<TEntity> where TEntity : TempTableBase
    //{
    //    public void InsertTemp(string codigoIC, List<TEntity> temp)
    //    {
    //        var dbContext = new Reports_IICSEntities();

    //        try
    //        {
    //            DbSet<TEntity> dbSet = dbContext.Set<TEntity>();

    //            //Si hubiera datos para este CodigoIC los borramos antes de insertar
    //            dbSet.RemoveRange(dbSet.Where(t => t.CodigoIC == codigoIC));

    //            //Insert
    //            dbSet.AddRange(temp);
    //            dbContext.SaveChanges();
    //        }
    //        catch (Exception ex)
    //        {
    //            throw ex;
    //        }
    //    }
    //}


}
