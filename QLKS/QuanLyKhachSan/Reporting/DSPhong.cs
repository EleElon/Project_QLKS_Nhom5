namespace QuanLyKhachSan.Reporting
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phong")]
    public partial class DSPhong
    {
        [Key]
        [StringLength(100)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(100)]
        public string MaLoaiPhong { get; set; }

        [Required]
        [StringLength(10)]
        public string SoPhong { get; set; }

        [StringLength(20)]
        public string TinhTrang { get; set; }
    }
}
