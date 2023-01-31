using Company.ProjectName.Application.DTO;
using Company.ProjectName.Transversal.Common;

namespace Company.ProjectName.Application.Interface
{
    public interface ICategoriesApplication
    {
        Task<Response<IEnumerable<CategoriesDto>>> GetAllAsync();
    }
}
