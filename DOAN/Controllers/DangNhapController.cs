using DOAN.Utilities;
using DOAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOAN.Controllers
{
    public class DangNhapController : Controller
    {
        private readonly QlksContext _context;
        public DangNhapController(QlksContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Index(TbTaiKhoan user)
        {
            if (user == null)
            {
                return NotFound();
            }
            string pw = Functions.MD5Password(user.MatKhau);
            var check = _context.TbTaiKhoans.Where(m => (m.TenDangNhap == user.TenDangNhap) && (m.MatKhau == pw)).FirstOrDefault();

            if (check == null)
            {
                Functions._Message = "Invalid UserName or Password!";
                return RedirectToAction("Index", "Login");
            }
            Functions._Message = string.Empty;
            Functions._AccountId = check.IdNguoiDung;
            Functions._Username = string.IsNullOrEmpty(check.TenDangNhap) ? string.Empty : check.TenDangNhap;
            return RedirectToAction("Index", "Home");
        }
    }
}
