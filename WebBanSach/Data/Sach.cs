using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("Sach")]
    public class Sach
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public String tenSach { get; set; }
        public int soLuong { get; set; }
        public string? mota { get; set; }
        public int donGia { get; set; }

        //relation
        public Guid? idNXB { get; set; }
        public NhaXuatBan? NhaXuatBan { get; set; }

        public ICollection<SachTheLoai> sachTheLoais { get; set; }
        public ICollection<BP_SachTacGia> bP_SachTacGias { get; set; }
        public ICollection<ChiTietDonHang>? chiTietDonHangs { get; set; }
    }
}
