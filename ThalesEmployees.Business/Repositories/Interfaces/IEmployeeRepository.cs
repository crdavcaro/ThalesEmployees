using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Model.Entities;

namespace ThalesEmployees.Business.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
        ValueTask<Employee> GetByIdAsync(int id);
    }
}
