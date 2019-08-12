using Reports_IICs.DataModels;

namespace Reports_IICs.Base
{
    public class BaseManagers<TEntity> : Core.EntityFramework.BaseManager<TEntity> where TEntity : class
    {
        public BaseManagers(Reports_IICSEntities dbc)
        {
            //this.db.Configuration.AutoDetectChangesEnabled = false;
            db = dbc;
        }

        public BaseManagers()
        {
            //this.db.Configuration.AutoDetectChangesEnabled = false;
            db = new Reports_IICSEntities();
        }
    }
}
