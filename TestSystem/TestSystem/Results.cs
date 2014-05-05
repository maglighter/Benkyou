using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lib;

namespace TestSystem
{
    public partial class Results : Form
    {
        DataTable result_query_table;
        Lib.StudentsDB sdb = new StudentsDB();
        List<int> st = new List<int>();
        List<int> cs = new List<int>();


        public Results()
        {
            InitializeComponent();
        }

        private void Results_Load(object sender, EventArgs e)
        {
            sdb.cn.Open();
            st = new List<int>();
            sdb.cmd.CommandText = "SELECT * FROM Results";
            sdb.dr = sdb.cmd.ExecuteReader();
            if (sdb.dr.HasRows)
            {
                while (sdb.dr.Read())
                {
                    //string text = sdb.dr["first_name"].ToString() + " " + sdb.dr["second_name"].ToString() + ", " + sdb.dr["group"].ToString();
                    st.Add(Convert.ToInt32(sdb.dr["ID"]));
                    //listBox1.Items.Add(text);
                }
            }
            sdb.dr.Close();
            sdb.cn.Close();
            string request = "SELECT Students.second_name, Students.first_name, Students.group, Courses.course, Results.right_answers, Results.time_end FROM Students INNER JOIN (Courses INNER JOIN Results ON Courses.ID = Results.course_id) ON Students.ID = Results.student_id;";
            result_query_table = sdb.query_table_return(request);
            dataGridView1.DataSource = result_query_table;
            dataGridView1.Columns[0].HeaderText = "Фамилия";
            dataGridView1.Columns[1].HeaderText = "Имя";
            dataGridView1.Columns[2].HeaderText = "Группа";
            dataGridView1.Columns[3].HeaderText = "Курс";
            dataGridView1.Columns[4].HeaderText = "Результат, %";
            dataGridView1.Columns[5].HeaderText = "Дата прохождения";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
