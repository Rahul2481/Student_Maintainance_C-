using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Maintainance.Business;
using System.Data.SqlClient;

namespace Student_Maintainance.DataAccess
{
    public static class StudentDB
    {
        public static void SaveRecords(Student st)
        {
            SqlConnection connDB = new SqlConnection();
            SqlCommand cmdInsert = new SqlCommand();
            cmdInsert.CommandText = "INSERT INTO STUDENT_INFO" + "VALUES(" + st.StudentNumber + "," + st.FirstName
                                                                       + st.LastName + "," + st.PhoneNumber + "," + st.Email + ")";
            cmdInsert.Connection = connDB;
            cmdInsert.ExecuteNonQuery();
            connDB.Close();
        }


        public static List<Student> GetRecordList()
        {
            List<Student> listSt = new List<Student>();

            SqlConnection connDB = UtilityDB.ConnectDB();

            SqlCommand cmdSelect = new SqlCommand("SELECT * FROM Student_Info", connDB);
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Student st;
            while (sqlReader.Read())
            {

                st = new Student();


                st.StudentNumber = Convert.ToInt32(sqlReader["StudentNumber"]);
                st.FirstName = sqlReader["FirstName"].ToString();
                st.LastName = sqlReader["LastName"].ToString();
                st.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                st.Email = sqlReader["Email"].ToString();

                listSt.Add(st);

            }
            return listSt;

        }

        public static Student GetRecord(int stN)
        {
            SqlConnection connDB = UtilityDB.ConnectDB();

            SqlCommand cmdSelect = new SqlCommand();

            cmdSelect.CommandText = "SELECT * FROM Student_info " +
                                    "WHERE StudentNumber = " + stN;
            cmdSelect.Connection = connDB;
            SqlDataReader sqlReader = cmdSelect.ExecuteReader();
            Student st = new Student();
            if (sqlReader.Read())
            {
                st.StudentNumber = Convert.ToInt32(sqlReader["StudentNumber"]);
                st.FirstName = sqlReader["FirstName"].ToString();
                st.LastName = sqlReader["LastName"].ToString();
                st.PhoneNumber = sqlReader["PhoneNumber"].ToString();
                st.Email = sqlReader["Email"].ToString();

            }
            else
            {
                st = null;
            }

            return st;
        }
    }
}