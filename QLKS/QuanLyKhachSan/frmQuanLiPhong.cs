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
    public partial class frmQuanLiPhong : Form
    {
        private string makh = "";
        private ErrorProvider errorProvider1 = new ErrorProvider();
        public frmQuanLiPhong()
        {
            InitializeComponent();
            LoadDuLieuLen();
            LoadMaKhachHang();
            LoadMaDatPhong();
            cbMaPhong.SelectedIndex = 0;
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            frmTimKiemPhong frm = new frmTimKiemPhong();
            frm.Show();
        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        public void LoadDuLieuLen()
        {
            BUS_DatPhong.Instance.Xem(dgvDatPhong);
            BUS_DatPhong.Instance.XemDP(dgvDatPhongg);
        }
        private void dgvDatPhong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadMaKhachHang()
        {
            BUS_DatPhong.Instance.LoadTenKhachHang(cbMaKH);
            BUS_DatPhong.Instance.LoadComBoBoxMaPhong(cbMaPhong);
        }
        public void LoadMaDatPhong()
        {
            BUS_DatPhong.Instance.LoadComBoBoxMaDatPhong(cbMaDatPhong);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (txtMaDatPhongg != null)
            {
                BUS_DatPhong.Instance.Them(txtMaDatPhongg, cbMaKH);
                LoadDuLieuLen();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập mã không để trống");
            }
        }

        private void dgvDatPhongg_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_DatPhong.Instance.LoadDGVLenFormDP(txtMaDatPhongg, cbMaKH, dgvDatPhongg);
            txtMaDatPhongg.Enabled = false;

            errorProvider1.SetError(txtMaDatPhongg, "");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BUS_DatPhong.Instance.Sua(txtMaDatPhongg, cbMaKH);
            LoadDuLieuLen();
            txtMaDatPhongg.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BUS_DatPhong.Instance.Xoa(txtMaDatPhongg);
            LoadDuLieuLen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cbMaDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaDatPhong.Text != null)
            {
                string selectedBookingId = cbMaDatPhong.Text;
                string customerName = BUS_DatPhong.Instance.GetCustomerNameByBookingId(selectedBookingId);
                cbMaKhachHang.Text = customerName;
                BUS_DatPhong.Instance.LoadComBoBoxMaKHachHang(cbMaKhachHang);
            }
        }

        private void cbMaPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            BUS_DatPhong.Instance.LoadComBoBoxLoaiPhong(cbMaLoaiPhong, cbMaPhong.Text, txtTinhTrangPhong, txtGia);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            makh = BUS_DatPhong.Instance.LayMaKHachHang(cbMaKhachHang);

            if (string.IsNullOrWhiteSpace(txtMaChiTiet.Text) ||
                cbMaDatPhong.SelectedItem == null ||
                cbMaPhong.SelectedItem == null ||
                string.IsNullOrWhiteSpace(txtGia.Text) ||
                string.IsNullOrWhiteSpace(txtSoLuong.Text) ||
                string.IsNullOrWhiteSpace(txtTongGia.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin.");
                return;
            }

            try
            {
                BUS_DatPhong.Instance.AddBookingDetail(
                    txtMaChiTiet,
                    cbMaDatPhong,
                    makh,
                    cbMaPhong,
                    cbMaLoaiPhong,
                    txtTinhTrangPhong,
                    txtGia,
                    txtSoLuong,
                    txtTongGia,
                    cboPTTT,
                    dtpNgayNhan.Value,
                    dtpNgayTra.Value
                );
                LoadDuLieuLen();
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm không thành công");
            }
        }

        private void CalculateTotalPrice()
        {
            string roomCode = txtGia.Text;
            int quantity = int.TryParse(txtSoLuong.Text, out int qty) ? qty : 0;

            decimal totalPrice = BUS_DatPhong.Instance.CalculateTotalPrice(roomCode, quantity);

            txtTongGia.Text = totalPrice.ToString();
        }

        private void txtGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmQuanLiPhong_Load(object sender, EventArgs e)
        {

        }

        private void cbMaPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvDatPhong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            BUS_DatPhong.Instance.LoadDuLieuLenChiTiet(txtMaChiTiet, cbMaDatPhong, cbMaKhachHang, cbMaPhong, cbMaLoaiPhong, txtTinhTrangPhong, txtGia, txtSoLuong, txtTongGia, cboPTTT, dtpNgayNhan, dtpNgayTra, dgvDatPhong);

            txtMaChiTiet.Enabled = false;

            errorProvider1.SetError(txtMaChiTiet, "");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            BUS_DatPhong.Instance.XoaCT(txtMaChiTiet);
            LoadDuLieuLen();
        }

        private void dtpNgayTra_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayNhan_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtTongGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            BUS_DatPhong.Instance.SuaCT(txtMaChiTiet, cbMaDatPhong, cbMaKhachHang, cbMaPhong, cbMaLoaiPhong, txtTinhTrangPhong, txtGia, txtSoLuong, txtTongGia, cboPTTT, dtpNgayNhan.Value, dtpNgayTra.Value);
            LoadDuLieuLen();
            txtMaChiTiet.Enabled = true;
        }

        private void txtMaChiTiet_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaChiTiet.Text))
            {
                errorProvider1.SetError(txtMaChiTiet, "Mã chi tiết không được để trống.");
            }
            else if (BUS_DatPhong.Instance.KiemTraMaChiTietTonTai(txtMaChiTiet.Text))
            {
                errorProvider1.SetError(txtMaChiTiet, "Mã chi tiết đã tồn tại. Vui lòng nhập mã khác.");
            }
            else
            {
                errorProvider1.SetError(txtMaChiTiet, "");
            }
        }

        private void txtMaChiTiet_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaChiTiet.Text))
            {
                errorProvider1.SetError(txtMaChiTiet, "Mã chi tiết không được để trống.");
            }
            else if (BUS_DatPhong.Instance.KiemTraMaChiTietTonTai(txtMaChiTiet.Text))
            {
                errorProvider1.SetError(txtMaChiTiet, "Mã chi tiết đã tồn tại. Vui lòng nhập mã khác.");
            }
            else
            {
                errorProvider1.SetError(txtMaChiTiet, "");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
