using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class DAO_DangNhap
    {
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
