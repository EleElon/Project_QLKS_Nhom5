using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QuanLyKhachSan.Reporting
{
    public partial class PhongConText : DbContext
    {
        public PhongConText()
            : base("name=PhongConText")
        {
        }

        public virtual DbSet<DSPhong> Phongs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
