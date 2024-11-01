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
    }
    }
