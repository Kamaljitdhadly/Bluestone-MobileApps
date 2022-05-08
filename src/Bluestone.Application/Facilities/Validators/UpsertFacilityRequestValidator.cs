using Bluestone.Domain.Entities.Facilities.RequestModels;
using FluentValidation;

namespace Bluestone.Application.Facilities.Validators
{
    public class UpsertFacilityRequestValidator : AbstractValidator<UpsertFacilityRequestModel>
    {
        public UpsertFacilityRequestValidator()
        {
            RuleFor(x => x.FacilityId).NotEmpty();
            RuleFor(x => x.Title).MaximumLength(60);
            RuleFor(x => x.FirstName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.LastName).MaximumLength(20).NotEmpty();
            RuleFor(x => x.Address).MaximumLength(20);
            RuleFor(x => x.City).MaximumLength(20);
        }
    }
}
