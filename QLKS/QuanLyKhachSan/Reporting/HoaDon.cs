namespace QuanLyKhachSan.Reporting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDon")]
    public partial class HoaDon
    {
        [Key]
        [StringLength(100)]
        public string MaHoaDon { get; set; }

        [Required]
        [StringLength(100)]
        public string MaDatPhong { get; set; }

        public double TongTien { get; set; }

        [Required]
        [StringLength(50)]
        public string TinhTrangThanhToan { get; set; }
    }
}
