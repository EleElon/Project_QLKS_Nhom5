using BUS;
using DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Xml.Serialization;

namespace QuanLyKhachSan
{
    public partial class frmLuong : Form
    {
        ErrorProvider errorProvider = new ErrorProvider();
        BUS_Luong bus_luong = new BUS_Luong();
        public frmLuong()
        {
            InitializeComponent();
        }
        public void FormDataBiding()
        {
            dtpNgayTinh.MaxDate = DateTime.Now;
            dtpNgayTinh.MinDate = new DateTime(2000, 1, 1);

            cboMaNV.Enabled = false;
            txtLuongCoBan.Text = "7000000";
            txtPhuCap.Text = "0";
            txtMaLuong.MaxLength = 100;
            txtThang.Enabled = false;
            txtNam.Enabled = false;
            txtSoNgayLam.Enabled = false;
            txtSoGioTangCa.Enabled = false;
            txtLuongCoBan.Enabled = false;
            //txtPhuCap.Enabled = false;
            txtThuong.Enabled = false;
            txtKhauTru.Enabled = false;
            txtTongLuong.Enabled = false;
        }
        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLuong_Load(object sender, EventArgs e)
        {
            //DSLuong(dgvDSLuong);
            LoadDataLuong();
            LoadComboMaCham();
            LoadComboMaNV();
            FormDataBiding();
        }

        public void LoadDataLuong()
        {
            BUS_Luong.Instance.Xem(dgvDSLuong);
        }
        public void LoadComboMaCham()
        {
            BUS_Luong.Instance.LoadMaCham(cboMaBangChamCong);
        }
        public void LoadComboMaNV()
        {
            BUS_Luong.Instance.LoadMaNhanVien(cboMaNV);
        }
        public void ClearFormFields()
        {
            txtMaLuong.Enabled = true;
            txtMaLuong.Text = string.Empty;
            cboMaBangChamCong.SelectedIndex = 0;
            cboMaNV.SelectedIndex = 0;
            txtThang.Text = string.Empty;
            txtNam.Text = string.Empty;
            txtSoNgayLam.Text = string.Empty;
            txtSoGioTangCa.Text = string.Empty;
            txtLuongCoBan.Text = "7000000";
            txtPhuCap.Text = "0";
            txtThuong.Text = string.Empty;
            txtKhauTru.Text = string.Empty;
            txtTongLuong.Text = string.Empty;
            dtpNgayTinh.Value = DateTime.UtcNow;

            //set validate == null
            errorProvider.SetError(txtMaLuong, "");
            //errorProvider.SetError(txtThang, "");
            //errorProvider.SetError(txtNam, "");
        }
        private bool ValidateForm()
        {
            //ValidateThang();
            //ValidateSoTien();

            return string.IsNullOrEmpty(errorProvider.GetError(txtMaLuong));/*&&*/
            //    string.IsNullOrEmpty(errorProvider.GetError(txtThang)) &&
            //    string.IsNullOrEmpty(errorProvider.GetError(txtNam));
        }
        private void ValidateMaLuong()
        {
            string pattern = @"^(l|L)[0-9]+$";

            if (string.IsNullOrEmpty(txtMaLuong.Text))
            {
                errorProvider.SetError(txtMaLuong, "Vui lòng nhập mã lương! Bắt đầu từ l / L sau đó là ký tự số");
            }
            else if (BUS_Luong.Instance.CheckMaLuongExists(txtMaLuong.Text))
            {
                errorProvider.SetError(txtMaLuong, "Mã lương đã tồn tại");
            }
            else if (!Regex.IsMatch(txtMaLuong.Text, pattern))
            {
                errorProvider.SetError(txtMaLuong, "Mã lương phải bắt đầu từ l / L sau đó là ký tự sô");
            }
            else
            {
                errorProvider.SetError(txtMaLuong, "");
            }
        }
        private void ValidateThang()
        {
            if (string.IsNullOrEmpty(txtThang.Text))
            {
                errorProvider.SetError(txtThang, "Vui lòng nhập tháng");
            }
            else if (!int.TryParse(txtThang.Text, out int thang))
            {
                errorProvider.SetError(txtThang, "Vui lòng nhập tháng với ký tự số");
            }
            else if (0 > thang || thang > 12)
            {
                errorProvider.SetError(txtThang, "Tháng chỉ có thể bắt đầu từ tháng 1 và kết thúc bằng tháng 12");
            }
            else
            {
                errorProvider.SetError(txtThang, "");
            }
        }
        private void ValidateSoTien()
        {
            if (string.IsNullOrEmpty(txtNam.Text))
            {
                errorProvider.SetError(txtNam, "Vui lòng nhập số tiền");
            }
            else if (!int.TryParse(txtNam.Text, out int soTien))
            {
                errorProvider.SetError(txtNam, "Số tiền chỉ có thể nhập bằng ký tự số");
            }
            else if (soTien < 0)
            {
                errorProvider.SetError(txtNam, "Số tiền không được phép âm");
            }
            else
            {
                errorProvider.SetError(txtNam, "");
            }
        }
        //public void DSLuong(DataGridView data)
        //{
        //    using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
        //    {
        //        var luong = db.Luongs.Select(a => new
        //        {
        //            a.MaLuong,
        //            a.MaNhanVien,
        //            a.Thang,
        //            a.SoTien
        //        }).ToList();
        //        data.DataSource = luong;
        //    }
        //}

