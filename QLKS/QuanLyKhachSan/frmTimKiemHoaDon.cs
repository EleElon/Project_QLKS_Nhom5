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
    public partial class frmTimKiemHoaDon : Form
    {
        BUS_HoaDon busHoaDon = new BUS_HoaDon();
        public frmTimKiemHoaDon()
        {
            InitializeComponent();
        }
        public void Reset()
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string maHoaDon = ccbMaHD.Text;

                if (string.IsNullOrWhiteSpace(maHoaDon))
                {
                    MessageBox.Show("Vui lòng nhập mã hóa đơn.");
                    return;
                }

                List<ChiTietHoaDon> danhSachHoaDon = busHoaDon.TimKiemHoaDonTheoMa(maHoaDon);

                if (danhSachHoaDon != null && danhSachHoaDon.Count > 0)
                {
                    dgvTimKiemHoaDon.DataSource = danhSachHoaDon;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hóa đơn nào với mã đã nhập.");
                    dgvTimKiemHoaDon.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ccbMaHD.Text = null;
            dgvTimKiemHoaDon.DataSource = null;
        }

        private void frmTimKiemHoaDon_Load(object sender, EventArgs e)
        {
            List<ChiTietHoaDon> DSDV = busHoaDon.HienThi();
            ccbMaHD.DataSource = DSDV;
            ccbMaHD.DisplayMember = "MaHoaDon";
        }
    }
}
