using AutoMapper;
using PropertyNow.Core.Application.DTOs.Message;
using PropertyNow.Core.Application.ViewModels.Client;

namespace PropertyNow.Core.Application.Mappings.DTOsAndViewModels
{
    public class MessageDTOMappingProfile : Profile
    {
        public MessageDTOMappingProfile()
        {
            CreateMap<MessageDTO, MessageViewModel>().ReverseMap();
        }
    }
}
