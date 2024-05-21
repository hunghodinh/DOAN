using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbDvu
{
    public string IdDv { get; set; } = null!;

    public string? TenDv { get; set; }

    public int? GiaDichVu { get; set; }

    public virtual ICollection<TbHoaDon> TbHoaDons { get; set; } = new List<TbHoaDon>();
}
