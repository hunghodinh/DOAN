using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbTaiKhoan
{
    public string IdNguoiDung { get; set; } = null!;

    public string? IdNv { get; set; }

    public string? TenDangNhap { get; set; }

    public string? MatKhau { get; set; }
    public bool? TrangThai { get; set; }
}
