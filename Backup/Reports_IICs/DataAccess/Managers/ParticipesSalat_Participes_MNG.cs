using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class ParticipesSalat_Participes_MNG : BaseManagers<ParticipesSalat_Participes>
    {
        public ParticipesSalat_Participes Get(ParticipesSalat_Participes entity)
        {
            return GetAll(x =>
                    x.DNI.ToUpper() == entity.DNI.ToUpper()
                      && x.TipoCuenta.ToUpper() == entity.TipoCuenta.ToUpper()
                      && x.CodigoCuenta.ToUpper() == entity.CodigoCuenta.ToUpper()
                    ).FirstOrDefault();
        }

        /// <summary>
        /// Borramos los partícipes que estén en la tabla ParticipesSalat_Participes y no estén en Plantillas_Participes con el codigoIC de la plantilla actual
        /// </summary>
        /// <param name="participesPlantilla"></param>
        public void BorrarInexistentes(ICollection<Plantillas_Participes> participesPlantilla)
        {
            //Borramos los ParticipesSalat_Participes que no estén en participesPlantilla
            foreach (var part in GetAll())
            {
                var obj = participesPlantilla.Where(x =>
                      x.Identificador.ToUpper() == part.DNI.ToUpper()
                      && x.TipoCuenta.ToUpper() == part.TipoCuenta.ToUpper()
                      && x.CodigoCuenta.ToUpper() == part.CodigoCuenta.ToUpper()                      
                      ).FirstOrDefault();

                if (obj == null)
                {
                    Delete(part);
                }
            }
        }
        public override void Save(ParticipesSalat_Participes entity, string summary)
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