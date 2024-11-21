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
            //// Lấy kích thước màn hình hiện tại
            //int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            //int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;

            //// Tính kích thước form (70% màn hình)
            //int formWidth = (int)(screenWidth * 0.7);
            //int formHeight = (int)(screenHeight * 0.7);

            //// Thiết lập kích thước form
            //this.Size = new Size(formWidth, formHeight);

            //// Tính toán vị trí trung tâm
            //int positionX = (screenWidth - formWidth) / 2;
            //int positionY = (screenHeight - formHeight) / 2;

            //// Đặt vị trí form
            //this.StartPosition = FormStartPosition.Manual; // Phải đặt thủ công vị trí
            //this.Location = new Point(positionX, positionY);

            //// Tùy chọn thêm: Đặt chế độ không thể thay đổi kích thước nếu cần
            //this.FormBorderStyle = FormBorderStyle.FixedDialog; // Không thể thay đổi kích thước
            //this.MaximizeBox = false; // Tắt nút maximize
            //this.MinimizeBox = true; // Cho phép minimize

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

            //QLKSContext context = new QLKSContext();

            //// Lấy dữ liệu từ Luong và NhanVien, liên kết hai bảng
            //var query = from l in context.Luongs
            //            join nv in context.NhanViens on l.MaNhanVien equals nv.MaNhanVien
            //            select new
            //            {
            //                l.MaLuong,
            //                TenNhanVien = nv.TenNhanVien, // Lấy tên nhân viên
            //                l.SoNgayLamViec,
            //                l.SoGioTangCa,
            //                l.TongLuong,
            //                l.NgayTinhLuong
            //            };

            //List<luongReport> listrpt = new List<luongReport>();
            //foreach (var item in query.ToList())
            //{
            //    luongReport temp = new luongReport
            //    {
            //        maLuong = item.MaLuong,
            //        tenNV = item.TenNhanVien, // Gán tên nhân viên
            //        soNgayLam = (int)item.SoNgayLamViec,
            //        soGioTangCa = (float)item.SoGioTangCa,
            //        tongLuong = (float)item.TongLuong,
            //        ngayTinh = (DateTime)item.NgayTinhLuong
            //    };

            //    listrpt.Add(temp);
            //}

            //rptViewLuong.LocalReport.ReportPath = "rptLuong.rdlc";
            //var source = new ReportDataSource("DataSet1", listrpt);
            //rptViewLuong.LocalReport.DataSources.Clear();
            //rptViewLuong.LocalReport.DataSources.Add(source);

            //this.rptViewLuong.RefreshReport();

            //using (QLKSContext context = new QLKSContext())
            //{
            //    // Truy vấn dữ liệu
            //    var query = from l in context.Luongs
            //                join nv in context.NhanViens on l.MaNhanVien equals nv.MaNhanVien
            //                where soNgayLam == null || l.SoNgayLamViec == soNgayLam // Điều kiện lọc theo số ngày làm
            //                select new
            //                {
            //                    l.MaLuong,
            //                    TenNhanVien = nv.TenNhanVien,
            //                    l.SoNgayLamViec,
            //                    l.SoGioTangCa,
            //                    l.TongLuong,
            //                    l.NgayTinhLuong
            //                };

            //    // Chuyển đổi dữ liệu
            //    List<luongReport> listrpt = query.ToList().Select(item => new luongReport
            //    {
            //        maLuong = item.MaLuong,
            //        tenNV = item.TenNhanVien,
            //        soNgayLam = (int)item.SoNgayLamViec,
            //        soGioTangCa = (float)item.SoGioTangCa,
            //        tongLuong = (float)item.TongLuong,
            //        ngayTinh = (DateTime)item.NgayTinhLuong
            //    }).ToList();

            //    // Gán dữ liệu cho ReportViewer
            //    rptViewLuong.LocalReport.ReportPath = "rptLuong.rdlc";
            //    var source = new ReportDataSource("DataSet1", listrpt);
            //    rptViewLuong.LocalReport.DataSources.Clear();
            //    rptViewLuong.LocalReport.DataSources.Add(source);

            //    rptViewLuong.RefreshReport();
            //}

            SetFormSizeAndPosition();
            // Gọi phương thức thiết lập kích thước ban đầu cho ReportViewer
            AdjustReportViewerSize();

            // Gắn sự kiện Resize để tự động thay đổi kích thước ReportViewer khi form thay đổi
            this.Resize += (s, ev) => AdjustReportViewerSize();
            LoadReport(null, null, null);

            chkTheoSoNgayLam.Checked = true;

            lbLuongMin.Visible = false;
            txtLuongMin.Visible = false;

            lbLuongMax.Visible = false;
            txtLuongMax.Visible = false;

            chkTheoSoNgayLam.CheckedChanged += (s, ev) => ChonTuyChon();
            chkTheoGia.CheckedChanged += (s, ev) => ChonTuyChon();

            TheoLuongFieldsLocation();
            rptViewLuong.ZoomMode = ZoomMode.PageWidth; // Hiển thị toàn bộ chiều rộng
        }

        private void SetFormSizeAndPosition()
        {
            int screenWidth = Screen.PrimaryScreen.WorkingArea.Width;
            int screenHeight = Screen.PrimaryScreen.WorkingArea.Height;
            int formWidth = (int)(screenWidth * 0.7);
            int formHeight = (int)(screenHeight * 0.7);
            this.Size = new Size(formWidth, formHeight);
            int positionX = (screenWidth - formWidth) / 2;
            int positionY = (screenHeight - formHeight) / 2;
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(positionX, positionY);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = true;
        }
        private void AdjustReportViewerSize()
        {
            // Tính toán kích thước và vị trí cho ReportViewer
            int topMargin = (int)(this.Height * 0.2); // Cách top của form 20%
            int leftMargin = 0; // Cách bên trái form
            int rightMargin = 0; // Cách bên phải form
            int bottomMargin = 0; // Cách dưới cùng form

            rptViewLuong.Location = new Point(leftMargin, topMargin); // Vị trí ReportViewer
            rptViewLuong.Size = new Size(this.Width - leftMargin - rightMargin, this.Height - topMargin - bottomMargin); // Kích thước ReportViewer
        }
        private void TheoLuongFieldsLocation()
        {
            lbLuongMin.Location = new Point(80, 43);
            txtLuongMin.Location = new Point(204, 40);

            lbLuongMax.Location = new Point(451, 43);
            txtLuongMax.Location = new Point(521, 40);
        }
        private void LoadReport(int? soNgayLam, float? luongMin, float? luongMax)
        {
            using (QLKSContext context = new QLKSContext())
            {
                // Truy vấn dữ liệu
                var query = from l in context.Luongs
                            join nv in context.NhanViens on l.MaNhanVien equals nv.MaNhanVien
                            where (soNgayLam == null || l.SoNgayLamViec == soNgayLam) &&
                                  (luongMin == null || l.TongLuong >= luongMin) &&
                                  (luongMax == null || l.TongLuong <= luongMax)
                            select new
                            {
                                l.MaLuong,
                                TenNhanVien = nv.TenNhanVien,
                                l.SoNgayLamViec,
                                l.SoGioTangCa,
                                l.TongLuong,
                                l.NgayTinhLuong
                            };

                // Chuyển đổi dữ liệu
                var listrpt = query.ToList().Select(item => new luongReport
                {
                    maLuong = item.MaLuong,
                    tenNV = item.TenNhanVien,
                    soNgayLam = item.SoNgayLamViec ?? 0,
                    soGioTangCa = (float)(item.SoGioTangCa ?? 0),
                    tongLuong = (float)(item.TongLuong ?? 0),
                    ngayTinh = item.NgayTinhLuong ?? DateTime.MinValue
                }).ToList();

                // Gán dữ liệu cho ReportViewer
                rptViewLuong.LocalReport.ReportPath = "rptLuong.rdlc";
                var source = new ReportDataSource("DataSet1", listrpt);
                rptViewLuong.LocalReport.DataSources.Clear();
                rptViewLuong.LocalReport.DataSources.Add(source);
                rptViewLuong.RefreshReport();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (chkTheoSoNgayLam.Checked)
            {
                // Lấy giá trị từ TextBox và chuyển đổi sang số nguyên
                if (int.TryParse(txtSoNgayLam.Text, out int soNgayLam))
                {
                    LoadReport(soNgayLam, null, null); // Tải dữ liệu dựa trên số ngày làm việc
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số ngày làm việc hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (chkTheoGia.Checked)
            {
                // Lấy giá trị từ TextBox
                if (float.TryParse(txtLuongMin.Text, out float luongMin) &&
                    float.TryParse(txtLuongMax.Text, out float luongMax))
                {
                    // Gọi phương thức LoadReport với lương min và max
                    LoadReport(null, luongMin, luongMax);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập lương tối thiểu và lương tối đa hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadReport(null, null, null);

            txtSoNgayLam.Text = string.Empty;

            txtLuongMin.Text = string.Empty;
            txtLuongMax.Text = string.Empty;
        }

        private void btnTuyChon_Click(object sender, EventArgs e)
        {
            panelFilterOptions.Location = new Point(btnTuyChon.Left, btnTuyChon.Bottom);

            panelFilterOptions.Visible = !panelFilterOptions.Visible;
        }
        private void ChonTuyChon()
        {
            // Kiểm tra trạng thái của checkbox
            if (chkTheoSoNgayLam.Checked)
            {
                lbSoNgayLam.Visible = true;
                txtSoNgayLam.Visible = true;

                lbLuongMin.Visible = false;
                txtLuongMin.Visible = false;

                lbLuongMax.Visible = false;
                txtLuongMax.Visible = false;
            }
            else if (chkTheoGia.Checked)
            {
                lbSoNgayLam.Visible = false;
                txtSoNgayLam.Visible = false;

                lbLuongMin.Visible = true;
                txtLuongMin.Visible = true;

                lbLuongMax.Visible = true;
                txtLuongMax.Visible = true;
            }
        }

        private void chkTheoSoNgayLam_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTheoSoNgayLam.Checked)
            {
                chkTheoGia.Checked = false;
            }
        }

        private void chkTheoLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTheoGia.Checked)
            {
                chkTheoSoNgayLam.Checked = false;
            }
        }
    }
}
