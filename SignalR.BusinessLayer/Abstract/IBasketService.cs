﻿using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Abstract
{
    public interface IBasketService : IGenericService<Basket>
    {
        List<Basket> TGetBasketByMenuTableNumber(int id);
        List<ResultBasketWithProductNameDto> TGetBasketByMenuTableWithProductName(int id);
    }
}
