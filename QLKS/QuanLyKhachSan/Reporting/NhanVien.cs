namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            ChamCongs = new HashSet<ChamCong>();
            Luongs = new HashSet<Luong>();
            Luongs1 = new HashSet<Luong>();
        }

        [Key]
        [StringLength(100)]
        public string MaNhanVien { get; set; }

        [StringLength(100)]
        public string MaPhong { get; set; }

        [Required]
        [StringLength(100)]
        public string TenNhanVien { get; set; }

        [Required]
        [StringLength(10)]
        public string gioiTinh { get; set; }

        [Column(TypeName = "date")]
        public DateTime ngaySinh { get; set; }

        [Required]
        [StringLength(20)]
        public string SDT { get; set; }

        [Required]
        [StringLength(50)]
        public string ChucVu { get; set; }

        [Required]
        [StringLength(200)]
        public string diaChi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChamCong> ChamCongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luong> Luongs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Luong> Luongs1 { get; set; }

        public virtual Phong Phong { get; set; }
    }
}
