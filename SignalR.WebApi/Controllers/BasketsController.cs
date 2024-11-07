using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DtoLayer.BasketDto;
using SignalR.EntityLayer.Entities;

namespace SignalR.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BasketsController : ControllerBase
    {
        private readonly IBasketService _basketService;
        private readonly IMapper _mapper;
        public BasketsController(IBasketService basketService, IMapper mapper)
        {
            _basketService = basketService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBasketByMenuTableID(int id)
        {
            var values = _basketService.TGetBasketByMenuTableNumber(id);
            return Ok(_mapper.Map<List<ResultBasketDto>>(values));
        }

        [HttpGet("GetBasketListByMenuTableWithProductName")]
        public IActionResult GetBasketListByMenuTableWithProductName(int id)
        {
            var values = _basketService.TGetBasketByMenuTableWithProductName(id);
            return Ok(_mapper.Map<List<ResultBasketWithProductNameDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateBasket(CreateBasketDto createBasketDto)
        {
            var context=new SignalRContext();
            var productPrice = context.Products.Where(x => x.ProductID == createBasketDto.ProductID).Select(y => y.Price).FirstOrDefault();
            _basketService.TAdd(new Basket()
            {
                ProductID = createBasketDto.ProductID,
                Count = 1,
                MenuTableID = 1,
                Price =productPrice,
                TotalPrice = productPrice
            });
            return Ok("Ürün Sepete Eklendi");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBasket(int id)
        {
            var value = _basketService.TGetByID(id);
            _basketService.TDelete(value);
            return Ok("Sepetteki Seçilen Ürün Silindi");
        }
    }
}
