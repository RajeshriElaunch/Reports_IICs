using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Reports.Cartera;
using System;
using System.Collections.Generic;
using Telerik.Reporting;
using System.Linq;
using Reports_IICs.Helpers;
using System.Data;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    //public class Cartera_VM_Prueba<TEntity> : BaseManagers<TEntity> where TEntity : TempTableBase
    public static class Cartera_VM_Prueba
    {
        public static void Insert_Temp(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            try
            {
                var listaTmp11 = Insert_Temp_PRO_11(plantilla, fecha, ref listaTmp);
                var listaTmp12 = Insert_Temp_PRO_12(plantilla, fecha, ref listaTmp);

                listaTmp = listaTmp11.Concat(listaTmp12).ToList();
                //Temp_Table_Manager2.InsertTemp(plantilla.CodigoIc, listaTmp);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static List<TempTableBase> Insert_Temp_PRO_11(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            //List<TempTableBase> listaTmp = new List<TempTableBase>();

            var pro11Result = VariablesGlobales.Pro11_Local;
            //Para el cálculo del % no tenemos en cuenta los DER
            var EfecActTotal = pro11Result.Where(w => w.CodTipoInstrumento != "DER").Sum(s => s.efeact);
            foreach (var pro11_item in pro11Result)
            {
                try
                {                    
                    Temp_PRO_11 pro11temp = new Temp_PRO_11();
                    //Copiamos el contenido de pro11_item en pro11temp
                    //Utils.CopyPropertyValues(pro11_item, pro11temp);
                    pro11temp.CodigoIC = plantilla.CodigoIc;
                    pro11temp.Isin = pro11_item.isin.ToUpper();
                    //Quieren mostrar unos tipos especiales y no los nuestros
                    //Cuando son del Tipo VAL y AMP, vamos a buscar la equivalencia con el Instrumento, no con el tipo
                    if (pro11_item.CodTipoInstrumento == "VAL" || pro11_item.CodTipoInstrumento == "AMP")
                    {
                        pro11temp.Tipo = VariablesGlobales.LookUpInstrumentoEquivalencia(pro11_item.CodInstrumento);
                    }
                    else
                    {
                        pro11temp.Tipo = VariablesGlobales.LookUpInstrumentoEquivalencia(pro11_item.CodTipoInstrumento);
                    }

                    pro11temp.DescripcionValor = pro11_item.descr.Trim();
                    pro11temp.Divisa = pro11_item.div;
                    pro11temp.Dias = pro11_item.diasvto;
                    pro11temp.Vencimiento = pro11_item.datvto;
                    pro11temp.Nominal = pro11_item.nomina;
                    pro11temp.Cantidad = pro11_item.cantid;
                    pro11temp.EfectivoCompra = pro11_item.efecos;
                    pro11temp.TIR_C_Fif = pro11_item.tircom;
                    pro11temp.CosteMedio = pro11_item.cosmed;
                    pro11temp.ValorActualDivisa = pro11_item.valact;
                    pro11temp.Cambio = pro11_item.cambio;
                    pro11temp.Intereses = pro11_item.interes;
                    if (pro11_item.plusva > 0)
                    {
                        pro11temp.Plusvalias = pro11_item.plusva;
                        pro11temp.Minusvalias = 0;
                    }
                    else
                    {
                        pro11temp.Plusvalias = 0;
                        pro11temp.Minusvalias = pro11_item.plusva * (-1);
                    }
                    pro11temp.EfectivoActual = pro11_item.efeact;

                    //pro11temp.PorcentajeP = pro11_item.TPC2;
                    var patrimTotal = Utils.GetPatrimonio(plantilla.CodigoIc, string.Empty, Convert.ToDateTime(fecha));
                    pro11temp.PorcentajeP = (pro11_item.efeact * 100) / patrimTotal; 
                    //Es el peso del EfectivoActual en el EfectivoActual Total
                    decimal porc = (pro11_item.efeact * 100) / EfecActTotal;
                    pro11temp.Porcentaje = decimal.Round(porc, 2);
                    //decimal rounded = decimal.Round(Convert.ToDecimal(pro11temp.Porcentaje), 2);                

                    listaTmp.Add(pro11temp);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


            return listaTmp;
        }

        private static List<TempTableBase> Insert_Temp_PRO_12(Plantilla plantilla, DateTime? fecha, ref List<TempTableBase> listaTmp)
        {
            //List<TempTableBase> listaTmp = new List<TempTableBase>();

            //var isins = plantilla.Plantillas_Generaciones_Plantilla.FirstOrDefault().Plantilla.Plantillas_Generaciones_Isins.Select(p => p.Isin);

            foreach (var isin in plantilla.Plantillas_Isins)
            {                            
                try
                {
                    DataTable dt = Reports_DA.GetPRO12(plantilla.CodigoIc, isin.Isin, Convert.ToDateTime(fecha));
                    
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        Temp_PRO_12 pro12temp = new Temp_PRO_12();
                        //Copiamos el contenido de pro12Result en pro12temp
                        //Utils.CopyPropertyValues(pro12Result, pro12temp);
                        pro12temp.CodigoIC = plantilla.CodigoIc;
                        pro12temp.Isin = isin.Isin;
                        pro12temp.Rentabilidad = Utils.CheckDecimal(dt.Rows[0]["rentabilidad"].ToString());
                        pro12temp.TotalPatrimonio = Utils.CheckDecimal(dt.Rows[0]["patrimonio"].ToString());
                        pro12temp.TotalParticipaciones = Utils.CheckDecimal(dt.Rows[0]["participaciones"].ToString());
                        pro12temp.ValorLiquidativo = Utils.CheckDecimal(dt.Rows[0]["valliq"].ToString());
                        pro12temp.TAE = Utils.CheckDecimal(dt.Rows[0]["tae"].ToString());
                        pro12temp.SaldoTesoreria = Utils.CheckDecimal(dt.Rows[0]["saldotesor"].ToString());
                        pro12temp.ActivoComputable = Utils.CheckDecimal(dt.Rows[0]["activo"].ToString());

                        listaTmp.Add(pro12temp);
                    }
                }
                catch (Exception)
                {

                }
                //}
            }
            return listaTmp;
        }
    }
    public static class Cartera_VM
    {
        public static Report GetReportCartera(string codigoIC, DateTime fecha, Plantilla plantilla)
        {
            //Telerik.Reporting.SqlDataSource sqlDataSource = new Telerik.Reporting.SqlDataSource();
            //sqlDataSource.ConnectionString = "Reports_IICs.Properties.Settings.ReportsIICS_Reports";

            //Llamada al procedimiento correspondientes

            //sqlDataSource.SelectCommand = "Get_Temp_PRO_11";
            //sqlDataSource.SelectCommandType = SqlDataSourceCommandType.StoredProcedure;
            //sqlDataSource.Parameters.Add("@CodigoIC", System.Data.DbType.String, codigoIC);

            //test 23/05/2019 -- start

            //Report_Cartera rep = new Report_Cartera(codigoIC, fecha, plantilla);
            Report_Cartera rep = new Report_Cartera(plantilla.CodigoIc, fecha, plantilla);
            //test 23/05/2019 -- end
            //rep.DataSource = sqlDataSource;            


            return rep;
        }
        
        
        
        public static Report GetReportPro12(Plantilla plantilla, string isin, string isinDesc, DateTime fecha)
        {
            Telerik.Reporting.Report rep = new Report_PRO_12();
            rep.ReportParameters["CodigoIC"].Value = plantilla.CodigoIc;
            rep.ReportParameters["Isin"].Value = isin;            
            rep.ReportParameters["IsinDesc"].Value = isinDesc;
            //Si tiene más de una clase no mostramos el Saldo Tesorería
            //Porque mostraría el mismo valor en cada cajita de cada clase y es un valor que pertenece a toda la cartera
            rep.ReportParameters["ShowTesoreria"].Value = plantilla.Plantillas_Isins.Count == 1 ? true : false;
            //rep.DataSource = Cartera_DA.GetTemp_PRO_12(codigoIC, isin).ToList();
            return rep;
        }
        
      
        
    }
}