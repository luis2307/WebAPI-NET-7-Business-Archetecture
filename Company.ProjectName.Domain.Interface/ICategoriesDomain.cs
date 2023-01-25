using Company.ProjectName.Domain.Entity;

namespace Company.ProjectName.Domain.Interface
{
    public interface ICategoriesDomain
    {
        Task<IEnumerable<Categories>> GetAllAsync();
    }
}
 
