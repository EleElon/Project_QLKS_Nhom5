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

        //public bool ThemLuong(string maLuong, string maNV, int thang, float soTien)
        //{
        //    return dao_luong.ThemLuong(maLuong, maNV, thang, soTien);
        //}
        public void ThemLuong(TextBox maLuong, ComboBox maNV, TextBox thang, TextBox soTien)
        {
            Luong l = new Luong
            {
                MaLuong = maLuong.Text,
                MaNhanVien = maNV.SelectedValue.ToString().Trim(),
                Thang = int.Parse(thang.Text),
                SoTien = float.Parse(soTien.Text)
            };
            DAO_Luong.Instance.Them(l);
        }

        public bool XoaLuong(string maluong)
        {
            return dao_luong.XoaLuong(maluong);
        }

        public bool SuaLuong(string maLuong, string maNV, int thang, float soTien)
        {
            return dao_luong.SuaLuong(maLuong, maNV, thang, soTien);
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
                    t.MaNhanVien,
                    t.Thang,
                    t.SoTien
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void LoadMaNV(ComboBox cb)
        {
            DAO_Luong.Instance.LoadComBoBoxMaNhanVien(cb);
        }
        public void LoadDGVLenForm(TextBox maLuong, ComboBox maNV, TextBox thang, TextBox soTien, DataGridView data)
        {
            DAO_Luong.Instance.LoadDGVForm(maLuong, maNV, thang, soTien, data);
        }
        public bool CheckMaLuongExists(string maLuong)
        {
            return DAO_Luong.Instance.CheckMaExists(maLuong);
        }
    }
}
