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

        // Phương thức Index hiển thị trang đăng nhập
        public IActionResult Index()
        {
            return View();
        }

        // Phương thức xử lý đăng nhập
        [HttpPost]
        public IActionResult Index(TbTaiKhoan user)
        {
            if (user == null)
            {
                Functions._Message = "Dữ liệu người dùng bị thiếu.";
                return View(user);
            }
            var mn = _context.TbTaiKhoans.FirstOrDefault();
            // Kiểm tra trạng thái của tài khoản
            if ( mn.TrangThai == false)
            {
                Functions._Message = "Tài khoản không hoạt động!";
                return View(user);
            }
            string pw = Functions.MD5Password(user.MatKhau);
            var check = _context.TbTaiKhoans.FirstOrDefault(m => m.TenDangNhap == user.TenDangNhap && m.MatKhau == pw);

            if (check == null)
            {
                Functions._Message = "Sai username hoặc password!";
                return View(user);
            }
            
            Functions._Message = string.Empty;
            Functions._AccountId = check.IdNguoiDung.ToString();
            Functions._Username = string.IsNullOrEmpty(check.TenDangNhap) ? string.Empty : check.TenDangNhap;
            return RedirectToAction("Index", "Home");
        }
        

    }
}
