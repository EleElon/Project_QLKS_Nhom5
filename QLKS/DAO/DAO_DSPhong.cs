using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_DSPhong
    {
        public DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());


        public List<Phong> Xem()
        {
            List<Phong> data = new List<Phong>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var phong = (from p in db.Phongs
                             select new
                             {
                                 p.MaPhong,
                                 p.MaLoaiPhong,
                                 p.SoPhong,
                                 p.TinhTrang
                             }).ToList();

                foreach (var item in phong)
                {
                    Phong pItem = new Phong();
                    pItem.MaPhong = item.MaPhong;
                    pItem.MaLoaiPhong = item.MaLoaiPhong;
                    pItem.SoPhong = item.SoPhong;
                    pItem.TinhTrang = item.TinhTrang;

                    data.Add(pItem);
                }
            }
            return data;
        }


        public bool themPhong(string maPhong, string maLoaiPhong, int soPhong, string tinhTrang)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                try
                {
                    if (db.Phongs.Any(p => p.MaPhong == maPhong))
                    {
                        return false;
                    }
                    Phong phong = new Phong();
                    phong.MaPhong = maPhong;
                    phong.MaLoaiPhong = maLoaiPhong;
                    phong.SoPhong = soPhong;
                    phong.TinhTrang = tinhTrang;
                    db.Phongs.InsertOnSubmit(phong);
                    db.SubmitChanges();
                    return true;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
        public bool xoaPhong(string maPhong)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                try
                {
                    Phong phong = db.Phongs.SingleOrDefault(p => p.MaPhong == maPhong);
                    if (phong == null)
                    {
                        return false;
                    }

                    // Xóa phòng khỏi cơ sở dữ liệu
                    db.Phongs.DeleteOnSubmit(phong);
                    db.SubmitChanges();

                    // Trả về true nếu xóa thành công
                    return true;
                }
                catch (Exception ex)
                {
                    // Xử lý ngoại lệ nếu có
                    throw ex;
                }
            }
        }
        public bool suaPhong(string maPhong, string maLoaiPhong, int soPhong, string tinhTrang)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                try
                {
                    Phong phong = db.Phongs.SingleOrDefault(p => p.MaPhong == maPhong);
                    if (phong != null)
                    {
                        phong.MaLoaiPhong = maLoaiPhong;
                        phong.SoPhong = soPhong;
                        phong.TinhTrang = tinhTrang;
                        db.SubmitChanges();
                        return true;

                    }
                    return false;
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Lỗi khi cập nhật: " + ex.Message);
                }
            }
        }



    }
}
