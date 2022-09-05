using AutoMapper;

namespace Turbo.Application.Services.Mapping;

/// <summary>
/// Maps generic source (T) to current class
/// If you want custom mapping you can override Mapping method
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IMapFrom<T>
{
    void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType()).ReverseMap();
}