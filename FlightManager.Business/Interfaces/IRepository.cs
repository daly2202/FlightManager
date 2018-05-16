namespace FlightManager.Business.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface IRepository<T>
    {
        bool Add(T entity);

        T Get(Func<T, Boolean> where, string[] includeProperties = null);
        IEnumerable<T> GetAll(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string[] includeProperties = null);
    }
}
