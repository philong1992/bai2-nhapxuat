
using Microsoft.EntityFrameworkCore;
using API.Models;
namespace API.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<NhapXuat> NhapXuat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=DBNhapXuat;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NhapXuat>(entity =>
            {
                entity.HasKey(e => new { e.SoPhieu, e.MaVt });

                entity.ToTable("NhapXuat");

                entity.Property(e => e.SoPhieu)
                    .HasMaxLength(50)
                    .HasColumnName("so_phieu");

                entity.Property(e => e.MaVt)
                    .HasMaxLength(50)
                    .HasColumnName("ma_vt");

                entity.Property(e => e.Dvt)
                    .HasMaxLength(50)
                    .HasColumnName("dvt");

                entity.Property(e => e.NgayLapPhieu)
                    .HasColumnType("date")
                    .HasColumnName("ngay_lap_phieu");

                entity.Property(e => e.SlNhap).HasColumnName("sl_nhap");

                entity.Property(e => e.SlXuat).HasColumnName("sl_xuat");

                entity.Property(e => e.TenVt)
                    .HasMaxLength(50)
                    .HasColumnName("ten_vt");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
