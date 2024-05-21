using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbCtphieuDangKy
{
    public int IdCtpdk { get; set; }

    public string? IdKh { get; set; }

    public string? IdPhong { get; set; }

    public int? SoNguoiLon { get; set; }

    public int? SoTreEm { get; set; }

    public DateTime? NgayDen { get; set; }

    public DateTime? NgayDi { get; set; }

    public int? TongNgayO { get; set; }

    public virtual TbKhachHang? IdKhNavigation { get; set; }

    public virtual TbCtphong? IdPhongNavigation { get; set; }
}
