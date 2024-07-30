
using ThalesEmployees.Business.Dtos;

namespace ThalesEmployees.Business.Services
{
    public interface IEmployeeService : IService<EmployeeDto, int>
    {
        ValueTask<EmployeeDto> GetByIdAsync(int id);

        ValueTask<EmployeeDto[]> GetListByNameAsync(string name);
    }
}
