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

        private void button1_Click(object sender, EventArgs e)
        {
            frmNhanVien frm = new frmNhanVien();

            // Đặt form không phải là form chính
            frm.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            frm.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y


            frm.Show();
            //frm.MdiParent = this;
        }

        private void btnKH_Click(object sender, EventArgs e)
        {
            frmKhachHang fr = new frmKhachHang();
            // Đặt form không phải là form chính
            fr.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            fr.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y

            fr.Show();
            //fr.MdiParent = this;
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            frmDSPhong fr = new frmDSPhong();
            // Đặt form không phải là form chính
            fr.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            fr.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y
            fr.Show();
            //fr.MdiParent = this;
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {
            frmDichVu fr = new frmDichVu();
            // Đặt form không phải là form chính
            fr.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            fr.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y
            fr.Show();
            //fr.MdiParent = this;
        }

        private void btnLuong_Click(object sender, EventArgs e)
        {
            frmLuong fr = new frmLuong();
            // Đặt form không phải là form chính
            fr.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            fr.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y
            fr.Show();
            //fr.MdiParent = this;
        }

        private void btnCSVC_Click(object sender, EventArgs e)
        {
            frmCoSoVatChat fr = new frmCoSoVatChat();
            // Đặt form không phải là form chính
            fr.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            fr.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y
            fr.Show();
            //fr.MdiParent = this;
        }




        private void btnDoanhThu_Click(object sender, EventArgs e)
        {
            frmThongKeDoanhThu fr = new frmThongKeDoanhThu();
            // Đặt form không phải là form chính
            fr.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            fr.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y
            fr.Show();
            //fr.MdiParent = this;
        }

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            frmHoaDon frm = new frmHoaDon();
            // Đặt form không phải là form chính
            frm.StartPosition = FormStartPosition.Manual;

            // Tính vị trí form con cách panel1 50px
            int panelRightEdge = panel1.Location.X + panel1.Width;
            int formXPosition = panelRightEdge + 50; // 50px cách panel

            // Đặt vị trí form
            frm.Location = new Point(formXPosition, this.Location.Y + 80); // Đặt form theo trục X và Y

            frm.Show();
            //frm.MdiParent = this;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDangNhap frmLogin = new frmDangNhap();
            frmLogin.Show();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            frmQuanLiPhong frm = new frmQuanLiPhong();
            frm.Show();
        }
    }
}
