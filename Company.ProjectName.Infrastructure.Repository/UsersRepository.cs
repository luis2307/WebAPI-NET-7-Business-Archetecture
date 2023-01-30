using Company.ProjectName.Domain.Entity;
using Company.ProjectName.Infrastructure.Data;
using Company.ProjectName.Infrastructure.Interface;
using Dapper;
using System.Data;

namespace Company.ProjectName.Infrastructure.Repository
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DapperContext _context;
        public UsersRepository(DapperContext context)
        {
            _context = context;
        }
        #region Métodos Síncronos     
        public Users Authenticate(string userName )
        {
            using var connection = _context.CreateConnection();
            var query = "UsersGetByUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", userName); 
            var user = connection.QuerySingle<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return user;
        }

        public int Exist(string username)
        {
            using var connection = _context.CreateConnection();
            var query = "UsersGetByUserName";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", username);
            var count = connection.QuerySingle<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return count;
        }

        public Users Get(string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Users> GetAll()
        {
            throw new System.NotImplementedException();
        } 

        public int Count()
        {
            throw new System.NotImplementedException();
        } 

        public bool Delete(string id)
        {
            throw new System.NotImplementedException();
        }

        public bool Insert(Users entity)
        {
            using var connection = _context.CreateConnection();
            var query = "UsersInsert";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", entity.UserId);
            parameters.Add("FirstName", entity.FirstName);
            parameters.Add("LastName", entity.LastName);
            parameters.Add("UserName", entity.UserName);
            parameters.Add("Password", entity.Password);
            var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Update(Users entity)
        {
            throw new System.NotImplementedException();
        }
        public IEnumerable<Users> GetAllWithPagination(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<Users> AuthenticateAsync(string userName )
        {
            using var connection = _context.CreateConnection();
            var query = "UsersGetByUser";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", userName);
            var user = await connection.QuerySingleAsync<Users>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return user;
        }
        public async Task<bool> InsertAsync(Users entity)
        {
            using var connection = _context.CreateConnection();
            var query = "UsersInsert";
            var parameters = new DynamicParameters();
            parameters.Add("UserId", entity.UserId);
            parameters.Add("FirstName", entity.FirstName);
            parameters.Add("LastName", entity.LastName);
            parameters.Add("UserName", entity.UserName);
            parameters.Add("Password", entity.Password);
            var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }


        public async Task<int> CountAsync()
        {
            throw new System.NotImplementedException();
        }
        public async Task<bool> DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }
        public async Task<int> ExistAsync(string username)
        {
            using var connection = _context.CreateConnection();
            var query = "UsersGetByUserName";
            var parameters = new DynamicParameters();
            parameters.Add("UserName", username);
            var count = await connection.QuerySingleAsync<int>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return count;
        }

        public async Task<IEnumerable<Users>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<Users>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Users> GetAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateAsync(Users entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
