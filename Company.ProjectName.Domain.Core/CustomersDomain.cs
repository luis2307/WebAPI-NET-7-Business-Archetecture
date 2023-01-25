using Company.ProjectName.Domain.Entity;
using Company.ProjectName.Domain.Interface;
using Company.ProjectName.Infrastructure.Interface;

namespace Company.ProjectName.Domain.Core
{
    public class CustomersDomain : ICustomersDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CustomersDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Métodos Síncronos

        public bool Insert(Customers customers)
        {
            return _unitOfWork.Customers.Insert(customers);
        }

        public bool Update(Customers customers)
        {
            return _unitOfWork.Customers.Update(customers);
        }

        public bool Delete(string customerId)
        {
            return _unitOfWork.Customers.Delete(customerId);
        }

        public Customers Get(string customerId)
        {
            return _unitOfWork.Customers.Get(customerId);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _unitOfWork.Customers.GetAll();
        }

        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            return _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
        }

        public int Count()
        {
            return _unitOfWork.Customers.Count();
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Customers customers)
        {
            return await _unitOfWork.Customers.InsertAsync(customers);
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            return await _unitOfWork.Customers.UpdateAsync(customers);
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            return await _unitOfWork.Customers.DeleteAsync(customerId);
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            return await _unitOfWork.Customers.GetAsync(customerId);
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            return await _unitOfWork.Customers.GetAllAsync();
        }

        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            return await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
        }

        public async Task<int> CountAsync()
        {
            return await _unitOfWork.Customers.CountAsync();
        }

        #endregion
    }
}