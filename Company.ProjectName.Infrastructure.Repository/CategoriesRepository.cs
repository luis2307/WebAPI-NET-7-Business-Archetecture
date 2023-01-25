using Company.ProjectName.Domain.Entity;
using Company.ProjectName.Infrastructure.Data;
using Company.ProjectName.Infrastructure.Interface;
using Dapper;
using System.Data;

namespace Company.ProjectName.Infrastructure.Repository
{
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly DapperContext _context;
        public CategoriesRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Categories>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select * From Categories"; 
            var categories = await connection.QueryAsync<Categories>(query, commandType: CommandType.Text);
            return categories;
        }
    }
}
