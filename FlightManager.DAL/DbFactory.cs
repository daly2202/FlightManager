namespace FlightManager.DAL
{
    using System.Data.Entity;

    public class DbFactory
    {
        public DbFactory()
        {
            Database.SetInitializer<FlightManagerContext>(null);
        }
        private FlightManagerContext _dataContext;
        public FlightManagerContext Get()
        {
            return _dataContext ?? (_dataContext = new FlightManagerContext());
        }

    }
}
