using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly MyDbContext _context;
        public HoaDonController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var hd = _context.hoaDons.ToList();
            if (hd == null) return NotFound();
            return Ok(hd);
        }
        [HttpGet("{idDonHang}")]
        public IActionResult getByID(int id)
        {
            var Hd = (from hd in _context.hoaDons
                      where hd.IdDonHang == id
                      select hd).FirstOrDefault();
            if(Hd == null) return NotFound();
            return Ok(Hd);                 
        }
        [HttpPut]
        public IActionResult UpdateVAT(int idDonHang, float VAT)
        {
            var Hd = _context.hoaDons.FirstOrDefault(e => e.IdDonHang == idDonHang);
            if(Hd == null) return NotFound();
            else
            {
                Hd.VAT = VAT;
                _context.SaveChanges();
                return Ok();
            }
        }
        [HttpPost]
        public IActionResult CreatNew(HoaDonModel hoaDonModel)
        {
            try
            {
                int tt = _context.chiTietDonHangs.Sum(s => s.IdDonHang == hoaDonModel.IdDonHang ? s.ThanhTien : 0);
                var hd = new HoaDon
                {
                    IdDonHang = hoaDonModel.IdDonHang,
                    VAT = hoaDonModel.VAT,
                    TongTientrcVAT = tt,
                    TongTien = tt * hoaDonModel.VAT + tt
                };
                _context.Add(hd);
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
