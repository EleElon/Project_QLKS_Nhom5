namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDatPhong")]
    public partial class ChiTietDatPhong
    {
        [Key]
        [StringLength(100)]
        public string MaChiTietDatPhong { get; set; }

        [StringLength(100)]
        public string MaDatPhong { get; set; }

        [StringLength(100)]
        public string MaKhachHang { get; set; }

        [StringLength(100)]
        public string MaPhong { get; set; }

        [StringLength(100)]
        public string MaLoaiPhong { get; set; }

        [StringLength(50)]
        public string TinhTrang { get; set; }

        public double? GiaMoiDem { get; set; }

        public int? SoLuongPhong { get; set; }

        public double? TongGia { get; set; }

        [StringLength(100)]
        public string PhuongThucThanhToan { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayNhanPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayTraPhong { get; set; }

        public virtual DatPhong DatPhong { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
