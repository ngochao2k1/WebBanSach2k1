using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonHangController : ControllerBase
    {
        private readonly MyDbContext _context;
        public DonHangController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var lst = _context.donHangs.ToList();
            if (lst == null) return NotFound();
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult CreateNEwDh(DonHangModel donHangModel)
        {
            try
            {
                var createNew = new DonHang
                {
                    NgayBan = DateTime.Today
                };
                _context.Add(createNew);
                _context.SaveChanges();
                return Ok(createNew);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteById(int id)
        {
            try
            {
                var dh = _context.donHangs.FirstOrDefault(d => d.Id == id);
                if (dh == null) return NotFound();
                _context.donHangs.Remove(dh);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
        /*
        [HttpPut]
        public IActionResult UpdateById(int id)
        {
            var dh = _context.donHangs.FirstOrDefault(d => d.Id == id);
            if (dh == null) return NotFound();
            else
            {
                
                //_context.SaveChanges();
                return Ok(dh);
            }
        }*/
    }
}