        public void LoadView()
        {
            dgvDSLuong.DataSource = bus_luong.View();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maNV = txtMaLuong.Text;

                if (System.Text.RegularExpressions.Regex.IsMatch(maNV, @"^(l|L)\d+$"))
                {
                    maNV = "L" + maNV.Substring(1);
                    txtMaLuong.Text = maNV;
                }
                else
                {
                    MessageBox.Show("Mã lương phải bắt đầu bằng 'l' hoặc 'L' và theo sau là số.");
                    return;
                }

                BUS_Luong.Instance.ThemLuong(txtMaLuong, cboMaBangChamCong, cboMaNV, txtThang, txtNam, txtSoNgayLam, txtSoGioTangCa, txtLuongCoBan, txtPhuCap, txtThuong, txtKhauTru, txtTongLuong, dtpNgayTinh);
                LoadDataLuong();
                ClearFormFields();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maLuong = txtMaLuong.Text;
                bool result = bus_luong.XoaLuong(maLuong);
                if (result)
                {
                    MessageBox.Show("Xóa lương thành công.");
                    LoadDataLuong();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Xóa lương không thành công. Không tìm thấy lương.");
                }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (ValidateForm())
            {
                string maLuong = txtMaLuong.Text;
                string maCham = cboMaBangChamCong.SelectedValue.ToString();
                string tenNV = cboMaNV.SelectedValue.ToString();
                int thang = int.Parse(txtThang.Text);
                int nam = int.Parse(txtNam.Text);
                int soNgayLam = int.Parse(txtSoNgayLam.Text);
                float soGioTangCa = float.Parse(txtSoGioTangCa.Text);
                float luongCoBan = float.Parse(txtLuongCoBan.Text);
                float phuCap = float.Parse(txtPhuCap.Text);
                float thuong = float.Parse(txtThuong.Text);
                float khauTru = float.Parse(txtKhauTru.Text);
                float tongLuong = float.Parse(txtTongLuong.Text);
                DateTime ngayTinh = dtpNgayTinh.Value;

                bool result = bus_luong.SuaLuong(maLuong, maCham, tenNV, thang, nam, soNgayLam, soGioTangCa, luongCoBan, phuCap, thuong, khauTru, tongLuong, ngayTinh);
                if (result)
                {
                    MessageBox.Show("Sửa thông tin lương thành công.");
                    LoadDataLuong();
                    ClearFormFields();
                }
                else
                {
                    MessageBox.Show("Sửa thông tin lương không thành công. Không tìm thấy lương.");
                }
            }
        }

        private void dgvDSLuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BUS_Luong.Instance.LoadDGVLenForm(txtMaLuong, cboMaBangChamCong, cboMaNV, txtThang, txtNam, txtSoNgayLam, txtSoGioTangCa, txtLuongCoBan, txtPhuCap, txtThuong, txtKhauTru, txtTongLuong, dtpNgayTinh, dgvDSLuong);

            txtMaLuong.Enabled = false;
            errorProvider.SetError(txtMaLuong, "");
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFormFields();
        }

        private void txtMaLuong_TextChanged(object sender, EventArgs e)
        {
            ValidateMaLuong();
        }

        private void cboMaBangChamCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã nhân viên từ ComboBox
            string maCham = cboMaBangChamCong.SelectedValue.ToString();
            //string maNhanVien = cboMaBangChamCong.SelectedValue.ToString();

