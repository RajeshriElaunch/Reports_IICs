using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class Preview_CompraVentaPrecAdq_MNG : BaseManagers<Preview_CompraVentaPrecAdq>
    {
        public Preview_CompraVentaPrecAdq Get(Preview_CompraVentaPrecAdq entity)
        {
            return GetAll(x =>
                    x.CodigoIC == entity.CodigoIC
                    && x.Isin.ToUpper() == entity.Isin.ToUpper()
                    && x.Fecha == entity.Fecha
                    && x.Tipo == entity.Tipo
                    && x.Titulos == entity.Titulos
                    && x.DescripcionValor == entity.DescripcionValor
                    && x.Adquisicion == entity.Adquisicion
                    ).FirstOrDefault();
        }

        public IEnumerable<object> GetByCodigoIC(string codigoIC, bool? previewNew = null)
        {
            IEnumerable<object> output = GetAll(x =>
                    x.CodigoIC == codigoIC);

            return output;
        }

        public override void Save(Preview_CompraVentaPrecAdq entity, string summary)
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

                //Si el item tenía el indicador added. Cuando añadimos un item siempre tendrá added = true
                //bool added = upd.Added;
                // Copy values
                summary = CopyObject(entity, upd, "Id");
                //upd.Added = added;

                // Persist
                base.Update(upd, summary);
            }
        }

        public void SavePreview(Preview_CompraVentaPrecAdq entity, Temp_CompraVentaPrecAdq temp, string summary)
        {
            

            if (entity.Id == 0)
            {
                base.Create(entity, summary);
            }
            else
            {
                // Get entity
                var upd = Get(entity);

                if (summary == null) summary = string.Format("Update {0}. Id: {1}", entity.GetType().BaseType.Name, entity.Id);

                // Copy values
                summary = CopyObject(entity, upd);

                // Persist
                base.Update(upd, summary);
            }
        }

    }
}