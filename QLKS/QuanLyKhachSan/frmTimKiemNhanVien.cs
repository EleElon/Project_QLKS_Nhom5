using BUS;
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
    public partial class frmTimKiemNhanVien : Form
    {
        private ErrorProvider errorProvider = new ErrorProvider();
        public frmTimKiemNhanVien()
        {
            InitializeComponent();
            LoadDataNhanVien();
        }
        public void LoadDataNhanVien()
        {
            BUS_NhanVien.Instance.View(dgvTimKiemNV);
        }
        private bool ValidateForm()
        {
            ValidateMaNVField();
            ValidateTenNVField();

            return string.IsNullOrEmpty(errorProvider.GetError(txtMaNV)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtTenNV));
        }
        private void ValidateMaNVField()
        {
            if (string.IsNullOrEmpty(txtMaNV.Text))
            {
                errorProvider.SetError(txtMaNV, "Vui lòng nhập mã nhân viên");
            }
        }
        private void ValidateTenNVField()
        {
            if (string.IsNullOrEmpty(txtTenNV.Text))
            {
                errorProvider.SetError(txtTenNV, "Vui lòng nhập tên nhân viên");
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Enabled)
            {
                if (txtMaNV.Text == "")
                {
                    if (ValidateForm())
                    {
                        BUS_TimKiemNhanVien.Instance.TimKiemMaNV(txtMaNV, dgvTimKiemNV);
                    }
                }
                else
                {
                    BUS_TimKiemNhanVien.Instance.TimKiemMaNV(txtMaNV, dgvTimKiemNV);
                }
            }
            if (txtTenNV.Enabled)
            {
                if (txtTenNV.Text == "")
                {
                    if (ValidateForm())
                    {
                        BUS_TimKiemNhanVien.Instance.TimKiemTenNV(txtTenNV, dgvTimKiemNV);
                    }
                }
                else
                {
                    BUS_TimKiemNhanVien.Instance.TimKiemTenNV(txtTenNV, dgvTimKiemNV);
                }
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = true;
            txtTenNV.Enabled = true;
            txtMaNV.Text = "";
            txtTenNV.Text = "";
            LoadDataNhanVien();
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Length > 0)
            {
                txtTenNV.Enabled = false;
                txtTenNV.Text = "";
                errorProvider.SetError(txtTenNV, "");
                errorProvider.SetError(txtMaNV, "");
            }
        }

        private void txtTenNV_TextChanged(object sender, EventArgs e)
        {
            if (txtTenNV.Text.Length > 0)
            {
                txtMaNV.Enabled = false;
                txtMaNV.Text = "";
                errorProvider.SetError(txtMaNV, "");
                errorProvider.SetError(txtTenNV, "");
            }
        }
    }
}
