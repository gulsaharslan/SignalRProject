using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.BasketDtos;
using SignalR.WebUI.Dtos.ProductDtos;
using SignalR.WebUI.Models;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace SignalR.WebUI.Controllers
{
    public class MenuController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public MenuController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            TempData["menuTableId"] = id;
            ViewBag.v = id;
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7018/api/Products/ProductListWithCategory");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> AddBasket([FromBody] CreateBasketDto createBasketDto)
        {

            // API'ye veri gönderme
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createBasketDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7018/api/Baskets", stringContent);

            if (responseMessage.IsSuccessStatusCode)
            { 
                // MenuTable durumu güncelleme
                var client2 = _httpClientFactory.CreateClient();
                await client2.GetAsync("https://localhost:7018/api/MenuTables/ChangeMenuTableStatusTrue?id=" + createBasketDto.MenuTableID);
                return Ok("Ürün sepete başarıyla eklendi.");
            }

            return BadRequest("Ürün sepete eklenemedi.");


        }
    }
}
