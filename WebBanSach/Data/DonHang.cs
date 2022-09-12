using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("DonHang")]
    public class DonHang
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public DateTime NgayBan { get; set; }
        public Guid? IdKhach { get; set; }
        public ICollection<ChiTietDonHang> chiTietDonHangs { get; set; }
        public virtual HoaDon HoaDon { get; set; }
    }
}
