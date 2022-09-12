using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class TheLoaiModel
    {
        [Required]
        [MaxLength(50)]
        public string TenTheLoai { get; set; }
        public string? MaTL { get; set; }

    }
}
