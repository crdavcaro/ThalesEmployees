using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThalesEmployees.Business.Dtos;
using ThalesEmployees.Business.Repositories;
using ThalesEmployees.Model.Entities;

namespace ThalesEmployees.Business.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository _repository;
        IMapper _mapper;
        public EmployeeService(IEmployeeRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async ValueTask<EmployeeDto[]> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();
            return _mapper.Map<EmployeeDto[]>(result);
        }

        public async ValueTask<EmployeeDto> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            return _mapper.Map<EmployeeDto>(result);
        }

        public async ValueTask<EmployeeDto[]> GetListByNameAsync(string name)
        {
            var result = new EmployeeDto[] { };
            var response = await _repository.GetAllAsync();

            if (response != null && response.Length > 0)
            {
                var filteredResult = response.Where(e => e.employee_name.ToLower().Contains(name.ToLower())).ToArray();
                result = _mapper.Map<EmployeeDto[]>(filteredResult);
            }

            return result;
        }
    }
}
