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
    public partial class frmNhanVien : Form
    {
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            DSNhanVien(dgvNhanVien);
        }

        public void DSNhanVien(DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
            {
                var nhanVien = db.NhanViens.Select(a => new
                {
                    a.MaNhanVien,
                    a.MaPhong,
                    a.TenNhanVien,
                    a.ChucVu,
                    a.Luong
                }).ToList();
                data.DataSource = nhanVien;
            }
        }

        public void LoadView()
        {
            dgvNhanVien.DataSource = bus_nv.View();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string maPhong = cboMaPhong.SelectedValue.ToString();
            string tenNV = txtTenNV.Text;
            string chucVu = txtChucVu.Text;
            float luong = float.Parse(txtLuong.Text);

            bool result = bus_nv.ThemNhanVien(maNV, maPhong, tenNV, chucVu, luong);
            if (result)
            {
                MessageBox.Show("Thêm nhân viên thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên không thành công. Nhân viên đã tồn tại.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            bool result = bus_nv.XoaNhanVien(maNV);
            if (result)
            {
                MessageBox.Show("Xóa nhân viên thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên không thành công. Không tìm thấy nhân viên.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maNV = txtMaNV.Text;
            string maPhong = cboMaPhong.SelectedValue.ToString();
            string tenNV = txtTenNV.Text;
            string chucVu = txtChucVu.Text;
            float luong = float.Parse(txtLuong.Text);

            bool result = bus_nv.SuaNhanVien(maNV, maPhong, tenNV, chucVu, luong);
            if (result)
            {
                MessageBox.Show("Sửa thông tin nhân viên thành công.");
                LoadView();
                //ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Sửa thông tin nhân viên không thành công. Không tìm thấy nhân viên.");
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];

            // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            txtMaNV.Text = row.Cells[0].Value.ToString();
            txtTenNV.Text = row.Cells[2].Value.ToString();
            string maPhongg = row.Cells[1].Value.ToString();
            foreach (NhanVien maPhong in cboMaPhong.Items)
            {
                if (maPhong.MaPhong == maPhongg)
                {
                    cboMaPhong.SelectedItem = maPhong;
                    break;
                }
            }
            txtChucVu.Text = row.Cells[3].Value.ToString();
            txtLuong.Text = row.Cells[4].Value.ToString();
        }
    }
}
