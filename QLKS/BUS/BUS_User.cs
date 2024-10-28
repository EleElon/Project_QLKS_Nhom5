using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_User
    {
        private static BUS_User instance;
        public static BUS_User Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BUS_User();
                }
                return instance;
            }
        }
        private BUS_User() { }

        public void DoiChuoiKetNoi(string chuoiKet)
        {
            DAO_User.Instance.DoiChuoiketNoi(chuoiKet);
        }
    }
}
