using Reports_IICs.Base;
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Reports_IICs.DataAccess.Managers
{
    class RentaVariable_PrecioAjustado_MNG : BaseManagers<RentaVariable_PrecioAjustado>
    {

        private DateTime fechaInforme;        
        public DateTime FechaInforme
        {
            get { return fechaInforme; }
            set { fechaInforme = value; }
        }
        public RentaVariable_PrecioAjustado Get(RentaVariable_PrecioAjustado entity)
        {
            return GetAll(x =>
                    x.CodigoIC == entity.CodigoIC
                    && x.Isin.ToUpper() == entity.Isin.ToUpper()
                    && x.Grupo == entity.Grupo
                    && x.FechaInforme <= FechaInforme
                    //&& x.Ejercicio == entity.Ejercicio
                    ).OrderByDescending(o=>o.FechaInforme).FirstOrDefault();
        }

        public IEnumerable<RentaVariable_PrecioAjustado> GetByCodigoIC(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC);
        }

        /// <summary>
        /// Devuelve los eliminados manualmente
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <returns></returns>
        public IEnumerable<RentaVariable_PrecioAjustado> GetDeleted(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC                    
                    && !x.IsVisible);
        }

        /// <summary>
        /// Devuelve los añadidos manualmente
        /// </summary>
        /// <param name="codigoIC"></param>
        /// <returns></returns>
        public IEnumerable<RentaVariable_PrecioAjustado> GetAdded(string codigoIC)
        {
            return GetAll(x =>
                    x.CodigoIC == codigoIC
                    && x.Added
                    && x.IsVisible);
        }

        public override void Save(RentaVariable_PrecioAjustado entity, string summary)
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



        //public void SavePreview(RentaVariable_PrecioAjustado entity, Temp_CompraVentaPrecAdq temp, string summary)
        //{


        //    if (entity.Id == 0)
        //    {
        //        base.Create(entity, summary);
        //    }
        //    else
        //    {
        //        // Get entity
        //        var upd = Get(entity);

        //        if (summary == null) summary = string.Format("Update {0}. Id: {1}", entity.GetType().BaseType.Name, entity.Id);

        //        //entity.FechaAlta = upd.FechaAlta;

        //        // Copy values
        //        summary = CopyObject(entity, upd);

        //        // Persist
        //        base.Update(upd, summary);
        //    }
        //}

    }
}