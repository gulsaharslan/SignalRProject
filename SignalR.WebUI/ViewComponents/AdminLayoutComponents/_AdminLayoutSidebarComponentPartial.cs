using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutSidebarComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
