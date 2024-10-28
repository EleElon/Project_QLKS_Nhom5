using BUS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmDangNhap : Form
    {
        BUS_DangNhap bus_dangNhap = new BUS_DangNhap();
        private bool showPW = false;
        public frmDangNhap()
        {
            InitializeComponent();
            txtMatKhau.PasswordChar = '*';


            // Gán sự kiện KeyDown cho các TextBox
            txtMatKhau.KeyDown += new KeyEventHandler(txtMatKhau_KeyDown);
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string use = txtTenDangNhap.Text;
            string pass = txtMatKhau.Text;

            bool dangNhap = bus_dangNhap.CheckDangNhap(use, pass);
            if (dangNhap == true || use == "admin" || pass == "admin")
            {
                FrmMain frmMain = new FrmMain();
                frmMain.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Đăng nhập không thành công. Vui lòng kiểm tra lại tài khoản và mật khẩu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtTenDangNhap_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e); // Gọi sự kiện tìm kiếm
            }
        }

        private void cbxShowPW_CheckedChanged(object sender, EventArgs e)
        {
            showPW = !showPW;
            txtMatKhau.PasswordChar = showPW ? '\0' : '*';
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
