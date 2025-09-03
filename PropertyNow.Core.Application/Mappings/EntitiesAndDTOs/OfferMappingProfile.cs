using AutoMapper;
using PropertyNow.Core.Domain.Entities;
using PropertyNow.Core.Application.DTOs.Offer;

namespace PropertyNow.Core.Application.Mapping
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Offer, OfferDTO>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Client, opt => opt.Ignore()); // Ignorar si no cargas Client en entity
        }
    }
}
