using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers.BangPhuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class SachTheLoaiController : ControllerBase
    {
        private readonly MyDbContext _context;
        public SachTheLoaiController(MyDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult createNewSachTl(SachTheLoaiModel sachTheLoaiModel)
        {
            try
            {
                var sachTl = new SachTheLoai
                {
                    IdSach = sachTheLoaiModel.IdSach,
                    IdTheLoai = sachTheLoaiModel.IdTheLoai
                };
                _context.Add(sachTl);
                _context.SaveChanges();
                return Ok(sachTl);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var list = _context.SachTheLoais.ToList();
            if (list == null) return NotFound();
            return Ok(list);
        }
    }
}
