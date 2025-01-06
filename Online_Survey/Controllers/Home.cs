using Microsoft.AspNetCore.Mvc;

namespace Online_Survey.Controllers
{
	public class Home : Controller
	{
		public IActionResult home()
		{

			return View();
		}
	}
}
