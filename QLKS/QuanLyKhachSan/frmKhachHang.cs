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
    public partial class frmKhachHang : Form
    {
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
            BUS_KhachHang.Instance.Them(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
            LoadDuLieuLen();
            ClearFormFields();
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
            ClearFormFields() ;
        }

        private void dgvDSKhachHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_KhachHang.Instance.LoadDGVLenForm(txtMaKH,cbMaDichVu,txtTenKH, txtCCCD,txtEmail, txtSDT,txtDiaChi,dgvDSKhachHang);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            BUS_KhachHang.Instance.Sua(txtMaKH, cbMaDichVu, txtTenKH, txtCCCD, txtEmail, txtSDT, txtDiaChi);
            LoadDuLieuLen();
        }
    }
}
