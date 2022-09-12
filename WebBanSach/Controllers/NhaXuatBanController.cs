using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhaXuatBanController : ControllerBase
    {
        private readonly MyDbContext _context;
        public NhaXuatBanController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var list = _context.nhaXuatBans.ToList();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult getNXBByID(Guid id)
        {
            var NXB = _context.nhaXuatBans.FirstOrDefault(nxb => nxb.Id == id);
            if (NXB == null)
            {
                return NotFound();
            }
            return Ok(NXB);
        }
        [HttpGet("IdNXB")]
        public IActionResult getSachByIDNXB(Guid id)
        {
            var list_Sach = from s in _context.saches
                            join nxb in _context.nhaXuatBans on s.idNXB equals nxb.Id
                            select s;
            if (list_Sach == null) return NotFound();
            else return Ok(list_Sach);
        }
        [HttpPost]
        public IActionResult createNew(NhaXuatBanModel model)
        {
            try
            {
                var NXB = new NhaXuatBan
                {
                    Id = Guid.NewGuid(),
                    TenNXB = model.TenNXB,
                    MaNXB = model.MaNXB
                };
                _context.Add(NXB);
                _context.SaveChanges();
                return Ok(NXB);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateNXBByID(Guid id, NhaXuatBanModel nhaXuatBanModel)
        {
            var NXB = _context.nhaXuatBans.FirstOrDefault(nxb => nxb.Id == id);
            if (NXB != null)
            {
                NXB.TenNXB = nhaXuatBanModel.TenNXB;
                NXB.MaNXB = nhaXuatBanModel.MaNXB;
                _context.SaveChanges();
                return Ok(NXB);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteNXB(Guid id)
        {
            try
            {
                var nxb = _context.nhaXuatBans.FirstOrDefault(n => n.Id == id);
                if (nxb == null) return NotFound();
                else
                {
                    _context.Remove(nxb);
                    _context.SaveChanges();
                    return Ok();
                }
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
