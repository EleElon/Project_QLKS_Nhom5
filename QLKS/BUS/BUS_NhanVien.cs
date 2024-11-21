using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_NhanVien
    {
        public static BUS_NhanVien instance;
        public static BUS_NhanVien Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_NhanVien();
                }
                return instance;
            }
        }
        public BUS_NhanVien() { }

        DAO_NhanVien dao_nv = new DAO_NhanVien();

        public void ThemNhanVien(TextBox maNV, ComboBox maPhong, TextBox tenNV, RadioButton nam, RadioButton nu, DateTimePicker ngaySinh, TextBox SDT, TextBox chucVu, TextBox diaChi)
        {
            string gioiTinh = nam.Checked ? "Nam" : (nu.Checked ? "Nu" : null);

            NhanVien nv = new NhanVien
            {
                MaNhanVien = maNV.Text,
                MaPhong = maPhong.SelectedValue.ToString().Trim(),
                TenNhanVien = tenNV.Text,
                gioiTinh = gioiTinh,
                ngaySinh = ngaySinh.Value,
                SDT = SDT.Text,
                ChucVu = chucVu.Text,
                diaChi = diaChi.Text
            };
            DAO_NhanVien.Instance.Them(nv);
        }

        public bool XoaNhanVien(string maNV)
        {
            return dao_nv.XoaNhanVien(maNV);
        }

        public bool SuaNhanVien(string maNV, string maPhong, string tenNV, string gioiTinh, DateTime ngaySinh, string SDT, string chucVu, string diaChi)
        {
            return dao_nv.SuaNhanVien(maNV, maPhong, tenNV, gioiTinh, ngaySinh, SDT, chucVu, diaChi);
        }

        public List<NhanVien> Vieww()
        {
            return dao_nv.HienThiDanhSachNhanVien();
        }
        public void View(DataGridView data)
        {
            var dv = DAO_NhanVien.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaNhanVien,
                    t.MaPhong,
                    t.TenNhanVien,
                    t.gioiTinh,
                    t.ngaySinh,
                    t.SDT,
                    t.ChucVu,
                    t.diaChi
                };
            }).ToList();
            data.DataSource = dv;
        }

        public void LoadMaPhong(ComboBox cb)
        {
            DAO_NhanVien.Instance.LoadComBoBoxMaPhong(cb);
        }
        public void LoadDGVLenForm(TextBox maNV, ComboBox maPhong, TextBox tenNV, RadioButton nam, RadioButton nu, DateTimePicker ngaySinh, TextBox SDT, TextBox chucVu, TextBox diaChi, DataGridView data)
        {
            DAO_NhanVien.Instance.LoadDGVForm(maNV, maPhong, tenNV, nam, nu, ngaySinh, SDT, chucVu, diaChi, data);
        }
        public bool CheckMaNVExists(string maNV)
        {
            return DAO_NhanVien.Instance.CheckMaExists(maNV);
        }
    }
}
