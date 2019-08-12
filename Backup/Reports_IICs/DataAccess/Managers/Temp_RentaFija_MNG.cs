using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class Temp_RentaFija_MNG : BaseManagers<Temp_RentaFija>
    {
        public IEnumerable<Temp_RentaFija> GetByCodigoIC(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC);
        }

        public Temp_RentaFija Get(Temp_RentaFija temp)
        {
            return GetAll(x =>                
                    x.CodigoIC == temp.CodigoIC
                    && x.Isin == temp.Isin
                    && x.Descripcion == temp.Descripcion
                    && x.Grupo == temp.Grupo
                    && x.NumTit == temp.NumTit
                    && x.EfectivoIni == temp.EfectivoIni
                    && x.EfectivoFin == temp.EfectivoFin
                    && x.PrecioCompra == temp.PrecioCompra
                    && x.PrecioVenta == temp.PrecioVenta
                    && x.IdInstrumento == temp.IdInstrumento
                    && x.IdTipoInstrumento == temp.IdTipoInstrumento
                    ).FirstOrDefault();
        }

        public override void Save(Temp_RentaFija entity, string summary)
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