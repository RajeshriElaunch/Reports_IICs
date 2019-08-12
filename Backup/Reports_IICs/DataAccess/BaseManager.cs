using Reports_IICs.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.DataAccess
{
    public class BaseManagers<TEntity> : Core.EntityFramework.BaseManager<TEntity> where TEntity : class
    {
        public BaseManagers(DBContainer dbc)
        {
            db = dbc;
        }

        public BaseManagers()
        {
            db = new DBContainer();
        }
    }
}
