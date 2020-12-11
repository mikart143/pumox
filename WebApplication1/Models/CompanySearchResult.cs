using System.Collections.Generic;
using Services.Models;

namespace WebApi.Models
{
    public class CompanySearchResult
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public virtual ICollection<EmployeeSearchResult> Employees { get; set; }
    }
}