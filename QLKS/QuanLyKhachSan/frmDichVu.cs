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

namespace QuanLyKhachSan
{
    public partial class frmDichVu : Form
    {
        private ErrorProvider errorProvider1 = new ErrorProvider(); // Khai báo ErrorProvider
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
            txtMaLoaiDV.MaxLength = 10;  // MaLoaiDichVu chỉ cho phép tối đa 10 ký tự
            txtTenLDV.MaxLength = 50;    // TenLoaiDichVu chỉ cho phép tối đa 50 ký tự

            //txtGia.Validating += new CancelEventHandler(ValidateGia);
            //txtMaSDDV.Validating += new CancelEventHandler(ValidateMaSDDV);
            //txtSoLuong.Validating += new CancelEventHandler(ValidateSoLuong);
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
            //var data = bus_dv.View();
            //dataGridViewDichVu.DataSource = data; // Gán lại nguồn dữ liệu
            //dataGridViewDichVu.Refresh(); // Làm mới DataGridView
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

            BUS_DanhSachDichVu.Instance.LoadDGVLenForm(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong, dgvSuDungDichVu);
            txtMaSDDV.Enabled = false;
            errorProvider1.SetError(txtMaSDDV, "");
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
            // Form DSLDV
            txtMaSDDV.Enabled = true;
            txtMaSDDV.Text = string.Empty;
            cbMaDichVu.SelectedIndex = 0;
            cbMaDatPhong.SelectedIndex = 0;
            txtSoLuong.Text = string.Empty;

            // Clear các trường khác nếu cần
            // Form LoaiDichVu
            txtMaLoaiDV.Enabled = true;
            txtMaLoaiDV.Text = string.Empty;
            txtTenLDV.Text = string.Empty;
            cboMaLoaiPhong.SelectedIndex = 0;

            // Form DichVu
            txtMaDV.Enabled = true;
            txtMaDV.Text = string.Empty;
            cbLoaiDichVu.SelectedIndex = 0;
            txtTenDV.Text = string.Empty;
            txtGia.Text = string.Empty;

            // Set null Validate DichVu
            errorProvider1.SetError(txtMaDV, "");
            errorProvider1.SetError(txtTenDV, "");
            errorProvider1.SetError(txtGia, "");

