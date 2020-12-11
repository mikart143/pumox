using System.Collections.Generic;

namespace Services.Models
{
    public class CompanySearchResultDTO
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public virtual ICollection<EmployeeSearchResultDTO> Employees { get; set; }
    }
}