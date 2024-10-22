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
        public void ThemLDV(TextBox maLDV, TextBox tenLDV, TextBox maLoaiPhong)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    LoaiDichVu dp = new LoaiDichVu();
                    dp.MaLoaiDichVu = maLDV.Text;
                    dp.TenLoaiDichVu = tenLDV.Text;
                    dp.MaLoaiPhong = maLoaiPhong.Text;

                    db.LoaiDichVus.InsertOnSubmit(dp);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm vào bị lỗi " + ex);
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
        public bool SuaLoaiDichVu(LoaiDichVu maLDV)
        {
            try
            {
                //LoaiDichVu ldv = db.LoaiDichVus.SingleOrDefault(dv => dv.MaLoaiDichVu == maLDV);
                //if (ldv != null)
                //{
                //    ldv.MaLoaiDichVu= maLDV;
                //    ldv.TenLoaiDichVu = tenLDV;
                //    ldv.MaLoaiPhong = maLoaiPhong;

                //    db.SubmitChanges();
                //    return true;
                //}
                //else
                //{
                //    return false;
                //}
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    var maLDVv = db.LoaiDichVus.SingleOrDefault(a => a.MaLoaiDichVu == maLDV.MaLoaiDichVu);
                    if (maLDVv != null)
                    {
                        maLDVv.MaLoaiDichVu = maLDV.MaLoaiDichVu;
                        maLDVv.TenLoaiDichVu = maLDV.TenLoaiDichVu;
                        maLDVv.MaLoaiPhong = maLDV.MaLoaiPhong;
                        db.SubmitChanges();
                        MessageBox.Show("Sửa thành công");
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
    }
}
