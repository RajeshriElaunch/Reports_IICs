using Reports_IICs.Base;
using Reports_IICs.DataModels;

namespace Reports_IICs.DataAccess.Managers
{
    class ParticipesSalat_Aportaciones_MNG : BaseManagers<ParticipesSalat_Aportaciones>
    {
        public override void Save(ParticipesSalat_Aportaciones entity, string summary)
        {
            if (entity.Id == 0)
            {
                base.Create(entity, summary);
            }
            else
            {
                // Get entity
                var upd = base.Get(entity.Id);

                if (summary == null) summary = string.Format("Update {0}. Id: {1}", entity.GetType().BaseType.Name, entity.Id);

                //entity.FechaAlta = upd.FechaAlta;

                // Copy values
                summary = CopyObject(entity, upd);

                // Persist
                base.Update(upd, summary);
            }
        }
    }
}