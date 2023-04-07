using FluentValidation;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Validators
{
    public class CreatePersonalValidator : AbstractValidator<CreatePersonalDTO>
    {
        public CreatePersonalValidator()
        {
            RuleFor(x => x.strDoi)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dblPrincipal)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dblApr)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dblEacr)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.intMonths)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.strLoanNumber)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dteLoanStart)
                .NotEmpty().WithMessage("{PropertyName} is empty");
        }
    }

    public class UpdatePersonalValidator : AbstractValidator<UpdatePersonalDTO>
    {
        public UpdatePersonalValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.StrDoi)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dblPrincipal)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dblApr)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dblEacr)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.intMonths)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.strLoanNumber)
                .NotEmpty().WithMessage("{PropertyName} is empty");

            RuleFor(x => x.dteLoanStart)
                .NotEmpty().WithMessage("{PropertyName} is empty");
        }
    }
}
