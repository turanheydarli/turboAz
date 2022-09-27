using Core.Application.Pipelines.Authorization;
using MediatR;
using Turbo.Application.Features.Models.DTOs;

namespace Turbo.Application.Features.Models.Commands.CreateModel;

public class CreateModelCommand : IRequest<CreatedModelDto>,ISecuredRequest
{
    public int BrandId { get; set; }
    public string Name { get; set; }
    public string[] Roles => new[] { "Model.Create" };
}