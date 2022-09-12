using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("ChiTietDonHang")]
    public class ChiTietDonHang
    {
        public Guid IdSach { get; set; }
        public int IdDonHang { get; set; }
        public int SoLuongMua { get; set; }
        public int DonGia { get; set; }
        public int ThanhTien { get; set; }
        public Sach Sach { get; set; }
        public DonHang? DonHang { get; set; }
    }
}
