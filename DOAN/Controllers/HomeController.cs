using DOAN.Models;
using DOAN.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DOAN.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;

		public HomeController(ILogger<HomeController> logger)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			if (!Functions.IsLogin())
				return RedirectToAction("Index", "DangNhap");
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
        public IActionResult Logout()
        {
            // Xóa thông tin đăng nhập
            Functions._AccountId = string.Empty;
            Functions._Username = string.Empty;
            Functions._Message = string.Empty;

            // Chuyển hướng tới trang đăng nhập
            return RedirectToAction("Index", "DangNhap");
        }
    }
}