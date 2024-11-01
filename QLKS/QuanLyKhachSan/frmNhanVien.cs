using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmNhanVien : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        BUS_NhanVien bus_nv = new BUS_NhanVien();
        public frmNhanVien()
        {
            InitializeComponent();
        }
        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            LoadDataNV();
            LoadComboMaPhong();
            FormNhanVienDataBinding();
        }
        public void ClearFormField()
        {
            txtMaNV.Enabled = true;
            txtMaNV.Text = string.Empty;
            cboMaPhong.SelectedIndex = 0;
            txtTenNV.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            txtLuong.Text = string.Empty;

            //Set error == null
            errorProvider.SetError(txtMaNV, "");
            errorProvider.SetError(txtTenNV, "");
            errorProvider.SetError(txtChucVu, "");
            errorProvider.SetError(txtLuong, "");
        }
        public void FormNhanVienDataBinding()
        {
            txtMaNV.MaxLength = 10;
            txtTenNV.MaxLength = 100;
            txtChucVu.MaxLength = 50;
            txtLuong.MaxLength = 9;
        }
        private bool ValidateForm()
        {
            ValidateTenNV();
            ValidateChucVu();
            ValidateLuong();

            return string.IsNullOrEmpty(errorProvider.GetError(txtMaNV)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtTenNV)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtChucVu)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtLuong));
        }
        private void ValidateMaNV()
        {
            string pattern = @"^(nv|NV)[0-9]+$";

            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                errorProvider.SetError(txtMaNV, "Vui lòng nhập mã nhân viên! bắt đầu từ NV / nv sau đó là ký tự số");
            }
            else if (BUS_NhanVien.instance.CheckMaNVExists(txtMaNV.Text))
            {
                errorProvider.SetError(txtMaNV, "Mã nhân viên đã tồn tại");
            }
            else if (!Regex.IsMatch(txtMaNV.Text, pattern))
            {
                errorProvider.SetError(txtMaNV, "Mã nhân viên phải bắt đầu từ NV / nv sau đó là ký tự số");
            }
            else
            {
                errorProvider.SetError(txtMaNV, "");
            }
        }
        private void ValidateTenNV()
        {
            string pattern = @"^[^!@#\$%\^*_\-\+=]+$";

            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                errorProvider.SetError(txtTenNV, "Vui lòng nhập tên nhân viên");
            }
            else if (!Regex.IsMatch(txtTenNV.Text, pattern))
            {
                errorProvider.SetError(txtTenNV, "Tên nhân viên không được chứa các ký tự đặc biệt ! @ # $ % ^ * _ - + = ");
            }
            else
            {
                errorProvider.SetError(txtTenNV, "");
            }
        }
        private void ValidateChucVu()
        {
            string pattern = @"^[^!@#\$%\^*_\-\+=]+$";

            if (string.IsNullOrEmpty(txtChucVu.Text))
            {
                errorProvider.SetError(txtChucVu, "Vui lòng nhập chức vụ");
            }
            else if (!Regex.IsMatch(txtChucVu.Text, pattern))
            {
                errorProvider.SetError(txtChucVu, "Tên chức vụ không được chứa các ký tự đặt biệt ! @ # $ % ^ * _ - + = ");
            }
            else
            {
                errorProvider.SetError(txtChucVu, "");
            }
        }
        private void ValidateLuong()
        {
            if (string.IsNullOrEmpty(txtLuong.Text))
            {
                errorProvider.SetError(txtLuong, "Vui lòng nhập lương");
            }
            else if (!int.TryParse(txtLuong.Text, out int luong))
            {
                errorProvider.SetError(txtLuong, "Vui lòng nhập số hợp lệ");
            }
            else if (luong < 0)
            {
                errorProvider.SetError(txtLuong, "Lương không thể là số âm");
            }
            else
            {
                errorProvider.SetError(txtLuong, "");
            }
        }
        public void LoadComboMaPhong()
        {
            BUS_NhanVien.instance.LoadMaPhong(cboMaPhong);
        }
        public void LoadDataNV()
        {
            BUS_NhanVien.Instance.View(dgvNhanVien);
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

        //public void LoadView()
        //{
        //    dgvNhanVien.DataSource = bus_nv.View();
        //}

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maNV = txtMaNV.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(maNV, @"^(nv|NV)\d+$"))
                {
                    maNV = "NV" + maNV.Substring(2);
                    txtMaNV.Text = maNV;
                }
                else
                {
                    MessageBox.Show("Mã dịch vụ phải bắt đầu bằng 'dv' hoặc 'DV' và theo sau là số.");
                    return;
                }

                BUS_NhanVien.Instance.ThemNhanVien(txtMaNV, cboMaPhong, txtTenNV, txtChucVu, txtLuong);
                LoadDataNV();
                ClearFormField();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maNV = txtMaNV.Text;
                bool result = bus_nv.XoaNhanVien(maNV);
                if (result)
                {
                    MessageBox.Show("Xóa nhân viên thành công.");
                    LoadDataNV();
                    ClearFormField();
                }
                else
                {
                    MessageBox.Show("Xóa nhân viên không thành công. Không tìm thấy nhân viên.");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
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
                    LoadDataNV();
                    ClearFormField();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin nhân viên không thành công. Không tìm thấy nhân viên.");
                }
            }
        }

        private void dgvNhanVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_NhanVien.Instance.LoadDGVLenForm(txtMaNV, cboMaPhong, txtTenNV, txtChucVu, txtLuong, dgvNhanVien);

            txtMaNV.Enabled = false;
            errorProvider.SetError(txtMaNV, "");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFormField();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNV.Enabled)
            {
                ValidateMaNV();
            }
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            ValidateTenNV();
        }

        private void txtChucVu_TextChanged(object sender, EventArgs e)
        {
            ValidateChucVu();
        }

        private void txtLuong_TextChanged(object sender, EventArgs e)
        {
            ValidateLuong();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemNhanVien fr = new frmTimKiemNhanVien();
            fr.Show();
            this.Close();
        }
    }
}
