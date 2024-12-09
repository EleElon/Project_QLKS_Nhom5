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
                        TenBangChamCong = item.TenBangChamCong,
                        MaNhanVien = item.MaNhanVien,
                        Thang = item.Thang,
                        Nam = item.Nam,
                        SoNgayLamViec = item.SoNgayLamViec,
                        SoGioTangCa = item.SoGioTangCa,
                        NgayChamCong = item.NgayChamCong,
                        GhiChu = item.GhiChu
                    });
                }
            }
            return data;
        }
        public bool ThemLuong(string maCham, string maNV, string thang, int nam, int soNgayLam, float soGioTangCa, DateTime ngayChamCong, string ghiChu)
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
                    SoGioTangCa = soGioTangCa,
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

        public bool SuaChamCong(string maCham, string tenBangChamCong, string maNV, string thang, int nam, int soNgayLam, float soGioTangCa, DateTime ngayChamCong, string ghiChu)
        {
            try
            {
                ChamCong cham = db.ChamCongs.FirstOrDefault(a => a.MaChamCong == maCham);
                if (cham != null)
                {
                    cham.MaChamCong = maCham;
                    cham.TenBangChamCong = tenBangChamCong;
                    cham.MaNhanVien = maNV;
                    cham.Thang = thang;
                    cham.Nam = nam;
                    cham.SoNgayLamViec = soNgayLam;
                    cham.SoGioTangCa = soGioTangCa;
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
        public bool ChamCong(string maCham, int soNgayLam, float soGioTangCa)
        {
            try
            {
                ChamCong cham = db.ChamCongs.FirstOrDefault(a => a.MaChamCong == maCham);
                if (cham != null)
                {
                    cham.MaChamCong = maCham;
                    cham.SoNgayLamViec = soNgayLam;
                    cham.SoGioTangCa = soGioTangCa;

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

        public void LoadDGVForm(TextBox maCham, TextBox tenBangChamCong, ComboBox maNV, ComboBox thang, NumericUpDown nam, NumericUpDown soNgayLam, TextBox soGioTangCa, DateTimePicker ngayCham, TextBox ghiChu, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];

                    maCham.Text = row.Cells[0].Value?.ToString().Trim() ?? string.Empty;
                    tenBangChamCong.Text = row.Cells[1].Value?.ToString().Trim() ?? string.Empty;

                    string selectedMaNV = row.Cells[2].Value?.ToString().Trim() ?? string.Empty;
                    thang.Text = row.Cells[3].Value?.ToString().Trim() ?? string.Empty;

                    if (int.TryParse(row.Cells[4].Value?.ToString().Trim(), out int namValue))
                    {
                        nam.Value = namValue;
                    }

                    if (int.TryParse(row.Cells[5].Value?.ToString().Trim(), out int soNgayLamValue))
                    {
                        soNgayLam.Value = soNgayLamValue;
                    }

                    soGioTangCa.Text = row.Cells[6].Value?.ToString().Trim() ?? string.Empty;

                    if (DateTime.TryParse(row.Cells[7].Value?.ToString().Trim(), out DateTime parsedNgayCham))
                    {
                        ngayCham.Value = parsedNgayCham;
                    }

                    ghiChu.Text = row.Cells[8].Value?.ToString().Trim() ?? string.Empty;

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
