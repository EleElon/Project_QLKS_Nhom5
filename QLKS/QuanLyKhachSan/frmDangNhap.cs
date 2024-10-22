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
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string use = txtTenDangNhap.Text;
            string pass = txtMatKhau.Text;
            
            bool dangNhap = bus_dangNhap.CheckDangNhap(use,pass);
            if (dangNhap == true)
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

        }

        private void cbxShowPW_CheckedChanged(object sender, EventArgs e)
        {
            showPW = !showPW;
            txtMatKhau.PasswordChar = showPW ? '\0' : '*';
        }
    }
}
