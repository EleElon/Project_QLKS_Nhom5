using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_DichVu
    {
        DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

        private static DAO_DichVu instance;
        public static DAO_DichVu Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_DichVu();
                }
                return instance;
            }
        }
        public DAO_DichVu() { }
        public List<DichVu> Xem()
        {
            List<DichVu> data = new List<DichVu>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var dichvu = db.DichVus.ToList();

                foreach (var item in dichvu)
                {
                    data.Add(new DichVu
                    {
                        MaDichVu = item.MaDichVu,
                        MaLoaiDichVu = item.MaLoaiDichVu,
                        TenDichVu = item.TenDichVu,
                        Gia = item.Gia
                    });
                }
            }
            return data;
        }
        public void Them(DichVu dv)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    db.DichVus.InsertOnSubmit(dv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công " + ex);
            }
        }
        public void Xoa(string maDV)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    var ma = db.DichVus.FirstOrDefault(a => a.MaDichVu == maDV);
                    if (ma != null)
                    {
                        db.DichVus.DeleteOnSubmit(ma);
                        db.SubmitChanges();
                        MessageBox.Show("Xóa thành công");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa không thành công " + ex);
            }
        }
        public bool Sua(DichVu DV)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maDV = db.DichVus.FirstOrDefault(a => a.MaDichVu == DV.MaDichVu);
                if (maDV != null)
                {
                    maDV.MaDichVu = DV.MaDichVu;
                    maDV.MaLoaiDichVu = DV.MaLoaiDichVu;
                    maDV.TenDichVu = DV.TenDichVu;
                    maDV.Gia = DV.Gia;
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    return true;
                }
                return false;
            }
        }

        public List<DichVu> HienThiDSDV()
        {
            return db.DichVus.ToList();
        }
        public void LoadComBoBoxLoaiDichVu(ComboBox cb)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var loaiDichVus = db.LoaiDichVus
                                    .Select(ldv => new { ldv.MaLoaiDichVu, ldv.TenLoaiDichVu })
                                    .ToList();

                cb.DataSource = loaiDichVus;
                cb.DisplayMember = "TenLoaiDichVu";
                cb.ValueMember = "MaLoaiDichVu";
            }
        }

        public void LoadDGVForm(TextBox maDV, ComboBox maLDV, TextBox tenDV, TextBox gia, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];

                    maDV.Text = row.Cells[0].Value.ToString().Trim();
                    string selectedMaLDV = row.Cells[1].Value.ToString().Trim();
                    tenDV.Text = row.Cells[2].Value.ToString().Trim();
                    gia.Text = row.Cells[3].Value.ToString().Trim();

                    foreach (var item in maLDV.Items)
                    {
                        var loaiDichVu = item as dynamic;
                        if (loaiDichVu != null && loaiDichVu.MaLoaiDichVu == selectedMaLDV)
                        {
                            maLDV.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
        public bool CheckMaExists(string maDV)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                return context.DichVus.Any(dv => dv.MaDichVu == maDV);
            }
        }
        public double LayGiaDichVu(string maDichVu)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var gia = (from dv in db.DichVus
                           where dv.MaDichVu == maDichVu
                           select dv.Gia).FirstOrDefault();

                if (gia == 0)
                {
                    return 0;
                }

                return gia;
            }
        }
    }
}
