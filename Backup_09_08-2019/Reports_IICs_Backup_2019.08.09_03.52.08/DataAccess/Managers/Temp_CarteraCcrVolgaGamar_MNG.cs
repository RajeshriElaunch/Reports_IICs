using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;

namespace Reports_IICs.DataAccess.Managers
{
    public class Temp_CarteraCcrVolgaGamar_MNG : BaseManagers<Temp_CarteraCcrVolgaGamar>
    {
        public IEnumerable<Temp_CarteraCcrVolgaGamar> GetByCodigoIC(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC);
        }

        public override void Save(Temp_CarteraCcrVolgaGamar entity, string summary)
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