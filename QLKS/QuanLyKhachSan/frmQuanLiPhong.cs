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
    public partial class frmQuanLiPhong : Form
    {
        public frmQuanLiPhong()
        {
            InitializeComponent();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemPhong frm = new frmTimKiemPhong();
            frm.Show();
            
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
    }
}
