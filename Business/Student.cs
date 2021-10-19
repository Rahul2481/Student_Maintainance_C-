using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Maintainance.DataAccess;

namespace Student_Maintainance.Business
{
    public class Student
    {
        private int studentNumber;
        private string firstName;
        private string lastName;
        private string phoneNumber;
        private string email;

        public int StudentNumber { get => studentNumber; set => studentNumber = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string LastName { get => lastName; set => lastName = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Email { get => email; set => email = value; }


        public Student GetStudent(int stN)
        {
            return StudentDB.GetRecord(stN);
        }

        public List<Student> GetStudentList()
        {
            return StudentDB.GetRecordList();
        }
        public void SaveStudent(Student st)
        {
            StudentDB.SaveRecords(st);
        }

    }
}