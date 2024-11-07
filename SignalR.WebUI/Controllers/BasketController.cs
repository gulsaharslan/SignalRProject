using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.WebUI.Dtos.BasketDtos;

namespace SignalR.WebUI.Controllers
{
    public class BasketController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BasketController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7018/api/Baskets/GetBasketListByMenuTableWithProductName?id=1");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultBasketWithProductNameDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        public async Task<IActionResult> DeleteBasket(int id)
        {
            //id = int.Parse(TempData["id"].ToString());
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7018/api/Baskets/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return NoContent();
        }
    }
}
