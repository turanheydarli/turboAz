using FluentValidation;

namespace Turbo.Application.Features.Categories.Commands.UpdateCategory;

public class UpdateCategoryCommandValidator:AbstractValidator<UpdateCategoryCommand>
{
    public UpdateCategoryCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
    }
}