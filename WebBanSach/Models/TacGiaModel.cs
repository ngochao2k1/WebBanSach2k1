using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class TacGiaModel
    {
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }
        public string? MaTacGia { get; set; }
        public int? STT { get; set; }
    }
}
