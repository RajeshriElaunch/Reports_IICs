using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataAccess.Secciones;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using Reports_IICs.Reports.ParticipesSalat;
using System;
using System.Collections.Generic;
using System.Linq;
using Telerik.Reporting;

namespace Reports_IICs.ViewModels.Reports.Secciones
{
    public static class ParticipesSalat_VM
    {
        private static ParticipesSalat _ps = new DataModels.ParticipesSalat();
        public static void Insert_Temp(Plantilla plantilla, DateTime? fechaInforme)
        {
            try
            {
                //Anna: se debe tener en cuenta que la información de los accionistas empieza el 01/05/2016 antes no existe por lo que no devolverá datos. 
                //Anna: para las sicavs no existe información anterior al 27/4/2016.
                var fechaIni = Utils.GetFechaInicio(plantilla, Convert.ToDateTime(fechaInforme));

                foreach (var isinPlantilla in plantilla.Plantillas_Isins)
                {
                    //Copiamos sólo los datos de ParticipesSalat (no copiamos ni aportaciones, ni participes, ni nada más)
                    _ps = new ParticipesSalat_MNG().Get();
                    if (_ps == null)
                    {
                        new ParticipesSalat_MNG().Save(_ps, null);
                        _ps = new ParticipesSalat_MNG().Get();
                    }
                    
                    //Comprobamos si ya existe
                    //var obj = ParticipesSalat_DA.Get_Temp_ParticipesSalatByCodigoIC(plantilla.CodigoIc);
                    //tmp.CodigoIC = plantilla.CodigoIc;

                    try
                    {
                        //Añadimos los partícipes
                        //foreach (var part in plantilla.Parametros_ParticipesSalat)                    

                        foreach (var part in plantilla.Plantillas_Participes)
                        {
                            var participe = getNuevoTemp_Participes(plantilla.CodigoIc, isinPlantilla.Isin, Convert.ToDateTime(fechaInforme), part);

                            //Guardamos en DB los partícipes
                            new ParticipesSalat_Participes_MNG().Save(participe, null);
                            _ps = new ParticipesSalat_MNG().Get();
                        }

                        // Borramos los partícipes que estén en la tabla ParticipesSalat_Participes y no estén en Plantillas_Participes con el codigoIC de la plantilla actual
                        new ParticipesSalat_Participes_MNG().BorrarInexistentes(plantilla.Plantillas_Participes);

                        //la entidad nos vale igual para la parte histórica (si tuviera)
                        //esto es los periodos posteriores a 27/4/2016, que los actualizaremos a continuación
                        //por tanto los eliminamos de este objeto para que se inserten actualizados
                        /*var fechaInicioPart = new DateTime(2016, 4, 27);
                        tmp.Temp_ParticipesSalat_Periodos.ToList().RemoveAll(w => w.FechaSaldo > fechaInicioPart);*/

                        //Añadimos los periodos 
                        //no hay datos anteriores a 27/4/2016. 
                        //var fechaInicioPart = new DateTime(2016, 4, 27);
                        //Así que añadimos un periodo por año desde esa fecha 
                        //añadimos periodos a 31/12 y a fecha de informe
                        //Los periodos anteriores se introducen en la preview
                        //for (int i = fechaInicioPart.Year; i <= Convert.ToDateTime(fechaInforme).Year; i++)
                        //{
                        //var fechaPeriodo = new DateTime();
                        //if (fechaInicioPart.Year < Convert.ToDateTime(fechaInforme).Year)
                        //{
                        //    //Cogemos 31/12
                        //    fechaPeriodo = new DateTime(fechaInicioPart.Year, 12, 31);
                        //}
                        //else
                        //{
                        //    fechaPeriodo = Convert.ToDateTime(fechaInforme);
                        //}

                        //Borraremos primero los periodos que tengan la misma fecha de saldo
                        //o fechas posteriores
                        //puesto que el último periodo se crea con cada generación
                        //EN VEZ DE BORRARLOS DEBERÍAMOS NO MOSTRARLOS NI EN LA PREVIEW NI EN EL REPORT
                        //var periodosBorrar = new ParticipesSalat_Periodos_MNG().GetByFecha(fechaPeriodo);
                        //foreach(var per in periodosBorrar)
                        //{
                        //    new ParticipesSalat_Periodos_MNG().Delete(per.Id);
                        //}

                        //var tmpPeriodo = getNuevoTemp_Periodo(plantilla, string.Empty, fechaPeriodo, _ps.ParticipesSalat_Participes);
                        var tmpPeriodo = getNuevoTemp_Periodo(plantilla, plantilla.Plantillas_Isins.First().Isin, Convert.ToDateTime(fechaInforme), _ps.ParticipesSalat_Participes);

                        //Nos quedamos con 

                        new ParticipesSalat_Periodos_MNG().Save(tmpPeriodo, null);

                        //Borramos las líneas que hubiera guardadas para este periodo
                        //tmpPeriodo.ParticipesSalat_Periodos_Lineas.Clear();
                        //var lineas = new ParticipesSalat_Periodos_Lineas_MNG().GetByIdPeriodo(tmpPeriodo.Id);
                        //foreach(var linea in lineas)
                        //{
                        //    new ParticipesSalat_Periodos_Lineas_MNG().Delete(linea.Id);
                        //}

                        //Añadimos las que acabamos de generar
                        var per = new ParticipesSalat_Periodos_MNG().Get(tmpPeriodo);
                        foreach (var linea in tmpPeriodo.ParticipesSalat_Periodos_Lineas)
                        {
                            linea.IdParticipesSalatPeriodo = per.Id;
                            new ParticipesSalat_Periodos_Lineas_MNG().Save(linea, null);
                        }
                            


                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    


                    //Esta sección es sólo para SALAT y no tiene su tabla temporal
                    //Guardamos lo generado en este momento
                    //new ParticipesSalat_MNG().Save(_ps, null);
                    //listaTmp.Add(tmp);

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static ParticipesSalat_Participes getNuevoTemp_Participes(string codigoIC, string isinPlantilla, DateTime fecha, Plantillas_Participes part)
        {
            var temp = new ParticipesSalat_Participes();

            var pro = Reports_DA.GetPRO01(codigoIC, isinPlantilla, null, part.TipoCuenta, part.CodigoCuenta, fecha).FirstOrDefault();

            if (pro != null)
            {
                var tmp = new ParticipesSalat_Participes();

                tmp.IdTempParticipeSalat = _ps.Id;
                tmp.IsinPlantilla = isinPlantilla;
                tmp.DNI = part.Identificador;
                tmp.NombreApellidos = part.Titular;
                tmp.NumeroParticipaciones = pro.participaciones;
                tmp.PorcentajeParticipacion = pro.tpc;
                tmp.TipoCuenta = part.TipoCuenta;
                tmp.CodigoCuenta = part.CodigoCuenta;

                return tmp;
            }
            else
            {
                return null;
            }

        }

        private static ParticipesSalat_Periodos getNuevoTemp_Periodo(Plantilla plantilla, string isinPlantilla, DateTime fechaSaldo, ICollection<ParticipesSalat_Participes> participes)
        {
            var tmpP = new ParticipesSalat_Periodos();
            tmpP.IdTempParticipeSalat= _ps.Id;

            tmpP.Descripcion = string.Format("EVOLUCIÓN SICAV {0} A {1}", fechaSaldo.Year.ToString(), fechaSaldo.ToShortDateString());
            tmpP.FechaSaldo = fechaSaldo;

            //Necesitamos recuperar el valor liquidativo para calcular "VALOR EN SICAV A ..."
            var pro02 = Reports_DA.GetPRO02(plantilla.CodigoIc, isinPlantilla, fechaSaldo).FirstOrDefault();            

            if (pro02 != null)
            {
                var valLiq = pro02.valliq;

                var ps = new ParticipesSalat_MNG().Get();
                //foreach (var participe in plantilla.Plantillas_Participes)
                foreach (var participe in participes)
                {
                    //Lo necesitamos para recuperar el número de participaciones (por cuenta, no por DNI)
                    var pro01 = Reports_DA.GetPRO01(plantilla.CodigoIc, isinPlantilla, null, participe.TipoCuenta, participe.CodigoCuenta, fechaSaldo).FirstOrDefault();

                    //Lo necesitamos para recuperar las aportaciones netas y el saldo en efectivo
                    var fechaIni = new DateTime(fechaSaldo.Year - 1, 12, 31);
                    var pro19 = Reports_DA.GetPRO19(isinPlantilla, fechaIni, fechaSaldo, participe.TipoCuenta, participe.CodigoCuenta).FirstOrDefault();

                    if (pro01 != null && pro02 != null)
                    {
                        var tmpL = new ParticipesSalat_Periodos_Lineas();
                        
                        tmpL.IdTitular = participe.Id;
                        tmpL.Titular = participe.NombreApellidos;
                        //tmpL.IdentificadorTitular = participe.Identificador;
                        tmpL.ImporteInvertido = pro19.ApoNet != null? pro19.ApoNet : 0; //es la columna APORTACIONES NETAS REALIZADAS
                        tmpL.Valor = valLiq * pro01.participaciones; // valorLiquidativo * NumeroParticipaciones
                        tmpL.Saldo = pro19.SalVal != null ? pro19.SalVal : 0;
                        //La columna VALOR SICAV + EFECTIVO se calcula sumando dos columnas del periodo anterior (si hubiera)
                        //VALOR EN SICAV
                        //SALDO EN EFECTIVO
                        var lineaPeriodoAnt = ParticipesSalat_DA.Get_LineaPeriodo_Anterior(fechaSaldo, tmpL.IdTitular);
                        if (lineaPeriodoAnt != null)
                        {
                            //tendremos que guardar en las líneas de periodo el identificador del titular
                            tmpL.ValorMasEfectPeriodoAnt = lineaPeriodoAnt.Valor + lineaPeriodoAnt.Saldo;
                        }

                        var valMasEfPerAnt = tmpL.ValorMasEfectPeriodoAnt != null ? (decimal)tmpL.ValorMasEfectPeriodoAnt : 0;
                        tmpL.Resultado = tmpL.Valor + (decimal)tmpL.Saldo - valMasEfPerAnt - (decimal)tmpL.ImporteInvertido;

                        //añadimos la línea al periodo
                        tmpP.ParticipesSalat_Periodos_Lineas.Add(tmpL);
                    }
                    
                    
                }
            }            

            return tmpP;
        }

        

        public static Report GetReportParticipesSalat(string codigoIC, DateTime fechaInforme)
        {
            Telerik.Reporting.Report rep = new ReportParticipesSalat(codigoIC);
            rep.ReportParameters["FechaInforme"].Value = fechaInforme;
            return rep;
        }
    }
}
