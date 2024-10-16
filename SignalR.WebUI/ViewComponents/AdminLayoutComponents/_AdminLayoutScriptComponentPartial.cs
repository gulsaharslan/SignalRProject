using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.ViewComponents.AdminLayoutComponents
{
	public class _AdminLayoutScriptComponentPartial : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}
