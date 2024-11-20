using Microsoft.Reporting.WinForms;
using QuanLyKhachSan.Reporting.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan.Reporting
{
    public partial class frmRptDichVu : Form
    {
        public frmRptDichVu()
        {
            InitializeComponent();
        }

        private void frmRptDichVu_Load(object sender, EventArgs e)
        {
            QLKSContext context = new QLKSContext();

            // Lấy dữ liệu từ Luong và NhanVien, liên kết hai bảng
            var query = from l in context.Luongs
                        join nv in context.NhanViens on l.MaNhanVien equals nv.MaNhanVien
                        select new
                        {
                            l.MaLuong,
                            TenNhanVien = nv.TenNhanVien, // Lấy tên nhân viên
                            l.SoNgayLamViec,
                            l.SoGioTangCa,
                            l.TongLuong,
                            l.NgayTinhLuong
                        };

            List<luongReport> listrpt = new List<luongReport>();
            foreach (var item in query.ToList())
            {
                luongReport temp = new luongReport
                {
                    maLuong = item.MaLuong,
                    tenNV = item.TenNhanVien, // Gán tên nhân viên
                    soNgayLam = (int)item.SoNgayLamViec,
                    soGioTangCa = (float)item.SoGioTangCa,
                    tongLuong = (float)item.TongLuong,
                    ngayTinh = (DateTime)item.NgayTinhLuong
                };

                listrpt.Add(temp);
            }

            rptViewLuong.LocalReport.ReportPath = "rptLuong.rdlc";
            var source = new ReportDataSource("DataSet1", listrpt);
            rptViewLuong.LocalReport.DataSources.Clear();
            rptViewLuong.LocalReport.DataSources.Add(source);

            this.rptViewDichVu.RefreshReport();
        }
    }
}
