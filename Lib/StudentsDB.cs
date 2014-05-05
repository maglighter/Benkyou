using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;
using System.Data;

namespace Lib
{
    public class StudentsDB
    {
        public OleDbCommand cmd = new OleDbCommand();
        public OleDbConnection cn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"..\\..\\..\\Lib\\bin\\Debug\\students_db.accdb\"");
        public OleDbDataReader dr;
        public OleDbDataAdapter da;

        public StudentsDB()
        {
            cmd.Connection = cn;
        }

        public void insert_student(string first_name, string second_name, string group)
        {
            Console.WriteLine(Lib.Properties.Settings.Default.students_dbConnectionString);
            cmd.CommandText = "INSERT INTO Students (first_name, second_name, [group], time_login) VALUES ('" + first_name + "', '" + second_name + "', '" + group 
            + "', '" + DateTime.Now.ToString("T") + "');";
            Console.WriteLine("Inserted!!! " + DateTime.Now.ToString("T"));
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

        public void save_test_results(int[] answers, string course)
        {
           // insert_answers(answers);
        }

        public void insert_answers(int[] answers, bool[] answerchoosed, string course)
        {
            string student_id = get_last_student_id();
            cn.Open();
            cmd.CommandText = "SELECT Courses.ID FROM Courses WHERE Courses.course = '" + course + "';";
            string course_id = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "INSERT INTO Results (course_id, student_id, time_end) VALUES ('" + course_id + "','" + student_id  + "','" + DateTime.Now.ToString("T") + "');";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "SELECT ID FROM Results WHERE Results.course_id = " + course_id + " and Results.student_id = " + student_id + ";";
            string result_id = cmd.ExecuteScalar().ToString();
            cmd.CommandText = "SELECT RightAnswers.question_num, RightAnswers.answer_num FROM RightAnswers WHERE RightAnswers.course_id = " + course_id +";";
            dr = cmd.ExecuteReader();
            int i = 0;
            string is_right_answer;
            int[] r_answers = new int[answers.Length];
            while (dr.Read())
            {
                r_answers[i] = Convert.ToInt32(dr[1].ToString());
                i++;
            }
            dr.Close();
            int right_ch = 0;
            for (i = 0; i<answers.Length; i++)
            {
                if (answerchoosed[i] == false)
                {
                    cmd.CommandText = "INSERT INTO Answers (result_id, question_num, answer_num, is_right_answer) VALUES (" + result_id + ", " + (i + 1).ToString() + ", " + "-1" + ", " + "False" + ");";
                }
                else
                {
                    if (r_answers[i] == answers[i] + 1)
                    {
                        is_right_answer = "True";
                        right_ch++;
                    }
                    else
                        is_right_answer = "False";
                    cmd.CommandText = "INSERT INTO Answers (result_id, question_num, answer_num, is_right_answer) VALUES (" + result_id + ", " + (i + 1).ToString() + ", " + (answers[i]+1).ToString() + ", " + is_right_answer + ");";
                }
                cmd.ExecuteNonQuery();
            }
            int total = 0;
            if (right_ch != 0)
                total = (int)(0.5f + ((100f * right_ch) / answers.Length));
            cmd.CommandText = "UPDATE Results SET right_answers = " + total.ToString() + " WHERE ID = " + result_id + ";";
            cmd.ExecuteNonQuery();

            cn.Close();
        }

        public DataTable query_table_return(string query)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = query;
            cn.Open();
            da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            cn.Close();
            da.Dispose();
            return dt;
        }

        public string get_last_student_id()
        {
            cmd.CommandText = "SELECT * FROM Students;";
            cn.Open();
            dr = cmd.ExecuteReader();
            string last_student_id = "";
            while (dr.Read())
            {
 //               for (int i = 0; i < 5; i++)
  //                  Console.Write(dr[i].ToString() + " ");
  //              Console.WriteLine();
                last_student_id = dr[0].ToString();
            }
            dr.Close();
            cn.Close();
            return last_student_id;
        }

        public bool clear_data()
        {
            cn.Open();
            cmd.CommandText = "DELETE * FROM Results;";
            cmd.ExecuteNonQuery();
            cmd.CommandText = "DELETE * FROM Students;";
            cmd.ExecuteNonQuery();
            cn.Close();
            return true;
        }
    }
}
