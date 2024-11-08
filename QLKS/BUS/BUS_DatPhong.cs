using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BUS
{
    public class BUS_DatPhong
    {
        private static BUS_DatPhong instance;
        public static BUS_DatPhong Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_DatPhong();
                }
                return instance;
            }
        }
        private BUS_DatPhong() { }

        public void Xem(DataGridView data)
        {
            var dv = DAO_DatPhong.Instance.Xem().Select(t =>
            {
                return new
                {
                    t.MaChiTietDatPhong,
                    t.MaDatPhong,
                    t.MaKhachHang,
                    t.MaPhong,
                    t.MaLoaiPhong,
                    t.TinhTrang,
                    t.GiaMoiDem,
                    t.SoLuongPhong,
                    t.TongGia,
                    t.PhuongThucThanhToan,
                    t.NgayNhanPhong,
                    t.NgayTraPhong
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void XemDP(DataGridView data)
        {
            var dv = DAO_DatPhong.Instance.XemDatPhong().Select(t =>
            {
                return new
                {
                    
                    t.MaDatPhong,
                    t.MaKhachHang,
                  
                };
            }).ToList();
            data.DataSource = dv;
        }
        public void LoadComBoBoxMaKHachHang(ComboBox cb)
        {
            DAO_DatPhong.Instance.LoadComBoBoxKhachHang(cb.Text);
        }
        public string LayMaKHachHang(ComboBox cb)
        {
            return DAO_DatPhong.Instance.LaymaKhachHang(cb.Text.ToString());
        }

        public void LoadComBoBoxMaDatPhong(ComboBox cb)
        {
            DAO_DatPhong.Instance.LoadComBoBoxDatPhong(cb);
        }

        public void LoadComBoBoxLoaiPhong(ComboBox cb, string maphong, TextBox tinhtrang,TextBox gia)
        {
            DAO_DatPhong.Instance.LoadComBoBoxLoaiPhongg(cb, maphong, tinhtrang,gia);
        }
        public void LoadComBoBoxMaPhong(ComboBox cb)
        {
            DAO_DatPhong.Instance.LoadComBoBoxPhong(cb);
        }
        public void LoadTenKhachHang(ComboBox cb)
        {
            DAO_DatPhong.Instance.LoadTenKhachhangODatPhong(cb);
        }
        public void LoadDGVLenFormDP(TextBox maDP, ComboBox maKH, DataGridView data)
        {
            DAO_DatPhong.Instance.LoadDGVFormDatPhong( maDP, maKH, data);
        }
        public void Them(TextBox maDatPhong, ComboBox maKHH)
        {
            DatPhong sd = new DatPhong
            {
               
               
                MaDatPhong = maDatPhong.Text,
                MaKhachHang = maKHH.SelectedValue.ToString(),
            

            };
            DAO_DatPhong.Instance.ThemDP(sd);
        }
        public void Xoa(TextBox maDPP)
        {
            DAO_DatPhong.Instance.XoaDatPhong(maDPP.Text);
        }
        public void Sua(TextBox maDatPhong, ComboBox maKHH)
        {
            DatPhong dp = new DatPhong
            {
                MaDatPhong = maDatPhong.Text,
                MaKhachHang = maKHH.SelectedValue.ToString()
            };


            DAO_DatPhong.Instance.SuaDatPhong(dp);
        }
        // Phương thức gọi DAL để kiểm tra trùng mã sử dụng dịch vụ
        public bool CheckMaSDDVExists(string maDPP)
        {
            return DAO_DatPhong.Instance.CheckMaSDDVExists(maDPP);
        }
        public string GetCustomerNameByBookingId(string maDatPhong)
        {
            return DAO_DatPhong.Instance.GetCustomerNameByBookingId(maDatPhong);
        }
        //public (string TenLoaiPhong, string TinhTrang) GetRoomInfo(string maPhong)
        //{
        //    return DAO_DatPhong.Instance.GetRoomInfoById(maPhong);
        //}

        public void AddBookingDetail(TextBox maCT,ComboBox maDatP,string maKH,ComboBox maPhong, ComboBox tenPhong,TextBox tinhTrang,TextBox gia,TextBox soLuong,TextBox TongGia, ComboBox pTTT,DateTime ngayNhan, DateTime ngayTra)
        {
           
            ChiTietDatPhong chiTietDatPhong = new ChiTietDatPhong
            {
                MaChiTietDatPhong = maCT.Text, // Mã sẽ được sinh tự động trong thực tế
                MaDatPhong = maDatP.Text,
                MaKhachHang = maKH,
                MaPhong = maPhong.Text,
                MaLoaiPhong = tenPhong.SelectedValue.ToString(),
                TinhTrang = tinhTrang.Text,
                GiaMoiDem = float.Parse(gia.Text.Trim()),
                SoLuongPhong = int.Parse(soLuong.Text.Trim()),

                // Tính tổng giá
                TongGia = float.Parse(gia.Text) * int.Parse(soLuong.Text),

                PhuongThucThanhToan = pTTT.SelectedItem.ToString(),
                NgayNhanPhong = ngayNhan,
                NgayTraPhong = ngayTra
            };

            if (ngayTra < ngayNhan)
            {
                MessageBox.Show("Ngày trả phòng không được trước ngày nhận phòng.");
                return;
            }

            // Gọi lớp DAO để thêm chi tiết đặt phòng
            DAO_DatPhong.Instance.ThemChiTietDatPhong(chiTietDatPhong);
        }
        public void LoadDuLieuLenChiTiet(TextBox ma, ComboBox maDP, ComboBox maKH, ComboBox maP, ComboBox maL, TextBox tinhTrang, TextBox gia, TextBox soLuong, TextBox tong,ComboBox pttt, DateTimePicker ngayNhan, DateTimePicker ngayTra, DataGridView data)
        {
            DAO_DatPhong.Instance.LoadDGVFormCTDatPhong(ma, maDP, maKH, maP, maL, tinhTrang, gia, soLuong, tong,pttt, ngayNhan, ngayTra, data);
        }

        // Method to check room availability and add booking detail
        public bool AddBookingDetailIfAvailable(string maPhong, ChiTietDatPhong bookingDetail)
        {
            // Check room status
            string roomStatus = DAO_DatPhong.Instance.GetRoomStatusById(maPhong);

            // If room is in use or under maintenance, return false
            if (roomStatus == "Đang su dung" || roomStatus == "Đang bao tri")
            {
                return false;
            }

            // Add booking if the room is available
            DAO_DatPhong.Instance.ThemChiTietDatPhong(bookingDetail);
            return true;
        }
        public void XoaCT(TextBox ma)
        {
            DAO_DatPhong.Instance.Xoa(ma.Text);
        }



        
        // Phương thức tính tổng giá từ mã phòng và số lượng
        public decimal CalculateTotalPrice(string roomCode, int quantity)
        {
            return DAO_DatPhong.Instance.CalculateTotalPrice(roomCode, quantity); // Gọi phương thức DAO để tính tổng giá
        }
        public void SuaCT(TextBox maCT, ComboBox maDatP, string maKH, ComboBox maPhong, ComboBox tenPhong, TextBox tinhTrang, TextBox gia, TextBox soLuong, TextBox TongGia, ComboBox pTTT, DateTime ngayNhan, DateTime ngayTra)
        {
            ChiTietDatPhong dp = new ChiTietDatPhong
            {
                MaChiTietDatPhong = maCT.Text,
                MaDatPhong = maDatP.Text,
                MaKhachHang = maKH,
                MaPhong = maPhong.Text,
                MaLoaiPhong = tenPhong.Text,
                TinhTrang = tinhTrang.Text,
                GiaMoiDem = float.Parse(gia.Text),
                SoLuongPhong = int.Parse(soLuong.Text),
                TongGia = float.Parse(gia.Text) * int.Parse(soLuong.Text),

                PhuongThucThanhToan = pTTT.SelectedItem.ToString(),
                NgayNhanPhong = ngayNhan,
                NgayTraPhong = ngayTra

            };


            DAO_DatPhong.Instance.Sua(dp);
        }

    }

}
