using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyKhachSan.Reporting
{
    public partial class HoaDonContext : DbContext
    {
        public HoaDonContext()
            : base("name=HoaDonContext1")
        {
        }

        public virtual DbSet<HoaDonCT> ChiTietHoaDons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
