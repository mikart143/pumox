using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Persistence.Entities
{
    public class Company
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CompanyId { get; set; }
        public string Name { get; set; }
        public int EstablishmentYear { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}