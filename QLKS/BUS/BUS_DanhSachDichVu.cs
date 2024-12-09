using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace BUS
{
    public class BUS_DanhSachDichVu
    {
        public static BUS_DanhSachDichVu instance;
        DAO_DanhSachDichVu daoDV = new DAO_DanhSachDichVu();
        public static BUS_DanhSachDichVu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_DanhSachDichVu();
                }
                return instance;
            }
        }
        public BUS_DanhSachDichVu() { }

        public void Xem(DataGridView data)
        {
            var dv = DAO_DanhSachDichVu.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaSuDungDichVu,
                    t.MaDichVu,
                    t.MaDatPhong,
                    t.SoLuong,
                    t.Gia
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void LoadDatPhong(ComboBox cb)
        {
            DAO_DanhSachDichVu.Instance.LoadComBoBoxDatPhong(cb);
        }
        public void LoadDichVu(ComboBox cb)
        {
            DAO_DanhSachDichVu.Instance.LoadComBoBoxDichVu(cb);
        }
        public void LoadDGVLenForm(TextBox ma, ComboBox maDV, ComboBox maDP, TextBox soLuong, TextBox gia, DataGridView data)
        {
            DAO_DanhSachDichVu.Instance.LoadDGVForm(ma, maDV, maDP, soLuong, gia, data);
        }
        public void Them(TextBox maSDDichVu, ComboBox maDichVu, ComboBox maDatPhong, TextBox soLuong, TextBox gia)
        {
            DanhSachSuDungDichVu sd = new DanhSachSuDungDichVu
            {
                MaSuDungDichVu = maSDDichVu.Text,
                MaDichVu = maDichVu.SelectedValue.ToString(),
                MaDatPhong = maDatPhong.Text,
                SoLuong = int.Parse(soLuong.Text),
                Gia = float.Parse(gia.Text)
            };
            DAO_DanhSachDichVu.Instance.Them(sd);
        }
        public void Xoa(TextBox maSD)
        {
            DAO_DanhSachDichVu.Instance.Xoa(maSD.Text);
        }
        public void Sua(TextBox ma, ComboBox maDichVu, ComboBox maDatPhong, TextBox soLuong, TextBox gia)
        {
            DanhSachSuDungDichVu dsdv = new DanhSachSuDungDichVu
            {
                MaSuDungDichVu = ma.Text,
                MaDichVu = maDichVu.SelectedValue.ToString(),
                MaDatPhong = maDatPhong.Text,
                SoLuong = int.Parse(soLuong.Text),
                Gia = float.Parse(gia.Text)
            };

            bool result = DAO_DanhSachDichVu.Instance.Sua(dsdv);
            if (result)
            {
                MessageBox.Show("Sửa thành công!");
            }
            else
            {
                MessageBox.Show("Danh sach sử dụng dịch vụ không tồn tại hoặc sửa thất bại!");
            }
        }

        public bool CheckMaSDDVExists(string maSDDV)
        {
            return DAO_DanhSachDichVu.Instance.CheckMaSDDVExists(maSDDV);
        }

        public List<DanhSachSuDungDichVu> LayDanhSachSuDungDichVu()
        {
            return DAO_DanhSachDichVu.Instance.HienThi();
        }
        public double LayGiaDV(string maSDDV)
        {
            return daoDV.LayGiaDichVu(maSDDV);
        }
    }
}
