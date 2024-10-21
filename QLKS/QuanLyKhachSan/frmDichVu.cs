using BUS;
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
    public partial class frmDichVu : Form
    {
        private ErrorProvider errorProvider1 = new ErrorProvider(); // Khai báo ErrorProvider

        public frmDichVu()
        {

            InitializeComponent();
            LoadDuLieuLenForm();

        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {

        }

        public void LoadDuLieuLenForm()
        {
            LoadDuLieu();
            LoadMaDatPhong();
            LoadMaDichVu();
        }

        private void tbSĐichVu_Click(object sender, EventArgs e)
        {

        }
        public void LoadDuLieu()
        {
            BUS_DanhSachDichVu.Instance.Xem(dgvSuDungDichVu);
        }

        private void cbMaDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void LoadMaDatPhong()
        {
            BUS_DanhSachDichVu.Instance.LoadDatPhong(cbMaDatPhong);
        }
        public void LoadMaDichVu()
        {
            BUS_DanhSachDichVu.Instance.LoadDichVu(cbMaDichVu);
        }
        private void dgvSuDungDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            BUS_DanhSachDichVu.Instance.LoadDGVLenForm(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong, dgvSuDungDichVu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BUS_DanhSachDichVu.Instance.Them(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong);
                LoadDuLieuLenForm();
                ClearFormFields();
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BUS_DanhSachDichVu.Instance.Xoa(txtMaSDDV);
                ClearFormFields();
                LoadDuLieuLenForm();
            }

        }
        // Hàm để làm sạch các trường trong form
        private void ClearFormFields()
        {
            txtMaSDDV.ReadOnly = false;
            txtMaSDDV.Text = string.Empty;
            cbMaDichVu.SelectedIndex = 0;
            cbMaDatPhong.SelectedIndex = 0;
            txtSoLuong.Text = string.Empty;

            // Clear các trường khác nếu cần

        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {

          
            if (ValidateForm())
            {
                txtMaSDDV.ReadOnly = true;
                BUS_DanhSachDichVu.Instance.Sua(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong);
                LoadDuLieuLenForm();
                ClearFormFields();
            }

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {
            ValidateSoLuong();
        }

        private void txtMaSDDV_TextChanged(object sender, EventArgs e)
        {
            ValidateMaSDDV();

        }
        // Hàm kiểm tra toàn bộ form
        private bool ValidateForm()
        {
            ValidateSoLuong(); // Kiểm tra số lượng
            ValidateMaSDDV(); // Kiểm tra mã sử dụng dịch vụ

            // Nếu cả hai không có lỗi thì trả về true, ngược lại là false
            return string.IsNullOrEmpty(errorProvider1.GetError(txtSoLuong)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtMaSDDV));
        }
        // Hàm kiểm tra giá trị trong txtSoLuong
        private void ValidateSoLuong()
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text)) // Nếu rỗng
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng!"); // Đặt lỗi
            }
            else if (!int.TryParse(txtSoLuong.Text, out _)) // Nếu không phải là số
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số hợp lệ!"); // Đặt lỗi nếu không phải số
            }
            else
            {
                errorProvider1.SetError(txtSoLuong, ""); // Xóa lỗi nếu hợp lệ
            }
        }

        // Hàm kiểm tra giá trị trong txtMaSDDV
        private void ValidateMaSDDV()
        {
            if (string.IsNullOrEmpty(txtMaSDDV.Text)) // Nếu rỗng
            {
                errorProvider1.SetError(txtMaSDDV, "Vui lòng nhập mã sử dụng dịch vụ!"); // Đặt lỗi
            }
            else
            {
                errorProvider1.SetError(txtMaSDDV, ""); // Xóa lỗi nếu hợp lệ
            }
        }
    }
}
