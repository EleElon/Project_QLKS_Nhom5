namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Luong")]
    public partial class Luong
    {
        [Key]
        [StringLength(100)]
        public string MaLuong { get; set; }

        [Required]
        [StringLength(100)]
        public string MaChamCong { get; set; }

        [Required]
        [StringLength(100)]
        public string MaNhanVien { get; set; }

        public int Thang { get; set; }

        public int Nam { get; set; }

        public int? SoNgayLamViec { get; set; }

        public double? SoGioTangCa { get; set; }

        public double? LuongCoBan { get; set; }

        public double? PhuCap { get; set; }

        public double? Thuong { get; set; }

        public double? KhauTru { get; set; }

        public double? TongLuong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTinhLuong { get; set; }

        public virtual ChamCong ChamCong { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        public virtual NhanVien NhanVien1 { get; set; }
    }
}
