using MediatR;

namespace Turbo.Application.Features.Models.Commands.DeleteModel;

public class DeleteModelCommand : IRequest<Unit>
{
    public int Id { get; set; }
}