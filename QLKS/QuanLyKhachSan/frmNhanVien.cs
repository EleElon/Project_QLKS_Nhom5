using BUS;
using DAO;
using System;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmNhanVien : Form
    {
        private FrmMain mainForm;

        private ErrorProvider errorProvider = new ErrorProvider();
        BUS_NhanVien bus_nv = new BUS_NhanVien();

        public frmNhanVien(FrmMain frmMain)
        {
            InitializeComponent();
            this.mainForm = frmMain;
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
            radNam.Checked = false;
            radNu.Checked = false;
            dtpNgaySinh.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtChucVu.Text = string.Empty;
            txtDiaChi.Text = string.Empty;

            errorProvider.SetError(txtMaNV, "");
            errorProvider.SetError(txtTenNV, "");
            errorProvider.SetError(txtChucVu, "");
            errorProvider.SetError(radNam, "");
            errorProvider.SetError(radNu, "");
            errorProvider.SetError(dtpNgaySinh, "");
            errorProvider.SetError(txtSDT, "");
            errorProvider.SetError(txtChucVu, "");
            errorProvider.SetError(txtDiaChi, "");
        }
        public void FormNhanVienDataBinding()
        {
            txtMaNV.MaxLength = 10;
            txtTenNV.MaxLength = 100;
            txtSDT.MaxLength = 10;
            txtChucVu.MaxLength = 50;
            txtDiaChi.MaxLength = 200;
        }
        private bool ValidateForm()
        {
            ValidateTenNV();
            ValidateGioiTinh();
            ValidateNgaySinh();
            ValidateSDT();
            ValidateChucVu();
            ValidateDiaChi();

            return string.IsNullOrEmpty(errorProvider.GetError(txtMaNV)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtTenNV)) &&
                string.IsNullOrEmpty(errorProvider.GetError(radNu)) &&
                string.IsNullOrEmpty(errorProvider.GetError(dtpNgaySinh)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtSDT)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtChucVu)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtDiaChi));
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
        private void ValidateGioiTinh()
        {
            if (!radNam.Checked && !radNu.Checked)
            {
                errorProvider.SetError(radNu, "Vui lòng chọn giới tính");
            }
            else
            {
                errorProvider.SetError(radNu, "");
            }
        }
        private void ValidateNgaySinh()
        {
            DateTime minDate = new DateTime(DateTime.Now.Year - 80, 1, 1);
            DateTime maxDate = DateTime.Now;

            if (dtpNgaySinh.Value < minDate)
            {
                errorProvider.SetError(dtpNgaySinh, $"Ngày sinh không được nhỏ hơn {minDate.ToShortDateString()}");
            }
            else if (dtpNgaySinh.Value > maxDate)
            {
                errorProvider.SetError(dtpNgaySinh, "Ngày sinh không được lớn hơn ngày hiện tại");
            }
            else
            {
                errorProvider.SetError(dtpNgaySinh, "");
            }
        }
        private void ValidateSDT()
        {
            string pattern = @"^0[0-9]+$";

            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errorProvider.SetError(txtSDT, "Vui lòng nhập số điện thoại");
            }
            else if (!Regex.IsMatch(txtSDT.Text, pattern))
            {
                errorProvider.SetError(txtSDT, "Số điện thoại phải bắt đầu bằng số 0");
            }
            else if (txtSDT.Text.Length != 10)
            {
                errorProvider.SetError(txtSDT, "Số điện thoại phải có đủ 10 số");
            }
            else
            {
                errorProvider.SetError(txtSDT, "");
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
        private void ValidateDiaChi()
        {
            string pattern = @"^[^!@#\$%\^*_\-\+=]+$";

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                errorProvider.SetError(txtDiaChi, "Vui lòng nhập địa chỉ");
            }
            else if (!Regex.IsMatch(txtDiaChi.Text, pattern))
            {
                errorProvider.SetError(txtDiaChi, "Vui lòng nhập địa chỉ hợp lệ, địa chỉ không bao gồm ký tự đặt biệt ! @ # $ % ^ * _ - + = ");
            }
            else
            {
                errorProvider.SetError(txtDiaChi, "");
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
                    a.gioiTinh,
                    a.ngaySinh,
                    a.SDT,
                    a.ChucVu,
                    a.diaChi
                }).ToList();
                data.DataSource = nhanVien;
            }
        }

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
                    MessageBox.Show("Mã nhân viên phải bắt đầu bằng 'nv' hoặc 'NV' và theo sau là số.");
                    return;
                }

                BUS_NhanVien.Instance.ThemNhanVien(txtMaNV, cboMaPhong, txtTenNV, radNam, radNu, dtpNgaySinh, txtSDT, txtChucVu, txtDiaChi);
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
                string gioiTinh = radNam.Checked ? "Nam" : "Nu";
                string SDT = txtSDT.Text;
                DateTime ngaySinh = dtpNgaySinh.Value;
                string chucVu = txtChucVu.Text;
                string diachi = txtDiaChi.Text;

                bool result = bus_nv.SuaNhanVien(maNV, maPhong, tenNV, gioiTinh, ngaySinh, SDT, chucVu, diachi);
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
            BUS_NhanVien.Instance.LoadDGVLenForm(txtMaNV, cboMaPhong, txtTenNV, radNam, radNu, dtpNgaySinh, txtSDT, txtChucVu, txtDiaChi, dgvNhanVien);

            txtMaNV.Enabled = false;
            errorProvider.SetError(txtMaNV, "");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFormField();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            ValidateMaNV();
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
            ValidateDiaChi();
        }

        public void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemNhanVien frTimKiem = new frmTimKiemNhanVien(mainForm);
            frTimKiem.TopLevel = false;
            frTimKiem.Dock = DockStyle.Fill;
            mainForm.pnMain.Controls.Add(frTimKiem);
            frTimKiem.Show();
            this.Hide();
        }

        private void frmNhanVien_Resize(object sender, EventArgs e)
        {
            int formWidth = this.ClientSize.Width;
            int leftRightMargin = 20;
            int buttonWidth = btnThoat.Width;
            int groupBoxWidth = groupBox1.Width;
            int buttonSpacing = (formWidth - 2 * leftRightMargin - 6 * buttonWidth) / 5;
            int groupBoxSpacing = (formWidth - 2 * leftRightMargin - 2 * groupBoxWidth) / 1;

            int baseTop = 700;
            int additionalOffset = 10;

            btnThoat.Left = leftRightMargin;
            btnThoat.Top = baseTop + additionalOffset;

            btnThem.Left = btnThoat.Right + buttonSpacing;
            btnThem.Top = baseTop + additionalOffset;

            btnXoa.Left = btnThem.Right + buttonSpacing;
            btnXoa.Top = baseTop + additionalOffset;

            btnSua.Left = btnXoa.Right + buttonSpacing;
            btnSua.Top = baseTop + additionalOffset;

            btnLamMoi.Left = btnSua.Right + buttonSpacing;
            btnLamMoi.Top = baseTop + additionalOffset;

            btnTimKiem.Left = btnLamMoi.Right + buttonSpacing;
            btnTimKiem.Top = baseTop + additionalOffset;
        }
        private void txtTenNV_Click_1(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtTenNV);
        }

        private void txtChucVu_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtChucVu);
        }

        private void txtLuong_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtDiaChi);
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            ValidateSDT();
        }

        private void dtpNgaySinh_ValueChanged(object sender, EventArgs e)
        {
            ValidateNgaySinh();
        }

        private void radNu_CheckedChanged(object sender, EventArgs e)
        {
            ValidateGioiTinh();
        }

        private void radNam_CheckedChanged(object sender, EventArgs e)
        {
            ValidateGioiTinh();
        }

        private void txtSDT_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtSDT);
        }

        private void MoveCursorToEnd(TextBox textBox)
        {
            textBox.SelectionStart = textBox.Text.Length;
        }
    }
}
