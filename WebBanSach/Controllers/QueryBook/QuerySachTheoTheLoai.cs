using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;

namespace WebBanSach.Controllers.QueryBook
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuerySachTheoTheLoai : ControllerBase
    {
        private readonly MyDbContext _context;
        public QuerySachTheoTheLoai(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }
        [HttpGet("{idTheLoai}")]
        public IActionResult getAllSach(Guid idTheLoai)
        {
            var list = from tl in _context.theLoais
                       where tl.Id == idTheLoai
                       join stl in _context.SachTheLoais on tl.Id equals stl.IdTheLoai
                       join s in _context.saches on stl.IdSach equals s.Id
                       join nxb in _context.nhaXuatBans on s.idNXB equals nxb.Id
                       join stg in _context.BP_SachTacGias on s.Id equals stg.IdSach
                       join tg in _context.tacGias on stg.IdTacGia equals tg.Id
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
                       }
                           ;
            if (list == null) return NotFound();
            return Ok(list);
        }
    }
}
