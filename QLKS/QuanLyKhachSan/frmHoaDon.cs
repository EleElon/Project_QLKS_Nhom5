using BUS;
using DAO;
using QuanLyKhachSan;
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
        BUS_DanhSachDichVu busDSDichVu = new BUS_DanhSachDichVu();
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
        }
        private void frmHoaDon_Load(object sender, EventArgs e)
        {
            LoadView();
            dgvHoaDon.Columns["DanhSachSuDungDichVu"].Visible = false;
            dgvHoaDon.Columns["DatPhong"].Visible = false;
            dgvHoaDon.Columns["HoaDon"].Visible = false;
            List<DanhSachSuDungDichVu> DSDV = busDSDichVu.HienThi();
            ccbMaSDDV.DataSource = DSDV;
            ccbMaSDDV.DisplayMember = "MaSuDungDichVu"; // Hiển thị tên loại phòng trong ComboBox
            
        }

        private void cboPTTT_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
    }
}
