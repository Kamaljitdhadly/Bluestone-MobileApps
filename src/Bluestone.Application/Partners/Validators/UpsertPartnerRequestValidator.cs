using Bluestone.Domain.Entities.Partners.RequestModels;
using FluentValidation;

namespace Bluestone.Application.Partners.Validators
{
    public class UpsertPatientCommandValidator : AbstractValidator<UpsertPartnerRequestModel>
    {
        public UpsertPatientCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(60);
            RuleFor(x => x.FirstName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(20);
            RuleFor(x => x.City).MaximumLength(20);
        }
    }
}
