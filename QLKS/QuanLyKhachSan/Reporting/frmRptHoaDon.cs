using DAO;
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
    public partial class frmRptHoaDon : Form
    {
        public frmRptHoaDon()
        {
            InitializeComponent();
        }

        private void frmRptHoaDon_Load(object sender, EventArgs e)
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
    }
}
