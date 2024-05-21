using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbHoaDon
{
    public string IdHd { get; set; } = null!;

    public string? IdKh { get; set; }

    public string? IdDv { get; set; }

    public DateTime? NgayLap { get; set; }

    public int? TongTien { get; set; }

    public string? GhiChu { get; set; }

    public virtual TbDvu? IdDvNavigation { get; set; }

    public virtual TbKhachHang? IdKhNavigation { get; set; }

    public virtual ICollection<TbCthoaDon> TbCthoaDons { get; set; } = new List<TbCthoaDon>();
}
