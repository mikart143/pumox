using FluentValidation;
using WebApi.Models;
using WebApi.Utils.Validators;

namespace WebApi.Utils.Validations
{
    public class SearchCompanyValidation: AbstractValidator<SearchCompany>
    {
        public SearchCompanyValidation()
        {
            RuleFor(x => x.EmployeeJobTitles).Must(JobTitleValidator.Validate).WithMessage($"The title is not in range of: {string.Join(',', JobTitleValidator.Titles)}");
        }
    }
}