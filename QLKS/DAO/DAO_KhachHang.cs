using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_KhachHang
    {
        private static DAO_KhachHang instance;
        public static DAO_KhachHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_KhachHang();
                }
                return instance;
            }
        }
        private DAO_KhachHang() { }

        public List<KhachHang> Xem()
        {
            List<KhachHang> data = new List<KhachHang>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var khachHang = (from kh in db.KhachHangs
                              select new
                              {
                                  kh.MaKhachHang,
                                  kh.MaDichVu,
                                  kh.TenKhachHang,
                                  kh.CCCD,
                                  kh.Email,
                                  kh.SDT,
                                  kh.DiaChi,
                              }).ToList();

                foreach (var item in khachHang)
                {
                    KhachHang dvu = new KhachHang();
                    dvu.MaKhachHang = item.MaKhachHang;
                    dvu.MaDichVu = item.MaDichVu;
                    dvu.TenKhachHang = item.TenKhachHang;
                    dvu.CCCD = item.CCCD;
                    dvu.Email = item.Email;
                    dvu.SDT = item.SDT; 
                    dvu.DiaChi = item.DiaChi;
            
                    data.Add(dvu);
                }

            }
            return data;
        }

        public void LoadComBoBoxDichVu(ComboBox cb)
        {
            Dictionary<string, string> dp = new Dictionary<string, string>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var tenDV = from ma in db.DichVus
                            join dv in db.DichVus on ma.MaDichVu equals dv.MaDichVu
                            select new
                            {
                                ma.MaDichVu,
                                dv.TenDichVu,
                            };

                foreach (var item in tenDV)
                {
                    dp.Add(item.MaDichVu, item.TenDichVu);
                }

                cb.DataSource = new BindingSource(dp, null);
                cb.DisplayMember = "Value";  // Hiển thị tên dịch vụ
                cb.ValueMember = "Key";      // Giá trị là mã dịch vụ
            }
        }

    
    public void LoadDGVForm(TextBox maKH, ComboBox maDichVu, TextBox tenKH, TextBox cccd,TextBox email, TextBox sdt,TextBox diaChi, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                //var rowIndex = data.SelectedCells[0].RowIndex;
                //var row = data.Rows[rowIndex];
                //maKH.Text = row.Cells[0].Value.ToString().Trim();
                //// Thiết lập lại giá trị ComboBox bằng mã dịch vụ
                //maDichVu.SelectedValue = row.Cells[1].Value.ToString().Trim();
                //tenKH.Text = row.Cells[2].Value.ToString().Trim();
                //cccd.Text = row.Cells[3].Value.ToString().Trim();
                //email.Text = row.Cells[4].Value.ToString().Trim();
                //sdt.Text = row.Cells[5].Value.ToString().Trim();
                //diaChi.Text = row.Cells[6].Value.ToString().Trim();

                // Lấy chỉ số dòng được chọn
                var rowIndex = data.SelectedCells[0].RowIndex;
                var row = data.Rows[rowIndex];

                // Lấy giá trị cho từng ô với kiểm tra
                maKH.Text = row.Cells[0].Value != null ? row.Cells[0].Value.ToString().Trim() : string.Empty;
                maDichVu.SelectedValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString().Trim() : null; // Không gán nếu null
                tenKH.Text = row.Cells[2].Value != null ? row.Cells[2].Value.ToString().Trim() : string.Empty;
                cccd.Text = row.Cells[3].Value != null ? row.Cells[3].Value.ToString().Trim() : string.Empty;
                email.Text = row.Cells[4].Value != null ? row.Cells[4].Value.ToString().Trim() : string.Empty;
                sdt.Text = row.Cells[5].Value != null ? row.Cells[5].Value.ToString().Trim() : string.Empty;
                diaChi.Text = row.Cells[6].Value != null ? row.Cells[6].Value.ToString().Trim() : string.Empty;


            }
        }
        public void Them(KhachHang kh)
        {
            try
            {
                // Kiểm tra mã khách hàng đã tồn tại hay chưa
                if (CheckMaExists(kh.MaKhachHang))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác.");
                    return; // Không thực hiện thêm nếu mã đã tồn tại
                }

                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    
                    db.KhachHangs.InsertOnSubmit(kh);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception )
            {

                MessageBox.Show("Thêm vào bị lỗi ");
            }
        }
        public void Xoa(string maKH)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var ma = db.KhachHangs.FirstOrDefault(a => a.MaKhachHang == maKH);
                if (ma != null)
                {
                    db.KhachHangs.DeleteOnSubmit(ma);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }
        public bool Sua(KhachHang kh)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maKH = db.KhachHangs.SingleOrDefault(a => a.MaKhachHang == kh.MaKhachHang);
                if (maKH != null)
                {
                
                    maKH.MaDichVu = kh.MaDichVu;
                    maKH.TenKhachHang = kh.TenKhachHang;
                    maKH.CCCD = kh.CCCD;
                    maKH.Email= kh.Email;
                    maKH.SDT = kh.SDT;
                    maKH.DiaChi =kh.DiaChi;
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    return true;

                }
                return false;
            }
        }
        //kiểm tra trùng mã
        public bool CheckMaExists(string maKH)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString())) // Giả sử đây là context của Entity Framework
            {
                // Sử dụng LINQ để kiểm tra trùng mã
                return context.KhachHangs.Any(dv => dv.MaKhachHang == maKH);
            }
            
        }

    }
}
