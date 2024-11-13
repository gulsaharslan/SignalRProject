using AutoMapper;
using SignalR.DtoLayer.MessageDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebApi.Mapping
{
    public class MessageMapping : Profile
    {
        public MessageMapping() 
        {
           CreateMap<Message, ResultMessageDto>().ReverseMap();
           CreateMap<Message, CreateMessageDto>().ReverseMap();
           CreateMap<Message, UpdateMessageDto>().ReverseMap();
           CreateMap<Message, GetByIdMessageDto>().ReverseMap();
        }
    }
}
