using FluentValidation;

namespace Bale.Identity.Application.Samples.Commands;
public class CreateSampleCommandValidator : AbstractValidator<CreateSampleCommand>
{
    public CreateSampleCommandValidator()
    {
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
    }
}
