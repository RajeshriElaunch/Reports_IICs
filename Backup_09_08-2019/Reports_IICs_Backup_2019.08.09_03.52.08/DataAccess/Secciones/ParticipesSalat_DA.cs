using Reports_IICs.DataAccess.Managers;
using Reports_IICs.DataAccess.Reports;
using Reports_IICs.DataModels;
using Reports_IICs.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    class ParticipesSalat_DA
    {

        public static T_ParticipesSalat Get_Temp_ParticipesSalatById(int id)
        {
            var dbContext = new Reports_IICSEntities();
            T_ParticipesSalat PartSalat_temp = new T_ParticipesSalat();


            foreach (var item in dbContext.ParticipesSalat_Participes.Where(r => r.Id == id))
            {
                PartSalat_temp.Id = item.Id;
                //PartSalat_temp.CodigoIC = item.CodigoIC;
                //PartSalat_temp.Isin = item.IsinPlantilla;
                PartSalat_temp.NombreApellidos = item.NombreApellidos;
                PartSalat_temp.NumeroParticipaciones = item.NumeroParticipaciones;
                PartSalat_temp.PorcentajeParticipacion = item.PorcentajeParticipacion;
            }

            return PartSalat_temp;
        }

        public static IEnumerable<ParticipesSalat> GetParametros_ParticipesSalat(int? idParamPartSalat = null)
        {
            var dbContext = new Reports_IICSEntities();
            if(idParamPartSalat != null)
            {
                return dbContext.ParticipesSalats.AsNoTracking().Where(w=>w.Id == idParamPartSalat);
            }
            else
            {
                return dbContext.ParticipesSalats;
            }
            
        }

        public static IEnumerable<ParticipesSalat_Participes> GetParticipesSalat_Participes(int? idParamPartSalat = null)
        {
            var dbContext = new Reports_IICSEntities();
            if (idParamPartSalat != null)
            {
                return dbContext.ParticipesSalat_Participes.AsNoTracking().Where(w => w.Id == idParamPartSalat);
            }
            else
            {
                return dbContext.ParticipesSalat_Participes;
            }
        }

        //public static ParticipesSalat Get_ParticipesSalat()
        //{
        //    var dbContext = new Reports_IICSEntities();
        //    return dbContext.ParticipesSalats.FirstOrDefault();
        //}

        public static decimal Get_ValorSicavMasEfec_PeriodAnt(DateTime fechaActualPeriodo, int idParametroParticipeSalat)
        {
            decimal valorSicavMasEfec = 0;
            var dbContext = new Reports_IICSEntities();
            var linea = dbContext.ParticipesSalat_Periodos_Lineas.Where(w => w.IdParametroParticipeSalat == idParametroParticipeSalat && w.ParticipesSalat_Periodos.FechaSaldo < fechaActualPeriodo).OrderByDescending(o => o.ParticipesSalat_Periodos.FechaSaldo).FirstOrDefault();
            if(linea != null)
            {
                decimal saldo = linea.Saldo != null ? (decimal)linea.Saldo : 0;
                valorSicavMasEfec = linea.Valor + saldo;
            }

            return valorSicavMasEfec;
        }

        /// <summary>
        /// Devuelve el periodo anterior a la fechaSaldo que pasemos
        /// </summary>
        /// <param name="fechaSaldo"></param>
        /// <returns></returns>
        public static ParticipesSalat_Periodos_Lineas Get_LineaPeriodo_Anterior(DateTime fechaSaldo, int idTitular)
        {
            var dbContext = new Reports_IICSEntities();
            var periodo = dbContext.ParticipesSalat_Periodos.Where(w => w.FechaSaldo < fechaSaldo).OrderByDescending(o => o.FechaSaldo).FirstOrDefault();
            if (periodo != null)
            {
                var linea = periodo.ParticipesSalat_Periodos_Lineas.Where(w=> w.IdTitular == idTitular).FirstOrDefault();
                return linea;
            }

            return null;
        }


        public static decimal GetResultadoAcumulado(string codigoIC, decimal resultAportaciones)
        {
            decimal resultadoAcum = 0;
            var dbContext = new Reports_IICSEntities();

            //Es la suma del RESULTADO de cada periodo y el RESULTADO de las aportaciones
            var tmp = dbContext.ParticipesSalats.FirstOrDefault();

            if(tmp != null)
            {
                //var sumAport = tmp.Temp_ParticipesSalat_Aportaciones.Sum(s => s.Aportacion);
                //decimal valEvolCart = tmp.Valor_EvolCartera != null? (decimal)tmp.Valor_EvolCartera : 0;
                //var resultAportaciones = valEvolCart - sumAport;

                decimal resultPeriodos = 0;

                foreach(var periodo in tmp.ParticipesSalat_Periodos)
                {
                    resultPeriodos += periodo.ParticipesSalat_Periodos_Lineas.Sum(s => s.Resultado);
                }

                resultadoAcum = resultAportaciones + resultPeriodos;
            }

            return resultadoAcum;
        }

        public static void InsertParametros(List<ParticipesSalat> parametros)
        {
            var dbContext = new Reports_IICSEntities();
            //string codigoIC = parametros.First().CodigoIC;
            dbContext.ParticipesSalats.RemoveRange(dbContext.ParticipesSalats);
            dbContext.ParticipesSalats.AddRange(parametros);
            try
            {
                dbContext.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public static void InsertGeneracion(ParticipesSalat ps)
        {
            using (var dbContext = new Reports_IICSEntities())
            {
                //Para actualizar los partícipes primero eliminamos los que teníamos 
                //y luego insertamos lo que teníamos de la generación
                dbContext.ParticipesSalat_Participes.RemoveRange(dbContext.ParticipesSalat_Participes);

                var obj = new ParticipesSalat_MNG().Get();

                if (obj == null)
                    obj = new DataModels.ParticipesSalat();

                Utils.CopyPropertyValues(ps, obj);

                dbContext.SaveChanges();
            }
        }

    }
}
