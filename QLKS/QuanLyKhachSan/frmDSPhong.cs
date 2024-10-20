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
    public partial class frmDSPhong : Form
    {
        public frmDSPhong()
        {
            InitializeComponent();
         
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            DanhSachPhong(dgvDanhSachPhong);
            LoadLoaiPhong(cbMaLoaiPhong);  // cboLoaiPhong là tên của ComboBox cho loại phòng
            //LoadTinhTrang(cbTinhTrang);  // cboTinhTrang là tên của ComboBox cho tình trạng

        }
        public void DanhSachPhong(DataGridView data)
        {
          
            
           
        }
        
        private void LoadTinhTrang(ComboBox comboBoxTinhTrang)
        {
            List<string> tinhTrangs = new List<string>
            {
                "Trống",
                "Có Khách",
                "Đang Bảo Trì"
            };

            comboBoxTinhTrang.DataSource = tinhTrangs;
        }
        private void LoadLoaiPhong(ComboBox comboBoxLoaiPhong)
        {
            
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã loại phòng từ ComboBox
                string maLoaiPhong = cbMaLoaiPhong.SelectedValue.ToString();

                // Lấy tình trạng phòng từ ComboBox
                //string tinhTrang = cbTinhTrang.SelectedItem.ToString();

                // Lấy mã phòng và số phòng từ TextBox
                string maPhong = txtMaPhong.Text;
                int soPhong = int.Parse(txtSoPhong.Text);

                // Gọi phương thức ThemPhong để thêm phòng mới
                //ThemPhong(maPhong, maLoaiPhong, soPhong, tinhTrang);

                // Cập nhật lại danh sách phòng trên DataGridView
                DanhSachPhong(dgvDanhSachPhong);

                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            frmTimKiemPhong frmTimKiemPhong = new frmTimKiemPhong();
            frmTimKiemPhong.Show();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
