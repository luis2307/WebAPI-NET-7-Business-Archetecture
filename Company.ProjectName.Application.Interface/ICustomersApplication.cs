using Company.ProjectName.Application.DTO;
using Company.ProjectName.Transversal.Common;

namespace Company.ProjectName.Application.Interface;
public interface ICustomersApplication
{
    #region Métodos Síncronos

    Response<bool> Insert(CustomersDto customersDto);
    Response<bool> Update(CustomersDto customersDto);
    Response<bool> Delete(string customerId);

    Response<CustomersDto> Get(string customerId);
    Response<IEnumerable<CustomersDto>> GetAll();
    ResponsePagination<IEnumerable<CustomersDto>> GetAllWithPagination(int pageNumber, int pageSize);
    #endregion

    #region Métodos Asíncronos
    Task<Response<bool>> InsertAsync(CustomersDto customersDto);
    Task<Response<bool>> UpdateAsync(CustomersDto customersDto);
    Task<Response<bool>> DeleteAsync(string customerId);

    Task<Response<CustomersDto>> GetAsync(string customerId);
    Task<Response<IEnumerable<CustomersDto>>> GetAllAsync();
    Task<ResponsePagination<IEnumerable<CustomersDto>>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
    #endregion
}