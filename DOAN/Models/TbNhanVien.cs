using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbNhanVien
{
    public string IdNv { get; set; } = null!;

    public string? IdCv { get; set; }

    public string? TenNv { get; set; }

    public DateTime? NgaySinh { get; set; }

    public string? GioiTinh { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public virtual TbChucVu? IdCvNavigation { get; set; }
}
