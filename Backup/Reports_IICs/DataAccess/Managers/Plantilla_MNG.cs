using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;

namespace Reports_IICs.DataAccess.Managers
{
    public class Plantilla_MNG : BaseManagers<Plantilla>
    {
        public IEnumerable<Plantilla> GetByCodigoIC(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIc == codigoIC);
        }

        public override void Save(Plantilla entity, string summary)
        {
            // Get entity
            var upd = base.Get(entity.CodigoIc);

            //Comprobar el valor de upd cuando insertamos una nueva plantilla
            if (upd == null)
            {
                base.Create(entity, summary);
            }
            else
            {
                if (summary == null) summary = string.Empty;

                //entity.FechaAlta = upd.FechaAlta;

                // Copy values
                //summary = CopyObject(entity, upd);
                upd = DeepClone(entity);

                // Persist
                base.Update(upd, summary);
            }
        }


    }
}