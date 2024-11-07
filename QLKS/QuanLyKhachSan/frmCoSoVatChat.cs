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
    public partial class frmCoSoVatChat : Form
    {
        BUS_CoSoVatChat BUS_CoSoVatChat = new BUS_CoSoVatChat();
        BUS_DSPhong busPhong = new BUS_DSPhong();
        public frmCoSoVatChat()
        {
            InitializeComponent();
        }
        public void LoadView()
        {
            dgvDSCSVC.DataSource = BUS_CoSoVatChat.Xem();
        }
        private void frmCoSoVatChat_Load(object sender, EventArgs e)
        {
            LoadView();
            List<Phong> DSDV = busPhong.Xem();
            ccbMaPhong.DataSource = DSDV;
            ccbMaPhong.DisplayMember = "MaPhong"; // Hiển thị tên loại phòng trong ComboBox
        }
        private bool ValidateInputs()
        {
            bool isValid = true;
            errorProvider1.Clear();

            // Ràng buộc cho MaCSVC
            if (string.IsNullOrWhiteSpace(ccbMaCSVC.Text))
            {
                errorProvider1.SetError(ccbMaCSVC, "Mã cơ sở vật chất không được để trống");
                isValid = false;
            }

            // Ràng buộc cho TenCSVC
            if (string.IsNullOrWhiteSpace(txtTenCSVC.Text))
            {
                errorProvider1.SetError(txtTenCSVC, "Tên cơ sở vật chất không được để trống");
                isValid = false;
            }

            // Ràng buộc cho MoTa
            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                errorProvider1.SetError(txtMoTa, "Mô tả không được để trống");
                isValid = false;
            }

            return isValid;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Lấy thông tin từ các textbox
            string maCSVC = ccbMaCSVC.Text;
            string maPhong = ccbMaPhong.Text; // Giả sử đây là ComboBox cho mã phòng
            string tenCSVC = txtTenCSVC.Text;
            string moTa = txtMoTa.Text;

            // Gọi hàm thêm từ lớp BUS
            bool ketQua = BUS_CoSoVatChat.ThemCoSoVatChat(maCSVC, maPhong, tenCSVC, moTa);

            if (ketQua)
            {
                MessageBox.Show("Thêm cơ sở vật chất thành công!");
                LoadView(); // Tải lại dữ liệu nếu cần
            }
            else
            {
                MessageBox.Show("Mã cơ sở vật chất đã tồn tại hoặc thêm thất bại.");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maCSVC = ccbMaCSVC.Text;

            // Kiểm tra xem người dùng có nhập mã cơ sở vật chất không
            if (string.IsNullOrWhiteSpace(maCSVC))
            {
                MessageBox.Show("Vui lòng nhập mã cơ sở vật chất cần xóa.");
                return;
            }

            // Gọi hàm xóa cơ sở vật chất từ lớp BUS
            bool ketQua = BUS_CoSoVatChat.XoaCoSoVatChat(maCSVC);

            if (ketQua)
            {
                MessageBox.Show("Xóa cơ sở vật chất thành công!");
                LoadView(); // Tải lại dữ liệu vào DataGridView
            }
            else
            {
                MessageBox.Show("Không tìm thấy cơ sở vật chất cần xóa.");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            CoSoVatChat csvc = new CoSoVatChat
            {
                MaPhong = ccbMaPhong.Text,
                MaCoSoVatChat = ccbMaCSVC.Text,
                TenCoSoVatChat = txtTenCSVC.Text,
                MoTa = txtMoTa.Text
            };

            if (BUS_CoSoVatChat.SuaCoSoVatChat(csvc))
            {
                MessageBox.Show("Sửa cơ sở vật chất thành công!");
                LoadView(); // Tải lại dữ liệu
            }
            else
            {
                MessageBox.Show("Sửa cơ sở vật chất thất bại.");
            }
        }

        private void dgvDSCSVC_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo rằng hàng không phải là tiêu đề
            {
                DataGridViewRow row = dgvDSCSVC.Rows[e.RowIndex];

                // Điền thông tin vào các textbox và combobox
                ccbMaPhong.Text = row.Cells["MaPhong"].Value.ToString();
                ccbMaCSVC.Text = row.Cells["MaCoSoVatChat"].Value.ToString();
                txtTenCSVC.Text = row.Cells["TenCoSoVatChat"].Value.ToString();
                txtMoTa.Text = row.Cells["MoTa"].Value.ToString();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
