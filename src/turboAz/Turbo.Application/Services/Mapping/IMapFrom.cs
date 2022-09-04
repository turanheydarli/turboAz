using AutoMapper;

namespace Turbo.Application.Services.Mapping;

public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
}