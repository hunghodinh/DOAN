using DOAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DOAN.Controllers
{
	public class KhachHangController : Controller
	{
		private readonly QlksContext _context;
		public KhachHangController(QlksContext context)
		{
			_context = context;
		}
		public IActionResult Index()
		{
			var mn = _context.TbKhachHangs.OrderBy(m=>m.IdKh).ToList();
			return View(mn);
		}
		public IActionResult Delete(string? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var mn = _context.TbKhachHangs.Find(id);
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
            var khachHang = _context.TbKhachHangs.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            // Tìm tất cả các bản ghi từ bảng tbCTPhieuDangKy có IdKH tương ứng
            var phieuDangKyList = _context.TbCtphieuDangKies.Where(p => p.IdKh == id).ToList();
            if (phieuDangKyList.Any())
            {
                // Nếu có bản ghi, xóa chúng trước
                _context.TbCtphieuDangKies.RemoveRange(phieuDangKyList);
            }

            _context.TbKhachHangs.Remove(khachHang);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Create()
        {
            var mn = _context.TbKhachHangs.OrderBy(m=>m.IdKh).ToList();
            ViewBag.mn = mn;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TbKhachHang mn)
        {
            if (ModelState.IsValid)
            {
                // Thêm dữ liệu mới vào bảng TbKhachHang trong cơ sở dữ liệu
                _context.TbKhachHangs.Add(mn);
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index"); // Chuyển hướng đến trang Index sau khi thêm thành công
            }

            // Nếu ModelState không hợp lệ, trả về View với model để hiển thị lỗi
            return View(mn);
        }
        public IActionResult Edit(string? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var po = _context.TbKhachHangs.Find(id);
            if (po == null)
            {
                return NotFound();
            }

            var polist = _context.TbKhachHangs.OrderBy(m => m.IdKh).ToList();
            ViewBag.poList = polist;
            return View(po);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(TbKhachHang po)
        {
            if (ModelState.IsValid)
            {
                _context.TbKhachHangs.Update(po);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(po);
        }
    }
}