            using (var db = new DBQuanLyKhachSanDataContext()) // Tên context của bạn
            {
                // Lấy dữ liệu chấm công của nhân viên
                var chamCong = db.ChamCongs
                    .Where(c => c.MaChamCong == maCham)
                    .OrderByDescending(c => c.Thang) // Lấy tháng gần nhất
                    .FirstOrDefault();
                //    var nhanVien = db.NhanViens
                //.Where(nv => nv.MaNhanVien == maNhanVien)
                //.FirstOrDefault();

                if (chamCong != null)
                {
                    //// Lấy mã nhân viên từ dữ liệu chấm công
                    //string maNhanVien = chamCong.MaNhanVien; // Lấy mã nhân viên từ chamCong

                    //// Lấy thông tin nhân viên từ bảng nhân viên
                    //var nhanVien = db.NhanViens
                    //    .Where(nv => nv.MaNhanVien == maNhanVien)
                    //    .FirstOrDefault();

                    //// Kiểm tra xem nhân viên có tồn tại không
                    //if (nhanVien != null)
                    //{
                    //    // Điền dữ liệu vào các TextBox
                    //    txtTenNV.Text = nhanVien.TenNhanVien; // Hiển thị tên nhân viên
                    //}

                    // Lấy mã nhân viên từ dữ liệu chấm công
                    string maNhanVien = chamCong.MaNhanVien;

                    // Lấy thông tin nhân viên
                    var nhanVien = db.NhanViens
                        .Where(nv => nv.MaNhanVien == maNhanVien)
                        .FirstOrDefault();

                    if (nhanVien != null)
                    {
                        // Gán dữ liệu vào ComboBox mã nhân viên (hiển thị tên)
                        cboMaNV.DataSource = new List<NhanVien> { nhanVien }; // Tạo danh sách chỉ có một nhân viên
                        cboMaNV.DisplayMember = "TenNhanVien"; // Hiển thị tên nhân viên
                        cboMaNV.ValueMember = "MaNhanVien"; // Giữ giá trị là mã nhân viên
                        //cboMaNV.SelectedValue = nhanVien.MaNhanVien.ToString();
                    }

                    // Điền dữ liệu vào các TextBox
                    //cboMaNV.Text = chamCong.MaNhanVien.ToString();
                    txtThang.Text = chamCong.Thang.ToString();
                    txtNam.Text = chamCong.Nam.ToString();
                    txtSoNgayLam.Text = chamCong.SoNgayLamViec.ToString();
                    txtSoGioTangCa.Text = chamCong.SoGioTangCa.ToString();
                    txtPhuCap.Text = "0";

                    int soNgayLam;
                    if (int.TryParse(txtSoNgayLam.Text, out soNgayLam))
                    {
                        // Tính thưởng và khấu trừ
                        float thuong = (soNgayLam - 28) * 200000;
                        float khauTru = (28 - soNgayLam) * 200000;

                        // Cập nhật TextBox cho thưởng và khấu trừ
                        txtThuong.Text = thuong > 0 ? thuong.ToString() : "0"; // Nếu thưởng âm, hiển thị 0
                        txtKhauTru.Text = khauTru > 0 ? khauTru.ToString() : "0"; // Nếu khấu trừ âm, hiển thị 0
                    }

                    CalculateTotalPrice();
                }
                //else
                //{
                //    // Nếu không có dữ liệu
                //    MessageBox.Show("Không tìm thấy dữ liệu chấm công cho nhân viên này!", "Thông báo");
                //}
            }
        }
        private void CalculateTotalPrice()
        {
            if (int.TryParse(txtLuongCoBan.Text, out int luongCoBan) && int.TryParse(txtSoNgayLam.Text, out int soNgayLam) && float.TryParse(txtSoGioTangCa.Text, out float soGioTangCa) && float.TryParse(txtPhuCap.Text, out float phuCap) && float.TryParse(txtThuong.Text, out float thuong) && float.TryParse(txtKhauTru.Text, out float khautru))
            {
                float tongLuong = (float)(((luongCoBan / 28) * soNgayLam) + (1.5 * (soGioTangCa * 10000)) + phuCap + thuong - khautru);
                //txtDonGia.Text = giaSauGiamGia.ToString();

                // Định dạng số để hiển thị đúng trong TextBox
                //txtTongLuong.Text = tongLuong.ToString("N0"); // "N0" để hiển thị số nguyên, không có dấu phẩy
                txtTongLuong.Text = tongLuong.ToString();
            }
        }

        private void txtPhuCap_TextChanged(object sender, EventArgs e)
        {
            CalculateTotalPrice();
        }
        private void MoveCursorToEnd(TextBox txt)
        {
            txt.SelectionStart = txt.Text.Length;
        }

        private void txtPhuCap_Click(object sender, EventArgs e)
        {
            if (txtPhuCap.Text == "0")
            {
                txtPhuCap.Text = string.Empty;
            }
            else
            {
                MoveCursorToEnd(txtPhuCap);
            }
        }
    }
}
