using DAO;
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
    public partial class frmTimKiemPhong : Form
    {
        public frmTimKiemPhong()
        {
            InitializeComponent();
        }
        DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaPhong.Text.Trim();
            string tenLoaiPhong = txtTenPhong.Text.Trim();

            if (string.IsNullOrWhiteSpace(maLoaiPhong) && string.IsNullOrWhiteSpace(tenLoaiPhong))
            {
                MessageBox.Show("Vui lòng nhập mã loại phòng hoặc tên loại phòng để tìm kiếm.");
                return;
            }

            var query = db.LoaiPhongs.AsQueryable();

            if (!string.IsNullOrEmpty(maLoaiPhong))
            {
                query = query.Where(lp => lp.MaLoaiPhong.Equals(maLoaiPhong));
            }

            if (!string.IsNullOrEmpty(tenLoaiPhong))
            {
                query = query.Where(lp => lp.TenLoaiPhong.Contains(tenLoaiPhong));
            }

            bool isCheckedGiaNhoHon500 = radioButton1.Checked;
            bool isCheckedGiaLonHon1000 = radioButton2.Checked;
            bool isCheckedGiaLonHon2000 = radioButton3.Checked;

            if (isCheckedGiaNhoHon500)
            {
                query = query.Where(lp => lp.Gia < 500000);
            }
            else if (isCheckedGiaLonHon1000)
            {
                query = query.Where(lp => lp.Gia > 1000000);
            }
            else if (isCheckedGiaLonHon2000)
            {
                query = query.Where(lp => lp.Gia > 2000000);
            }

            var result = query.ToList();

            dgTimKiemPhong.DataSource = result;

            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy loại phòng khớp với điều kiện tìm kiếm.");
            }
        }

        private void dgvTimKiemPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void frmTimKiemPhong_Load(object sender, EventArgs e)
        {

        }

        private void dgTimKiemPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenPhong.Text = null;
            txtMaPhong.Text = null;
        }
    }
}