            // Set null Validate LoaiDichVu
            errorProvider1.SetError(txtMaLoaiDV, "");
            errorProvider1.SetError(txtTenLDV, "");
        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
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
            //ValidateMaSDDV(); // Kiểm tra mã sử dụng dịch vụ

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
            else if (BUS_DanhSachDichVu.Instance.CheckMaSDDVExists(txtMaSDDV.Text)) // Gọi BUS để kiểm tra trùng mã
            {
                errorProvider1.SetError(txtMaSDDV, "Mã sử dụng dịch vụ đã tồn tại, vui lòng nhập mã khác!"); // Đặt lỗi khi mã bị trùng
            }
            else
            {
                errorProvider1.SetError(txtMaSDDV, ""); // Xóa lỗi nếu hợp lệ
            }
        }
        /// <summary>
        /// Validate Form LoaiDichVu
        /// </summary>
        /// 
        private bool ValidateFormLoaiDV()
        {
            //if (txtMaLoaiDV.Enabled)
            //{
            //    ValidateMaLDV();
            //}
            ValidateTenLDV();

            return string.IsNullOrEmpty(errorProvider1.GetError(txtMaLoaiDV)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtTenLDV));
        }
        private void ValidateMaLDV()
        {
            string pattern = @"^(dv|DV)[0-9]+$";

            if (string.IsNullOrEmpty(txtMaLoaiDV.Text))
            {
                errorProvider1.SetError(txtMaLoaiDV, "Vui lòng nhập mã loại dịch vụ! Mã phải bắt đầu bằng 'dv / DV' và theo sau là số giới hạn 10 ký tự");
            }
            else if (BUS_LoaiDichVu.Instance.CheckMaLDVExists(txtMaLoaiDV.Text))
            {
                errorProvider1.SetError(txtMaLoaiDV, "Mã loại dịch vụ đã tồn tại!");
            }
            else if (!Regex.IsMatch(txtMaLoaiDV.Text, pattern))
            {
                errorProvider1.SetError(txtMaLoaiDV, "Mã loại dịch vụ không hợp lệ! Mã phải bắt đầu bằng 'dv / DV' và theo sau là số");
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
        //
        //
        //
        /***/
        /// <summary>
        /// Validate Form DichVu
        /// </summary>
        private bool ValidateFormDV()
        {
            //if (txtMaDV.Enabled)
            //{
            //    ValidateMaDV();
            //}
            ValidateTenDV();
            ValidateGia();

            return string.IsNullOrEmpty(errorProvider1.GetError(txtMaDV)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtTenDV)) &&
                   string.IsNullOrEmpty(errorProvider1.GetError(txtGia));
        }
        private void ValidateMaDV()
        {
            //if (!txtMaDV.Enabled)
            //{
            //    errorProvider1.SetError(txtMaDV, "");
            //    return;
            //}

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
            //else if (!int.TryParse(txtGia.Text, out _))
            //{
            //    errorProvider1.SetError(txtGia, "Vui lòng nhập số hợp lệ từ 0 - 999999999");
            //}
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
        //
        //
        //
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
                //txtMaLoaiDV.ReadOnly = true;
                //string maLDV = txtMaLoaiDV.Text;
                //string tenLDV = txtMaLoaiDV.Text;
                //string maLoaiPhong = txtMaLoaiPhong.Text;

                //bool result = bus_ldv.ThemLDV(maLDV, tenLDV, maLoaiPhong);
                //if (result)
                //{
                //    MessageBox.Show("Thêm loại dịch vụ thành công.");
                //    LoadDuLieuLDV();
                //    //ClearTextBoxes();
                //}
                //else
                //{
                //    MessageBox.Show("Thêm loại dịch không thành công. Loại dịch đã tồn tại.");
                //}

                // Chuẩn hóa txtMaDV trước khi gọi phương thức ThemDV
                string maLDV = txtMaLoaiDV.Text;
                string tenLDV = txtTenLDV.Text;

                // Kiểm tra và chuẩn hóa thành 'DV' theo sau là số
                if (System.Text.RegularExpressions.Regex.IsMatch(maLDV, @"^(dv|DV)\d+$"))
                {
                    maLDV = "DV" + maLDV.Substring(2); // Thay thế 'dv' hoặc 'DV' bằng 'DV'
                    txtMaLoaiDV.Text = maLDV; // Gán lại giá trị đã chuẩn hóa cho txtMaDV
                }
                else
                {
                    MessageBox.Show("Mã loại dịch vụ phải bắt đầu bằng 'dv' hoặc 'DV' và theo sau là số.");
                    return; // Thoát khỏi sự kiện nếu không hợp lệ
                }

                //if (System.Text.RegularExpressions.Regex.IsMatch(tenLDV, @"^(lp|LP)\d+$"))
                //{
                //    tenLDV = "LP" + tenLDV.Substring(2);
                //    txtTenLDV.Text = tenLDV;
                //}
                //else
                //{
                //    return;
                //}

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
                //string maLDV = txtMaLoaiDV.Text;
                //bool result = bus_ldv.XoaLDV(maLDV);
                //if (result)
                //{
                //    MessageBox.Show("Xóa loại dịch vụ thành công.");
                //    LoadDuLieuLDV();
                //    //ClearTextBoxes();
                //}
                //else
                //{
                //    MessageBox.Show("Xóa loại dịch vụ không thành công. Không tìm thấy loại dịch vụ.");
                //}
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
                //string maLDV = txtMaLoaiDV.Text;
                //string tenLDV = txtTenLDV.Text;
                //string maLoaiPhong = txtMaLoaiPhong.Text;

                //bool result = bus_ldv.SuaLDV(maLDV, tenLDV, maLoaiPhong);
                //if (result)
                //{
                //    MessageBox.Show("Sửa thông tin loại dịch vụ thành công.");
                //    LoadDuLieuLDV();
                //    //ClearTextBoxes();
                //}
                //else
                //{
                //    MessageBox.Show("Sửa thông tin loại dịch vụ không thành công. Không tìm thấy loại dịch vụ.");
                //}
                BUS_LoaiDichVu.Instance.Sua(txtMaLoaiDV, txtTenLDV, cboMaLoaiPhong);
                LoadDuLieuLDV();
                ClearFormFields();
                LoadMaLoaiDichVu();
            }
        }

        private void dataGridViewLoaiDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //DataGridViewRow row = dataGridViewLoaiDichVu.Rows[e.RowIndex];

            //// Hiển thị thông tin của dòng được chọn lên các TextBox tương ứng
            //txtMaLoaiDV.Text = row.Cells[0].Value.ToString();
            //txtTenLDV.Text = row.Cells[1].Value.ToString();
            //txtMaLoaiPhong.Text = row.Cells[2].Value.ToString();

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
            // Chuẩn hóa txtMaDV trước khi gọi phương thức ThemDV
            string maDV = txtMaDV.Text;

            // Kiểm tra và chuẩn hóa thành 'DV' theo sau là số
            if (System.Text.RegularExpressions.Regex.IsMatch(maDV, @"^(dv|DV)\d+$"))
            {
                maDV = "DV" + maDV.Substring(2); // Thay thế 'dv' hoặc 'DV' bằng 'DV'
                txtMaDV.Text = maDV; // Gán lại giá trị đã chuẩn hóa cho txtMaDV
            }
            else
            {
                MessageBox.Show("Mã dịch vụ phải bắt đầu bằng 'dv' hoặc 'DV' và theo sau là số.");
                return; // Thoát khỏi sự kiện nếu không hợp lệ
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
            // Nếu các trường khác trống thì enable txtMaDV lại và kiểm tra validate
            if (string.IsNullOrEmpty(txtTenDV.Text) || string.IsNullOrEmpty(txtGia.Text))
            {
                txtMaDV.ReadOnly = false;  // Enable lại txtMaDV
                ValidateFormDV();  // Kích hoạt lại quá trình validate
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
    }
}
