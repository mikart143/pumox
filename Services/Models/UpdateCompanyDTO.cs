using System.Collections.Generic;

namespace Services.Models
{
    public class UpdateCompanyDTO
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public virtual ICollection<UpdateEmployeeDTO> Employees { get; set; }
    }
}