using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Lib;

namespace TestSystem
{
    public partial class ViewDB : Form
    {
        DataTable result_query_table;
        Lib.StudentsDB sdb = new StudentsDB();
        List<int> st = new List<int>();
        List<int> cs = new List<int>();
        

        public ViewDB()
        {
            InitializeComponent();
        }

        private void ViewDB_Load(object sender, EventArgs e)
        {
            sdb.cn.Open();
            st = new List<int>();
            sdb.cmd.CommandText = "SELECT * FROM Students";
            sdb.dr = sdb.cmd.ExecuteReader();
            if (sdb.dr.HasRows)
            {
                while (sdb.dr.Read())
                {
                    string text = sdb.dr["first_name"].ToString() + " " + sdb.dr["second_name"].ToString() + ", " + sdb.dr["group"].ToString();
                    st.Add(Convert.ToInt32(sdb.dr["ID"]));
                    listBox1.Items.Add(text);
                }
            }
            sdb.dr.Close();
            sdb.cn.Close();
            
        }

        private void load_lb2()
        {
            listBox2.Items.Clear();
            
            dataGridView1.DataSource = null;
            cs = new List<int>();
            sdb.cn.Open();
            
            sdb.cmd.CommandText = "SELECT Courses.ID, Courses.course FROM Students INNER JOIN (Courses INNER JOIN Results ON Courses.ID = Results.course_id) ON Students.ID = Results.student_id WHERE (((Students.ID)=" + st[listBox1.SelectedIndex] + "));";
            sdb.dr = sdb.cmd.ExecuteReader();
            if (sdb.dr.HasRows)
            {
                while (sdb.dr.Read())
                {
                    
                    listBox2.Items.Add(sdb.dr["course"].ToString());
                    cs.Add(Convert.ToInt32(sdb.dr["ID"]));
                }
                
            }
            sdb.dr.Close();
            sdb.cn.Close();
            if (listBox2.Items.Count > 0)
                listBox2.SelectedIndex = 0;
        }

        private void load_dgv1()
        {
            result_query_table = sdb.query_table_return("SELECT Answers.question_num, Answers.answer_num, Answers.is_right_answer FROM (Courses INNER JOIN Results ON Courses.ID = Results.course_id) INNER JOIN Answers ON Results.ID = Answers.result_id WHERE (((Results.student_id)=" + st[listBox1.SelectedIndex] + ") AND ((Results.course_id)=" + cs[listBox2.SelectedIndex] + "));");
            dataGridView1.DataSource = result_query_table;
            dataGridView1.Columns[0].HeaderText = "Номер вопроса";
            dataGridView1.Columns[1].HeaderText = "Номер ответа";
            dataGridView1.Columns[2].HeaderText = "Верность";
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            if (dataGridView1.RowCount > 0)
            {
                sdb.cn.Open();
                sdb.cmd.CommandText = "SELECT Results.right_answers FROM (Courses INNER JOIN Results ON Courses.ID = Results.course_id) INNER JOIN Answers ON Results.ID = Answers.result_id WHERE (((Results.student_id)=" + st[listBox1.SelectedIndex] + ") AND ((Results.course_id)=" + cs[listBox2.SelectedIndex] + "));";
                label4.Text = Convert.ToInt32(sdb.cmd.ExecuteScalar()).ToString() + " %";
                sdb.cn.Close();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndices.Count > 0)
                load_lb2();
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_dgv1();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить все результаты тестирований? Это удалит все данные студентов и их ответы.", "Подтверждение", MessageBoxButtons.YesNo , MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (dialogResult == DialogResult.Yes)
            {
                if (sdb.clear_data())
                {
                    MessageBox.Show("Все данные были удалены. ", "Операция завершена", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var results_form = new Results();
            results_form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // ShowDialog(new LiveSwitch.TextControl.Form1());
            var TS = new LiveSwitch.TextControl.Form1();
            TS.ShowDialog();
        }

    }
}
