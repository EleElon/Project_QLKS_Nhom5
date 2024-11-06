using BUS;
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
    public partial class frmLuong : Form
    {
        BUS_Luong bus_luong = new BUS_Luong();
        public frmLuong()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            DSLuong(dgvDSLuong);
        }

        public void DSLuong(DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
            {
                var luong = db.Luongs.Select(a => new
                {
                    a.MaLuong,
                    a.MaNhanVien,
                    a.Thang,
                    a.SoTien
                }).ToList();
                data.DataSource = luong;
            }
        }

        public void LoadView()
        {
            dgvDSLuong.DataSource = bus_luong.View();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLuong = txtMaLuong.Text;
            string maNV = cboMaNhanVien.SelectedValue.ToString();
            int thang = int.Parse(txtThang.Text);
            float soTien = float.Parse(txtSoTien.Text);

            bool result = bus_luong.ThemLuong(maLuong, maNV, thang, soTien);
            if (result)
            {
                MessageBox.Show("Thêm lương thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Thêm lương không thành công. Lương đã tồn tại.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maLuong = txtMaLuong.Text;
            bool result = bus_luong.XoaLuong(maLuong);
            if (result)
            {
                MessageBox.Show("Xóa lương thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Xóa lương không thành công. Không tìm thấy lương.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maLuong = txtMaLuong.Text;
            string maNV = cboMaNhanVien.SelectedValue.ToString();
            int thang = int.Parse(txtThang.Text);
            float soTien = float.Parse(txtSoTien.Text);

            bool result = bus_luong.SuaLuong(maLuong, maNV, thang, soTien);
            if (result)
            {
                MessageBox.Show("Sửa thông tin lương thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Sửa thông tin lương không thành công. Không tìm thấy lương.");
            }
        }

        private void dgvDSLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvDSLuong.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaLuong.Text = row.Cells[0].Value.ToString();
            txtThang.Text = row.Cells[2].Value.ToString();
            string maNVv = row.Cells[1].Value.ToString();
            foreach (Luong maNV in cboMaNhanVien.Items)
            {
                if (maNV.MaNhanVien == maNVv)
                {
                    cboMaNhanVien.SelectedItem = maNV;
                    break;
                }
            }
            txtSoTien.Text = row.Cells[3].Value.ToString();
        }
    }
}
