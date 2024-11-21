namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DoanhThu")]
    public partial class DoanhThu
    {
        [Key]
        [StringLength(100)]
        public string MaDoanhThu { get; set; }

        [Column(TypeName = "date")]
        public DateTime Ngay { get; set; }

        public double SoTien { get; set; }
    }
}
