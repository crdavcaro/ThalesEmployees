
using AutoMapper;
using ThalesEmployees.Model.Entities;

namespace ThalesEmployees.Business.Dtos.Mappers
{
    internal class Profiles : Profile
    {
        public Profiles()
        { 
            CreateMap<Employee, EmployeeDto>()
                .ForMember(
                    dest => dest.Name,
                    src => src.MapFrom(s => s.employee_name)
                )
                .ForMember(
                    dest => dest.Salary,
                    src => src.MapFrom(s => s.employee_salary)
                )
                .ForMember(
                    dest => dest.Age,
                    src => src.MapFrom(s => s.employee_age)
                )
                .ForMember(
                    dest => dest.ProfileImage,
                    src => src.MapFrom(s => s.profile_image)
                )
                .ForMember(
                    dest=> dest.AnualSalary,
                    src => src.MapFrom(s => s.employee_salary * 12)
                )
                .ReverseMap();        
        }
    }
}
