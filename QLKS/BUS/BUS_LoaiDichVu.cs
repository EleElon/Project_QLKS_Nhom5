using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_LoaiDichVu
    {
        public static BUS_LoaiDichVu instance;
        public static BUS_LoaiDichVu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_LoaiDichVu();
                }
                return instance;
            }
        }
        public BUS_LoaiDichVu() { }

        private DAO_LoaiDichVu dao_ldv = new DAO_LoaiDichVu();

        //public bool ThemLDV(string maLDV, string tenLDV, string maLoaiPhong)
        //{
        //    return dao_ldv.ThemLDV(maLDV, tenLDV, maLoaiPhong);
        //}
        //public void ThemLDV(TextBox maLDV, TextBox tenLDV, ComboBox maLoaiPhong)
        //{
        //    DAO_LoaiDichVu.Instance.ThemLDV(maLDV, tenLDV, maLoaiPhong);
        //}
        public void ThemLDV(TextBox maLDV, TextBox tenLDV, ComboBox maLoaiPhong)
        {
            LoaiDichVu ldv = new LoaiDichVu
            {
                MaLoaiDichVu = maLDV.Text,
                TenLoaiDichVu = tenLDV.Text,
                MaLoaiPhong = maLoaiPhong.SelectedValue.ToString()
            };
            DAO_LoaiDichVu.Instance.ThemLDV(ldv);
        }
        //public bool XoaLDV(string maLDV)
        //{
        //    return dao_ldv.XoaLoaiDichVu(maLDV);
        //}
        public void XoaLDV(TextBox maLDV)
        {
            DAO_LoaiDichVu.Instance.XoaLoaiDichVu(maLDV.Text);
        }
        //public bool SuaLDV(string maLDV, string tenLDV, string maLoaiPhong)
        //{
        //    return dao_ldv.SuaLoaiDichVu(maLDV, tenLDV, maLoaiPhong);
        //}
        public void Sua(TextBox maLDV, TextBox tenLDV, ComboBox maLoaiPhong)
        {
            LoaiDichVu dsldv = new LoaiDichVu
            {
                MaLoaiDichVu = maLDV.Text,
                TenLoaiDichVu = tenLDV.Text,
                MaLoaiPhong = maLoaiPhong.SelectedValue.ToString().Trim()
            };
            DAO_LoaiDichVu.Instance.SuaLoaiDichVu(dsldv);
        }
        //public void Sua(TextBox maLDV, TextBox tenLDV, ComboBox maLoaiPhong)
        //{
        //    LoaiDichVu ldv = new LoaiDichVu
        //    {
        //        MaLoaiDichVu = maLDV.Text,
        //        TenLoaiDichVu = tenLDV.Text,
        //        MaLoaiPhong = maLoaiPhong.SelectedValue.ToString().Trim()
        //    };
        //    bool result = DAO_LoaiDichVu.Instance.SuaLoaiDichVu(ldv); // Capture the result
        //    if (result)
        //    {
        //        MessageBox.Show("Sửa khách hàng thành công!");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Khách hàng không tồn tại hoặc sửa thất bại!");
        //    }
        //}
        public List<LoaiDichVu> View()
        {
            return dao_ldv.HienThiDanhSachLoaiDichVu();
        }
        public void Xem(DataGridView data)
        {
            var dv = DAO_LoaiDichVu.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaLoaiDichVu,
                    t.TenLoaiDichVu,
                    t.MaLoaiPhong
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void LoadMaLoaiPhong(ComboBox cb)
        {
            DAO_LoaiDichVu.Instance.LoadComBoBoxLoaiPhong(cb);
        }
        public void LoadDGVLenForm(TextBox maLDV, TextBox tenLDV, ComboBox maLP, DataGridView data)
        {
            DAO_LoaiDichVu.Instance.LoadDGVForm(maLDV, tenLDV, maLP, data);
        }
        public bool CheckMaLDVExists(string maLDV)
        {
            return DAO_LoaiDichVu.Instance.CheckMaExists(maLDV);
        }
    }
}
