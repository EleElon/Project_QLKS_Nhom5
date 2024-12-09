using BUS;
using QuanLyKhachSan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiKhachSan_Nhom5
{
    public partial class frmThongKeKhachHang : Form
    {
        public frmThongKeKhachHang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            BUS_ThoongKeKhachHang.Instance.HienThi(dgvThongKe, dtpTu.Text.ToString(), dtpDen.Text.ToString());
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            dtpDen.Value = DateTime.Now;
            dtpTu.Value = DateTime.Now;
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            FrmReportKhachHang frm = new FrmReportKhachHang(dtpTu.Text, dtpDen.Text);
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.TopLevel = true;
            frm.Dock = DockStyle.None;
            frm.Show();
        }
    }
}
