using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Flipkart.Connections
{
    public class DBConnection
    {

        public static SqlConnection CreateConnection()
        {
            SqlConnection con = new SqlConnection("data source=.; database=FLIPKART ;Integrated security=SSPI");//key value paris

            return con;
        }
    }
}