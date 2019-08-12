using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;

namespace Reports_IICs.DataAccess.Managers
{
    class Parametros_OperacionesRentaVariable_II_MNG : BaseManagers<Parametros_OperacionesRentaVariable_II>
    {
        public IEnumerable<Parametros_OperacionesRentaVariable_II> GetByCodigoIC(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC);
        }

        public override void Save(Parametros_OperacionesRentaVariable_II entity, string summary)
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