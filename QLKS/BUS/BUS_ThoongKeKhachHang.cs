using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_ThoongKeKhachHang
    {
        private static BUS_ThoongKeKhachHang instance;
        public static BUS_ThoongKeKhachHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_ThoongKeKhachHang();
                }
                return instance;
            }
        }
        private BUS_ThoongKeKhachHang() { }

        public void HienThi(DataGridView data, string ngay, string den)
        {
            data.DataSource = DAO_ThongKeKhachHang.Instance.Xem(ngay, den);
        }
    }
}
