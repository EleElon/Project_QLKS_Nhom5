namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChamCong")]
    public partial class ChamCong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChamCong()
        {
            Luongs = new HashSet<Luong>();
        }

        [Key]
        [StringLength(100)]
        public string MaChamCong { get; set; }

        [Required]
        [StringLength(100)]
        public string TenBangChamCong { get; set; }

        [Required]
        [StringLength(100)]
        public string MaNhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string Thang { get; set; }

        public int Nam { get; set; }

        public int? SoNgayLamViec { get; set; }

        public double? SoGioTangCa { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayChamCong { get; set; }

        [StringLength(200)]
        public string GhiChu { get; set; }

        public virtual NhanVien NhanVien { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luong> Luongs { get; set; }
    }
}
