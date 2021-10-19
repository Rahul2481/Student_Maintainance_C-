using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Student_Maintainance.Validation;
using System.Windows.Forms;
using Student_Maintainance.Business;
using System.Data.SqlClient;
using Student_Maintainance.DataAccess;

namespace Student_Maintainance.GUI
{
    public partial class FormStudent : Form
    {
        public FormStudent()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string tempId = textBoxStudentNumber.Text.Trim();
            if (!Validator.IsValidId(tempId, 7))
            {
                MessageBox.Show("Invalid Student Number", "Error");
                textBoxStudentNumber.Clear();
                textBoxStudentNumber.Focus();
                return;
            }

            Student st = new Student();
            st = st.GetStudent(Convert.ToInt32(tempId));
            if (st != null)
            {
                MessageBox.Show("This Student Number already exists!", "Duplicate Student Number");
                textBoxStudentNumber.Clear();
                textBoxStudentNumber.Focus();
                return;
            }

            string tempFname = textBoxFName.Text.Trim();
            if (!Validator.IsValidName(tempFname))
            {
                MessageBox.Show("Invalid First Name", "Error");
                textBoxFName.Clear();
                textBoxFName.Focus();
                return;
            }

            string tempLname = textBoxLName.Text.Trim();
            if (!Validator.IsValidName(tempLname))
            {
                MessageBox.Show("Invalid Last Name", "Error");
                textBoxLName.Clear();
                textBoxLName.Focus();
                return;
            }

            string tempPNum = textBoxPNumber.Text;
            if (!Validator.IsValidId(tempPNum, 10))
            {
                MessageBox.Show("Invalid Phone", "Error");
                textBoxPNumber.Clear();
                textBoxPNumber.Focus();
                return;
            }

            string tempEmail = textBoxEmail.Text.Trim();
            if (!Validator.IsValidEmail(tempEmail))
            {
                MessageBox.Show("Invalid Email", "Error");
                textBoxEmail.Clear();
                textBoxEmail.Focus();
                return;
            }
            Student st1 = new Student();
            
            st1.StudentNumber = Convert.ToInt32(textBoxStudentNumber.Text);
            st1.FirstName = textBoxFName.Text.Trim();
            st1.LastName = textBoxLName.Text.Trim();
            st1.PhoneNumber = textBoxPNumber.Text;
            st1.Email = textBoxEmail.Text;
            st1.SaveStudent(st1);
            MessageBox.Show("Student Info saved successfully", "Confirmation");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string tempId = textBoxStudentNumber.Text.Trim();
            if (!Validator.IsValidId(tempId, 7))
            {
                MessageBox.Show("Invalid Student Number", "Error");
                textBoxStudentNumber.Clear();
                textBoxStudentNumber.Focus();
                return;
            }


            Student st = new Student();
            st = st.GetStudent(Convert.ToInt32(textBoxStudentNumber.Text.Trim()));
            if (st != null)
            {
                textBoxStudentNumber.Text = st.StudentNumber.ToString();
                textBoxFName.Text = st.FirstName;
                textBoxLName.Text = st.LastName;
                textBoxPNumber.Text = st.PhoneNumber;
                textBoxEmail.Text = st.Email;

            }
            else
            {
                MessageBox.Show("Student not found !", "Invalid Student Number");
                textBoxStudentNumber.Clear();
                textBoxStudentNumber.Focus();
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            Student st = new Student();
            List<Student> listSt = new List<Student>();
            listSt = st.GetStudentList();
            listView1.Items.Clear();
            if (listSt != null)
            {
                foreach (Student anSt in listSt)
                {
                    ListViewItem item = new ListViewItem(anSt.StudentNumber.ToString());
                    item.SubItems.Add(anSt.FirstName);
                    item.SubItems.Add(anSt.LastName);
                    item.SubItems.Add(anSt.PhoneNumber);
                    item.SubItems.Add(anSt.Email);
                    listView1.Items.Add(item);
                }

            }
            else
            {

            }
        }

        private void btnStatus_Click(object sender, EventArgs e)
        {
            SqlConnection conn = UtilityDB.ConnectDB();
            MessageBox.Show(conn.State.ToString(), "Database Connection");
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
