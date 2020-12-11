using System;
using System.Collections.Generic;

namespace WebApi.Models
{
    public class SearchCompany
    {
        public string Keyword { get; set; }
        public DateTime? EmployeeDateOfBirthFrom { get; set; }
        public DateTime? EmployeeDateOfBirthTo { get; set; }
        public ICollection<string> EmployeeJobTitles { get; set; }
    }
}