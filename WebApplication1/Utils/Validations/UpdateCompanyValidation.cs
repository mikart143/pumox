using FluentValidation;
using WebApi.Models;

namespace WebApi.Utils.Validations
{
    public class UpdateCompanyValidation: AbstractValidator<UpdateCompany>
    {
        public UpdateCompanyValidation()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.EstablishmentYear).NotEmpty();
            RuleForEach(x => x.Employees).SetValidator(new UpdateWorkerValidation());
        }
    }
}