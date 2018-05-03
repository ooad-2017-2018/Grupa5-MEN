using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace eRouting2
{
    public class DBConnectionString
    {
        private String s;
        public DBConnectionString()
        {
            s = "Server=tcp:ooad-men.database.windows.net,1433;Initial Catalog=OOADBaza;Persist Security Info=False;User ID=user;Password=ooad;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }
        public String GetString() { return s; }
    }
}
