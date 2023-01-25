using Company.ProjectName.Application.DTO;
using Company.ProjectName.Transversal.Common;

namespace Company.ProjectName.Application.Interface
{
    public interface IUsersApplication
    {
        Response<UsersDto> Authenticate(string username, string password);
    }
}
