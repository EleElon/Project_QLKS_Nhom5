using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_LoaiDichVu
    {
        private DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

        private static DAO_LoaiDichVu instance;
        public static DAO_LoaiDichVu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_LoaiDichVu();
                }
                return instance;
            }
        }
        public DAO_LoaiDichVu() { }

        public void ThemLDV(LoaiDichVu ldv)
        {
            try
            {
                if (CheckMaExists(ldv.MaLoaiDichVu))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác.");
                    return;
                }

                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    db.LoaiDichVus.InsertOnSubmit(ldv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Thêm vào bị lỗi ");
            }
        }

        public void XoaLoaiDichVu(string maLDV)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var ma = db.LoaiDichVus.FirstOrDefault(a => a.MaLoaiDichVu == maLDV);
                if (ma != null)
                {
                    db.LoaiDichVus.DeleteOnSubmit(ma);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công");
                }
            }
        }

        public bool SuaLoaiDichVu(LoaiDichVu ldv)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maLDV = db.LoaiDichVus.SingleOrDefault(a => a.MaLoaiDichVu == ldv.MaLoaiDichVu);
                if (maLDV != null)
                {
                    maLDV.MaLoaiDichVu = ldv.MaLoaiDichVu;
                    maLDV.TenLoaiDichVu = ldv.TenLoaiDichVu;
                    maLDV.MaLoaiPhong = ldv.MaLoaiPhong;

                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    return true;
                }
                return false;
            }
        }
        public List<LoaiDichVu> HienThiDanhSachLoaiDichVu()
        {
            return db.LoaiDichVus.ToList();
        }
        public List<LoaiDichVu> Xem()
        {
            List<LoaiDichVu> data = new List<LoaiDichVu>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var ldichvu = db.LoaiDichVus.ToList();

                foreach (var item in ldichvu)
                {
                    data.Add(new LoaiDichVu
                    {
                        MaLoaiDichVu = item.MaLoaiDichVu,
                        TenLoaiDichVu = item.TenLoaiDichVu,
                        MaLoaiPhong = item.MaLoaiPhong
                    });
                }
            }
            return data;
        }
        public bool CheckMaExists(string maLDV)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                return context.LoaiDichVus.Any(a => a.MaLoaiDichVu == maLDV);
            }
        }
        public void LoadComBoBoxLoaiPhong(ComboBox cb)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var loaiPhongs = db.LoaiPhongs
                                    .Select(lp => new { lp.MaLoaiPhong, lp.TenLoaiPhong })
                                    .ToList();

                cb.DataSource = loaiPhongs;
                cb.DisplayMember = "TenLoaiPhong";
                cb.ValueMember = "MaLoaiPhong";
            }
        }
        public void LoadDGVForm(TextBox maLDV, TextBox tenLDV, ComboBox maLP, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];

                    maLDV.Text = row.Cells[0].Value.ToString().Trim();
                    string selectedMaLP = row.Cells[2].Value.ToString().Trim();
                    tenLDV.Text = row.Cells[1].Value.ToString().Trim();

                    foreach (var item in maLP.Items)
                    {
                        var loaiDichVu = item as dynamic;
                        if (loaiDichVu != null && loaiDichVu.MaLoaiPhong == selectedMaLP)
                        {
                            maLP.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
    }
}
