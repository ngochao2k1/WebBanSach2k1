using System.ComponentModel.DataAnnotations;

namespace WebBanSach.Models
{
    public class SachModel
    {
        [Required]
        [MaxLength(100)]
        public String tenSach { get; set; }
        public int soLuong { get; set; }
        public string? mota { get; set; }
        public int donGia { get; set; }

        //relation
        public Guid? idNXB { get; set; }
    }
}
