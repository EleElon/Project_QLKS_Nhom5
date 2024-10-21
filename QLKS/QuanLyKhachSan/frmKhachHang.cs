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
            // Gọi hàm kiểm tra trước

            // Nếu không có lỗi nào trong form thì mới thêm khách hàng
            if (ValidateForm())
            {
                // Thực hiện thêm khách hàng
                BUS_KhachHang.Instance.Them(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
                LoadDuLieuLen();  // Tải lại dữ liệu
                ClearFormFields();  // Xóa form
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

            // Clear các trường khác nếu cần

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
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                txtMaKH.ReadOnly = true;
                 BUS_KhachHang.Instance.Sua(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
                 LoadDuLieuLen();
                 ClearFormFields() ;
            }
           
        }
        private void ValidateSDT()
        {
            ErrorProvider errorProvider1 = new ErrorProvider();
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại!");
            }
            else if (!Regex.IsMatch(txtSDT.Text, @"^[0-9]{10}$"))  // Kiểm tra xem số điện thoại có 10 chữ số
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại không hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");  // Xóa lỗi nếu hợp lệ
            }
        }

        private void ValidateEmail()
        {
            ErrorProvider errorProvider1 = new ErrorProvider();
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập email!");
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))  // Kiểm tra email hợp lệ
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

            // Kiểm tra mã khách hàng
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                errorProvider1.SetError(txtMaKH, "Vui lòng nhập mã khách hàng!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtMaKH, "");  // Xóa lỗi nếu hợp lệ
            }

            // Kiểm tra tên khách hàng
            if (string.IsNullOrEmpty(txtTenKH.Text))
            {
                errorProvider1.SetError(txtTenKH, "Vui lòng nhập tên khách hàng!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtTenKH, "");  // Xóa lỗi nếu hợp lệ
            }

            // Kiểm tra CCCD
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                errorProvider1.SetError(txtCCCD, "Vui lòng nhập CCCD!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtCCCD, "");  // Xóa lỗi nếu hợp lệ
            }

            // Kiểm tra địa chỉ
            if (string.IsNullOrEmpty(txtDiaChi.Text))
            {
                errorProvider1.SetError(txtDiaChi, "Vui lòng nhập địa chỉ!");
                isValid = false;
            }
            else
            {
                errorProvider1.SetError(txtDiaChi, "");  // Xóa lỗi nếu hợp lệ
            }

            return isValid;  // Trả về true nếu tất cả các trường hợp đều hợp lệ
        }


        // Hàm kiểm tra toàn bộ form
        private bool ValidateForm()
        {
            ValidateEmail(); // Kiểm tra email
            ValidateSDT(); // Kiểm tra sdt


            // Nếu cả hai không có lỗi thì trả về true, ngược lại là false
            return ValidateFormFields();
        }
        private void txtSDT_Leave(object sender, EventArgs e)
        {
            ErrorProvider errorProvider1 = new ErrorProvider();
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                errorProvider1.SetError(txtSDT, "Vui lòng nhập số điện thoại!");
            }
            else if (!Regex.IsMatch(txtSDT.Text, @"^[0-9]{10}$"))  // Kiểm tra xem số điện thoại có 10 chữ số
            {
                errorProvider1.SetError(txtSDT, "Số điện thoại không hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtSDT, "");  // Xóa lỗi nếu hợp lệ
            }
        }

        private void txtMaKH_Leave(object sender, EventArgs e)
        {
               // Kiểm tra txtMaKH
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                errorProvider1.SetError(txtMaKH, "Vui lòng nhập mã khách hàng!");

            }
            else
            {
                errorProvider1.SetError(txtMaKH, ""); // Xóa lỗi nếu hợp lệ
            }
        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {
           
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
            ErrorProvider errorProvider1 = new ErrorProvider();
            if (string.IsNullOrEmpty(txtCCCD.Text))
            {
                errorProvider1.SetError(txtCCCD, "Vui lòng nhập số điện thoại!");
            }
            else if (!Regex.IsMatch(txtCCCD.Text, @"^[0-9]{12}$"))  // Kiểm tra xem số điện thoại có 10 chữ số
            {
                errorProvider1.SetError(txtCCCD, "Số điện thoại không hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtCCCD, "");  // Xóa lỗi nếu hợp lệ
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            ErrorProvider errorProvider1 = new ErrorProvider();
            if (string.IsNullOrEmpty(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, "Vui lòng nhập email!");
            }
            else if (!Regex.IsMatch(txtEmail.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))  // Kiểm tra email hợp lệ
            {
                errorProvider1.SetError(txtEmail, "Email không hợp lệ!");
            }
            else
            {
                errorProvider1.SetError(txtEmail, "");  // Xóa lỗi nếu hợp lệ
            }
        }

        private void txtSDT_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtDiaChi_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra txtMaKH
            if (string.IsNullOrEmpty(txtMaKH.Text))
            {
                errorProvider1.SetError(txtMaKH, "Vui lòng nhập mã khách hàng!");

            }
            else
            {
                errorProvider1.SetError(txtMaKH, ""); // Xóa lỗi nếu hợp lệ
            }
        }
    }
}
