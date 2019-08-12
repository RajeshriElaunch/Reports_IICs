using Reports_IICs.DataAccess.Instrumentos;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.GraficoComposicionCartera;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class GraficoCompCartRV_VM
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                //List<Temp_GraficoCompCarteraRV> listaPro04temp = new List<Temp_GraficoCompCarteraRV>();

                //foreach (var isin in plantilla.Plantillas_Isins)
                //{
                    List<string> listaTipos = new List<string>() { "VAL", "IIC" };

                    var pro11Result = VariablesGlobales.Pro11_Local.Where(p => VariablesGlobales.InstrumentosImportados_Local.
                                                                        Where(i => i.Instrumento.Codigo.Equals("RVA")
                                                                                && listaTipos.Contains(i.Instrumentos_Tipos.Codigo)
                                                                                ).Select(s => s.ISIN).Contains(p.isin, StringComparer.CurrentCultureIgnoreCase)).ToList();

                    //Si la plantilla tiene seleccionada la estrategia PATRIMONIALISTA => idTipoInstrumento == 5
                    //No mostramos los instrumentos que tengan Tipo2 = PAT
                    if (plantilla.Plantillas_Estrategias.Where(w => w.IdTipoInstrumento == "5").Count() > 0)//PAT
                    {
                        pro11Result = pro11Result.Where(w => w.IdTipoInstrumento2 != "5").ToList();
                    }

                    if (pro11Result != null)
                    {
                        foreach (var item in pro11Result)
                        {
                            try
                            {
                                //var datosIsin = dbContext.Instrumentos_Importados.Where(i => i.ISIN == item.isin).FirstOrDefault();
                                var datosIsin = InstrumentosImportados_DA.GetInstrumentoImportadoByIsin(item.isin);
                                if (datosIsin != null && item.efeact > 0)
                                {
                                    Temp_GraficoCompCarteraRV graficoCompCarteraRVTemp = new Temp_GraficoCompCarteraRV();
                                    //Copiamos el contenido de pro04Result en pro04temp
                                    //Para este caso buscamos la categoría que tengamos asignada a este sector en la tabla 
                                    if (datosIsin.IdCategoria != null)
                                        graficoCompCarteraRVTemp.Categoria = GraficoCompCartRV_DA.GetCategoriaBySector(datosIsin.Instrumentos_Sectores.Descripcion);
                                    graficoCompCarteraRVTemp.CodigoIC = plantilla.CodigoIc;
                                    graficoCompCarteraRVTemp.Divisa = item.div;
                                    if (datosIsin.IdEmpresa != null)
                                        graficoCompCarteraRVTemp.Empresa = datosIsin.Instrumentos_Empresas.Descripcion;
                                    //graficoCompCarteraRVTemp.Isin = string.Empty;
                                    graficoCompCarteraRVTemp.Patrimonio = item.efeact;
                                    //graficoCompCarteraRVTemp.Patrimonio = item.TPC2;
                                    graficoCompCarteraRVTemp.Pais = datosIsin.Instrumentos_Paises.Descripcion;
                                    if (datosIsin.IdSector != null)
                                        graficoCompCarteraRVTemp.Sector = datosIsin.Instrumentos_Sectores.Descripcion;

                                    listaTmp.Add(graficoCompCarteraRVTemp);
                                }
                                else
                                {

                                }
                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                        }
                    }
                //}

                //GraficoCompCartRV_DA.Insert_Temp(plantilla, listaPro04temp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static Report GetReportGraficosComposicionCarteraRV(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new ReportCompCartRV(isin, isinDesc, plantilla.CodigoIc);
            //ReportParameters.Add("MemberID", "5");
            //var HasValues = Cartera_DA.GetTemp_PRO_04(plantilla.CodigoIc, isin, fecha).ToList();
            //if (isin != null)
                rep.ReportParameters["Isin"].Value = isin;
            //if (plantilla.CodigoIc != null)
                rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            return rep;
        }

    }
}
