using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbChucVu
{
    public string IdCv { get; set; } = null!;

    public string? TenCv { get; set; }

    public virtual ICollection<TbNhanVien> TbNhanViens { get; set; } = new List<TbNhanVien>();
}
