using DOAN.Models;
using DOAN.Utilities;
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
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "DangNhap");
            var mn = _context.TbNhanViens.OrderBy(m => m.IdNv).ToList();
			return View(mn);
		}
		public IActionResult Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var mn = _context.TbNhanViens.Find(id);
			if (mn == null)
			{
				return NotFound();
			}
			return View(mn);
		}
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public IActionResult DeleteConfirmed(string id)
		{
			var nv = _context.TbNhanViens.Find(id);
			if (nv == null)
			{
				return NotFound();
			}
			// Tìm tất cả các bản ghi 
			var tk = _context.TbTaiKhoans.Where(p => p.IdNv == id).ToList();
			if (tk.Any())
			{
				// Nếu có bản ghi, xóa chúng trước
				_context.TbTaiKhoans.RemoveRange(tk);
			}

			_context.TbNhanViens.Remove(nv);
			_context.SaveChanges();
			return RedirectToAction(nameof(Index));
		}
		public IActionResult Create()
		{
			var mn = _context.TbNhanViens.OrderBy(m => m.IdNv).ToList();
			ViewBag.mn = mn;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Create(TbNhanVien mn)
		{
			if (ModelState.IsValid)
			{
				// Thêm dữ liệu mới vào bảng  trong cơ sở dữ liệu
				_context.TbNhanViens.Add(mn);
				_context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

				return RedirectToAction("Index"); // Chuyển hướng đến trang Index sau khi thêm thành công
			}

			// Nếu ModelState không hợp lệ, trả về View với model để hiển thị lỗi
			return View(mn);
		}
        public IActionResult DanhSach()
        {
            var mn = _context.TbTaiKhoans.OrderBy(m => m.IdNguoiDung).ToList();
            return View(mn);
        }
		public IActionResult CreateTK()
		{
			var mn = _context.TbTaiKhoans.OrderBy(m => m.IdNguoiDung).ToList();
			ViewBag.mn = mn;
			return View();
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult CreateTK(TbTaiKhoan mn)
		{
			if (ModelState.IsValid)
			{
				var check = _context.TbTaiKhoans.Where(m => m.TenDangNhap == mn.TenDangNhap).FirstOrDefault();
				if (check != null)
				{
					Functions._MessageEmail = "Trùng tên đăng nhập";
					return RedirectToAction("DanhSach");
				}
				Functions._MessageEmail = string.Empty;
				mn.MatKhau = Functions.MD5Password(mn.MatKhau);
				// Thêm dữ liệu mới vào bảng  trong cơ sở dữ liệu
				_context.TbTaiKhoans.Add(mn);
				_context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

				return RedirectToAction("Index"); // Chuyển hướng đến trang Index sau khi thêm thành công
			}

			// Nếu ModelState không hợp lệ, trả về View với model để hiển thị lỗi
			return View(mn);
		}

	}
}
