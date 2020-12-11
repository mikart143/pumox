using FluentValidation;
using WebApi.Models;
using WebApi.Utils.Validators;

namespace WebApi.Utils.Validations
{
    public class UpdateWorkerValidation: AbstractValidator<UpdateEmployee>
    {
        public UpdateWorkerValidation()
        {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.DateOfBirth).NotEmpty();
            RuleFor(x => x.JobTitle).Must(JobTitleValidator.Validate).WithMessage($"The title is not in range of: {string.Join(',', JobTitleValidator.Titles)}");
        }
    }
}