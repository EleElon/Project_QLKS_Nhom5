using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_HoaDon
    {
        DAO_HoaDon chiTietHoaDonDAO = new DAO_HoaDon();

        public List<ChiTietHoaDon> HienThi()
        {
            return chiTietHoaDonDAO.Xem();
        }
        public void LoadDSDV(ComboBox cb)
        {
            DAO_DanhSachDichVu.Instance.LoadComBoBoxDatPhong(cb);
        }
        public bool ThemChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            return chiTietHoaDonDAO.ThemChiTietHoaDon(chiTietHoaDon);
        }

        public bool XoaChiTietHoaDon(string maChiTietHoaDon)
        {
            return chiTietHoaDonDAO.XoaChiTietHoaDon(maChiTietHoaDon);
        }

        public bool SuaChiTietHoaDon(ChiTietHoaDon chiTietHoaDonCapNhat)
        {
            return chiTietHoaDonDAO.SuaChiTietHoaDon(chiTietHoaDonCapNhat);
        }

        public List<ChiTietHoaDon> TimKiemHoaDonTheoMa(string maHoaDon)
        {
            return chiTietHoaDonDAO.TimKiemHoaDonTheoMa(maHoaDon);
        }
    }
}
