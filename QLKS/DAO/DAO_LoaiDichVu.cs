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

        //public bool ThemLDV(string maLDV, string tenLDV, string maLoaiPhong)
        //{
        //    try
        //    {
        //        if (db.LoaiDichVus.Any(nv => nv.MaLoaiPhong == maLDV))
        //        {
        //            return false;
        //        }

        //        LoaiDichVu ldv = new LoaiDichVu
        //        {
        //            MaLoaiDichVu = maLDV,
        //            TenLoaiDichVu = tenLDV,
        //            MaLoaiPhong = maLoaiPhong
        //        };

        //        db.LoaiDichVus.InsertOnSubmit(ldv);
        //        db.SubmitChanges();

        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        //public void ThemLDV(TextBox maLDV, TextBox tenLDV, ComboBox maLoaiPhong)
        //{
        //    try
        //    {
        //        using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
        //        {
        //            LoaiDichVu dp = new LoaiDichVu();
        //            dp.MaLoaiDichVu = maLDV.Text;
        //            dp.TenLoaiDichVu = tenLDV.Text;
        //            dp.MaLoaiPhong = maLoaiPhong.Text;

        //            db.LoaiDichVus.InsertOnSubmit(dp);
        //            db.SubmitChanges();
        //            MessageBox.Show("Thêm thành công");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Thêm vào bị lỗi " + ex);
        //    }
        //}
        public void ThemLDV(LoaiDichVu ldv)
        {
            try
            {
                // Kiểm tra mã khách hàng đã tồn tại hay chưa
                if (CheckMaExists(ldv.MaLoaiDichVu))
                {
                    MessageBox.Show("Mã khách hàng đã tồn tại. Vui lòng nhập mã khác.");
                    return; // Không thực hiện thêm nếu mã đã tồn tại
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
        //public bool XoaLoaiDichVu(string maLDV)
        //{
        //    try
        //    {
        //        LoaiDichVu ldv = db.LoaiDichVus.FirstOrDefault(dv => dv.MaLoaiDichVu == maLDV);
        //        if (ldv != null)
        //        {
        //            db.LoaiDichVus.DeleteOnSubmit(ldv);
        //            db.SubmitChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
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
        //public bool SuaLoaiDichVu(LoaiDichVu maLDV)
        //{
        //    try
        //    {
        //        //LoaiDichVu ldv = db.LoaiDichVus.SingleOrDefault(dv => dv.MaLoaiDichVu == maLDV);
        //        //if (ldv != null)
        //        //{
        //        //    ldv.MaLoaiDichVu= maLDV;
        //        //    ldv.TenLoaiDichVu = tenLDV;
        //        //    ldv.MaLoaiPhong = maLoaiPhong;

        //        //    db.SubmitChanges();
        //        //    return true;
        //        //}
        //        //else
        //        //{
        //        //    return false;
        //        //}
        //        using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
        //        {
        //            var maLDVv = db.LoaiDichVus.FirstOrDefault(a => a.MaLoaiDichVu == maLDV.MaLoaiDichVu);
        //            if (maLDVv != null)
        //            {
        //                maLDVv.MaLoaiDichVu = maLDV.MaLoaiDichVu;
        //                maLDVv.TenLoaiDichVu = maLDV.TenLoaiDichVu;
        //                maLDVv.MaLoaiPhong = maLDV.MaLoaiPhong;
        //                db.SubmitChanges();
        //                MessageBox.Show("Sửa thành công");
        //                return true;
        //            }
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public bool SuaLoaiDichVu(LoaiDichVu ldv)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                // Fetch the customer by ID
                var maLDV = db.LoaiDichVus.SingleOrDefault(a => a.MaLoaiDichVu == ldv.MaLoaiDichVu);
                if (maLDV != null)
                {
                    // Update the customer's details
                    maLDV.MaLoaiDichVu = ldv.MaLoaiDichVu;
                    maLDV.TenLoaiDichVu = ldv.TenLoaiDichVu;
                    maLDV.MaLoaiPhong = ldv.MaLoaiPhong;

                    // Commit changes to the database
                    db.SubmitChanges();
                    MessageBox.Show("Sửa thành công");
                    return true;
                }
                return false; // Customer not found
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
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString())) // Giả sử đây là context của Entity Framework
            {
                // Sử dụng LINQ để kiểm tra trùng mã
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
                cb.DisplayMember = "TenLoaiPhong"; // Hiển thị tên dịch vụ
                cb.ValueMember = "MaLoaiPhong"; // Giá trị là mã dịch vụ
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

                    // Gán giá trị vào các TextBox
                    maLDV.Text = row.Cells[0].Value.ToString().Trim();
                    string selectedMaLP = row.Cells[2].Value.ToString().Trim();
                    tenLDV.Text = row.Cells[1].Value.ToString().Trim();

                    // Tìm đối tượng trong ComboBox có mã trùng với mã được chọn từ DataGridView
                    foreach (var item in maLP.Items)
                    {
                        var loaiDichVu = item as dynamic; // Chuyển đối tượng sang kiểu động nếu cần
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
