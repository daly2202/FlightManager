namespace FlightManager.Business.Implementation
{
    using System;
    using System.Transactions;
    using FlightManager.Business.Interfaces;
    using FlightManager.DAL;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly DbFactory _databaseFactory;
        private FlightManagerContext _dataContext;

        public FlightManagerContext DataContext
        {
            get
            {
                if (_dataContext == null)
                {
                    _dataContext = _databaseFactory.Get();
                }
                return _dataContext;
            }
        }
        private TransactionScope _transactionScope;

        public UnitOfWork()
        {
            this.Dispose();
            this._databaseFactory = new DbFactory();
            this._transactionScope = new TransactionScope(TransactionScopeOption.Suppress);
        }
        public void Commit()
        {
            DataContext?.SaveChanges();
        }

        public void Rollback()
        {
            this._transactionScope?.Dispose();
            this._transactionScope = null;
        }

        public void Dispose()
        {
            this._transactionScope?.Complete();
            this._transactionScope?.Dispose();
        }
    }
}
