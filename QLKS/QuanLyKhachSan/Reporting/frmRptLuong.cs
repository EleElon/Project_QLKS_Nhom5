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
            SetFormSizeAndPosition();
            AdjustReportViewerSize();

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
            rptViewLuong.ZoomMode = ZoomMode.PageWidth;
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
            int topMargin = (int)(this.Height * 0.2);
            int leftMargin = 0;
            int rightMargin = 0;
            int bottomMargin = 0;

            rptViewLuong.Location = new Point(leftMargin, topMargin);
            rptViewLuong.Size = new Size(this.Width - leftMargin - rightMargin, this.Height - topMargin - bottomMargin);
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
            using (QLKSDataset context = new QLKSDataset())
            {
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

                var listrpt = query.ToList().Select(item => new luongReport
                {
                    maLuong = item.MaLuong,
                    tenNV = item.TenNhanVien,
                    soNgayLam = item.SoNgayLamViec ?? 0,
                    soGioTangCa = (float)(item.SoGioTangCa ?? 0),
                    tongLuong = (float)(item.TongLuong ?? 0),
                    ngayTinh = item.NgayTinhLuong ?? DateTime.MinValue
                }).ToList();

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
                if (int.TryParse(txtSoNgayLam.Text, out int soNgayLam))
                {
                    LoadReport(soNgayLam, null, null);
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập số ngày làm việc hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (chkTheoGia.Checked)
            {
                if (float.TryParse(txtLuongMin.Text, out float luongMin) &&
                    float.TryParse(txtLuongMax.Text, out float luongMax))
                {
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
