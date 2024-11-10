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
    public partial class frmTimKiemPhong : Form
    {
        public frmTimKiemPhong()
        {
            InitializeComponent();
        }
        DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext();
        private void button1_Click(object sender, EventArgs e)
        {
            string maLoaiPhong = txtMaPhong.Text.Trim();  // Lấy mã loại phòng
            string tenLoaiPhong = txtTenPhong.Text.Trim();  // Lấy tên loại phòng

            // Kiểm tra xem người dùng đã nhập đầy đủ thông tin chưa
            if (string.IsNullOrWhiteSpace(maLoaiPhong) && string.IsNullOrWhiteSpace(tenLoaiPhong))
            {
                MessageBox.Show("Vui lòng nhập mã loại phòng hoặc tên loại phòng để tìm kiếm.");
                return;  // Dừng thực hiện tìm kiếm
            }

            // Khởi tạo query ban đầu
            var query = db.LoaiPhongs.AsQueryable();  // Sử dụng LINQ để truy vấn dữ liệu LoaiPhong

            // Tìm theo MaLoaiPhong nếu có giá trị
            if (!string.IsNullOrEmpty(maLoaiPhong))
            {
                query = query.Where(lp => lp.MaLoaiPhong.Equals(maLoaiPhong));  // So sánh chính xác mã loại phòng
            }

            // Tìm theo TenLoaiPhong nếu có giá trị
            if (!string.IsNullOrEmpty(tenLoaiPhong))
            {
                query = query.Where(lp => lp.TenLoaiPhong.Contains(tenLoaiPhong));  // So sánh chứa tên loại phòng
            }

            // Kiểm tra xem có chọn RadioButton nào cho mức giá không
            bool isCheckedGiaNhoHon500 = radioButton1.Checked;  // Kiểm tra giá nhỏ hơn 500
            bool isCheckedGiaLonHon1000 = radioButton2.Checked;  // Kiểm tra giá lớn hơn 1000
            bool isCheckedGiaLonHon2000 = radioButton3.Checked;  // Kiểm tra giá lớn hơn 2000

            // Kiểm tra mức giá nếu có lựa chọn RadioButton
            if (isCheckedGiaNhoHon500)
            {
                query = query.Where(lp => lp.Gia < 500000);
            }
            else if (isCheckedGiaLonHon1000)
            {
                query = query.Where(lp => lp.Gia > 1000000);
            }
            else if (isCheckedGiaLonHon2000)
            {
                query = query.Where(lp => lp.Gia > 2000000);
            }

            // Thực hiện truy vấn và hiển thị kết quả
            var result = query.ToList();

            // Hiển thị kết đ vào DataGridView
            dgTimKiemPhong.DataSource = result;

            // Nếu không tìm thấy kết quả
            if (result.Count == 0)
            {
                MessageBox.Show("Không tìm thấy loại phòng khớp với điều kiện tìm kiếm.");
            }
        }

        private void dgvTimKiemPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void frmTimKiemPhong_Load(object sender, EventArgs e)
        {
           
        }

        private void dgTimKiemPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            txtTenPhong.Text = null;
            txtMaPhong.Text = null;
        }
    }
}
