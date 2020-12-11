using System.Collections.Generic;
using System.Threading.Tasks;
using Services.Models;

namespace Services.Interfaces
{
    public interface ICompanyService
    {
        Task<long> CreateCompany(CreateCompanyDTO company);
        Task<ICollection<CompanySearchResultDTO>> SearchCompany(SearchCompanyDTO searchCompany);
        Task<bool> CompanyExist(long id);
        Task UpdateCompany(UpdateCompanyDTO company, long id);
        Task RemoveCompany(long id);
    }
}