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
    public partial class frmPhong : Form
    {
        public frmPhong()
        {
            InitializeComponent();
         
        }

        private void frmPhong_Load(object sender, EventArgs e)
        {
            DanhSachPhong(dgvDanhSachPhong);
            LoadLoaiPhong(cbMaLoaiPhong);  // cboLoaiPhong là tên của ComboBox cho loại phòng
            LoadTinhTrang(cbTinhTrang);  // cboTinhTrang là tên của ComboBox cho tình trạng

        }
        public void DanhSachPhong(DataGridView data)
        {
          
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
            {
                var phongs = db.Phongs.Select(a => new
                {
                    a.MaPhong,
                    a.MaLoaiPhong,
                    a.SoPhong,
                    a.TinhTrang
                }).ToList();
                data.DataSource = phongs;
            }
           
        }
        public void ThemPhong(string maPhong, string maLoaiPhong, int soPhong, string tinhTrang)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
            {
                var phong = new Phong
                {
                    MaPhong = maPhong,
                    MaLoaiPhong = maLoaiPhong,
                    SoPhong = soPhong,
                    TinhTrang = tinhTrang
                };
                db.Phongs.InsertOnSubmit(phong);
                db.SubmitChanges();  // Lưu thay đổi vào cơ sở dữ liệu
            }
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
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
            {
                var loaiPhongs = db.LoaiPhongs.Select(lp => new { lp.MaLoaiPhong, lp.TenLoaiPhong }).ToList();
                comboBoxLoaiPhong.DataSource = loaiPhongs;
                comboBoxLoaiPhong.DisplayMember = "TenLoaiPhong";  // Hiển thị tên loại phòng
                comboBoxLoaiPhong.ValueMember = "MaLoaiPhong";    // Giá trị là mã loại phòng
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Lấy mã loại phòng từ ComboBox
                string maLoaiPhong = cbMaLoaiPhong.SelectedValue.ToString();

                // Lấy tình trạng phòng từ ComboBox
                string tinhTrang = cbTinhTrang.SelectedItem.ToString();

                // Lấy mã phòng và số phòng từ TextBox
                string maPhong = txtMaPhong.Text;
                int soPhong = int.Parse(txtSoPhong.Text);

                // Gọi phương thức ThemPhong để thêm phòng mới
                ThemPhong(maPhong, maLoaiPhong, soPhong, tinhTrang);

                // Cập nhật lại danh sách phòng trên DataGridView
                DanhSachPhong(dgvDanhSachPhong);

                MessageBox.Show("Thêm phòng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phòng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
