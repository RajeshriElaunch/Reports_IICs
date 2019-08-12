using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class Temp_CompraVentaPrecAdq_MNG : BaseManagers<Temp_CompraVentaPrecAdq>
    {
        public IEnumerable<Temp_CompraVentaPrecAdq> GetByCodigoIC(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC);
        }

        public Temp_CompraVentaPrecAdq Get(Temp_CompraVentaPrecAdq temp)
        {
            return GetAll(x =>
                    x.CodigoIC == temp.CodigoIC
                    && x.Isin == temp.Isin
                    && x.Fecha == temp.Fecha
                    && x.Tipo == temp.Tipo
                    && x.Titulos == temp.Titulos
                    && x.DescripcionValor == temp.DescripcionValor
                    && x.Adquisicion == temp.Adquisicion
                    ).FirstOrDefault();
        }

        public override void Save(Temp_CompraVentaPrecAdq entity, string summary)
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