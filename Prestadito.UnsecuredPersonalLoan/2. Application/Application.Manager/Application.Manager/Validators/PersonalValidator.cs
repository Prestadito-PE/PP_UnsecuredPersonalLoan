using FluentValidation;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.UpdatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.CreatePersonal;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.GetPersonalById;
using Prestadito.UnsecuredPersonalLoan.Infrastructure.Data.Constants;
using Prestadito.UnsecuredPersonalLoan.Application.Dto.Personal.DisablePersonal;

namespace Prestadito.UnsecuredPersonalLoan.Application.Manager.Validators
{
    public class GetPersonalByIdValidator : AbstractValidator<GetPersonalByIdRequest>
    {
        public GetPersonalByIdValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class CreatePersonalValidator : AbstractValidator<CreatePersonalRequest>
    {
        public CreatePersonalValidator()
        {
            RuleFor(x => x.StrDoi)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblPrincipal)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblApr)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblEacr)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.IntMonths)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrLoanNumber)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DteLoanStart)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class UpdatePersonalValidator : AbstractValidator<UpdatePersonalRequest>
    {
        public UpdatePersonalValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrDoi)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblPrincipal)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblApr)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DblEacr)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.IntMonths)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.StrLoanNumber)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);

            RuleFor(x => x.DteLoanStart)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class DisablePersonalValidator : AbstractValidator<DisablePersonalRequest>
    {
        public DisablePersonalValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }

    public class DeletePersonalValidator : AbstractValidator<DeletePersonalRequest>
    {
        public DeletePersonalValidator()
        {
            RuleFor(x => x.StrId)
                .NotEmpty().WithMessage(ConstantMessages.Validator.PROPERTY_NAME_IS_EMPTY);
        }
    }
}
