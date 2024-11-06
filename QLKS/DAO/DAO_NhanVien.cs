using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DAO
{
    public class DAO_NhanVien
    {
        private DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

        public bool ThemNhanVien(string maNV, string maPhong, string tenNV, string chucVu, float luong)
        {
            try
            {
                if (db.NhanViens.Any(nv => nv.MaNhanVien == maNV))
                {
                    return false;
                }

                NhanVien nhanVien = new NhanVien
                {
                    MaNhanVien = maNV,
                    MaPhong = maPhong,
                    TenNhanVien = tenNV,
                    ChucVu = chucVu,
                    Luong = luong
                };

                db.NhanViens.InsertOnSubmit(nhanVien);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool XoaNhanVien(string maNV)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNV);
                if (nhanVien != null)
                {
                    db.NhanViens.DeleteOnSubmit(nhanVien);
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

        public bool SuaNhanVien(string maNV, string maPhong, string tenNV, string chucVu, float luong)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNV);
                if (nhanVien != null)
                {
                    nhanVien.MaNhanVien = maNV;
                    nhanVien.MaPhong = maPhong;
                    nhanVien.TenNhanVien = tenNV;
                    nhanVien.Luong = luong;

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

        public List<NhanVien> HienThiDanhSachNhanVien()
        {
            return db.NhanViens.ToList();
        }
    }
}
