using Company.ProjectName.Domain.Entity;


namespace Company.ProjectName.Domain.Interface
{
    public interface IUsersDomain
    {
        Users Authenticate(string username, string password);
    }
}
