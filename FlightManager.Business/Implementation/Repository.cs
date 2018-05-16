namespace FlightManager.Business.Implementation
{
    using FlightManager.Business.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class Repository<T> : IRepository<T> where T : class
    {
        public bool Add(T entity)
        {
            bool inserted = false;
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                try
                {
                    unitOfWork.DataContext.Set<T>().Add(entity);
                    unitOfWork.Commit();
                    inserted = true;
                }
                catch(Exception)
                {
                    unitOfWork.Rollback();
                }
            }
            return inserted;
        }

        public T Get(Func<T, bool> where, string[] includeProperties = null)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IQueryable<T> query = unitOfWork.DataContext.Set<T>().Where(where).AsQueryable();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }
                return query.FirstOrDefault<T>();
            }
        }

        public IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null)
        {
            using (UnitOfWork unitOfWork = new UnitOfWork())
            {
                IQueryable<T> query = unitOfWork.DataContext.Set<T>().AsQueryable();
                if (includeProperties != null)
                {
                    foreach (var includeProperty in includeProperties)
                    {
                        query = query.Include(includeProperty);
                    }
                }

                if (orderBy != null)
                {
                    return orderBy(query);
                }

                return query;
            }
        }
        
    }
}
