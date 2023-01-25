using Company.ProjectName.Application.DTO;
using Company.ProjectName.Transversal.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Company.ProjectName.Application.Interface
{
    public interface ICategoriesApplication
    {
        Task<Response<IEnumerable<CategoriesDto>>> GetAllAsync();
    }
}
