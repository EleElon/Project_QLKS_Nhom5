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
using System.Configuration;
using System.Data.Entity;
using System.Xml;

namespace QuanLyKhachSan
{
    public partial class frmThayDoiChuoiKetNoi : Form
    {
        public frmThayDoiChuoiKetNoi()
        {
            InitializeComponent();

            txtTenChuoi.KeyDown += new KeyEventHandler(txtTenChuoi_KeyDown);
        }
        private void UpdateConnectionString(string name, string chuoi)
        {
            string configFilePath = Application.StartupPath + "\\QuanLyKhachSan.exe.config";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFilePath);

            XmlNodeList connectionStrings = xmlDoc.GetElementsByTagName("connectionStrings");

            foreach (XmlNode node in connectionStrings)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Attributes["name"] != null && childNode.Attributes["name"].Value == name)
                    {
                        childNode.Attributes["connectionString"].Value = $"Data Source={chuoi};Initial Catalog=QLKS;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
                        xmlDoc.Save(configFilePath);
                        break;
                    }
                }
            }
        }

        private void DoiChuoiKetNoi(string chuoi)
        {
            ThayDoichuoiKetNoi.SetConnectionString($"Data Source={chuoi};Initial Catalog=QLKS;Integrated Security=True;TrustServerCertificate=True");

            BUS_User.Instance.DoiChuoiKetNoi(chuoi);

            MessageBox.Show("Chuỗi kết nối đã được thay đổi và áp dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateConnectionString("QLKSDataset", chuoi);
            UpdateConnectionString("HoaDonContext", chuoi);
            UpdateConnectionString("PhongContext", chuoi);
            UpdateConnectionString("QuanLyKhachSan.Properties.Settings.QLKSConnectionString3", chuoi);
        }

        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            string chuoiMoi = txtTenChuoi.Text.Trim();

            if (string.IsNullOrEmpty(chuoiMoi))
            {
                MessageBox.Show("Vui lòng nhập chuỗi kết nối hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DoiChuoiKetNoi(chuoiMoi);

                frmDangNhap frm = new frmDangNhap();
                frm.Show();
                this.Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi thay đổi chuỗi kết nối: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnThayDoi_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtTenChuoi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //btnThayDoi_Click(sender, e); 
            }
        }
    }
}
