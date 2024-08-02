using AutoMapper;

namespace GoodwillSingledb.Application.Common.Mappings
{
    internal interface IMapWith<T>
    {
        void Mapping(Profile profile) =>
            profile.CreateMap(typeof(T), GetType());
    }
}
