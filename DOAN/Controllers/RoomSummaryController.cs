using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DOAN.Models;

namespace DOAN.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoomSummaryController : ControllerBase
	{
		private readonly QlksContext _context;

		public RoomSummaryController(QlksContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetRoomSummary()
		{
			var totalBookings = await _context.TbCtphongs.SelectMany(p => p.TbCtphieuDangKies).CountAsync();
			var availableRooms = await _context.TbCtphongs.CountAsync(p => p.TrangThai == false);

			var summary = new RoomSummaryDto
			{
				TotalBookings = totalBookings,
				AvailableRooms = availableRooms
			};

			return Ok(summary);
		}
	}

	public class RoomSummaryDto
	{
		public int TotalBookings { get; set; }
		public int AvailableRooms { get; set; }
	}
}
