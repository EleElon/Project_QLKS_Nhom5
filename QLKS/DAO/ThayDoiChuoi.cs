using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    internal class ThayDoiChuoi
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
