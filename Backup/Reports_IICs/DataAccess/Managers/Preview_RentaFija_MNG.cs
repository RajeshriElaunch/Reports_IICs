using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class Preview_RentaFija_MNG : BaseManagers<Preview_RentaFija>
    {
        //private DateTime fechaInforme;        

        public Preview_RentaFija Get(Preview_RentaFija entity)
        {
            return GetAll(x =>
                    x.CodigoIC == entity.CodigoIC
                    && x.Isin.ToUpper() == entity.Isin.ToUpper()
                    && x.Grupo == entity.Grupo
                    && x.Descripcion == entity.Descripcion
                    && x.NumTit == entity.NumTit
                    && x.EfectivoIni == entity.EfectivoIni
                    && x.EfectivoFin == entity.EfectivoFin
                    && x.BoPDivisa == entity.BoPDivisa
                    //&& x.BoPPrecio == entity.BoPPrecio
                    && x.PosicionCartera == entity.PosicionCartera
                    && x.PosicionesCerradas == entity.PosicionesCerradas
                    ).FirstOrDefault();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <param name="previewNew">
        /// Cuando es null devolvemos todos los campos
        /// Cuando es false devolvemos los valores originales de la Preview
        /// Cuando es true devolvemos los valores nuevos, después de las modificaciones de la Preview
        /// </param>
        /// <returns></returns>
        public IEnumerable<object> GetByCodigoIC(string codigoIC, bool? previewNew = null)
        {
            IEnumerable<object> output = GetAll(x =>
                    x.CodigoIC == codigoIC);

            return output;
        }

        public override void Save(Preview_RentaFija entity, string summary)
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

        public void SavePreview(Preview_RentaFija entity, Temp_RentaFija temp, string summary)
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

                //entity.FechaAlta = upd.FechaAlta;

                // Copy values
                summary = CopyObject(entity, upd);

                // Persist
                base.Update(upd, summary);
            }
        }

    }
}