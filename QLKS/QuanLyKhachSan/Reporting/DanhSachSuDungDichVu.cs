namespace QuanLyKhachSan.Reporting.Context
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhSachSuDungDichVu")]
    public partial class DanhSachSuDungDichVu
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DanhSachSuDungDichVu()
        {
            ChiTietHoaDons = new HashSet<ChiTietHoaDon>();
        }

        [Key]
        [StringLength(100)]
        public string MaSuDungDichVu { get; set; }

        [StringLength(100)]
        public string MaDichVu { get; set; }

        [StringLength(100)]
        public string MaDatPhong { get; set; }

        public int? SoLuong { get; set; }

        public double? Gia { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; }

        public virtual DatPhong DatPhong { get; set; }

        public virtual DichVu DichVu { get; set; }
    }
}
