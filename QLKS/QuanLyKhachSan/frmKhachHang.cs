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
        private ErrorProvider errorProvider1 = new ErrorProvider();  // Khai báo ErrorProvider

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
        //Load dữu liệu lên tất cả form
        public void LoadDuLieuLen()
        {
            BUS_KhachHang.Instance.Xem(dgvDSKhachHang);
        }
        //Load mã dịch vụ
        public void LoadMaDichVu()
        {
            BUS_KhachHang.Instance.LoadDichVu(cbMaDichVu);
        }
        //Thêm khách hàng
        private void btnThemKH_Click(object sender, EventArgs e)
        {

            // Nếu không có lỗi nào trong form thì mới thêm khách hàng
            if (ValidateForm())
            {
                // Đảm bảo số điện thoại luôn bắt đầu bằng 0
                if (!txtSDT.Text.StartsWith("0"))
                {
                    txtSDT.Text = "0" + txtSDT.Text; // Thêm số 0 vào đầu nếu chưa có
                }


                // Thực hiện thêm khách hàng
                BUS_KhachHang.Instance.Them(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
                LoadDuLieuLen();  // Tải lại dữ liệu

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //Xóa làm mới tất cả
        private void ClearFormFields()
        {
            txtMaKH.Text = string.Empty;
            cbMaDichVu.SelectedIndex = 0;
            txtTenKH.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtSDT.Text = string.Empty;
            txtDiaChi.Text = string.Empty;


            // Clear the ErrorProvider for each field
            errorProvider1.SetError(txtMaKH, "");
            errorProvider1.SetError(cbMaDichVu, "");
            errorProvider1.SetError(txtTenKH, "");
            errorProvider1.SetError(txtCCCD, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtSDT, "");
            errorProvider1.SetError(txtDiaChi, "");

            txtMaKH.Enabled =true;

        }
        //Xóa khách hàng
        private void btnXoaDV_Click(object sender, EventArgs e)
        {
            BUS_KhachHang.Instance.Xoa(txtMaKH);
            LoadDuLieuLen();
            ClearFormFields();
        }
        //DatagridView khách hàng
        private void dgvDSKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           

            
            BUS_KhachHang.Instance.LoadDGVLenForm(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi, dgvDSKhachHang);
            txtMaKH.Enabled = false;

            // Clear any existing errors first
            errorProvider1.SetError(txtMaKH, "");

        }
        //Sửa khách hàng
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                // Đảm bảo số điện thoại luôn bắt đầu bằng 0
                if (!txtSDT.Text.StartsWith("0"))
                {
                    txtSDT.Text = "0" + txtSDT.Text; // Thêm số 0 vào đầu nếu chưa có
                }

                //txtMaKH.ReadOnly = true;
                BUS_KhachHang.Instance.Sua(cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
                LoadDuLieuLen();
                txtMaKH.Enabled = true;
            }
            else
            {

            }
            txtMaKH.Enabled = true;
        }

        //ràng buộc sdt
        private void ValidateSDT()
        {
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại!");
            }
            else if (txtSDT.Text.Length != 10 || !Regex.IsMatch(txtSDT.Text, @"^0[0-9]{9}$")) // Kiểm tra số điện thoại bắt đầu bằng 0 và có 10 chữ số
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại không hợp lệ! (phải có 10 chữ số và bắt đầu bằng 0)");
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");  // Xóa lỗi nếu hợp lệ
            }
        }
        //ràng buộc email
        private void ValidateEmail()
        {

            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập email!");
            }
            else if (!txtEmail.Text.Contains("@"))  // Kiểm tra sự hiện diện của ký tự @
            {
                errorProvider1.SetError(txtEmail, "Email phải chứa ký tự '@'!");
            }

            // Kiểm tra email hợp lệ theo chuẩn (dạng a@b.c)
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtEmail, "Email không hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");  // Xóa lỗi nếu hợp lệ
            }
        }



        // Hàm kiểm tra từng trường trong form
        private bool ValidateFormFields()
        {

            bool isValid = true;



            // Kiểm tra tên khách hàng
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                errorProvider1.SetError(txtTenKH, "Vui lòng nhập tên khách hàng!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtTenKH, "");
            }

            // Kiểm tra CCCD
            if (string.IsNullOrEmpty(txtCCCD.Text) || !Regex.IsMatch(txtCCCD.Text, @"^[0-9]{12}$"))
            {
                errorProvider1.SetError(txtCCCD, "Vui lòng nhập CCCD hợp lệ (12 chữ số)!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtCCCD, "");
            }

            // Kiểm tra email
            if (string.IsNullOrEmpty(txtEmail.Text) || !Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập email hợp lệ!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");
            }

            // Kiểm tra số điện thoại
            if (string.IsNullOrEmpty(txtSDT.Text) || !Regex.IsMatch(txtSDT.Text, @"^[0-9]{10}$"))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại hợp lệ (10 chữ số)!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");
            }

            // Kiểm tra địa chỉ
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



        // Hàm kiểm tra toàn bộ form
        private bool ValidateForm()
        {
            // Chỉ kiểm tra mã khách hàng nếu txtMaKH đang bật (enabled)
            if (txtMaKH.Enabled)
            {
                ValidateMaKH();
            }

            // Kiểm tra các trường còn lại
            ValidateEmail();
            ValidateSDT();
            ValidateCCCD();
            ValidateFormFields();

            // Kiểm tra nếu tất cả các trường không có lỗi
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
            // Không kiểm tra mã khách hàng nếu txtMaKH đang bị vô hiệu hóa
            if (!txtMaKH.Enabled)
            {
                errorProvider1.SetError(txtMaKH, ""); // Xóa lỗi
                return; // Thoát khỏi hàm
            }

            ValidateMaKH(); // Chỉ gọi kiểm tra nếu trường đang bật

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

            // Không kiểm tra mã khách hàng nếu txtMaKH đang bị vô hiệu hóa
            if (!txtMaKH.Enabled)
            {
                errorProvider1.SetError(txtMaKH, ""); // Xóa lỗi
                return; // Thoát khỏi hàm
            }

            ValidateMaKH(); // Chỉ gọi kiểm tra nếu trường đang bật

        }

        private void txtTenKH_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra txtTenKH
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                errorProvider1.SetError(txtTenKH, "Vui lòng nhập tên khách hàng!");

            }
            else
            {
                errorProvider1.SetError(txtTenKH, ""); // Xóa lỗi nếu hợp lệ
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
        // Hàm kiểm tra giá trị trong txtMaSDDV
        private void ValidateMaKH()
        {
            // Nếu txtMaKH đang bị vô hiệu hóa (disabled) thì không cần kiểm tra mã khách hàng
            if (!txtMaKH.Enabled)
            {
                errorProvider1.SetError(txtMaKH, ""); // Xóa lỗi nếu có
                return; // Thoát khỏi hàm
            }


            // Kiểm tra nếu txtMaKH rỗng
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                errorProvider1.SetError(txtMaKH, "Vui lòng nhập mã khách hàng!");
            }
            // Kiểm tra nếu mã khách hàng bị trùng
            else if (BUS_KhachHang.Instance.CheckMaExists(txtMaKH.Text))
            {
                errorProvider1.SetError(txtMaKH, "Mã khách hàng đã tồn tại, vui lòng nhập mã khác!");
            }
            else
            {
                errorProvider1.SetError(txtMaKH, ""); // Xóa lỗi nếu hợp lệ
            }
        }
        private void ValidateCCCD()
        {
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                errorProvider1.SetError(txtCCCD, "Vui lòng nhập CCCD!");
            }
            else if (!Regex.IsMatch(txtCCCD.Text, @"^0[0-9]{11}$"))  // Kiểm tra xem CCCD có 12 chữ số và bắt đầu bằng 0
            {
                errorProvider1.SetError(txtCCCD, "CCCD không hợp lệ! Phải có 12 chữ số và bắt đầu bằng 0!");
            }
            else
            {
                errorProvider1.SetError(txtCCCD, "");  // Xóa lỗi nếu hợp lệ
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
            // Kiểm tra 
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập dia chi!");

            }
            else
            {
                errorProvider1.SetError(txtDiaChi, ""); // Xóa lỗi nếu hợp lệ
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

            // Clear the ErrorProvider for each field
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
