using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThalesEmployees.Business.Dtos
{
    public record EmployeeDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
        public decimal? AnualSalary { get; set; }
        public int Age { get; set; }
        public string ProfileImage { get; set; }
    }
}
