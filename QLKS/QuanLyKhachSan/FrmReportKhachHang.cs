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
    public partial class FrmReportKhachHang : Form
    {
        public FrmReportKhachHang()
        {
            InitializeComponent();
        }

        private void FrmReportKhachHang_Load(object sender, EventArgs e)
        {

        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter frm = new QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter();
            frm.Connection.ConnectionString = ThayDoichuoiKetNoi.GetConnectionString();
            frm.Fill(quanLyKhachSanDataSet.HienThiThongKeKhachHang, DateTime.Parse(dtpTuNgay.Text), DateTime.Parse(dtpDenNgay.Text));
            this.rptKhachHang.RefreshReport();
        }
    }
}
