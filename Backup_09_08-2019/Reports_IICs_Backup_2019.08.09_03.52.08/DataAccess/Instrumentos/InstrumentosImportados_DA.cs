using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Linq;

namespace Reports_IICs.DataAccess.Instrumentos
{
    public  class Query_Instrumentos_Importados
    {
        
        public string ISIN { get; set; }
        //public Nullable<int> IdTipoInstrumento { get; set; }
        public string TipoInstrumento { get; set; }
        public string TipoInstrumento2 { get; set; }
        public string TipoInstrumento3 { get; set; }
        public string Sector { get; set; }
        public Nullable<bool> Emergente { get; set; }
        //public Nullable<int> IdCategoria { get; set; }
        public string descripcionCategoria { get; set; }
        //public Nullable<int> IdEmpresa { get; set; }
        public string descripcionEmpresa { get; set; }
        //public Nullable<int> IdInstrumento { get; set; }
        public string descripcionInstrumento { get; set; }
        //public Nullable<int> IdZona { get; set; }
        public string descripcionZona { get; set; }
        //public Nullable<int> IdPais { get; set; }
        public string descripcionPais { get; set; }
    }

    public static class InstrumentosImportados_DA
    {
        private static Reports_IICSEntities dbContext = new Reports_IICSEntities();


        public static IEnumerable<Instrumentos_Importados> GetAll()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return dbContext.Instrumentos_Importados;
        }

