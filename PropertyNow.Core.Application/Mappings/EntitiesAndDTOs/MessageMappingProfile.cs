using AutoMapper;
using PropertyNow.Core.Application.DTOs.Message;
using PropertyNow.Core.Domain.Entities;


namespace PropertyNow.Core.Application.Mappings.EntitiesAndDTOs
{
    public class MessageMappingProfile : Profile
    {
        public MessageMappingProfile()
        {
            CreateMap<Message, MessageDTO>()
                .ForMember(d => d.SentAt, o => o.MapFrom(s => s.SentAt)); 

            CreateMap<MessageDTO, Message>()
                .ForMember(d => d.Property, o => o.Ignore());
        }
    }
}
