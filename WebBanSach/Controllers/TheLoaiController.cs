using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TheLoaiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public TheLoaiController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAllTheLoai()
        {
            var list = _context.theLoais.ToList();
            if (list.Count == 0)
            {
                return NotFound();
            }
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var TheLoai = _context.theLoais.FirstOrDefault(x => x.Id == id);
            if (TheLoai == null) return NotFound();
            return Ok(TheLoai);
        }

        [HttpPost]
        public IActionResult CreateNewTheLoai(TheLoaiModel theLoaiModel)
        {
            try
            {
                var newTheLoai = new TheLoai
                {
                    Id = Guid.NewGuid(),
                    TenTheLoai = theLoaiModel.TenTheLoai,
                    MaTL = theLoaiModel.MaTL
                };
                _context.theLoais.Add(newTheLoai);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPut]
        public IActionResult UpdateTheLoaiById(Guid id, TheLoai theLoai)
        {
            var TheLoai = _context.theLoais.FirstOrDefault(e => e.Id == id);
            if (TheLoai == null) return NotFound();
            else
            {
                TheLoai.TenTheLoai = theLoai.TenTheLoai;
                TheLoai.MaTL = theLoai.MaTL;
                _context.SaveChanges();
                return Ok(TheLoai);
            }
        }
        [HttpDelete]
        public IActionResult DeletebyId(Guid id)
        {
            var TheLoai = _context.theLoais.FirstOrDefault(e => e.Id == id);
            if (TheLoai == null) return NotFound();
            else
            {
                _context.theLoais.Remove(TheLoai);
                _context.SaveChanges();
                return Ok();
            }
        }
    }
}
