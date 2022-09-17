using MediatR;
using Turbo.Application.Features.Models.DTOs;

namespace Turbo.Application.Features.Models.Commands.UpdateModel;

public class UpdateModelCommand : IRequest<UpdatedModelDto>
{
    public int Id { get; set; }
    public string Name { get; set; }
}