using QuanLiKhachSan_Nhom5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class FrmMain : Form
    {
        private int smoothScrollTarget = 0;
        private Timer smoothScrollTimer;

        public FrmMain()
        {
            InitializeComponent();

            smoothScrollTimer = new Timer();
            smoothScrollTimer.Interval = 10;
            smoothScrollTimer.Tick += SmoothScrollTimer_Tick;

            pnlSystemButton.MouseWheel += PnlSystemButton_MouseWheel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void OpenChildFormInPanel(Form childForm, Panel panel)
        {
            panel.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMain.Controls.Add(childForm);
            pnMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmNhanVien frmNV = new frmNhanVien(this);

            frmNV.TopLevel = false;
            frmNV.Dock = DockStyle.Fill;
            pnMain.Controls.Add(frmNV);
            frmNV.Show();
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmKhachHang khachHang = new frmKhachHang();

            khachHang.TopLevel = false;
            khachHang.Dock = DockStyle.Fill;
            pnMain.Controls.Add(khachHang);
            khachHang.Show();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmDSPhong khachHang = new frmDSPhong();

            khachHang.TopLevel = false;
            khachHang.Dock = DockStyle.Fill;
            pnMain.Controls.Add(khachHang);
            khachHang.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmDichVu dv = new frmDichVu();

            dv.TopLevel = false;
            dv.Dock = DockStyle.Fill;
            pnMain.Controls.Add(dv);
            dv.Show();
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmLuong khachHang = new frmLuong();

            khachHang.TopLevel = false;
            khachHang.Dock = DockStyle.Fill;
            pnMain.Controls.Add(khachHang);
            khachHang.Show();
        }

        private void btnCSVC_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmCoSoVatChat khachHang = new frmCoSoVatChat();

            khachHang.TopLevel = false;
            khachHang.Dock = DockStyle.Fill;
            pnMain.Controls.Add(khachHang);
            khachHang.Show();
        }

        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmThongKeKhachHang fr = new frmThongKeKhachHang();

            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            pnMain.Controls.Add(fr);
            fr.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();
            frmHoaDon fr = new frmHoaDon();

            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            pnMain.Controls.Add(fr);
            fr.Show();
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangNhap frmLogin = new frmDangNhap();
            frmLogin.Show();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();

            frmQuanLiPhong fr = new frmQuanLiPhong();
            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            pnMain.Controls.Add(fr);
            fr.Show();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            pnMain.Controls.Clear();

            frmChamCong fr = new frmChamCong();
            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            pnMain.Controls.Add(fr);
            fr.Show();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            foreach (Control ctrl in pnlSystemButton.Controls)
            {
                ctrl.Top = ctrl.Top - (e.NewValue - e.OldValue);
            }
        }

        private void pnlSystemButton_Resize(object sender, EventArgs e)
        {
            //int totalHeight = pnlSystemButton.Controls.Cast<Control>().Sum(c => c.Height + c.Margin.Vertical);

            //vScrollBar1.Maximum = Math.Max(0, totalHeight - pnlSystemButton.ClientSize.Height);
            //vScrollBar1.LargeChange = pnlSystemButton.ClientSize.Height;
            //vScrollBar1.SmallChange = 10; 
            //vScrollBar1.Visible = vScrollBar1.Maximum > 0; 
        }

        private void pnlSystemButton_Scroll(object sender, ScrollEventArgs e)
        {
            //vScrollBar1.Value = pnlSystemButton.VerticalScroll.Value; 
        }

        private void PnlSystemButton_MouseWheel(object sender, MouseEventArgs e)
        {
            smoothScrollTarget -= e.Delta / 2;
            smoothScrollTarget = Math.Max(0, Math.Min(smoothScrollTarget, pnlSystemButton.VerticalScroll.Maximum));

            //smoothScrollTimer.Start();
        }

        private void SmoothScrollTimer_Tick(object sender, EventArgs e)
        {
            int currentScroll = pnlSystemButton.VerticalScroll.Value;
            int step = (smoothScrollTarget - currentScroll) / 100;
            if (Math.Abs(step) < 1)
            {
                pnlSystemButton.AutoScrollPosition = new Point(0, smoothScrollTarget);
                smoothScrollTimer.Stop();
            }
            else
            {
                pnlSystemButton.AutoScrollPosition = new Point(0, currentScroll + step);
            }
        }
    }
}
