using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class ParticipesSalat_Periodos_MNG : BaseManagers<ParticipesSalat_Periodos>
    {
        /// <summary>
        /// Devuelve los periodos con fecha de saldo igual o posterior a la del parámetro de entrada
        /// </summary>
        /// <param name="fechaSaldo"></param>
        /// <returns></returns>
        public ParticipesSalat_Periodos Get(ParticipesSalat_Periodos entity)
        {
            return GetAll(x =>
                    x.IdTempParticipeSalat == entity.IdTempParticipeSalat
                    && x.FechaSaldo == entity.FechaSaldo
                    ).FirstOrDefault();
        }
        public override void Save(ParticipesSalat_Periodos entity, string summary)
        {
            // Get entity
            var upd = Get(entity);

            if (upd == null)
            {
                base.Create(entity, summary);
            }
            else
            {
                if (summary == null) summary = string.Format("Update {0}. Id: {1}", entity.GetType().BaseType.Name, entity.Id);

                //entity.FechaAlta = upd.FechaAlta;

                // Copy values
                summary = CopyObject(entity, upd, "Id");

                // Persist
                base.Update(upd, summary);

                
            }
        }
    }
}