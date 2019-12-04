using System;
using System.Collections.Generic;
using System.Text;

namespace DowntownSAMP.Data
{
    public class DbHandler
    {
        public static string GetConnectionString()
        {
            string host = "localhost";
            string uid = "root";
            string password = "";
            string db = "dtsamp";
            string ssl = "none";

            return "SERVER=" + host + "; DATABASE=" + db + "; UID=" + uid + "; PASSWORD=" + password + "; SSLMODE=" + ssl + ";";
        }
    }
}
