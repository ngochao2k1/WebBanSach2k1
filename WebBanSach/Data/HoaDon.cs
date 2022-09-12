using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Data
{
    public class HoaDon
    {
        [Key]
        public int IDHoaDon { get; set; }
        [Required]
        public int TongTientrcVAT { get; set; }
        [Required]
        public float VAT { get; set; }
        [Required]
        public float TongTien { get; set; }
        public int IdDonHang { get; set; }
        public virtual DonHang DonHang { get; set; }    
    }
}
