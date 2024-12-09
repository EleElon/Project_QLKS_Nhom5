using BUS;
using DAO;
using QuanLyKhachSan;
using QuanLyKhachSan.Reporting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLiKhachSan_Nhom5
{
    public partial class frmHoaDon : Form
    {
        BUS_HoaDon busHoaDon = new BUS_HoaDon();
        BUS_DSPhong busPhong = new BUS_DSPhong();
        BUS_DatPhong busDatPhong = new BUS_DatPhong();
        BUS_DanhSachDichVu busDichVu = new BUS_DanhSachDichVu();

        public frmHoaDon()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            frmTimKiemHoaDon frmTimKiemHoaDon = new frmTimKiemHoaDon();
            frmTimKiemHoaDon.Show();
        }
        public void LoadView()
        {
            dgvHoaDon.DataSource = busHoaDon.HienThi();
            var danhSachPhong = busPhong.Xem();

            ccbMaDP.DataSource = danhSachPhong;
            ccbMaDP.DisplayMember = "MaPhong";
            ccbMaDP.ValueMember = "MaPhong";
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            txtThanhTien.Enabled = false;
            LoadView();
            List<DanhSachSuDungDichVu> DSDV = BUS_DanhSachDichVu.Instance.LayDanhSachSuDungDichVu();
            ccbMaSDDV.DataSource = DSDV;
            ccbMaSDDV.DisplayMember = "MaSuDungDichVu";
        }
        public void LengthData()
        {

        }
        private bool ValidateInputs()
        {
            bool isValid = true;
            errorProvider.Clear();

            var controlsToValidate = new Dictionary<Control, string>
    {
        { txtPhuThu, "Phụ thu không được để trống" },
        { txtTienDichVu, "Tiền dịch vụ không được để trống" },
        { ccbGiamGia, "Giảm giá không được để trống" },
        { txtTienPhong, "Tiền phòng không được để trống" },
        { txtSoNgayThue, "Số ngày thuê không được để trống" },
        { txtMaHD, "Mã hóa đơn không được để trống" },
        { ccbMaSDDV, "Mã sử dụng dịch vụ không được để trống" },
        { cboPTTT, "Hình thức thanh toán không được để trống" }
    };

            foreach (var control in controlsToValidate)
            {
                if (string.IsNullOrWhiteSpace(control.Key.Text))
                {
                    errorProvider.SetError(control.Key, control.Value);
                    isValid = false;
                }
            }
            return isValid;
        }

        private void cboPTTT_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInputs())
            {
                return;
            }
            try
            {
                float phuThu = float.Parse(txtPhuThu.Text);
                float tienDichVu = float.Parse(txtTienDichVu.Text);
                float giamGiaKH = float.Parse(ccbGiamGia.Text);
                float tienPhong = float.Parse(txtTienPhong.Text);
                float soNgay = float.Parse(txtSoNgayThue.Text);
                float thanhTien = (phuThu + tienDichVu + (tienPhong * soNgay)) * (1 - giamGiaKH / 100);

                DAO.ChiTietHoaDon chiTietHoaDonMoi = new DAO.ChiTietHoaDon
                {
                    MaHoaDon = txtMaHD.Text,
                    MaDatPhong = ccbMaDP.Text,
                    MaSuDungDichVu = ccbMaSDDV.Text,
                    PhuThu = float.Parse(txtPhuThu.Text),
                    TienPhong = float.Parse(txtTienPhong.Text),
                    TienDichVu = float.Parse(txtTienDichVu.Text),
                    GiamGiaKH = float.Parse(ccbGiamGia.Text),
                    HinhThucThanhToan = cboPTTT.Text,
                    SoNgay = float.Parse(txtSoNgayThue.Text),
                    ThanhTien = thanhTien
                };

                bool ketQua = busHoaDon.ThemChiTietHoaDon(chiTietHoaDonMoi);

                if (ketQua)
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn thành công!");
                    LoadView();
                }
                else
                {
                    MessageBox.Show("Thêm chi tiết hóa đơn thất bại.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void ccbMaSDDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string maPhong = ccbMaDP.SelectedValue?.ToString();

                double giaTien = busPhong.LayGiaTienTheoMaPhong(maPhong);

                txtTienPhong.Text = giaTien.ToString();

                if (!string.IsNullOrEmpty(maPhong))
                {
                    int soNgayThue = busDatPhong.LaySoNgayThue(maPhong);
                    txtSoNgayThue.Text = soNgayThue.ToString();
                }
                else
                {
                    txtSoNgayThue.Text = "0";
                }
                string maDV = ccbMaSDDV.Text;

                txtTienDichVu.Text = busDichVu.LayGiaDV(maDV).ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("lỗi " + ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ccbNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtpNgayXuat_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtMaHoaDon_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaKH_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void dgvHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvHoaDon.Rows[e.RowIndex];
                txtMaHD.Text = row.Cells["MaHoaDon"].Value.ToString();
                ccbMaDP.Text = row.Cells["MaDatPhong"].Value.ToString();
                txtPhuThu.Text = row.Cells["PhuThu"].Value.ToString();
                txtTienPhong.Text = row.Cells["TienPhong"].Value.ToString();
                txtTienDichVu.Text = row.Cells["TienDichVu"].Value.ToString();
                ccbGiamGia.Text = row.Cells["GiamGiaKH"].Value.ToString();
                txtSoNgayThue.Text = row.Cells["SoNgay"].Value.ToString();
                cboPTTT.Text = row.Cells["HinhThucThanhToan"].Value.ToString();
                txtThanhTien.Text = row.Cells["ThanhTien"].Value.ToString();
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void txtMaDatPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtThanhTien_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienPhong_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTienDichVu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhuThu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSoNgayThue_TextChanged(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maHoaDon = txtMaHD.Text;
                bool ketQua = busHoaDon.XoaChiTietHoaDon(maHoaDon);

                if (ketQua)
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn thành công!");
                    LoadView();
                }
                else
                {
                    MessageBox.Show("Xóa chi tiết hóa đơn thất bại hoặc không tìm thấy.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                string maHoaDon = txtMaHD.Text;
                string maDatPhong = ccbMaDP.Text;
                string maSuDungDichVu = ccbMaSDDV.Text;
                float phuThu = float.Parse(txtPhuThu.Text);
                float tienPhong = float.Parse(txtTienPhong.Text);
                float tienDichVu = float.Parse(txtTienDichVu.Text);
                float giamGiaKH = float.Parse(ccbGiamGia.Text);
                string hinhThucThanhToan = cboPTTT.Text;
                float soNgay = float.Parse(txtSoNgayThue.Text);

                float thanhTien = (tienPhong * soNgay + tienDichVu + phuThu) * (1 - giamGiaKH / 100);

                DAO.ChiTietHoaDon chiTietHoaDonMoi = new DAO.ChiTietHoaDon
                {
                    MaHoaDon = maHoaDon,
                    MaDatPhong = maDatPhong,
                    MaSuDungDichVu = maSuDungDichVu,
                    PhuThu = phuThu,
                    TienPhong = tienPhong,
                    TienDichVu = tienDichVu,
                    GiamGiaKH = giamGiaKH,
                    HinhThucThanhToan = hinhThucThanhToan,
                    SoNgay = soNgay,
                    ThanhTien = thanhTien
                };

                bool ketQua = busHoaDon.SuaChiTietHoaDon(chiTietHoaDonMoi);

                if (ketQua)
                {
                    MessageBox.Show("Sửa chi tiết hóa đơn thành công!");
                    LoadView();
                }
                else
                {
                    MessageBox.Show("Sửa chi tiết hóa đơn thất bại hoặc không tìm thấy");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            frmRptHoaDonn frmRptHoaDonn = new frmRptHoaDonn();
            frmRptHoaDonn.ShowDialog();
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
