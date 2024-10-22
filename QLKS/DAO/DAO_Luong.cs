using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_Luong
    {
        private DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

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
    }
}
