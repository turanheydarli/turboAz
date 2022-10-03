using MediatR;

namespace Turbo.Application.Features.Categories.Commands.DeleteCategory;

public class DeleteCategoryCommand:IRequest
{
    public int Id { get; set; }
}