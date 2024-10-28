using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace DAO
{
    public class DAO_User
    {
        private static DAO_User instance;
        public static DAO_User Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DAO_User();
                }
                return instance;
            }
        }
        private DAO_User() { }
        public bool KiemTraNhapMKDungSai(string tenTK, string matKhau)
        {
            using(DBQuanLyKhachSanDataContext db = new DBQuanLyKhachSanDataContext(ThayDoiChuoi.GetConnectionString()))
            {
                var matKhauDaLuu = (from ds in db.Users
                                    where ds.UserName == tenTK
                                    select ds.PassWordd).FirstOrDefault();
                return matKhauDaLuu == matKhau;
            }
        }


        public void DoiChuoiketNoi(string chuoi)
        {
            ThayDoiChuoi.SetConnectionString($"Data Source={chuoi};Initial Catalog=QLKS;Integrated Security=True");
        }
    }
}
