using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachController : ControllerBase
    {
        private readonly MyDbContext _context;
        public SachController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAllSach()
        {
            var Lst_sach = _context.saches.ToList();
            if (Lst_sach == null)
            {
                return NotFound();
            }
            return Ok(Lst_sach);
        }
        [HttpGet("{id}")]
        public IActionResult getSachById(Guid id)
        {
            try
            {
                var Sach = from s in _context.saches
                           where s.Id == id
                           join nxb in _context.nhaXuatBans on s.idNXB equals nxb.Id
                           join stg in _context.BP_SachTacGias on s.Id equals stg.IdSach
                           join tg in _context.tacGias on stg.IdTacGia equals tg.Id
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
                return Ok(Sach);
            }
            catch
            {
                return NotFound();
            }
        }
        [HttpPost]
        public IActionResult CreatNewSach(SachModel sach)
        {
            try
            {
                var newSach = new Sach
                {
                    Id = Guid.NewGuid(),
                    tenSach = sach.tenSach,
                    soLuong = sach.soLuong,
                    donGia = sach.donGia,
                    mota = sach.mota,
                    idNXB = sach.idNXB
                };
                _context.Add(newSach);
                _context.SaveChanges();
                return Ok(newSach);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdatebyId(Guid id, SachModel sachModel)
        {
            try
            {
                var sach = _context.saches.FirstOrDefault(s => s.Id == id);
                if (sach == null) return NotFound();
                else
                {
                    sach.tenSach = sachModel.tenSach;
                    sach.idNXB = sachModel.idNXB;
                    sach.donGia = sachModel.donGia;
                    sach.soLuong = sachModel.soLuong;
                    sach.mota = sachModel.mota;
                    _context.SaveChanges();
                    return Ok(sach);
                }
            }
            catch
            {
                return BadRequest();
            }
          }
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            try
            {
                var s = _context.saches.FirstOrDefault(e => e.Id == Id);
                if (s == null) return NotFound();
                _context.Remove(s);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
