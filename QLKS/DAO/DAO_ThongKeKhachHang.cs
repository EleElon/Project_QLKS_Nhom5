using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_ThongKeKhachHang
    {
        private static DAO_ThongKeKhachHang instance;
        public static DAO_ThongKeKhachHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_ThongKeKhachHang();
                }
                return instance;
            }
        }
        private DAO_ThongKeKhachHang() { }

        public class ThongKeKhachHangDTO
        {
            public string tenKH { get; set; }
            public DateTime ngayNhan { get; set; }
            public DateTime ngayTra { get; set; }
            public float gia { get; set; }
            public int soLuong { get; set; }
            public float tong { get; set; }
            public string pttt { get; set; }
            public string tenloaiphong { get; set; }
        }
        public List<ThongKeKhachHangDTO> Xem(string ngay, string den)
        {
            List<ThongKeKhachHangDTO> data = new List<ThongKeKhachHangDTO>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var datphong = (from dv in db.KhachHangs
                                join ctdp in db.ChiTietDatPhongs on dv.MaKhachHang equals ctdp.MaKhachHang
                                join lp in db.LoaiPhongs on ctdp.MaLoaiPhong equals lp.MaLoaiPhong
                                where ctdp.NgayNhanPhong >= DateTime.Parse(ngay) && ctdp.NgayTraPhong <= DateTime.Parse(den)
                                select new
                                {
                                    dv.TenKhachHang,
                                    ctdp.NgayNhanPhong,
                                    ctdp.NgayTraPhong,
                                    ctdp.GiaMoiDem,
                                    ctdp.SoLuongPhong,
                                    ctdp.TongGia,
                                    ctdp.PhuongThucThanhToan,
                                    lp.TenLoaiPhong
                                }).ToList();

                foreach (var item in datphong)
                {
                    ThongKeKhachHangDTO thongKe = new ThongKeKhachHangDTO();
                    thongKe.tenKH = item.TenKhachHang;
                    thongKe.ngayNhan = (DateTime)item.NgayNhanPhong;
                    thongKe.ngayTra = (DateTime)item.NgayTraPhong;
                    thongKe.gia = (float)item.GiaMoiDem;
                    thongKe.soLuong = (int)item.SoLuongPhong;
                    thongKe.tong = (float)item.TongGia;
                    thongKe.pttt = item.PhuongThucThanhToan;
                    thongKe.tenloaiphong = item.TenLoaiPhong;

                    data.Add(thongKe);
                }
            }
            return data;
        }
    }
}
