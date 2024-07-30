
using ThalesEmployees.Model.Entities;
using ThalesEmployees.Model.Helpers;

namespace ThalesEmployees.Business.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        IHttpHelper _httpHelper;
        string _baseUrl;
        public EmployeeRepository(IHttpHelper httpHelper, string baseUrl) 
        { 
            _httpHelper = httpHelper;
            _baseUrl = baseUrl;
        }
        public async ValueTask<Employee[]> GetAllAsync()
        {
            var url = $"{_baseUrl}/employees";
            var result = await _httpHelper.GetAsync<HttpWrapper<Employee[]>>(url);
            return (Employee[])result.data;
        }

        public async ValueTask<Employee> GetByIdAsync(int id)
        {
            var url = $"{_baseUrl}/employee/{id}";
            var result = await _httpHelper.GetAsync<HttpWrapper<Employee>>(url);
            return (Employee)result.data;
        }
    }
}
