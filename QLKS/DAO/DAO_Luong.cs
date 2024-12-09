using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_Luong
    {
        private DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

        private static DAO_Luong instance;
        public static DAO_Luong Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_Luong();
                }
                return instance;
            }
        }
        public DAO_Luong() { }
        public List<Luong> Xem()
        {
            List<Luong> data = new List<Luong>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var luong = db.Luongs.ToList();

                foreach (var item in luong)
                {
                    data.Add(new Luong
                    {
                        MaLuong = item.MaLuong,
                        MaChamCong = item.MaChamCong,
                        MaNhanVien = item.MaNhanVien,
                        Thang = item.Thang,
                        Nam = item.Nam,
                        SoNgayLamViec = item.SoNgayLamViec,
                        SoGioTangCa = item.SoGioTangCa,
                        LuongCoBan = item.LuongCoBan,
                        PhuCap = item.PhuCap,
                        Thuong = item.Thuong,
                        KhauTru = item.KhauTru,
                        TongLuong = item.TongLuong,
                        NgayTinhLuong = item.NgayTinhLuong
                    });
                }
            }
            return data;
        }
        public void Them(Luong a)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    db.Luongs.InsertOnSubmit(a);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công " + ex);
            }
        }

        public bool XoaLuong(string maLuong)
        {
            try
            {
                Luong luong = db.Luongs.FirstOrDefault(a => a.MaLuong == maLuong);
                if (luong != null)
                {
                    db.Luongs.DeleteOnSubmit(luong);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaLuong(string maLuong, string maCham, string maNV, int thang, int nam, int soNgayLamViec, float soGioTangCa, float luongCoBan, float phuCap, float thuong, float khauTru, float tongLuong, DateTime ngayTinhLuong)
        {
            try
            {
                Luong luong = db.Luongs.FirstOrDefault(a => a.MaLuong == maLuong);
                if (luong != null)
                {
                    luong.MaLuong = maLuong;
                    luong.MaChamCong = maCham;
                    luong.MaNhanVien = maNV;
                    luong.Thang = thang;
                    luong.Nam = nam;
                    luong.SoNgayLamViec = soNgayLamViec;
                    luong.SoGioTangCa = soGioTangCa;
                    luong.LuongCoBan = luongCoBan;
                    luong.PhuCap = phuCap;
                    luong.Thuong = thuong;
                    luong.KhauTru = khauTru;
                    luong.TongLuong = tongLuong;
                    luong.NgayTinhLuong = ngayTinhLuong;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Luong> HienThiDanhSachLuong()
        {
            return db.Luongs.ToList();
        }
        public void LoadComBoBoxMaCham(ComboBox cb)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var Cham = db.ChamCongs
                                    .Select(nv => new { nv.MaChamCong, nv.TenBangChamCong })
                                    .ToList();

                cb.DataSource = Cham;
                cb.DisplayMember = "TenBangChamCong";
                cb.ValueMember = "MaChamCong";
            }
        }
        public void LoadComBoBoxMaNV(ComboBox cb)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var nhanVien = db.NhanViens
                                    .Select(nv => new { nv.MaNhanVien, nv.TenNhanVien })
                                    .ToList();

                cb.DataSource = nhanVien;
                cb.DisplayMember = "TenNhanVien";
                cb.ValueMember = "MaNhanVien";
            }
        }

        public void LoadDGVForm(TextBox maLuong, ComboBox maCham, ComboBox maNV, TextBox thang, TextBox nam, TextBox soNgayLamViec, TextBox soGioTangCa, TextBox luongCoBan, TextBox phuCap, TextBox thuong, TextBox khauTru, TextBox tongLuong, DateTimePicker ngayTinhLuong, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];

                    maLuong.Text = row.Cells[0].Value.ToString().Trim();
                    string selectedMaCham = row.Cells[1].Value.ToString().Trim();
                    string selectedMaNV = row.Cells[2].Value.ToString().Trim();
                    thang.Text = row.Cells[3].Value.ToString().Trim();
                    nam.Text = row.Cells[4].Value.ToString().Trim();
                    soNgayLamViec.Text = row.Cells[5].Value.ToString().Trim();
                    soGioTangCa.Text = row.Cells[6].Value.ToString().Trim();
                    luongCoBan.Text = row.Cells[7].Value.ToString().Trim();
                    phuCap.Text = row.Cells[8].Value.ToString().Trim();
                    thuong.Text = row.Cells[9].Value.ToString().Trim();
                    khauTru.Text = row.Cells[10].Value.ToString().Trim();
                    tongLuong.Text = row.Cells[11].Value.ToString().Trim();
                    ngayTinhLuong.Text = row.Cells[12].Value.ToString().Trim();

                    foreach (var item in maCham.Items)
                    {
                        var chamCong = item as dynamic;
                        if (chamCong != null && chamCong.MaChamCong == selectedMaCham)
                        {
                            maCham.SelectedItem = item;
                            break;
                        }
                    }
                    foreach (var item in maNV.Items)
                    {
                        var nhanVien = item as dynamic;
                        if (nhanVien != null && nhanVien.MaNhanVien == selectedMaNV)
                        {
                            maNV.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
        public bool CheckMaExists(string maLuong)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                return context.Luongs.Any(l => l.MaLuong == maLuong);
            }
        }
    }
}
