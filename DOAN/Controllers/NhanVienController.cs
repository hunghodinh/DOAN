using DOAN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOAN.Controllers
{
	public class NhanVienController : Controller
	{
		private readonly QlksContext _context;
		public NhanVienController(QlksContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			return View();
		}
	}
}
