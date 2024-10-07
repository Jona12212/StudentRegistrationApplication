using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace StudentRegistrationApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            PopulateCoursesComboBox();
            PopulateDateOfBirthComboBoxes();
        }
        private void PopulateCoursesComboBox()
        {
            cb_Course.Items.Add("BS in Computer Science");
            cb_Course.Items.Add("BS in Information Technology");
            cb_Course.Items.Add("BS in Business Administration");
            cb_Course.Items.Add("BS in Tourism");
        }

        private void PopulateDateOfBirthComboBoxes()
        {
            for (int day = 1; day <= 31; day++)
            {
                cb_Day.Items.Add(day);
            }

            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            foreach (string month in months)
            {
                cb_Month.Items.Add(month);
            }

            int currentYear = DateTime.Now.Year;
            for (int year = 1900; year <= currentYear; year++)
            {
                cb_Year.Items.Add(year);
            }
        }
        private void DisplayStudentInfo(string firstName, string middleName, string lastName, string gender, string course)
        {
            string fullName = $"{firstName} {middleName} {lastName}";
            MessageBox.Show($"Student Name: {fullName}\nGender: {gender}\nCourse: {course}");
        }

        private void DisplayStudentInfo(string firstName, string lastName, string course, string gender, DateTime dateOfBirth)
        {
            string fullName = $"{firstName} {lastName}";
            MessageBox.Show($"Student Name: {fullName}\nGender: {gender}\nCourse: {course}\nDate of Birth: {dateOfBirth.ToShortDateString()}");
        }

        private void DisplayStudentInfo(string lastName, string firstName, string middleName, string gender, string course, DateTime dateOfBirth)
        {
            string fullName = $"{firstName} {middleName} {lastName}";
            MessageBox.Show($"Student Name: {fullName}\nGender: {gender}\nCourse: {course}\nDate of Birth: {dateOfBirth.ToShortDateString()}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Retrive values from form controls
            string lastName = tb_LastName.Text;
            string firstName = tb_FirstName.Text;
            string middleName = tb_MiddleName.Text;
            int day = Convert.ToInt32(cb_Day.SelectedItem);
            string selectedMonth = cb_Month.SelectedItem.ToString();
            int month = Array.IndexOf(new string[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" }, selectedMonth) + 1;
            int year = Convert.ToInt32(cb_Year.SelectedItem);
            DateTime studentDOB = new DateTime(year, month, day);
            string gender = rb_Male.Checked ? "Male" : "Female";
            string course = cb_Course.Text;

            // Invoke the overloaded methods
            if (string.IsNullOrEmpty(middleName))
            {
                DisplayStudentInfo(firstName, lastName, course, gender, studentDOB);
            }
            else if (cb_Day.SelectedItem == null || cb_Month.SelectedItem == null || cb_Year.SelectedItem == null)
            {
                DisplayStudentInfo(firstName, middleName, lastName, gender, course);
            }
            else
            {
                DisplayStudentInfo(lastName, firstName, middleName, gender, course, studentDOB);
            }


        }
    }
}
