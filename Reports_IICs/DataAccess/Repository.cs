using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reports_IICs.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly UnitOfWork _unitOfWork;

        public Repository() : this(new UnitOfWork())
        {
        }

        public Repository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? new UnitOfWork();
        }

        public IList<TEntity> GetAll()
        {
            try
            {
                return _unitOfWork.Context.Set<TEntity>().ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return Enumerable.Empty;
            }
        }

        public TEntity GetById(int id)
        {
            try
            {
                return _unitOfWork.Context.Set<TEntity>().Find(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public TEntity Get(TEntity entity)
        {
            try
            {
                return _unitOfWork.Context.Set<TEntity>().Find(entity);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return null;
            }
        }

        public bool Add(TEntity entity)
        {
            try
            {
                _unitOfWork.Context.Set<TEntity>().Add(entity);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool Update(TEntity entity)
        {
            try
            {
                _unitOfWork.Context.Set<TEntity>().Attach(entity);
                _unitOfWork.Context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool Delete(TEntity entity)
        {
            try
            {
                var entityToRemove = Get(entity);
                _unitOfWork.Context.Set<TEntity>().Remove(entityToRemove);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }

        public bool DeleteById(int id)
        {
            try
            {
                var entityToRemove = GetById(id);
                _unitOfWork.Context.Set<TEntity>().Remove(entityToRemove);
                _unitOfWork.Save();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                return false;
            }
        }
    }
}
