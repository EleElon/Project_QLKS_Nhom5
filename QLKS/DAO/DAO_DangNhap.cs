using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_DangNhap
    {
        //private static DAO_DangNhap instance;
        //public static DAO_DangNhap Instance
        //{
        //    get
        //    {
        //        if (instance == null)
        //        {
        //            instance = new DAO_DangNhap();
        //        }
        //        return instance;
        //    }
        //}
        //private DAO_DangNhap() { }

        public bool CheckLogin(string username, string password)
        {
            using (DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var result = db.Users.Where(item => item.UserName == username && item.PassWordd == password).FirstOrDefault();
                return result != null;
            }
        }
    }
}
