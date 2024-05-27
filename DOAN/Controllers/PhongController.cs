using DOAN.Models;
using DOAN.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace DOAN.Controllers
{
    public class PhongController : Controller
    {
        private readonly QlksContext _context;

        public PhongController(QlksContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (!Functions.IsLogin())
                return RedirectToAction("Index", "DangNhap");
            var mn = _context.TbCtphongs.OrderBy(m => m.IdPhong).ToList();
            return View(mn);
        }

        public IActionResult ChiTiet(string idPhong)
        {
            var phieuDangKies = _context.TbCtphieuDangKies
                .Where(p => p.IdPhong == idPhong)
                .OrderBy(p => p.IdCtpdk)
                .ToList();

            if (!phieuDangKies.Any())
            {
                return NotFound();
            }

            ViewBag.Phong = _context.TbCtphongs.FirstOrDefault(p => p.IdPhong == idPhong);

            return View(phieuDangKies);
        }
        public IActionResult CreatePDK(string idPhong)
        {
            if (string.IsNullOrEmpty(idPhong))
            {
                return NotFound();
            }

            // Lấy thông tin phòng từ cơ sở dữ liệu
            var phong = _context.TbCtphongs.FirstOrDefault(p => p.IdPhong == idPhong);
            if (phong == null)
            {
                return NotFound();
            }

            // Khởi tạo một đối tượng TbCtphieuDangKy với IdPhong đã được thiết lập
            var newPhieuDangKy = new TbCtphieuDangKy
            {
                IdPhong = idPhong
            };

            // Truyền thông tin phòng vào ViewBag
            ViewBag.TrangThaiPhong = phong.TrangThai;

            return View(newPhieuDangKy);
        }
        [HttpPost]
        public IActionResult CreatePDK(TbCtphieuDangKy phieuDangKy, bool TrangThai)
        {
            if (ModelState.IsValid)
            {
                // Lấy thông tin phòng từ cơ sở dữ liệu
                var phong = _context.TbCtphongs.FirstOrDefault(p => p.IdPhong == phieuDangKy.IdPhong);
                if (phong == null)
                {
                    return NotFound();
                }

                // Đảm bảo trạng thái của phòng là True
                phong.TrangThai = true;

                // Cập nhật lại phòng trong cơ sở dữ liệu
                _context.Update(phong);

                // Thêm phiếu đăng ký vào cơ sở dữ liệu
                _context.TbCtphieuDangKies.Add(phieuDangKy);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(phieuDangKy);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var po = _context.TbCtphieuDangKies.Find(id);
            if (po == null)
            {
                return NotFound();
            }

            var polist = _context.TbCtphieuDangKies.OrderBy(m => m.IdCtpdk).ToList();
            ViewBag.poList = polist;
            return View(po);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(TbCtphieuDangKy po)
        {
            if (ModelState.IsValid)
            {
                _context.TbCtphieuDangKies.Update(po);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(po);
        }
        public IActionResult DeletePDK(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var phieuDangKy = _context.TbCtphieuDangKies
                .FirstOrDefault(m => m.IdCtpdk == id);
            if (phieuDangKy == null)
            {
                return NotFound();
            }

            return View(phieuDangKy);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Tìm phiếu đăng ký theo id
            var phieuDangKy = _context.TbCtphieuDangKies.Find(id);
            if (phieuDangKy != null)
            {
                // Tìm phòng liên quan đến phiếu đăng ký
                var phong = _context.TbCtphongs.FirstOrDefault(p => p.IdPhong == phieuDangKy.IdPhong);
                if (phong != null)
                {
                    // Cập nhật trạng thái phòng thành false
                    phong.TrangThai = false;
                    _context.Update(phong);
                }

                // Xóa phiếu đăng ký
                _context.TbCtphieuDangKies.Remove(phieuDangKy);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
       
        public IActionResult Create()
        {
            var mn = _context.TbCtphongs.OrderBy(m => m.IdPhong).ToList();
            ViewBag.mn = mn;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TbCtphong mn)
        {
            if (ModelState.IsValid)
            {
                mn.TrangThai = false;
                // Thêm dữ liệu mới vào bảng TbKhachHang trong cơ sở dữ liệu
                _context.TbCtphongs.Add(mn);
                _context.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                return RedirectToAction("Index"); // Chuyển hướng đến trang Index sau khi thêm thành công
            }

            // Nếu ModelState không hợp lệ, trả về View với model để hiển thị lỗi
            return View(mn);
        }

    }
}
