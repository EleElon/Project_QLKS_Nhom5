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
    public partial class TimKiemKhachHang : Form
    {
        public TimKiemKhachHang()
        {
            InitializeComponent();


            // Gán sự kiện KeyDown cho các TextBox
            txtMaKH.KeyDown += new KeyEventHandler(txtMaKH_KeyDown);
            txtTenKH.KeyDown += new KeyEventHandler(txtTenKH_KeyDown);
        }

       

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            if (txtMaKH.Text.Length > 0)
            {
                txtTenKH.ReadOnly = true;
                txtTenKH.Text = "";
               
            }
           
        }
        //Làm mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            txtTenKH.Text = "";
            txtMaKH.ReadOnly = false;
            txtTenKH.ReadOnly = false;

        }
        //Tìm kiếm
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtTenKH.ReadOnly == true)
            {
                BUS_TimKiemKhachHang.Instance.TimKiemMaKH(txtMaKH, dgvTimKiemKH);
            }
            if (txtMaKH.ReadOnly == true)
            {
                BUS_TimKiemKhachHang.Instance.TimKiemTenKH(txtTenKH, dgvTimKiemKH);
            }
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
          if (txtTenKH.Text.Length > 0)
            {
                txtMaKH.ReadOnly = true;
                txtMaKH.Text = "";
            }
        }

        private void txtMaKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e); // Gọi sự kiện tìm kiếm
            }
        }

        private void txtTenKH_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnTimKiem_Click(sender, e); // Gọi sự kiện tìm kiếm
            }
        }
    }
}
