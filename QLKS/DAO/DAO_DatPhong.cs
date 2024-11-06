using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_DatPhong
    {
        private static DAO_DatPhong instance;
        public static DAO_DatPhong Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_DatPhong();
                }
                return instance;
            }
        }
        private DAO_DatPhong() { }

        public List<ChiTietDatPhong> Xem()
        {
            List<ChiTietDatPhong> data = new List<ChiTietDatPhong>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var datphong = (from dv in db.ChiTietDatPhongs
                              select new
                              {
                                  dv.MaChiTietDatPhong,
                                  dv.MaDatPhong,
                                  dv.MaKhachHang,
                                  dv.MaPhong,
                                  dv.MaLoaiPhong,
                                  dv.TinhTrang,
                                  dv.GiaMoiDem,
                                  dv.SoLuongPhong,
                                  dv.TongGia,
                                  dv.PhuongThucThanhToan,
                                  dv.NgayNhanPhong,
                                  dv.NgayTraPhong
                              }).ToList();

                foreach (var item in datphong)
                {
                    ChiTietDatPhong datp = new ChiTietDatPhong();
                    datp.MaChiTietDatPhong = item.MaChiTietDatPhong;
                    datp.MaDatPhong = item.MaDatPhong;
                    datp.MaKhachHang = item.MaKhachHang;
                    datp.MaPhong = item.MaPhong;
                    datp.MaLoaiPhong = item.MaLoaiPhong;
                    datp.TinhTrang = item.TinhTrang;
                    datp.GiaMoiDem = item.GiaMoiDem;    
                    datp.SoLuongPhong = item.SoLuongPhong;
                    datp.TongGia = item.TongGia;    
                    datp.PhuongThucThanhToan = item.PhuongThucThanhToan;
                    datp.NgayNhanPhong = item.NgayNhanPhong;
                    datp.NgayTraPhong = item.NgayTraPhong;

                    data.Add(datp);
                }
            }
            return data;
           
        }
        public List<DatPhong> XemDatPhong()
        {

            List<DatPhong> data = new List<DatPhong>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var datphong = (from dv in db.DatPhongs
                                select new
                                {
                                 
                                    dv.MaDatPhong,
                                    dv.MaKhachHang,
                                   
                                }).ToList();

                foreach (var item in datphong)
                {
                    DatPhong datp = new DatPhong();
                  
                    datp.MaDatPhong = item.MaDatPhong;
                    datp.MaKhachHang = item.MaKhachHang;
                

                    data.Add(datp);
                }
            }
            return data;

        }

        public void LoadTenKhachhangODatPhong(ComboBox cb)
        {
            Dictionary<string, string> dp = new Dictionary<string, string>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maKH = from ma in db.KhachHangs
                           select new
                           {
                               ma.MaKhachHang,
                               ma.TenKhachHang
                           };


                foreach (var item in maKH)
                {
                    dp.Add(item.MaKhachHang, item.TenKhachHang);
                }

                cb.DataSource = new BindingSource(dp, null);
                cb.DisplayMember = "Value";
                cb.ValueMember = "Key";
            }
        }

        public void LoadComBoBoxDatPhong(ComboBox cb)
        {
            cb.Items.Clear(); // Clear existing items to avoid duplication

            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maDPhong = from ma in db.DatPhongs
                               select ma.MaDatPhong;

                foreach (var item in maDPhong)
                {
                    cb.Items.Add(item); // Add each item individually
                }
            }
        }

        public string LoadComBoBoxKhachHang(string tenKH)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                string b = "";
                if (tenKH != "")
                {
                    var tkh = db.KhachHangs.FirstOrDefault(x => x.TenKhachHang == tenKH);
                    b = tkh.MaKhachHang;
                }                  
                return b;

            }
        }


        public void LoadDGVFormDatPhong( TextBox maDatPhong, ComboBox maKH, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var rowIndex = data.SelectedCells[0].RowIndex;
                var row = data.Rows[rowIndex];
                  maDatPhong.Text = row.Cells[0].Value.ToString().Trim();
                maKH.SelectedValue = row.Cells[1].Value.ToString().Trim();
             
             
            }
        }


        public void ThemDP(DatPhong dv)
        {
            try
            {
                // Kiểm tra mã khách hàng đã tồn tại hay chưa
                if (CheckMaSDDVExists(dv.MaDatPhong))
                {
                    MessageBox.Show("Mã su dung vu đã tồn tại. Vui lòng nhập mã khác.");
                    return; // Không thực hiện thêm nếu mã đã tồn tại
                }

                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {

                    db.DatPhongs.InsertOnSubmit(dv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Thêm vào bị lỗi ");
            }
        }
        public void XoaDatPhong(string maDP)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var ma = db.DatPhongs.FirstOrDefault(a => a.MaDatPhong == maDP);
                if (ma != null)
                {
                    db.DatPhongs.DeleteOnSubmit(ma);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        public bool SuaDatPhong(DatPhong maDPP)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maSDDV = db.DatPhongs.SingleOrDefault(a => a.MaDatPhong == maDPP.MaDatPhong);
                if (maSDDV != null)
                {

                    
                    maSDDV.MaDatPhong = maDPP.MaDatPhong;
                    maSDDV.MaKhachHang = maDPP.MaKhachHang;
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    return true;
                }
                return false;
            }
        }
        public bool CheckMaSDDVExists(string maDP)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString())) // Giả sử đây là context của Entity Framework
            {
                // Sử dụng LINQ để kiểm tra trùng mã
                return context.DatPhongs.Any(dv => dv.MaDatPhong == maDP);
            }
        }
        public string GetCustomerNameByBookingId(string maDatPhong)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var customer = (from dp in db.DatPhongs
                                join kh in db.KhachHangs on dp.MaKhachHang equals kh.MaKhachHang
                                where dp.MaDatPhong == maDatPhong
                                select kh.TenKhachHang).FirstOrDefault();
                return customer ?? "Not Found";
            }
        }




        public void LoadComBoBoxLoaiPhong(ComboBox cb, string maphong, TextBox tinhtrang)
        {
            // Initialize the dictionary for data binding.
            Dictionary<string, string> dp = new Dictionary<string, string>();

            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                // Query the database to get room details.
                var result = (from dp1 in db.ChiTietDatPhongs
                              join kh in db.Phongs on dp1.MaPhong equals kh.MaPhong
                              join loai in db.LoaiPhongs on kh.MaLoaiPhong equals loai.MaLoaiPhong
                              where dp1.MaPhong == maphong
                              select new { loai.TenLoaiPhong, kh.TinhTrang, loai.MaLoaiPhong }).FirstOrDefault();

                // Check if a result was found.
                if (result != null)
                {
                    // Add the result to the dictionary.
                    dp.Add(result.MaLoaiPhong, result.TenLoaiPhong);

                    // Bind the dictionary to the ComboBox.
                    cb.DataSource = new BindingSource(dp, null);
                    cb.DisplayMember = "Value";
                    cb.ValueMember = "Key";

                    // Set the TextBox value.
                    tinhtrang.Text = result.TinhTrang;
                }
                else
                {
                    // If no result is found, clear the ComboBox and TextBox.
                    cb.DataSource = null;
                    tinhtrang.Clear();
                }
            }
        }

        public void LoadComBoBoxPhong(ComboBox cb)
        {
            Dictionary<string, string> dp = new Dictionary<string, string>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maDPhong = from ma in db.Phongs
                               select (
                                   ma.MaPhong);

                foreach (var item in maDPhong)
                {
                    dp.Add(item, item);
                }

                cb.DataSource = new BindingSource(dp, null);
                cb.DisplayMember = "Value";
                cb.ValueMember = "Key";
            }
        }

        public void LoadDGVFormCTDatPhong(TextBox ma, ComboBox maDP, ComboBox maKH, ComboBox maP, ComboBox maL, TextBox tinhTrang,TextBox gia,TextBox soLuong,TextBox tong,DateTimePicker ngayNhan,DateTimePicker ngayTra, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var rowIndex = data.SelectedCells[0].RowIndex;
                var row = data.Rows[rowIndex];

                ma.Text = row.Cells[0].Value.ToString().Trim();
                maDP.Text = row.Cells[1].Value != null ? row.Cells[1].Value.ToString().Trim() : null;
                maKH.SelectedValue = row.Cells[2].Value != null ? row.Cells[2].Value.ToString().Trim() : null;
                maP.Text = row.Cells[3].Value != null ? row.Cells[3].Value.ToString().Trim() : null;
                maL.SelectedValue = row.Cells[4].Value != null ? row.Cells[4].Value.ToString().Trim() : null;
                tinhTrang.Text = row.Cells[5].Value.ToString().Trim();
                gia.Text = row.Cells[6].Value.ToString().Trim();
                soLuong.Text = row.Cells[7].Value.ToString().Trim();
                tong.Text = row.Cells[8].Value.ToString().Trim();
                // Parse the date fields safely
                if (DateTime.TryParse(row.Cells[9].Value?.ToString(), out DateTime ngayNhanValue))
                {
                    ngayNhan.Value = ngayNhanValue;
                }
                else
                {
                    ngayNhan.Value = DateTime.Now; // Set a default date if parsing fails
                }

                if (DateTime.TryParse(row.Cells[10].Value?.ToString(), out DateTime ngayTraValue))
                {
                    ngayTra.Value = ngayTraValue;
                }
                else
                {
                    ngayTra.Value = DateTime.Now;
                }
            }
        }

        public void ThemChiTietDatPhong(ChiTietDatPhong chiTiet)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    // Thêm chi tiết đặt phòng vào cơ sở dữ liệu
                    db.ChiTietDatPhongs.InsertOnSubmit(chiTiet);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm chi tiết đặt phòng thành công");
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Thêm chi tiết đặt phòng bị lỗi: " );
            }
        }
        public void Xoa(string maCTDP)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var ma = db.ChiTietDatPhongs.FirstOrDefault(a => a.MaChiTietDatPhong == maCTDP);
                if (ma != null)
                {
                    db.ChiTietDatPhongs.DeleteOnSubmit(ma);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        public string LaymaKhachHang(string tenKH)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                string b = "";
                var a = db.KhachHangs.FirstOrDefault(x=> x.TenKhachHang == tenKH);
                b = a.MaKhachHang;
                return b;
            }
        }
    }
}
