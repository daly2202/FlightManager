namespace FlightManager.Business.Interfaces
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        void Rollback();
    }
}
