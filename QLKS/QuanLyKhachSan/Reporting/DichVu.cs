namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DichVu")]
    public partial class DichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DichVu()
        {
            DanhSachSuDungDichVus = new HashSet<DanhSachSuDungDichVu>();
        }

        [Key]
        [StringLength(100)]
        public string MaDichVu { get; set; }

        [Required]
        [StringLength(100)]
        public string MaLoaiDichVu { get; set; }

        [Required]
        [StringLength(100)]
        public string TenDichVu { get; set; }

        public double Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhSachSuDungDichVu> DanhSachSuDungDichVus { get; set; }

        public virtual LoaiDichVu LoaiDichVu { get; set; }
    }
}
