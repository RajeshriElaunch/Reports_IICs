using Reports_IICs.Base;
using Reports_IICs.DataAccess.Plantillas;
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.Managers
{
    public class PlantillaManager : BaseManagers<Plantilla>
    {
        public IEnumerable<Plantilla> GetByFilter(string filter, bool habilitado)
        {
            if (string.IsNullOrWhiteSpace(filter))
                //return GetAll();
                return GetAll(
                    //x => (x.Habilitado == habilitado)
                );

            return GetAll(x =>
                    x.Descripcion.Contains(filter) 
                    //&&(x.Habilitado == habilitado)
                    );
        }

        public Plantilla GetPlantilla(string Id)
        {
            return db.Set<Plantilla>().AsNoTracking().Where(w=>w.CodigoIc == Id).FirstOrDefault();
        }

        //public Plantilla GetPlantilla(string Id, Seccione secc)
        //{
        //    db.Set<Seccione>().Attach(secc);
        //    db.Entry(secc).State = EntityState.Unchanged;
        //    var plantilla = db.Set<Plantilla>().AsNoTracking().Where(w => w.CodigoIc == Id).FirstOrDefault();
            
        //    return plantilla;
        //}

        //public IEnumerable<ItemDTO> GetItemDTO(int ClinicaId)
        //{
        //    return GetAll(x => x.IdClinica == ClinicaId &&
        //                    x.Habilitado &&
        //                    x.Clinica.Habilitado).Select(x => new ItemDTO()
        //                    {
        //                        Text = x.Nombre,
        //                        IntValue = x.Id
        //                    }).OrderBy(x => x.Text).ToList();
        //}

        public override void Save(Plantilla entity, string summary)
        {
            try
            {
                Plantillas_DA.SavePlantilla2(entity);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*
        public override void Save(Plantilla entity, string summary)
        {
            var plantilla = base.Get(entity.CodigoIc);
            try
            {
                if (plantilla == null)
                {
                    //((Reports_IICSEntities)db).Plantillas.Attach(entity);
                    //db.Entry(entity).State = EntityState.Detached;
                    //((Reports_IICSEntities)db).Plantillas.Attach(entity);
                    base.Create(entity, summary);
                    //Plantillas_DA.SavePlantilla2(entity);
                }
                else
                {
                    // Get entity
                    //Plantilla upd = base.Get(entity.CodigoIc);

                    if (summary == null) summary = string.Format("Update {0}. Id: {1}", entity.GetType().BaseType.Name, entity.Id);

                    //entity.FechaAlta = upd.FechaAlta;

                    // Copy values
                    //summary = CopyObject(entity, plantilla);      
                    plantilla = DeepClone(entity);


                    //db.Entry(plantilla).State = EntityState.Detached;
                    //context.Entry(existingBlog).State = EntityState.Unchanged;

                    //((Reports_IICSEntities)db).Plantillas.Attach(plantilla);

                    // Persist
                    base.Update(entity, plantilla.CodigoIc, summary);

                }

            }
            catch (Exception ex)
            {
            }
        }
        */

        public override void Delete(Plantilla entity)
        {
            var plantilla = base.Get(entity.CodigoIc);

            if (plantilla != null)
            {
                base.Delete(plantilla);
            }            
        }
    }
}
