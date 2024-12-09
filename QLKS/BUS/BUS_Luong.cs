using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_Luong
    {
        public static BUS_Luong instance;
        public static BUS_Luong Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_Luong();
                }
                return instance;
            }
        }
        public BUS_Luong() { }

        DAO_Luong dao_luong = new DAO_Luong();

        public void ThemLuong(TextBox maLuong, ComboBox maCham, ComboBox maNV, TextBox thang, TextBox nam, TextBox soNgayLamViec, TextBox soGioTangCa, TextBox luongCoBan, TextBox phuCap, TextBox thuong, TextBox khauTru, TextBox tongLuong, DateTimePicker ngayTinhLuong)
        {
            Luong l = new Luong
            {
                MaLuong = maLuong.Text,
                MaChamCong = maCham.SelectedValue.ToString().Trim(),
                MaNhanVien = maNV.SelectedValue.ToString().Trim(),
                Thang = int.Parse(thang.Text),
                Nam = int.Parse(nam.Text),
                SoNgayLamViec = int.Parse(soNgayLamViec.Text),
                SoGioTangCa = int.Parse(soGioTangCa.Text),
                LuongCoBan = int.Parse(luongCoBan.Text),
                PhuCap = int.Parse(phuCap.Text),
                Thuong = int.Parse(thuong.Text),
                KhauTru = int.Parse(khauTru.Text),
                TongLuong = int.Parse(tongLuong.Text),
                NgayTinhLuong = DateTime.Parse(ngayTinhLuong.Text)
            };
            DAO_Luong.Instance.Them(l);
        }

        public bool XoaLuong(string maluong)
        {
            return dao_luong.XoaLuong(maluong);
        }

        public bool SuaLuong(string maLuong, string maCham, string maNV, int thang, int nam, int soNgayLamViec, float soGioTangCa, float luongCoBan, float phuCap, float thuong, float khauTru, float tongLuong, DateTime ngayTinhLuong)
        {
            return dao_luong.SuaLuong(maLuong, maCham, maNV, thang, nam, soNgayLamViec, soGioTangCa, luongCoBan, phuCap, thuong, khauTru, tongLuong, ngayTinhLuong);
        }

        public List<Luong> View()
        {
            return dao_luong.HienThiDanhSachLuong();
        }
        public void Xem(DataGridView data)
        {
            var dv = DAO_Luong.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaLuong,
                    t.MaChamCong,
                    t.MaNhanVien,
                    t.Thang,
                    t.Nam,
                    t.SoNgayLamViec,
                    t.SoGioTangCa,
                    t.LuongCoBan,
                    t.PhuCap,
                    t.Thuong,
                    t.KhauTru,
                    t.TongLuong,
                    t.NgayTinhLuong
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void LoadMaCham(ComboBox cb)
        {
            DAO_Luong.Instance.LoadComBoBoxMaCham(cb);
        }
        public void LoadMaNhanVien(ComboBox cb)
        {
            DAO_Luong.Instance.LoadComBoBoxMaNV(cb);
        }
        public void LoadDGVLenForm(TextBox maLuong, ComboBox maCham, ComboBox maNV, TextBox thang, TextBox nam, TextBox soNgayLamViec, TextBox soGioTangCa, TextBox luongCoBan, TextBox phuCap, TextBox thuong, TextBox khauTru, TextBox tongLuong, DateTimePicker ngayTinhLuong, DataGridView data)
        {
            DAO_Luong.Instance.LoadDGVForm(maLuong, maCham, maNV, thang, nam, soNgayLamViec, soGioTangCa, luongCoBan, phuCap, thuong, khauTru, tongLuong, ngayTinhLuong, data);
        }
        public bool CheckMaLuongExists(string maLuong)
        {
            return DAO_Luong.Instance.CheckMaExists(maLuong);
        }
    }
}
