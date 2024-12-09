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
        private DAO_TimKiemNhanVien() { }
        public List<NhanVien> TimKiemTheoMaNV(string maNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

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
                        gioiTinh = s.gioiTinh,
                        ngaySinh = s.ngaySinh,
                        SDT = s.SDT,
                        ChucVu = s.ChucVu,
                        diaChi = s.diaChi
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
        public List<NhanVien> TimKiemTheoTenNV(string TenNV)
        {
            List<NhanVien> list = new List<NhanVien>();
            DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

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
                        gioiTinh = s.gioiTinh,
                        ngaySinh = s.ngaySinh,
                        SDT = s.SDT,
                        ChucVu = s.ChucVu,
                        diaChi = s.diaChi
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
    }
}
