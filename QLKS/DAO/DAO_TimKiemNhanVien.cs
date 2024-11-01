using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_TimKiemNhanVien
    {
        private static DAO_TimKiemNhanVien instance;
        public static DAO_TimKiemNhanVien Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_TimKiemNhanVien();
                }
                return instance;
            }
        }
        //Tìm kiếm theo mã khách hàng
        private DAO_TimKiemNhanVien() { }
        public List<NhanVien> TimKiemTheoMaNV(string maNV)
        {

            List<NhanVien> list = new List<NhanVien>();
            DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());
            // Tìm tất cả khách hàng có mã chứa từ khóa
            var nhanViens = db.NhanViens.Where(nv => nv.MaNhanVien.Contains(maNV)).ToList();

            if (nhanViens.Any())
            {
                foreach (var s in nhanViens)
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNhanVien = s.MaNhanVien,
                        MaPhong = s.MaPhong,
                        TenNhanVien = s.TenNhanVien,
                        ChucVu = s.ChucVu,
                        Luong = s.Luong
                    };
                    list.Add(nv);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên có mã khớp.");
            }
            return list;
        }
        //Tìm kiếm theo tên khách hàng
        public List<NhanVien> TimKiemTheoTenNV(string TenNV)
        {

            List<NhanVien> list = new List<NhanVien>();
            DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

            // Tìm tất cả khách hàng có tên chứa từ khóa
            var nhanViens = db.NhanViens.Where(nv => nv.TenNhanVien.Contains(TenNV.ToLower())).ToList();

            if (nhanViens.Any())
            {
                foreach (var s in nhanViens)
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNhanVien = s.MaNhanVien,
                        MaPhong = s.MaPhong,
                        TenNhanVien = s.TenNhanVien,
                        ChucVu = s.ChucVu,
                        Luong = s.Luong
                    };
                    list.Add(nv);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy nhân viên có tên khớp.");
            }

            return list;
        }
        public List<NhanVien> TimKiemTheoLuong(bool tangDan)
        {
            List<NhanVien> list = new List<NhanVien>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                // Sắp xếp danh sách nhân viên theo lương
                var nhanViens = tangDan
                    ? db.NhanViens.OrderBy(nv => nv.Luong).ToList()
                    : db.NhanViens.OrderByDescending(nv => nv.Luong).ToList();

                foreach (var s in nhanViens)
                {
                    NhanVien nv = new NhanVien
                    {
                        MaNhanVien = s.MaNhanVien,
                        MaPhong = s.MaPhong,
                        TenNhanVien = s.TenNhanVien,
                        ChucVu = s.ChucVu,
                        Luong = s.Luong
                    };
                    list.Add(nv);
                }
            }
            return list;
        }
    }
}
