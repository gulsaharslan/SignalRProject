﻿using AutoMapper;
using SignalR.DtoLayer.NotificationDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebApi.Mapping
{
    public class NotificationMapping : Profile
    {
        public NotificationMapping() 
        {
          CreateMap<Notification, ResultNotificationDto>().ReverseMap();
          CreateMap<Notification, CreateNotificationDto>().ReverseMap();
          CreateMap<Notification, GetByIdNotificationDto>().ReverseMap();
          CreateMap<Notification, UpdateNotificationDto>().ReverseMap();
        }
    }
}
