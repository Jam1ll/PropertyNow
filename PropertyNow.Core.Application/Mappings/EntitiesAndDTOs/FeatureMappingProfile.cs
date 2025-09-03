using AutoMapper;
using PropertyNow.Core.Application.DTOs.Feature;
using PropertyNow.Core.Application.Features.Features.Commands.Create;
using PropertyNow.Core.Application.Features.Features.Commands.Update;
using PropertyNow.Core.Domain.Entities;

namespace PropertyNow.Core.Application.Mappings.EntitiesAndDTOs
{
    public class FeatureMappingProfile : Profile
    {
        public FeatureMappingProfile()
        {
            // Entity ↔ DTO
            CreateMap<Feature, FeatureDTO>()
                .ForMember(dest => dest.NumberOfProperties, opt => opt.MapFrom(src => src.Properties != null ? src.Properties.Count : 0))
                .ReverseMap()
                .ForMember(dest => dest.Properties, opt => opt.Ignore());

            // Commands → Entity
            CreateMap<CreateFeatureCommand, Feature>();
            CreateMap<UpdateFeatureCommand, Feature>();

            // Entity ↔ DTOs directos
            CreateMap<Feature, CreateFeatureDTO>().ReverseMap();
            CreateMap<Feature, UpdateFeatureDTO>().ReverseMap();
        }
    }
}
