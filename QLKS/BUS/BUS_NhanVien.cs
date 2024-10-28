using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_NhanVien
    {
        DAO_NhanVien dao_nv = new DAO_NhanVien();

        public bool ThemNhanVien(string maNV, string maPhong, string tenNV, string chucVu, float luong)
        {
            return dao_nv.ThemNhanVien(maNV, maPhong, tenNV, chucVu, luong);
        }

        public bool XoaNhanVien(string maNV)
        {
            return dao_nv.XoaNhanVien(maNV);
        }

        public bool SuaNhanVien(string maNV, string maPhong, string tenNV, string chucVu, float luong)
        {
            return dao_nv.SuaNhanVien(maNV, maPhong, tenNV, chucVu, luong);
        }

        public List<NhanVien> View()
        {
            return dao_nv.HienThiDanhSachNhanVien();
        }
    }
}
