using Microsoft.Reporting.WinForms;
using QuanLyKhachSan.Reporting.Context;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Forms;

namespace QuanLyKhachSan.Reporting
{
    public partial class frmRptLuong : Form
    {
        public frmRptLuong()
        {
            InitializeComponent();
        }

        private void frmRptLuong_Load(object sender, EventArgs e)
        {
            // Lấy kích thước màn hình hiện tại
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            // Tính kích thước form (70% màn hình)
            int formWidth = (int)(screenWidth * 0.7);
            int formHeight = (int)(screenHeight * 0.7);

            // Thiết lập kích thước form
            this.Size = new Size(formWidth, formHeight);

            // Tính toán vị trí trung tâm
            int positionX = (screenWidth - formWidth) / 2;
            int positionY = (screenHeight - formHeight) / 2;

            // Đặt vị trí form
            this.StartPosition = FormStartPosition.Manual; // Phải đặt thủ công vị trí
            this.Location = new Point(positionX, positionY);

            // Tùy chọn thêm: Đặt chế độ không thể thay đổi kích thước nếu cần
            this.FormBorderStyle = FormBorderStyle.FixedDialog; // Không thể thay đổi kích thước
            this.MaximizeBox = false; // Tắt nút maximize
            this.MinimizeBox = true; // Cho phép minimize

            //QLKSContext context = new QLKSContext();
            //List<Luong> list = context.Luongs.ToList();
            //List<luongReport> listrpt = new List<luongReport>();
            //foreach (Luong l in list)
            //{
            //    luongReport temp = new luongReport();
            //    temp.maLuong = l.MaLuong;
            //    temp.tenNV = l.MaNhanVien;
            //    temp.soNgayLam = (int)l.SoNgayLamViec;
            //    temp.soGioTangCa = (float)l.SoGioTangCa;
            //    temp.tongLuong = (float)l.TongLuong;
            //    temp.ngayTinh = (DateTime)l.NgayTinhLuong;

            //    listrpt.Add(temp);
            //}

            //rptViewLuong.LocalReport.ReportPath = "rptLuong.rdlc";
            //var source = new ReportDataSource("DataSet1", listrpt);
            //rptViewLuong.LocalReport.DataSources.Clear();
            //rptViewLuong.LocalReport.DataSources.Add(source);

            //this.rptViewLuong.RefreshReport();

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

            this.rptViewLuong.RefreshReport();
        }
    }
}
