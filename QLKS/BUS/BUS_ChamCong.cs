using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_ChamCong
    {
        public static BUS_ChamCong instance;
        public static BUS_ChamCong Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_ChamCong();
                }
                return instance;
            }
        }
        public BUS_ChamCong() { }

        DAO_ChamCong dao_cc = new DAO_ChamCong();

        public void ThemChamCong(TextBox maCham, TextBox tenBangChamCong, ComboBox maNV, ComboBox thang, NumericUpDown nam, NumericUpDown soNgayLam, TextBox soGioTangCa, DateTimePicker ngayCham, TextBox ghiChu)
        {
            ChamCong c = new ChamCong
            {
                MaChamCong = maCham.Text,
                TenBangChamCong = tenBangChamCong.Text,
                MaNhanVien = maNV.SelectedValue.ToString().Trim(),
                Thang = thang.Text,
                Nam = int.Parse(nam.Text),
                SoNgayLamViec = int.Parse(soNgayLam.Text),
                SoGioTangCa = float.Parse(soGioTangCa.Text),
                NgayChamCong = DateTime.Parse(ngayCham.Text),
                GhiChu = ghiChu.Text
            };
            DAO_ChamCong.Instance.Them(c);
        }

        public bool XoaChamCong(string maCham)
        {
            return dao_cc.XoaChamCong(maCham);
        }

        public bool SuaChamCong(string maCham, string tenBangChamCong, string maNV, string thang, int nam, int soNgayLam, float soGioTangCa, DateTime ngayChamCong, string ghiChu)
        {
            return dao_cc.SuaChamCong(maCham, tenBangChamCong, maNV, thang, nam, soNgayLam, soGioTangCa, ngayChamCong, ghiChu);
        }
        public bool ChamCong(string maCham, int soNgayLam, float soGioTangCa)
        {
            return dao_cc.ChamCong(maCham, soNgayLam, soGioTangCa);
        }

        public List<ChamCong> View()
        {
            return dao_cc.HienThiDanhSachChamCong();
        }
        public void Xem(DataGridView data)
        {
            var dv = DAO_ChamCong.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaChamCong,
                    t.TenBangChamCong,
                    t.MaNhanVien,
                    t.Thang,
                    t.Nam,
                    t.SoNgayLamViec,
                    t.SoGioTangCa,
                    t.NgayChamCong,
                    t.GhiChu
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void LoadMaNV(ComboBox cb)
        {
            DAO_ChamCong.Instance.LoadComBoBoxMaNhanVien(cb);
        }
        public void LoadDGVLenForm(TextBox maCham, TextBox tenBangChamCong, ComboBox maNV, ComboBox thang, NumericUpDown nam, NumericUpDown soNgayLam, TextBox soGioTangCa, DateTimePicker ngayCham, TextBox ghiChu, DataGridView data)
        {
            DAO_ChamCong.Instance.LoadDGVForm(maCham, tenBangChamCong, maNV, thang, nam, soNgayLam, soGioTangCa, ngayCham, ghiChu, data);
        }
        public bool CheckMaLuongExists(string maLuong)
        {
            return DAO_ChamCong.Instance.CheckMaExists(maLuong);
        }
    }
}
