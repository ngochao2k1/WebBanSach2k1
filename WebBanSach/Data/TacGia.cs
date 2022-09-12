using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("TacGia")]
    public class TacGia
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }
        public string? MaTacGia { get; set; }
        public int? STT { get; set; }
        public ICollection<BP_SachTacGia> bP_SachTacGias { get; set; }
    }
}
