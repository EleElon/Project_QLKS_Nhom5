using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_TimKiemNhanVien
    {
        private static BUS_TimKiemNhanVien instance;
        public static BUS_TimKiemNhanVien Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_TimKiemNhanVien();
                }
                return instance;
            }
        }
        private BUS_TimKiemNhanVien() { }

        public void TimKiemMaNV(TextBox maNV, DataGridView data)
        {
            data.DataSource = DAO_TimKiemNhanVien.Instance.TimKiemTheoMaNV(maNV.Text);
        }
        public void TimKiemTenNV(TextBox tenNV, DataGridView data)
        {
            data.DataSource = DAO_TimKiemNhanVien.Instance.TimKiemTheoTenNV(tenNV.Text);
        }
        public void View(DataGridView data)
        {
            var dv = DAO_NhanVien.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaNhanVien,
                    t.MaPhong,
                    t.TenNhanVien,
                    t.gioiTinh,
                    t.ngaySinh,
                    t.SDT,
                    t.ChucVu,
                    t.diaChi
                };
            }).ToList();
            data.DataSource = dv;
        }
    }
}
