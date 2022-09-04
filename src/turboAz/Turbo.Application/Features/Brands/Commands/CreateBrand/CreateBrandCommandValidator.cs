using FluentValidation;

namespace Turbo.Application.Features.Brands.Commands.CreateBrand;

public class CreateBrandCommandValidator : AbstractValidator<CreateBrandCommand>
{
    public CreateBrandCommandValidator()
    {
        RuleFor(p => p.Name).NotNull().NotEmpty().MaximumLength(50);
    }
}