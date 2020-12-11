using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Entities;
using Services.Interfaces;
using Services.Models;
using Services.Utils;

namespace Services.Implementations
{
    public class CompanyService:ICompanyService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMapper _mapper;
        public CompanyService(ApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<long> CreateCompany(CreateCompanyDTO company)
        {
            var entity = _mapper.Map<Company>(company);

            await _dbContext.Companies.AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return entity.CompanyId;
        }

        public async Task<ICollection<CompanySearchResultDTO>> SearchCompany(SearchCompanyDTO searchCompany)
        {
            var result = await Task.Run(() =>
            {
                var entries = _dbContext.Companies.Include(x => x.Employees).Where(x =>
                    string.IsNullOrEmpty(searchCompany.Keyword) ||
                    (x.Name.Contains(searchCompany.Keyword) ||
                     x.Employees.Any(y =>
                         y.FirstName.Contains(searchCompany.Keyword) ||
                         y.LastName.Contains(searchCompany.Keyword)))).ToList();



                foreach (var company in entries)
                {
                    var filtered = new List<Employee>();

                    foreach (var employee in company.Employees)
                    {
                        if(CanTakeEmployee(searchCompany, employee)) filtered.Add(employee);
                    }

                    company.Employees.Clear();
                    company.Employees.AddRange(filtered);
                }

                var mapped = _mapper.Map<ICollection<CompanySearchResultDTO>>(entries);

                return mapped;
            });

            return result;
        }

        private bool CanTakeEmployee(SearchCompanyDTO searchCompany, Employee employee)
        {
            var a = (searchCompany.EmployeeDateOfBirthTo == null || employee.DateOfBirth < searchCompany.EmployeeDateOfBirthTo);
            var b = (searchCompany.EmployeeDateOfBirthFrom == null || employee.DateOfBirth > searchCompany.EmployeeDateOfBirthFrom);
            var c = (!searchCompany.EmployeeJobTitles.Any() || searchCompany.EmployeeJobTitles.Contains(employee.JobTitle));
            var d = a && b && c;

            return d;
        }

        public async Task<bool> CompanyExist(long id)
        {
            var result = await _dbContext.Companies.FindAsync(id);
            return result != null;
        }

        public async Task UpdateCompany(UpdateCompanyDTO company, long id)
        {
            var entry = await _dbContext.Companies.Include(b => b.Employees).FirstOrDefaultAsync(x => x.CompanyId == id);

            entry.Employees.Clear();
            var employees = _mapper.Map<ICollection<Employee>>(company.Employees);
            entry.Employees = employees;

            entry.Name = company.Name;
            entry.EstablishmentYear = company.EstablishmentYear;

            _dbContext.Companies.Update(entry);

            await _dbContext.SaveChangesAsync();
        }

        public async Task RemoveCompany(long id)
        {
            var entry = await _dbContext.Companies.FindAsync(id);
            _dbContext.Remove(entry);

            await _dbContext.SaveChangesAsync();
        }
    }
}