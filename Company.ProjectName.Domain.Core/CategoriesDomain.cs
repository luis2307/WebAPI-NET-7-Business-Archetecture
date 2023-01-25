using Company.ProjectName.Domain.Entity;
using Company.ProjectName.Domain.Interface;
using Company.ProjectName.Infrastructure.Interface;

namespace Company.ProjectName.Domain.Core
{
    public class CategoriesDomain : ICategoriesDomain
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoriesDomain(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            return await _unitOfWork.Categories.GetAllAsync();
        }
    }
}
