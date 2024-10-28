using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class BUS_DangNhap
    {
        //private static BUS_DangNhap instance;
        //public static BUS_DangNhap Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new BUS_DangNhap();
        //        }
        //        return instance;
        //    }
        //}
        //private BUS_DangNhap() { }

        DAO_DangNhap dao_dangNhap = new DAO_DangNhap();

        public bool CheckDangNhap(string usename,string pass)
        {
           return dao_dangNhap.CheckLogin(usename, pass);
        }
    }
}
