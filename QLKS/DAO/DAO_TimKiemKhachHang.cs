using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_TimKiemKhachHang
    {
        private static DAO_TimKiemKhachHang instance;
        public static DAO_TimKiemKhachHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_TimKiemKhachHang();
                }
                return instance;
            }
        }
        //Tìm kiếm theo mã khách hàng
        private DAO_TimKiemKhachHang() { }
        public List<KhachHang> TimKiemTheoMaKH(string MaKH)
        {

            List<KhachHang> list = new List<KhachHang>();
            DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());
            // Tìm tất cả khách hàng có mã chứa từ khóa
            var khachHangs = db.KhachHangs.Where(kh => kh.MaKhachHang.Contains(MaKH)).ToList();

            if (khachHangs.Any())
            {
                foreach (var s in khachHangs)
                {
                    KhachHang khachHang = new KhachHang
                    {
                        MaKhachHang = s.MaKhachHang,
                        MaDichVu = s.MaDichVu,
                        TenKhachHang = s.TenKhachHang,
                        CCCD = s.CCCD,
                        Email = s.Email,
                        SDT = s.SDT,
                        DiaChi = s.DiaChi
                    };
                    list.Add(khachHang);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng có mã khớp.");
            }
            return list;
        }
        //Tìm kiếm theo tên khách hàng
        public List<KhachHang> TimKiemTheoTenKH(string TenKH)
        {

            List<KhachHang> list = new List<KhachHang>();
            DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());
       
            // Tìm tất cả khách hàng có tên chứa từ khóa
            var khachHangs = db.KhachHangs.Where(kh => kh.TenKhachHang.Contains(TenKH.ToLower())).ToList();

            if (khachHangs.Any())
            {
                foreach (var s in khachHangs)
                {
                    KhachHang khachHang = new KhachHang
                    {
                        MaKhachHang = s.MaKhachHang,
                        MaDichVu = s.MaDichVu,
                        TenKhachHang = s.TenKhachHang,
                        CCCD = s.CCCD,
                        Email = s.Email,
                        SDT = s.SDT,
                        DiaChi = s.DiaChi
                    };
                    list.Add(khachHang);
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khách hàng có tên khớp.");
            }

            return list;
        }
    }
}
