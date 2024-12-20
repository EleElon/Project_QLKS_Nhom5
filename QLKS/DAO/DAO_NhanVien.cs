﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DAO
{
    public class DAO_NhanVien
    {
        private DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString());

        private static DAO_NhanVien instance;
        public static DAO_NhanVien Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_NhanVien();
                }
                return instance;
            }
        }
        public DAO_NhanVien() { }
        public bool ThemNhanVien(string maNV, string maPhong, string tenNV, string gioiTinh, DateTime ngaySinh, string SDT, string chucVu, string diaChi)
        {
            try
            {
                if (db.NhanViens.Any(nv => nv.MaNhanVien == maNV))
                {
                    return false;
                }

                NhanVien nhanVien = new NhanVien
                {
                    MaNhanVien = maNV,
                    MaPhong = maPhong,
                    TenNhanVien = tenNV,
                    gioiTinh = gioiTinh,
                    ngaySinh = ngaySinh,
                    SDT = SDT,
                    ChucVu = chucVu,
                    diaChi = diaChi
                };

                db.NhanViens.InsertOnSubmit(nhanVien);
                db.SubmitChanges();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Them(NhanVien nv)
        {
            try
            {
                using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
                {
                    db.NhanViens.InsertOnSubmit(nv);
                    db.SubmitChanges();
                    MessageBox.Show("Thêm thành công");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm không thành công " + ex);
            }
        }

        public bool XoaNhanVien(string maNV)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNV);
                if (nhanVien != null)
                {
                    db.NhanViens.DeleteOnSubmit(nhanVien);
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

        public bool SuaNhanVien(string maNV, string maPhong, string tenNV, string gioiTinh, DateTime ngaySinh, string SDT, string chucVu, string diaChi)
        {
            try
            {
                NhanVien nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == maNV);
                if (nhanVien != null)
                {
                    nhanVien.MaNhanVien = maNV;
                    nhanVien.MaPhong = maPhong;
                    nhanVien.TenNhanVien = tenNV;
                    nhanVien.gioiTinh = gioiTinh;
                    nhanVien.ngaySinh = ngaySinh;
                    nhanVien.SDT = SDT;
                    nhanVien.ChucVu = chucVu;
                    nhanVien.diaChi = diaChi;

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

        public List<NhanVien> HienThiDanhSachNhanVien()
        {
            return db.NhanViens.ToList();
        }
        public void LoadComBoBoxMaPhong(ComboBox cb)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var phongs = db.Phongs
                                    .Select(maPhong => new { maPhong.MaPhong, maPhong.SoPhong })
                                    .ToList();

                cb.DataSource = phongs;
                cb.DisplayMember = "SoPhong"; // Hiển thị tên dịch vụ
                cb.ValueMember = "MaPhong"; // Giá trị là mã dịch vụ
            }
        }
        public void LoadDGVForm(TextBox maNV, ComboBox maPhong, TextBox tenNV, RadioButton nam, RadioButton nu, DateTimePicker ngaySinh, TextBox SDT, TextBox chucVu, TextBox diaChi, DataGridView data)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                if (data.SelectedCells.Count > 0)
                {
                    var rowIndex = data.SelectedCells[0].RowIndex;
                    var row = data.Rows[rowIndex];

                    maNV.Text = row.Cells[0].Value.ToString().Trim();
                    string selectedMaPhong = row.Cells[1].Value.ToString().Trim();
                    tenNV.Text = row.Cells[2].Value.ToString().Trim();
                    string gioiTinh = row.Cells[3].Value.ToString().Trim();

                    if (gioiTinh == "Nam")
                    {
                        nam.Checked = true;
                    }
                    else if (gioiTinh == "Nu")
                    {
                        nu.Checked = true;
                    }

                    if (DateTime.TryParse(row.Cells[4].Value.ToString().Trim(), out DateTime parsedNgaySinh))
                    {
                        ngaySinh.Value = parsedNgaySinh;
                    }

                    SDT.Text = row.Cells[5].Value.ToString().Trim();
                    chucVu.Text = row.Cells[6].Value.ToString().Trim();
                    diaChi.Text = row.Cells[7].Value.ToString().Trim();

                    foreach (var item in maPhong.Items)
                    {
                        var Phong = item as dynamic;
                        if (Phong != null && Phong.MaPhong == selectedMaPhong)
                        {
                            maPhong.SelectedItem = item;
                            break;
                        }
                    }
                }
            }
        }
        public bool CheckMaExists(string maNV)
        {
            using (var context = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                return context.NhanViens.Any(nv => nv.MaNhanVien == maNV);
            }
        }
        public List<NhanVien> Xem()
        {
            List<NhanVien> data = new List<NhanVien>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var nv = db.NhanViens.ToList();

                foreach (var item in nv)
                {
                    data.Add(new NhanVien
                    {
                        MaNhanVien = item.MaNhanVien,
                        MaPhong = item.MaPhong,
                        TenNhanVien = item.TenNhanVien,
                        gioiTinh = item.gioiTinh,
                        ngaySinh = item.ngaySinh,
                        SDT = item.SDT,
                        ChucVu = item.ChucVu,
                        diaChi = item.diaChi
                    }); ;
                }
            }
            return data;
        }
    }
}
