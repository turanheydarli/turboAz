using FluentValidation;
using Turbo.Application.Features.Models.Constants;

namespace Turbo.Application.Features.Models.Commands.CreateModel;

public class CreateModelCommandValidator:AbstractValidator<CreateModelCommand>
{
    public CreateModelCommandValidator()
    {
        RuleFor(p => p.BrandId).GreaterThan(0)
            .WithMessage(ModelMessages.BrandIdMustBeGreaterThanZero);
    }
}