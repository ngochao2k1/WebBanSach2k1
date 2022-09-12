using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class NhaXuatBanModel
    {
        [Required]
        [MaxLength(100)]
        public string TenNXB { get; set; }
        public string? MaNXB { get; set; }
    }
}
