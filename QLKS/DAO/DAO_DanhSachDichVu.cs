using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_DanhSachDichVu
    {
        public static DAO_DanhSachDichVu instance;
        public static DAO_DanhSachDichVu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_DanhSachDichVu();
                }
                return instance;
            }
        }
        public DAO_DanhSachDichVu() { }

        public List<DanhSachSuDungDichVu> Xem()
        {
            List<DanhSachSuDungDichVu> data = new List<DanhSachSuDungDichVu>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var dichvu = (from dv in db.DanhSachSuDungDichVus
                              select new
                              {
                                  dv.MaSuDungDichVu,
                                  dv.MaDichVu,
                                  dv.MaDatPhong,
                                  dv.SoLuong,
                                  dv.Gia
                              }).ToList();

                foreach (var item in dichvu)
                {
                    DanhSachSuDungDichVu dvu = new DanhSachSuDungDichVu();
                    dvu.MaSuDungDichVu = item.MaSuDungDichVu;
                    dvu.MaDichVu = item.MaDichVu;
                    dvu.MaDatPhong = item.MaDatPhong;
                    dvu.SoLuong = item.SoLuong;
                    dvu.Gia = item.Gia;
                    data.Add(dvu);
                }
            }
            return data;
        }

        public void LoadComBoBoxDatPhong(ComboBox cb)
        {
            Dictionary<string, string> dp = new Dictionary<string, string>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maDPhong = from ma in db.DatPhongs
                               select (
                                   ma.MaDatPhong);

                foreach (var item in maDPhong)
                {
                    dp.Add(item, item);
                }

                cb.DataSource = new BindingSource(dp, null);
                cb.DisplayMember = "Value";
                cb.ValueMember = "Key";
            }
        }
        public void LoadComBoBoxDichVu(ComboBox cb)
        {
            Dictionary<string, string> dp = new Dictionary<string, string>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var tenDV = from ma in db.DichVus
                            select new
                            {
                                ma.MaDichVu,
                                ma.TenDichVu
                            };

                foreach (var item in tenDV)
                {
                    dp.Add(item.MaDichVu, item.TenDichVu);
                }

                cb.DataSource = new BindingSource(dp, null);
                cb.DisplayMember = "Value";
                cb.ValueMember = "Key";
            }
        }
        public void LoadDGVForm(TextBox maSDDichVu, ComboBox maDichVu, ComboBox maDatPhong, TextBox soLuong, TextBox gia, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var rowIndex = data.SelectedCells[0].RowIndex;
                var row = data.Rows[rowIndex];

                maSDDichVu.Text = row.Cells[0].Value.ToString().Trim();
                maDichVu.SelectedValue = row.Cells[1].Value != null ? row.Cells[1].Value.ToString().Trim() : null;
                maDatPhong.SelectedValue = row.Cells[2].Value != null ? row.Cells[2].Value.ToString().Trim() : null;
                soLuong.Text = row.Cells[3].Value.ToString().Trim();
                gia.Text = row.Cells[4].Value.ToString().Trim();
            }
        }
        public void Them(DanhSachSuDungDichVu dv)
        {
            try
            {
                if (CheckMaSDDVExists(dv.MaSuDungDichVu))
                {
                    MessageBox.Show("Mã su dung vu đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }

                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    db.DanhSachSuDungDichVus.InsertOnSubmit(dv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm vào bị lỗi ");
            }
        }
        public void Xoa(string maSDDichVu)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var ma = db.DanhSachSuDungDichVus.FirstOrDefault(a => a.MaSuDungDichVu == maSDDichVu);
                if (ma != null)
                {
                    db.DanhSachSuDungDichVus.DeleteOnSubmit(ma);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công");
                }
                else
                {
                    MessageBox.Show("Xóa không thành công");
                }
            }
        }

        public bool Sua(DanhSachSuDungDichVu daDV)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maSDDV = db.DanhSachSuDungDichVus.SingleOrDefault(a => a.MaSuDungDichVu == daDV.MaSuDungDichVu);
                if (maSDDV != null)
                {
                    maSDDV.MaDichVu = daDV.MaDichVu;
                    maSDDV.MaDatPhong = daDV.MaDatPhong;
                    maSDDV.SoLuong = daDV.SoLuong;
                    maSDDV.Gia = daDV.Gia;
                    db.SubmitChanges();

                    return true;
                }
                return false;
            }
        }
        public bool CheckMaSDDVExists(string maSDDV)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                return context.DanhSachSuDungDichVus.Any(dv => dv.MaSuDungDichVu == maSDDV);
            }
        }
        public List<DanhSachSuDungDichVu> HienThi()
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                return db.DanhSachSuDungDichVus.ToList();
            }
        }
        public double LayGiaDichVu(string maSDDV)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var gia = (from ds in db.DanhSachSuDungDichVus
                           where ds.MaSuDungDichVu == maSDDV
                           select ds.Gia).FirstOrDefault();

                return gia ?? 0;
            }
        }
    }
}
