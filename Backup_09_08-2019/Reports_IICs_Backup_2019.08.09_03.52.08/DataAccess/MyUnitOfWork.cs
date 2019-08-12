using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.DataAccess
{
    public class MyUnitOfWork
    {
        private readonly Reports_IICSEntities _context;

        public MyUnitOfWork() : this(new Reports_IICSEntities()) { }

        public MyUnitOfWork(Reports_IICSEntities context)
        {
            _context = context;
        }

        public T GetRepository<T>() where T : class
        {
            using (var kernel = new StandardKernel())
            {
                kernel.Load(Assembly.GetExecutingAssembly());
                var result = kernel.Get<T>(new ConstructorArgument("context", _context));
                // Requirements
                //   - Must be in this assembly
                //   - Must implement a specific interface (i.e. IBlogModule)
                if (result != null && result.GetType().GetInterfaces().Contains(typeof(IBlogModule)))
                {
                    return result;
                }
            }

            // Optional: return an error instead of a null?
            //var msg = typeof (T).FullName + " doesn't implement the IBlogModule.";
            //throw new Exception(msg);
            return null;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
        public void Rollback()
        {
            _context
                .ChangeTracker
                .Entries()
                .ToList()
                .ForEach(x => x.Reload());
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
