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

            // Tạo và cấu hình Timer
            smoothScrollTimer = new Timer();
            smoothScrollTimer.Interval = 10; // 10ms, tạo hiệu ứng mượt
            smoothScrollTimer.Tick += SmoothScrollTimer_Tick;

            // Bắt sự kiện MouseWheel
            pnlSystemButton.MouseWheel += PnlSystemButton_MouseWheel;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void OpenChildFormInPanel(Form childForm, Panel panel)
        {
            panel.Controls.Clear(); // Xóa tất cả các điều khiển con trong Panel
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
           
            // Đặt form không phải là form chính
            pnMain.Controls.Clear();
       frmThongKeKhachHang fr = new frmThongKeKhachHang();

            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            pnMain.Controls.Add(fr);
            fr.Show();
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            // Đặt form không phải là form chính
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
          
            // Đặt form không phải là form chính
            pnMain.Controls.Clear();
           
            frmQuanLiPhong fr = new frmQuanLiPhong();
            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            pnMain.Controls.Add(fr);
            fr.Show();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            // Đặt form không phải là form chính
            pnMain.Controls.Clear();

            frmChamCong fr = new frmChamCong();
            fr.TopLevel = false;
            fr.Dock = DockStyle.Fill;
            pnMain.Controls.Add(fr);
            fr.Show();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            // Di chuyển các control trong pnlSystemButton theo giá trị của thanh cuộn
            foreach (Control ctrl in pnlSystemButton.Controls)
            {
                ctrl.Top = ctrl.Top - (e.NewValue - e.OldValue); // Di chuyển theo giá trị cuộn
            }
        }

        private void pnlSystemButton_Resize(object sender, EventArgs e)
        {
            //// Tổng chiều cao của các button trong Panel
            //int totalHeight = pnlSystemButton.Controls.Cast<Control>().Sum(c => c.Height + c.Margin.Vertical);

            //// Cập nhật giá trị thanh cuộn
            //vScrollBar1.Maximum = Math.Max(0, totalHeight - pnlSystemButton.ClientSize.Height);
            //vScrollBar1.LargeChange = pnlSystemButton.ClientSize.Height;
            //vScrollBar1.SmallChange = 10; // Pixel di chuyển mỗi lần cuộn nhỏ
            //vScrollBar1.Visible = vScrollBar1.Maximum > 0; // Chỉ hiển thị thanh cuộn khi cần
        }

        private void pnlSystemButton_Scroll(object sender, ScrollEventArgs e)
        {
            //vScrollBar1.Value = pnlSystemButton.VerticalScroll.Value; // Đồng bộ giá trị thanh cuộn
        }

        private void PnlSystemButton_MouseWheel(object sender, MouseEventArgs e)
        {
            // Cập nhật giá trị cuộn đích
            smoothScrollTarget -= e.Delta / 2; // Giá trị nhỏ để cuộn mượt hơn
            smoothScrollTarget = Math.Max(0, Math.Min(smoothScrollTarget, pnlSystemButton.VerticalScroll.Maximum));

            // Bắt đầu Timer
            //smoothScrollTimer.Start();
        }

        private void SmoothScrollTimer_Tick(object sender, EventArgs e)
        {
            int currentScroll = pnlSystemButton.VerticalScroll.Value;
            int step = (smoothScrollTarget - currentScroll) / 100; // Chia thành 5 bước để mượt
            if (Math.Abs(step) < 1) // Khi gần đạt giá trị đích
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
