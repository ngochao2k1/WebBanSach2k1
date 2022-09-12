using System.ComponentModel.DataAnnotations.Schema;

namespace WebBanSach.Data
{
    [Table("BP_SachTheLoai")]
    public class SachTheLoai
    {
        public Guid IdSach { get; set; }
        public Guid IdTheLoai { get; set; }

        public Sach sach { get; set; }
        public TheLoai theLoai { get; set; }
    }
}
