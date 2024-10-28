using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_TimKiemKhachHang
    {
        private static BUS_TimKiemKhachHang instance;
        public static BUS_TimKiemKhachHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_TimKiemKhachHang();
                }
                return instance;
            }
        }
        private BUS_TimKiemKhachHang() { }

        public void TimKiemMaKH(TextBox maKH,DataGridView data)
        {
           data.DataSource = DAO_TimKiemKhachHang.Instance.TimKiemTheoMaKH(maKH.Text);
        }
        public void TimKiemTenKH(TextBox tenKH, DataGridView data)
        {
            data.DataSource = DAO_TimKiemKhachHang.Instance.TimKiemTheoTenKH(tenKH.Text);
        }

    }
}
