using AutoMapper;
using GoodwillSingledb.Application.Goodwills.Queries.GetPartnerDetails;
using GoodwillSingledb.Domain;
using System.Reflection;
using static GoodwillSingledb.Application.Goodwills.Queries.GetPartnerDetails.PartnerDetailsVm;

namespace GoodwillSingledb.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile()
        {
            ApplyMappingsFromAssembly(typeof(AssemblyMappingProfile).Assembly);

            CreateMap<Partner, PartnerDetailsVm>();
            CreateMap<Partner, DeliveryInfo>();
            CreateMap<Partner, Pricing>();
            CreateMap<Partner, Legal>();
            CreateMap<Partner, ConturDiadoc>();
            CreateMap<Partner, SafeStorage>();
        }

        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapWith<>)))
                .ToList();
            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
