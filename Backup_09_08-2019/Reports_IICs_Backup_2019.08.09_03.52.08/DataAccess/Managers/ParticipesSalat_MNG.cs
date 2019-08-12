using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class ParticipesSalat_MNG : BaseManagers<ParticipesSalat>
    {
        //private DateTime fechaInforme;        

        public ParticipesSalat Get()
        {
            return GetAll().FirstOrDefault();
        }

        public override void Save(ParticipesSalat entity, string summary)
        {
            // Get entity
            var upd = Get();
            if (upd == null)
            {
                base.Create(entity, summary);
            }
            else
            {
                

                if (summary == null) summary = string.Format("Update {0}. Id: {1}", entity.GetType().BaseType.Name, entity.Id);

                //entity.FechaAlta = upd.FechaAlta;

                // Copy values
                //summary = CopyObject(entity, upd);
                //sólo copiamos los datos de ParticipesSalat
                //los de las tablas relacionadas se actualizan por separado
                upd.TituloInforme = entity.TituloInforme;
                upd.EvolucionCarteras_Text = entity.EvolucionCarteras_Text;
                upd.Aportaciones_EvolCart_Text = entity.Aportaciones_EvolCart_Text;
                upd.Valor_EvolCart_Text = entity.Valor_EvolCart_Text;
                upd.Valor_EvolCartera = entity.Valor_EvolCartera;
                upd.TotalPeriodos_Text = entity.TotalPeriodos_Text;
                upd.TotalPeriodos = entity.TotalPeriodos;

                // Persist
                base.Update(upd, summary);
            }
        }            

    }
}