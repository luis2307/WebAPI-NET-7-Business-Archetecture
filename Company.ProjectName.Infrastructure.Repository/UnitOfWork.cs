using Company.ProjectName.Infrastructure.Interface;


namespace Company.ProjectName.Infrastructure.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool _disposed = false;
        public ICustomersRepository Customers { get; }

        public IUsersRepository Users { get; }

        public ICategoriesRepository Categories { get; }

        public UnitOfWork(ICustomersRepository customers, IUsersRepository users, ICategoriesRepository categories)
        {
            Customers = customers;
            Users = users;
            Categories = categories;    
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    //_context.Dispose();
                }
            }
            this._disposed = true;
        }
    }
}
