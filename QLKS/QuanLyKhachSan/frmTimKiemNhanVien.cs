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
            List<NhanVien> danhSachNhanVien = new List<NhanVien>();

            if (txtMaNV.Enabled)
            {
                if (txtMaNV.Text == "")
                {
                    if (ValidateForm())
                    {
                        BUS_TimKiemNhanVien.Instance.TimKiemMaNV(txtMaNV, dgvTimKiemNV);
                        //ApplyFilter(danhSachNhanVien);
                    }
                }
                else
                {
                    BUS_TimKiemNhanVien.Instance.TimKiemMaNV(txtMaNV, dgvTimKiemNV);
                    //ApplyFilter(danhSachNhanVien);
                }
            }
            if (txtTenNV.Enabled)
            {
                if (txtTenNV.Text == "")
                {
                    if (ValidateForm())
                    {
                        BUS_TimKiemNhanVien.Instance.TimKiemTenNV(txtTenNV, dgvTimKiemNV);
                        //ApplyFilter(danhSachNhanVien);
                    }
                }
                else
                {
                    BUS_TimKiemNhanVien.Instance.TimKiemTenNV(txtTenNV, dgvTimKiemNV);
                    //ApplyFilter(danhSachNhanVien);
                }
            }

            //if (txtMaNV.Enabled && !string.IsNullOrEmpty(txtMaNV.Text))
            //{
            //    danhSachNhanVien = BUS_TimKiemNhanVien.Instance.TimKiemMaNV(txtMaNV.Text);
            //}
            //else if (txtTenNV.Enabled && !string.IsNullOrEmpty(txtTenNV.Text))
            //{
            //    danhSachNhanVien = BUS_TimKiemNhanVien.Instance.TimKiemTenNV(txtTenNV.Text);
            //}

            //ApplyFilter(danhSachNhanVien);
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

        private void btnFilter_Click(object sender, EventArgs e)
        {
            panelFilterOptions.Location = new Point(btnFilter.Left, btnFilter.Bottom);

            panelFilterOptions.Visible = !panelFilterOptions.Visible;
        }

        private void chkLuongTangDan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLuongTangDan.Checked)
            {
                chkLuongGiamDan.Checked = false;
                BUS_TimKiemNhanVien.Instance.SapXepNhanVienTheoLuong(dgvTimKiemNV, true);
            }
            else
            {
                LoadDataNhanVien();
            }
        }

        private void chkLuongGiamDan_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLuongGiamDan.Checked)
            {
                chkLuongTangDan.Checked = false;
                BUS_TimKiemNhanVien.Instance.SapXepNhanVienTheoLuong(dgvTimKiemNV, false);
            }
            else
            {
                LoadDataNhanVien();
            }
        }
        private void ApplyFilter(List<NhanVien> danhSachNhanVien)
        {
            //if (danhSachNhanVien == null || !danhSachNhanVien.Any())
            //{
            //    MessageBox.Show("Không tìm thấy nhân viên khớp.");
            //    dgvTimKiemNV.DataSource = null;
            //    return;
            //}

            if (chkLuongTangDan.Checked)
            {
                dgvTimKiemNV.DataSource = danhSachNhanVien.OrderBy(nv => nv.Luong).ToList();
            }
            else if (chkLuongGiamDan.Checked)
            {
                dgvTimKiemNV.DataSource = danhSachNhanVien.OrderByDescending(nv => nv.Luong).ToList();
            }
            else
            {
                dgvTimKiemNV.DataSource = danhSachNhanVien;
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            frmNhanVien fr = new frmNhanVien();
            fr.Show();
            this.Close();
        }
    }
}
