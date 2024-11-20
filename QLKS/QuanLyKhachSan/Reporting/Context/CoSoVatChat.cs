namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CoSoVatChat")]
    public partial class CoSoVatChat
    {
        [Required]
        [StringLength(100)]
        public string MaPhong { get; set; }

        [Key]
        [StringLength(100)]
        public string MaCoSoVatChat { get; set; }

        [Required]
        [StringLength(100)]
        public string TenCoSoVatChat { get; set; }

        [Required]
        [StringLength(200)]
        public string MoTa { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
