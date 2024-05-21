using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbKhachHang
{
    public string IdKh { get; set; } = null!;

    public string? TenKh { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? GioTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? SoCccd { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<TbCtphieuDangKy> TbCtphieuDangKies { get; set; } = new List<TbCtphieuDangKy>();

    public virtual ICollection<TbHoaDon> TbHoaDons { get; set; } = new List<TbHoaDon>();
}
