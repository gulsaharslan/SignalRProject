using AutoMapper;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebApi.Mapping
{
    public class BasketMapping:Profile
    {
        public BasketMapping()
        {
            CreateMap<Basket, ResultBasketDto>().ReverseMap();
            CreateMap<Basket, ResultBasketWithProductNameDto>().ReverseMap();
        }
      
    }
}
