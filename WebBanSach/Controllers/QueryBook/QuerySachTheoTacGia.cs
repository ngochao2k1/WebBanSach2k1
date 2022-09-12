using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;

namespace WebBanSach.Controllers.QueryBook
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerySachTheoTacGia : ControllerBase
    {
        private readonly MyDbContext _context;
        public QuerySachTheoTacGia(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult get(Guid idTacGia)
        {
            var lst = from bp in _context.BP_SachTacGias
                      where bp.IdTacGia == idTacGia
                      join tg in _context.tacGias on bp.IdTacGia equals tg.Id
                      join s in _context.saches on bp.IdSach equals s.Id
                      join nxb in _context.nhaXuatBans on s.idNXB equals nxb.Id
                      join stl in _context.SachTheLoais on s.Id equals stl.IdSach
                      join tl in _context.theLoais on stl.IdTheLoai equals tl.Id
                      select new
                      {
                          s.Id,
                          s.tenSach,
                          s.soLuong,
                          s.donGia,
                          s.mota,
                          nxb.TenNXB,
                          tl.TenTheLoai,
                          tg.Name
                      };
            if (lst == null) return NotFound();
            return Ok(lst);
        }
    }
}
