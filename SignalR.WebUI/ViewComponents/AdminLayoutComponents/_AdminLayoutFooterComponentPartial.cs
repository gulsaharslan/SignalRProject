using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutFooterComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
