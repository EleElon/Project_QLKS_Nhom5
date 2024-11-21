namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LoaiDichVu")]
    public partial class LoaiDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LoaiDichVu()
        {
            DichVus = new HashSet<DichVu>();
        }

        [Key]
        [StringLength(100)]
        public string MaLoaiDichVu { get; set; }

        [Required]
        [StringLength(50)]
        public string TenLoaiDichVu { get; set; }

        [Required]
        [StringLength(100)]
        public string MaLoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DichVu> DichVus { get; set; }

        public virtual LoaiPhong LoaiPhong { get; set; }
    }
}
