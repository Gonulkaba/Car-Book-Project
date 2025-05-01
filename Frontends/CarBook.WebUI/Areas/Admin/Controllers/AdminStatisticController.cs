using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminStatistic")]
	public class AdminStatisticController : Controller
	{
		[Route("Index")]
		public IActionResult Index()
		{
			return View();
		}
	}
}
