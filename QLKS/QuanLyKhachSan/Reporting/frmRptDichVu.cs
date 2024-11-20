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

            QLKSContext context = new QLKSContext();

            // Lấy dữ liệu từ Luong và NhanVien, liên kết hai bảng
            var query = from dv in context.DichVus
                        join ldv in context.LoaiDichVus on dv.MaLoaiDichVu equals ldv.MaLoaiDichVu
                        select new
                        {
                            dv.MaDichVu,
                            TenLoaiDichVu = ldv.TenLoaiDichVu, // Lấy tên nhân viên
                            dv.TenDichVu,
                            dv.Gia
                        };

            List<dichVuReport> listrpt = new List<dichVuReport>();
            foreach (var item in query.ToList())
            {
                dichVuReport temp = new dichVuReport
                {
                    maDV = item.MaDichVu,
                    tenLDV = item.TenLoaiDichVu, // Gán tên nhân viên
                    tenDV = item.TenDichVu,
                    gia = (float)item.Gia
                };

                listrpt.Add(temp);
            }

            rptViewDichVu.LocalReport.ReportPath = "rptDichVu.rdlc";
            var source = new ReportDataSource("dichVuDataSet", listrpt);
            rptViewDichVu.LocalReport.DataSources.Clear();
            rptViewDichVu.LocalReport.DataSources.Add(source);

            this.rptViewDichVu.RefreshReport();
        }
    }
}
