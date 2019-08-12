
using Reports_IICs.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.DataAccess
{
    public class UnitOfWork
    {
        private readonly Reports_IICSEntities _context;

        public UnitOfWork()
        {
            _context = new Reports_IICSEntities();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public Reports_IICSEntities Context
        {
            get { return _context; }
        }
    }

    

}
