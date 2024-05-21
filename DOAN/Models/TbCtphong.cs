using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbCtphong
{
    public string IdPhong { get; set; } = null!;

    public string? TenPhong { get; set; }

    public int? GiaCt { get; set; }

    public int? SoNguoi { get; set; }

    public int? SoGiuong { get; set; }

    public string? LoaiGiuong { get; set; }

    public bool? TrangThai { get; set; }

    public string? LoaiPhong { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<TbCtphieuDangKy> TbCtphieuDangKies { get; set; } = new List<TbCtphieuDangKy>();
}
