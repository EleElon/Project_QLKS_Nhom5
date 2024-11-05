using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_CoSoVatChat
    {
        DAO_CoSoVatChat DAO_CoSoVatChat = new DAO_CoSoVatChat();
        public List<CoSoVatChat> Xem()
        {
            return DAO_CoSoVatChat.Xem();
        }
        public bool ThemCoSoVatChat(string maCSVC, string maPhong, string tenCSVC, string moTa)
        {
            return DAO_CoSoVatChat.ThemCoSoVatChat(maCSVC, maPhong, tenCSVC, moTa);
        }

        public bool SuaCoSoVatChat(CoSoVatChat coSoVatChat)
        {
            return DAO_CoSoVatChat.SuaCoSoVatChat(coSoVatChat);
        }

        public bool XoaCoSoVatChat(string maCSVC)
        {
            return DAO_CoSoVatChat.XoaCoSoVatChat(maCSVC);
        }
    }
}
