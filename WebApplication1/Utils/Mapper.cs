using AutoMapper;
using Persistence.Entities;
using Services.Models;
using WebApi.Models;

namespace WebApi.Utils
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<EmployeeSearchResultDTO, EmployeeSearchResult>()
                .ForMember(x => x.DateOfBirth, opt => opt.MapFrom(y => y.DateOfBirth.ToString("yyyy-MM-dd")));
            CreateMap<CompanySearchResultDTO, CompanySearchResult>();



            CreateMap<CreateEmployeeDTO, Employee>();
            CreateMap<CreateCompanyDTO, Company>();
            CreateMap<Company, CompanySearchResult>();
            CreateMap<Employee, EmployeeSearchResult>();
            CreateMap<UpdateEmployeeDTO, Employee>();

            CreateMap<CreateCompany, CreateCompanyDTO>();
            CreateMap<CreateCompanyDTO, CreateCompany>();

            CreateMap<CreateEmployee, CreateEmployeeDTO>();
            CreateMap<CreateEmployeeDTO, CreateEmployee>();

            CreateMap<SearchCompany, SearchCompanyDTO>();
            CreateMap<UpdateCompany, UpdateCompanyDTO>();
            CreateMap<UpdateEmployee, UpdateEmployeeDTO>();
        }
    }
}