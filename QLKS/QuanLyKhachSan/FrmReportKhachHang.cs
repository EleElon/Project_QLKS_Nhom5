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
        string tungay = "";
        string denngay = "";
        public FrmReportKhachHang()
        {
            InitializeComponent();
        }
        public FrmReportKhachHang(string tungay, string denngay)
        {
            InitializeComponent();
            this.tungay = tungay;
            this.denngay = denngay;
        }

        private void FrmReportKhachHang_Load(object sender, EventArgs e)
        {
            QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter frm = new QuanLyKhachSanDataSetTableAdapters.HienThiThongKeKhachHangTableAdapter();
            frm.Connection.ConnectionString = ThayDoichuoiKetNoi.GetConnectionString();
            frm.Fill(quanLyKhachSanDataSet.HienThiThongKeKhachHang, DateTime.Parse(tungay), DateTime.Parse(denngay));
            this.rptKhachHang.RefreshReport();
        }
    }
}
