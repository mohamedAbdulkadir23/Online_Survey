using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Survey.Data;

namespace Online_Survey.Controllers
{
	public class LoginController : Controller
	{
		private readonly OnlineDbCon _context;

		public LoginController(OnlineDbCon context)
		{
			_context = context;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(string username, string password)
		{
			// Validate user credentials
			var user = await _context.Users
				.FirstOrDefaultAsync(u => u.Username == username && u.Password == password);

			if (user != null) // If user exists
			{
				// Store user details in session
				HttpContext.Session.SetString("UserEmail", user.Username);
				HttpContext.Session.SetString("IsAuthenticated", "true");

				// Redirect to Addresses controller
				return RedirectToAction("Index", "Addresses");
			}
			else
			{
				ViewBag.Error = "Invalid username or password!";
				return View();
			}
		}

		public IActionResult Logout()
		{
			// Clear session and redirect to login
			HttpContext.Session.Clear();
			return RedirectToAction("Index");
		}
	}
}

