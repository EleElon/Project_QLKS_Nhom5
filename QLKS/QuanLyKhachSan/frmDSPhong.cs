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
    public partial class frmDSPhong : Form
    {
        public BUS_DSPhong bus_Phong = new BUS_DSPhong();
        public BUS_LoaiPhong bus_LoaiPhong = new BUS_LoaiPhong();
        public frmDSPhong()
        {
            InitializeComponent();

        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            LoadViewPhong();
            dgvDanhSachPhong.Columns["LoaiPhong"].Visible = false;
            LoadViewLoaiPhong();
            List<LoaiPhong> danhSachLoaiPhong = bus_LoaiPhong.Xem();
            dgvLoaiPhong.DataSource = danhSachLoaiPhong;

            cbMaLoaiPhong.DataSource = danhSachLoaiPhong;
            cbMaLoaiPhong.ValueMember = "MaLoaiPhong"; // Hiển thị tên loại phòng trong ComboBox

        }
        public void LoadViewLoaiPhong()
        {
            List<LoaiPhong> danhSachLoaiPhong = bus_LoaiPhong.Xem();

            if (danhSachLoaiPhong != null && danhSachLoaiPhong.Count > 0)
            {
                // Giả sử bạn có DataGridView tên là dgvDanhSachLoaiPhong
                dgvLoaiPhong.DataSource = danhSachLoaiPhong;
                dgvLoaiPhong.Refresh();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu loại phòng.");
            }
        }

        public void LoadViewPhong()
        {
            List<Phong> danhSachPhong = bus_Phong.Xem();

            if (danhSachPhong != null && danhSachPhong.Count > 0)
            {
                dgvDanhSachPhong.DataSource = danhSachPhong;
                dgvDanhSachPhong.Refresh();
            }
            else
            {
                MessageBox.Show("Không có dữ liệu phòng.");
            }
        }
        private void btnThem_Click_2(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;
            string maLoaiPhong = cbMaLoaiPhong.SelectedValue.ToString();
            int soPhong;
            string tinhTrang = cbtinhTrang.Text;

            // Kiểm tra dữ liệu đầu vào có hợp lệ không
            if (string.IsNullOrWhiteSpace(maPhong) ||
                string.IsNullOrWhiteSpace(maLoaiPhong) ||
                !int.TryParse(txtSoPhong.Text, out soPhong) ||
                string.IsNullOrWhiteSpace(tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Gọi phương thức thêm phòng từ lớp BUS
            bool ketQua = bus_Phong.themPhong(maPhong, maLoaiPhong, soPhong, tinhTrang);

            if (ketQua)
            {
                MessageBox.Show("Thêm phòng thành công!");
                dgvDanhSachPhong.DataSource = bus_Phong.Xem();
            }
            else
            {
                MessageBox.Show("Mã phòng đã tồn tại hoặc thêm phòng thất bại.");
            }
        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;

            // Kiểm tra xem người dùng có nhập mã phòng không
            if (string.IsNullOrWhiteSpace(maPhong))
            {
                MessageBox.Show("Vui lòng nhập mã phòng cần xóa.");
                return;
            }

            // Gọi hàm xóa phòng từ lớp BUS
            bool ketQua = bus_Phong.xoaPhong(maPhong);

            if (ketQua)
            {
                MessageBox.Show("Xóa phòng thành công!");
                dgvDanhSachPhong.DataSource = bus_Phong.Xem();

            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng cần xóa.");
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;
            string maLoaiPhong = cbMaLoaiPhong.SelectedValue.ToString();
            int soPhong;
            string tinhTrang = cbtinhTrang.Text;

            if (string.IsNullOrWhiteSpace(maPhong) ||
                string.IsNullOrWhiteSpace(maLoaiPhong) ||
                !int.TryParse(txtSoPhong.Text, out soPhong) ||
                string.IsNullOrWhiteSpace(tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }


            bool ketQua = bus_Phong.suaPhong(maPhong, maLoaiPhong, soPhong, tinhTrang);

            if (ketQua)
            {
                MessageBox.Show("Sửa phòng thành công!");
                LoadViewPhong();

            }
            else
            {
                MessageBox.Show("Không tìm thấy phòng cần sửa.");
            }
        }

        private void dgvDanhSachPhong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dgvDanhSachPhong.Rows[e.RowIndex];

                // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
                txtMaPhong.Text = row.Cells[0].Value.ToString();
                txtSoPhong.Text = row.Cells[2].Value.ToString();
                string maLoaiPhong = row.Cells[1].Value.ToString();

                // Lặp qua các mục trong ComboBox để chọn đúng loại phòng dựa trên MaLoaiPhong
                foreach (LoaiPhong loaiPhong in cbMaLoaiPhong.Items)
                {
                    if (loaiPhong.MaLoaiPhong == maLoaiPhong)
                    {
                        cbMaLoaiPhong.SelectedItem = loaiPhong;
                        break;
                    }
                }

                cbtinhTrang.Text = row.Cells[3].Value.ToString();
            }
        }

        private void btnThemPhong_Click_1(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaLoaiPhong.Text.Trim();
            string tenLoaiPhong = txtTenLoaiPhong.Text.Trim();
            float gia;
            if (string.IsNullOrWhiteSpace(maLoaiPhong))
            {
                MessageBox.Show("Mã loại phòng không được để trống.");
                return;
            }
            if (string.IsNullOrWhiteSpace(tenLoaiPhong))
            {
                MessageBox.Show("Tên loại phòng không được để trống.");
                return;
            }
            if (!float.TryParse(txtGia.Text.Trim(), out gia) || gia <= 0)
            {
                MessageBox.Show("Giá phòng phải là số hợp lệ =.");
                return;
            }

            if (bus_LoaiPhong.ThemLoaiPhong(maLoaiPhong, tenLoaiPhong, gia))
            {
                MessageBox.Show("Thêm loại phòng thành công!");
                LoadViewLoaiPhong();
            }
            else
            {
                MessageBox.Show("Thêm loại phòng thất bại. Mã loại phòng đã tồn tại.");
            }
        }

        private void btnXoaPhong_Click_1(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaLoaiPhong.Text;

            if (bus_LoaiPhong.XoaLoaiPhong(maLoaiPhong))
            {
                MessageBox.Show("Xóa loại phòng thành công!");
                LoadViewLoaiPhong();

            }
            else
            {
                MessageBox.Show("Xóa loại phòng thất bại. Không tìm thấy mã loại phòng.");
            }
        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaLoaiPhong.Text;
            string tenLoaiPhong = txtTenLoaiPhong.Text;
            float gia = float.Parse(txtGia.Text);

            if (bus_LoaiPhong.SuaLoaiPhong(maLoaiPhong, tenLoaiPhong, gia))
            {
                MessageBox.Show("Sửa loại phòng thành công!");
                LoadViewLoaiPhong();
            }
            else
            {
                MessageBox.Show("Sửa loại phòng thất bại. Không tìm thấy mã loại phòng.");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           this.Close();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
           this.Close();
        }

        private void dgvLoaiPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Lấy dòng được chọn
                DataGridViewRow row = dgvLoaiPhong.Rows[e.RowIndex];

                // Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
                txtMaLoaiPhong.Text = row.Cells["MaLoaiPhong"].Value.ToString();
                txtTenLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
            }
        }
    }
}
