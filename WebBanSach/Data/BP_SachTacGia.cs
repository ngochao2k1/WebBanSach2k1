using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("BP_SachTacGia")]
    public class BP_SachTacGia
    {
        public Guid IdSach { get; set; }
        public Guid IdTacGia { get; set; }
        public TacGia TacGia { get; set; }
        public Sach Sach { get; set; }
    }
}
