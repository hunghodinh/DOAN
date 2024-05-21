using System;
using System.Collections.Generic;

namespace DOAN.Models;

public partial class TbCthoaDon
{
    public int IdCthd { get; set; }

    public string? IdHd { get; set; }

    public int? TienPhong { get; set; }

    public int? TienDv { get; set; }

    public int? ThanhTien { get; set; }

    public virtual TbHoaDon? IdHdNavigation { get; set; }
}
