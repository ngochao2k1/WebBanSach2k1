using Microsoft.EntityFrameworkCore;

namespace WebBanSach.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }
        #region DbSet
        public DbSet<NhaXuatBan> nhaXuatBans { get; set; }
        public DbSet<Sach> saches { get; set; }
        public DbSet<SachTheLoai> SachTheLoais { get; set; }
        public DbSet<TheLoai> theLoais { get; set; }
        public DbSet<TacGia> tacGias { get; set; }
        public DbSet<BP_SachTacGia> BP_SachTacGias { get; set; }
        public DbSet<ChiTietDonHang> chiTietDonHangs { get; set; }
        public DbSet<DonHang> donHangs { get; set; }
        public DbSet<HoaDon> hoaDons { get; set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhaXuatBan>(entity =>
            {
                entity.ToTable("NhaXuatBan");
                entity.HasKey(x => x.Id);

            });
            modelBuilder.Entity<Sach>(entity =>
            {
                entity.HasOne(e => e.NhaXuatBan)
                        .WithMany(e => e.saches)
                        .HasForeignKey(e => e.idNXB)
                        .HasConstraintName("FK_SACH_NXB");
            });
            modelBuilder.Entity<SachTheLoai>(entity =>
            {
                entity.HasKey(e => new { e.IdSach, e.IdTheLoai });

                entity.HasOne(e => e.sach)
                        .WithMany(e => e.sachTheLoais)
                        .HasForeignKey(e => e.IdSach)
                        .HasConstraintName("FK_Sach_TL");

                entity.HasOne(e => e.theLoai)
                    .WithMany(e => e.sachTheLoais)
                    .HasForeignKey(e => e.IdTheLoai)
                    .HasConstraintName("FK_TheLoai_Sach");
            });
            modelBuilder.Entity<BP_SachTacGia>(entity =>
            {
                entity.HasKey(e => new { e.IdSach, e.IdTacGia });

                entity.HasOne(e => e.Sach)
                    .WithMany(e => e.bP_SachTacGias)
                    .HasForeignKey(e => e.IdSach)
                    .HasConstraintName("FK_SACH_TG1");

                entity.HasOne(e => e.TacGia)
                .WithMany(e => e.bP_SachTacGias)
                .HasForeignKey(e => e.IdTacGia)
                .HasConstraintName("FK_SACH_TG2");
            });
            modelBuilder.Entity<ChiTietDonHang>(entity =>
            {
                entity.HasKey(k => new { k.IdSach, k.IdDonHang });

                entity.HasOne(e => e.Sach)
                    .WithMany(e => e.chiTietDonHangs)
                    .HasForeignKey(e => e.IdSach)
                    .HasConstraintName("FK_ChiTietDonHang1");

                entity.HasOne(e => e.DonHang)
                    .WithMany(e => e.chiTietDonHangs)
                    .HasForeignKey(e => e.IdDonHang)
                    .HasConstraintName("FK_ChiTietDonHang2");
            });
            modelBuilder.Entity<DonHang>(entity =>
            {
                entity.HasOne(e => e.HoaDon)
                        .WithOne(e=>e.DonHang)
                        .HasForeignKey<HoaDon>(e=> e.IdDonHang);
            });
        }
    }
}
