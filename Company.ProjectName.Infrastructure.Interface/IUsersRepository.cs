using Company.ProjectName.Domain.Entity;

namespace Company.ProjectName.Infrastructure.Interface
{
    public interface IUsersRepository : IGenericRepository<Users>
    {
        Users Authenticate(string username);
        Task<int> ExistAsync(string username); 
        int Exist(string username);
         

    }
}
