using FluentValidation;

namespace Turbo.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommandValidator:AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(p => p.Name).NotNull();
        
        //TODO: Set all rules 
    }
}