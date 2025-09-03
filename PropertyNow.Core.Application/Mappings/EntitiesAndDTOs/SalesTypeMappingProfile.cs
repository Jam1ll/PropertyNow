using AutoMapper;
using PropertyNow.Core.Application.DTOs.SalesType;
using PropertyNow.Core.Application.Features.SalesTypes.Commands.Create;
using PropertyNow.Core.Application.Features.SalesTypes.Commands.Update;
using PropertyNow.Core.Domain.Entities;

namespace PropertyNow.Core.Application.Mappings.EntitiesAndDTOs
{
    public class SalesTypeMappingProfile : Profile
    {
        public SalesTypeMappingProfile()
        {
            // Entity <-> DTO principal
            CreateMap<SalesType, SalesTypeDTO>()
                .ForMember(dest => dest.NumberOfProperties, opt => opt.MapFrom(src => src.Properties != null ? src.Properties.Count : 0))
                .ReverseMap()
                .ForMember(dest => dest.Properties, opt => opt.Ignore());

            // Para API CQRS (Create Command -> Entity)
            CreateMap<CreateSalesTypeCommand, SalesType>()
                .ForMember(dest => dest.Properties, opt => opt.Ignore());

            // Para API CQRS (Update Command -> Entity)
            CreateMap<UpdateSalesTypeCommand, SalesType>()
                .ForMember(dest => dest.Properties, opt => opt.Ignore());

            // Entity <-> DTOs de creación/actualización directa (por si se usan en API sin CQRS)
            CreateMap<SalesType, CreateSalesTypeDTO>().ReverseMap();
            CreateMap<SalesType, UpdateSalesTypeDTO>().ReverseMap();
        }
    }
}
