using Company.ProjectName.Domain.Entity;
 
 
namespace Company.ProjectName.Infrastructure.Interface
{
    public interface ICategoriesRepository
    { 
        Task<IEnumerable<Categories>> GetAllAsync(); 
    }
}
