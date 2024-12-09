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
            HoaDonContext hoaDonContext = new HoaDonContext();
            {
                List<ChiTietHoaDon> listHoaDon = hoaDonContext.ChiTietHoaDons.ToList();

                List<HoaDonReport> listReport = new List<HoaDonReport>();

                foreach (ChiTietHoaDon hoaDon in listHoaDon)
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

                reportViewer1.LocalReport.ReportPath = "rptHoaDon.rdlc";
                var source = new ReportDataSource("HoaDonDataSet", listReport);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(source);

                this.reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(tuKhoa))
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (HoaDonContext hoaDonContext = new HoaDonContext())
            {
                List<ChiTietHoaDon> listHoaDon;

                if (rdoMaHD.Checked)
                {
                    listHoaDon = hoaDonContext.ChiTietHoaDons
                        .Where(h => h.MaHoaDon.Contains(tuKhoa))
                        .ToList();
                }
                else if (rdoMaDP.Checked)
                {
                    listHoaDon = hoaDonContext.ChiTietHoaDons
                        .Where(h => h.MaDatPhong.Contains(tuKhoa))
                        .ToList();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn loại tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (listHoaDon.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy kết quả phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                List<HoaDonReport> listReport = new List<HoaDonReport>();
                foreach (ChiTietHoaDon hoaDon in listHoaDon)
                {
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
                }

                reportViewer1.LocalReport.DataSources.Clear();
                var source = new ReportDataSource("HoaDonDataSet", listReport);
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTimKiem.Text = null;
        }
    }
}
