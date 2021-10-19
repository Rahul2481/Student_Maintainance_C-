using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace Student_Maintainance.DataAccess
{
    public static class UtilityDB
    {
        public static SqlConnection ConnectDB()
        {            
            //conn.ConnectionString = ConfigurationManager.ConnectionStrings["ClientDB_Connection"].ConnectionString;
            //conn.Open();
            //return conn;

            SqlConnection connDB = new SqlConnection();
            connDB.ConnectionString = @"server=DESKTOP-02B6TN1\MSSQLSERVER2017; database=StudentDB; user=sa; password=Rahul2481";
            connDB.Open();
            return connDB;
        }
    }
}
