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
            SetFormSizeAndPosition();
            AdjustReportViewerSize();

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
            rptViewDichVu.ZoomMode = ZoomMode.PageWidth;
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

            rptViewDichVu.Location = new Point(leftMargin, topMargin);
            rptViewDichVu.Size = new Size(this.Width - leftMargin - rightMargin, this.Height - topMargin - bottomMargin);
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

                List<dichVuReport> listrpt = query.ToList().Select(item => new dichVuReport
                {
                    maDV = item.MaDichVu,
                    tenLDV = item.TenLoaiDichVu,
                    tenDV = item.TenDichVu,
                    gia = (float)item.Gia
                }).ToList();

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
                if (float.TryParse(txtGiaMin.Text, out float luongMin) &&
                    float.TryParse(txtGiaMax.Text, out float luongMax))
                {
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
