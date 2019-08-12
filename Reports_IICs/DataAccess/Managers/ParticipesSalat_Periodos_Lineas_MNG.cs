using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class ParticipesSalat_Periodos_Lineas_MNG : BaseManagers<ParticipesSalat_Periodos_Lineas>
    {
        public ParticipesSalat_Periodos_Lineas Get(ParticipesSalat_Periodos_Lineas entity)
        {
            return GetAll(x =>
                    x.IdParticipesSalatPeriodo == entity.IdParticipesSalatPeriodo
                    && x.IdTitular == entity.IdTitular
                    ).FirstOrDefault();
        }
        public override void Save(ParticipesSalat_Periodos_Lineas entity, string summary)
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