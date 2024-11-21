using BUS;
using DAO;
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
using System.Windows.Media.Animation;
using System.Xml.Serialization;

namespace QuanLyKhachSan
{
    public partial class frmLuong : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        BUS_Luong bus_luong = new BUS_Luong();
        public frmLuong()
        {
            InitializeComponent();
        }
        public void FormDataBiding()
        {
            txtMaLuong.MaxLength = 10;
            txtThang.MaxLength = 2;
            txtSoTien.MaxLength = 9;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            //DSLuong(dgvDSLuong);
            LoadDataLuong();
            LoadComboNhanVien();
            FormDataBiding();
        }

        public void LoadDataLuong()
        {
            BUS_Luong.Instance.Xem(dgvDSLuong);
        }
        public void LoadComboNhanVien()
        {
            BUS_Luong.Instance.LoadMaNV(cboMaNhanVien);
        }
        public void ClearFormFields()
        {
            txtMaLuong.Enabled = true;
            txtMaLuong.Text = string.Empty;
            cboMaNhanVien.SelectedIndex = 0;
            txtThang.Text = string.Empty;
            txtSoTien.Text = string.Empty;

            //set validate == null
            errorProvider.SetError(txtMaLuong, "");
            errorProvider.SetError(txtThang, "");
            errorProvider.SetError(txtSoTien, "");
        }
        private bool ValidateForm()
        {
            ValidateThang();
            ValidateSoTien();

            return string.IsNullOrEmpty(errorProvider.GetError(txtMaLuong)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtThang)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtSoTien));
        }
        private void ValidateMaLuong()
        {
            string pattern = @"^(l|L)[0-9]+$";

            if (string.IsNullOrEmpty(txtMaLuong.Text))
            {
                errorProvider.SetError(txtMaLuong, "Vui lòng nhập mã lương! Bắt đầu từ l / L sau đó là ký tự số");
            }
            else if (BUS_Luong.Instance.CheckMaLuongExists(txtMaLuong.Text))
            {
                errorProvider.SetError(txtMaLuong, "Mã lương đã tồn tại");
            }
            else if (!Regex.IsMatch(txtMaLuong.Text, pattern))
            {
                errorProvider.SetError(txtMaLuong, "Mã lương phải bắt đầu từ l / L sau đó là ký tự sô");
            }
            else
            {
                errorProvider.SetError(txtMaLuong, "");
            }
        }
        private void ValidateThang()
        {
            if (string.IsNullOrEmpty(txtThang.Text))
            {
                errorProvider.SetError(txtThang, "Vui lòng nhập tháng");
            }
            else if (!int.TryParse(txtThang.Text, out int thang))
            {
                errorProvider.SetError(txtThang, "Vui lòng nhập tháng với ký tự số");
            }
            else if (0 > thang || thang > 12)
            {
                errorProvider.SetError(txtThang, "Tháng chỉ có thể bắt đầu từ tháng 1 và kết thúc bằng tháng 12");
            }
            else
            {
                errorProvider.SetError(txtThang, "");
            }
        }
        private void ValidateSoTien()
        {
            if (string.IsNullOrEmpty(txtSoTien.Text))
            {
                errorProvider.SetError(txtSoTien, "Vui lòng nhập số tiền");
            }
            else if (!int.TryParse(txtSoTien.Text, out int soTien))
            {
                errorProvider.SetError(txtSoTien, "Số tiền chỉ có thể nhập bằng ký tự số");
            }
            else if (soTien < 0)
            {
                errorProvider.SetError(txtSoTien, "Số tiền không được phép âm");
            }
            else
            {
                errorProvider.SetError(txtSoTien, "");
            }
        }
        public void DSLuong(DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
            {
                var luong = db.Luongs.Select(a => new
                {
                    a.MaLuong,
                    a.MaNhanVien,
                    a.Thang,
                    a.SoTien
                }).ToList();
                data.DataSource = luong;
            }
        }

        public void LoadView()
        {
            dgvDSLuong.DataSource = bus_luong.View();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                BUS_Luong.Instance.ThemLuong(txtMaLuong, cboMaNhanVien, txtThang, txtSoTien);
                LoadDataLuong();
                ClearFormFields();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maLuong = txtMaLuong.Text;
                bool result = bus_luong.XoaLuong(maLuong);
                if (result)
                {
                    MessageBox.Show("Xóa lương thành công.");
                    LoadDataLuong();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Xóa lương không thành công. Không tìm thấy lương.");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maLuong = txtMaLuong.Text;
                string maNV = cboMaNhanVien.SelectedValue.ToString();
                int thang = int.Parse(txtThang.Text);
                float soTien = float.Parse(txtSoTien.Text);

                bool result = bus_luong.SuaLuong(maLuong, maNV, thang, soTien);
                if (result)
                {
                    MessageBox.Show("Sửa thông tin lương thành công.");
                    LoadDataLuong();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin lương không thành công. Không tìm thấy lương.");
                }
            }
        }

        private void dgvDSLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_Luong.Instance.LoadDGVLenForm(txtMaLuong, cboMaNhanVien, txtThang, txtSoTien, dgvDSLuong);

            txtMaLuong.Enabled = false;
            errorProvider.SetError(txtMaLuong, "");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void txtMaLuong_TextChanged(object sender, EventArgs e)
        {
            ValidateMaLuong();
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {
            ValidateThang();
        }

        private void txtSoTien_TextChanged(object sender, EventArgs e)
        {
            ValidateSoTien();
        }
    }
}
