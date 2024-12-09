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
    public partial class frmDichVu : Form
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();
        BUS_LoaiDichVu bus_ldv = new BUS_LoaiDichVu();
        BUS_DichVu bus_dv = new BUS_DichVu();

        public frmDichVu()
        {
            InitializeComponent();
            LoadDuLieuLenForm();
            LoadFormLDV();
            LoadFormDV();
            FormLoaiDichVuDataBinding();
            FormDichVuDataBinding();
        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {

        }

        private void FormLoaiDichVuDataBinding()
        {
            txtMaLoaiDV.MaxLength = 10;
            txtTenLDV.MaxLength = 50;
        }

        private void FormDichVuDataBinding()
        {
            txtMaDV.MaxLength = 10;
            txtTenDV.MaxLength = 100;
            txtGia.MaxLength = 9;
        }


        public void LoadDuLieuLenForm()
        {
            LoadDuLieu();
            LoadMaDatPhong();
            LoadMaDichVu();
        }
        public void LoadFormDV()
        {
            LoadDuLieuDV();
            LoadMaLoaiDichVu();
        }
        public void LoadFormLDV()
        {
            LoadDuLieuLDV();
            LoadMaLoaiPhong();
        }
        private void tbSĐichVu_Click(object sender, EventArgs e)
        {

        }
        public void LoadDuLieu()
        {
            BUS_DanhSachDichVu.Instance.Xem(dgvSuDungDichVu);
        }
        public void LoadDuLieuLDV()
        {
            BUS_LoaiDichVu.Instance.Xem(dataGridViewLoaiDichVu);
        }
        public void LoadDuLieuDV()
        {
            BUS_DichVu.Instance.Xem(dataGridViewDichVu);
        }

        private void cbMaDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void LoadMaLoaiPhong()
        {
            BUS_LoaiDichVu.Instance.LoadMaLoaiPhong(cboMaLoaiPhong);
        }
        public void LoadMaDatPhong()
        {
            BUS_DanhSachDichVu.Instance.LoadDatPhong(cbMaDatPhong);
        }
        public void LoadMaDichVu()
        {
            BUS_DanhSachDichVu.Instance.LoadDichVu(cbMaDichVu);
        }
        public void LoadMaLoaiDichVu()
        {
            BUS_DichVu.Instance.LoadMaLoaiDV(cbLoaiDichVu);
        }
        private void dgvSuDungDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_DanhSachDichVu.Instance.LoadDGVLenForm(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong, txtGiaSD, dgvSuDungDichVu);
            txtMaSDDV.Enabled = false;
            errorProvider1.SetError(txtMaSDDV, "");
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BUS_DanhSachDichVu.Instance.Them(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong, txtGiaSD);
                LoadDuLieuLenForm();
            }
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BUS_DanhSachDichVu.Instance.Xoa(txtMaSDDV);
                LoadDuLieuLenForm();
            }
        }
        private void ClearFormFields()
        {
            txtMaSDDV.Enabled = true;
            txtMaSDDV.Text = string.Empty;
            cbMaDichVu.SelectedIndex = 0;
            cbMaDatPhong.SelectedIndex = 0;
            txtSoLuong.Text = string.Empty;

            txtMaLoaiDV.Enabled = true;
            txtMaLoaiDV.Text = string.Empty;
            txtTenLDV.Text = string.Empty;
            cboMaLoaiPhong.SelectedIndex = 0;

            txtMaDV.Enabled = true;
            txtMaDV.Text = string.Empty;
            cbLoaiDichVu.SelectedIndex = 0;
            txtTenDV.Text = string.Empty;
            txtGia.Text = string.Empty;

            errorProvider1.SetError(txtMaDV, "");
            errorProvider1.SetError(txtTenDV, "");
            errorProvider1.SetError(txtGia, "");

            errorProvider1.SetError(txtMaLoaiDV, "");
            errorProvider1.SetError(txtTenLDV, "");
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BUS_DanhSachDichVu.Instance.Sua(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong, txtGiaSD);
                LoadDuLieuLenForm();
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
        private bool ValidateForm()
        {
            ValidateSoLuong();

            return string.IsNullOrEmpty(errorProvider1.GetError(txtSoLuong)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtMaSDDV));
        }
        private void ValidateSoLuong()
        {
            if (string.IsNullOrEmpty(txtSoLuong.Text))
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số lượng!");
            }
            else if (!int.TryParse(txtSoLuong.Text, out _))
            {
                errorProvider1.SetError(txtSoLuong, "Vui lòng nhập số hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtSoLuong, "");
            }
        }

        private void ValidateMaSDDV()
        {
            if (string.IsNullOrEmpty(txtMaSDDV.Text))
            {
                errorProvider1.SetError(txtMaSDDV, "Vui lòng nhập mã sử dụng dịch vụ!");
            }
            else if (BUS_DanhSachDichVu.Instance.CheckMaSDDVExists(txtMaSDDV.Text))
            {
                errorProvider1.SetError(txtMaSDDV, "Mã sử dụng dịch vụ đã tồn tại, vui lòng nhập mã khác!");
            }
            else
            {
                errorProvider1.SetError(txtMaSDDV, "");
            }
        }
        private bool ValidateFormLoaiDV()
        {
            ValidateTenLDV();

            return string.IsNullOrEmpty(errorProvider1.GetError(txtMaLoaiDV)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtTenLDV));
        }
        private void ValidateMaLDV()
        {
            string pattern = @"^(ldv|LDV)[0-9]+$";

            if (string.IsNullOrEmpty(txtMaLoaiDV.Text))
            {
                errorProvider1.SetError(txtMaLoaiDV, "Vui lòng nhập mã loại dịch vụ! Mã phải bắt đầu bằng 'ldv / LDV' và theo sau là số giới hạn 10 ký tự");
            }
            else if (BUS_LoaiDichVu.Instance.CheckMaLDVExists(txtMaLoaiDV.Text))
            {
                errorProvider1.SetError(txtMaLoaiDV, "Mã loại dịch vụ đã tồn tại!");
            }
            else if (!Regex.IsMatch(txtMaLoaiDV.Text, pattern))
            {
                errorProvider1.SetError(txtMaLoaiDV, "Mã loại dịch vụ không hợp lệ! Mã phải bắt đầu bằng 'ldv / LDV' và theo sau là số");
            }
            else
            {
                errorProvider1.SetError(txtMaLoaiDV, "");
            }
        }
        private void ValidateTenLDV()
        {
            string pattern = @"^[^!@#\$%\^*_\-\+=]+$";

            if (string.IsNullOrEmpty(txtTenLDV.Text))
            {
                errorProvider1.SetError(txtTenLDV, "Vui lòng nhập tên loại dịch vụ!");
            }
            else if (!Regex.IsMatch(txtTenLDV.Text, pattern))
            {
                errorProvider1.SetError(txtTenLDV, "Tên loại dịch vụ không được chứa các ký tự đặc biệt ! @ # $ % ^ * _ - + =");
            }
            else
            {
                errorProvider1.SetError(txtTenLDV, "");
            }
        }
        private bool ValidateFormDV()
        {
            ValidateTenDV();
            ValidateGia();

            return string.IsNullOrEmpty(errorProvider1.GetError(txtMaDV)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtTenDV)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtGia));
        }
        private void ValidateMaDV()
        {
            string pattern = @"^(dv|DV)[0-9]+$";

            if (string.IsNullOrEmpty(txtMaDV.Text))
            {
                errorProvider1.SetError(txtMaDV, "Vui lòng nhập mã dịch vụ! Mã phải bắt đầu bằng 'dv / DV' theo sau là chữ số giới hạn 10 ký tự");
            }
            else if (BUS_DichVu.Instance.CheckMaDVExists(txtMaDV.Text))
            {
                errorProvider1.SetError(txtMaDV, "Mã dịch vụ đã tồn tại!");
            }
            else if (!Regex.IsMatch(txtMaDV.Text, pattern))
            {
                errorProvider1.SetError(txtMaDV, "Mã dịch vụ không hợp lệ! Mã phải bắt đầu bằng 'dv / DV' theo sau là chữ số");
            }
            else
            {
                errorProvider1.SetError(txtMaDV, "");
            }
        }
        private void ValidateTenDV()
        {
            string pattern = @"^[^!@#\$%\^*_\-\+=]+$";

            if (string.IsNullOrEmpty(txtTenDV.Text))
            {
                errorProvider1.SetError(txtTenDV, "Vui lòng nhập tên dịch vụ! Tên dịch vụ không được chứa các ký tự đặc biệt ! @ # $ % ^ * _ - + = giới hạn 100 ký tự");
            }
            else if (!Regex.IsMatch(txtTenDV.Text, pattern))
            {
                errorProvider1.SetError(txtTenDV, "Tên dịch vụ không hợp lệ! Tên dịch vụ không được chứa các ký tự đặc biệt ! @ # $ % ^ * _ - + =");
            }
            else
            {
                errorProvider1.SetError(txtTenDV, "");
            }
        }
        private void ValidateGia()
        {
            if (string.IsNullOrEmpty(txtGia.Text))
            {
                errorProvider1.SetError(txtGia, "Vui lòng nhập giá!");
            }
            else if (!int.TryParse(txtGia.Text, out int gia))
            {
                errorProvider1.SetError(txtGia, "Vui lòng nhập số hợp lệ từ 0 - 999999999");
            }
            else if (gia < 0)
            {
                errorProvider1.SetError(txtGia, "Giá không thể là số âm");
            }
            else
            {
                errorProvider1.SetError(txtGia, "");
            }
        }
        private void btnThoatt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThoatLDV_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemLDV_Click(object sender, EventArgs e)
        {
            if (ValidateFormLoaiDV())
            {
                string maLDV = txtMaLoaiDV.Text;
                string tenLDV = txtTenLDV.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(maLDV, @"^(ldv|LDV)\d+$"))
                {
                    maLDV = "LDV" + maLDV.Substring(3);
                    txtMaLoaiDV.Text = maLDV;
                }
                else
                {
                    MessageBox.Show("Mã loại dịch vụ phải bắt đầu bằng 'dv' hoặc 'DV' và theo sau là số.");
                    return;
                }

                BUS_LoaiDichVu.Instance.ThemLDV(txtMaLoaiDV, txtTenLDV, cboMaLoaiPhong);
                LoadDuLieuLDV();
                ClearFormFields();
                LoadMaLoaiDichVu();
            }
        }

        private void btnXoaLDV_Click(object sender, EventArgs e)
        {
            if (ValidateFormLoaiDV())
            {
                BUS_LoaiDichVu.Instance.XoaLDV(txtMaLoaiDV);
                LoadDuLieuLDV();
                ClearFormFields();
                LoadMaLoaiDichVu();
            }
        }

        private void btnCapNhatLDV_Click(object sender, EventArgs e)
        {
            if (ValidateFormLoaiDV())
            {
                BUS_LoaiDichVu.Instance.Sua(txtMaLoaiDV, txtTenLDV, cboMaLoaiPhong);
                LoadDuLieuLDV();
                ClearFormFields();
                LoadMaLoaiDichVu();
            }
        }

        private void dataGridViewLoaiDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_LoaiDichVu.Instance.LoadDGVLenForm(txtMaLoaiDV, txtTenLDV, cboMaLoaiPhong, dataGridViewLoaiDichVu);

            txtMaLoaiDV.Enabled = false;
            errorProvider1.SetError(txtMaLoaiDV, "");
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThemDV_Click(object sender, EventArgs e)
        {
            string maDV = txtMaDV.Text;

            if (System.Text.RegularExpressions.Regex.IsMatch(maDV, @"^(dv|DV)\d+$"))
            {
                maDV = "DV" + maDV.Substring(2);
                txtMaDV.Text = maDV;
            }
            else
            {
                MessageBox.Show("Mã dịch vụ phải bắt đầu bằng 'dv' hoặc 'DV' và theo sau là số.");
                return;
            }

            if (ValidateFormDV())
            {
                BUS_DichVu.Instance.ThemDV(txtMaDV, cbLoaiDichVu, txtTenDV, txtGia);
                LoadDuLieuDV();
                ClearFormFields();
            }
        }

        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            if (ValidateFormDV())
            {
                BUS_DichVu.Instance.XoaDV(txtMaDV);
                LoadDuLieuDV();
                ClearFormFields();
            }
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (ValidateFormDV())
            {
                BUS_DichVu.Instance.SuaDV(txtMaDV, cbLoaiDichVu, txtTenDV, txtGia);
                LoadDuLieuDV();
                ClearFormFields();
            }
        }

        private void dataGridViewDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_DichVu.Instance.LoadDGVLenForm(txtMaDV, cbLoaiDichVu, txtTenDV, txtGia, dataGridViewDichVu);

            txtMaDV.Enabled = false;
            errorProvider1.SetError(txtMaDV, "");
        }
        private void CheckEmptyFields()
        {
            if (string.IsNullOrEmpty(txtTenDV.Text) || string.IsNullOrEmpty(txtGia.Text))
            {
                txtMaDV.ReadOnly = false;
                ValidateFormDV();
            }
        }

        private void txtMaLoaiDV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaLoaiDV.Enabled)
            {
                ValidateMaLDV();
            }
        }

        private void txtTenLDV_TextChanged(object sender, EventArgs e)
        {
            ValidateTenLDV();
        }

        private void txtMaDV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaDV.Enabled)
            {
                ValidateMaDV();
            }
        }

        private void txtTenDV_TextChanged(object sender, EventArgs e)
        {
            ValidateTenDV();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {
            ValidateGia();
        }

        private void btnLamMoiDV_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void btnLamMoiLDV_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void btnLamMoiDSSDDV_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void frmDichVu_Load_1(object sender, EventArgs e)
        {

        }

        private void cbMaDichVu_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            frmRptDichVu fr = new frmRptDichVu();
            fr.Show();
        }

        private void txtTenDV_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtTenDV);
        }

        private void MoveCursorToEnd(TextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
        }

        private void txtGia_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtGia);
        }

        private void txtTenLDV_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtTenLDV);
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }
    }
}
