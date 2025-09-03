using AutoMapper;
using PropertyNow.Core.Application.DTOs.PropertyType;
using PropertyNow.Core.Application.ViewModels.PropertyType;

namespace PropertyNow.Core.Application.Mappings.DTOsAndViewModels
{
    public class PropertyTypeDTOMappingProfile : Profile
    {
        public PropertyTypeDTOMappingProfile()
        {
            // Mapping entre PropertyTypeDTO y PropertyTypeViewModel
            CreateMap<PropertyTypeDTO, PropertyTypeViewModel>().ReverseMap();

            // Mapping entre PropertyTypeDTO y SavePropertyTypeViewModel
            CreateMap<PropertyTypeDTO, SavePropertyTypeViewModel>().ReverseMap()
                .ForMember(dest => dest.NumberOfProperties, opt => opt.Ignore())
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));

            // Mapping entre PropertyTypeDTO y DeletePropertyTypeViewModel
            CreateMap<PropertyTypeDTO, DeletePropertyTypeViewModel>().ReverseMap()
                .ForMember(dest => dest.Name, opt => opt.Ignore())
                .ForMember(dest => dest.Description, opt => opt.Ignore())
                .ForMember(dest => dest.NumberOfProperties, opt => opt.Ignore());
        }
    }
}
