using DAO;
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

            //// Lấy dữ liệu từ Luong và NhanVien, liên kết hai bảng
            //var query = from dv in context.DichVus
            //            join ldv in context.LoaiDichVus on dv.MaLoaiDichVu equals ldv.MaLoaiDichVu
            //            select new
            //            {
            //                dv.MaDichVu,
            //                TenLoaiDichVu = ldv.TenLoaiDichVu, // Lấy tên nhân viên
            //                dv.TenDichVu,
            //                dv.Gia
            //            };

            //List<dichVuReport> listrpt = new List<dichVuReport>();
            //foreach (var item in query.ToList())
            //{
            //    dichVuReport temp = new dichVuReport
            //    {
            //        maDV = item.MaDichVu,
            //        tenLDV = item.TenLoaiDichVu, // Gán tên nhân viên
            //        tenDV = item.TenDichVu,
            //        gia = (float)item.Gia
            //    };

            //    listrpt.Add(temp);
            //}

            //rptViewDichVu.LocalReport.ReportPath = "rptDichVu.rdlc";
            //var source = new ReportDataSource("dichVuDataSet", listrpt);
            //rptViewDichVu.LocalReport.DataSources.Clear();
            //rptViewDichVu.LocalReport.DataSources.Add(source);

            //this.rptViewDichVu.RefreshReport();

            SetFormSizeAndPosition();
            // Gọi phương thức thiết lập kích thước ban đầu cho ReportViewer
            AdjustReportViewerSize();

            // Gắn sự kiện Resize để tự động thay đổi kích thước ReportViewer khi form thay đổi
            this.Resize += (s, ev) => AdjustReportViewerSize();
            LoadReport(null, null, null);

            chkTheoTenLoai.Checked = true;

            lbGiaMin.Visible = false;
            txtGiaMin.Visible = false;

            lbGiaMax.Visible = false;
            txtGiaMax.Visible = false;

            chkTheoTenLoai.CheckedChanged += (s, ev) => ChonTuyChon();
            chkTheoGia.CheckedChanged += (s, ev) => ChonTuyChon();

            TheoLuongFieldsLocation();
            rptViewDichVu.ZoomMode = ZoomMode.PageWidth; // Hiển thị toàn bộ chiều rộng
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

            rptViewDichVu.Location = new Point(leftMargin, topMargin); // Vị trí ReportViewer
            rptViewDichVu.Size = new Size(this.Width - leftMargin - rightMargin, this.Height - topMargin - bottomMargin); // Kích thước ReportViewer
        }
        private void TheoLuongFieldsLocation()
        {
            lbGiaMin.Location = new Point(80, 43);
            txtGiaMin.Location = new Point(204, 40);

            lbGiaMax.Location = new Point(451, 43);
            txtGiaMax.Location = new Point(521, 40);
        }
        private void LoadReport(string loaiDichVu, float? giaMin, float? giaMax)
        {
            using (QLKSDataset context = new QLKSDataset())
            {
                // Truy vấn dữ liệu có điều kiện lọc
                var query = from dv in context.DichVus
                            join ldv in context.LoaiDichVus on dv.MaLoaiDichVu equals ldv.MaLoaiDichVu
                            where (string.IsNullOrEmpty(loaiDichVu) || ldv.TenLoaiDichVu.Contains(loaiDichVu))
                               && (!giaMin.HasValue || dv.Gia >= giaMin)
                               && (!giaMax.HasValue || dv.Gia <= giaMax)
                            select new
                            {
                                dv.MaDichVu,
                                TenLoaiDichVu = ldv.TenLoaiDichVu,
                                dv.TenDichVu,
                                dv.Gia
                            };

                // Chuyển đổi dữ liệu sang danh sách báo cáo
                List<dichVuReport> listrpt = query.ToList().Select(item => new dichVuReport
                {
                    maDV = item.MaDichVu,
                    tenLDV = item.TenLoaiDichVu,
                    tenDV = item.TenDichVu,
                    gia = (float)item.Gia
                }).ToList();

                // Gán dữ liệu cho ReportViewer
                rptViewDichVu.LocalReport.ReportPath = "rptDichVu.rdlc";
                var source = new ReportDataSource("dichVuDataSet", listrpt);
                rptViewDichVu.LocalReport.DataSources.Clear();
                rptViewDichVu.LocalReport.DataSources.Add(source);

                rptViewDichVu.RefreshReport();
            }
        }
        private void ChonTuyChon()
        {
            if (chkTheoTenLoai.Checked)
            {
                lbTenLoaiDV.Visible = true;
                txtTenLoaiDV.Visible = true;

                lbGiaMin.Visible = false;
                txtGiaMin.Visible = false;

                lbGiaMax.Visible = false;
                txtGiaMax.Visible = false;
            }
            else if (chkTheoGia.Checked)
            {
                lbTenLoaiDV.Visible = false;
                txtTenLoaiDV.Visible = false;

                lbGiaMin.Visible = true;
                txtGiaMin.Visible = true;

                lbGiaMax.Visible = true;
                txtGiaMax.Visible = true;
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadReport(null, null, null);

            txtTenLoaiDV.Text = string.Empty;

            txtGiaMin.Text = string.Empty;
            txtGiaMax.Text = string.Empty;
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            if (chkTheoTenLoai.Checked)
            {
                string loaiDichVu = txtTenLoaiDV.Text.Trim();
                if (!string.IsNullOrEmpty(loaiDichVu))
                {
                    LoadReport(loaiDichVu, null, null);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập tên loại dịch vụ để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (chkTheoGia.Checked)
            {
                // Lấy giá trị từ TextBox
                if (float.TryParse(txtGiaMin.Text, out float luongMin) &&
                    float.TryParse(txtGiaMax.Text, out float luongMax))
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

        private void chkTheoTenLoai_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTheoTenLoai.Checked)
            {
                chkTheoGia.Checked = false;
            }
        }

        private void chkTheoLuong_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTheoGia.Checked)
            {
                chkTheoTenLoai.Checked = false;
            }
        }

        private void btnTuyChon_Click(object sender, EventArgs e)
        {
            panelFilterOptions.Location = new Point(btnTuyChon.Left, btnTuyChon.Bottom);

            panelFilterOptions.Visible = !panelFilterOptions.Visible;
        }
    }
}
