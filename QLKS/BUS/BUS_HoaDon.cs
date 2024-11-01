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
        DAO_HoaDon dao_HoaDon = new DAO_HoaDon();
        public List<ChiTietHoaDon> HienThi()
        {
            return dao_HoaDon.Xem();
        }
        public void LoadDSDV(ComboBox cb)
        {
            DAO_DanhSachDichVu.Instance.LoadComBoBoxDatPhong(cb);
        }
    }
}
