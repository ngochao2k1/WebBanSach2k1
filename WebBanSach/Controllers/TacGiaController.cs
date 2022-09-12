using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TacGiaController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TacGiaController(MyDbContext _context)
        {
            this._context = _context;
        }
        [HttpGet]
        public IActionResult getAllTacGia()
        {
            var list = _context.tacGias.ToList();
            if (list == null) return NotFound();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult getTacGiaById(Guid id)
        {
            var tacgia = _context.tacGias.FirstOrDefault(t => t.Id == id);
            if (tacgia == null) return NotFound();
            return Ok(tacgia);
        }
        [HttpPost]
        public IActionResult CreateNewTacGia(TacGiaModel tacGia)
        {
            try
            {
                var newTG = new TacGia
                {
                    Id = Guid.NewGuid(),
                    Name = tacGia.Name,
                    MaTacGia = tacGia.MaTacGia,
                    STT = tacGia.STT
                };
                _context.tacGias.Add(newTG);
                _context.SaveChanges();
                return Ok(newTG);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateTGById(Guid Id, TacGiaModel tacGia)
        {
            var tg = _context.tacGias.FirstOrDefault(t => t.Id == Id);
            if (tg == null) return NotFound();
            else
            {
                tg.Name = tacGia.Name;
                tg.MaTacGia = tacGia.MaTacGia;
                tg.STT = tacGia.STT;
                _context.SaveChanges();
                return Ok(tg);
            }
        }
        [HttpDelete]
        public IActionResult DeleteTgById(Guid Id)
        {
            try
            {
                var tg = _context.tacGias.FirstOrDefault(t => t.Id == Id);
                if (tg == null) return NotFound();
                _context.Remove(tg);
                _context.SaveChanges();
                return Ok(tg);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
