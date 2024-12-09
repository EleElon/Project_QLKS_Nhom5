using BUS;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyKhachSan
{
    public partial class frmChamCong : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        BUS_ChamCong bus_cc = new BUS_ChamCong();
        public frmChamCong()
        {
            InitializeComponent();
            FormDataBiding();
            loadData();
            LoadComboNhanVien();
            DataComboBox();
        }
        private void DataComboBox()
        {
            for (int i = 1; i <= 12; i++)
            {
                cboThang.Items.Add($"{i}");
            }
        }
        public void FormDataBiding()
        {
            txtMaChamCong.MaxLength = 100;
            txtTenBangChamCong.MaxLength = 100;
            txtGhiChu.MaxLength = 200;
            txtSoGioTangCa.MaxLength = 4;

            cboThang.SelectedItem = 0;

            nudNam.Minimum = 1900;
            nudNam.Maximum = DateTime.Now.Year;
            nudNam.Value = DateTime.Now.Year;
            nudNam.Increment = 1;

            dtpNgayCham.MaxDate = DateTime.Now;
            dtpNgayCham.MinDate = new DateTime(2000, 1, 1);

            nudSoNgayLam.Minimum = 0;
            nudSoNgayLam.Value = 0;
            nudSoNgayLam.Increment = 1;
        }
        public void loadData()
        {
            BUS_ChamCong.Instance.Xem(dgvDSChamCong);
        }
        public void LoadComboNhanVien()
        {
            BUS_ChamCong.Instance.LoadMaNV(cboMaNhanVien);
        }
        public void ClearFormFields()
        {
            txtMaChamCong.Enabled = true;
            txtMaChamCong.Text = string.Empty;
            txtTenBangChamCong.Text = string.Empty;
            cboMaNhanVien.SelectedIndex = 0;
            cboThang.SelectedIndex = 0;
            nudNam.Value = DateTime.Now.Year;
            nudSoNgayLam.Value = 0;
            dtpNgayCham.Value = DateTime.UtcNow;
            txtSoGioTangCa.Text = string.Empty;
            dtpNgayCham.Text = string.Empty;
            txtGhiChu.Text = string.Empty;

            errorProvider.SetError(txtMaChamCong, "");
            errorProvider.SetError(txtTenBangChamCong, "");
            errorProvider.SetError(nudSoNgayLam, "");
            errorProvider.SetError(txtSoGioTangCa, "");
            errorProvider.SetError(dtpNgayCham, "");
            errorProvider.SetError(txtGhiChu, "");
        }
        private bool ValidateForm()
        {
            ValidateTenBang();
            ValidateSoNgayLam();
            ValidateSoGioTangCa();
            ValidateNgayCham();
            ValidateGhiChu();

            return string.IsNullOrEmpty(errorProvider.GetError(txtMaChamCong)) &&
             string.IsNullOrEmpty(errorProvider.GetError(txtTenBangChamCong)) &&
                string.IsNullOrEmpty(errorProvider.GetError(nudSoNgayLam)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtSoGioTangCa)) &&
                string.IsNullOrEmpty(errorProvider.GetError(dtpNgayCham)) &&
                string.IsNullOrEmpty(errorProvider.GetError(txtGhiChu));
        }
        private void ValidateMaChamCong()
        {
            string pattern = @"^(cc|CC)[0-9]+$";

            if (string.IsNullOrEmpty(txtMaChamCong.Text))
            {
                errorProvider.SetError(txtMaChamCong, "Vui lòng nhập mã chấm công! Bắt đầu từ cc / CC sau đó là ký tự số");
            }
            else if (BUS_ChamCong.Instance.CheckMaLuongExists(txtMaChamCong.Text))
            {
                errorProvider.SetError(txtMaChamCong, "Mã lương đã tồn tại");
            }
            else if (!Regex.IsMatch(txtMaChamCong.Text, pattern))
            {
                errorProvider.SetError(txtMaChamCong, "Mã chấm công phải bắt đầu từ cc /CC sau đó là ký tự sô");
            }
            else
            {
                errorProvider.SetError(txtMaChamCong, "");
            }
        }
        private void ValidateTenBang()
        {
            string pattern = @"^[^!@#\$%\^*_\-\+=]+$";

            if (string.IsNullOrEmpty(txtTenBangChamCong.Text))
            {
                errorProvider.SetError(txtTenBangChamCong, "Vui lòng nhập tên");
            }
            else if (!Regex.IsMatch(txtTenBangChamCong.Text, pattern))
            {
                errorProvider.SetError(txtTenBangChamCong, "Vui lòng nhập tên hợp lệ, tên không bao gồm ký tự đặt biệt ! @ # $ % ^ * _ - + = ");
            }
            else
            {
                errorProvider.SetError(txtTenBangChamCong, "");
            }
        }
        private void ValidateSoNgayLam()
        {
            if (nudSoNgayLam.Value == 0)
            {
                errorProvider.SetError(nudSoNgayLam, "Vui lòng nhập số ngày làm");
            }
            else
            {
                errorProvider.SetError(nudSoNgayLam, "");
            }
        }
        private void ValidateSoGioTangCa()
        {
            if (string.IsNullOrEmpty(txtSoGioTangCa.Text))
            {
                errorProvider.SetError(txtSoGioTangCa, "Vui lòng nhập số giờ tăng ca");
            }
            else if (!int.TryParse(txtSoGioTangCa.Text, out int soH))
            {
                errorProvider.SetError(txtSoGioTangCa, "Số giờ tăng ca chỉ có thể nhập bằng ký tự số");
            }
            else if (soH < 0)
            {
                errorProvider.SetError(txtSoGioTangCa, "Số giờ không được phép âm");
            }
            else
            {
                errorProvider.SetError(txtSoGioTangCa, "");
            }
        }
        private void ValidateNgayCham()
        {
            DateTime minDate = new DateTime(DateTime.Now.Date.Month - 1);
            DateTime maxDate = DateTime.Now;

            if (dtpNgayCham.Value < minDate)
            {
                errorProvider.SetError(dtpNgayCham, $"Ngày chấm không được nhỏ hơn {minDate.ToShortDateString()}");
            }
            else if (dtpNgayCham.Value > maxDate)
            {
                errorProvider.SetError(dtpNgayCham, "Ngày chấm không được lớn hơn ngày hiện tại");
            }
            else
            {
                errorProvider.SetError(dtpNgayCham, "");
            }
        }
        private void ValidateGhiChu()
        {
            string pattern = @"^[^!@#\$%\^*_\-\+=]+$";

            if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                errorProvider.SetError(txtGhiChu, "Vui lòng nhập ghi chú");
            }
            else if (!Regex.IsMatch(txtGhiChu.Text, pattern))
            {
                errorProvider.SetError(txtGhiChu, "Vui lòng nhập ghi chú hợp lệ, ghi chú không bao gồm ký tự đặt biệt ! @ # $ % ^ * _ - + = ");
            }
            else
            {
                errorProvider.SetError(txtGhiChu, "");
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maCC = txtMaChamCong.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(maCC, @"^(cc|CC)\d+$"))
                {
                    maCC = "CC" + maCC.Substring(2);
                    txtMaChamCong.Text = maCC;
                }
                else
                {
                    MessageBox.Show("Mã chấm công phải bắt đầu bằng 'cc' hoặc 'CC' và theo sau là số.");
                    return;
                }
                BUS_ChamCong.Instance.ThemChamCong(txtMaChamCong, txtTenBangChamCong, cboMaNhanVien, cboThang, nudNam, nudSoNgayLam, txtSoGioTangCa, dtpNgayCham, txtGhiChu);
                loadData();
                ClearFormFields();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maCham = txtMaChamCong.Text;
                bool result = bus_cc.XoaChamCong(maCham);
                if (result)
                {
                    MessageBox.Show("Xóa chấm công thành công.");
                    loadData();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Xóa chấm công không thành công. Không tìm thấy mã chấm công.");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maCham = txtMaChamCong.Text;
                string tenBang = txtTenBangChamCong.Text;
                string maNV = cboMaNhanVien.SelectedValue.ToString();
                string thang = cboThang.SelectedItem.ToString();
                int nam = (int)nudNam.Value;
                int soNgayLam = (int)nudSoNgayLam.Value;
                float soGioTangCa = float.Parse(txtSoGioTangCa.Text);
                DateTime ngayCham = dtpNgayCham.Value;
                string ghiChu = txtGhiChu.Text;

                bool result = bus_cc.SuaChamCong(maCham, tenBang, maNV, thang, nam, soNgayLam, soGioTangCa, ngayCham, ghiChu);
                if (result)
                {
                    MessageBox.Show("Sửa thông tin chấm công thành công.");
                    loadData();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin chấm công không thành công. Không tìm thấy mã chấm công.");
                }
            }
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maCham = txtMaChamCong.Text;
                int soNgayLam = (int)nudSoNgayLam.Value;
                float soGioTangCa = float.Parse(txtSoGioTangCa.Text);

                bool result = bus_cc.ChamCong(maCham, soNgayLam, soGioTangCa);
                if (result)
                {
                    MessageBox.Show("Chấm công thành công.");
                    loadData();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Chấm công không thành công. Không tìm thấy mã chấm công.");
                }
            }
        }

        private void dgvDSChamCong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_ChamCong.Instance.LoadDGVLenForm(txtMaChamCong, txtTenBangChamCong, cboMaNhanVien, cboThang, nudNam, nudSoNgayLam, txtSoGioTangCa, dtpNgayCham, txtGhiChu, dgvDSChamCong);

            txtMaChamCong.Enabled = false;
            errorProvider.SetError(txtMaChamCong, "");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtMaChamCong_TextChanged(object sender, EventArgs e)
        {
            ValidateMaChamCong();
        }

        private void txtGhiChu_TextChanged(object sender, EventArgs e)
        {
            ValidateGhiChu();
        }

        private void txtSoGioTangCa_TextChanged(object sender, EventArgs e)
        {
            ValidateSoGioTangCa();
        }
        private void MoveCursorToEnd(TextBox txt)
        {
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtSoGioTangCa_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtSoGioTangCa);
        }

        private void txtGhiChu_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtGhiChu);
        }

        private void txtTenBangChamCong_TextChanged(object sender, EventArgs e)
        {
            ValidateTenBang();
        }

        private void txtTenBangChamCong_Click(object sender, EventArgs e)
        {
            MoveCursorToEnd(txtTenBangChamCong);
        }

        private void cboThang_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedMonth = Convert.ToInt32(cboThang.SelectedItem);

            switch (selectedMonth)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    nudSoNgayLam.Maximum = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    nudSoNgayLam.Maximum = 30;
                    break;

                case 2:
                    nudSoNgayLam.Maximum = 28;
                    break;

                default:
                    nudSoNgayLam.Maximum = 30;
                    break;
            }
        }
    }
}
