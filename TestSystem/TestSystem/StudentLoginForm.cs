using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Lib;

namespace TestSystem
{
    public partial class StudentLoginForm : Form
    {
        public bool result = false;
        public StudentsDB sdb;

        public StudentLoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            TeacherLogin tlform = new TeacherLogin();
            this.Visible = false;
            tlform.ShowDialog();
            this.Visible = true;
        }

        private void StudentLoginForm_Load(object sender, EventArgs e)
        {

        }

        private void userLoginButton_Click(object sender, EventArgs e)
        {
            if (firstNameTB.TextLength != 0 && secondNameTB.TextLength != 0 && groupTB.TextLength != 0)
            {
                sdb = new StudentsDB();
                sdb.insert_student(secondNameTB.Text, firstNameTB.Text, groupTB.Text);
                sdb.show_students();
                this.result = true;
                this.Close();
            }
            else
                MessageBox.Show("Пожалуйста, заполните все поля формы входа.", "Не все поля заполнены", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
