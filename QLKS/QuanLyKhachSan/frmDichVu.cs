using BUS;
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
    public partial class frmDichVu : Form
    {
        public frmDichVu()
        {

            InitializeComponent();
            LoadDuLieuLenForm();

        }

        private void frmDichVu_Load(object sender, EventArgs e)
        {

        }

        public void LoadDuLieuLenForm()
        {
            LoadDuLieu();
            LoadMaDatPhong();
            LoadMaDichVu();
        }

        private void tbSĐichVu_Click(object sender, EventArgs e)
        {

        }
        public void LoadDuLieu()
        {
            BUS_DanhSachDichVu.Instance.Xem(dgvSuDungDichVu);
        }

        private void cbMaDatPhong_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        public void LoadMaDatPhong()
        {
            BUS_DanhSachDichVu.Instance.LoadDatPhong(cbMaDatPhong);
        }
        public void LoadMaDichVu()
        {
            BUS_DanhSachDichVu.Instance.LoadDichVu(cbMaDichVu);
        }
        private void dgvSuDungDichVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_DanhSachDichVu.Instance.LoadDGVLenForm(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong, dgvSuDungDichVu);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            BUS_DanhSachDichVu.Instance.Them(txtMaSDDV, cbMaDichVu, cbMaDatPhong, txtSoLuong);
            LoadDuLieuLenForm();
            ClearFormFields();
        }

        private void btnHuyPhieu_Click(object sender, EventArgs e)
        {
            BUS_DanhSachDichVu.Instance.Xoa(txtMaSDDV);
            ClearFormFields();
            LoadDuLieuLenForm();
        }
        // Hàm để làm sạch các trường trong form
        private void ClearFormFields()
        {
            txtMaSDDV.Text = string.Empty;
            cbMaDichVu.SelectedIndex = 0;
            cbMaDatPhong.SelectedIndex = 0;
            txtSoLuong.Text = string.Empty;

            // Clear các trường khác nếu cần

        }

        private void btnCapNhap_Click(object sender, EventArgs e)
        {
            BUS_DanhSachDichVu.Instance.Sua(txtMaSDDV,cbMaDichVu,cbMaDatPhong,txtSoLuong);
            LoadDuLieuLenForm();
        }
    }
}
