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

            // Gán sự kiện KeyDown cho các TextBox
            txtTenChuoi.KeyDown += new KeyEventHandler(txtTenChuoi_KeyDown);
        }
        //private void DoiChuoiKetNoi(string chuoi)
        //{
        //    // Gọi phương thức trong BUS để thay đổi chuỗi kết nối cho ứng dụng
        //    ThayDoichuoiKetNoi.SetConnectionString($"Data Source={chuoi};Initial Catalog=QLKS;Integrated Security=True;TrustServerCertificate=True");

        //    // Cập nhật chuỗi kết nối cho các đối tượng cần sử dụng như BUS, DAO (nếu có)
        //    BUS_User.Instance.DoiChuoiKetNoi(chuoi); // Ví dụ với BUS_User

        //    // Thay đổi chuỗi kết nối trong file .exe.config
        //    UpdateConnectionString("QLKSDataset", chuoi);
        //    UpdateConnectionString("HoaDonContext", chuoi);
        //    UpdateConnectionString("PhongContext", chuoi);
        //}

        // Hàm cập nhật chuỗi kết nối trong QuanLyKhachSan.exe.Config
        private void UpdateConnectionString(string name, string chuoi)
        {
            string configFilePath = Application.StartupPath + "\\QuanLyKhachSan.exe.config";
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(configFilePath);

            // Tìm kiếm phần tử connectionStrings
            XmlNodeList connectionStrings = xmlDoc.GetElementsByTagName("connectionStrings");

            foreach (XmlNode node in connectionStrings)
            {
                foreach (XmlNode childNode in node.ChildNodes)
                {
                    if (childNode.Attributes["name"] != null && childNode.Attributes["name"].Value == name)
                    {
                        // Thay đổi giá trị chuỗi kết nối
                        childNode.Attributes["connectionString"].Value = $"Data Source={chuoi};Initial Catalog=QLKS;Integrated Security=True;TrustServerCertificate=True;MultipleActiveResultSets=True;App=EntityFramework";
                        xmlDoc.Save(configFilePath);
                        //MessageBox.Show("Chuỗi kết nối đã được thay đổi!");
                        break;
                    }
                }
            }
        }

        //// Xử lý sự kiện thay đổi chuỗi kết nối khi người dùng nhấn nút
        //private void btnThayDoi_Click(object sender, EventArgs e)
        //{
        //    DoiChuoiKetNoi(txtTenChuoi.Text);
        //    frmDangNhap frm = new frmDangNhap();
        //    frm.Show();
        //    this.Hide();
        //}

        /// <summary>
        /// Thay đổi chuỗi kết nối cho ứng dụng
        /// </summary>
        /// <param name="chuoi">Chuỗi kết nối mới</param>
        private void DoiChuoiKetNoi(string chuoi)
        {
            // Gọi phương thức trong BUS để thay đổi chuỗi kết nối cho ứng dụng
            ThayDoichuoiKetNoi.SetConnectionString($"Data Source={chuoi};Initial Catalog=QLKS;Integrated Security=True;TrustServerCertificate=True");

            // Cập nhật chuỗi kết nối trong các lớp BUS, DAO (nếu cần)
            BUS_User.Instance.DoiChuoiKetNoi(chuoi);

            // Thông báo thành công
            MessageBox.Show("Chuỗi kết nối đã được thay đổi và áp dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            UpdateConnectionString("QLKSDataset", chuoi);
            UpdateConnectionString("HoaDonContext", chuoi);
            UpdateConnectionString("PhongContext", chuoi);
        }

        /// <summary>
        /// Xử lý sự kiện thay đổi chuỗi kết nối khi người dùng nhấn nút
        /// </summary>
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
                // Gọi hàm đổi chuỗi kết nối
                DoiChuoiKetNoi(chuoiMoi);

                // Chuyển sang form đăng nhập
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
                //btnThayDoi_Click(sender, e); // Gọi sự kiện tìm kiếm
            }
        }



    }
}
