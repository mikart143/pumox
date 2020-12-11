using System.Collections.Generic;

namespace WebApi.Models
{
    public class CreateCompany
    {
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public ICollection<CreateEmployee> Employees { get; set; }
    }
}