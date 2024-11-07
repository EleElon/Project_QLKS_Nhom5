using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_HoaDon
    {
        public DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());
        public List<ChiTietHoaDon> Xem()
        {
            List<ChiTietHoaDon> data = new List<ChiTietHoaDon>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                db.CommandTimeout = 120;
                var chiTietHoaDon = (from h in db.ChiTietHoaDons
                                     select new
                                     {
                                         h.MaHoaDon,
                                         h.MaDatPhong,
                                         h.MaSuDungDichVu,
                                         h.PhuThu,
                                         h.TienPhong,
                                         h.TienDichVu,
                                         h.GiamGiaKH,
                                         h.HinhThucThanhToan,
                                         h.SoNgay,
                                         h.ThanhTien
                                     }).ToList();

                foreach (var item in chiTietHoaDon)
                {
                    ChiTietHoaDon hItem = new ChiTietHoaDon();
                    hItem.MaHoaDon = item.MaHoaDon;
                    hItem.MaDatPhong = item.MaDatPhong;
                    hItem.MaSuDungDichVu = item.MaSuDungDichVu;
                    hItem.PhuThu = item.PhuThu;
                    hItem.TienPhong = item.TienPhong;
                    hItem.TienDichVu = item.TienDichVu;
                    hItem.GiamGiaKH = item.GiamGiaKH;
                    hItem.HinhThucThanhToan = item.HinhThucThanhToan;
                    hItem.SoNgay = item.SoNgay;
                    hItem.ThanhTien = item.ThanhTien;

                    data.Add(hItem);
                }
            }
            return data;
        }
        public bool ThemChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    db.ChiTietHoaDons.InsertOnSubmit(chiTietHoaDon);
                    db.SubmitChanges();
                }
                return true;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }
        public bool XoaChiTietHoaDon(string maChiTietHoaDon)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    var chiTietHoaDon = db.ChiTietHoaDons.SingleOrDefault(h => h.MaHoaDon == maChiTietHoaDon);

                    if (chiTietHoaDon != null)
                    {
                        db.ChiTietHoaDons.DeleteOnSubmit(chiTietHoaDon);
                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy chi tiết hóa đơn với mã: " + maChiTietHoaDon);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa chi tiết hóa đơn: " + ex.Message);
                return false;
            }
        }
        public bool SuaChiTietHoaDon(ChiTietHoaDon chiTietHoaDonCapNhat)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    var chiTietHoaDon = db.ChiTietHoaDons.SingleOrDefault(h => h.MaHoaDon == chiTietHoaDonCapNhat.MaHoaDon);

                    if (chiTietHoaDon != null)
                    {
                        chiTietHoaDon.MaDatPhong = chiTietHoaDonCapNhat.MaDatPhong;
                        chiTietHoaDon.MaSuDungDichVu = chiTietHoaDonCapNhat.MaSuDungDichVu;
                        chiTietHoaDon.PhuThu = chiTietHoaDonCapNhat.PhuThu;
                        chiTietHoaDon.TienPhong = chiTietHoaDonCapNhat.TienPhong;
                        chiTietHoaDon.TienDichVu = chiTietHoaDonCapNhat.TienDichVu;
                        chiTietHoaDon.GiamGiaKH = chiTietHoaDonCapNhat.GiamGiaKH;
                        chiTietHoaDon.HinhThucThanhToan = chiTietHoaDonCapNhat.HinhThucThanhToan;
                        chiTietHoaDon.SoNgay = chiTietHoaDonCapNhat.SoNgay;
                        chiTietHoaDon.ThanhTien = chiTietHoaDonCapNhat.ThanhTien;

                        db.SubmitChanges();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Không tìm thấy chi tiết hóa đơn với mã: " + chiTietHoaDonCapNhat.MaHoaDon);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi sửa chi tiết hóa đơn: " + ex.Message);
                return false;
            }
        }
        public List<ChiTietHoaDon> TimKiemHoaDonTheoMa(string maHoaDon)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext())
            {
                // Tìm kiếm hóa đơn theo mã
                var danhSachHoaDon = db.ChiTietHoaDons
                                        .Where(hd => hd.MaHoaDon == maHoaDon)
                                        .ToList();

                return danhSachHoaDon;
            }
        }

    }
}
