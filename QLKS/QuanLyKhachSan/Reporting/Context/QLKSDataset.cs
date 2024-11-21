using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyKhachSan.Reporting.Context
{
    public partial class QLKSDataset : DbContext
    {
        public QLKSDataset()
            : base("name=QLKSDataset")
        {
        }

        public virtual DbSet<ChamCong> ChamCongs { get; set; }
        public virtual DbSet<ChiTietDatPhong> ChiTietDatPhongs { get; set; }
        public virtual DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public virtual DbSet<CoSoVatChat> CoSoVatChats { get; set; }
        public virtual DbSet<DanhSachSuDungDichVu> DanhSachSuDungDichVus { get; set; }
        public virtual DbSet<DatPhong> DatPhongs { get; set; }
        public virtual DbSet<DichVu> DichVus { get; set; }
        public virtual DbSet<DoanhThu> DoanhThus { get; set; }
        public virtual DbSet<HoaDon> HoaDons { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiDichVu> LoaiDichVus { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<Luong> Luongs { get; set; }
        public virtual DbSet<NhanVien> NhanViens { get; set; }
        public virtual DbSet<Phong> Phongs { get; set; }
        public virtual DbSet<TraPhong> TraPhongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChamCong>()
                .HasMany(e => e.Luongs)
                .WithRequired(e => e.ChamCong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DatPhong>()
                .HasMany(e => e.HoaDons)
                .WithRequired(e => e.DatPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DatPhong>()
                .HasMany(e => e.TraPhongs)
                .WithRequired(e => e.DatPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiDichVu>()
                .HasMany(e => e.DichVus)
                .WithRequired(e => e.LoaiDichVu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.LoaiDichVus)
                .WithRequired(e => e.LoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LoaiPhong>()
                .HasMany(e => e.Phongs)
                .WithRequired(e => e.LoaiPhong)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.ChamCongs)
                .WithRequired(e => e.NhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Luongs)
                .WithRequired(e => e.NhanVien)
                .HasForeignKey(e => e.MaNhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.Luongs1)
                .WithRequired(e => e.NhanVien1)
                .HasForeignKey(e => e.MaNhanVien)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Phong>()
                .HasMany(e => e.CoSoVatChats)
                .WithRequired(e => e.Phong)
                .WillCascadeOnDelete(false);
        }
    }
}
