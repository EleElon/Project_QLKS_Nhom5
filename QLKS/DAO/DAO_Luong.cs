using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
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
                        MaNhanVien = item.MaNhanVien,
                        Thang = item.Thang,
                        SoTien = item.SoTien
                    });
                }
            }
            return data;
        }
        public bool ThemLuong(string maLuong, string maNV, int thang, float soTien)
        {
            try
            {
                if (db.Luongs.Any(a => a.MaLuong == maLuong))
                {
                    return false;
                }

                Luong luong = new Luong
                {
                    MaLuong = maLuong,
                    MaNhanVien = maNV,
                    Thang = thang,
                    SoTien = soTien
                };

                db.Luongs.InsertOnSubmit(luong);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public bool SuaLuong(string maLuong, string maNV, int thang, float soTien)
        {
            try
            {
                Luong luong = db.Luongs.FirstOrDefault(a => a.MaLuong == maLuong);
                if (luong != null)
                {
                    luong.MaLuong = maLuong;
                    luong.MaNhanVien = maNV;
                    luong.Thang = thang;
                    luong.SoTien = soTien;

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
        public void LoadComBoBoxMaNhanVien(ComboBox cb)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var nhanViens = db.NhanViens
                                    .Select(nv => new { nv.MaNhanVien, nv.TenNhanVien })
                                    .ToList();

                cb.DataSource = nhanViens;
                cb.DisplayMember = "TenNhanVien";
                cb.ValueMember = "MaNhanVien";
            }
        }

        public void LoadDGVForm(TextBox maLuong, ComboBox maNV, TextBox thang, TextBox soTien, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];

                    maLuong.Text = row.Cells[0].Value.ToString().Trim();
                    string selectedMaNV = row.Cells[1].Value.ToString().Trim();
                    thang.Text = row.Cells[2].Value.ToString().Trim();
                    soTien.Text = row.Cells[3].Value.ToString().Trim();

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
