using Company.ProjectName.Domain.Entity;
using Company.ProjectName.Infrastructure.Data;
using Company.ProjectName.Infrastructure.Interface;
using Dapper;
using System.Data;

namespace Company.ProjectName.Infrastructure.Repository
{
    public class CustomersRepository : ICustomersRepository
    {
        private readonly DapperContext _context;
        public CustomersRepository(DapperContext context)
        {
            _context = context;
        }

        #region Métodos Síncronos        

        public bool Insert(Customers customers)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersInsert";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customers.CustomerId);
            parameters.Add("CompanyName", customers.CompanyName);
            parameters.Add("ContactName", customers.ContactName);
            parameters.Add("ContactTitle", customers.ContactTitle);
            parameters.Add("Address", customers.Address);
            parameters.Add("City", customers.City);
            parameters.Add("Region", customers.Region);
            parameters.Add("PostalCode", customers.PostalCode);
            parameters.Add("Country", customers.Country);
            parameters.Add("Phone", customers.Phone);
            parameters.Add("Fax", customers.Fax);

            var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public bool Update(Customers customers)
        {
            using (var connection = _context.CreateConnection())
            {
                var query = "CustomersUpdate";
                var parameters = new DynamicParameters();
                parameters.Add("CustomerID", customers.CustomerId);
                parameters.Add("CompanyName", customers.CompanyName);
                parameters.Add("ContactName", customers.ContactName);
                parameters.Add("ContactTitle", customers.ContactTitle);
                parameters.Add("Address", customers.Address);
                parameters.Add("City", customers.City);
                parameters.Add("Region", customers.Region);
                parameters.Add("PostalCode", customers.PostalCode);
                parameters.Add("Country", customers.Country);
                parameters.Add("Phone", customers.Phone);
                parameters.Add("Fax", customers.Fax);

                var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
                return result > 0;
            }
        }

        public bool Delete(string customerId)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersDelete";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customerId);
            var result = connection.Execute(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public Customers Get(string customerId)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersGetByID";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customerId);

            var customer = connection.QuerySingle<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public IEnumerable<Customers> GetAll()
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersList"; 
            var customers = connection.Query<Customers>(query, commandType: CommandType.StoredProcedure);
            return customers;
        }

        public IEnumerable<Customers> GetAllWithPagination(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize); 
            var customers = connection.Query<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return customers;
        }

        public int Count()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(1) from Customers"; 
            var count = connection.ExecuteScalar<int>(query, commandType: CommandType.Text);
            return count;
        }

        #endregion

        #region Métodos Asíncronos

        public async Task<bool> InsertAsync(Customers customers)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersInsert";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customers.CustomerId);
            parameters.Add("CompanyName", customers.CompanyName);
            parameters.Add("ContactName", customers.ContactName);
            parameters.Add("ContactTitle", customers.ContactTitle);
            parameters.Add("Address", customers.Address);
            parameters.Add("City", customers.City);
            parameters.Add("Region", customers.Region);
            parameters.Add("PostalCode", customers.PostalCode);
            parameters.Add("Country", customers.Country);
            parameters.Add("Phone", customers.Phone);
            parameters.Add("Fax", customers.Fax);  
            var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> UpdateAsync(Customers customers)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersUpdate";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customers.CustomerId);
            parameters.Add("CompanyName", customers.CompanyName);
            parameters.Add("ContactName", customers.ContactName);
            parameters.Add("ContactTitle", customers.ContactTitle);
            parameters.Add("Address", customers.Address);
            parameters.Add("City", customers.City);
            parameters.Add("Region", customers.Region);
            parameters.Add("PostalCode", customers.PostalCode);
            parameters.Add("Country", customers.Country);
            parameters.Add("Phone", customers.Phone);
            parameters.Add("Fax", customers.Fax);

            var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<bool> DeleteAsync(string customerId)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersDelete";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customerId);
            var result = await connection.ExecuteAsync(query, param: parameters, commandType: CommandType.StoredProcedure);
            return result > 0;
        }

        public async Task<Customers> GetAsync(string customerId)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersGetByID";
            var parameters = new DynamicParameters();
            parameters.Add("CustomerID", customerId); 
            var customer = await connection.QuerySingleAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return customer;
        }

        public async Task<IEnumerable<Customers>> GetAllAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersList"; 
            var customers = await connection.QueryAsync<Customers>(query, commandType: CommandType.StoredProcedure);
            return customers;
        }



        public async Task<IEnumerable<Customers>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            using var connection = _context.CreateConnection();
            var query = "CustomersListWithPagination";
            var parameters = new DynamicParameters();
            parameters.Add("PageNumber", pageNumber);
            parameters.Add("PageSize", pageSize); 
            var customers = await connection.QueryAsync<Customers>(query, param: parameters, commandType: CommandType.StoredProcedure);
            return customers;
        }

        public async Task<int> CountAsync()
        {
            using var connection = _context.CreateConnection();
            var query = "Select Count(1) from Customers"; 
            var count = await connection.ExecuteScalarAsync<int>(query, commandType: CommandType.Text);
            return count;
        }

        #endregion
    }
}