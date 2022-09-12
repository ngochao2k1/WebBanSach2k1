using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("NhaXuatBan")]
    public class NhaXuatBan
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenNXB { get; set; }
        public string? MaNXB { get; set; }
        public IList<Sach> saches { get; set; }
    }
}
