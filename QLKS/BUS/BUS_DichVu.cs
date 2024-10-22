using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_DichVu
    {
        public static BUS_DichVu instance;
        public static BUS_DichVu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_DichVu();
                }
                return instance;
            }
        }
        public BUS_DichVu() { }

        private DAO_DichVu dao_dv = new DAO_DichVu();
        public void ThemDV(TextBox maDV, ComboBox maLDV, TextBox tenDV, TextBox gia)
        {
            DAO_DichVu.Instance.Them(maDV, maLDV, tenDV, gia);
        }
        public void XoaDV(TextBox maDV)
        {
            DAO_DichVu.Instance.Xoa(maDV.Text);
        }
        public void SuaDV(TextBox maDV, ComboBox maLDV, TextBox tenDV, TextBox gia)
        {
            DichVu dsdv = new DichVu
            {
                MaDichVu = maDV.Text,
                MaLoaiDichVu = maLDV.Text,
                TenDichVu = tenDV.Text,
                Gia = float.Parse(gia.Text),
            };
            DAO_DichVu.Instance.Sua(dsdv);
        }
        public List<DichVu> View()
        {
            return dao_dv.HienThiDSDV();
        }
        public void Xem(DataGridView data)
        {
            var dv = DAO_DichVu.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaDichVu,
                    t.MaLoaiDichVu,
                    t.TenDichVu,
                    t.Gia
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void LoadMaLoaiDV(ComboBox cb)
        {
            DAO_DichVu.Instance.LoadComBoBoxLoaiDichVu(cb);
        }
        public void LoadDGVLenForm(TextBox maDV, ComboBox maLDV, TextBox tenDV, TextBox gia, DataGridView data)
        {
            DAO_DichVu.Instance.LoadDGVForm(maDV, maLDV, tenDV, gia, data);
        }
    }
}
