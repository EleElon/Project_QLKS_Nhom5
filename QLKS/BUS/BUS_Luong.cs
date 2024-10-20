using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_Luong
    {
        DAO_Luong dao_luong = new DAO_Luong();

        public bool ThemLuong(string maLuong, string maNV, int thang, float soTien)
        {
            return dao_luong.ThemLuong(maLuong, maNV, thang, soTien);
        }

        public bool XoaLuong(string maluong)
        {
            return dao_luong.XoaLuong(maluong);
        }

        public bool SuaLuong(string maLuong, string maNV, int thang, float soTien)
        {
            return dao_luong.SuaLuong(maLuong, maNV, thang, soTien);
        }

        public List<Luong> View()
        {
            return dao_luong.HienThiDanhSachLuong();
        }
    }
}
