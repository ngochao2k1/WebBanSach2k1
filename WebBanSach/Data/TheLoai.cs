using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("TheLoai")]
    public class TheLoai
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string TenTheLoai { get; set; }
        public string? MaTL { get; set; }

        //relation
        public ICollection<SachTheLoai> sachTheLoais { get; set; }
    }
}
