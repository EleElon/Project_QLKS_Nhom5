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
    }
}
