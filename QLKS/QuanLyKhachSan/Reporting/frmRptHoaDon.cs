using Microsoft.Reporting.WinForms;
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
    public partial class frmRptHoaDonn : Form
    {
        public frmRptHoaDonn()
        {
            InitializeComponent();
        }

        private void frmRptHoaDonn_Load(object sender, EventArgs e)
        {
            HoaDonContext hoaDonContext = new HoaDonContext(); // Kết nối tới database
            {
                // Lấy danh sách hóa đơn từ database
                List<HoaDonCT> listHoaDon = hoaDonContext.ChiTietHoaDons.ToList();

                // Tạo danh sách report
                List<HoaDonReport> listReport = new List<HoaDonReport>();

                // Duyệt qua danh sách hóa đơn để chuyển sang định dạng report
                foreach (HoaDonCT hoaDon in listHoaDon)
                {
                    HoaDonReport temp = new HoaDonReport();
                    temp.MaHoaDon = hoaDon.MaHoaDon;
                    temp.MaDatPhong = hoaDon.MaDatPhong;
                    temp.MaSuDungDichVu = hoaDon.MaSuDungDichVu;
                    temp.PhuThu = (float)hoaDon.PhuThu;
                    temp.TienPhong = (float)hoaDon.TienPhong;
                    temp.TienDichVu = (float)hoaDon.TienDichVu;
                    temp.GiamGiaKH = (float)hoaDon.GiamGiaKH;
                    temp.HinhThucThanhToan = hoaDon.HinhThucThanhToan;
                    temp.SoNgay = (float)hoaDon.SoNgay;
                    temp.ThanhTien = (float)hoaDon.ThanhTien;
                    listReport.Add(temp);
                }

                // Cấu hình ReportViewer
                reportViewer1.LocalReport.ReportPath = "rptHoaDon.rdlc"; // Đường dẫn tới file .rdlc
                var source = new ReportDataSource("HoaDonDataSet", listReport); // DataSet tương ứng
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(source);

                // Làm mới ReportViewer
                this.reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();
            }
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string maHoaDon = txtMaHD.Text.Trim();

            // Kiểm tra nếu người dùng chưa nhập mã hóa đơn
            if (string.IsNullOrEmpty(maHoaDon))
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kết nối tới database
            HoaDonContext hoaDonContext = new HoaDonContext();

            // Tìm hóa đơn theo mã
            var hoaDon = hoaDonContext.ChiTietHoaDons.FirstOrDefault(h => h.MaHoaDon == maHoaDon);

            if (hoaDon != null)
            {
                // Tạo danh sách report với một hóa đơn tìm thấy
                List<HoaDonReport> listReport = new List<HoaDonReport>();
                HoaDonReport temp = new HoaDonReport
                {
                    MaHoaDon = hoaDon.MaHoaDon,
                    MaDatPhong = hoaDon.MaDatPhong,
                    MaSuDungDichVu = hoaDon.MaSuDungDichVu,
                    PhuThu = (float)hoaDon.PhuThu,
                    TienPhong = (float)hoaDon.TienPhong,
                    TienDichVu = (float)hoaDon.TienDichVu,
                    GiamGiaKH = (float)hoaDon.GiamGiaKH,
                    HinhThucThanhToan = hoaDon.HinhThucThanhToan,
                    SoNgay = (float)hoaDon.SoNgay,
                    ThanhTien = (float)hoaDon.ThanhTien
                };
                listReport.Add(temp);

                // Cập nhật ReportViewer
                reportViewer1.LocalReport.ReportPath = "rptHoaDon.rdlc";
                var source = new ReportDataSource("HoaDonDataSet", listReport);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(source);

                // Làm mới ReportViewer
                reportViewer1.RefreshReport();
            }
            else
            {
                // Thông báo nếu không tìm thấy
                MessageBox.Show("Không tìm thấy hóa đơn với mã đã nhập!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaHD.Text = null;
        }
    }
}