        public static IEnumerable<Instrumentos_Importados> GetInstrumentosRV()
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            return VariablesGlobales.InstrumentosImportados_Local.Where(w => w.Instrumento.Codigo.Equals("RVA"));
        }

        public static IEnumerable<Query_Instrumentos_Importados> GetQuery()
        {
            var InsImportQuery = (from ii in VariablesGlobales.InstrumentosImportados_Local
                                  join itipo in dbContext.Instrumentos_Tipos on ii.IdTipoInstrumento equals itipo.Id
                                  join itipo2 in dbContext.Instrumentos_Tipos on ii.IdTipoInstrumento equals itipo2.Id
                                  join itipo3 in dbContext.Instrumentos_Tipos on ii.IdTipoInstrumento equals itipo3.Id
                                  join isector in dbContext.Instrumentos_Sectores on ii.IdSector equals isector.Id
                                  join icategoria in dbContext.Instrumentos_Categorias on ii.IdCategoria equals icategoria.Id
                                  join iempresa in dbContext.Instrumentos_Empresas on ii.IdEmpresa equals iempresa.Id
                                  join iinstrumentos in dbContext.Instrumentos on ii.IdInstrumento equals iinstrumentos.Id
                                  join izona in dbContext.Instrumentos_Zonas on ii.IdZona equals izona.Id
                                  join ipais in dbContext.Instrumentos_Paises on ii.IdPais equals ipais.Id
                                  //where e.OwnerID == user.UID
                                  select new Query_Instrumentos_Importados
                                  {
                                      ISIN = ii.ISIN,
                                      //IdTipoInstrumento = ii.IdTipoInstrumento,
                                      TipoInstrumento = itipo.Descripcion,
                                      TipoInstrumento2 = itipo2.Descripcion,
                                      TipoInstrumento3 = itipo3.Descripcion,
                                      Sector = isector.Descripcion,
                                      Emergente = ii.Emergente,
                                      //IdCategoria = ii.IdCategoria,
                                      descripcionCategoria = icategoria.Descripcion,
                                      //IdEmpresa = ii.IdEmpresa,
                                      descripcionEmpresa = iempresa.Descripcion,
                                      //IdInstrumento = ii.IdInstrumento,
                                      descripcionInstrumento = iinstrumentos.Descripcion,
                                      //IdZona = ii.IdZona,
                                      descripcionZona = izona.Descripcion,
                                      //IdPais = ii.IdPais,
                                      descripcionPais = ipais.Descripcion
                                  });
            return InsImportQuery;
        }

        public static bool GuardarInstrumentosImportados(List<Instrumentos_Importados> listaInstr)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();
            //Primero borramos los existentes
            dbContext.Instrumentos_Importados.RemoveRange(dbContext.Instrumentos_Importados);
            dbContext.Instrumentos_Importados.AddRange(listaInstr);

            try
            {
                dbContext.SaveChanges();
                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
        public static bool GuardarInstrumentoImportado(DataTable dt)
        {
            using (var dbContextTransaction = dbContext.Database.BeginTransaction())
            {
                try
                {
                    //Aquí almacenaremos todos los instrumentos importados a guardar para hacerlo en una sola llamada a bd
                    List<Instrumentos_Importados> listaInstrumentosImportados = new List<Instrumentos_Importados>();
                    foreach (DataRow dr in dt.Rows)
                    {
                        Instrumentos_Importados intrumentoImportadoObject = new Instrumentos_Importados();
                        intrumentoImportadoObject.ISIN = dr["Isin"].ToString().ToUpper();

                        var idTipo = VariablesGlobales.LookUpInstrumentos_Tipo(dr["Tipo"].ToString());
                        var idTipo2 = VariablesGlobales.LookUpInstrumentos_Tipo(dr["Tipo2"].ToString());
                        var idTipo3 = VariablesGlobales.LookUpInstrumentos_Tipo(dr["Tipo3"].ToString());
                        intrumentoImportadoObject.IdTipoInstrumento = idTipo != null ? idTipo.ToString() : string.Empty;
                        intrumentoImportadoObject.IdTipoInstrumento2 = idTipo2 != null ? idTipo2.ToString() : string.Empty;
                        intrumentoImportadoObject.IdTipoInstrumento3 = idTipo3 != null ? idTipo3.ToString() : string.Empty;
                        intrumentoImportadoObject.IdSector = VariablesGlobales.LookUpInstrumentos_Sector(dr["Sector"].ToString());
                        bool? emergente = null;
                        if (dr["Emergente"].ToString().Equals("Sí"))
                        {
                            emergente = true;
                        }
                        else if (dr["Emergente"].ToString().Equals("No"))
                        {
                            emergente = false;
                        }
                        intrumentoImportadoObject.Emergente = emergente;
                        intrumentoImportadoObject.IdCategoria = VariablesGlobales.LookUpInstrumentos_Categoria(dr["Categoría"].ToString());
                        intrumentoImportadoObject.IdEmpresa = VariablesGlobales.LookUpInstrumentos_Empresa(dr["Empresa"].ToString());

                        var idInstr = VariablesGlobales.LookUpInstrumento(dr["Instrumento"].ToString());
                        intrumentoImportadoObject.IdInstrumento = idInstr != null ? idInstr.ToString() : string.Empty;
                        intrumentoImportadoObject.IdZona = VariablesGlobales.LookUpInstrumentos_Zona(dr["Zona"].ToString());
                        intrumentoImportadoObject.IdPais = VariablesGlobales.LookUpInstrumentos_Pais(dr["País"].ToString());
                        intrumentoImportadoObject.TickerBloomberg = dr["TICKER BLOOMBERG"].ToString();
                        intrumentoImportadoObject.PuntuacionSmallBig = Utils.CheckDecimal(dr["PUNTUACIÓN SMALL-BIG"].ToString()); // string.IsNullOrEmpty(dr["PUNTUACIÓN SMALL-BIG"].ToString())?0:Convert.ToDecimal( dr["PUNTUACIÓN SMALL-BIG"].ToString());
                        intrumentoImportadoObject.PuntaucionValueGrowth = Utils.CheckDecimal(dr["PUNTUACIÓN VALUE-GROWTH"].ToString()); //string.IsNullOrEmpty(dr["PUNTUACIÓN VALUE-GROWTH"].ToString()) ? 0 : Convert.ToDecimal(dr["PUNTUACIÓN VALUE-GROWTH"].ToString());
                        intrumentoImportadoObject.PuntuacionUta = Utils.CheckDecimal(dr["PUNTUACIÓN UTA"].ToString()); //string.IsNullOrEmpty(dr["PUNTUACIÓN UTA"].ToString()) ? 0 : Convert.ToDecimal(dr["PUNTUACIÓN UTA"].ToString());

                        listaInstrumentosImportados.Add(intrumentoImportadoObject);
                    }

                    //insertamos los nuevos Isins y actualizamos los existentes 
                    //actualizamos existentes

                    //var result = peopleList2.Where(p => !peopleList1.Any(p2 => p2.ID == p.ID));
                    var existentes = listaInstrumentosImportados.Where(i => VariablesGlobales.InstrumentosImportados_Local.Any(l => l.ISIN == i.ISIN));
                    var nuevos = listaInstrumentosImportados.Where(i => !VariablesGlobales.InstrumentosImportados_Local.Any(l => l.ISIN == i.ISIN));
                    foreach (var i in existentes)
                    {
                        var c = VariablesGlobales.InstrumentosImportados_Local.Where(a => a.ISIN.Equals(i.ISIN)).FirstOrDefault();
                        if (c != null)
                        {
                            c.IdTipoInstrumento = i.IdTipoInstrumento;
                            c.IdTipoInstrumento2 = i.IdTipoInstrumento2;
                            c.IdTipoInstrumento3 = i.IdTipoInstrumento3;
                            c.IdSector = i.IdSector;
                            c.Emergente = i.Emergente;
                            c.IdCategoria = i.IdCategoria;
                            c.IdEmpresa = i.IdEmpresa;
                            c.IdInstrumento = i.IdInstrumento;
                            c.IdZona = i.IdZona;
                            c.IdPais = i.IdPais;
                            c.TickerBloomberg = i.TickerBloomberg;
                            c.PuntuacionSmallBig = i.PuntuacionSmallBig;
                            c.PuntaucionValueGrowth = i.PuntaucionValueGrowth;
                            c.PuntuacionUta = i.PuntuacionUta;
                        }
                    }
                    dbContext.SaveChanges();

                    dbContext.Instrumentos_Importados.AddRange(nuevos);
                    dbContext.SaveChanges();
                    dbContextTransaction.Commit();

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

                    return false;
                }
                catch (Exception)
                {
                    dbContextTransaction.Rollback();

                    return false;
                }
            }

        }

        public static IEnumerable<string> GetIsinsSector(int idSector)
        {
            var isins = VariablesGlobales.InstrumentosImportados_Local.Where(ii => ii.IdSector == idSector).Select(s => s.ISIN);
            return isins;
        }

        public static Instrumentos_Importados GetInstrumentoImportadoByIsin(string isin)
        {
            var instr = VariablesGlobales.InstrumentosImportados_Local.Where(ii => ii.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();
            return instr;
        }

        public static bool EsRF_ByIsin(string isin)
        {
            var obj = GetInstrumentoImportadoByIsin(isin);

            if(obj != null && obj.IdInstrumento == "2")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string GetIdInstrumentoImportadoByIsin(string isin)
        {
            string output = string.Empty;

            if (isin != null)
            {
                var instr = VariablesGlobales.InstrumentosImportados_Local.Where(ii => ii.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                if (instr != null)
                {
                    output = instr.IdInstrumento;
                }
            }
            return output;
        }

        public static string GetIdTipoInstrumentoImportadoByIsin(string isin)
        {
            string output = string.Empty;

            if (isin != null)
            {
                var instr = VariablesGlobales.InstrumentosImportados_Local.Where(ii => ii.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                if (instr != null)
                {
                    output = instr.IdTipoInstrumento;
                }
            }
            return output;
        }

        public static int? GetIdCategoriaInstrumentoImportadoByIsin(string isin)
        {
            int? output = null;

            if (isin != null)
            {
                var instr = VariablesGlobales.InstrumentosImportados_Local.Where(ii => ii.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                if (instr != null)
                {
                    output = instr.IdCategoria;
                }
            }
            return output;
        }

        public static int? GetIdEmpresaInstrumentoImportadoByIsin(string isin)
        {
            int? output = null;

            if (isin != null)
            {
                var instr = VariablesGlobales.InstrumentosImportados_Local.Where(ii => ii.ISIN.ToUpper() == isin.ToUpper()).FirstOrDefault();

                if (instr != null)
                {
                    output = instr.IdEmpresa;
                }
            }
            return output;
        }        

        public static IEnumerable<Instrumentos_Importados> GetInstrumentosImportadosByIsin(List<string> isins)
        {
            var instr = VariablesGlobales.InstrumentosImportados_Local.Where(ii => isins.Contains(ii.ISIN.ToUpper()));
            return instr;
        }

        public static string GetPaisInstrumento(string isin)
        {
            string pais = string.Empty;
            var instr = VariablesGlobales.InstrumentosImportados_Local.Where(ii => ii.ISIN == isin).FirstOrDefault();
            if (instr != null)
            {
                pais = instr.Instrumentos_Paises.Descripcion;
            }
            return pais;
        }

        public static List<string> GetInstrumentosNoImportados(Plantilla plantilla, List<string> listaInstr)
        {
            //Aquí guardamos los ISINS que vienen en listaInstr y no se encuentran en la tabla Instrumentos_Importados
            //List<string> listaNoImp = dbContext.Instrumentos_Importados.Where(w => !listaInstr.Contains(w.ISIN, StringComparer.CurrentCultureIgnoreCase)).Select(s => s.ISIN).ToList();
            var importados = VariablesGlobales.InstrumentosImportados_Local.Where(w => listaInstr.Contains(w.ISIN.ToUpper())).ToList();
            var noImp = listaInstr.Except(importados.Select(s => s.ISIN.Trim())).ToList();

            noImp = Utils.ExcluirIsinsPlantilla(plantilla, noImp);

            return noImp;
        }
    }
}
