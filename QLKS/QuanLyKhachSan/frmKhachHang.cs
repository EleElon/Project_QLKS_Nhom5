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
    public partial class frmKhachHang : Form
    {
        private ErrorProvider errorProvider1 = new ErrorProvider();

        public frmKhachHang()
        {
            InitializeComponent();
            LoadDL();
        }

        public void HienThiDanhSachKhachHang(DataGridView data)
        {

        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TimKiemKhachHang frm = new TimKiemKhachHang();
            frm.Show();
        }
        public void LoadDL()
        {
            LoadDuLieuLen();
            LoadMaDichVu();
        }
        public void LoadDuLieuLen()
        {
            BUS_KhachHang.Instance.Xem(dgvDSKhachHang);
        }
        public void LoadMaDichVu()
        {
            BUS_KhachHang.Instance.LoadDichVu(cbMaDichVu);
        }
        private void btnThemKH_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (!txtSDT.Text.StartsWith("0"))
                {
                    txtSDT.Text = "0" + txtSDT.Text;
                }

                BUS_KhachHang.Instance.Them(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
                LoadDuLieuLen();
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ClearFormFields()
        {
            txtMaKH.Text = string.Empty;
            cbMaDichVu.SelectedIndex = 0;
            txtTenKH.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;

            errorProvider1.SetError(txtMaKH, "");
            errorProvider1.SetError(cbMaDichVu, "");
            errorProvider1.SetError(txtTenKH, "");
            errorProvider1.SetError(txtCCCD, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");

            txtMaKH.Enabled = true;
        }
        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            BUS_KhachHang.Instance.Xoa(txtMaKH);
            LoadDuLieuLen();
            ClearFormFields();
        }
        private void dgvDSKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_KhachHang.Instance.LoadDGVLenForm(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi, dgvDSKhachHang);
            txtMaKH.Enabled = false;

            errorProvider1.SetError(txtMaKH, "");
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                if (!txtSDT.Text.StartsWith("0"))
                {
                    txtSDT.Text = "0" + txtSDT.Text;
                }

                BUS_KhachHang.Instance.Sua(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
                LoadDuLieuLen();
                txtMaKH.Enabled = true;
            }
            else
            {
                txtMaKH.Enabled = true;
            }
        }

        private void ValidateSDT()
        {
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại!");
            }
            else if (txtSDT.Text.Length != 10 || !Regex.IsMatch(txtSDT.Text, @"^0[0-9]{9}$"))
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại không hợp lệ! (phải có 10 chữ số và bắt đầu bằng 0)");
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }
        }
        private void ValidateEmail()
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập email!");
            }
            else if (!txtEmail.Text.Contains("@"))
            {
                errorProvider1.SetError(txtEmail, "Email phải chứa ký tự '@'!");
            }

            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtEmail, "Email không hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }
        }
        private bool ValidateFormFields()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                errorProvider1.SetError(txtTenKH, "Vui lòng nhập tên khách hàng!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtTenKH, "");
            }

            if (string.IsNullOrEmpty(txtCCCD.Text) || !Regex.IsMatch(txtCCCD.Text, @"^[0-9]{12}$"))
            {
                errorProvider1.SetError(txtCCCD, "Vui lòng nhập CCCD hợp lệ (12 chữ số)!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtCCCD, "");
            }

            if (string.IsNullOrEmpty(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập email hợp lệ!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            if (string.IsNullOrEmpty(txtSDT.Text) || !Regex.IsMatch(txtSDT.Text, @"^[0-9]{10}$"))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại hợp lệ (10 chữ số)!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }

            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập địa chỉ!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, "");
            }

            return isValid;
        }

        private bool ValidateForm()
        {
            if (txtMaKH.Enabled)
            {
                ValidateMaKH();
            }

            ValidateEmail();
            ValidateSDT();
            ValidateCCCD();
            ValidateFormFields();

            return string.IsNullOrEmpty(errorProvider1.GetError(txtMaKH))
                && string.IsNullOrEmpty(errorProvider1.GetError(cbMaDichVu))
                && string.IsNullOrEmpty(errorProvider1.GetError(txtTenKH))
                && string.IsNullOrEmpty(errorProvider1.GetError(txtCCCD))
                && string.IsNullOrEmpty(errorProvider1.GetError(txtEmail))
                && string.IsNullOrEmpty(errorProvider1.GetError(txtSDT))
                && string.IsNullOrEmpty(errorProvider1.GetError(txtDiaChi));
        }
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            ValidateSDT();
        }

        private void txtMaKH_Leave(object sender, EventArgs e)
        {
            if (!txtMaKH.Enabled)
            {
                errorProvider1.SetError(txtMaKH, "");
                return;
            }

            ValidateMaKH();
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
            if (!txtMaKH.Enabled)
            {
                errorProvider1.SetError(txtMaKH, "");
                return;
            }

            ValidateMaKH();
        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                errorProvider1.SetError(txtTenKH, "Vui lòng nhập tên khách hàng!");
            }
            else
            {
                errorProvider1.SetError(txtTenKH, "");
            }
        }

        private void txtCCCD_TextChanged(object sender, EventArgs e)
        {
            ValidateCCCD();
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            ValidateSDT();
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            ValidateDiaChi();
        }
        private void ValidateMaKH()
        {
            if (!txtMaKH.Enabled)
            {
                errorProvider1.SetError(txtMaKH, "");
                return;
            }
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                errorProvider1.SetError(txtMaKH, "Vui lòng nhập mã khách hàng!");
            }
            else if (BUS_KhachHang.Instance.CheckMaExists(txtMaKH.Text))
            {
                errorProvider1.SetError(txtMaKH, "Mã khách hàng đã tồn tại, vui lòng nhập mã khác!");
            }
            else
            {
                errorProvider1.SetError(txtMaKH, "");
            }
        }
        private void ValidateCCCD()
        {
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                errorProvider1.SetError(txtCCCD, "Vui lòng nhập CCCD!");
            }
            else if (!Regex.IsMatch(txtCCCD.Text, @"^0[0-9]{11}$"))
            {
                errorProvider1.SetError(txtCCCD, "CCCD không hợp lệ! Phải có 12 chữ số và bắt đầu bằng 0!");
            }
            else
            {
                errorProvider1.SetError(txtCCCD, "");
            }
        }

        private void txtCCCD_Leave(object sender, EventArgs e)
        {
            ValidateCCCD();
        }

        private void txtEmail_Leave(object sender, EventArgs e)
        {
            ValidateEmail();
        }

        private void txtDiaChi_Leave(object sender, EventArgs e)
        {

        }
        private void ValidateDiaChi()
        {
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập dia chi!");
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, "");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaKH.Text = "";
            cbMaDichVu.SelectedIndex = 0;
            txtTenKH.Text = "";
            txtCCCD.Text = "";
            txtEmail.Text = "";
            txtSDT.Text = "";
            txtDiaChi.Text = "";

            txtMaKH.Enabled = true;

            errorProvider1.SetError(txtMaKH, "");
            errorProvider1.SetError(cbMaDichVu, "");
            errorProvider1.SetError(txtTenKH, "");
            errorProvider1.SetError(txtCCCD, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");
        }
    }
}
