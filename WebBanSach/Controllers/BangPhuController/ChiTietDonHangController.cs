using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebBanSach.Data;
using WebBanSach.Models;

namespace WebBanSach.Controllers.BangPhuController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietDonHangController : ControllerBase
    {
        private readonly MyDbContext _context;
        public ChiTietDonHangController(MyDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            var lst = _context.chiTietDonHangs.ToList();
            if (lst == null) return NotFound();
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult CreateNewCTHD(ChiTietDonHangModel chiTietDonHangModel)
        {
            try
            {
                var s = _context.saches.FirstOrDefault(s => s.Id == chiTietDonHangModel.IdSach);
                if (s == null) return NotFound();
                int tt = s.donGia * chiTietDonHangModel.SoLuongMua;
                var ctdh = new ChiTietDonHang
                {
                    IdSach = chiTietDonHangModel.IdSach,
                    IdDonHang = chiTietDonHangModel.IdDonHang,
                    DonGia = s.donGia,
                    SoLuongMua = chiTietDonHangModel.SoLuongMua,
                    ThanhTien = tt
                };
                _context.Add(ctdh);
                _context.SaveChanges();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut]
        // Chi update so luong mua
        public IActionResult UpdateById(Guid idSach, int idDonHang, int SoLuongMua)
        {
            try
            {
                var ctdh = (from d in _context.chiTietDonHangs
                            where d.IdSach == idSach && d.IdDonHang == idDonHang
                            select d).FirstOrDefault();
                if (ctdh == null) return NotFound();
                else
                {
                    ctdh.SoLuongMua = SoLuongMua;
                    _context.SaveChanges();
                    return Ok(ctdh);
                }
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public IActionResult DeleteByID (Guid idSach, int idDonHang)
        {
            try
            {
                var ctdh = (from d in _context.chiTietDonHangs
                            where d.IdSach == idSach && d.IdDonHang == idDonHang
                            select d).FirstOrDefault();
                if (ctdh == null) return NotFound();
                _context.Remove(ctdh);
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
