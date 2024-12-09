using BUS;
using DAO;
using QuanLyKhachSan.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            LoadViewLoaiPhong();
            GioiHanKiTu();
            List<LoaiPhong> danhSachLoaiPhong = bus_LoaiPhong.Xem();
            dgvLoaiPhong.DataSource = danhSachLoaiPhong;
            cbMaLoaiPhong.DataSource = danhSachLoaiPhong;
            cbMaLoaiPhong.DisplayMember = "MaLoaiPhong";
            cbMaLoaiPhong.ValueMember = "MaLoaiPhong";
            dgvDanhSachPhong.Columns["LoaiPhong"].Visible = false;
        }
        public void LoadViewLoaiPhong()
        {
            List<LoaiPhong> danhSachLoaiPhong = bus_LoaiPhong.Xem();

            if (danhSachLoaiPhong != null && danhSachLoaiPhong.Count > 0)
            {
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
            List<DAO.Phong> danhSachPhong = bus_Phong.Xem();

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
            errorProvider1.Clear();

            string maPhong = txtMaPhong.Text;
            string maLoaiPhong = cbMaLoaiPhong.SelectedValue?.ToString();
            string soPhong = txtSoPhong.Text;
            string tinhTrang = cbtinhTrang.Text;

            if (!ValidateInput(maPhong, maLoaiPhong, soPhong, tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

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

            if (string.IsNullOrWhiteSpace(maPhong))
            {
                MessageBox.Show("Vui lòng nhập mã phòng cần xóa.");
                return;
            }

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
            string soPhong = txtSoPhong.Text;
            string tinhTrang = cbtinhTrang.Text;

            if (string.IsNullOrWhiteSpace(maPhong) ||
                string.IsNullOrWhiteSpace(maLoaiPhong) ||
                string.IsNullOrEmpty(soPhong) ||
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
                DataGridViewRow row = dgvDanhSachPhong.Rows[e.RowIndex];

                txtMaPhong.Text = row.Cells[0].Value.ToString();
                txtSoPhong.Text = row.Cells[2].Value.ToString();
                string maLoaiPhong = row.Cells[1].Value.ToString();

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
            errorProvider2.Clear();

            string maLoaiPhong = txtMaLoaiPhong2.Text;
            string tenPhong = txtTenLoaiPhong.Text;
            string gia = txtGia.Text;

            if (!ValidateInput(maLoaiPhong, tenPhong, gia, out float giaValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            bool ketQua = bus_LoaiPhong.ThemLoaiPhong(maLoaiPhong, tenPhong, giaValue);

            if (ketQua)
            {
                MessageBox.Show("Thêm loại phòng thành công!");
                LoadViewLoaiPhong();
            }
            else
            {
                MessageBox.Show("Mã loại phòng đã tồn tại hoặc thêm loại phòng thất bại.");
            }
        }

        private void btnXoaPhong_Click_1(object sender, EventArgs e)
        {
            string maLoaiPhong = cbMaLoaiPhong.Text;

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
            string maLoaiPhong = cbMaLoaiPhong.Text;
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
                DataGridViewRow row = dgvLoaiPhong.Rows[e.RowIndex];

                cbMaLoaiPhong.Text = row.Cells["MaLoaiPhong"].Value.ToString();
                txtTenLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
            }
        }

        private void cbMaLoaiPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private bool ValidateInput(string maPhong, string maLoaiPhong, string soPhong, string tinhTrang)
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(maPhong))
            {
                errorProvider1.SetError(txtMaPhong, "Mã phòng không được để trống.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(maLoaiPhong))
            {
                errorProvider1.SetError(cbMaLoaiPhong, "Mã loại phòng không được để trống.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(soPhong))
            {
                errorProvider1.SetError(txtSoPhong, "Số phòng không được để trống.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(tinhTrang))
            {
                errorProvider1.SetError(cbtinhTrang, "Tình trạng không được để trống.");
                isValid = false;
            }

            return isValid;
        }
        private bool ValidateInput(string maLoaiPhong, string tenPhong, string gia, out float giaValue)
        {
            bool isValid = true;
            giaValue = 0;

            if (string.IsNullOrWhiteSpace(maLoaiPhong))
            {
                errorProvider2.SetError(txtMaLoaiPhong2, "Mã loại phòng không được để trống.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(tenPhong))
            {
                errorProvider2.SetError(txtTenLoaiPhong, "Tên phòng không được để trống.");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(gia))
            {
                errorProvider2.SetError(txtGia, "Giá không được để trống.");
                isValid = false;
            }
            else if (!float.TryParse(gia, out giaValue))
            {
                errorProvider2.SetError(txtGia, "Giá phải là một số hợp lệ.");
                isValid = false;
            }
            else if (giaValue < 0)
            {
                errorProvider2.SetError(txtGia, "Giá phải lớn hơn hoặc bằng 0.");
                isValid = false;
            }
            return isValid;
        }

        public void GioiHanKiTu()
        {
            txtMaPhong.MaxLength = 10;
            txtSoPhong.MaxLength = 3;
            txtMaLoaiPhong2.MaxLength = 10;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            frmTimKiemPhong frmTimKiemPhong = new frmTimKiemPhong();
            frmTimKiemPhong.ShowDialog();
        }

        private void tbPhong_Click(object sender, EventArgs e)
        {

        }

        private void dgvLoaiPhong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmTimKiemPhong frmTimKiemPhong = new frmTimKiemPhong();
            frmTimKiemPhong.ShowDialog();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            string maPhong = txtMaPhong.Text;
            string maLoaiPhong = cbMaLoaiPhong.SelectedValue?.ToString();
            string soPhong = txtSoPhong.Text;
            string tinhTrang = "Trống";

            if (!ValidateInput(maPhong, maLoaiPhong, soPhong, tinhTrang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

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

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;

            if (string.IsNullOrWhiteSpace(maPhong))
            {
                MessageBox.Show("Vui lòng nhập mã phòng cần xóa.");
                return;
            }

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;
            string maLoaiPhong = cbMaLoaiPhong.SelectedValue.ToString();
            string soPhong = txtSoPhong.Text;
            string tinhTrang = cbtinhTrang.Text;

            if (string.IsNullOrWhiteSpace(maPhong) ||
                string.IsNullOrWhiteSpace(maLoaiPhong) ||
                string.IsNullOrEmpty(soPhong) ||
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

        private void button2_Click_2(object sender, EventArgs e)
        {
            frmTimKiemPhong frmTimKiemPhong = new frmTimKiemPhong();
            frmTimKiemPhong.ShowDialog();
        }

        private void dgvDanhSachPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvDanhSachPhong.Rows[e.RowIndex];

                txtMaPhong.Text = row.Cells[0].Value.ToString();
                txtSoPhong.Text = row.Cells[2].Value.ToString();
                string maLoaiPhong = row.Cells[1].Value.ToString();

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

        private void dgvLoaiPhong_CellContentClick_2(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLoaiPhong.Rows[e.RowIndex];

                txtMaLoaiPhong2.Text = row.Cells["MaLoaiPhong"].Value.ToString();
                txtTenLoaiPhong.Text = row.Cells["TenLoaiPhong"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
            }
        }

        private void txtMaPhong_TextChanged(object sender, EventArgs e)
        {
            string maPhong = txtMaPhong.Text;

            if (!string.IsNullOrEmpty(maPhong) && maPhong[0] != 'P')
            {
                errorProvider1.SetError(txtMaPhong, "Mã phòng phải bắt đầu bằng chữ 'P'.");
            }
            else
            {
                errorProvider1.SetError(txtMaPhong, string.Empty);
            }
        }

        private void ccbMaLoaiPhong_TextChanged(object sender, EventArgs e)
        {
            string maPhong = txtMaLoaiPhong2.Text;

            if (!maPhong.StartsWith("LP"))
            {
                errorProvider2.SetError(txtMaLoaiPhong2, "Mã phòng phải bắt đầu bằng 'LP'.");
            }
            else
            {
                errorProvider2.SetError(txtMaLoaiPhong2, string.Empty);
            }
        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {
            string input = txtSoPhong.Text;

            if (string.IsNullOrEmpty(input) || !Regex.IsMatch(input, @"^\d+$"))
            {
                errorProvider1.SetError(txtSoPhong, "Số phòng chỉ được chứa ký tự số.");
            }
            else
            {
                errorProvider1.SetError(txtSoPhong, string.Empty);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmRptDSPhong frmPhong = new frmRptDSPhong();
            frmPhong.Show();
        }
    }
}
