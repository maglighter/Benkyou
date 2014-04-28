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
            cn.Open();
            for (int i = 0; i < answerchoosed.Length; i++)
            {
                //if (answerchoosed[i] == false || answers[i] == 0)
                //    cmd.CommandText = "INSERT INTO Students (first_name, second_name, [group], time_login) VALUES ('" + i + "', '" + answers[i] + "', '" + group
                //+ "', '" + DateTime.Now.ToString("T") + "');";
                cmd.ExecuteNonQuery();
            }
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

        public void show_students()
        {
            cmd.CommandText = "SELECT * FROM Students;";
            cn.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                for (int i = 0; i < 5; i++)
                    Console.Write(dr[i].ToString() + " ");
                Console.WriteLine();
            }
            dr.Close();
            cn.Close();
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
