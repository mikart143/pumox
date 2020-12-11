using AutoMapper;
using Persistence.Entities;
using Services.Models;

namespace Services.Utils
{
    public class Mappers:Profile
    {
        public Mappers()
        {
            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<Company, CompanySearchResultDTO>();
            CreateMap<Employee, EmployeeSearchResultDTO>();
            CreateMap<UpdateEmployeeDTO, Employee>();
        }
    }
}