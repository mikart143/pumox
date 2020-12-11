using System.Collections.Generic;

namespace WebApi.Models
{
    public class UpdateCompany
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<UpdateEmployee> Employees { get; set; }
    }
}