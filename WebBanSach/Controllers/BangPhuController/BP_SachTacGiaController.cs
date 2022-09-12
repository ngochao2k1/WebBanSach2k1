using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers.BangPhuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BP_SachTacGiaController : ControllerBase
    {
        private readonly MyDbContext _context;
        public BP_SachTacGiaController(MyDbContext myDbContext)
        {
            _context = myDbContext;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var lst = _context.BP_SachTacGias.ToList();
            if (lst == null) return NotFound();
            else
            {
                return Ok(lst);
            }
        }
        [HttpPost]
        public IActionResult CreateNew(BP_SachTacGiaModel bP_SachTacGiaModel)
        {
            try
            {
                var newSachTg = new BP_SachTacGia
                {
                    IdSach = bP_SachTacGiaModel.IdSach,
                    IdTacGia = bP_SachTacGiaModel.IdTacGia
                };
                _context.BP_SachTacGias.Add(newSachTg);
                _context.SaveChanges();
                return Ok(newSachTg);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateSachTg(Guid id, BP_SachTacGiaModel bP_SachTacGiaModel)
        {
            var x = _context.BP_SachTacGias.FirstOrDefault(t => t.IdSach == id);
            if (x == null) return NotFound();
            else
            {
                x.IdSach = bP_SachTacGiaModel.IdSach;
                x.IdTacGia = bP_SachTacGiaModel.IdTacGia;
                _context.SaveChanges();
                return Ok(x);
            };
        }
        [HttpDelete]
        public IActionResult DeleteById(Guid Id)
        {
            var x = _context.BP_SachTacGias.FirstOrDefault(t => t.IdSach == Id);
            if (x == null) return NotFound();
            else
            {
                _context.Remove(x);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
