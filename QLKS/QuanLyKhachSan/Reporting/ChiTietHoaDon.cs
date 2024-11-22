namespace QuanLyKhachSan.Reporting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHoaDon")]
    public partial class ChiTietHoaDon
    {
        [Key]
        [StringLength(100)]
        public string MaHoaDon { get; set; }

        [Required]
        [StringLength(100)]
        public string MaDatPhong { get; set; }

        [StringLength(100)]
        public string MaSuDungDichVu { get; set; }

        public double? PhuThu { get; set; }

        public double? TienPhong { get; set; }

        public double? TienDichVu { get; set; }

        public double? GiamGiaKH { get; set; }

        [StringLength(100)]
        public string HinhThucThanhToan { get; set; }

        public double? SoNgay { get; set; }

        public double? ThanhTien { get; set; }
    }
}
