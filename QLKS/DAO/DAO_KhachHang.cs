using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_KhachHang
    {
        private static DAO_KhachHang instance;
        public static DAO_KhachHang Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_KhachHang();
                }
                return instance;
            }
        }
        private DAO_KhachHang() { }

        public List<KhachHang> Xem()
        {
            List<KhachHang> data = new List<KhachHang>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var khachHang = (from kh in db.KhachHangs
                              select new
                              {
                                  kh.MaKhachHang,
                                  kh.MaDichVu,
                                  kh.TenKhachHang,
                                  kh.CCCD,
                                  kh.Email,
                                  kh.SDT,
                                  kh.DiaChi,
                              }).ToList();

                foreach (var item in khachHang)
                {
                    KhachHang dvu = new KhachHang();
                    dvu.MaKhachHang = item.MaKhachHang;
                    dvu.MaDichVu = item.MaDichVu;
                    dvu.TenKhachHang = item.TenKhachHang;
                    dvu.CCCD = item.CCCD;
                    dvu.Email = item.Email;
                    dvu.SDT = item.SDT; 
                    dvu.DiaChi = item.DiaChi;
            
                    data.Add(dvu);
                }

            }
            return data;
        }
      
        public void LoadComBoBoxDichVu(ComboBox cb)
        {
            Dictionary<string, string> dp = new Dictionary<string, string>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var tenDV = from ma in db.DichVus
                            join loai in db.LoaiDichVus on ma.MaLoaiDichVu equals loai.MaLoaiDichVu
                            select new
                            {
                                ma.MaDichVu,
                                loai.TenLoaiDichVu,
                            };
                              



                foreach (var item in tenDV)
                {
                    dp.Add(item.MaDichVu, item.TenLoaiDichVu);
                }

                cb.DataSource = new BindingSource(dp, null);
                cb.DisplayMember = "Value";
                cb.ValueMember = "Key";
            }
        }
        public void LoadDGVForm(TextBox maKH, ComboBox maDichVu, TextBox tenKH, TextBox cccd,TextBox email, TextBox sdt,TextBox diaChi, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var rowIndex = data.SelectedCells[0].RowIndex;
                var row = data.Rows[rowIndex];
                maKH.Text = row.Cells[0].Value.ToString().Trim();
                maDichVu.Text = row.Cells[1].Value.ToString().Trim();
                tenKH.Text = row.Cells[2].Value.ToString().Trim();
                cccd.Text = row.Cells[3].Value.ToString().Trim();
                email.Text = row.Cells[4].Value.ToString().Trim();
                sdt.Text = row.Cells[5].Value.ToString().Trim();
                diaChi.Text = row.Cells[6].Value.ToString().Trim();

            }
        }
        public void Them(TextBox maKH, ComboBox maDichVu, TextBox tenKH, TextBox cccd, TextBox email, TextBox sdt, TextBox diaChi)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    KhachHang dp = new KhachHang();
                    dp.MaKhachHang = maKH.Text;
                    dp.MaDichVu = maDichVu.Text;
                    dp.TenKhachHang = tenKH.Text;
                    dp.MaKhachHang = cccd.Text;
                    dp.Email = email.Text;
                    dp.SDT = sdt.Text;
                    dp.DiaChi = diaChi.Text;
                    db.KhachHangs.InsertOnSubmit(dp);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Thêm vào bị lỗi " + ex);
            }
        }
        public void Xoa(string maKH)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var ma = db.KhachHangs.FirstOrDefault(a => a.MaKhachHang == maKH);
                if (ma != null)
                {
                    db.KhachHangs.DeleteOnSubmit(ma);
                    db.SubmitChanges();
                    MessageBox.Show("Xóa thành công");
                }
            }
        }
        public bool Sua(KhachHang kh)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var maKH = db.KhachHangs.SingleOrDefault(a => a.MaKhachHang == kh.MaKhachHang);
                if (maKH != null)
                {
                    maKH.MaKhachHang = kh.MaKhachHang;
                    maKH.MaDichVu = kh.MaDichVu;
                    maKH.TenKhachHang = kh.TenKhachHang;
                    maKH.CCCD = kh.CCCD;
                    maKH.Email= kh.Email;
                    maKH.SDT = kh.SDT;
                    maKH.DiaChi =kh.DiaChi;
                    db.SubmitChanges();
                    MessageBox.Show("Sua thành công");
                    return true;

                }
                return false;
            }
        }
    }
}
