using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Connection
    {
        public static string Cn = Properties.Settings.Default.Cn;
    }
}
