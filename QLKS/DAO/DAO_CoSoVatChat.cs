using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_CoSoVatChat
    {
        public List<CoSoVatChat> Xem()
        {
            List<CoSoVatChat> data = new List<CoSoVatChat>();
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var coSoVatChatList = (from csvc in db.CoSoVatChats
                                       select new
                                       {
                                           csvc.MaPhong,
                                           csvc.MaCoSoVatChat,
                                           csvc.TenCoSoVatChat,
                                           csvc.MoTa
                                       }).ToList();

                foreach (var item in coSoVatChatList)
                {
                    CoSoVatChat csvcItem = new CoSoVatChat
                    {
                        MaPhong = item.MaPhong,
                        MaCoSoVatChat = item.MaCoSoVatChat,
                        TenCoSoVatChat = item.TenCoSoVatChat,
                        MoTa = item.MoTa
                    };

                    data.Add(csvcItem);
                }
            }
            return data;
        }
        public bool ThemCoSoVatChat(string maCSVC, string maPhong, string tenCSVC, string moTa)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                try
                {
                    // Kiểm tra xem mã cơ sở vật chất đã tồn tại chưa
                    if (db.CoSoVatChats.Any(c => c.MaCoSoVatChat == maCSVC))
                    {
                        return false; // Mã cơ sở vật chất đã tồn tại
                    }

                    // Tạo mới cơ sở vật chất
                    CoSoVatChat csvc = new CoSoVatChat
                    {
                        MaCoSoVatChat = maCSVC,
                        MaPhong = maPhong,
                        TenCoSoVatChat = tenCSVC,
                        MoTa = moTa
                    };

                    // Thêm cơ sở vật chất vào cơ sở dữ liệu
                    db.CoSoVatChats.InsertOnSubmit(csvc);
                    db.SubmitChanges();
                    return true; // Thêm thành công
                }
                catch (Exception ex)
                {
                    throw ex; // Ném ra lỗi nếu có
                }
            }
        }

        public bool XoaCoSoVatChat(string maCSVC)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var existingCSVC = db.CoSoVatChats.SingleOrDefault(csvc => csvc.MaCoSoVatChat == maCSVC);
                if (existingCSVC != null)
                {
                    db.CoSoVatChats.DeleteOnSubmit(existingCSVC);
                    db.SubmitChanges();
                    return true;
                }
                return false; // Không tìm thấy cơ sở vật chất
            }
        }
        public bool SuaCoSoVatChat(CoSoVatChat coSoVatChat)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var existingCSVC = db.CoSoVatChats.SingleOrDefault(csvc => csvc.MaCoSoVatChat == coSoVatChat.MaCoSoVatChat);
                if (existingCSVC != null)
                {
                    existingCSVC.MaPhong = coSoVatChat.MaPhong;
                    existingCSVC.TenCoSoVatChat = coSoVatChat.TenCoSoVatChat;
                    existingCSVC.MoTa = coSoVatChat.MoTa;

                    db.SubmitChanges();
                    return true;
                }
                return false; // Không tìm thấy cơ sở vật chất
            }
        }

    }
}
