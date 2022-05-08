using Bluestone.Domain.Entities.Messages.RequestModels;
using FluentValidation;

namespace Bluestone.Application.Messages.Validators
{
    public class UpsertMessageRequestValidator : AbstractValidator<UpsertMessageRequestModel>
    {
        public UpsertMessageRequestValidator()
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
