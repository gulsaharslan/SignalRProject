using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult NotFound404Page()
        {
            return View();
        }
    }
}
