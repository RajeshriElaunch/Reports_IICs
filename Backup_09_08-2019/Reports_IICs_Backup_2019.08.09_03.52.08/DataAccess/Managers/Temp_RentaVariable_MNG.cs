using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    public class Temp_RentaVariable_MNG : BaseManagers<Temp_RentaVariable>
    {
        public IEnumerable<Temp_RentaVariable> GetByCodigoIC(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC);
        }

        public Temp_RentaVariable Get(Temp_RentaVariable entity)
        {
            return GetAll(x =>
                    x.CodigoIC == entity.CodigoIC
                    && x.Isin.ToUpper() == entity.Isin.ToUpper()
                    && x.Grupo == entity.Grupo
                    && x.GrupoNuevo == entity.GrupoNuevo
                    ).FirstOrDefault();
        }

        public override void Save(Temp_RentaVariable entity, string summary)
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

        public override void Delete(Temp_RentaVariable entity)
        {
            // Get entity
            var obj = Get(entity);

            if (obj != null)
            {
                base.Delete(obj);
            }
        }
    }
}