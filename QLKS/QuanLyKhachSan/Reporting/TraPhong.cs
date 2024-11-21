namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TraPhong")]
    public partial class TraPhong
    {
        [Key]
        [StringLength(100)]
        public string MaTraPhong { get; set; }

        [Required]
        [StringLength(100)]
        public string MaDatPhong { get; set; }

        [Column(TypeName = "date")]
        public DateTime NgayTra { get; set; }

        public double TienDatCoc { get; set; }

        public virtual DatPhong DatPhong { get; set; }
    }
}
