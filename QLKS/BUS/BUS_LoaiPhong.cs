using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_LoaiPhong
    {
        public DAO_LoaiPhong loaiPhongDAO = new DAO_LoaiPhong();
        public BUS_LoaiPhong()
        {
            loaiPhongDAO = new DAO_LoaiPhong();
        }
        public List<LoaiPhong> Xem()
        {
            return loaiPhongDAO.Xem();
        }

        public bool ThemLoaiPhong(string maLoaiPhong, string tenLoaiPhong, float gia)
        {
            return loaiPhongDAO.ThemLoaiPhong(maLoaiPhong, tenLoaiPhong, gia);
        }

        public bool SuaLoaiPhong(string maLoaiPhong, string tenLoaiPhong, float gia)
        {
            return loaiPhongDAO.SuaLoaiPhong(maLoaiPhong, tenLoaiPhong, gia);
        }

        public bool XoaLoaiPhong(string maLoaiPhong)
        {
            return loaiPhongDAO.XoaLoaiPhong(maLoaiPhong);
        }
    }
}
