using AutoMapper;
using PropertyNow.Core.Application.DTOs.Offer;
using PropertyNow.Core.Application.ViewModels.Client;

namespace PropertyNow.Core.Application.Mapping
{
    public class DtoToViewModelProfile : Profile
    {
        public DtoToViewModelProfile()
        {
            CreateMap<OfferDTO, OfferViewModel>();

        }
    }
}
