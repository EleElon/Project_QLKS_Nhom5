using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyKhachSan
{
    internal class ThayDoichuoiKetNoi
    {
        private static string connectionString;

        public static void SetConnectionString(string chuoi)
        {
            connectionString = chuoi;
        }

        public static string GetConnectionString()
        {
            return connectionString;
        }
    }
}
