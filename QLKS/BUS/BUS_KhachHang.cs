using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_KhachHang
    {
        private static BUS_KhachHang instance;
        public static BUS_KhachHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_KhachHang();
                }
                return instance;
            }
        }
        private BUS_KhachHang() { }

        public void Xem(DataGridView data)
        {
            var dv = DAO_KhachHang.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaKhachHang,
                    t.MaDichVu,
                    t.TenKhachHang,
                    t.CCCD,
                    t.Email,
                    t.SDT,
                    t.DiaChi
                 
                };
            }).ToList();
            data.DataSource = dv;
        }
      //load dịch vụ
        public void LoadDichVu(ComboBox cb)
        {
            DAO_KhachHang.Instance.LoadComBoBoxDichVu(cb);
        }
        //hiển thị tất cả các khách hàng lên form
        public void LoadDGVLenForm(TextBox ma, ComboBox maDV, TextBox tenKH,TextBox cccd,TextBox email, TextBox sdt,TextBox diaChi, DataGridView data)
        {
            DAO_KhachHang.Instance.LoadDGVForm(ma, maDV, tenKH,cccd,email,sdt,diaChi, data);
        }
        //Thêm khách ahngf
        public void Them(TextBox ma, ComboBox maDV, TextBox tenKH, TextBox cccd, TextBox email, TextBox sdt, TextBox diaChi)
        {
            KhachHang kh = new KhachHang
            {
                MaKhachHang = ma.Text,
                MaDichVu = maDV.SelectedValue.ToString(),
                TenKhachHang = tenKH.Text,
                CCCD = cccd.Text,
                Email = email.Text,
                SDT = sdt.Text,
                DiaChi = diaChi.Text
            };
            DAO_KhachHang.Instance.Them(kh);
        }
        //xóa khách hàng
        public void Xoa(TextBox ma)
        {
            DAO_KhachHang.Instance.Xoa(ma.Text);
        }
        //Sửa khách hàng
        public void Sua( ComboBox maDichVu, TextBox tenKH, TextBox cccd, TextBox email, TextBox sdt, TextBox diaChi)
        {
            KhachHang kh = new KhachHang
            {
               
                MaDichVu = maDichVu.Text,
                TenKhachHang = tenKH.Text,
                CCCD = cccd.Text,
                Email = email.Text,
                SDT = sdt.Text,
                DiaChi = diaChi.Text,
            };
            DAO_KhachHang.Instance.Sua(kh);
        }
        // Phương thức gọi DAL để kiểm tra trùng mã khách hàng
        public bool CheckMaExists(string ma)
        {
            return DAO_KhachHang.Instance.CheckMaExists(ma);
        }

    }
}
