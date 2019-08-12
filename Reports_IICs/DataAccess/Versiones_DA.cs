using Reports_IICs.DataModels;
using System.Linq;

namespace Reports_IICs.DataAccess
{
    public static class Versiones_DA
    {
        public static string GetLatestVersion()
        {
            var dbContext = new Reports_IICSEntities();

            var fileVersion = dbContext.Versiones.OrderByDescending(v => v.FechaVersion).Select(v => v.FileVersion).FirstOrDefault();

            return fileVersion;            
        }
    }
}
