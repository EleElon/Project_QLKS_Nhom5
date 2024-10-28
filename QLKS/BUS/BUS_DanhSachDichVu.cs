using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_DanhSachDichVu
    {
        private static BUS_DanhSachDichVu instance;
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
        private BUS_DanhSachDichVu() { }

        public void Xem(DataGridView data)
        {
            var dv= DAO_DanhSachDichVu.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaSuDungDichVu,
                    t.MaDichVu,
                    t.MaDatPhong,
                    t.SoLuong
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
        public void LoadDGVLenForm(TextBox ma,ComboBox maDV, ComboBox maDP,TextBox soLuong,DataGridView data)
        {
            DAO_DanhSachDichVu.Instance.LoadDGVForm(ma, maDV, maDP, soLuong, data);
        }
        public void Them(TextBox maSDDichVu, ComboBox maDichVu, ComboBox maDatPhong, TextBox soLuong)
        {
            DAO_DanhSachDichVu.Instance.Them(maSDDichVu, maDichVu, maDatPhong, soLuong);
        }
        public void Xoa(TextBox maSD)
        {
            DAO_DanhSachDichVu.Instance.Xoa(maSD.Text);
        }
        public void Sua(TextBox maSDDichVu, ComboBox maDichVu, ComboBox maDatPhong, TextBox soLuong)
        {
            DanhSachSuDungDichVu dsdv = new DanhSachSuDungDichVu
            {
                MaSuDungDichVu = maSDDichVu.Text,
                MaDichVu = maDichVu.Text,
                MaDatPhong = maDatPhong.Text,
                SoLuong = int.Parse(soLuong.Text),
            };
            DAO_DanhSachDichVu.Instance.Sua(dsdv);
        }
        // Phương thức gọi DAL để kiểm tra trùng mã sử dụng dịch vụ
        public bool CheckMaSDDVExists(string maSDDV)
        {
            return DAO_DanhSachDichVu.Instance.CheckMaSDDVExists(maSDDV);
        }

    }
}
