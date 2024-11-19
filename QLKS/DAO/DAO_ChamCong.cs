using Microsoft.ReportingServices.RdlExpressions.ExpressionHostObjectModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAO
{
    public class DAO_ChamCong
    {
        private DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

        private static DAO_ChamCong instance;
        public static DAO_ChamCong Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_ChamCong();
                }
                return instance;
            }
        }
        public DAO_ChamCong() { }

        public List<ChamCong> Xem()
        {
            List<ChamCong> data = new List<ChamCong>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var chamCOng = db.ChamCongs.ToList();

                foreach (var item in chamCOng)
                {
                    data.Add(new ChamCong
                    {
                        MaChamCong = item.MaChamCong,
                        MaNhanVien = item.MaNhanVien,
                        Thang = item.Thang,
                        Nam = item.Nam,
                        SoNgayLamViec = item.SoNgayLamViec,
                        NgayChamCong = item.NgayChamCong,
                        GhiChu = item.GhiChu
                    });
                }
            }
            return data;
        }
        public bool ThemLuong(string maCham, string maNV, string thang, int nam, int soNgayLam, DateTime ngayChamCong, string ghiChu)
        {
            try
            {
                if (db.ChamCongs.Any(a => a.MaChamCong == maCham))
                {
                    return false;
                }

                ChamCong cham = new ChamCong
                {
                    MaChamCong = maCham,
                    MaNhanVien = maNV,
                    Thang = thang,
                    Nam = nam,
                    SoNgayLamViec = soNgayLam,
                    NgayChamCong = ngayChamCong,
                    GhiChu = ghiChu
                };

                db.ChamCongs.InsertOnSubmit(cham);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Them(ChamCong a)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    db.ChamCongs.InsertOnSubmit(a);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công " + ex);
            }
        }

        public bool XoaChamCong(string maCham)
        {
            try
            {
                ChamCong cham = db.ChamCongs.FirstOrDefault(a => a.MaChamCong == maCham);
                if (cham != null)
                {
                    db.ChamCongs.DeleteOnSubmit(cham);
                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SuaChamCong(string maCham, string maNV, string thang, int nam, int soNgayLam, DateTime ngayChamCong, string ghiChu)
        {
            try
            {
                ChamCong cham= db.ChamCongs.FirstOrDefault(a => a.MaChamCong == maCham);
                if (cham != null)
                {
                    cham.MaChamCong = maCham;
                    cham.MaNhanVien = maNV;
                    cham.Thang = thang;
                    cham.Nam = nam;
                    cham.SoNgayLamViec = soNgayLam;
                    cham.NgayChamCong = ngayChamCong;
                    cham.GhiChu = ghiChu;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool ChamCong(string maCham, int soNgayLam)
        {
            try
            {
                ChamCong cham = db.ChamCongs.FirstOrDefault(a => a.MaChamCong == maCham);
                if (cham != null)
                {
                    cham.MaChamCong = maCham;
                    cham.SoNgayLamViec = soNgayLam;

                    db.SubmitChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ChamCong> HienThiDanhSachChamCong()
        {
            return db.ChamCongs.ToList();
        }
        public void LoadComBoBoxMaNhanVien(ComboBox cb)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var nhanViens = db.NhanViens
                                    .Select(nv => new { nv.MaNhanVien, nv.TenNhanVien })
                                    .ToList();

                cb.DataSource = nhanViens;
                cb.DisplayMember = "TenNhanVien";
                cb.ValueMember = "MaNhanVien";
            }
        }

        public void LoadDGVForm(TextBox maCham, ComboBox maNV, ComboBox thang, NumericUpDown nam, NumericUpDown soNgayLam, DateTimePicker ngayCham, TextBox ghiChu, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];

                    maCham.Text = row.Cells[0].Value.ToString().Trim();
                    string selectedMaNV = row.Cells[1].Value.ToString().Trim();
                    thang.Text = row.Cells[2].Value.ToString().Trim();
                    nam.Text = row.Cells[3].Value.ToString().Trim();
                    soNgayLam.Text = row.Cells[4].Value.ToString().Trim();

                    if (DateTime.TryParse(row.Cells[5].Value.ToString().Trim(), out DateTime parsedNgayCham))
                    {
                        ngayCham.Value = parsedNgayCham;
                    }

                    ghiChu.Text = row.Cells[6].Value.ToString().Trim();

                    foreach (var item in maNV.Items)
                    {
                        var nhanVien = item as dynamic;
                        if (nhanVien != null && nhanVien.MaNhanVien == selectedMaNV)
                        {
                            maNV.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
        public bool CheckMaExists(string maCham)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                return context.ChamCongs.Any(l => l.MaChamCong == maCham);
            }
        }
    }
}
