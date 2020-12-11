using FluentValidation;
using WebApi.Models;

namespace WebApi.Utils.Validations
{
    public class CreateCompanyValidation:AbstractValidator<CreateCompany>
    {
        public CreateCompanyValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EstablishmentYear).NotEmpty().GreaterThan(0);
            RuleForEach(x => x.Employees).SetValidator(new CreateWorkerValidation());
        }
    }
}