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
    public partial class frmRptDSPhong : Form
    {
        public frmRptDSPhong()
        {
            InitializeComponent();
        }

        private void frmDSPhong_Load(object sender, EventArgs e)
        {
            PhongConText phongConText = new PhongConText();
            List<DSPhong> listPhong = phongConText.Phongs.ToList();
            List<PhongReport> listReport = new List<PhongReport>();
            foreach (DSPhong phong in listPhong)
            {
                PhongReport temp = new PhongReport();
               
                temp.MaLoaiPhong = phong.MaLoaiPhong;
                temp.MaPhong = phong.MaPhong;
                temp.SoPhong = phong.SoPhong;
                temp.TinhTrang = phong.TinhTrang;
                listReport.Add(temp);
            }
            reportViewer1.LocalReport.ReportPath = "rptPhong.rdlc";
            var source = new ReportDataSource("PhongDataSet",listReport);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(source);
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text.Trim();

            if (string.IsNullOrEmpty(maPhong))
            {
                MessageBox.Show("Vui lòng nhập mã phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lấy dữ liệu từ cơ sở dữ liệu (chỉ phòng có MaPhong tương ứng)
            PhongConText phongConText = new PhongConText();
            var phong = phongConText.Phongs.FirstOrDefault(p => p.MaPhong == maPhong);

            if (phong != null)
            {
                // Chuyển dữ liệu sang danh sách report
                List<PhongReport> listReport = new List<PhongReport>();
                PhongReport temp = new PhongReport
                {
                    MaLoaiPhong = phong.MaLoaiPhong,
                    MaPhong = phong.MaPhong,
                    SoPhong = phong.SoPhong,
                    TinhTrang = phong.TinhTrang
                };
                listReport.Add(temp);

                // Gán dữ liệu vào ReportViewer
                reportViewer1.LocalReport.ReportPath = "rptPhong.rdlc";
                var source = new ReportDataSource("PhongDataSet", listReport);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(source);
                reportViewer1.RefreshReport();
            }
            else
            {
                MessageBox.Show("Không tìm thấy thông tin phòng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
