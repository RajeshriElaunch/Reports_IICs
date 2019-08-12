using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.Managers
{
    public class BaseManager<TEntity> : IDisposable where TEntity : class
    {
        public DbContext db;

        public BaseManager(DbContext dbc)
        {
            db = dbc;
        }

        public BaseManager()
        {
            db = new DbContext("Reports_IICSEntities");
        }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
