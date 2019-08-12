using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess.Secciones
{
    public static class DiversificacionAsset_DA
    {
        public static Parametros_Diversificacion GetParametros(string codigoIC)
        {
            Reports_IICSEntities dbContext = new Reports_IICSEntities();

            //var result = dbContext.Parametros_Diversificacion.Where(w => w.CodigoIC == codigoIC).FirstOrDefault();
            var result = dbContext.Parametros_Diversificacion.FirstOrDefault();
            return result;
        }
    }
}
