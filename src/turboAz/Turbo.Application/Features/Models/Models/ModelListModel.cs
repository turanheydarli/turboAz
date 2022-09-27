using Core.Persistence.Paging;
using Turbo.Application.Features.Models.DTOs;
using Turbo.Application.Services.Mapping;
using Turbo.Domain.Entities.Catalog;

namespace Turbo.Application.Features.Models.Models;

public class ModelListModel : IMapFrom<IPaginate<Model>>
{
    public IList<ModelListDto> Items { get; set; }
}