using System.Collections.Generic;

namespace Services.Models
{
    public class CreateCompanyDTO
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public virtual ICollection<CreateEmployeeDTO> Employees { get; set; }
    }
}