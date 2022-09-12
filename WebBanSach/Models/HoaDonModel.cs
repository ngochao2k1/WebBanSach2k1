using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class HoaDonModel
    {
        [Required]
        public int IdDonHang { get; set; }
        [Required]
        public float VAT { get; set; }
    }
}
