using BUS;
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
    public partial class frmThayDoiChuoiKetNoi : Form
    {
        public frmThayDoiChuoiKetNoi()
        {
            InitializeComponent();

            // Gán sự kiện KeyDown cho các TextBox
            txtTenChuoi.KeyDown += new KeyEventHandler(txtTenChuoi_KeyDown);
        }
        private void DoiChuoiKetNoi(string chuoi)
        {
            ThayDoichuoiKetNoi.SetConnectionString($"Data Source={chuoi};Initial Catalog=QLKS;Integrated Security=True");
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            BUS_User.Instance.DoiChuoiKetNoi(txtTenChuoi.Text);
            DoiChuoiKetNoi(txtTenChuoi.Text);
            frmDangNhap frm = new frmDangNhap();
            frm.Show();
            this.Hide();
          
        }

        private void btnThayDoi_KeyDown(object sender, KeyEventArgs e)
        {
           
        }

        private void txtTenChuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnThayDoi_Click(sender, e); // Gọi sự kiện tìm kiếm
            }
        }
    }
}
