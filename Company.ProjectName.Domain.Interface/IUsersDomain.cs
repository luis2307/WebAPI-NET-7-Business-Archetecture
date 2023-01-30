using Company.ProjectName.Domain.Entity;
namespace Company.ProjectName.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username);
        bool Exist(string username);
        bool Register(Users users);
        Task<bool> ExistAsync(string username);

    }
}
