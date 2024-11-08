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
        public FrmMain()
        {
            InitializeComponent();
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
       frmThongKeDoanhThu fr = new frmThongKeDoanhThu();

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
        
    }
}
